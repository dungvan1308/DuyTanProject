//===============================================================================
// SacomBank Card Center
//===============================================================================
// This file contains the implementations of the base service abstract class.
//===============================================================================
// SacomBank Card Center
//===============================================================================
using System;
using System.Data;
using System.Text;
using System.Reflection;
using ScheduleDBCore.Enum;

namespace ScheduleDBCore
{
    public abstract class SQLBaseService : IDisposable
    {
        protected SqlHelper _sqlHelper;
        protected bool _disposed;
        protected StringBuilder _sqlStr;
        protected StringBuilder _sqlStrDetail;
        protected int _userId;
        protected int _resultCode;

        #region Construction
        protected SQLBaseService(int userId)
        {
            _sqlHelper = new SqlHelper();
            _sqlStr = new StringBuilder();
            _sqlStrDetail = new StringBuilder();
            _disposed = false;
            _userId = userId;
        }
        protected SQLBaseService(int userId, ConnectionType connectionType)
        {
            _sqlHelper = new SqlHelper(connectionType);
            _sqlStr = new StringBuilder();
            _sqlStrDetail = new StringBuilder();
            _disposed = false;
            _userId = userId;
        }
        ~SQLBaseService()
        {
            Dispose(false);
        }
        #endregion

        #region Property
        protected SqlHelper SqlHelper
        {
            get { return _sqlHelper; }
            set { _sqlHelper = value; }
        }
        protected int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        #endregion

        #region Base Method
        protected int BuildErrorMessage(System.Exception exception, MethodInfo methodInfo)
        {
            try
            {
                _sqlHelper.Reset();
                _sqlHelper.AddParameter("@ErrorCodeId", SqlDbType.Int, -1);
                _sqlHelper.AddParameter("@UserId", SqlDbType.Int, _userId);
                _sqlHelper.AddParameter("@MethodName", SqlDbType.NVarChar, methodInfo.Name);
                if (exception.Message.Length > 255)
                    _sqlHelper.AddParameter("@Message", SqlDbType.NVarChar, exception.Message.Substring(0, 254));
                else
                    _sqlHelper.AddParameter("@Message", SqlDbType.NVarChar, exception.Message);

                _sqlHelper.AddParameter("@CreatedDate", SqlDbType.SmallDateTime, DateTime.Now);
                _sqlHelper.ExecuteSqlNonQuery("INSERT INTO [SC_LogError] ([UserId], [ErrorCodeId], [MethodName], [Message], [CreatedDate]) VALUES (@UserId, @ErrorCodeId, @MethodName, @Message, @CreatedDate)");
                _sqlHelper.Connection.Close();
            }
            catch (Exception ex)
            {
                //LogFunction.SaveErrorLog(ex, "Execute SQL Failed.");
            }
            return -1;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void ResetValue()
        {
            _sqlStr.Remove(0, _sqlStr.Length);
            _sqlStrDetail.Remove(0, _sqlStrDetail.Length);
            _sqlHelper.Reset();

        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // release managed resource
                    _sqlHelper.Reset();
                    _sqlHelper.Disconnect();
                    _sqlStr.Remove(0, _sqlStr.Length);
                    _sqlStr = null;
                }
                //release unmanaged resources here
            }
            _disposed = true;
        }
        #endregion

    }
}

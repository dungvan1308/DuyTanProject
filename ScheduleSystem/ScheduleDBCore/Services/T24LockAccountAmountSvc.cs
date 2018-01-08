using ScheduleDBCore.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDBCore.Service
{
    public class T24LockAccountAmountSvc : SQLBaseService
    {
        public T24LockAccountAmountSvc(int userId) : base(userId) { }
        public T24LockAccountAmountSvc(int userId, ConnectionType connectionType) : base(userId, connectionType) { }
                
        public DataTable GetAccount4CheckLockAmt()
        {
            base.ResetValue();
            DataTable result;
            try
            {
                result = this._sqlHelper.ExecuteSPDataTable("T24Utilities_GetAccount4CheckLockAmt");
            }
            catch (SystemException exception)
            {
                BuildErrorMessage(exception, (MethodInfo)MethodBase.GetCurrentMethod());
                result = new DataTable();
            }
            return result;
        }

        public int PutData2T24LockAmountInfo(DataTable dt)
        {
            base.ResetValue();
            try
            {
                this._sqlHelper.AddParameter("@tableName", SqlDbType.Structured, dt);
                this._sqlHelper.ExecuteSPNonQuery("T24Utilities_PutData2T24LockAmountInfo");
            }
            catch (SystemException exception)
            {
                BuildErrorMessage(exception, (MethodInfo)MethodBase.GetCurrentMethod());
                return -1;
            }
            return 1;
        }

        public int PutData2T24Utilities(DataTable dt, int service)
        {
            base.ResetValue();
            try
            {
                this._sqlHelper.AddParameter("@tableName", SqlDbType.Structured, dt);
                this._sqlHelper.AddParameter("@Service", SqlDbType.TinyInt, service);
                this._sqlHelper.ExecuteSPNonQuery("RegOnline.dbo.T24Utilities_PutData2T24Utilities");
            }
            catch (SystemException exception)
            {
                BuildErrorMessage(exception, (MethodInfo)MethodBase.GetCurrentMethod());
                return -1;
            }
            return 1;
        }

    }
}

//===============================================================================
// SacomBank Card Center
//===============================================================================
// This file contains the implementations of the SQL Helper class.
//===============================================================================
// SacomBank Card Center
//===============================================================================
using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using ScheduleDBCore.Enum;

namespace ScheduleDBCore
{
    public class SqlHelper
    {
        #region Protected Member Variables
        protected string _connectionString = String.Empty;
        protected SqlParameterCollection _parameterCollection;
        protected ArrayList _parameters = new ArrayList();
        protected bool _convertEmptyValuesToDbNull = false;
        protected bool _convertMinValuesToDbNull = false;
        protected bool _convertMaxValuesToDbNull = false;
        protected SqlConnection _connection;
        protected int _commandTimeout = 60;
        protected SqlCommand _cmd;
        #endregion Protected Member Variables

        #region Contructors
        public SqlHelper()
        {
            _connectionString = ConfigurationManager.AppSettings["ScheduleDB"];
            _cmd = new SqlCommand();
        }
        public SqlHelper(ConnectionType connectionType)
        {
            if (connectionType == ConnectionType.ScheduleDB)
            {
                _connectionString = ConfigurationManager.AppSettings["ScheduleDB"];
            }            
            else if (connectionType == ConnectionType.MIS)
            {
                _connectionString = ConfigurationManager.AppSettings["MIS"];
            }
            else 
            {
                _connectionString = ConfigurationManager.AppSettings["ScheduleDB"];
            }

            //string[] arr = _connectionString.Split(';');
            //string userName = arr[arr.Length - 3].Substring(arr[arr.Length - 3].IndexOf("=") + 1);
            //string password = arr[arr.Length - 2].Substring(arr[arr.Length - 2].IndexOf("=") + 1);
            //_connectionString = arr[0] + ";" + arr[1] + ";" +
            //"uid=" + Decrypt3DES(userName, ConfigurationManager.AppSettings["DBPassphrase"]) + ";" +
            //"pwd=" + Decrypt3DES(password, ConfigurationManager.AppSettings["DBPassphrase"]) + ";";
            
            _cmd = new SqlCommand();
        }
        #endregion Contructors

        #region Properties
        public string ConStr
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        public int CommandTimeout
        {
            get
            {
                return _commandTimeout;
            }
            set
            {
                _commandTimeout = value;
            }
        }

        public SqlConnection Connection
        {
            get
            {
                return _connection;
            }
            set
            {
                _connection = value;
                ConStr = _connection.ConnectionString;
            }
        }

        public bool ConvertEmptyValuesToDbNull
        {
            get
            {
                return _convertEmptyValuesToDbNull;
            }
            set
            {
                _convertEmptyValuesToDbNull = value;
            }
        }

        public bool ConvertMinValuesToDbNull
        {
            get
            {
                return _convertMinValuesToDbNull;
            }
            set
            {
                _convertMinValuesToDbNull = value;
            }
        }

        public bool ConvertMaxValuesToDbNull
        {
            get
            {
                return _convertMaxValuesToDbNull;
            }
            set
            {
                _convertMaxValuesToDbNull = value;
            }
        }

        public SqlParameterCollection Parameters
        {
            get
            {
                return _parameterCollection;
            }
        }

        public int ReturnValue
        {
            get
            {
                if (_parameterCollection.Contains("@ReturnValue"))
                {
                    return Convert.ToInt32(_parameterCollection["@ReturnValue"].Value);
                }
                else
                {
                    throw new SystemException("You must call the AddReturnValueParameter method before executing your request.");
                }
            }
        }
        #endregion Properties

        #region Execute Methods
        public SqlDataReader ExecuteSqlReader(string sql)
        {
            SqlDataReader reader;
            Connect();
            _cmd.CommandTimeout = CommandTimeout;
            _cmd.CommandText = sql;
            _cmd.Connection = _connection;
            _cmd.CommandType = CommandType.Text;
            CopyParameters();
            reader = _cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
        public void ExecuteSqlNonQuery(string sql)
        {
            Connect();
            _cmd.CommandTimeout = CommandTimeout;
            _cmd.CommandText = sql;
            _cmd.Connection = _connection;
            _cmd.CommandType = CommandType.Text;
            CopyParameters();
            _cmd.ExecuteNonQuery();
            _connection.Close();

        }
        public DataSet ExecuteSqlDataSet(string sql)
        {
            Connect();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            _cmd.CommandTimeout = CommandTimeout;
            _cmd.Connection = _connection;
            _cmd.CommandText = sql;
            _cmd.CommandType = CommandType.Text;
            CopyParameters();
            da.SelectCommand = _cmd;
            da.Fill(ds);
            _connection.Close();
            da.Dispose();
            return ds;
        }
        public DataTable ExecuteSqlDataTable(string sql)
        {
            Connect();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            _cmd.CommandTimeout = CommandTimeout;
            _cmd.Connection = _connection;
            _cmd.CommandText = sql;
            _cmd.CommandType = CommandType.Text;
            CopyParameters();
            da.SelectCommand = _cmd;
            da.Fill(dt);
            da.Dispose();
            _connection.Close();
            return dt;
        }
        public DataView ExecuteSqlDataView(string sql)
        {
            Connect();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            _cmd.CommandTimeout = CommandTimeout;
            _cmd.Connection = _connection;
            _cmd.CommandText = sql;
            _cmd.CommandType = CommandType.Text;
            CopyParameters();
            da.SelectCommand = _cmd;
            da.Fill(dt);
            DataView dv = new DataView(dt);
            dt.Dispose();
            dt = null;
            da.Dispose();
            da = null;
            _connection.Close();
            return dv;
        }
        public object ExecuteSqlScalar(string sql)
        {
            Connect();
            _cmd.CommandTimeout = CommandTimeout;
            _cmd.CommandText = sql;
            _cmd.Connection = _connection;
            _cmd.CommandType = CommandType.Text;
            CopyParameters();
            object obj = _cmd.ExecuteScalar();
            _connection.Close();
            return obj;
        }
        public SqlDataReader ExecuteSPSqlReader(string procedureName)
        {
            SqlDataReader reader;
            Connect();
            _cmd.CommandTimeout = CommandTimeout;
            _cmd.CommandText = procedureName;
            _cmd.Connection = _connection;
            _cmd.CommandType = CommandType.StoredProcedure;
            CopyParameters();
            reader = _cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
        public DataView ExecuteSPDataView(string procedureName)
        {
            Connect();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            _cmd.CommandTimeout = CommandTimeout;
            _cmd.Connection = _connection;
            _cmd.CommandText = procedureName;
            _cmd.CommandType = CommandType.StoredProcedure;
            CopyParameters();
            da.SelectCommand = _cmd;
            da.Fill(dt);
            DataView dv = new DataView(dt);
            dt.Dispose();
            dt = null;
            da.Dispose();
            da = null;
            _connection.Close();
            return dv;
        }
        public DataSet ExecuteSPDataSet(string procedureName)
        {
            Connect();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            _cmd.CommandTimeout = CommandTimeout;
            _cmd.CommandText = procedureName;
            _cmd.Connection = _connection;
            _cmd.CommandType = CommandType.StoredProcedure;
            CopyParameters();
            da.SelectCommand = _cmd;
            da.Fill(ds);
            da.Dispose();
            _connection.Close();
            return ds;
        }
        public DataTable ExecuteSPDataTable(string procedureName)
        {
            Connect();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            _cmd.CommandTimeout = CommandTimeout;
            _cmd.CommandText = procedureName;
            _cmd.Connection = _connection;
            _cmd.CommandType = CommandType.StoredProcedure;
            CopyParameters();
            da.SelectCommand = _cmd;
            da.Fill(dt);
            da.Dispose();
            _connection.Close();
            return dt;
        }
        public void ExecuteSPNonQuery(string procedureName)
        {
            Connect();
            _cmd.CommandTimeout = CommandTimeout;
            _cmd.CommandText = procedureName;
            _cmd.Connection = _connection;
            _cmd.CommandType = CommandType.StoredProcedure;
            CopyParameters();
            _cmd.ExecuteNonQuery();
            _connection.Close();
        }
        public object ExecuteSPScalar(string procedureName)
        {
            Connect();
            _cmd.CommandTimeout = CommandTimeout;
            _cmd.CommandText = procedureName;
            _cmd.Connection = _connection;
            _cmd.CommandType = CommandType.StoredProcedure;
            CopyParameters();
            object obj = _cmd.ExecuteScalar();
            _connection.Close();
            return obj;
        }
        #endregion Execute Methods

        #region AddParameter
        public SqlParameter AddParameter(string name, SqlDbType type, object value)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = ParameterDirection.Input;
            prm.ParameterName = name;
            prm.SqlDbType = type;
            prm.Value = PrepareSqlValue(value);
            _parameters.Add(prm);
            return prm;
        }

        public SqlParameter AddParameter(string name, SqlDbType type, object value, bool convertZeroToDBNull)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = ParameterDirection.Input;
            prm.ParameterName = name;
            prm.SqlDbType = type;
            prm.Value = PrepareSqlValue(value, convertZeroToDBNull);

            _parameters.Add(prm);

            return prm;
        }

        public SqlParameter AddParameter(string name, SqlDbType type, object value, int size)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = ParameterDirection.Input;
            prm.ParameterName = name;
            prm.SqlDbType = type;
            prm.Size = size;
            prm.Value = PrepareSqlValue(value);
            _parameters.Add(prm);
            return prm;
        }

        public SqlParameter AddParameter(string name, SqlDbType type, object value, ParameterDirection direction)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = direction;
            prm.ParameterName = name;
            prm.SqlDbType = type;
            prm.Value = PrepareSqlValue(value);
            _parameters.Add(prm);
            return prm;
        }

        public SqlParameter AddParameter(string name, SqlDbType type, object value, int size, ParameterDirection direction)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = direction;
            prm.ParameterName = name;
            prm.SqlDbType = type;
            prm.Size = size;
            prm.Value = PrepareSqlValue(value);

            _parameters.Add(prm);

            return prm;
        }

        public void AddParameter(SqlParameter parameter)
        {
            _parameters.Add(parameter);
        }
        #endregion AddParameter

        #region Specialized AddParameter Methods
        public object GetOutputParameterValue(string name)
        {

            for (int i = 0; i < _parameters.Count; i++)
            {
                if (((SqlParameter)_parameters[i]).ParameterName == name)
                {
                    return ((SqlParameter)_parameters[i]).Value;
                }
            }
            return null;
        }
        public SqlParameter AddOutputParameter(string name, SqlDbType type)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = ParameterDirection.Output;
            prm.ParameterName = name;
            prm.SqlDbType = type;
            _parameters.Add(prm);
            return prm;
        }

        public SqlParameter AddOutputParameter(string name, SqlDbType type, int size)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = ParameterDirection.Output;
            prm.ParameterName = name;
            prm.SqlDbType = type;
            prm.Size = size;
            _parameters.Add(prm);
            return prm;
        }

        public SqlParameter AddReturnValueParameter()
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = ParameterDirection.ReturnValue;
            prm.ParameterName = "@ReturnValue";
            prm.SqlDbType = SqlDbType.Int;
            _parameters.Add(prm);
            return prm;
        }

        public SqlParameter AddStreamParameter(string name, Stream value)
        {
            return AddStreamParameter(name, value, SqlDbType.Image);
        }

        public SqlParameter AddStreamParameter(string name, Stream value, SqlDbType type)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = ParameterDirection.Input;
            prm.ParameterName = name;
            prm.SqlDbType = type;

            value.Position = 0;
            byte[] data = new byte[value.Length];
            value.Read(data, 0, (int)value.Length);
            prm.Value = data;

            _parameters.Add(prm);

            return prm;
        }

        public SqlParameter AddTextParameter(string name, string value)
        {
            SqlParameter prm = new SqlParameter();
            prm.Direction = ParameterDirection.Input;
            prm.ParameterName = name;
            prm.SqlDbType = SqlDbType.Text;
            prm.Value = PrepareSqlValue(value);

            _parameters.Add(prm);

            return prm;
        }
        #endregion Specialized AddParameter Methods

        #region Private Methods
        private void CopyParameters()
        {
            for (int i = 0; i < _parameters.Count; i++)
            {
                _cmd.Parameters.Add(_parameters[i]);
            }
            _parameterCollection = _cmd.Parameters;
        }

        private object PrepareSqlValue(object value)
        {
            return PrepareSqlValue(value, false);
        }

        private object PrepareSqlValue(object value, bool convertZeroToDBNull)
        {
            if (value == null)
                return DBNull.Value;
            if (value is String)
            {
                if (ConvertEmptyValuesToDbNull && (string)value == String.Empty)
                {
                    return DBNull.Value;
                }
                else
                {
                    return value;
                }
            }
            else if (value is Guid)
            {
                if (ConvertEmptyValuesToDbNull && (Guid)value == Guid.Empty)
                {
                    return DBNull.Value;
                }
                else
                {
                    return value;
                }
            }
            else if (value is DateTime)
            {
                if ((ConvertMinValuesToDbNull && (DateTime)value == DateTime.MinValue)
                    || (ConvertMaxValuesToDbNull && (DateTime)value == DateTime.MaxValue))
                {
                    return DBNull.Value;
                }
                else
                {
                    return value;
                }
            }
            else if (value is Int16)
            {
                if ((ConvertMinValuesToDbNull && (Int16)value == Int16.MinValue)
                    || (ConvertMaxValuesToDbNull && (Int16)value == Int16.MaxValue)
                    || (convertZeroToDBNull && (Int16)value == 0))
                {
                    return DBNull.Value;
                }
                else
                {
                    return value;
                }
            }
            else if (value is Int32)
            {
                if ((ConvertMinValuesToDbNull && (Int32)value == Int32.MinValue)
                    || (ConvertMaxValuesToDbNull && (Int32)value == Int32.MaxValue)
                    || (convertZeroToDBNull && (Int32)value == 0))
                {
                    return DBNull.Value;
                }
                else
                {
                    return value;
                }
            }
            else if (value is Int64)
            {
                if ((ConvertMinValuesToDbNull && (Int64)value == Int64.MinValue)
                    || (ConvertMaxValuesToDbNull && (Int64)value == Int64.MaxValue)
                    || (convertZeroToDBNull && (Int64)value == 0))
                {
                    return DBNull.Value;
                }
                else
                {
                    return value;
                }
            }
            else if (value is Single)
            {
                if ((ConvertMinValuesToDbNull && (Single)value == Single.MinValue)
                    || (ConvertMaxValuesToDbNull && (Single)value == Single.MaxValue)
                    || (convertZeroToDBNull && (Single)value == 0))
                {
                    return DBNull.Value;
                }
                else
                {
                    return value;
                }
            }
            else if (value is Double)
            {
                if ((ConvertMinValuesToDbNull && (Double)value == Double.MinValue)
                    || (ConvertMaxValuesToDbNull && (Double)value == Double.MaxValue)
                    || (convertZeroToDBNull && (Double)value == 0))
                {
                    return DBNull.Value;
                }
                else
                {
                    return value;
                }
            }
            else if (value is Decimal)
            {
                if ((ConvertMinValuesToDbNull && (Decimal)value == Decimal.MinValue)
                    || (ConvertMaxValuesToDbNull && (Decimal)value == Decimal.MaxValue)
                    || (convertZeroToDBNull && (Decimal)value == 0))
                {
                    return DBNull.Value;
                }
                else
                {
                    return value;
                }
            }
            else
            {
                return value;
            }
        }

        private string Decrypt3DES(string cipherText, string key)
        {
            byte[] input = Convert.FromBase64String(cipherText);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            return Encoding.UTF8.GetString(tripleDES.CreateDecryptor().TransformFinalBlock(input, 0, input.Length));
        }
        #endregion Private Methods

        #region Public Methods
        public void Connect()
        {
            if (_connection != null)
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
            }
            else
            {
                if (_connectionString != null && _connectionString != String.Empty)
                {
                    _connection = new SqlConnection(_connectionString);
                    _connection.Open();
                }
                else
                {
                    throw new InvalidOperationException("You must set a connection object or specify a connection string before calling Connect.");
                }
            }
        }

        public void Disconnect()
        {
            if ((_connection != null) && (_connection.State != ConnectionState.Closed))
            {
                _connection.Close();
            }
            if (_connection != null) _connection.Dispose();
            _cmd.Dispose();
            _connection = null;
            _cmd.Dispose();
            _cmd = null;
            if (_parameters != null)
            {
                _parameters.Clear();
                _parameters = null;
            }
            if (_parameterCollection != null)
            {
                _parameterCollection.Clear();
                _parameterCollection = null;
            }
        }

        public void Reset()
        {
            _cmd.Parameters.Clear();
            if (_parameters != null)
            {
                _parameters.Clear();
            }
            if (_parameterCollection != null)
            {
                _parameterCollection.Clear();
            }
        }
        #endregion
    }
}

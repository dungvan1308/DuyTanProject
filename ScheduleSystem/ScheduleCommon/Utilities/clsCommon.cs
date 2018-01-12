using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleCommon.Utilities
{
    public class clsCommon
    {
        public const string SQL_SET_DATE_FORMAT = " SET DATEFORMAT DMY ";

        public const string SYSTEM_DATE_FORMAT = "dd/MM/yyyy";

        //public const string DATE_FORMAT_DD_MM_YYYY_HH_MM_SS = "dd/MM/yyyy hh:mm:ss tt";
        public const string DATE_FORMAT_DD_MM_YYYY_HH_MM_SS = "dd/MM/yyyy hh:mm tt";
        public const string LOGIN_STATUS = "1";
        public const string LOGOUT_STATUS = "0";
        public const string MODULE_CONTRACT = "CONTRACT";
        public const int iMaxGroupField = 2;
        public const string FIELD_NOTE = "NOTE";
        public const string MAIN_KEY = "1";
        public const string JOURNEY_STATUS_OPEN = "O"; //Chua xuat phat 
        public const string JOURNEY_STATUS_RUN = "R"; //Da xuat phat 
        public const string JOURNEY_TRANSACTIONSTATUS_IMPORT = "I"; // Đang chờ nhập hàng
        public const string JOURNEY_TRANSACTIONSTATUS_EXPORT = "E"; //Đang giao hàng
        public const string JOURNEY_TRANSACTIONSTATUS_M = "M"; //Đang giao hàng trễ
        public const string JOURNEY_TRANSACTIONSTATUS_LATE = "L"; //Xe đi trễ
    }
}

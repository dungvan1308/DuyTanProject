using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using System.Globalization;

namespace WebServiceDuyTan.DbObjects
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


        public static string convertDateTimeToString(DateTime dateTime)
        {
            return dateTime.ToString(SYSTEM_DATE_FORMAT);
        }

        public static string convertDateTimeToString(DateTime dateTime, string dateFormat)
        {
            return dateTime.ToString(dateFormat);
        }

        public static DateTime convertStringToDate(string strDate, string FormatDate)
        {
            //CultureInfo provider = CultureInfo.InvariantCulture;
            //CultureInfo provider = CultureInfo.CurrentCulture;
            IFormatProvider provider = new CultureInfo("en-US", true); 
            

            try
            {
                return DateTime.ParseExact(strDate, FormatDate, provider);
            }
            catch(Exception ex)
            {
                return DateTime.ParseExact("01/01/1970", FormatDate, provider);
                
            }
        }


    }
}
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
        public const string JOURNEY_STATUS_OPEN = "O"; //Chua xuat phat 
        public const string JOURNEY_STATUS_RUN = "R"; //Da xuat phat 
        public const string JOURNEY_TRANSACTIONSTATUS_IMPORT = "I"; // Đang chờ nhập hàng
        public const string JOURNEY_TRANSACTIONSTATUS_EXPORT = "E"; //Đang giao hàng
        public const string JOURNEY_TRANSACTIONSTATUS_M="M"; //Đang giao hàng trễ
        public const string JOURNEY_TRANSACTIONSTATUS_LATE = "L"; //Xe đi trễ


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

    public class Coordinates
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }

    public static class CoordinatesDistanceExtensions
    {
        public static double DistanceTo(this Coordinates baseCoordinates, Coordinates targetCoordinates)
        {
            return DistanceTo(baseCoordinates, targetCoordinates, UnitOfLength.Kilometers);
        }

        public static double DistanceTo(this Coordinates baseCoordinates, Coordinates targetCoordinates, UnitOfLength unitOfLength)
        {
            var baseRad = Math.PI * baseCoordinates.Latitude / 180;
            var targetRad = Math.PI * targetCoordinates.Latitude / 180;
            var theta = baseCoordinates.Longitude - targetCoordinates.Longitude;
            var thetaRad = Math.PI * theta / 180;

            double dist =
                Math.Sin(baseRad) * Math.Sin(targetRad) + Math.Cos(baseRad) *
                Math.Cos(targetRad) * Math.Cos(thetaRad);
            dist = Math.Acos(dist);

            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return unitOfLength.ConvertFromMiles(dist);
        }
    }

    public class UnitOfLength
    {
        public static UnitOfLength Kilometers = new UnitOfLength(1.609344);
        public static UnitOfLength NauticalMiles = new UnitOfLength(0.8684);
        public static UnitOfLength Miles = new UnitOfLength(1);

        private readonly double _fromMilesFactor;

        private UnitOfLength(double fromMilesFactor)
        {
            _fromMilesFactor = fromMilesFactor;
        }

        public double ConvertFromMiles(double input)
        {
            return input * _fromMilesFactor;
        }
    }
}
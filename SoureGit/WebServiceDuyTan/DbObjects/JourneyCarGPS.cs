using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibraryObjects;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.IO;


namespace WebServiceDuyTan.DbObjects
{
    public class JourneyCarGPSDB
    {
        protected string strConection = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
        private string _UserName = "ndt_service02_V3.1";//"ndt_serviceV3.1";//string.Empty;
        private string _Password = "ndthcm062017";//string.Empty;
        private string _Serial = "NDTVHDD2678686";//string.Empty;
        private string _Version = "V3.1";// string.Empty;

        private void getJourneyCarGPS()
        {
            /*
             * Dungnv   : 07/01/2018
             * Purpose  : Lay du lieu tu Vinh Hien
             */

            //Check Login 

            //string kq = _Service.CheckLogin(_UserName, _Password, _Serial, _Version);
            /*
            string msg = GetLoginMessage(kq);
            if (!string.IsNullOrEmpty(msg))
            {
                return;
            }
            */

            //Lay du lieu GPS
            //DataSet ds = _Service.GetVehicleStatusListV3(_UserName, _Password, _Serial, _Version);



        }

        public bool insertJourneyCarGPS(JourneyCarGPSObj obj)
        {
            /*
           * Dungnv    :   18/10/2014
           * Purpose   :   Insert
           * Output    :   Ma outUserId
           */
            Double dec = 0;
            SqlParameter[] aParams = new SqlParameter[32];
            string importDatetime = DateTime.Now.ToString("yyyyMMddHHmmss");

            aParams[0] = new SqlParameter("@Activity", System.Data.SqlDbType.VarChar);
            aParams[0].Value = "ImportData";

            aParams[1] = new SqlParameter("@LicenseCard", System.Data.SqlDbType.VarChar);
            aParams[1].Value = obj.LicenseCard;

            aParams[2] = new SqlParameter("@Lat", System.Data.SqlDbType.Decimal);
            aParams[2].Value = obj.Lat;

            aParams[3] = new SqlParameter("@Lon", System.Data.SqlDbType.Decimal);
            aParams[3].Value = obj.Lon;

            aParams[4] = new SqlParameter("@Heading", System.Data.SqlDbType.Decimal);
            aParams[4].Value = obj.Heading;

            aParams[5] = new SqlParameter("@Speed", System.Data.SqlDbType.Decimal);
            aParams[5].Value = obj.Speed;

            aParams[6] = new SqlParameter("@MaxSpeed", System.Data.SqlDbType.Decimal);
            aParams[6].Value = obj.MaxSpeed;

            aParams[7] = new SqlParameter("@sDateTime", System.Data.SqlDbType.DateTime);
            aParams[7].Value = obj.sDateTime;

            aParams[8] = new SqlParameter("@TotalMil", System.Data.SqlDbType.Decimal);
            aParams[8].Value = obj.TotalMil;

            aParams[9] = new SqlParameter("@CurrentMil", System.Data.SqlDbType.Decimal);
            aParams[9].Value = obj.CurrentMil;

            aParams[10] = new SqlParameter("@TotalTripTime", System.Data.SqlDbType.VarChar);
            aParams[10].Value = obj.TotalTripTime;

            aParams[11] = new SqlParameter("@NDT", System.Data.SqlDbType.VarChar);
            aParams[11].Value = obj.NDT;

            aParams[12] = new SqlParameter("@EquipmentID", System.Data.SqlDbType.VarChar);
            aParams[12].Value = obj.EquipmentID;

            aParams[13] = new SqlParameter("@CompanyName", System.Data.SqlDbType.VarChar);
            aParams[13].Value = obj.CompanyName;

            aParams[14] = new SqlParameter("@ConnectedFrom", System.Data.SqlDbType.VarChar);
            aParams[14].Value = obj.ConnectedFrom;

            aParams[15] = new SqlParameter("@Duration", System.Data.SqlDbType.VarChar);
            aParams[15].Value = obj.Duration;

            aParams[16] = new SqlParameter("@LiveStatus", System.Data.SqlDbType.VarChar);
            aParams[16].Value = obj.LiveStatus;

            aParams[17] = new SqlParameter("@sColor", System.Data.SqlDbType.VarChar);
            aParams[17].Value = obj.sColor;

            aParams[18] = new SqlParameter("@IDLE", System.Data.SqlDbType.VarChar);
            aParams[18].Value = obj.IDLE;

            aParams[19] = new SqlParameter("@Engine", System.Data.SqlDbType.VarChar);
            aParams[19].Value = obj.Engine;

            aParams[20] = new SqlParameter("@Door", System.Data.SqlDbType.VarChar);
            aParams[20].Value = obj.Door;

            aParams[21] = new SqlParameter("@AreaName", System.Data.SqlDbType.VarChar);
            aParams[21].Value = obj.AreaName;

            aParams[22] = new SqlParameter("@Fuel", System.Data.SqlDbType.VarChar);
            aParams[22].Value = obj.Fuel;

            aParams[23] = new SqlParameter("@MayLanh", System.Data.SqlDbType.VarChar);
            aParams[23].Value = obj.MayLanh;

            aParams[24] = new SqlParameter("@MMC_ID", System.Data.SqlDbType.VarChar);
            aParams[24].Value = obj.MMC_ID;

            aParams[25] = new SqlParameter("@CarGroupName", System.Data.SqlDbType.VarChar);
            aParams[25].Value = obj.CarGroupName;

            aParams[26] = new SqlParameter("@MaTaiXe", System.Data.SqlDbType.VarChar);
            aParams[26].Value = obj.MaTaiXe;

            aParams[27] = new SqlParameter("@FullName", System.Data.SqlDbType.NVarChar);
            aParams[27].Value = obj.FullName;

            aParams[28] = new SqlParameter("@Phone", System.Data.SqlDbType.VarChar);
            aParams[28].Value = obj.Phone;

            aParams[29] = new SqlParameter("@LoaiXe", System.Data.SqlDbType.NVarChar);
            aParams[29].Value = obj.LoaiXe;

            aParams[30] = new SqlParameter("@HanKiemDinh", System.Data.SqlDbType.VarChar);
            aParams[30].Value = obj.HanKiemDinh;

            aParams[31] = new SqlParameter("@ImportDatetime", System.Data.SqlDbType.VarChar);
            aParams[31].Value = importDatetime;

            try
            {
                dec = SqlHelper.ExecuteNonQuery(strConection, CommandType.StoredProcedure, "usp_JourneyCarGPS", aParams);

                return true;

            }
            catch (Exception ex)
            {
                dec = -1000;

                return false;
            }
        }

        private string GetLoginMessage(string msgId)
        {
            string msg = string.Empty;
            switch (msgId)
            {
                case "-1":
                    msg = "HDD serial is invalid";
                    break;
                case "0":
                    msg = "UserName/Password is invalid";
                    break;
                case "-2":
                    msg = "Version is invalid";
                    break;
                default:
                    break;
            }

            return msg;
        }

    }
    
}
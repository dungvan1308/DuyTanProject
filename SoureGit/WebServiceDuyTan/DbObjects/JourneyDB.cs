using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Configuration;
using ClassLibraryObjects;
using ClassLibraryCommon;


namespace WebServiceDuyTan.DbObjects
{
 
    
    public class JourneyDB
    {
        protected string strConection = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
        protected double para_IntervalPlace	=10; 	//  Khoản cách so với điểm giao hàng gần nhất (km)
        protected double para_IntervalTime	=10;	//  Số giờ đứng yên không di chuyển
        protected double para_IntervalPlace_DuyTan=10;   //	Khoản cách đứng yên so với Duy Tân
        protected double para_IntervalTime_DuyTan=	10;	 // Thời gian đứng yên xác định xe về Duy Tân
        protected double para_TimeOut=	10; 	    //  Thời gian trễ
        protected double para_AvgSpeed=40; //	Vận tốc trung bình (km/h)
        protected double para_Distance=500;  //	Khoản cách khi xe rời khỏi địa điểm của Duy Tân
        protected double para_DistanceTime=	5;  //	Thời gian khi xe rời khỏi địa điểm Duy Tân ( Để update trạng thái đã xuất phát)



        public bool insertUpdateJourney(JourneyObject obj)
        {
            /*
           * Dungnv    :   18/10/2014
           * Purpose   :   Insert
           * Output    :   Ma outUserId
           */
            Double dec = 0;


            SqlParameter[] aParams = new SqlParameter[21];


            aParams[0] = new SqlParameter("@JourneyID", System.Data.SqlDbType.Int);
            aParams[0].Value = obj.JourneyID;

            aParams[1] = new SqlParameter("@JourneyDate", System.Data.SqlDbType.Date);
            aParams[1].Value = obj.JourneyDate;

            aParams[2] = new SqlParameter("@VehicleNumber", System.Data.SqlDbType.NVarChar);
            aParams[2].Value = obj.VehicleNumber;

            aParams[3] = new SqlParameter("@Driver", System.Data.SqlDbType.NVarChar);
            aParams[3].Value = obj.Driver;

            aParams[4] = new SqlParameter("@Employee1", System.Data.SqlDbType.Int);
            aParams[4].Value = obj.Employee1;

            aParams[5] = new SqlParameter("@Employee2", System.Data.SqlDbType.Int);
            aParams[5].Value = obj.Employee2;

            aParams[6] = new SqlParameter("@StartPlace", System.Data.SqlDbType.Int);
            aParams[6].Value = obj.StartPlace;

            aParams[7] = new SqlParameter("@StartTimePlan1", System.Data.SqlDbType.DateTime);
            aParams[7].Value = obj.StartTimePlan1;



            aParams[8] = new SqlParameter("@DeliveryPlace1", System.Data.SqlDbType.Int);
            aParams[8].Value = obj.DeliveryPlace1;

            aParams[9] = new SqlParameter("@ArrivalTimePlan1", System.Data.SqlDbType.DateTime);
            aParams[9].Value = obj.ArrivalTimePlan1;


            aParams[10] = new SqlParameter("@StartTimePlan2", System.Data.SqlDbType.DateTime);
            aParams[10].Value = obj.StartTimePlan2;


            aParams[11] = new SqlParameter("@DeliveryPlace2", System.Data.SqlDbType.Int);
            aParams[11].Value = obj.DeliveryPlace2;

            aParams[12] = new SqlParameter("@ArrivalTimePlan2", System.Data.SqlDbType.DateTime);
            aParams[12].Value = obj.ArrivalTimePlan2;

            aParams[13] = new SqlParameter("@StartTimePlan3", System.Data.SqlDbType.DateTime);
            aParams[13].Value = obj.StartTimePlan3;


            aParams[14] = new SqlParameter("@DeliveryPlace3", System.Data.SqlDbType.Int);
            aParams[14].Value = obj.DeliveryPlace3;

            aParams[15] = new SqlParameter("@ArrivalTimePlan3", System.Data.SqlDbType.DateTime);
            aParams[15].Value = obj.ArrivalTimePlan3;


            aParams[16] = new SqlParameter("@Status", System.Data.SqlDbType.Char);
            aParams[16].Value = obj.Status;

            aParams[17] = new SqlParameter("@Gate", System.Data.SqlDbType.Char);
            aParams[17].Value = obj.Gate;

            aParams[18] = new SqlParameter("@Note", System.Data.SqlDbType.NVarChar);
            aParams[18].Value = obj.Note;


            aParams[19] = new SqlParameter("@CreateBy", System.Data.SqlDbType.VarChar);
            aParams[19].Value = obj.CreateBy;

            aParams[20] = new SqlParameter("@ModifyBy", System.Data.SqlDbType.VarChar);
            aParams[20].Value = obj.ModifyBy;

            //aParams[20] = new SqlParameter("@TimesUpdate", System.Data.SqlDbType.Int);
            //aParams[20].Value = obj.TimesUpdate;
           
            try
            {
                dec = SqlHelper.ExecuteNonQuery(strConection,CommandType.StoredProcedure, "usp_InsertUpdateJourney", aParams);

                return true;

            }
            catch (Exception ex)
            {
                dec = -1000;

                return false;
            }
        }

        public JourneyObject selectJourney(int iJourneyID)
        {
            /*
             * Dungnv : 21/10/2014
             * Purpose: Tim kiem thong tin 
             */


            SqlParameter[] aParams = new SqlParameter[1];
            aParams[0] = new SqlParameter("@JourneyID ", System.Data.SqlDbType.Int);
            aParams[0].Value = iJourneyID;

            JourneyObject obj = new JourneyObject();

            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "usp_SelectJourney", aParams);
                if (ds != null)
                {
                    if (ds.Tables[0] != null)
                    {
                        obj.JourneyID = Int32.Parse(ds.Tables[0].Rows[0]["JourneyID"].ToString());
                        obj.DeliveryPlace1 = Int32.Parse(ds.Tables[0].Rows[0]["DeliveryPlace1"].ToString(), 0);

                        obj.DeliveryPlace2 = Int32.Parse(ds.Tables[0].Rows[0]["DeliveryPlace2"].ToString(), 0);
                        obj.DeliveryPlace3 = Int32.Parse(ds.Tables[0].Rows[0]["DeliveryPlace3"].ToString(), 0);
                        obj.Driver = Int32.Parse( ds.Tables[0].Rows[0]["Driver"].ToString(),0);
                        obj.StartPlace = Int32.Parse(ds.Tables[0].Rows[0]["StartPlace"].ToString(), 0);

                        obj.Employee1 = Int32.Parse(ds.Tables[0].Rows[0]["Employee1"].ToString(), 0);
                        obj.Employee2 = Int32.Parse(ds.Tables[0].Rows[0]["Employee2"].ToString(), 0);
                        obj.Gate = ds.Tables[0].Rows[0]["Gate"].ToString();
                        obj.JourneyDate = DateTime.Parse(ds.Tables[0].Rows[0]["JourneyDate"].ToString());

                        obj.Note = ds.Tables[0].Rows[0]["Note"].ToString();

                        obj.Status = ds.Tables[0].Rows[0]["Status"].ToString();
                        //obj.ArrivalTime1 = clsCommon.convertStringToDate(ds.Tables[0].Rows[0]["ArrivalTime1"].ToString(), clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS);
                        obj.ArrivalTime1 = DateTime.Parse(ds.Tables[0].Rows[0]["ArrivalTime1"].ToString());
                        obj.ArrivalTime2 = DateTime.Parse(ds.Tables[0].Rows[0]["ArrivalTime2"].ToString());
                        obj.ArrivalTime3 = DateTime.Parse(ds.Tables[0].Rows[0]["ArrivalTime3"].ToString());
                        obj.TimeGoHome = DateTime.Parse(ds.Tables[0].Rows[0]["ArrivalTime3"].ToString());
                        obj.ArrivalTimePlan1 = DateTime.Parse(ds.Tables[0].Rows[0]["ArrivalTimePlan1"].ToString());
                        obj.ArrivalTimePlan2 = DateTime.Parse(ds.Tables[0].Rows[0]["ArrivalTimePlan2"].ToString());
                        obj.ArrivalTimePlan3 = DateTime.Parse(ds.Tables[0].Rows[0]["ArrivalTimePlan3"].ToString());
                        
                        obj.TimesUpdate = Int32.Parse(ds.Tables[0].Rows[0]["TimesUpdate"].ToString(), 0);
                        obj.VehicleNumber = ds.Tables[0].Rows[0]["VehicleNumber"].ToString();
                        obj.StartTime1 = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime1"].ToString());

                        obj.StartTime2 = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime2"].ToString());
                        obj.StartTime3 = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime3"].ToString());
                        obj.StartTimePlan1 = DateTime.Parse(ds.Tables[0].Rows[0]["StartTimePlan1"].ToString());
                        obj.StartTimePlan2 = DateTime.Parse(ds.Tables[0].Rows[0]["StartTimePlan2"].ToString());
                        obj.StartTimePlan3 = DateTime.Parse(ds.Tables[0].Rows[0]["StartTimePlan3"].ToString());
                        obj.Status = ds.Tables[0].Rows[0]["Status"].ToString();
                        
                        

                        obj.CreateBy = ds.Tables[0].Rows[0]["CreateBy"].ToString();
                        obj.ModifyBy = ds.Tables[0].Rows[0]["ModifyBy"].ToString();


                        try
                        {
                            obj.ModifyDate = DateTime.Parse(ds.Tables[0].Rows[0]["ModifyDate"].ToString());
                        }
                        catch (Exception ex)
                        {

                            obj.ModifyDate = DateTime.Parse("01/01/1970");
                        }

                        try
                        {
                            obj.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                        }
                        catch (Exception ex)
                        {

                            obj.CreateDate = DateTime.Parse("01/01/1970");
                        }

                       

                    }
                }
            }
            catch (Exception ex)
            {
                obj = null;
            }

            return obj;
        }

        public DataSet selectJourneyDynamic(string strCondition, string strOrderBy)
        {
            /*
             * Dungnv : 21/10/2014
             * Purpose: Tim kiem thong tin 
             */

            SqlParameter[] aParams = new SqlParameter[2];
            aParams[0] = new SqlParameter("@WhereCondition", System.Data.SqlDbType.NVarChar);
            aParams[0].Value = strCondition;

            aParams[1] = new SqlParameter("@OrderByExpression", System.Data.SqlDbType.NVarChar);
            aParams[1].Value = strOrderBy;

            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "usp_SelectJourneysDynamic", aParams);
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;

        }

        public DataSet selectAllCurrentJourney()
        {
            /*
             * Dungnv : 25/12/2017 
             */
 
           

            DataSet ds = new DataSet();
            try
            {
                //Test Job 
                processJobUpdateJourney();
                //End Test Job

                ds = SqlHelper.ExecuteDataset(strConection, "usp_selectAllCurrentJourney");
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;
        }

        public bool deleteJourney(int iPlaceId, out string strResult)
        {
            /*
             * Dungnv   : 09.11.2017
             * Purpose  : Xoa Trust
             */

            Double dec = 0;
            SqlParameter[] aParams = new SqlParameter[2];

            aParams[0] = new SqlParameter("@JourneyID", System.Data.SqlDbType.Int);
            aParams[0].Value = iPlaceId;

            aParams[1] = new SqlParameter("@RESULT", System.Data.SqlDbType.VarChar, 5);
            aParams[1].Direction = ParameterDirection.Output;

            try
            {
                dec = SqlHelper.ExecuteNonQuery(strConection, CommandType.StoredProcedure, "usp_DeleteJourney", aParams);
                strResult = aParams[1].Value.ToString();
                return true;
            }
            catch (Exception ex)
            {
                dec = -1000;
                strResult = "99999";
                return false;
            }

        }

        public DataSet selectInformationAtTrustStore()
        {
            /*
             * Dungnv   :   25/12/2017 
             * Purpose  :   Thông tin tại kho
             */

            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "usp_informationAtTrustStore");
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;
        }

        public DataSet selectInformationAtTrustGroup()
        {
            /*
             * Dungnv   :   25/12/2017 
             * Purpose  :   Thông tin đội xe 
             */

            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "usp_informationAtTrustGroup");
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;
        }

        public void processJourney(JourneyObject obj,Coordinates locationStartPlace,Coordinates locationGPS,Coordinates location1,Coordinates location2,Coordinates location3)
        {
            /*
             * Dungnv   : 09/01/2018
             * Purpose  : Xu ly tinh toan, update trang thai, thoi gian cua hanh trinh
             */
 
             /*
                “Đã Xuất Phát”: tự động update khi xe cách khỏi Địa Điểm Duy Tân Group 500m trong thời gian B phút 
               (khoảng cách ra khỏi Duy Tân Group khác khoảng cách đã đến).
                Xe chưa xuất phát ghi “Chưa Xuất Phát”
              */

            double db_distince = 0;
          
            DateTime dt_currentTime = new DateTime();
            DateTime dt_timePlan = new DateTime();


            db_distince = CoordinatesDistanceExtensions.DistanceTo(locationStartPlace, locationGPS, UnitOfLength.Kilometers);
            dt_currentTime = DateTime.Now;
            dt_timePlan = obj.StartTimePlan1;
            dt_timePlan.AddMinutes(para_DistanceTime);

          
            #region Xử lý xe xuất phát 
            string strsql = "";
            string strSqlTest = "";

            if (dt_currentTime > dt_timePlan)
            {
                //Xe da chay duoc 5 phut 
                if (db_distince > para_Distance)
                {
                    if (obj.Status == clsCommon.JOURNEY_STATUS_OPEN)
                    {
                        //Tien hanh update lai trang thai va thoi gian hanh xuat phat 

                        strsql = "set dateformat dmy   update Journey set Status='R', StartTime1='" + clsCommon.convertDateTimeToString( dt_currentTime,clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS)+ "'  where JourneyID='" + obj.JourneyID + "'";
                        
                    }
                }


            }

            strSqlTest = strSqlTest + "set dateformat dmy   update Journey set Status='R', StartTime1='" + clsCommon.convertDateTimeToString(dt_currentTime, clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS) + "'  where JourneyID='" + obj.JourneyID + "'";

            #endregion 

            #region Xử lý thời gian, trạng thái hành trình tại điểm đến 1
            /*
               * cập nhập thời gian đến điểm 1
               * nếu như tọa độ gps cách điểm 1 trong khoản 500m và thời gian đến = null => sẽ cập nhập thời gian đến
               */

            db_distince = CoordinatesDistanceExtensions.DistanceTo(location1, locationGPS, UnitOfLength.Kilometers);

            //Nếu như khoản cách < 500 và thời gian đến điểm 1 là null  => xe đang ở gần điểm Location 1
            if(db_distince < para_Distance & obj.ArrivalTime1==null)
            {
                
                strsql = "set dateformat dmy   update Journey set  ArrivalTime1='" + clsCommon.convertDateTimeToString(dt_currentTime, clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS) + "' where JourneyID='" + obj.JourneyID + "'";
                
            }

            strSqlTest = strSqlTest + " set dateformat dmy   update Journey set  ArrivalTime1='" + clsCommon.convertDateTimeToString(dt_currentTime, clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS) + "'  where JourneyID='" + obj.JourneyID + "'";
           
            //Nếu như khoản cách > 500 và thời gian hiện tại lớn hơn thời gian kế hoạch 1, và thời gian đến điểm 1 là null => Xe bị trễ
            if(db_distince > para_Distance & obj.ArrivalTime1 ==null)
            {
                //Tre
                if(dt_currentTime > obj.ArrivalTimePlan1)
                {
                    strsql = "set dateformat dmy   update Journey set  TransactionStatus='" + clsCommon.JOURNEY_TRANSACTIONSTATUS_LATE
                    + "',DescHistoryJourney='Cách điểm 1 " + db_distince.ToString() + " km '  where JourneyID='" + obj.JourneyID + "'";
                }
                else //Khong tre
                {
                    strsql = " update Journey set  DescHistoryJourney='Cách điểm 1 " + db_distince.ToString() + " km '  where JourneyID='" + obj.JourneyID + "'";
                }
                
            }

            strSqlTest = strSqlTest + "set dateformat dmy   update Journey set  TransactionStatus='" + clsCommon.JOURNEY_TRANSACTIONSTATUS_LATE
                        + "',DescHistoryJourney='Cách điểm 1 " + db_distince.ToString() + " km '  where JourneyID='" + obj.JourneyID + "'";

            strSqlTest = strSqlTest + " update Journey set  DescHistoryJourney='Cách điểm 1 " + db_distince.ToString() + " km '  where JourneyID='" + obj.JourneyID + "'";


            #endregion 

            #region Xử lý thời gian, trạng thái hành trình tại điểm đến 2
            /*
               * cập nhập thời gian đến điểm 2
               * nếu như tọa độ gps cách điểm 2 trong khoản 500m và thời gian đến  = null => sẽ cập nhập thời gian đến
               */
            db_distince = CoordinatesDistanceExtensions.DistanceTo(location2, locationGPS, UnitOfLength.Kilometers);
            //Nếu như khoản cách < 500 và thời gian đến điểm 2 là null  => xe đang ở gần điểm Location 2
            if (db_distince <= para_Distance & obj.ArrivalTime2 == null)
            {

                strsql = "set dateformat dmy   update Journey set  ArrivalTime2='" + clsCommon.convertDateTimeToString(dt_currentTime, clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS) + "'  where JourneyID='" + obj.JourneyID + "'";

            }

            strSqlTest = strSqlTest + " set dateformat dmy   update Journey set  ArrivalTime2='" + clsCommon.convertDateTimeToString(dt_currentTime, clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS) + "'   where JourneyID='" + obj.JourneyID + "'";

            //Nếu như khoản cách > 500 và thời gian hiện tại lớn hơn thời gian kế hoạch 2, và thời gian đến điểm 2 là null => Xe bị trễ
            if (db_distince > para_Distance & obj.ArrivalTime2 == null)
            {
                //Tre
                if (dt_currentTime > obj.ArrivalTimePlan2)
                {
                    strsql = " set dateformat dmy   update Journey set  TransactionStatus='" + clsCommon.JOURNEY_TRANSACTIONSTATUS_LATE + "'  where JourneyID='" + obj.JourneyID + "'"
                     + "update Journey set  DescHistoryJourney='Cách điểm 2 " + db_distince.ToString() + " km '  where JourneyID='" + obj.JourneyID + "'";
                    
                }
                else
                {
                    strsql = " update Journey set  DescHistoryJourney='Cách điểm 2 " + db_distince.ToString() + " km '  where JourneyID='" + obj.JourneyID + "'";
                }
                
            }


            strSqlTest = strSqlTest + "set dateformat dmy   update Journey set  TransactionStatus='" + clsCommon.JOURNEY_TRANSACTIONSTATUS_LATE + "'  where JourneyID='" + obj.JourneyID + "'"
                     + "update Journey set  DescHistoryJourney='Cách điểm 2 " + db_distince.ToString() + " km '  where JourneyID='" + obj.JourneyID + "'";

            strSqlTest = strSqlTest + " update Journey set  DescHistoryJourney='Cách điểm 2 " + db_distince.ToString() + " km '  where JourneyID='" + obj.JourneyID + "'";


            #endregion 

            #region Xử lý thời gian, trạng thái hành trình tại điểm đến 3
            /*
              * cập nhập thời gian đến điểm 3
              * nếu như tọa độ gps cách điểm 3 trong khoản 500m và thời gian đến  = null => sẽ cập nhập thời gian đến
              */
            db_distince = CoordinatesDistanceExtensions.DistanceTo(location3, locationGPS, UnitOfLength.Kilometers);
            //Nếu như khoản cách < 500 và thời gian đến điểm 3 là null  => xe đang ở gần điểm Location 3
            if (db_distince <= para_Distance & obj.ArrivalTime3 == null)
            {

                strsql = " set dateformat dmy   update Journey set  ArrivalTime3='" + clsCommon.convertDateTimeToString(dt_currentTime, clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS) 
                    + "' where JourneyID='" + obj.JourneyID + "'";
                
                //Cap nhap cho dau xe khi xe quay ve 
                strsql = strsql + " update Trust set PackingPlace ='" + obj.DeliveryPlace3 + "' where VehicleNumber='" + obj.VehicleNumber + "'";


            }

            strSqlTest = strSqlTest + " set dateformat dmy   update Journey set  ArrivalTime3='" + clsCommon.convertDateTimeToString(dt_currentTime, clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS)
                    + "' where JourneyID='" + obj.JourneyID + "'";
            strSqlTest = strSqlTest + " update Trust set PackingPlace ='" + obj.DeliveryPlace3 + "' where VehicleNumber='" + obj.VehicleNumber + "'";



            //Nếu như khoản cách > 500 và thời gian hiện tại lớn hơn thời gian kế hoạch 2, và thời gian đến điểm 2 là null => Xe bị trễ
            if (db_distince > para_Distance & obj.ArrivalTime3 == null)
            {
                if(dt_currentTime > obj.ArrivalTimePlan3)
                {
                    strsql = " set dateformat dmy   update Journey set  TransactionStatus='" + clsCommon.JOURNEY_TRANSACTIONSTATUS_LATE + "'  where JourneyID='" + obj.JourneyID + "'"
                     + " update Journey set  DescHistoryJourney='Cách điểm 3 " + db_distince.ToString() + " km '  where JourneyID='" + obj.JourneyID + "'";

                    //Can xu ly them viec add thoi gian ke hoach tiep theo
                }
                else
                {
                    strsql = " update Journey set  DescHistoryJourney='Cách điểm 3 " + db_distince.ToString() + " km '  where JourneyID='" + obj.JourneyID + "'";
                }
                
            }


            strSqlTest = strSqlTest + " set dateformat dmy   update Journey set  TransactionStatus='" + clsCommon.JOURNEY_TRANSACTIONSTATUS_LATE + "'  where JourneyID='" + obj.JourneyID + "'"
                     + " update Journey set  DescHistoryJourney='Cách điểm 3 " + db_distince.ToString() + " km '  where JourneyID='" + obj.JourneyID + "'";

            strSqlTest = strSqlTest + " update Journey set  DescHistoryJourney='Cách điểm 3 " + db_distince.ToString() + " km '  where JourneyID='" + obj.JourneyID + "'";



            #endregion 

            double dec = 0;
            try
            {
                if(strsql!="")
                {
                    dec = SqlHelper.ExecuteNonQuery(strConection, CommandType.Text, strsql);
                }
                
            }
            catch(Exception ex)
            {
                dec = -1;
            }

        }

        public void processJobUpdateJourney()
        {
            /*
             * Dungnv   :   10/01/2018
             * Purpose  :   Xử lý cập nhập trạng thai của hanh trình
             *              Này nên thiết lập 1 Job định kì 
             * 
             */
            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "usp_jobUpdateJourney");
                if (ds != null)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        double db_Lat = 0;
                        double db_Lon = 0;
                        double db_out = 0;

                        //locationStartPlace
                       double.TryParse(row["StartPlace_Lat"].ToString(), out db_out);
                       db_Lat = db_out;
                       double.TryParse(row["StartPlace_Lon"].ToString(), out db_out);
                       db_Lon = db_out;
                       Coordinates locationStartPlace = new Coordinates(db_Lat, db_Lon);


                       //locationGPS
                       double.TryParse(row["Lat"].ToString(), out db_out);
                       db_Lat = db_out;
                       double.TryParse(row["Lon"].ToString(), out db_out);
                       db_Lon = db_out;
                       Coordinates locationGPS = new Coordinates(db_Lat, db_Lon);

                       //location1
                       double.TryParse(row["DeliveryPlace1_Lat"].ToString(), out db_out);
                       db_Lat = db_out;
                       double.TryParse(row["DeliveryPlace1_Lon"].ToString(), out db_out);
                       db_Lon = db_out;
                       Coordinates location1 = new Coordinates(db_Lat, db_Lon);

                       //location2
                       double.TryParse(row["DeliveryPlace2_Lat"].ToString(), out db_out);
                       db_Lat = db_out;
                       double.TryParse(row["DeliveryPlace2_Lon"].ToString(), out db_out);
                       db_Lon = db_out;
                       Coordinates location2 = new Coordinates(db_Lat, db_Lon);

                       //location3
                       double.TryParse(row["DeliveryPlace3_Lat"].ToString(), out db_out);
                       db_Lat = db_out;
                       double.TryParse(row["DeliveryPlace3_Lon"].ToString(), out db_out);
                       db_Lon = db_out;
                       Coordinates location3 = new Coordinates(db_Lat, db_Lon);

                       JourneyObject obj = new JourneyObject();
                       int ID = 0;

                       // Set gia tri cho JourneyObject
                       obj.JourneyID = Int32.Parse(ds.Tables[0].Rows[0]["JourneyID"].ToString());
                       obj.ArrivalTime1 = DateTime.Parse(ds.Tables[0].Rows[0]["ArrivalTime1"].ToString());
                       obj.ArrivalTime2 = DateTime.Parse(ds.Tables[0].Rows[0]["ArrivalTime2"].ToString());
                       obj.ArrivalTime3 = DateTime.Parse(ds.Tables[0].Rows[0]["ArrivalTime3"].ToString());

                       obj.ArrivalTimePlan1 = DateTime.Parse(ds.Tables[0].Rows[0]["ArrivalTimePlan1"].ToString());
                       obj.ArrivalTimePlan2 = DateTime.Parse(ds.Tables[0].Rows[0]["ArrivalTimePlan2"].ToString());
                       obj.ArrivalTimePlan3 = DateTime.Parse(ds.Tables[0].Rows[0]["ArrivalTimePlan3"].ToString());

                       obj.VehicleNumber = ds.Tables[0].Rows[0]["VehicleNumber"].ToString();
                       obj.StartTime1 = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime1"].ToString());
                       obj.StartTime2 = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime2"].ToString());
                       obj.StartTime3 = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime3"].ToString());
                       obj.StartTimePlan1 = DateTime.Parse(ds.Tables[0].Rows[0]["StartTimePlan1"].ToString());
                       obj.StartTimePlan2 = DateTime.Parse(ds.Tables[0].Rows[0]["StartTimePlan2"].ToString());
                       obj.StartTimePlan3 = DateTime.Parse(ds.Tables[0].Rows[0]["StartTimePlan3"].ToString());
                       obj.Status = ds.Tables[0].Rows[0]["Status"].ToString();

                        //Thực hiện update 
                       processJourney(obj, locationStartPlace, locationGPS, location1, location2, location3);

                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }

                
        }

    }
}
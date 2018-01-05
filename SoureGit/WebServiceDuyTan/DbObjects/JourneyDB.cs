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

            aParams[3] = new SqlParameter("@DriverName", System.Data.SqlDbType.NVarChar);
            aParams[3].Value = obj.DriverName;

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
                        obj.DriverName = ds.Tables[0].Rows[0]["DriverName"].ToString();
                        obj.Employee1 = Int32.Parse(ds.Tables[0].Rows[0]["Employee1"].ToString(), 0);
                        obj.Employee2 = Int32.Parse(ds.Tables[0].Rows[0]["Employee2"].ToString(), 0);
                        obj.Gate = ds.Tables[0].Rows[0]["Gate"].ToString();
                        obj.JourneyDate = DateTime.Parse(ds.Tables[0].Rows[0]["JourneyDate"].ToString());

                        obj.Note = ds.Tables[0].Rows[0]["Note"].ToString();

                        obj.Status = ds.Tables[0].Rows[0]["Status"].ToString();
                        obj.ArrivalTime1 = clsCommon.convertStringToDate(ds.Tables[0].Rows[0]["ArrivalTime1"].ToString(), clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS);
                        obj.ArrivalTime2 = clsCommon.convertStringToDate(ds.Tables[0].Rows[0]["ArrivalTime2"].ToString(), clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS);
                        obj.ArrivalTime3 = clsCommon.convertStringToDate(ds.Tables[0].Rows[0]["ArrivalTime3"].ToString(), clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS);
                        obj.TimeGoHome = clsCommon.convertStringToDate(ds.Tables[0].Rows[0]["TimeGoHome"].ToString(), clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS);
                        obj.ArrivalTimePlan1 = clsCommon.convertStringToDate(ds.Tables[0].Rows[0]["ArrivalTimePlan1"].ToString(), clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS);
                        obj.ArrivalTimePlan2 = clsCommon.convertStringToDate(ds.Tables[0].Rows[0]["ArrivalTimePlan2"].ToString(), clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS);
                        obj.ArrivalTimePlan3 = clsCommon.convertStringToDate(ds.Tables[0].Rows[0]["ArrivalTimePlan3"].ToString(), clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS);
                        obj.StartPlace = ds.Tables[0].Rows[0]["StartPlace"].ToString();
                        obj.TimesUpdate = Int32.Parse(ds.Tables[0].Rows[0]["TimesUpdate"].ToString(), 0);
                        obj.VehicleNumber = ds.Tables[0].Rows[0]["VehicleNumber"].ToString();
                        obj.StartTime1 = clsCommon.convertStringToDate(ds.Tables[0].Rows[0]["StartTime2"].ToString(), clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS);


                        obj.StartTime2 =clsCommon.convertStringToDate( ds.Tables[0].Rows[0]["StartTime2"].ToString(),clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS);
                        obj.StartTime3 = clsCommon.convertStringToDate(ds.Tables[0].Rows[0]["StartTime2"].ToString(), clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS);
                        obj.StartTimePlan1 = clsCommon.convertStringToDate(ds.Tables[0].Rows[0]["StartTime2"].ToString(), clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS);
                        obj.StartTimePlan2 = clsCommon.convertStringToDate(ds.Tables[0].Rows[0]["StartTime2"].ToString(), clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS);
                        obj.StartTimePlan3 = clsCommon.convertStringToDate(ds.Tables[0].Rows[0]["StartTime2"].ToString(), clsCommon.DATE_FORMAT_DD_MM_YYYY_HH_MM_SS);
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

    }
}
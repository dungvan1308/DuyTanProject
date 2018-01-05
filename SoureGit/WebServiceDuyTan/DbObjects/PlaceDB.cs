using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Configuration;
using ClassLibraryObjects;
using ClassLibraryCommon;
using System.Data;

namespace WebServiceDuyTan.DbObjects
{
    public class PlaceDB
    {
        protected string strConection = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;

        public bool insertUpdatePlace(PlaceObject obj)
        {
            /*
           * Dungnv    :   18/10/2014
           * Purpose   :   Insert
           * Output    :   Ma outUserId
           */
            Double dec = 0;


            SqlParameter[] aParams = new SqlParameter[12];
            aParams[0] = new SqlParameter("@PlaceID", System.Data.SqlDbType.Int);
            aParams[0].Value = obj.PlaceID;

            aParams[1] = new SqlParameter("@PlaceName", System.Data.SqlDbType.NVarChar);
            aParams[1].Value = obj.Name;

            aParams[2] = new SqlParameter("@GpsX", System.Data.SqlDbType.Float);
            aParams[2].Value = obj.GpsX;

            aParams[3] = new SqlParameter("@GpsY", System.Data.SqlDbType.Float);
            aParams[3].Value = obj.GpsY;

            aParams[4] = new SqlParameter("@DistrictID", System.Data.SqlDbType.VarChar);
            aParams[4].Value = obj.DistrictID;

            aParams[5] = new SqlParameter("@CityID", System.Data.SqlDbType.VarChar);
            aParams[5].Value = obj.CityID;

            aParams[6] = new SqlParameter("@Address", System.Data.SqlDbType.NVarChar);
            aParams[6].Value = obj.Address;

            aParams[7] = new SqlParameter("@DistanceDuyTan", System.Data.SqlDbType.Float);
            aParams[7].Value = obj.DistanceDuyTan;

            aParams[8] = new SqlParameter("@TimeDuyTan", System.Data.SqlDbType.Float);
            aParams[8].Value = obj.TimeDuyTan;

            aParams[9] = new SqlParameter("@OfDuyTan", System.Data.SqlDbType.Bit);
            aParams[9].Value = obj.OfDuyTan;

            aParams[10] = new SqlParameter("@CreateBy", System.Data.SqlDbType.VarChar);
            aParams[10].Value = obj.CreateBy;

            aParams[11] = new SqlParameter("@ModifyBy", System.Data.SqlDbType.VarChar);
            aParams[11].Value = obj.ModifyBy;



            try
            {
                dec = SqlHelper.ExecuteNonQuery(strConection, CommandType.StoredProcedure, "usp_InsertUpdatePlace", aParams);

                return true;

            }
            catch (Exception ex)
            {
                dec = -1000;

                return false;
            }
        }

        public DataSet selectPlacesDynamic(string strCondition, string strOrderBy)
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
                ds = SqlHelper.ExecuteDataset(strConection, "usp_SelectPlacesDynamic", aParams);
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;

        }
        public PlaceObject selectPlace(int iPlaceID)
        {
            /*
             * Dungnv : 21/10/2014
             * Purpose: Tim kiem thong tin 
             */


            SqlParameter[] aParams = new SqlParameter[1];
            aParams[0] = new SqlParameter("@PlaceID ", System.Data.SqlDbType.Int);
            aParams[0].Value = iPlaceID;

            PlaceObject obj = new PlaceObject();
            bool outBool =false;
            Double outDec = 0;

            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "usp_SelectPlace", aParams);
                if (ds != null)
                {
                    if (ds.Tables[0] != null)
                    {
                        obj.PlaceID = Int32.Parse(ds.Tables[0].Rows[0]["PlaceID"].ToString());
                        obj.Name = ds.Tables[0].Rows[0]["PlaceName"].ToString();
                        Boolean.TryParse(ds.Tables[0].Rows[0]["OfDuyTan"].ToString(),out outBool);
                        obj.OfDuyTan = outBool;
                        Double.TryParse(ds.Tables[0].Rows[0]["GpsX"].ToString(), out outDec);
                        obj.GpsX = outDec;
                        Double.TryParse(ds.Tables[0].Rows[0]["GpsY"].ToString(), out outDec);
                        obj.GpsY = outDec;

                        obj.DistrictID = ds.Tables[0].Rows[0]["DistrictID"].ToString();
                        obj.CityID = ds.Tables[0].Rows[0]["CityID"].ToString();

                        obj.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                        Double.TryParse(ds.Tables[0].Rows[0]["TimeDuyTan"].ToString(), out outDec);
                        obj.TimeDuyTan = outDec;

                        obj.CreateBy = ds.Tables[0].Rows[0]["CreateBy"].ToString();

                        obj.ModifyBy = ds.Tables[0].Rows[0]["ModifyBy"].ToString();


                   
                        try
                        {
                            obj.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                        }
                        catch (Exception ex)
                        {

                            obj.CreateDate = DateTime.Parse("01/01/1970");
                        }

                        try
                        {
                            obj.ModifyDate = DateTime.Parse(ds.Tables[0].Rows[0]["ModifyDate"].ToString());
                        }
                        catch (Exception ex)
                        {

                            obj.ModifyDate = DateTime.Parse("01/01/1970");
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

        public bool deletePlace(int iPlaceId, out string strResult)
        {
            /*
             * Dungnv   : 09.11.2017
             * Purpose  : Xoa Trust
             */

            Double dec = 0;
            SqlParameter[] aParams = new SqlParameter[2];

            aParams[0] = new SqlParameter("@PlaceID", System.Data.SqlDbType.Int);
            aParams[0].Value = iPlaceId;

            aParams[1] = new SqlParameter("@RESULT", System.Data.SqlDbType.VarChar, 5);
            aParams[1].Direction = ParameterDirection.Output;

            try
            {
                dec = SqlHelper.ExecuteNonQuery(strConection, CommandType.StoredProcedure, "usp_DeletePlace", aParams);
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
    }
}
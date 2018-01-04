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
    public class TrustDB
    {
        protected string strConection = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;

        public bool insertUpdateTrust(TrustObject obj)
        {
            /*
           * Dungnv    :   18/10/2014
           * Purpose   :   Insert
           * Output    :   Ma outUserId
           */
            Double dec = 0;


            SqlParameter[] aParams = new SqlParameter[13];
            aParams[0] = new SqlParameter("@TrustID", System.Data.SqlDbType.Int);
            aParams[0].Value = obj.TrustID;

            aParams[1] = new SqlParameter("@TrustName", System.Data.SqlDbType.NVarChar);
            aParams[1].Value = obj.TrustName;

            aParams[2] = new SqlParameter("@VehicleNumber", System.Data.SqlDbType.VarChar);
            aParams[2].Value = obj.VehicleNumber;

            aParams[3] = new SqlParameter("@Type", System.Data.SqlDbType.Char);
            aParams[3].Value = obj.Type;

            aParams[4] = new SqlParameter("@DateOfPurchase", System.Data.SqlDbType.Date);
            aParams[4].Value = obj.DateOfPurchase;

            aParams[5] = new SqlParameter("@Total", System.Data.SqlDbType.Decimal);
            aParams[5].Value = obj.Total;

            aParams[6] = new SqlParameter("@SeatingNumber", System.Data.SqlDbType.Int);
            aParams[6].Value = obj.SeatingNumber;

            aParams[7] = new SqlParameter("@Color", System.Data.SqlDbType.NVarChar);
            aParams[7].Value = obj.Color;

            aParams[8] = new SqlParameter("@Capicity", System.Data.SqlDbType.Decimal);
            aParams[8].Value = obj.Capicity;

            aParams[9] = new SqlParameter("@ExpireDate", System.Data.SqlDbType.Date);
            aParams[9].Value = obj.ExpireDate;

            aParams[10] = new SqlParameter("@GroupTrust", System.Data.SqlDbType.Char);
            aParams[10].Value = obj.GroupTrust;

          
            aParams[11] = new SqlParameter("@CreateBy", System.Data.SqlDbType.VarChar);
            aParams[11].Value = obj.CreateBy;

            /*
            aParams[12] = new SqlParameter("@CreateDate", System.Data.SqlDbType.Date);
            aParams[12].Value = obj.CreateDate;
            */

            aParams[12] = new SqlParameter("@ModifyBy", System.Data.SqlDbType.VarChar);
            aParams[12].Value = obj.ModifyBy;

            /*
            aParams[14] = new SqlParameter("@ModifyDate", System.Data.SqlDbType.Date);
            aParams[14].Value = obj.ModifyDate;
            */


            try
            {
                dec = SqlHelper.ExecuteNonQuery(strConection, CommandType.StoredProcedure, "usp_InsertUpdateTrust", aParams);
                
                return true;

            }
            catch (Exception ex)
            {
                dec = -1000;
                
                return false;
            }
        }
        public TrustObject selectTrust(int  iTrustID)
        {
            /*
             * Dungnv : 21/10/2014
             * Purpose: Tim kiem thong tin 
             */


            SqlParameter[] aParams = new SqlParameter[1];
            aParams[0] = new SqlParameter("@TrustID ", System.Data.SqlDbType.Int);
            aParams[0].Value = iTrustID;

            TrustObject obj = new TrustObject();

            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "usp_SelectTrust", aParams);
                if (ds != null)
                {
                    if (ds.Tables[0] != null)
                    {
                        obj.TrustID = Int32.Parse(ds.Tables[0].Rows[0]["TrustID"].ToString());
                        obj.TrustName = ds.Tables[0].Rows[0]["TrustName"].ToString();
                        obj.VehicleNumber = ds.Tables[0].Rows[0]["VehicleNumber"].ToString();
                        obj.Type = ds.Tables[0].Rows[0]["Type"].ToString();

                        obj.Total = Decimal.Parse(ds.Tables[0].Rows[0]["Total"].ToString());
                        obj.SeatingNumber = Int32.Parse(ds.Tables[0].Rows[0]["SeatingNumber"].ToString());
                        obj.Color = ds.Tables[0].Rows[0]["Color"].ToString();
                        obj.Capicity = Decimal.Parse(ds.Tables[0].Rows[0]["Capicity"].ToString());

                        obj.GroupTrust = ds.Tables[0].Rows[0]["GroupTrust"].ToString();
                     
                        obj.CreateBy = ds.Tables[0].Rows[0]["CreateBy"].ToString();

                        obj.ModifyBy = ds.Tables[0].Rows[0]["ModifyBy"].ToString();


                        try
                        {
                            obj.ExpireDate = DateTime.Parse(ds.Tables[0].Rows[0]["ExpireDate"].ToString());
                        }
                        catch (Exception ex)
                        {

                            obj.ExpireDate = DateTime.Parse("01/01/1970");
                        }


                        try
                        {
                            obj.DateOfPurchase = DateTime.Parse(ds.Tables[0].Rows[0]["DateOfPurchase"].ToString());
                        }
                        catch (Exception ex)
                        {

                            obj.DateOfPurchase = DateTime.Parse("01/01/1970");
                        }
                      
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
        public DataSet selectTrustsDynamic(string strCondition, string strOrderBy)
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
                ds = SqlHelper.ExecuteDataset(strConection, "usp_SelectTrustsDynamic", aParams);
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;

        }

        public bool deleteTrust(int iTrustID, out string strResult)
        {
            /*
             * Dungnv   : 09.11.2017
             * Purpose  : Xoa Trust
             */

            Double dec = 0;
            SqlParameter[] aParams = new SqlParameter[2];

            aParams[0] = new SqlParameter("@TrustID", System.Data.SqlDbType.Int);
            aParams[0].Value = iTrustID;

            aParams[1] = new SqlParameter("@RESULT", System.Data.SqlDbType.VarChar, 5);
            aParams[1].Direction = ParameterDirection.Output;

            try
            {
                dec = SqlHelper.ExecuteNonQuery(strConection, CommandType.StoredProcedure, "usp_DeleteTrust", aParams);
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
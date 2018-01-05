using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using ClassLibraryObjects;
using System.Data;

namespace WebServiceDuyTan.DbObjects
{
    public class EmployeeDB
    {
        protected string strConection = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
        
        public EmployeeObject selectEmployee(int ID)
        {
            SqlParameter[] aParams = new SqlParameter[1];
            aParams[0] = new SqlParameter("@EMPLOYEEID ", System.Data.SqlDbType.VarChar);
            aParams[0].Value = ID;

            EmployeeObject obj = new EmployeeObject();
            string strSql = "";
            int iCount =0;
            ArrayList arrSalary = new ArrayList();

            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "usp_SelectEmployee", aParams);
                if (ds != null)
                {
                    if (ds.Tables[0] != null)
                    {
                        obj.Id = Int32.Parse( ds.Tables[0].Rows[0]["EmployeeId"].ToString());
                        obj.Name = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
                        if (ds.Tables[0].Rows[0]["BirthDay"].ToString() != "")
                        {
                            obj.BirthDay = DateTime.Parse(ds.Tables[0].Rows[0]["BirthDay"].ToString());
                        }
                        obj.Birth_Place = ds.Tables[0].Rows[0]["Birth_Place"].ToString();
                        obj.Identitycard = ds.Tables[0].Rows[0]["Identitycard"].ToString();
                        if (ds.Tables[0].Rows[0]["Identitycard_DateIssue"].ToString() != null)
                        {
                            obj.Identitycard_DateIssue = DateTime.Parse(ds.Tables[0].Rows[0]["Identitycard_DateIssue"].ToString());
                        }
                        obj.Identitycard_PlaceIssue = ds.Tables[0].Rows[0]["Identitycard_PlaceIssue"].ToString();
                        obj.Gender = ds.Tables[0].Rows[0]["Gender"].ToString();
                        obj.MaritalStatus = ds.Tables[0].Rows[0]["MaritalStatus"].ToString();
                        obj.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                        obj.CityId = ds.Tables[0].Rows[0]["CityId"].ToString();
                        obj.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                        obj.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();

                        obj.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                        obj.Education = ds.Tables[0].Rows[0]["Education"].ToString();
                        obj.Status = ds.Tables[0].Rows[0]["Status"].ToString();
                        
                        if (ds.Tables[0].Rows[0]["DateStartWork"].ToString() != "")
                            obj.DateStartWork = DateTime.Parse(ds.Tables[0].Rows[0]["DateStartWork"].ToString());



                        obj.Position = ds.Tables[0].Rows[0]["Position"].ToString();
                        obj.CreateBy = ds.Tables[0].Rows[0]["CreateBy"].ToString();
                        if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                            obj.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());



                    }
                }
            }
            catch (Exception ex)
            {
                obj = null;
            }

            return obj;
        }
        public DataSet selectEmployeeDymanic(string strCondition, string strOrderBy)
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
                ds = SqlHelper.ExecuteDataset(strConection, "usp_SelectEmployeesDynamic", aParams);
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;

        }
        public bool deleteEmployee(string strEmployeeId, out string strResult)
        {
            /*
             * Dungnv   : 23/10/2014
             * Purpose  : Xoa Employee 
             */

            Double dec = 0;
            SqlParameter[] aParams = new SqlParameter[2];

            aParams[0] = new SqlParameter("@EMPLOYEEID", System.Data.SqlDbType.NVarChar);
            aParams[0].Value = strEmployeeId;

            aParams[1] = new SqlParameter("@RESULT", System.Data.SqlDbType.VarChar, 5);
            aParams[1].Direction = ParameterDirection.Output;

            try
            {
                dec = SqlHelper.ExecuteNonQuery(strConection, CommandType.StoredProcedure, "pro_DeleteEmployee", aParams);
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
        public bool insertUpdateEmployee(EmployeeObject employee)
        {
            /*
           * Dungnv    :   18/10/2014
           * Purpose   :   Insert
           * Output    :   Ma outEmployeeId
           */

            SqlParameter[] aParams = new SqlParameter[23];

            aParams[0] = new SqlParameter("@EmployeeId", System.Data.SqlDbType.VarChar);
            aParams[0].Value = employee.Id;

            aParams[1] = new SqlParameter("@EmployeeName", System.Data.SqlDbType.NVarChar);
            aParams[1].Value = employee.Name;

            aParams[2] = new SqlParameter("@BirthDay", System.Data.SqlDbType.Date);
            aParams[2].Value = employee.BirthDay;

            aParams[3] = new SqlParameter("@Birth_Place", System.Data.SqlDbType.VarChar);
            aParams[3].Value = employee.Birth_Place;

            aParams[4] = new SqlParameter("@Identitycard", System.Data.SqlDbType.VarChar);
            aParams[4].Value = employee.Identitycard;

            aParams[5] = new SqlParameter("@Identitycard_DateIssue", System.Data.SqlDbType.Date);
            aParams[5].Value = employee.Identitycard_DateIssue;

            aParams[6] = new SqlParameter("@Identitycard_PlaceIssue", System.Data.SqlDbType.VarChar);
            aParams[6].Value = employee.Identitycard_PlaceIssue;

            aParams[7] = new SqlParameter("@Gender", System.Data.SqlDbType.Char);
            aParams[7].Value = employee.Gender;

            aParams[8] = new SqlParameter("@MaritalStatus", System.Data.SqlDbType.Char);
            aParams[8].Value = employee.MaritalStatus;

            aParams[9] = new SqlParameter("@Address", System.Data.SqlDbType.NVarChar);
            aParams[9].Value = employee.Address;

            aParams[10] = new SqlParameter("@CityId", System.Data.SqlDbType.VarChar);
            aParams[10].Value = employee.CityId;

            aParams[11] = new SqlParameter("@Phone", System.Data.SqlDbType.VarChar);
            aParams[11].Value = employee.Phone;

            aParams[12] = new SqlParameter("@Mobile", System.Data.SqlDbType.VarChar);
            aParams[12].Value = employee.Mobile;

            aParams[13] = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
            aParams[13].Value = employee.Email;

            aParams[14] = new SqlParameter("@Education", System.Data.SqlDbType.VarChar);
            aParams[14].Value = employee.Education;

            aParams[15] = new SqlParameter("@Position", System.Data.SqlDbType.VarChar);
            aParams[15].Value = employee.Position;

            aParams[16] = new SqlParameter("@DateStartWork", System.Data.SqlDbType.Date);
            aParams[16].Value = employee.DateStartWork;

            aParams[17] = new SqlParameter("@Type", System.Data.SqlDbType.VarChar);
            aParams[17].Value = employee.Type;

            aParams[18] = new SqlParameter("@LicenseType", System.Data.SqlDbType.VarChar);
            aParams[18].Value = employee.LicenseType;

            aParams[19] = new SqlParameter("@Status", System.Data.SqlDbType.Char);
            aParams[19].Value = employee.Status;

            aParams[20] = new SqlParameter("@UserID", System.Data.SqlDbType.VarChar);
            aParams[20].Value = employee.UserID;

            aParams[21] = new SqlParameter("@CreateBy", System.Data.SqlDbType.VarChar);
            aParams[21].Value = employee.CreateBy;

            aParams[22] = new SqlParameter("@ModifyBy", System.Data.SqlDbType.VarChar);
            aParams[22].Value = employee.ModifyBy;

            

            try
            {
                Double dec = SqlHelper.ExecuteNonQuery(strConection, CommandType.StoredProcedure, "usp_InsertUpdateEmployee", aParams);
                return true;

            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
      
    }
}
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
    public class UserDB
    {
        protected string strConection = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
         
        public bool loginUser(UserObject users,out UserObject outUser)
        {
            /*
             * Dungnv   : 18/10/2014
             * Purpose  : Check user có đăng nhập được ko ? Nếu có lấy thông tin của user trả về
             */

            SqlParameter[] aParams = new SqlParameter[2];
            aParams[0] = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
            aParams[0].Value = users.USERNAME;

            aParams[1] = new SqlParameter("@Password", System.Data.SqlDbType.VarChar);
            aParams[1].Value = users.PASSWORD;
            outUser = new UserObject();
            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "proc_LoginUser", aParams);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (Boolean.Parse(ds.Tables[0].Rows[0]["Lock"].ToString()) == false)
                        {
                            //User khong bi lock 
                            outUser.USERID = ds.Tables[0].Rows[0]["USERID"].ToString().Trim();
                            outUser.USERNAME = ds.Tables[0].Rows[0]["USERNAME"].ToString().Trim();
                            outUser.GROUPID = ds.Tables[0].Rows[0]["GROUPID"].ToString().Trim();
                            outUser.FULLNAME = ds.Tables[0].Rows[0]["FULLNAME"].ToString().Trim();
                            return true;
                        }
                        else
                        {
                            outUser = null;
                            return false;

                        }
                    }
                    else
                    {
                        outUser = null;
                        return false;
                    }


                }
                else
                {
                    outUser = null;
                    return false;
                }
            }
            catch (Exception ex)
            {
                outUser = null;
                return false;
            }


        }
        public bool insertUser(UserObject user, out string outUserId)
        {
            /*
           * Dungnv    :   18/10/2014
           * Purpose   :   Insert
           * Output    :   Ma outUserId
           */
            Double dec = 0;


            SqlParameter[] aParams = new SqlParameter[6];
            aParams[0] = new SqlParameter("@USERNAME", System.Data.SqlDbType.VarChar);
            aParams[0].Value = user.USERNAME;

            aParams[1] = new SqlParameter("@FULLNAME", System.Data.SqlDbType.NVarChar);
            aParams[1].Value = user.FULLNAME;

            aParams[2] = new SqlParameter("@GROUPID", System.Data.SqlDbType.VarChar);
            aParams[2].Value = user.GROUPID;

            aParams[3] = new SqlParameter("@EmployeeID", System.Data.SqlDbType.VarChar);
            aParams[3].Value = user.EMPLOYEEID;

            aParams[4] = new SqlParameter("@CREATEBY", System.Data.SqlDbType.VarChar);
            aParams[4].Value = user.CREATEBY;


            aParams[5] = new SqlParameter("@OUTUSERID", System.Data.SqlDbType.VarChar, 5);
            aParams[5].Direction = ParameterDirection.Output;

            try
            {
                dec = SqlHelper.ExecuteNonQuery(strConection, CommandType.StoredProcedure, "proc_InsertUser", aParams);
                outUserId = aParams[5].Value.ToString();
                return true;

            }
            catch (Exception ex)
            {
                dec = -1000;
                outUserId = "";
                return false;
            }
        }
        public bool updateUser(UserObject user)
        {
            /*
           * Dungnv    :   21/10/2014
           * Purpose   :   Update
           * Output    :   
           */
            Double dec = 0;


            SqlParameter[] aParams = new SqlParameter[6];
            aParams[0] = new SqlParameter("@USERNAME", System.Data.SqlDbType.VarChar);
            aParams[0].Value = user.USERNAME;

            aParams[1] = new SqlParameter("@FULLNAME", System.Data.SqlDbType.NVarChar);
            aParams[1].Value = user.FULLNAME;

            aParams[2] = new SqlParameter("@GROUPID", System.Data.SqlDbType.VarChar);
            aParams[2].Value = user.GROUPID;

            aParams[3] = new SqlParameter("@EmployeeID", System.Data.SqlDbType.VarChar);
            aParams[3].Value = user.EMPLOYEEID;

            
            aParams[4] = new SqlParameter("@LOCK", System.Data.SqlDbType.Bit);
            aParams[4].Value = user.LOCK;

            aParams[5] = new SqlParameter("@MODIFIEDBY", System.Data.SqlDbType.VarChar);
            aParams[5].Value = user.MODIFIEDBY;

         
            try
            {
                dec = SqlHelper.ExecuteNonQuery(strConection, CommandType.StoredProcedure, "proc_updateUser", aParams);
            
                return true;

            }
            catch (Exception ex)
            {
                dec = -1000;
              
                return false;
            }
        }
        public UserObject selectUser(string strUserId)
        {
            /*
             * Dungnv : 21/10/2014
             * Purpose: Tim kiem thong tin 
             */

            SqlParameter[] aParams = new SqlParameter[1];
            aParams[0] = new SqlParameter("@USERID ", System.Data.SqlDbType.VarChar);
            aParams[0].Value = strUserId;

            UserObject obj = new UserObject();

            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "proc_SelectUser", aParams);
                if (ds != null)
                {
                    if (ds.Tables[0] != null)
                    {
                        obj.GROUPID = ds.Tables[0].Rows[0]["GROUPID"].ToString();
                        obj.USERID = ds.Tables[0].Rows[0]["USERID"].ToString();
                        obj.EMPLOYEEID = ds.Tables[0].Rows[0]["EmployeeID"].ToString();
                        obj.USERNAME = ds.Tables[0].Rows[0]["USERNAME"].ToString();
                        obj.MODIFIEDBY = ds.Tables[0].Rows[0]["MODIFIEDBY"].ToString();
                        obj.CREATEBY = ds.Tables[0].Rows[0]["CREATEBY"].ToString();
                        obj.FULLNAME = ds.Tables[0].Rows[0]["FULLNAME"].ToString();
                        obj.LOCK = bool.Parse(ds.Tables[0].Rows[0]["LOCK"].ToString());
                        obj.CREATEDATE = DateTime.Parse(ds.Tables[0].Rows[0]["CREATEDATE"].ToString());
                        try
                        {
                            obj.MODIFIEDDATE = DateTime.Parse(ds.Tables[0].Rows[0]["MODIFIEDDATE"].ToString());
                        }
                        catch (Exception ex)
                        {

                            obj.MODIFIEDDATE = DateTime.Parse("01/01/1970");
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

        public UserObject selectUserByUserName(string strUserName)
        {
            /*
             * Dungnv : 21/10/2014
             * Purpose: Tim kiem thong tin 
             */

            SqlParameter[] aParams = new SqlParameter[1];
            aParams[0] = new SqlParameter("@USERNAME", System.Data.SqlDbType.VarChar);
            aParams[0].Value = strUserName;

            UserObject obj = new UserObject();

            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "proc_SelectUserByUserName", aParams);
                if (ds != null)
                {
                    if (ds.Tables[0] != null)
                    {
                        obj.GROUPID = ds.Tables[0].Rows[0]["GROUPID"].ToString();
                        obj.USERID = ds.Tables[0].Rows[0]["USERID"].ToString();
                        obj.EMPLOYEEID = ds.Tables[0].Rows[0]["EMPLOYEEID"].ToString();
                        obj.USERNAME = ds.Tables[0].Rows[0]["USERNAME"].ToString();
                        obj.MODIFIEDBY = ds.Tables[0].Rows[0]["MODIFIEDBY"].ToString();
                        obj.CREATEBY = ds.Tables[0].Rows[0]["CREATEBY"].ToString();
                        obj.FULLNAME = ds.Tables[0].Rows[0]["FULLNAME"].ToString();
                        obj.LOCK = bool.Parse(ds.Tables[0].Rows[0]["LOCK"].ToString());
                        obj.CREATEDATE = DateTime.Parse(ds.Tables[0].Rows[0]["CREATEDATE"].ToString());
                        obj.MODIFIEDDATE = DateTime.Parse(ds.Tables[0].Rows[0]["MODIDIEDDATE"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                obj = null;
            }

            return obj;
        }


        public DataSet selectUserDymanic(string strCondition, string strOrderBy)
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
                ds = SqlHelper.ExecuteDataset(strConection, "proc_SelectUserDynamic", aParams);
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;

        }
        public bool lock_unlock_User(UserObject user)
        {
            /*
           * Dungnv    :   21/10/2014
           * Purpose   :   Update
           * Output    :   
           */
            Double dec = 0;

                        SqlParameter[] aParams = new SqlParameter[3];
            aParams[0] = new SqlParameter("@USERNAME", System.Data.SqlDbType.VarChar);
            aParams[0].Value = user.USERNAME;

            aParams[1] = new SqlParameter("@LOCK", System.Data.SqlDbType.Bit);
            aParams[1].Value = user.LOCK;

            aParams[2] = new SqlParameter("@MODIFIEDBY", System.Data.SqlDbType.VarChar);
            aParams[2].Value = user.MODIFIEDBY;

            try
            {
                dec = SqlHelper.ExecuteNonQuery(strConection, CommandType.StoredProcedure, "proc_lock_unlock_User", aParams);
            
                return true;

            }
            catch (Exception ex)
            {
                dec = -1000;
              
                return false;
            }
        }
        public bool resetPass(UserObject user)
        {
            /*
           * Dungnv    :   21/10/2014
           * Purpose   :   Update
           * Output    :   
           */
            Double dec = 0;

            SqlParameter[] aParams = new SqlParameter[3];
            aParams[0] = new SqlParameter("@USERNAME", System.Data.SqlDbType.VarChar);
            aParams[0].Value = user.USERNAME;

            aParams[1] = new SqlParameter("@PASSWORD", System.Data.SqlDbType.NVarChar);
            aParams[1].Value = user.PASSWORD;

            aParams[2] = new SqlParameter("@MODIFIEDBY", System.Data.SqlDbType.VarChar);
            aParams[2].Value = user.MODIFIEDBY;

            try
            {
                dec = SqlHelper.ExecuteNonQuery(strConection, CommandType.StoredProcedure, "proc_ResetUser", aParams);

                return true;

            }
            catch (Exception ex)
            {
                dec = -1000;

                return false;
            }
        }
        public DataSet lookUpUser()
        {
            /*
             * Dungnv   : 22/10/2014
             * Purpse   : Lay thong tin All GroupUser 
             */
            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "proc_lookupUser");
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;

        }
        public bool deleteUser(string strUserId, out string strResult)
        {
            /*
             * Dungnv   : 23/10/2014
             * Purpose  : Xoa Customer 
             */

            Double dec = 0;
            SqlParameter[] aParams = new SqlParameter[2];

            aParams[0] = new SqlParameter("@USERID", System.Data.SqlDbType.VarChar);
            aParams[0].Value = strUserId;

            aParams[1] = new SqlParameter("@RESULT", System.Data.SqlDbType.VarChar, 5);
            aParams[1].Direction = ParameterDirection.Output;

            try
            {
                dec = SqlHelper.ExecuteNonQuery(strConection, CommandType.StoredProcedure, "proc_DeleteUser", aParams);
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

        public bool logOut(string strUserId)
        {
            /*
             * Dungnv   :   25/05/2015
             * Purpose  :   Update status khi logout
             */

            String strSql = "";
            strSql = "update LogIn set Status=0,LogOut=SYSDATETIME() where UserID='" + strUserId.Trim() + "'";
            Double dec = 0;
            try
            {
                dec = SqlHelper.ExecuteNonQuery(strConection, CommandType.Text, strSql);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool checkLienceKey()
        {
            /*
             * Dungnv   :   Check Lience cua phan mem
             */
            string strLienceKey ="";
            strLienceKey = ConfigurationManager.ConnectionStrings["LienceKey"].ConnectionString;

            //Doc thong tin Server 
            string strInfoMachine = "";
            
            strInfoMachine = CommonObject.getCpuId_Serial();
            strInfoMachine = CommonObject.EncryptData(strInfoMachine);
            if(strInfoMachine.Trim()==strLienceKey.Trim())
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }
    
    }
}
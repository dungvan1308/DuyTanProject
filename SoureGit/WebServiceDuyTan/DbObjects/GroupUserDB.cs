using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Configuration;
using ClassLibraryObjects;
using System.Data;

namespace WebServiceDuyTan.DbObjects
{
    public class GroupUserDB
    {
        protected string strConection = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
        public bool insertGroupUseṛ(GroupUserObject groupUsers, out string OutGroupId)
        {
            /*
            * Dungnv    :   18/10/2014
            * Purpose   :   Insert
            * Output    :   Ma OutGroupId
            */
            Double dec = 0;


            SqlParameter[] aParams = new SqlParameter[5];
            aParams[0] = new SqlParameter("@GROUPNAME", System.Data.SqlDbType.NVarChar);
            aParams[0].Value = groupUsers.GROUPNAME;

            aParams[1] = new SqlParameter("@NOTE", System.Data.SqlDbType.NVarChar);
            aParams[1].Value = groupUsers.NOTE;

            aParams[2] = new SqlParameter("@CREATEBY", System.Data.SqlDbType.VarChar);
            aParams[2].Value = groupUsers.CREATEBY;

            aParams[3] = new SqlParameter("@MODIFIEDBY", System.Data.SqlDbType.VarChar);
            aParams[3].Value = groupUsers.MODIFIEDBY;

            aParams[4] = new SqlParameter("@OutGroupId", System.Data.SqlDbType.VarChar, 5);
            aParams[4].Direction = ParameterDirection.Output;

            try
            {
                dec = SqlHelper.ExecuteNonQuery(strConection, CommandType.StoredProcedure, "proc_InsertGroupUser", aParams);
                OutGroupId = aParams[4].Value.ToString();
                return true;

            }
            catch (Exception ex)
            {
                dec = -1000;
                OutGroupId = "";
                return false;
            }

        }
        public bool updateGroupUser(GroupUserObject groupUsers)
        {
            /*
             * Dungnv   : 18/10/2014
             * Purpose  : Update Thong Tin 
             */
            Double dec = 0;


            SqlParameter[] aParams = new SqlParameter[4];

            aParams[0] = new SqlParameter("@GROUPID", System.Data.SqlDbType.VarChar);
            aParams[0].Value = groupUsers.GROUPID;

            aParams[1] = new SqlParameter("@GROUPNAME", System.Data.SqlDbType.NVarChar);
            aParams[1].Value = groupUsers.GROUPNAME;

            aParams[2] = new SqlParameter("@NOTE", System.Data.SqlDbType.NVarChar);
            aParams[2].Value = groupUsers.NOTE;

            aParams[3] = new SqlParameter("@MODIFIEDBY", System.Data.SqlDbType.VarChar);
            aParams[3].Value = groupUsers.MODIFIEDBY;


            try
            {
                dec = SqlHelper.ExecuteNonQuery(strConection, CommandType.StoredProcedure, "proc_updateGroupUser", aParams);
                return true;

            }
            catch (Exception ex)
            {
                dec = -1000;
                return false;
            }

        }
        public GroupUserObject selectGroupUser(string strGroupUserID)
        {
            /*
             * Dungnv : 18/10/2014
             * Purpose: Tim kiem thong tin 
             */

            SqlParameter[] aParams = new SqlParameter[1];
            aParams[0] = new SqlParameter("@GROUPID", System.Data.SqlDbType.VarChar);
            aParams[0].Value = strGroupUserID;

            GroupUserObject obj = new GroupUserObject();

            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "proc_SelectGroupUser", aParams);
                if (ds != null)
                {
                    if (ds.Tables[0] != null)
                    {
                        obj.GROUPID = ds.Tables[0].Rows[0]["GROUPID"].ToString();
                        obj.GROUPNAME = ds.Tables[0].Rows[0]["GROUPNAME"].ToString();
                        obj.NOTE = ds.Tables[0].Rows[0]["NOTE"].ToString();
                        obj.MODIFIEDBY = ds.Tables[0].Rows[0]["MODIFIEDBY"].ToString();
                        obj.CREATEBY = ds.Tables[0].Rows[0]["CREATEBY"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                obj = null;
            }

            return obj;
        }

        public GroupUserObject selectGroupUserByName(string strGroupName)
        {
            /*
             * Dungnv : 18/10/2014
             * Purpose: Tim kiem thong tin 
             */

            SqlParameter[] aParams = new SqlParameter[1];
            aParams[0] = new SqlParameter("@GROUPNAME", System.Data.SqlDbType.NVarChar);
            aParams[0].Value = strGroupName;

            GroupUserObject obj = new GroupUserObject();

            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "proc_SelectGroupUserByName", aParams);
                if (ds != null)
                {
                    if (ds.Tables[0] != null)
                    {
                        obj.GROUPID = ds.Tables[0].Rows[0]["GROUPID"].ToString();
                        obj.GROUPNAME = ds.Tables[0].Rows[0]["GROUPNAME"].ToString();
                        obj.NOTE = ds.Tables[0].Rows[0]["NOTE"].ToString();
                        obj.MODIFIEDBY = ds.Tables[0].Rows[0]["MODIFIEDBY"].ToString();
                        obj.CREATEBY = ds.Tables[0].Rows[0]["CREATEBY"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                obj = null;
            }

            return obj;
        }

        public DataSet selectGroupUserDymanic(string strCondition, string strOrderBy)
        {
            /*
             * Dungnv : 18/10/2014
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
                ds = SqlHelper.ExecuteDataset(strConection, "proc_SelectGroupUserDynamic", aParams);
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;

        }
        public DataSet lookUpGroupUser()
        {
            /*
             * Dungnv   : 22/10/2014
             * Purpse   : Lay thong tin All GroupUser 
             */
            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "proc_lookupGroupUser");
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;

        }

        public bool deleteGroupUser(string strGroupUserId, out string strResult)
        {
            /*
             * Dungnv   : 15/10/2013
             * Purpose  : Xoa Group User 
             */

            Double dec = 0;


            SqlParameter[] aParams = new SqlParameter[2];

            aParams[0] = new SqlParameter("@GROUPID", System.Data.SqlDbType.VarChar);
            aParams[0].Value = strGroupUserId;

            aParams[1] = new SqlParameter("@RESULT", System.Data.SqlDbType.VarChar, 6);
            aParams[1].Direction = ParameterDirection.Output;

            try
            {
                dec = SqlHelper.ExecuteNonQuery(strConection, CommandType.StoredProcedure, "proc_DeleteGroupUser", aParams);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibraryObjects;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;


namespace WebServiceDuyTan.DbObjects
{
    public class MenuDB
    {
        protected string strConection = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
        public MenuObjectList selectAllMenuItem()
        {
            MenuObjectList menuObjectList = new MenuObjectList();

            SqlParameter[] aParams = new SqlParameter[2];

            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "proc_SelectAllMenuItem", null);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    ArrayList listMenuItems = new ArrayList();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        MenuObject menuObject = new MenuObject();
                        menuObject.MENUID = ds.Tables[0].Rows[i]["MENUID"].ToString().Trim();
                        menuObject.MENUNAME = ds.Tables[0].Rows[i]["MENUNAME"].ToString().Trim();
                        menuObject.PARENTID = ds.Tables[0].Rows[i]["PARENTID"].ToString().Trim();
                        menuObject.NOTE = ds.Tables[0].Rows[i]["MODULE"].ToString().Trim();
                        if (ds.Tables[0].Rows[i]["MENUORDER"].ToString().Trim() != "")
                        {
                            menuObject.MENUORDER = Convert.ToInt16(ds.Tables[0].Rows[i]["MENUORDER"].ToString().Trim());
                        }
                        menuObject.AU = ds.Tables[0].Rows[i]["AU"].ToString().Trim();
                        listMenuItems.Add(menuObject);
                    }
                    menuObjectList.add(listMenuItems);
                }
            }
            catch (Exception ex)
            {

            }
            return menuObjectList;
        }

        public AuthorizeMenuObjectList getAuthorizeMenus(string userGroupId)
        {
            AuthorizeMenuObjectList authorizeMenuList = new AuthorizeMenuObjectList();

            SqlParameter[] aParams = new SqlParameter[1];
            aParams[0] = new SqlParameter("@GROUPID", System.Data.SqlDbType.NVarChar);
            aParams[0].Value = userGroupId;

            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "proc_SelectAuthorizeMenu", aParams);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    ArrayList listMenuItems = new ArrayList();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string menuId = ds.Tables[0].Rows[i]["MENUID"].ToString().Trim();
                        listMenuItems.Add(menuId);
                    }
                    authorizeMenuList.menuIdList = listMenuItems;
                }
            }
            catch (Exception ex)
            {

            }
            return authorizeMenuList;
        }

        public bool updateAuthorizeMenu(AuthorizeMenuObjectList authorizeMenuList)
        {
            if (authorizeMenuList.menuIdList.Count > 0)
            {
                try
                {
                    string userGroupID = authorizeMenuList.USERGROUPID;
                    String sql = " DELETE FROM AUTHORISEMENU WHERE GROUPID='" + userGroupID + "' ";
                    for (int i = 0; i < authorizeMenuList.menuIdList.Count; i++)
                    {
                        string menuID = authorizeMenuList.menuIdList[i] as string;
                        sql += " INSERT INTO AUTHORISEMENU(MENUID,GROUPID) VALUES('" + menuID + "', '" + userGroupID + "') ";
                    }
                    SqlHelper.ExecuteNonQuery(strConection, CommandType.Text, sql);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            return false;
        }

        public void checkAuthorizeManage(string strModule, string strGroupID,ref bool bAdd,ref bool bDel,ref bool bUpd, ref bool bVie)
        {
            /*
             * Dungnv   :   22/06/2016
             * Purpose  :   Check quyen them xoa sua tren cac form Manage Common
             */

            string strSql = "";
            DataSet ds = new DataSet();
            strSql = " select GROUPID,RIGHT(A.MENUID,3) STATUS  from AUTHORISEMENU A,MENU B "
		            + " WHERE left(A.MENUID,6) = B.MENUID "
		            + " AND A.GROUPID='" + strGroupID + "' and MODULE ='" + strModule + "'"
		            + " and RIGHT(A.MENUID,3) in ('ADD','DEL','UPD','VIE')";

            bAdd = false;
            bDel = false;
            bUpd = false;
            bVie = false;

            try
            {


                ds = SqlHelper.ExecuteDataset(strConection, CommandType.Text, strSql);
                if(ds!=null)
                {
                    if(ds.Tables[0]!=null)
                    {
                        if(ds.Tables[0].Rows.Count > 0)
                        {
                            for(int i=0;i < ds.Tables[0].Rows.Count ;i++)
                            {
                               if( ds.Tables[0].Rows[i]["STATUS"].ToString().Trim()=="ADD")
                               {
                                   bAdd = true;
                               }

                               if (ds.Tables[0].Rows[i]["STATUS"].ToString().Trim() == "DEL")
                               {
                                   bDel = true;
                               }
                               if (ds.Tables[0].Rows[i]["STATUS"].ToString().Trim() == "UPD")
                               {
                                   bUpd = true;
                               }
                               if (ds.Tables[0].Rows[i]["STATUS"].ToString().Trim() == "VIE")
                               {
                                   bVie = true;
                               }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
            

        }
    }
}
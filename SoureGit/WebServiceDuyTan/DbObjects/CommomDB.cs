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
    public class CommomDB
    {
        protected string strConection = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
        protected string strSoureDir = ConfigurationManager.ConnectionStrings["DirectoryBK"].ConnectionString;
        protected string strDBName = ConfigurationManager.ConnectionStrings["DBName"].ConnectionString;
        protected string strMachine = ConfigurationManager.ConnectionStrings["Machine"].ConnectionString; 

        public DataSet SelectCiTyDynamic(string strCondition, string strOrderBy)
        {
            /*
             * Dungnv : 10/10/2013
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
                ds = SqlHelper.ExecuteDataset(strConection, "proc_SelectCiTyDynamic", aParams);
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;

        }
        public DataSet SelecAllCodeDynamic(string strFieldName, string strTableName)
        {
            /*
             * Dungnv : 10/10/2013
             * Purpose: Tim kiem thong tin 
             */

            SqlParameter[] aParams = new SqlParameter[2];
            aParams[0] = new SqlParameter("@FieldName", System.Data.SqlDbType.NVarChar);
            aParams[0].Value = strFieldName;

            aParams[1] = new SqlParameter("@TableName", System.Data.SqlDbType.NVarChar);
            aParams[1].Value = strTableName;

            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "proc_SelecAllCodeDynamic", aParams);
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;

        }
        public DataSet SelectBySql(string Sql)
        {
            /*
             *  Dungnv  :   30/10/2014
             *  Purpose :   Lay thong tin tu cau lenh Sql
             */
            DataSet ds = new DataSet();
            ds = null;
            try
            {
                if (Sql != "")
                {
                    ds = SqlHelper.ExecuteDataset(strConection, CommandType.Text, Sql);
                }

            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;
        }
        public DataSet get_info_company()
        {
            /*
             * Dungnv   :   06/03/2015
             * Purpose  :   Lay thong tin cong ty tu Db 
             */
            string strSql = "";
            DataSet ds = new DataSet();
            strSql = "select COMPANYNAME,ADDRESS,TAX,TEL from INFO";
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, CommandType.Text, strSql);

            }
            catch (Exception ex)
            {
                ds = null;
            }

            return ds;
        }
        public bool backupData()
        {
            /*
             *  Dungnv  :   25/04/2015
             *  Purpose :   Backup du lieu 
             */
            SqlParameter[] aParams = new SqlParameter[1];

            aParams[0] = new SqlParameter("@PATH", System.Data.SqlDbType.VarChar);
            aParams[0].Value = strSoureDir;


            Double dec = 0;
            try
            {
                dec = SqlHelper.ExecuteNonQuery(strConection, CommandType.StoredProcedure, "BACKUPDATA", aParams);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public  bool restoreData(string strFileName)
        {
            /*
             * Dungnv   :   11/06/2016
             * Purpose  :   Restore Data by Sql
             */
            string strSql ="";
            strSql = "use master "
                    + " alter database " + strDBName + " set offline with rollback immediate "
                    + " RESTORE DATABASE " + strDBName 
                    + " FROM DISK = '" + strSoureDir +  strFileName + "'";
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

        public DataSet selectListReport(string strModule)
        {
            /*
             *  Dungnv  :   01/01/2015
             *  Purpose :   Lay danh sach Report 
             */

            DataSet ds = new DataSet();
            string strSql = "";
            strSql = " select  ROW_NUMBER() over (order by LSTODR) STT,RPTNAME,[DESC] as DESC_RPT    " +
                     " from  RPTMASTER where MODULE like '%" + strModule + "%'";

            try
            {
                ds = SelectBySql(strSql);
            }
            catch (Exception ex)
            {
                ds = null;
            }

            return ds;

        }
        public ReportObjects ExecProcedureToArr(string strProcedureName)
        {
            /*
             * Dungnv : 22/11/2009 
             */


            SqlParameter[] aParams;
            string strSQL = "";
            DataSet ds = new DataSet();
            ArrayList arrPara = new ArrayList();

            ReportObjects objReport = new ReportObjects();

            try
            {

                aParams = SqlHelperParameterCache.GetSpParameterSet(strConection, strProcedureName);
                for (int i = 0; i < aParams.Length; ++i)
                {
                    //Doc du lieu trong table PARARPT
                    SqlParameter sqlpara = new SqlParameter();
                    sqlpara = (SqlParameter)aParams[i];
                    strSQL = "select PARA_NAME,PARA_CONTENT,PARA_DBTYPE,PARA_TYPE,isnull(SIZES,0) PARA_SIZES ,ISNULL(MASK,'') MASK   from RPTPARA where PARA_NAME='" + sqlpara.ParameterName + "' and LANGUAGE='VN' ";

                    ds = SqlHelper.ExecuteDataset(strConection, CommandType.Text, strSQL);

                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                            {
                                ReportParaObject objStruct = new ReportParaObject();
                                objStruct.PARA_NAME = ds.Tables[0].Rows[j]["PARA_NAME"].ToString().Trim();
                                objStruct.PARA_CONTENT = ds.Tables[0].Rows[j]["PARA_CONTENT"].ToString().Trim();
                                objStruct.PARA_DBTYPE = ds.Tables[0].Rows[j]["PARA_DBTYPE"].ToString().Trim();
                                objStruct.PARA_TYPE = ds.Tables[0].Rows[j]["PARA_TYPE"].ToString().Trim();
                                objStruct.PARA_SIZE = Int32.Parse((ds.Tables[0].Rows[j]["PARA_SIZES"].ToString()));
                                objStruct.MASK = ds.Tables[0].Rows[j]["MASK"].ToString().Trim();
                                arrPara.Add(objStruct);
                            }


                        }
                    }


                }

                objReport.arrLst = arrPara;
                objReport.strReportName = strProcedureName;

            }
            catch (Exception e)
            {
                objReport = null;
            }

            return objReport;
        }
        public DataSet SelectWardDynamic(string strCondition, string strOrderBy)
        {
            /*
             * Dungnv : 10/10/2013
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
                ds = SqlHelper.ExecuteDataset(strConection, "proc_SelectWardDynamic", aParams);
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;

        }
        public DataSet SelectDistrictDynamic(string strCondition, string strOrderBy)
        {
            /*
             * Dungnv : 10/10/2013
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
                ds = SqlHelper.ExecuteDataset(strConection, "proc_SelectDistrictDynamic", aParams);
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;

        }
        public DataSet SelectCountriesDynamic(string strCondition, string strOrderBy)
        {
            /*
             * Dungnv : 10/10/2013
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
                ds = SqlHelper.ExecuteDataset(strConection, "proc_SelectCountriesDynamic", aParams);
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;

        }
        public DataSet SelectMeasurement(string RowId)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "proc_SelectMeasurement", RowId);
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;
        }
        public DataSet SelectMeasurementsDynamic(string strCondition, string strOrderBy)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "proc_SelectMeasurementsDynamic", strCondition, strOrderBy);
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;
        }
        public DataSet SelectReservation(string RowId)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "proc_SelectReservation", RowId);
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;
        }
        public DataSet SelectReservationsDynamic(string strCondition, string strOrderBy)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "proc_SelectReservationsDynamic", strCondition, strOrderBy);
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;
        }
        public DataSet SelectResoure(string RowId)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "proc_SelectResoure", RowId);
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;
        }
        public DataSet SelectResouresDynamic(string strCondition, string strOrderBy)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "proc_SelectResouresDynamic", strCondition, strOrderBy);
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;
        }

        public DataSet SelectCurrentLogin()
        {
            DataSet ds = new DataSet();
            string strSql = "";
            strSql = "select  ROW_NUMBER ( ) over (order by LogIn) STT,UserID,convert(varchar, LogIn, 120) LogIn from LogIn where Status='" + clsCommon.LOGIN_STATUS + "'";
            try
            {
                ds = SelectBySql(strSql);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;
        }

        public DataSet listUserLogIn(DateTime frdate, DateTime toDate)
        {
            /*
             * Dungnv   :   26/05/2016 
             * Purpose  :   Lay danh sach cac UserLogin
             */
            string strSql = "";
            string strFrDate = "";
            string strToDate = "";
            DataSet ds = new DataSet();

                strFrDate = clsCommon.convertDateTimeToString(frdate);
                strToDate = clsCommon.convertDateTimeToString(toDate);
                strSql = " set dateformat dmy ";
                strSql = strSql + " select ROW_NUMBER ( ) over (order by LogIn) STT,UserID,convert(varchar, LogIn, 120) LogIn ,convert(varchar, LogOut, 120) LogOut from LogIn where Login between '" + strFrDate + "' and '" + strToDate + "'";
                try
                {
                    ds = SelectBySql(strSql);
                }
                catch (Exception ex)
                {
                    ds = null;
                }
                return ds;

        }
        public bool excuetNonQuery(string strSql)
        {
            /*
             *  Dungnv  :   02/06/2016 
             *  Purpose :   Execute sql non query 
             */
            int iResult = 0;
            try
            {
                iResult= SqlHelper.ExecuteNonQuery(strConection, CommandType.Text, strSql);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public string[] getListFileBk()
        {
            /*
             * Dungnv   :   11/06/2016
             * Purpose  :   get list file in folder backup
             */

                
            //string sourceDir = @"D:\Downloads";

            string[] files = Directory.GetFiles(strSoureDir);
            return files;
        }

        public ArrayList getListFileInfo()
        {
            /*
             * Dungnv   :   11/06/2016
             * Purpose  :   get list file in folder backup
             */
          
            ArrayList arr = new ArrayList();
            arr.Clear();

            try
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(strSoureDir);
                System.IO.FileInfo[] fileInformations = dir.GetFiles();
                
                if(fileInformations !=null)
                {
                    for(int i=0; i < fileInformations.Length;i++)
                    {
                        FileObject obj = new FileObject();
                        obj.strFileName = fileInformations[i].Name;
                        obj.dtCreated = fileInformations[i].CreationTime;
                        obj.dbSize = fileInformations[i].Length;

                        arr.Add(obj);
                    }
                }

                return arr;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }
        public string getMachine()
        {
            /*
             * Dungnv : 09/01/2017
             * Purpose: Lay gia tri cua may van tay
             * 02: RonaldJack
             */
            return strMachine;
        }
    }
}
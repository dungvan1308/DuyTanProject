using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using ClassLibraryObjects;
using System.Collections;

namespace WebServiceDuyTan.DbObjects
{
    public class ReportDB
    {
        protected string strConection = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
        public DataSet selectReportData(string strCondition, string procedureName)
        {
            SqlParameter[] aParams = new SqlParameter[1];
            aParams[0] = new SqlParameter("@WhereCondition", System.Data.SqlDbType.NVarChar);
            aParams[0].Value = strCondition;

            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, procedureName, aParams);
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;

        }
        private SqlDbType getSQLDBType(string type)
        {
            if (type == "DateTime" || type == "Date")
            {
                return System.Data.SqlDbType.Date;
            }
            else if (type == "VARCHAR")
            {
                return System.Data.SqlDbType.NVarChar;
            }
            else if (type == "CHAR")
            {
                return System.Data.SqlDbType.Char;
            }
            return System.Data.SqlDbType.NVarChar;
        }
        public DataSet selectReportDatas(ReportObjects reportObjects, string procedureName)
        {
            SqlParameter[] aParams = null;
            if (reportObjects.arrLst.Count > 0)
            {
                aParams = new SqlParameter[reportObjects.arrLst.Count];
                ArrayList reportParameters = reportObjects.arrLst;
                for (int i = 0; i < reportParameters.Count; i++)
                {
                    ReportParaObject objStruct = new ReportParaObject();
                    objStruct = (ReportParaObject)(reportParameters[i]);
                    if (objStruct.PARA_DBTYPE.Trim().Equals("DateTime"))
                    {
                        aParams[i] = new SqlParameter(objStruct.PARA_NAME.Trim(), SqlDbType.DateTime);
                        aParams[i].Value = DateTime.ParseExact(objStruct.PARA_VALUE, "dd/MM/yyyy", null);
                    }
                    else
                    {
                        aParams[i] = new SqlParameter(objStruct.PARA_NAME.Trim(), getSQLDBType(objStruct.PARA_DBTYPE));
                        aParams[i].Value = objStruct.PARA_VALUE;
                    }
                }
            }

            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, procedureName.Trim(), aParams);
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;

        }
    }
}
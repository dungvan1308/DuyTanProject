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
 
    
    public class ScheduleDB
    {
        protected string strConection = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;

        public DataSet GetScheduleSystem()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "Schedule_GetSchedule");
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;
        }       

        public DataSet GetScheduleProperty()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(strConection, "Schedule_GetProperty");
            }
            catch (Exception ex)
            {
                return null;
            }

            return ds;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using GYM.ServiceReferenceDuyTan;

namespace GYM.Common
{
   public class ClsCommonDB
    {
        public ArrayList getArrAllCode(string strFieldName, string strTableName)
        {
            /*
             * Dungnv   :   26/10/2014
             * Purpose  :   Lay mang gia tri AllCode      
             */


            DataSet ds = new DataSet();
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();

            ArrayList arr = new ArrayList();
            arr.Clear();

            try
            {
                ds = ws.SelecAllCodeDynamic(strFieldName, strTableName);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ClsParameter.STRUCTINFO objstruct = new ClsParameter.STRUCTINFO();
                            objstruct.KEY = ds.Tables[0].Rows[i]["FieldValue"].ToString();
                            objstruct.VALUE = ds.Tables[0].Rows[i]["Descriptions"].ToString();
                            objstruct.NAME = ds.Tables[0].Rows[i]["FieldName"].ToString();
                            arr.Add(objstruct);
                        }
                    }
                }
                else
                {
                    arr = null;
                }



            }
            catch (Exception ex)
            {
                ds = null;
                arr = null;
            }

            return arr;
        }
        public DataSet getDataSetAllCode(string strFieldName, string strTableName)
        {
            /*
             * Dungnv : 26/10/2012
             */

            DataSet ds = new DataSet();
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            ArrayList arr = new ArrayList();
            arr.Clear();
            try
            {
                ds = ws.SelecAllCodeDynamic(strFieldName, strTableName);

            }
            catch (Exception ex)
            {
                ds = null;
            }

            return ds;
        }
     
    }
}

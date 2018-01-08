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
using WebServiceDuyTan.ServiceReferenceGPS;

namespace WebServiceDuyTan.DbObjects
{
    public class JourneyCarGPS
    {
        private string _UserName = "ndt_service02_V3.1";//"ndt_serviceV3.1";//string.Empty;
        private string _Password = "ndthcm062017";//string.Empty;
        private string _Serial = "NDTVHDD2678686";//string.Empty;
        private string _Version = "V3.1";// string.Empty;
        ServiceSoapClient  _Service = null;


        private void getJourneyCarGPS()
        {
            /*
             * Dungnv   : 07/01/2018
             * Purpose  : Lay du lieu tu Vinh Hien
             */
        
            //Check Login 

            string kq = _Service.CheckLogin(_UserName, _Password, _Serial, _Version);
            string msg = GetLoginMessage(kq);
            if (!string.IsNullOrEmpty(msg))
            {
                return;
            }

            //Lay du lieu GPS
             DataSet ds = _Service.GetVehicleStatusListV3(_UserName, _Password, _Serial, _Version);



        }
          private string GetLoginMessage(string msgId)
        {
            string msg = string.Empty;
            switch (msgId)
            {
                case "-1":
                    msg = "HDD serial is invalid";
                    break;
                case "0":
                    msg = "UserName/Password is invalid";
                    break;
                case "-2":
                    msg = "Version is invalid";
                    break;
                default:
                    break;
            }

            return msg;
        }

    }
    }
}
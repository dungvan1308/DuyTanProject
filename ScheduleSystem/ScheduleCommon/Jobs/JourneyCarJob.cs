using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using log4net;
using ScheduleEntity;
using ServiceStack.Text;
using ScheduleCommon.JourneyCarWS;
using System.Data;
using ScheduleCommon.Object;
using ScheduleDBCore.Service;
using ScheduleDBCore.Enum;

namespace ScheduleCommon.Jobs
{
    public class JourneyCarJob : JobBase
    {
        private static ILog _log = LogManager.GetLogger(typeof(JourneyCarJob));
        private bool flag = false;
        public override void Process()
        {
            try
            {                
                string _UserName = ConfigurationManager.AppSettings["UserName"];
                string _Password = ConfigurationManager.AppSettings["Password"];
                string _Serial = ConfigurationManager.AppSettings["Serial"];
                string _Version = ConfigurationManager.AppSettings["Version"];
                ScheduleCommon.JourneyCarWS.Service _Service = new ScheduleCommon.JourneyCarWS.Service();
                string kq =_Service.CheckLogin(_UserName, _Password, _Serial, _Version);
                string msg = GetLoginMessage(kq);
                if (!string.IsNullOrEmpty(msg))
                {
                    _log.Info(msg);
                }
                else
                {
                    DataSet ds = _Service.GetVehicleStatusListV3(_UserName, _Password, _Serial, _Version);
                    if (ds == null || ds.Tables[0] == null || ds.Tables[0].Rows == null || ds.Tables[0].Rows.Count == 0)
                    {
                        _log.Info("No data");
                    }
                    else
                    {
                        JourneyCarObj journeyCarObj = new JourneyCarObj();
                        JourneyCarSvc JourneyCarSvc = new JourneyCarSvc(1, ConnectionType.ScheduleDB);
                        string importDatetime = DateTime.Now.ToString("yyyyMMddHHmmss");
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            journeyCarObj = new JourneyCarObj();                            
                            journeyCarObj.LicenseCard = row["LicenseCard"].ToString();
                            journeyCarObj.Lat = row["Lat"].ToString();
                            journeyCarObj.Lon = row["Lon"].ToString();
                            journeyCarObj.Heading = row["Heading"].ToString();
                            journeyCarObj.Speed = row["Speed"].ToString();
                            journeyCarObj.MaxSpeed = row["MaxSpeed"].ToString();
                            journeyCarObj.sDateTime = row["sDateTime"].ToString();
                            journeyCarObj.TotalMil = row["TotalMil"].ToString();
                            journeyCarObj.CurrentMil = row["CurrentMil"].ToString();
                            journeyCarObj.TotalTripTime = row["TotalTripTime"].ToString();
                            journeyCarObj.NDT = row["NDT"].ToString();
                            journeyCarObj.EquipmentID = row["EquipmentID"].ToString();
                            journeyCarObj.CompanyName = row["CompanyName"].ToString();
                            journeyCarObj.ConnectedFrom = row["ConnectedFrom"].ToString();
                            journeyCarObj.Duration = row["Duration"].ToString();
                            journeyCarObj.LiveStatus = row["LiveStatus"].ToString();
                            journeyCarObj.sColor = row["sColor"].ToString();
                            journeyCarObj.IDLE = row["IDLE"].ToString();
                            journeyCarObj.Engine = row["Engine"].ToString();
                            journeyCarObj.Door = row["Door"].ToString();
                            journeyCarObj.AreaName = row["AreaName"].ToString();
                            journeyCarObj.Fuel = row["Fuel"].ToString();
                            journeyCarObj.MayLanh = row["MayLanh"].ToString();
                            journeyCarObj.MMC_ID = row["MMC_ID"].ToString();
                            journeyCarObj.CarGroupName = row["CarGroupName"].ToString();
                            journeyCarObj.MaTaiXe = row["MaTaiXe"].ToString();
                            journeyCarObj.FullName = row["FullName"].ToString();
                            journeyCarObj.Phone = row["Phone"].ToString();
                            journeyCarObj.LoaiXe = row["LoaiXe"].ToString();
                            journeyCarObj.HanKiemDinh = row["HanKiemDinh"].ToString();
                            JourneyCarSvc.InsertData(journeyCarObj.LicenseCard, journeyCarObj.Lat, journeyCarObj.Lon,
                                    journeyCarObj.Heading, journeyCarObj.Speed, journeyCarObj.MaxSpeed,
                                    journeyCarObj.sDateTime, journeyCarObj.TotalMil, journeyCarObj.CurrentMil,
                                    journeyCarObj.TotalTripTime, journeyCarObj.NDT, journeyCarObj.EquipmentID,
                                    journeyCarObj.CompanyName, journeyCarObj.ConnectedFrom, journeyCarObj.Duration,
                                    journeyCarObj.LiveStatus, journeyCarObj.sColor, journeyCarObj.IDLE,
                                    journeyCarObj.Engine, journeyCarObj.Door, journeyCarObj.AreaName,
                                    journeyCarObj.Fuel, journeyCarObj.MayLanh, journeyCarObj.MMC_ID,
                                    journeyCarObj.CarGroupName, journeyCarObj.MaTaiXe, journeyCarObj.FullName,
                                    journeyCarObj.Phone, journeyCarObj.LoaiXe, journeyCarObj.HanKiemDinh,
                                    importDatetime);
                        }
                        JourneyCarSvc.Dispose();
                    }                    
                }

            }
            catch (Exception ex)
            {
                _log.Error(string.Format(ex.ToString() + Environment.NewLine + ex.StackTrace));
            }
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

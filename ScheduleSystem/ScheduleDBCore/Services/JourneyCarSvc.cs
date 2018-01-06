using ScheduleDBCore.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDBCore.Service
{
    public class JourneyCarSvc : SQLBaseService
    {
        public JourneyCarSvc(int userId) : base(userId) { }
        public JourneyCarSvc(int userId, ConnectionType connectionType) : base(userId, connectionType) { }
               
        public DataTable InsertData(string LicenseCard, string Lat, string Lon,string Heading,string  Speed, string MaxSpeed, string  sDateTime, string TotalMil,string CurrentMil,string TotalTripTime,string NDT,string EquipmentID,string CompanyName,string ConnectedFrom, string Duration, string LiveStatus, string sColor, string IDLE, string Engine, string Door, string AreaName, string Fuel, string MayLanh, string  MMC_ID, string CarGroupName, string MaTaiXe, string  FullName, string Phone, string LoaiXe, string HanKiemDinh, string importdatetime)
        {
            DataTable dt = new DataTable();            
            ResetValue();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();                
                this._sqlHelper.AddParameter("@Activity", SqlDbType.VarChar, "ImportData");
                this._sqlHelper.AddParameter("@LicenseCard", SqlDbType.VarChar, LicenseCard);
                this._sqlHelper.AddParameter("@Lat", SqlDbType.Decimal, Lat);
                this._sqlHelper.AddParameter("@Lon", SqlDbType.Decimal, Lon);
                this._sqlHelper.AddParameter("@Heading", SqlDbType.Decimal, Heading);
                this._sqlHelper.AddParameter("@Speed", SqlDbType.Decimal, Speed);
                this._sqlHelper.AddParameter("@MaxSpeed", SqlDbType.Decimal, MaxSpeed);
                this._sqlHelper.AddParameter("@sDateTime", SqlDbType.DateTime, sDateTime);
                this._sqlHelper.AddParameter("@TotalMil", SqlDbType.Decimal, TotalMil);
                this._sqlHelper.AddParameter("@CurrentMil", SqlDbType.Decimal, CurrentMil);
                this._sqlHelper.AddParameter("@TotalTripTime", SqlDbType.VarChar, TotalTripTime);
                this._sqlHelper.AddParameter("@NDT", SqlDbType.VarChar, NDT);
                this._sqlHelper.AddParameter("@EquipmentID", SqlDbType.VarChar, EquipmentID);
                this._sqlHelper.AddParameter("@CompanyName", SqlDbType.VarChar, CompanyName);
                this._sqlHelper.AddParameter("@ConnectedFrom", SqlDbType.DateTime, ConnectedFrom);
                this._sqlHelper.AddParameter("@Duration", SqlDbType.VarChar, Duration);
                this._sqlHelper.AddParameter("@LiveStatus", SqlDbType.VarChar, LiveStatus);
                this._sqlHelper.AddParameter("@sColor", SqlDbType.VarChar, sColor);
                this._sqlHelper.AddParameter("@IDLE", SqlDbType.VarChar, IDLE);
                this._sqlHelper.AddParameter("@Engine", SqlDbType.VarChar, Engine);
                this._sqlHelper.AddParameter("@Door", SqlDbType.VarChar, Door);
                this._sqlHelper.AddParameter("@AreaName", SqlDbType.VarChar, AreaName);
                this._sqlHelper.AddParameter("@Fuel", SqlDbType.Int, Fuel);
                this._sqlHelper.AddParameter("@MayLanh", SqlDbType.VarChar, MayLanh);
                this._sqlHelper.AddParameter("@MMC_ID", SqlDbType.VarChar, MMC_ID);
                this._sqlHelper.AddParameter("@CarGroupName", SqlDbType.VarChar, CarGroupName);
                this._sqlHelper.AddParameter("@MaTaiXe", SqlDbType.VarChar, MaTaiXe);
                this._sqlHelper.AddParameter("@FullName", SqlDbType.NVarChar, FullName);
                this._sqlHelper.AddParameter("@Phone", SqlDbType.VarChar, Phone);
                this._sqlHelper.AddParameter("@LoaiXe", SqlDbType.NVarChar, LoaiXe);
                this._sqlHelper.AddParameter("@HanKiemDinh", SqlDbType.DateTime, HanKiemDinh);
                this._sqlHelper.AddParameter("@ImportDatetime", SqlDbType.VarChar, importdatetime);
                dt =this._sqlHelper.ExecuteSPDataTable("usp_JourneyCar");
                
            }
            catch (SystemException exception)
            {                
                BuildErrorMessage(exception , (MethodInfo)MethodBase.GetCurrentMethod());
            }
            return dt;
        }
    }
}

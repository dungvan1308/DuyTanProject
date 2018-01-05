using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryObjects
{
    public class JourneyObject
    {
        private int _journeyID;
        private DateTime _journeyDate;
        private string _vehicleNumber = String.Empty;
        private int _driver;
        private int _employee1;
        private int _employee2;
        private string _startPlace;
        private DateTime _startTimePlan1;
        private DateTime _startTime1;
        private int _deliveryPlace1;
        private DateTime _arrivalTimePlan1;
        private DateTime _arrivalTime1;
        private DateTime _startTimePlan2;
        private DateTime _startTime2;
        private int _deliveryPlace2;
        private DateTime _arrivalTimePlan2;
        private DateTime _arrivalTime2;
        private DateTime _startTimePlan3;
        private DateTime _startTime3;
        private int _deliveryPlace3;
        private DateTime _arrivalTimePlan3;
        private DateTime _arrivalTime3;
        private DateTime _startGoHomePlan;
        private DateTime _startGoHome;
        private DateTime _timeGoHome;
        private string _status = String.Empty;
        private string _gate = String.Empty;
        private string _note = String.Empty;
        private string _createBy = String.Empty;
        private DateTime _createDate;
        private string _modifyBy = String.Empty;
        private DateTime _modifyDate;
        private int _timesUpdate;

        #region Public Properties
        public int JourneyID
        {
            get { return _journeyID; }
            set { _journeyID = value; }
        }

        public DateTime JourneyDate
        {
            get { return _journeyDate; }
            set { _journeyDate = value; }
        }

        public string VehicleNumber
        {
            get { return _vehicleNumber; }
            set { _vehicleNumber = value; }
        }

        public int Driver
        {
            get { return _driver; }
            set { _driver = value; }
        }

        public int Employee1
        {
            get { return _employee1; }
            set { _employee1 = value; }
        }

        public int Employee2
        {
            get { return _employee2; }
            set { _employee2 = value; }
        }

        public string StartPlace
        {
            get { return _startPlace; }
            set { _startPlace = value; }
        }

        public DateTime StartTimePlan1
        {
            get { return _startTimePlan1; }
            set { _startTimePlan1 = value; }
        }

        public DateTime StartTime1
        {
            get { return _startTime1; }
            set { _startTime1 = value; }
        }

        public int DeliveryPlace1
        {
            get { return _deliveryPlace1; }
            set { _deliveryPlace1 = value; }
        }

        public DateTime ArrivalTimePlan1
        {
            get { return _arrivalTimePlan1; }
            set { _arrivalTimePlan1 = value; }
        }

        public DateTime ArrivalTime1
        {
            get { return _arrivalTime1; }
            set { _arrivalTime1 = value; }
        }

        public DateTime StartTimePlan2
        {
            get { return _startTimePlan2; }
            set { _startTimePlan2 = value; }
        }

        public DateTime StartTime2
        {
            get { return _startTime2; }
            set { _startTime2 = value; }
        }

        public int DeliveryPlace2
        {
            get { return _deliveryPlace2; }
            set { _deliveryPlace2 = value; }
        }

        public DateTime ArrivalTimePlan2
        {
            get { return _arrivalTimePlan2; }
            set { _arrivalTimePlan2 = value; }
        }

        public DateTime ArrivalTime2
        {
            get { return _arrivalTime2; }
            set { _arrivalTime2 = value; }
        }

        public DateTime StartTimePlan3
        {
            get { return _startTimePlan3; }
            set { _startTimePlan3 = value; }
        }

        public DateTime StartTime3
        {
            get { return _startTime3; }
            set { _startTime3 = value; }
        }

        public int DeliveryPlace3
        {
            get { return _deliveryPlace3; }
            set { _deliveryPlace3 = value; }
        }

        public DateTime ArrivalTimePlan3
        {
            get { return _arrivalTimePlan3; }
            set { _arrivalTimePlan3 = value; }
        }

        public DateTime ArrivalTime3
        {
            get { return _arrivalTime3; }
            set { _arrivalTime3 = value; }
        }

        public DateTime StartGoHomePlan
        {
            get { return _startGoHomePlan; }
            set { _startGoHomePlan = value; }
        }

        public DateTime StartGoHome
        {
            get { return _startGoHome; }
            set { _startGoHome = value; }
        }

        public DateTime TimeGoHome
        {
            get { return _timeGoHome; }
            set { _timeGoHome = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string Gate
        {
            get { return _gate; }
            set { _gate = value; }
        }

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        public string CreateBy
        {
            get { return _createBy; }
            set { _createBy = value; }
        }

        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        public string ModifyBy
        {
            get { return _modifyBy; }
            set { _modifyBy = value; }
        }

        public DateTime ModifyDate
        {
            get { return _modifyDate; }
            set { _modifyDate = value; }
        }

        public int TimesUpdate
        {
            get { return _timesUpdate; }
            set { _timesUpdate = value; }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryObjects
{
    public class PlaceObject
    {
        private int _pLaceID;
        private string _name = String.Empty;
        private double _gpsX;
        private double _gpsY;
        private string _districtID = String.Empty;
        private string _cityID = String.Empty;
        private string _address = String.Empty;
        private double _distanceDuyTan;
        //private TimeSpan _timeDuyTan;
        private double _timeDuyTan;
        private bool _ofDuyTan;
        private string _createBy = String.Empty;
        private DateTime _createDate;
        private string _modifyBy = String.Empty;
        private DateTime _modifyDate;
        



        #region Public Properties
        public int PlaceID
        {
            get { return _pLaceID; }
            set { _pLaceID = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double GpsX
        {
            get { return _gpsX; }
            set { _gpsX = value; }
        }

        public double GpsY
        {
            get { return _gpsY; }
            set { _gpsY = value; }
        }

        public string DistrictID
        {
            get { return _districtID; }
            set { _districtID = value; }
        }

        public string CityID
        {
            get { return _cityID; }
            set { _cityID = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public double DistanceDuyTan
        {
            get { return _distanceDuyTan; }
            set { _distanceDuyTan = value; }
        }

        public double TimeDuyTan
        {
            get { return _timeDuyTan; }
            set { _timeDuyTan = value; }
        }

        public bool OfDuyTan
        {
            get { return _ofDuyTan; }
            set { _ofDuyTan = value; }
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
        #endregion

    }
}

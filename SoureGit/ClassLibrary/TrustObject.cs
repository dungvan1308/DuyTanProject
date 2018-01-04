using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryObjects
{
    public class TrustObject
    {
        private int _trustID;
        private string _trustName = String.Empty;
        private string _vehicleNumber = String.Empty;
        private string _type = String.Empty;
        private DateTime _dateOfPurchase;
        private decimal _total;
        private int _seatingNumber;
        private string _color = String.Empty;
        private decimal _capicity;
        private DateTime _expireDate;
        private string _groupTrust = String.Empty;
      
        private string _createBy = String.Empty;
        private DateTime _createDate;
        private string _modifyBy = String.Empty;
        private DateTime _modifyDate;

        #region Public Properties
        public int TrustID
        {
            get { return _trustID; }
            set { _trustID = value; }
        }

        public string TrustName
        {
            get { return _trustName; }
            set { _trustName = value; }
        }

        public string VehicleNumber
        {
            get { return _vehicleNumber; }
            set { _vehicleNumber = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public DateTime DateOfPurchase
        {
            get { return _dateOfPurchase; }
            set { _dateOfPurchase = value; }
        }

        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public int SeatingNumber
        {
            get { return _seatingNumber; }
            set { _seatingNumber = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public decimal Capicity
        {
            get { return _capicity; }
            set { _capicity = value; }
        }

        public DateTime ExpireDate
        {
            get { return _expireDate; }
            set { _expireDate = value; }
        }

        public string GroupTrust
        {
            get { return _groupTrust; }
            set { _groupTrust = value; }
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

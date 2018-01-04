using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;


namespace ClassLibraryObjects
{
    public class EmployeeObject
    {
        private int _id;
        private string _name = String.Empty;
        private DateTime _birthDay;
        private string _birth_Place = String.Empty;
        private string _identitycard = String.Empty;
        private DateTime _identitycard_DateIssue;
        private string _identitycard_PlaceIssue = String.Empty;
        private string _gender = String.Empty;
        private string _maritalStatus = String.Empty;
        private string _address = String.Empty;
        private string _cityId = String.Empty;
        private string _phone = String.Empty;
        private string _mobile = String.Empty;
        private string _email = String.Empty;
        private string _education = String.Empty;
        private string _position = String.Empty;
        private DateTime _dateStartWork;
        private string _type = String.Empty;
        private string _licenseType = String.Empty;
        private string _status = String.Empty;
        private string _userID = String.Empty;
        private string _createBy = String.Empty;
        private DateTime _createDate;
        private string _modifyBy = String.Empty;
        private DateTime _modifyDate;


        #region Public Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DateTime BirthDay
        {
            get { return _birthDay; }
            set { _birthDay = value; }
        }

        public string Birth_Place
        {
            get { return _birth_Place; }
            set { _birth_Place = value; }
        }

        public string Identitycard
        {
            get { return _identitycard; }
            set { _identitycard = value; }
        }

        public DateTime Identitycard_DateIssue
        {
            get { return _identitycard_DateIssue; }
            set { _identitycard_DateIssue = value; }
        }

        public string Identitycard_PlaceIssue
        {
            get { return _identitycard_PlaceIssue; }
            set { _identitycard_PlaceIssue = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string MaritalStatus
        {
            get { return _maritalStatus; }
            set { _maritalStatus = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string CityId
        {
            get { return _cityId; }
            set { _cityId = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Education
        {
            get { return _education; }
            set { _education = value; }
        }

        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public DateTime DateStartWork
        {
            get { return _dateStartWork; }
            set { _dateStartWork = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string LicenseType
        {
            get { return _licenseType; }
            set { _licenseType = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
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

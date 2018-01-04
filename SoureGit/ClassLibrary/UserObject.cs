using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryObjects
{
    public class UserObject
    {
        private string _uSerID = String.Empty;
        private string _uSERNAME = String.Empty;
        private string _fULLNAME = String.Empty;
        private string _gROUPID = String.Empty;
        private string _employeeID = String.Empty;
        private string _pASSWORD = String.Empty;
        private bool _iSCHANGEPASS;
        private bool _lOCK;
        private string _cREATEBY = String.Empty;
        private DateTime _cREATEDATE;
        private string _mODIFIEDBY = String.Empty;
        private DateTime _mODIFIEDDATE;

        #region Public Properties
        public string USERID
        {
            get { return _uSerID; }
            set { _uSerID = value; }
        }

        public string USERNAME
        {
            get { return _uSERNAME; }
            set { _uSERNAME = value; }
        }

        public string FULLNAME
        {
            get { return _fULLNAME; }
            set { _fULLNAME = value; }
        }

        public string GROUPID
        {
            get { return _gROUPID; }
            set { _gROUPID = value; }
        }

        public string EMPLOYEEID
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }

        public string PASSWORD
        {
            get { return _pASSWORD; }
            set { _pASSWORD = value; }
        }

        public bool ISCHANGEPASS
        {
            get { return _iSCHANGEPASS; }
            set { _iSCHANGEPASS = value; }
        }

        public bool LOCK
        {
            get { return _lOCK; }
            set { _lOCK = value; }
        }

        public string CREATEBY
        {
            get { return _cREATEBY; }
            set { _cREATEBY = value; }
        }

        public DateTime CREATEDATE
        {
            get { return _cREATEDATE; }
            set { _cREATEDATE = value; }
        }

        public string MODIFIEDBY
        {
            get { return _mODIFIEDBY; }
            set { _mODIFIEDBY = value; }
        }

        public DateTime MODIFIEDDATE
        {
            get { return _mODIFIEDDATE; }
            set { _mODIFIEDDATE = value; }
        }
        #endregion
    }
}

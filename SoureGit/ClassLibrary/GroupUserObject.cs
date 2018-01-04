using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryObjects
{
    public class GroupUserObject
    {
        private string _gROUPID = String.Empty;
        private string _gROUPNAME = String.Empty;
        private string _nOTE = String.Empty;
        private string _cREATEBY = String.Empty;
        private DateTime _cREATEDATE;
        private string _mODIFIEDBY = String.Empty;
        private DateTime _mODIFIEDDATE;

        #region Public Properties
        public string GROUPID
        {
            get { return _gROUPID; }
            set { _gROUPID = value; }
        }

        public string GROUPNAME
        {
            get { return _gROUPNAME; }
            set { _gROUPNAME = value; }
        }

        public string NOTE
        {
            get { return _nOTE; }
            set { _nOTE = value; }
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

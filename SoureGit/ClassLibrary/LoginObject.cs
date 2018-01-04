using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryObjects
{
    public class LoginObject
    {
        private string _uSERID = String.Empty;
        private DateTime _lOGIN;
        private DateTime _lOGOUT;
        private string _sTATUS = String.Empty;

        #region Public Properties

        public string USERID
        {
            get { return _uSERID; }
            set { _uSERID = value; }
        }

        public DateTime LOGIN
        {
            get { return _lOGIN; }
            set { _lOGIN = value; }
        }

        public DateTime LOGOUT
        {
            get { return _lOGOUT; }
            set { _lOGOUT = value; }
        }

        public string STATUS
        {
            get { return _sTATUS; }
            set { _sTATUS = value; }
        }
        #endregion
    }
}

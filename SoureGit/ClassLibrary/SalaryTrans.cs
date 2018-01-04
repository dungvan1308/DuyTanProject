using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryObjects
{
   public class SalaryTrans
    {
        private string _eMPLOYEEID = String.Empty;
        private string _eMPLOYEENAME = String.Empty;
        private string _tERM = string.Empty;
        private int _sALARYID;
        private decimal _aMOUNT;
        private DateTime _cREATEDATE;
        private string _uSERID = String.Empty;
        private string _nOTE = String.Empty;

        public int SALARYID
        {
            get { return _sALARYID; }
            set { _sALARYID = value; }
        }

        public string EMPLOYEEID
        {
            get { return _eMPLOYEEID; }
            set { _eMPLOYEEID = value; }
        }

        public string EMPLOYEENAME
        {
            get { return _eMPLOYEENAME; }
            set { _eMPLOYEENAME = value; }
        }

        public decimal AMOUNT
        {
            get { return _aMOUNT; }
            set { _aMOUNT = value; }
        }

        public DateTime CREATEDATE
        {
            get { return _cREATEDATE; }
            set { _cREATEDATE = value; }
        }

        public string USERID
        {
            get { return _uSERID; }
            set { _uSERID = value; }
        }

        public string TERM
        {
            get { return _tERM; }
            set { _tERM = value; }
        }

        public string NOTE
        {
            get { return _nOTE; }
            set { _nOTE = value; }
        }
    }
}

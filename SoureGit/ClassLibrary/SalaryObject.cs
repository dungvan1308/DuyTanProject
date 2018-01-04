using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryObjects
{
    public class SalaryObject
    {
        private int _sALARYID;
        private string _eMPLOYEEID = String.Empty;
        private decimal _aMOUNT;
        private DateTime _dATEEFFECT;
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
        public decimal AMOUNT
        {
            get { return _aMOUNT; }
            set { _aMOUNT = value; }
        }
        public DateTime DATEEFFECT
        {
            get { return _dATEEFFECT; }
            set { _dATEEFFECT = value; }
        }

        public string NOTE
        {
            get { return _nOTE; }
            set { _nOTE = value; }
        }
    }
}

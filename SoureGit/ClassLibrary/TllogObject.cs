using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ClassLibraryObjects
{
    public class TllogObject
    {
        public string _tXNUM = String.Empty;
        public DateTime  _tXDATE;
        public string _tLTXCD = String.Empty;
        public string _tLTXDESC = String.Empty;
        public string _uSERID = String.Empty;
        public double _aMOUNT;
        public string _cHARID = String.Empty;
        public string _mODULE = String.Empty;
        public string _dELTD = String.Empty;

        public ArrayList arrField;

        public string TXNUM
        {
            get { return _tXNUM; }
            set { _tXNUM = value; }
        }

            public DateTime TXDATE
        {
            get { return _tXDATE; }
            set { _tXDATE = value; }
        }
            public string TLTXCD
        {
            get { return _tLTXCD; }
            set { _tLTXCD = value; }
        }
            public string TLTXDESC
        {
            get { return _tLTXDESC; }
            set { _tLTXDESC = value; }
        }
            public string USERID
        {
            get { return _uSERID; }
            set { _uSERID = value; }
        }
            public Double AMOUNT
        {
            get { return _aMOUNT; }
            set { _aMOUNT = value; }
        }
            public string CHARID
        {
            get { return _cHARID; }
            set { _cHARID = value; }
        }
            public string MODULE
        {
            get { return _mODULE; }
            set { _mODULE = value; }
        }
            public string DELTD
        {
            get { return _dELTD; }
            set { _mODULE = value; }
        }




    }
}

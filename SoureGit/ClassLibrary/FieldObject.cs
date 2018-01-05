using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryObjects
{
    public class FieldObject
    {
        public string _fIELDID = String.Empty;
        public string _fIELDNAME= String.Empty;
        public string _tABLENAME= String.Empty;
        public string _cAPTION= String.Empty;
        public string _dATATYPE= String.Empty;
        public string _cONTROL= String.Empty;
        public int _sIZE;
        public string _mASK = String.Empty;
        public bool _eNABLE ;
        public int _oRDERBY;
        public string _vAlues = String.Empty;
        public string _mAINKEY = String.Empty;
        public string _tYPE = String.Empty;
        public string _mODULE = String.Empty;
        public int _gROUPFIELD;




        public string FIELDID
        {
            get { return _fIELDID; }
            set { _fIELDID = value; }
        }

        public string FIELDNAME
        {
            get { return _fIELDNAME; }
            set { _fIELDNAME = value; }
        }
        public string TABLENAME
        {
            get { return _tABLENAME; }
            set { _tABLENAME = value; }
        }
        public string CAPTION
        {
            get { return _cAPTION; }
            set { _cAPTION = value; }
        }
        public string DATATYPE
        {
            get { return _dATATYPE; }
            set { _dATATYPE = value; }
        }
 
        public string CONTROL
        {
            get { return _cONTROL; }
            set { _cONTROL = value; }
        }

        public int SIZE
        {
            get { return _sIZE; }
            set { _sIZE = value; }
        }

        public string MASK
        {
            get { return _mASK; }
            set { _mASK = value; }
        }

        public bool ENABLE
        {
            get { return _eNABLE; }
            set { _eNABLE = value; }
        }

        public int ORDERBY
        {
            get { return _oRDERBY; }
            set { _oRDERBY = value; }
        }

        public string VALUES
        {
            get { return _vAlues; }
            set { _vAlues = value; }
        }

        public string MAINKEY
        {
            get { return _mAINKEY; }
            set { _mAINKEY = value; }
        }

        public string TYPE
        {
            get { return _tYPE; }
            set { _tYPE = value; }
        }

        public string MODULE
        {
            get { return _mODULE; }
            set { _mODULE = value; }
        }

        public int GROUPFIELD
        {
            get { return _gROUPFIELD; }
            set { _gROUPFIELD = value; }
        }

        
    }
}

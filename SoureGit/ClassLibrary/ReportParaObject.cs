using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryObjects
{
    public class ReportParaObject
    {
        private string _pARA_NAME = String.Empty;       //  Ten bien 
        private string _pARA_CONTENT = String.Empty;    //  Dien giai 
        private string _pARA_DBTYPE = String.Empty;     //  Kieu DataBase 
        private string _pARA_TYPE = String.Empty;       //  Kieu Control 
        private string _pARA_VALUE = String.Empty;
        private string _mASK = String.Empty;            //  Format 
        private int _pARA_SIZE = 0;

        public string PARA_NAME
        {
            get { return _pARA_NAME; }
            set { _pARA_NAME = value; }
        }

        public string PARA_CONTENT
        {
            get { return _pARA_CONTENT; }
            set { _pARA_CONTENT = value; }
        }

        public string PARA_DBTYPE
        {
            get { return _pARA_DBTYPE; }
            set { _pARA_DBTYPE = value; }
        }

        public string PARA_TYPE
        {
            get { return _pARA_TYPE; }
            set { _pARA_TYPE = value; }
        }

        public string PARA_VALUE
        {
            get { return _pARA_VALUE; }
            set { _pARA_VALUE = value; }
        }

        public string MASK
        {
            get { return _mASK; }
            set { _mASK = value; }
        }

        public int PARA_SIZE
        {
            get { return _pARA_SIZE; }
            set { _pARA_SIZE = value; }
        }

    }
}

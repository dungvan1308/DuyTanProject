using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryObjects
{
    public class MenuObject
    {
        private string _uMenuID = String.Empty;
        private string _uMenuName = String.Empty;
        private string _uParantID = String.Empty;
        private string _uNote = string.Empty;
        private int _uMENUORDER = 0;
        private string _uAu = string.Empty;

        #region Public Properties

        public string MENUID
        {
            get { return _uMenuID; }
            set { _uMenuID = value; }
        }

        public string MENUNAME
        {
            get { return _uMenuName; }
            set { _uMenuName = value; }
        }

        public string PARENTID
        {
            get { return _uParantID; }
            set { _uParantID = value; }
        }

        public string NOTE
        {
            get { return _uNote; }
            set { _uNote = value; }
        }

        public int MENUORDER
        {
            get { return _uMENUORDER; }
            set { _uMENUORDER = value; }
        }

        public string AU
        {
            get { return _uAu; }
            set { _uAu = value; }
        }

        #endregion
    }
}

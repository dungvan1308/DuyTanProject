using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryObjects
{
    public class AuthorizeMenuObject
    {
        private string _uMenuID = String.Empty;
        private string _uGroupID = String.Empty;

        public string MENUID
        {
            get { return _uMenuID; }
            set { _uMenuID = value; }
        }

        public string GROUPID
        {
            get { return _uGroupID; }
            set { _uGroupID = value; }
        }
    }
}

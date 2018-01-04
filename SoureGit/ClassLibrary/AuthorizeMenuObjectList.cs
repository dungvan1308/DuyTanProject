using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ClassLibraryObjects
{
    public class AuthorizeMenuObjectList
    {
        private string _uUserGroupId = string.Empty;
        public ArrayList menuIdList = new ArrayList();

        public string USERGROUPID
        {
            get { return _uUserGroupId; }
            set { _uUserGroupId = value; }
        }

        public void addMenuItemID(String menuId)
        {
            menuIdList.Add(menuId);
        }

        public bool contains(String menuId)
        {
            if (menuIdList.Contains(menuId))
            {
                return true;
            }
            return false;
        }
    }
}

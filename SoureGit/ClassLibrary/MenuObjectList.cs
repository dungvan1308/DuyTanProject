using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ClassLibraryObjects
{
    public class MenuObjectList
    {
        public ArrayList list = new ArrayList();
        public void add(MenuObject menuObject)
        {
            list.Add(menuObject);
        }

        public void remove(MenuObject menuObject)
        {
            list.Remove(menuObject);
        }

        public void add(ArrayList list)
        {
            this.list = list;
        }
    }
}

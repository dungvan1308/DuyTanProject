using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryObjects
{
    public class ResoureObject
    {

        private int _id;
		private string _resourceID = String.Empty;
		private string _name = String.Empty;
		private string _resourceType = String.Empty;

        public ResoureObject()
		{
		}

        #region Public Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string ResourceID
        {
            get { return _resourceID; }
            set { _resourceID = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string ResourceType
        {
            get { return _resourceType; }
            set { _resourceType = value; }
        }
        #endregion
		

    }
}

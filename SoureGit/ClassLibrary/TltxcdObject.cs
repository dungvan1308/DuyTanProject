using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ClassLibraryObjects
{
    public class TltxcdObject
    {
       public string  _tLTXCD = String.Empty;
       public string _tLTXDESC = String.Empty;
       public string _mODULE = String.Empty;
       public string _tYPE = String.Empty;
       public string _vISIBLE = String.Empty;

       public ArrayList arrFields = new ArrayList();
        

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

       public string MODULE
       {
           get { return _mODULE; }
           set { _mODULE = value; }
       }

       public string TYPE
       {
           get { return _tYPE; }
           set { _tYPE = value; }
       }

       public string VISIBLE
       {
           get { return _vISIBLE; }
           set { _vISIBLE = value; }
       }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace DOCXM
{
    class PySimilar
    {
        public String FileName = null;
        public Hashtable Similars = null;//<Key KeyPair<File ratio>>
        public PySimilar()
        {
            FileName = "";
            Similars = new Hashtable();
        }
    }
    //class SimilarPart
    //{
    //    String KeyName;
    //    String Content;
    //    String Ratio;
    //}
}

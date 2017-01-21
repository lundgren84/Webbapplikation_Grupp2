using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_layer.Tables
{
   public class tbl_Taunt
    {
        public Guid id { get; set; }
        public string winWord1 { get; set; }
        public string winWord2 { get; set; }
        public string winWord3 { get; set; }

        public string commonWord1 { get; set; }
        public string commonWord2 { get; set; }
        public string commonWord3 { get; set; }

        public string looseWord1 { get; set; }
        public string looseWord2 { get; set; }
        public string looseWord3 { get; set; }
        public Guid? AccountRefID { get; set; }
       
    }
}

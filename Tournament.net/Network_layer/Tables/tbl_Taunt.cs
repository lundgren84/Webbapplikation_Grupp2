using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public tbl_Taunt()
        {
            id = Guid.NewGuid();
            winWord1 = "Im the Winner!";
            winWord2 = "How came first? ME!!";
            winWord3 = "There can be only ONE!";
            commonWord1 = "im ok";
            commonWord2 = "Not best but not last!";
            commonWord3 = "Mr decent";
            looseWord1 = "Cryy..";
            looseWord2 = "Hate you all!";
            looseWord3 = "Im just crap!";
        }


    }
}

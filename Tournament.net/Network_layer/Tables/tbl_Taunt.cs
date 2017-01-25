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
        public tbl_Taunt() {
            this.id = Guid.NewGuid();
            this.winWord1 = "Im the Winner!";
            this.winWord2 = "How came first? ME!!";
            this.winWord3 = "There can be only ONE!";
            this.commonWord1 = "im ok";
            this.commonWord2 = "Not best but not last!";
            this.commonWord3 = "Mr decent";
            this.looseWord1 = "Cryy..";
            this.looseWord2 = "Hate you all!";
            this.looseWord3 = "Im just crap!";
        }
        public tbl_Taunt(Guid AccountRefID)
        {
            this.AccountRefID = AccountRefID;
            this.id = Guid.NewGuid();
            this.winWord1 = "Im the Winner!";
            this.winWord2 = "How came first? ME!!";
            this.winWord3 = "There can be only ONE!";
            this.commonWord1 = "im ok";
            this.commonWord2 = "Not best but not last!";
            this.commonWord3 = "Mr decent";
            this.looseWord1 = "Cryy..";
            this.looseWord2 = "Hate you all!";
            this.looseWord3 = "Im just crap!";
        }


    }
}

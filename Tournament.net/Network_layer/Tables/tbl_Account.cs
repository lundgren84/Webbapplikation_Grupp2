using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_layer.Tables
{
   public class tbl_Account
    {
        public Guid id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ImgURL { get; set; }
        public virtual ICollection<string> WinWords { get; set; }
        public virtual ICollection<string> CommonWords { get; set; }
        public virtual ICollection<string> LooseWords { get; set; }
    }
}

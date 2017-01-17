using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tournament.net.Models
{
    public class AccountViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ImageURL { get; set; }
        public List<string> WinWord { get; set; }
        public List<string> CommonWord { get; set; }
        public List<string> LooseWord { get; set; }
    }
}
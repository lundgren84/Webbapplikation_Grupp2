using Business_layer.ExtensionMethods.Mapping;
using Network_layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.BusinessObjects
{
   public class Account_BData
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ImgURL { get; set; }
        public List<string> WinWords { get; set; }
        public List<string> CommonWords { get; set; }
        public List<string> LooseWords { get; set; }

        public static void CreateAccount(Account_BData businessData)
        {
            // Map to Entity and send to Connection layer
            AccountRepository.CreateOrUpdate(businessData.ToEntity());
        }
    }
}

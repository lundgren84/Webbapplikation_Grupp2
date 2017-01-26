using Business_layer.ExtensionMethods.Mapping;
using Network_layer.Repositories;
using Network_layer.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.BusinessObjects
{
    public class Account_BData
    {
        public Guid id;
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ImgURL { get; set; }

        public static object GetAccount()
        {
            throw new NotImplementedException();
        }

        public static Account_BData GetAccount(string userName)
        {
            var entity = AccountRepository.GetAccount(userName);
            var BusinessData = entity.ToBusinessData();
            return BusinessData;
        }
    }
}

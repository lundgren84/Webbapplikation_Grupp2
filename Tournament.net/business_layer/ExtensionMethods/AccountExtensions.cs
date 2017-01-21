using Business_layer.BusinessObjects;
using Business_layer.ExtensionMethods.Mapping;
using Network_layer.Repositories;
using Network_layer.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.ExtensionMethods
{
    public static class AccountExtensions
    {
        
        public static void CreateNew(this Account_BData BData)
        {
            BData = AddDefaultValuesToNewAccount(BData);
            // Map to Entity and send to Connection layer
            AccountRepository.CreateOrUpdate(BData.ToEntity());
        }
        private static Account_BData AddDefaultValuesToNewAccount(Account_BData NewAccount)
        {
            NewAccount.WinWords = new List<string>() { "WinWord1", "WinWord2", "WinWord3" };
            NewAccount.CommonWords = new List<string>() { "CommonWord1", "CommonWord2", "CommonWord3" };
            NewAccount.LooseWords = new List<string>() { "LooseWord1", "LooseWord2", "LooseWord3" };
            NewAccount.ImgURL = "/Items/Images/Default/1.jpg";
            return NewAccount;
        }
    }
    // Add default values


}


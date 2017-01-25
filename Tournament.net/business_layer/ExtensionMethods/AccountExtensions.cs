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
            if (AccountRepository.CreateOrUpdate(BData.ToEntity()))
            {
                //Send mail
            }            
        }
        public static bool SaveChanges(this Account_BData BData)
        {
            var Entity = AccountRepository.GetAccount(BData.UserName);
            var entityToSave = BData.ToEntity();
            entityToSave.id = Entity.id;
            entityToSave.Taunts = TauntRepository.GetTaunt(Entity.id);
            var saved = false;
            if (AccountRepository.CreateOrUpdate(entityToSave))
            {
                saved = true;
            }
            return saved;
        }

        private static Account_BData AddDefaultValuesToNewAccount(Account_BData NewAccount)
        {
            Random random = new Random();
            var imgNr = "";
            var rndNr = random.Next(1, 14);
            if (rndNr < 10)
            {
                imgNr = "0" + rndNr.ToString();
            }
            else { imgNr = rndNr.ToString(); }
            NewAccount.WinWords = new List<string>() { "WinWord1", "WinWord2", "WinWord3" };
            NewAccount.CommonWords = new List<string>() { "CommonWord1", "CommonWord2", "CommonWord3" };
            NewAccount.LooseWords = new List<string>() { "LooseWord1", "LooseWord2", "LooseWord3" };
            NewAccount.ImgURL = "/Items/Avatars/M"+ imgNr + ".png";
            return NewAccount;
        }
    }
    // Add default values


}


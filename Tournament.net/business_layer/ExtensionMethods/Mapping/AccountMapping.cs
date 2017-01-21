using Business_layer.BusinessObjects;
using Network_layer.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.ExtensionMethods.Mapping
{
    public static class AccountMapping
    {
        public static tbl_Account ToEntity(this Account_BData BData)
        {
            var Entity = new tbl_Account()
            {
                id = BData.id,
                UserName = BData.UserName,
                Email = BData.Email,
                ImgURL = BData.ImgURL,
                WinWords = BData.WinWords,
                CommonWords = BData.CommonWords,
                LooseWords = BData.LooseWords
                // Mapp to entity
            };
            return Entity;
        }
        public static Account_BData ToBusinessData(this tbl_Account Entity)
        {
            var BusinessData = new Account_BData()
            {
                id = Entity.id,
                UserName = Entity.UserName,
                Email = Entity.Email,
                ImgURL = Entity.ImgURL,
                WinWords = (List<string>)Entity.WinWords,
                CommonWords = (List<string>)Entity.CommonWords,
                LooseWords = (List<string>)Entity.LooseWords

            };
            return BusinessData;
        }
    }
}

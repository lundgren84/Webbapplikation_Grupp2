using Business_layer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournament.net.Models;

namespace Tournament.net.ExtensionMethods.Mapping
{
    public static class AccountMapping
    {
        public static Account_BData ToBusinessData(this AccountViewModel Model)
        {
            var busniessData = new Account_BData()
            {
              UserName = Model.UserName,
              Email = Model.Email,
              ImgURL = Model.ImgURL,
              CommonWords= Model.CommonWords,
              WinWords = Model.WinWords,
              LooseWords = Model.LooseWords
            };
            return busniessData;
        }
    }
}
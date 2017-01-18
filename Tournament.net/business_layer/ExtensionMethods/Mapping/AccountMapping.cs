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
                // Mapp to entity
            };
            return Entity;
        }
    }
}

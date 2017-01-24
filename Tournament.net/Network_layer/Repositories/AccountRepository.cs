using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Network_layer.Tables;
using System.Data.Entity.Migrations;

namespace Network_layer.Repositories
{
    public class AccountRepository
    {

        public static bool CreateOrUpdate(tbl_Account Entity)
        {
           try { 
                using (var ctx = new TournamentDbContext())
                {
                    var EntityToCreateOrUpdate = ctx.Accounts.FirstOrDefault(x => x.id == Entity.id)
                        ?? new tbl_Account() { id = Guid.NewGuid() };

                    EntityToCreateOrUpdate.UserName = Entity.UserName;
                    EntityToCreateOrUpdate.Email = Entity.Email;
                    EntityToCreateOrUpdate.ImgURL = Entity.ImgURL;
                    EntityToCreateOrUpdate.Taunts = Entity.Taunts;          

                    ctx.Accounts.AddOrUpdate(EntityToCreateOrUpdate);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }


        }
        public static tbl_Account GetAccount(string userName)
        {
            using (var ctx = new TournamentDbContext())
            {
                var Entity = ctx.Accounts.FirstOrDefault(x => x.UserName == userName);
                return Entity;
            }
        }

    }
}

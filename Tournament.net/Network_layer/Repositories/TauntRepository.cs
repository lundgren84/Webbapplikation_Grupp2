using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Network_layer.Tables;
using System.Data.Entity.Migrations;

namespace Network_layer.Repositories
{
    public class TauntRepository
    {
        public static tbl_Taunt GetTaunt(Guid id)
        {
            using (var ctx = new TournamentDbContext())
            {
                var Entity = ctx.Taunts.FirstOrDefault(x => x.AccountRefID == id)
                    ?? new tbl_Taunt()
                    {
                        id = Guid.NewGuid(),
                        AccountRefID = id,
                        winWord1 = "Im the Winner!",
                        winWord2 = "How came first? ME!!",
                        winWord3 = "There can be only ONE!",
                        commonWord1 = "im ok",
                        commonWord2 = "Not best but not last!",
                        commonWord3 = "Mr decent",
                        looseWord1 = "Cryy..",
                        looseWord2 = "Hate you all!",
                        looseWord3 = "Im just crap!"
                    };
                ctx.Taunts.AddOrUpdate(Entity);
                ctx.SaveChanges();
                return Entity;
            };
        }

        public static tbl_Taunt AddOrUpdate()
        {

        }
        public static List<string> GetWords(string type, Guid accountId)
        {
            var result = new List<string>();
            var taunts = GetTaunt(accountId);
            if (type == "win")
            { result = (new List<string>() { taunts.winWord1, taunts.winWord2, taunts.winWord3 }); }
            else if (type == "common")
            { result = (new List<string>() { taunts.commonWord1, taunts.commonWord2, taunts.commonWord3 }); }
            else if (type == "loose")
            { result = (new List<string>() { taunts.looseWord1, taunts.looseWord2, taunts.looseWord3 }); }
            return result;
        }
    }
}

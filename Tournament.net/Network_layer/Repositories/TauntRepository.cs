using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Network_layer.Tables;

namespace Network_layer.Repositories
{
    public class TauntRepository
    {
        public static tbl_Taunt GetTaunt(Guid id)
        {
            using (var ctx = new TournamentDbContext())
            {
                var Entity = ctx.Taunts.FirstOrDefault(x => x.id == id)
                    ?? new tbl_Taunt()
                    {
                        id = Guid.NewGuid(),
                        AccountRefID = id,
                        winWord1 = "win1",
                        winWord2 = "win2",
                        winWord3 = "win3",
                        commonWord1 = "com1",
                        commonWord2 = "com2",
                        commonWord3 = "com3",
                        looseWord1 = "los1",
                        looseWord2 = "los2",
                        looseWord3 = "los3"
                    };
                return Entity;
            };
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

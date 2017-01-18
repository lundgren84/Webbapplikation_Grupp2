using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_layer
{
    public class TournamentDbContext : DbContext
    {
        public TournamentDbContext():base("name=Tournament_DataBase")
        {

        }
    }
}

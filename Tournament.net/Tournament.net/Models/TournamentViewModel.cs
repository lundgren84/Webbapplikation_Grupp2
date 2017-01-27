using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tournament.net.Models
{
    public class TournamentViewModel
    {
        public TournamentTypeViewModel Type { get; set; }
        public List<AccountViewModel> Players { get; set; }
        public int NumbersOfPlayers { get; set; }
    }
    public class TournamentTypeViewModel
    {

    }
}
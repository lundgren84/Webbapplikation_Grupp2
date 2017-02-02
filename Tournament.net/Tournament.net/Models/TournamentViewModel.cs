using Business_layer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tournament.net.Models
{
   
    public class TournamentViewModel
    {
        public TournamentType Type { get; set; }
        public List<AccountInTournamentViewModel> Players { get; set; }
        public int NumbersOfPlayers { get; set; }
        public bool OddPlayers { get; set; }
        public List<Round> Rounds { get; set; }
    }
    public class Round
    {
        public int NumberPlayers { get; set; }

    }
  
  
}
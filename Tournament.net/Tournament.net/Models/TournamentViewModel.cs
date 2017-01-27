using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tournament.net.Models
{
    public enum TournamentType
    {
        Highscore,Tournament
    }
    public class TournamentViewModel
    {
        public TournamentType Type { get; set; }
        public List<AccountInTournamentViewModel> Players { get; set; }
        public int NumbersOfPlayers { get; set; }
    }
    public class HighscoreViewModel
    {
        public TournamentType Type { get; set; }
        public List<AccountInHighscoreViewModel> Players { get; set; }
        public int NumbersOfPlayers { get; set; }
    }
  
  
}
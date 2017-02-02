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
        public int PlayersInRound { get; set; }
        public List<AccountInTournamentViewModel> Players { get; set; }
        public Round(int PlayersInRound)
        {
            this.PlayersInRound = PlayersInRound;
            this.Players = GetPlayers(PlayersInRound);
        }
        private List<AccountInTournamentViewModel> GetPlayers(int PlayersInRound)
        {
            var result = new List<AccountInTournamentViewModel>();
            for (int i = 0; i < PlayersInRound; i++)
            {
                result.Add(new AccountInTournamentViewModel() { UserName ="Unknown", ImgURL ="/Items/Images/Buttons/questionmark 100px.png" });
            }

            return result;
        }
    }


}
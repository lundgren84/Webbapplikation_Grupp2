using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.BusinessObjects
{
    public enum TournamentType
    {
        Highscore, Tournament
    }
    public class Tournament_BData
    {
        public TournamentType Type { get; set; }
        public List<Account_BData> Players { get; set; }
        public int NumbersOfPlayers { get; set; }
        public bool OddPlayers { get; set; }
        public int Rounds { get; set; }

        public static int GetTournamentRounds(int PlayerAmount)
        {       
            var rounds = 0;

            while (PlayerAmount>1)
            {
                rounds++;
                if (IsOdd(PlayerAmount))
                {
                    PlayerAmount++;              
                }
                PlayerAmount = PlayerAmount / 2;
            }
            return rounds;
        }
        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
    }
    
}

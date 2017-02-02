
using Business_layer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tournament.net.ExtensionMethods.Mapping;
using Tournament.net.Models;

namespace Tournament.net.Controllers
{
    public class TournamentController : Controller
    {
        public static List<string> GuestList = new List<string>();
        // GET: Tournament
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ParticiPants(int number)
        {
            ViewBag.number = number;

            return PartialView();
        }
        [HttpPost]
        public ActionResult ParticiPants(string username)
        {
            GuestList.Add(username);

            return PartialView();
        }
        [HttpPost]
        public ActionResult Play(string gametype)
        {
            if (gametype == "Highscore")
            {
                return RedirectToAction("HighscoreBracket", "Main");
            }
            return RedirectToAction("TournamentBracket", "Tournament", new { GuestList = GuestList });
        }

        [HttpGet]
        public ActionResult TournamentBracket(List<string> Players)
        {
            // Connect "Players" when done!!!!
            var userNames = Players;
           // var userNames = new List<string>() { "Olle", "Fanny(Guest)", "Linda","Kalle", "Kaj(Guest)" , "Rudolf(Guest)" };
            var players = new List<AccountInTournamentViewModel>();

            var counter = userNames.Count;
            foreach (var item in userNames)
            {              
                var Account = new AccountViewModel() { Email = "", UserName = item, id = new Guid(), ImgURL = "/Items/Avatars/Guest.png" };
                if (!item.Contains("(Guest)"))
                {
                    Account = (Account_BData.GetAccount(item).ToModel());
                }

                players.Add(new AccountInTournamentViewModel()
                {
                    UserName = Account.UserName,
                    ImgURL = Account.ImgURL,
                    Email = Account.Email,
                    id = Account.id,
                    WindowSpot = counter,
                    TournamentPosition = 1
                });
            }
            var tournament = new TournamentViewModel()
            {
                Type = TournamentType.Tournament,
                Players = players,
                NumbersOfPlayers = counter,
                Rounds = FastFix.GetTournamentRounds(counter),
                OddPlayers = Tournament_BData.IsOdd(counter)
            };

            return PartialView(tournament);
        }
        [HttpPost]
        public ActionResult TournamentBracket()
        {

            return View();
        }


    }
    public static class FastFix
    {
        public static List<Round> GetTournamentRounds(int PlayerAmount)
        {
            var rounds = new List<Round>();

            while (PlayerAmount > 0)
            {            
                rounds.Add( new Round(PlayerAmount));
               
                if(PlayerAmount == 1) { PlayerAmount = 0; }
                else
                {
                    if (IsOdd(PlayerAmount))
                    {
                        PlayerAmount++;
                    }
                    PlayerAmount = (PlayerAmount / 2);
                }
            }
            return rounds;
        }
        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
    }
}

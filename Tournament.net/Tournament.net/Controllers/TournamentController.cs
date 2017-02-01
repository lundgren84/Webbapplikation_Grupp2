
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
        public ActionResult ParticiPants(int number, string type)
        {
            ViewBag.number = number;
            ViewBag.type = type;

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
      
        public ActionResult TournamentBracket(List<string> Players)
        {
            //Hämta lista av players (username) från databas?
            var userNames = Players;
            var players = new List<AccountInTournamentViewModel>();

            var counter = 0;
            foreach (var item in userNames)
            {
                counter++;
                //FIX HERE!!! So we dont go after guests!!
                var Account = new AccountViewModel() { Email = "", UserName = item, id = new Guid(), ImgURL = "/Items/Avatars/M01.png" };
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
                Rounds = Tournament_BData.GetTournamentRounds(counter),
                OddPlayers = Tournament_BData.IsOdd(counter)
            };
            return View(tournament);
        }
    }
}
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
    public class MainController : Controller
    {
        // GET: Main
        static List<AccountInHighscoreViewModel> playersList = new List<AccountInHighscoreViewModel>();
        static List<string> players = new List<string>();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GameTypeSelection()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult NbrOfPlayersSelection()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult NbrOfPlayersSelection(int number, string type)
        {
            //number = 8;
            //ViewBag.title = 8;

            return RedirectToAction("ParticiPants", "Tournament", new { number = number, type = type });
        }
        [HttpGet]
        public ActionResult ContendersForm(int number)
        {

            return PartialView();
        }

        [HttpGet]
        public ActionResult HighscoreBracket(List<string> Players)
        {
            //-------- START -------------
            var userNames = Players;
            var players = new List<AccountInHighscoreViewModel>();

            List<string> GuestList = Players;
            foreach (var item in userNames)
            {
                var Account = new AccountViewModel() { Email = "", UserName = item, id = new Guid(), ImgURL = "/Items/Avatars/Guest.png" };
                if (!item.Contains("(Guest)"))
                {
                    Account = (Account_BData.GetAccount(item).ToModel());
                }

                players.Add(new AccountInHighscoreViewModel()
                {
                    UserName = Account.UserName,
                    ImgURL = Account.ImgURL,
                    Email = Account.Email,
                    id = Account.id,
                    Score = 0
                });
            }
            //-------- END -------------

            if (playersList.Count < 1)
            {
                foreach (var item in players)
                {
                   
                    playersList.Add(item);
                }
            }

            return PartialView("HighscoreBracket", playersList);
        }
        [HttpPost]
        public ActionResult HighscoreBracket(int number, string username)
        {
            AccountInHighscoreViewModel playerToBeModified = new AccountInHighscoreViewModel();
            playerToBeModified = playersList.Where(p => p.UserName == username).FirstOrDefault();
            playerToBeModified.Score = number;
            List<AccountInHighscoreViewModel> playersToHighscoreBracket = playersList.OrderByDescending(s => s.Score).ToList();
            return PartialView(playersToHighscoreBracket);
        }
    }

}
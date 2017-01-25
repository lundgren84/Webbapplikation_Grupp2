
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
        public ActionResult ParticiPants(string username,int password)
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult TournamentBracket()
        {


            //Hämta lista av players (username) från databas?
            var userNames = new List<string>() {"Kalle","Olle","Frodo" };
            var players = new List<AccountViewModel>();
            var tournament = new TournamentViewModel();
            foreach (var item in userNames)
            {
                var Account = (Account_BData.GetAccount(item).ToModel());
                players.Add(Account);
            }
            tournament.Players = players;
            return View("TreeTest",tournament);
        }    
    }
}
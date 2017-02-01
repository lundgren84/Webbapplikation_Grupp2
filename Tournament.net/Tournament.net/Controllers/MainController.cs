﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult NbrOfPlayersSelection(string type)
        {
            ViewBag.type = type;
            return PartialView();
        }
        [HttpPost]
        public ActionResult NbrOfPlayersSelection(int number,string type)
        {
            //number = 8;
            //ViewBag.title = 8;

            return RedirectToAction("ParticiPants", "Tournament", new { number = number,type = type });
        }
        [HttpGet]
        public ActionResult ContendersForm(int number)
        {

            return PartialView();
        }

        [HttpGet]
        public ActionResult HighscoreBracket(List<string> Players)
        {
            // Just Liked up with the list... fix database and stuff!!
            List<string> GuestList = Players;

            if (playersList.Count < 1)
            {
                foreach (var item in GuestList)
                {
                    AccountInHighscoreViewModel player = new AccountInHighscoreViewModel() { UserName = item, Score = 0 };
                    playersList.Add(player);
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
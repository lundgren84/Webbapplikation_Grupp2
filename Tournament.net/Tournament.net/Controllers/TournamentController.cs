using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            //Hämta lista av players från databas?
            var player = new List<AccountViewModel>{};

            return PartialView(player);
        }
    }
}
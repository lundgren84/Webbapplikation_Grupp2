using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tournament.net.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
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
        public ActionResult NbrOfPlayersSelection(int number)
        {
            //number = 8;
            ViewBag.numberofPlayers = number;
        
           return RedirectToAction("ParticPants", "Tournament", null);
        }
        [HttpGet]
        public ActionResult ContendersForm(int number)
        {
            
            return PartialView();
        }
    }
  
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult ParticiPants()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult ParticiPants(string username,int password)
        {
            return PartialView();
        }
    }
}
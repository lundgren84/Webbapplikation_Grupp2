using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tournament.net.Controllers
{
    public class TurnamentController : Controller
    {
        // GET: Turnament
        public ActionResult Index()
        {
            return View();
        }
    }
}
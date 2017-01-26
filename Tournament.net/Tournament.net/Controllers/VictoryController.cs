using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tournament.net.Controllers
{
    public class VictoryController : Controller
    {
        // GET: Victory
        public ActionResult Finalpage()
        {
            return PartialView();
        }
    }
}
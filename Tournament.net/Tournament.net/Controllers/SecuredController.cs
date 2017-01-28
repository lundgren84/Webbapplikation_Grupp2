using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tournament.net.Library;

namespace Tournament.net.Controllers
{
    [AppCustomAuth]
    public class SecuredController : Controller
    {
        // GET: Secured
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tournament.net.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            Response.StatusCode = 200;
            return View("NotFound");
        }

        public ActionResult InternalServer()
        {
            Response.StatusCode = 200;
            return View("InternalServer");
        }
    }
}
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
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Options()
        {
            // Get Account Name
            var accName = User.Identity.Name;
            //Get current Account from DB
            var Account = (Account_BData.GetAccount(accName).ToModel());
            //Inject Account to view
            return PartialView(Account);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Options(AccountViewModel Model)
        {
            return PartialView();
        }




    }
}
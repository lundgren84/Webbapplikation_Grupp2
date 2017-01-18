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
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(AccountViewModel Model)
        {
            return RedirectToAction("Index","Main");
        }
        [HttpPost]
        public ActionResult Create(AccountViewModel Model)
        {
            //Mapping to BusinessData
            var BusinessData = Model.ToBusinessData();
            //Sending it to Business layer
            Account_BData.CreateAccount(BusinessData);

            return View();
        }
      
    }
}
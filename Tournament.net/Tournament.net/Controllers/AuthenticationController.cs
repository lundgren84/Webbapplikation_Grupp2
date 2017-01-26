using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using Business_layer.BusinessObjects;
using Business_layer.ExtensionMethods;
using Tournament.net.Models;
using Tournament.net.ExtensionMethods.Mapping;

namespace Tournament.net.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        private UserManager<IdentityUser> userManager;
        public AuthenticationController()
        {
            var context = new MyIdentityDbContext();
            var store = new UserStore<IdentityUser>(context);
            userManager = new UserManager<IdentityUser>(store);
        }
        // GET: Authentication
       
        public ActionResult Register()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(string username,
            string password,
            string email)
        {
            //Setup new user
            var user = new IdentityUser
            {
                UserName = username,
                Email = email
            };
            //Register user in db
            var result = await userManager.CreateAsync(user, password);           
            if (result.Succeeded)
            {
                //Create a identity
                var identity = await userManager.CreateIdentityAsync(user, 
                    DefaultAuthenticationTypes.ApplicationCookie);
                //Create new claim            
                identity.AddClaim(new Claim("Email", user.Email));

                var authorisationManager = 
                    HttpContext.GetOwinContext().Authentication;
                //Sign in
                authorisationManager.SignIn(identity);

                //Create BusinessData                
                var BusinessData = new Account_BData()
                {          
                    UserName = user.UserName,
                    Email = user.Email
                };
                //Sending it to Business layer

                BusinessData.CreateNew();
                return Content("Registration Successful");
            }
            else
            {
                return Content(result.Errors.First());
            }
           
        }
        public ActionResult Login()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CheckLogin(
          string username,
          string password)
        {
            var user = await userManager.FindAsync(username, password);
            AccountViewModel account;
            if (user == null) { return null; }
            else
            {
                account = (Account_BData.GetAccount(username)).ToModel();
            }
            return Json(account, JsonRequestBehavior.AllowGet);       
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(
            string username,
            string password)
        {
            var user = await userManager.FindAsync(username, password);

            if (user == null) { return View(username); }

            var identity = await userManager.CreateIdentityAsync(user,
                DefaultAuthenticationTypes.ApplicationCookie);

            var authorisationManager = HttpContext.GetOwinContext().Authentication;

            authorisationManager.SignIn(identity);

            return RedirectToAction("Index", "Main");
        }

        public ActionResult Logout()
        {

            var authorisationManager = HttpContext.GetOwinContext().Authentication;

            authorisationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Index","Main",null);
        }
    }
}
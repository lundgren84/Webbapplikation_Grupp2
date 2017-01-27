using Business_layer.BusinessObjects;
using Business_layer.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tournament.net.ExtensionMethods.Mapping;
using Tournament.net.Library;
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

        /* ----------------------------------------------------------------------- */
        #region Options
        public ActionResult Options()
        {
            // Get Account Name
            var accName = User.Identity.Name;
            //Get current Account from DB
            var Account = (Account_BData.GetAccount(accName).ToModel());
            //Inject Account to view
            return PartialView(Account);
        }
        #endregion

        #region SaveChanges
        [HttpPost]
        [Authorize]
        public ActionResult SaveChanges(AccountViewModel Model)
        {
            // Saving Account changes
            (Model.ToBusinessData()).SaveChanges();

            return Content("Hello");
        }
        #endregion

        /* ----------------------------------------------------------------------- */
        AppEFContext appContext = new AppEFContext();
        /* ----------------------------------------------------------------------- */
        /* GET */
        #region Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        #endregion

        #region Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        #endregion

        #region LogOff
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Main");
        }
        #endregion

        /* ----------------------------------------------------------------------- */
        /* POST */
        #region Login
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var user = appContext.App_User.Where(r => r.EmailID == model.EmailID && r.Password == model.Password).FirstOrDefault();


            if (user != null)
            {

                // check if verified
                if (user.IsVerified == true)
                {
                    // Add AUTH cookies now and redirect user to any secured page
                    HttpContext.Response.Cookies.Add(AppAuthenticate.Authenticate(model.EmailID));
                    return RedirectToAction("Index", "Secured");
                }
                else
                {
                    TempData["ErrorMessage"] = "Please verify your account, an email has already been sent.";
                    return RedirectToAction("Login", "Account");
                }
            }
            else
            {

                ModelState.AddModelError("", "Incorrect username and/or password");
                return View(model);
            }
        }
        #endregion

        #region Register
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }


            string emailID = model.EmailID;

            App_User user = new App_User()
            {
                ID = Guid.NewGuid(),
                EmailID = model.EmailID,
                Password = model.Password,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Country = model.Country,
                RegistrationDate = DateTime.UtcNow,
                IsVerified = false

            };


            var isUserExist = appContext.App_User.Where(r => r.EmailID == emailID).FirstOrDefault();

            if (isUserExist == null)
            {

                ViewBag.SentMailID = model.EmailID;


                appContext.App_User.Add(user);
                appContext.SaveChanges();


                var randomID = Guid.NewGuid().ToString();
                string toAddress = model.EmailID;

                string verificationURL = Request.Url.GetLeftPart(UriPartial.Authority) + "/Main/Verify?id=" + randomID;



                string mailContent = "<h2>Please verify your account by logging at:</h2>";
                mailContent += "<br><br>";
                mailContent += "<a href='" + verificationURL + "'>" + verificationURL + "</a>";
                mailContent += "<br><br>";


                mailContent += "<br>Thank You";


                AppNotification.SendEmail(toAddress, "Verification of account", mailContent);


                var appVerification = new App_UserVerification()
                {
                    ID = Guid.NewGuid(),
                    EmailID = toAddress,
                    CreateDate = DateTime.UtcNow,
                    VerificationCode = randomID
                };


                appContext.App_UserVerification.Add(appVerification);
                appContext.SaveChanges();


                return View("ThankYou");

            }
            else
            {

                ModelState.AddModelError("", "Email ID is already registered");
                return View(model);
            }

        }
        #endregion

        /* ----------------------------------------------------------------------- */


    }
}
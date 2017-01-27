using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Tournament.net.Models;
using System.Web.Helpers;

namespace Tournament.net.Controllers
{
    public class VictoryController : Controller
    {
        // GET: Victory
        public ActionResult Finalpage()
        {
            return PartialView();
        }

        public ActionResult ScoreSummary()
        {
            return PartialView();
        }

        public ActionResult SendDiplomaMail(AccountViewModel avm)
        {

            try
            {
                //Configuring webMail class to send emails  
                //gmail smtp server  
                WebMail.SmtpServer = "smtp.gmail.com";
                //gmail port to send emails  
                WebMail.SmtpPort = 587;
                WebMail.SmtpUseDefaultCredentials = true;
                //sending emails with secure protocol  
                WebMail.EnableSsl = true;
                //EmailId used to send emails from application  
                //WebMail.UserName = "YourGamilId@gmail.com";
                WebMail.UserName = avm.Email;
                WebMail.Password = "YourGmailPassword";

                //Sender email address.  
                WebMail.From = "SenderGamilId@gmail.com";

                var thesubject = "Här är Diploma";
                var Dibloma="Du vant tournamnet";


                //Send email  
                WebMail.Send(to: avm.Email, subject: thesubject, body: Dibloma,  isBodyHtml: true);
                ViewBag.Status = "Email Sent Successfully.";
            }
            catch (Exception)
            {
                ViewBag.Status = "Problem while sending email, Please check details.";

            }

            return View();
        }

    }
}
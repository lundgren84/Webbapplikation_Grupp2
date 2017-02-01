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
            AccountViewModel AVM = new AccountViewModel();

            AVM.Email = "testmail@mail.com";
            AVM.UserName = "Rikard";

            return PartialView(AVM);
        }

        public ActionResult ScoreSummary()
        {
            return PartialView();
        }

        public ActionResult PartisipationSummary()
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

        public static void SendEmail(string to)
        {
            // These are custom settings
            string fromAddress = "tournament@jonasjsk.com";
            string toAddress = to;

            
            //string pass = "mQ8FJkKyj49o";
            //string host = "smtpout.europe.secureserver.net";
            //int port = 80;

            //// Message
            //MailMessage mm = new MailMessage();
            //mm.IsBodyHtml = true; // make HTML mail
            //mm.From = new MailAddress(fromAddress);
            //mm.To.Add(new MailAddress(toAddress));
            //mm.Subject = "Här är diplomat.";
            //mm.Body = "Du vann tävlingne med tournamnet appen.";

            //// SMTP
            //NetworkCredential credential = new NetworkCredential(fromAddress, pass);
            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = host;
            //smtp.Port = port;
            //smtp.EnableSsl = false;
            //smtp.Credentials = credential;
            //smtp.Timeout = 20000;

            //// Send
            //try
            //{
            //    smtp.Send(mm);
            //}
            //catch (Exception e)
            //{

            //}
        }

        

    }
}
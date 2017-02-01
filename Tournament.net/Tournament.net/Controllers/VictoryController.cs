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
            AVM.ImgURL = "/Items/Avatars/M12.png";

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


        public static void SendEmail(string to, string subject, string details)
        {
            // These are custom settings
            string fromAddress = "tournament@jonasjsk.com";
            string toAddress = to;
            string pass = "mQ8FJkKyj49o";
            string host = "smtpout.europe.secureserver.net";
            int port = 80;

            // Message
            MailMessage mm = new MailMessage();
            mm.IsBodyHtml = true; // make HTML mail
            mm.From = new MailAddress(fromAddress);
            mm.To.Add(new MailAddress(toAddress));
            mm.Subject = subject;
            mm.Body = details;

            // SMTP
            NetworkCredential credential = new NetworkCredential(fromAddress, pass);
            SmtpClient smtp = new SmtpClient();
            smtp.Host = host;
            smtp.Port = port;
            smtp.EnableSsl = false;
            smtp.Credentials = credential;
            smtp.Timeout = 20000;

            // Send
            try
            {
                smtp.Send(mm);
            }
            catch (Exception e)
            {

            }
        }



    }
}
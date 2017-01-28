using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Tournament.net.Library
{
    public class AppNotification
    {
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
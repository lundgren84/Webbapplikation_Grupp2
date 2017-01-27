using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Tournament.net.Library
{
    public class AppAuthenticate
    {
        public static HttpCookie Authenticate(string emailID)
        {

            FormsAuthentication.SetAuthCookie(emailID, true);


            var authTicket = new FormsAuthenticationTicket(1, emailID, DateTime.Now, DateTime.Now.AddDays(1), false, "");
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);


            return new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

        }


        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }


        public static string GetPasswordEncypted(string password, string salt)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] src = Convert.FromBase64String(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            byte[] inArray = null;


            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            inArray = algorithm.ComputeHash(dst);


            return Convert.ToBase64String(inArray);

        }
    }
}
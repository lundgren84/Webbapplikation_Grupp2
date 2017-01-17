using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(Tournament.net.App_Start.Startup1))]

namespace Tournament.net.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(
               new CookieAuthenticationOptions
               {
                   AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                   LoginPath = new PathString("/Authentication/Login")
               });
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}

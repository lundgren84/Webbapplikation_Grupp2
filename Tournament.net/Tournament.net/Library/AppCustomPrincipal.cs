using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Tournament.net.Library
{
    public class AppCustomPrincipal : IPrincipal
    {
        public AppCustomPrincipal(string username)
        {

            this.Identity = new GenericIdentity(username);
        }


        public IIdentity Identity
        {
            get; set;
        }

        // not in use
        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
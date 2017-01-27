using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tournament.net.Library
{
    public class AppCustomAuth : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                // user is authenticated
            }
            else
            {

                filterContext.Result = new HttpUnauthorizedResult();
            }


            base.OnAuthorization(filterContext);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Tournament.net
{
    public class MyIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public MyIdentityDbContext() : base("name = connectionsStringName") { }
    }
}
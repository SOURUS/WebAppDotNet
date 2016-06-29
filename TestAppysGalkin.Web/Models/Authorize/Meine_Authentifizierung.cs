using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestAppysGalkin.Web.Models.Shared;

namespace TestAppysGalkin.Web.Models.Authorize
{
    public class Meine_Authentifizierung : AuthorizeAttribute, IAuthorizationFilter
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                return false;
            }
            return true;
        }
    }
}
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
            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new { controller = "Security", action = "AccessDenied" }));

        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["UserProfile"] == null)
            {
                filterContext.Result = filterContext.Result = new HttpUnauthorizedResult();
            }

            else
            {
                // аутентификация прошла успешна
                base.OnAuthorization(filterContext);
            }
        }

    }
}
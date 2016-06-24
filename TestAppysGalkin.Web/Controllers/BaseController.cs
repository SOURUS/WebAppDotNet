using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestAppysGalkin.Web.Controllers
{
    public class BaseController : Controller
    {
        //здесь мог бы быть логгер

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            if (Session == null)
            {

            }
            base.Initialize(requestContext);
        }

    }
}

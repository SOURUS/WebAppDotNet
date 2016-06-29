using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(TestAppysGalkin.Web.Startup))]

namespace TestAppysGalkin.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Security/Login")
            });

            app.MapSignalR();
            GlobalHost.HubPipeline.RequireAuthentication();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;
using TestAppysGalkin.Web.Models.Authorize;

namespace TestAppysGalkin.Web.Hubs
{
    [Authorize]
    [HubName("MainHub")]
    public class MainHub : Hub
    {
        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<MainHub>();

        public void SendMessage(string user, string message)
        {
            string name = HttpContext.Current.User.Identity.Name;

            if (name!=null)
                hubContext.Clients.Group(user).updateMessages(message);
        }

        public void GreetAll()
        {
            hubContext.Clients.All.acceptGreet("Привет от сервера!");
        }

        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;

            if (name!=null)
                Groups.Add(Context.ConnectionId, name);

            return base.OnConnected();
        }
    }
}
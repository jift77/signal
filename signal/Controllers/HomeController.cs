using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace signal.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public void SendMessage()
        {
            var dependencyResolver = GlobalHost.DependencyResolver;
            var connectionManager = dependencyResolver.Resolve<IConnectionManager>();
            var hubContext = connectionManager.GetHubContext<EchoHub>();
            var all = hubContext.Clients.All;
            all.greetings("ola ke ase");
        }
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using signal.PersistentCon;

[assembly: OwinStartup(typeof(signal.Startup))]
namespace signal
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            app.MapSignalR<EchoConnection>("/echo");
        }
    }
}

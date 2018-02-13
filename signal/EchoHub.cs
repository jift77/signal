using System.Diagnostics;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace signal
{
    [HubName("Echo")]
    public class EchoHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();    
        }

        public void Say(string message)
        {
            Trace.WriteLine(message);
        }
    }
}
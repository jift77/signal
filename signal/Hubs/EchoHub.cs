using System.Diagnostics;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;

namespace signal
{
    [HubName("Echo")]
    public class EchoHub : Hub
    {
        public static int _calls = 0;

        public EchoHub()
        { }

        public void Hello()
        {
            var msg = $"Greetings {Context.ConnectionId}, its {DateTime.Now} ";
            var all = Clients.All;
            all.greetings(msg);
        }

        public void Say(string message)
        {
            Trace.WriteLine(message);
        }
    }
}
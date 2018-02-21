using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace signal
{
    [HubName("Exclude")]
    public class ExcludeHub : Hub
    {
        static readonly HashSet<string> connectionIds = new HashSet<string>();

        public void Subscribe()
        {
            var connectionId = Context.ConnectionId;
            connectionIds.UnionWith(new[] { connectionId });
            Clients.All.connections(connectionIds);
        }

        public void HelloBut(string excludeConnectionId)
        {
            var msg = $"Welcome {Context.ConnectionId} at {DateTime.Now}";
            var allExcept = Clients.AllExcept(excludeConnectionId);
            allExcept.greetings(msg);
        }
    }
}
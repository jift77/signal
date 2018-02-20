using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace signal
{
    [HubName("Group")]
    public class GroupsHub : Hub
    {
        public void Subscribe(string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);
        }

        public void Unsuscribe(string groupName)
        {
            Groups.Remove(Context.ConnectionId, groupName);
        }

        public void Hello(string groupName)
        {
            var msg = $"Welcome form {groupName}";
            Clients.Group(groupName).greetings(msg);
        }
    }
}
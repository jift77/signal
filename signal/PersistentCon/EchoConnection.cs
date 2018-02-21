using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace signal.PersistentCon
{
    public class EchoConnection : PersistentConnection
    {
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            return Connection.Send(connectionId, "Hoooooli");
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            var payload = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(data, new { body = "" });
            var body = $"You said: {payload.body}";
            return Connection.Broadcast(new { body = body });
        }
    }
}
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

// based on http://www.asp.net/signalr/overview/getting-started/tutorial-getting-started-with-signalr-and-mvc

namespace SignalRChat
{
    //[HubName("chat")]
    public class ChatHub : Hub
    {
        public void SendChat(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
        }

        public void SendJoinNotification(string name)
        {
            Clients.Others.broadcastJoined(name);
        }

        public void SendDisconnectNotification(string name)
        {
            Clients.Others.broadcastDisconnected(name);
        }

        public void SendAlert(string name)
        {
            Clients.All.broadcastAlert(name);
        }
    }
}
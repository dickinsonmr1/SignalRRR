using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new HubConnection("http://localhost:57504/");
            //var connection = new HubConnection("http://signalrrr.azurewebsites.net/");
            connection.Error += ex => Console.WriteLine("SignalR error: {0}", ex.Message);

            var listenerId = Guid.NewGuid();

            var hubProxy = connection.CreateHubProxy("ChatHub");

            hubProxy.On<string>("hubMessage", (data) =>
            {
                Console.WriteLine("hubMessage: " + data);
            });

            hubProxy.On<string, string>("broadcastMessage", (name, message) => SendMessageToConsole(name, message));
            hubProxy.On("broadcastAlert", name => SendAlertToConsole(name));
            hubProxy.On("broadcastJoined", name => SendJoinedToConsole(name));

            connection.Start().Wait();


            hubProxy.Invoke("SendJoinNotification", "Console Client " + listenerId.ToString()).Wait();
            Console.WriteLine("Client connected to hub. Press ENTER to finish program.");
            Console.ReadLine();
            hubProxy.Invoke("SendDisconnectNotification", "Console Client " + listenerId.ToString()).Wait();
        }

        public void DetermineLength(string message)
        {
            Console.WriteLine(message);
        }

        public static void SendMessageToConsole(string name, string message)
        {
            Console.WriteLine("{0}: {1}", name, message);
        }

        public static void SendAlertToConsole(string name)
        {
            Console.WriteLine("{0} has sent an alert!", name);
        }

        public static void SendJoinedToConsole(string name)
        {
            Console.WriteLine("{0} has joined.", name);
        }

        //public async Task RunAsync(string url)
        //{
        //    var connection = new HubConnection("http://localhost:57504/");

        //    //connection.TraceWriter = _traceWriter;

        //    var hubProxy = connection.CreateHubProxy("ChatHub");

        //    hubProxy.On<string>("hubMessage", (data) =>
        //    {
        //        Console.WriteLine("hubMessage: " + data);
        //    });

        //    await connection.Start();
        //    await hubProxy.Invoke("SendToMe", "Hello World!");
        //}
    }
}

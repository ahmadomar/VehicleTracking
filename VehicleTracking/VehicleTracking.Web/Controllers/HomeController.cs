using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleTracking.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var client = new SignalRMasterClient("https://localhost:44340/status");

            // Send message to server.
            client.SayHello("Message from client to Server!");

            Console.ReadKey();

            // Stop connection with the server to immediately call "OnDisconnected" event 
            // in server hub class.
            client.Stop();
            return View();
        }
    }



    public class SignalRMasterClient
    {
        public string Url { get; set; }
        public HubConnection Connection { get; set; }
        public IHubProxy Hub { get; set; }

        public SignalRMasterClient(string url)
        {
            Url = url;
            Connection = new HubConnection(url, useDefaultUrl: false);
            Hub = Connection.CreateHubProxy("VehicleStatusHub");
            Connection.Start().Wait();

            Hub.On<string>("acknowledgeMessage", (message) =>
            {
                Console.WriteLine("Message received: " + message);

                /// TODO: Check status of the LDAP
                /// and update status to Web API.
            });
        }

        public void SayHello(string message)
        {
            Hub.Invoke("hello", message);
            Console.WriteLine("hello method is called!");
        }

        public void Stop()
        {
            Connection.Stop();
        }

    }
}

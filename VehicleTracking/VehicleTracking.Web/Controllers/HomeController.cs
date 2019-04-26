using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.Mvc;
using VehicleTracking.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleTracking.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var data = VehicleStaticData.ReadData();
            var vehiclesList = data.SelectMany(v => v.Vehicles.ToList()).ToList();
            return View(vehiclesList);
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

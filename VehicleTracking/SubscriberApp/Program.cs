using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;
using VehicleTracking.Models;

namespace SubscriberApp
{
    class Program
    {
        public static string[] ConnectionStatus => new string[] { "Connected", "NotConnected" };
        static void Main(string[] args)
        {
            var random = new Random();

            var randomConnection = new Random();

            var data = VehicleStaticData.ReadData();
            var vehiclesList = data.SelectMany(v => v.Vehicles.ToList()).ToList();

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(1);

            var timer = new System.Threading.Timer((e) =>
            {
                int itemIndex = random.Next(vehiclesList.Count);
                int connectionIntex = randomConnection.Next(ConnectionStatus.Length);

                var vehicle = vehiclesList[itemIndex];

                vehicle.Status = ConnectionStatus[connectionIntex];

                NotifyClient(vehicle);
                Console.WriteLine($"Vehicle {vehicle.RegNr}: {vehicle.Status}");
                
            }, null, startTimeSpan, periodTimeSpan);

            

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }

        private static void NotifyClient(VehicleModel vehicle)
        {
            var statusJson = new
            {
                VehicleNumber = vehicle.RegNr,
                Status = vehicle.Status
            };

            var client = new RestClient("https://localhost:5001/status");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("", JsonConvert.SerializeObject(statusJson), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
        }
    }
}

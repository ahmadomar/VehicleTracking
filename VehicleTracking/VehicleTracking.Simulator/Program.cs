using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;
using System.Net;
using VehicleTracking.Models;

namespace VehicleTracking.Simulator
{
    class Program
    {
        public static string[] ConnectionStatus => new string[] { "Connected", "NotConnected" };
        static void Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };


            var random = new Random();

            var randomConnection = new Random();

            var data = VehicleStaticData.ReadData();
            var vehiclesList = data.SelectMany(v => v.Vehicles.ToList()).ToList();

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(10);

            var timer = new System.Threading.Timer((e) =>
            {
                int itemIndex = random.Next(vehiclesList.Count);
                int connectionIntex = randomConnection.Next(ConnectionStatus.Length);

                var vehicle = vehiclesList[itemIndex];

                vehicle.Status = ConnectionStatus[connectionIntex];

                NotifyClient(vehicle);
                Console.WriteLine($"Vehicle {vehicle.VehicleNumber}-{vehicle.RegNr}: {vehicle.Status}");

            }, null, startTimeSpan, periodTimeSpan);



            Console.WriteLine("Welcome to Vehicle Simulator App!");
            Console.ReadLine();
        }

        private static void NotifyClient(VehicleModel vehicle)
        {
            var statusJson = new
            {
                VehicleNumber = vehicle.VehicleNumber,
                RegNr = vehicle.RegNr,
                Status = vehicle.Status
            };

            var client = new RestClient("https://localhost:5001/status");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("command", JsonConvert.SerializeObject(statusJson,Formatting.None), ParameterType.RequestBody);
            client.Execute(request);
        }
    }
}

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;
using System.Linq;
using System.Net;
using VehicleTracking.Models;

namespace VehicleTracking.Simulator
{
    class Program
    {
        static string GatewayAPIStatusURL { get; set; }
        static string[] ConnectionStatus => new string[] { "Connected", "Disconnected", "Connected", "Disconnected", };
        static void Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            GatewayAPIStatusURL = ReadGatwayURL();

            var random = new Random();

            var randomConnection = new Random();

            var data = VehicleStaticData.ReadData();
            var vehiclesList = data.SelectMany(v => v.Vehicles.ToList()).ToList();

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(5);

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

        private static string ReadGatwayURL()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            
            return configuration["GatewayAPI-Status"];
        }

        private static void NotifyClient(VehicleModel vehicle)
        {
            var statusJson = new
            {
                VehicleNumber = vehicle.VehicleNumber,
                RegNr = vehicle.RegNr,
                Status = vehicle.Status
            };

            var client = new RestClient(GatewayAPIStatusURL);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("command", JsonConvert.SerializeObject(statusJson,Formatting.None), ParameterType.RequestBody);
            client.Execute(request);
        }
    }
}

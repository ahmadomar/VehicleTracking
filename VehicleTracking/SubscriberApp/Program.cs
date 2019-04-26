using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SubscriberApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            HubConnection connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/VehicleStatusHub")
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };


            connection.On<VehicleData>("ReceiveStatusChanges", (vehicleData) =>
            {
                var newMessage = $"{vehicleData.VehicleNumber}: {vehicleData.Status}";
                Console.WriteLine(newMessage);
            });

            try
            {
                connection.StartAsync();
                Console.WriteLine("Connection started");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();
            connection.StopAsync();
        }

        public class VehicleData
        {
            public string VehicleNumber { get; set; }
            public string Status { get; set; }
        }
    }
}

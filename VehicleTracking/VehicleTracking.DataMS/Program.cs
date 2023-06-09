﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using VehicleTracking.Common.MQ.Commands;
using VehicleTracking.Common.MQ.Services;
using VehicleTracking.DataMS.DataContext;

namespace VehicleTracking.DataMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var servHost = ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToCommand<UpdateVehicleCommand>()
                .Build();

            using (var scope = servHost._webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<VehicleDBContext>();

                DataGenerator.Initialize(services);
            }

            servHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

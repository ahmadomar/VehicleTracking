using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using VehicleTracking.Models;

namespace VehicleTracking.DataMS.DataContext
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VehicleDBContext(serviceProvider.GetRequiredService<DbContextOptions<VehicleDBContext>>()))
            {
                var data = VehicleStaticData.ReadData();
                context.Customers.AddRange(data);
                context.SaveChanges();
            }
        }
    }
}
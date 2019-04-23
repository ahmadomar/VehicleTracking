using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace VehicleTracking.DataMS.DataContext
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VehicleDBContext(serviceProvider.GetRequiredService<DbContextOptions<VehicleDBContext>>()))
            {
                context.Customers.AddRange(
                    new Models.CustomerModel
                    {
                        Id = 1,
                        Name = "Kalles Grustransporter AB",
                        Address = "Cementvägen 8, 111 11 Södertälje",
                        Vehicles = new List<Models.VehicleModel>
                    {
                        new Models.VehicleModel
                        {
                            CustomerId = 1,
                            VehicleId = "YS2R4X20005399401",
                            RegNr = "ABC123",
                            Status = "Connected"
                        },
                        new Models.VehicleModel
                        {
                            CustomerId = 1,
                            VehicleId = "VLUR4X20009093588",
                            RegNr = "DEF456",
                            Status = "Connected"
                        },
                        new Models.VehicleModel
                        {
                            CustomerId = 1,
                            VehicleId = "VLUR4X20009048065",
                            RegNr = "GHI789",
                            Status = "Connected"
                        },
                    }
                    },
                    new Models.CustomerModel
                    {
                        Id = 2,
                        Name = "Johans Bulk AB",
                        Address = "Balkvägen 12, 222 22 Stockholm",
                        Vehicles = new List<Models.VehicleModel>
                    {
                        new Models.VehicleModel
                        {
                            CustomerId = 2,
                            VehicleId = "YS2R4X20005388011",
                            RegNr = "JKL012",
                            Status = "Connected"
                        },
                        new Models.VehicleModel
                        {
                            CustomerId = 2,
                            VehicleId = "YS2R4X20005387949",
                            RegNr = "MNO345",
                            Status = "Connected"
                        }
                    }
                    },
                    new Models.CustomerModel
                    {
                        Id = 3,
                        Name = "Haralds Värdetransporter AB",
                        Address = "Budgetvägen 1, 333 33 Uppsala",
                        Vehicles = new List<Models.VehicleModel>
                    {
                        new Models.VehicleModel
                        {
                            CustomerId = 3,
                            VehicleId = "VLUR4X20009048066",
                            RegNr = "PQR678",
                            Status = "Connected"
                        },
                        new Models.VehicleModel
                        {
                            CustomerId = 3,
                            VehicleId = "YS2R4X20005387055",
                            RegNr = "STU901",
                            Status = "Connected"
                        }
                    }
                    });

                context.SaveChanges();

            }
        }
    }
}
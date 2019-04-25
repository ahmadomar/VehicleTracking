using System.Collections.Generic;

namespace VehicleTracking.Models
{
    public static class VehicleStaticData
    {
        public static List<CustomerModel> ReadData()
        {
            return new List<CustomerModel>
            {
                new CustomerModel
            {
                Id = 1,
                Name = "Kalles Grustransporter AB",
                Address = "Cementvägen 8, 111 11 Södertälje",
                Vehicles = new List<VehicleModel>
                    {
                        new VehicleModel
                        {
                            CustomerId = 1,
                            VehicleId = "YS2R4X20005399401",
                            RegNr = "ABC123",
                            Status = "Connected"
                        },
                        new VehicleModel
                        {
                            CustomerId = 1,
                            VehicleId = "VLUR4X20009093588",
                            RegNr = "DEF456",
                            Status = "Connected"
                        },
                        new VehicleModel
                        {
                            CustomerId = 1,
                            VehicleId = "VLUR4X20009048065",
                            RegNr = "GHI789",
                            Status = "Connected"
                        },
                    }
            },
                    new CustomerModel
                    {
                        Id = 2,
                        Name = "Johans Bulk AB",
                        Address = "Balkvägen 12, 222 22 Stockholm",
                        Vehicles = new List<VehicleModel>
                    {
                        new VehicleModel
                        {
                            CustomerId = 2,
                            VehicleId = "YS2R4X20005388011",
                            RegNr = "JKL012",
                            Status = "Connected"
                        },
                        new VehicleModel
                        {
                            CustomerId = 2,
                            VehicleId = "YS2R4X20005387949",
                            RegNr = "MNO345",
                            Status = "Connected"
                        }
                    }
                    },
                    new CustomerModel
                    {
                        Id = 3,
                        Name = "Haralds Värdetransporter AB",
                        Address = "Budgetvägen 1, 333 33 Uppsala",
                        Vehicles = new List<VehicleModel>
                    {
                        new VehicleModel
                        {
                            CustomerId = 3,
                            VehicleId = "VLUR4X20009048066",
                            RegNr = "PQR678",
                            Status = "Connected"
                        },
                        new VehicleModel
                        {
                            CustomerId = 3,
                            VehicleId = "YS2R4X20005387055",
                            RegNr = "STU901",
                            Status = "Connected"
                        }
                    }
                    }
            };
        }
    }
}
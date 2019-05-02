using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using VehicleTracking.DataMS.DataContext;

namespace VehicleTracking.DataMS.Tests
{
    public class InMemoryDbContextFactory
    {
        public Mock<VehicleDBContext> GetVehicleDbContext()
        {
            var options = new DbContextOptionsBuilder<VehicleDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            return new Mock<VehicleDBContext>(options);
        }
    }
}

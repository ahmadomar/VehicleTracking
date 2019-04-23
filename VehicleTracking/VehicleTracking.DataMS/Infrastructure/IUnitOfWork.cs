using System;
using VehicleTracking.DataMS.Repositories;

namespace VehicleTracking.DataMS.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IVehicleRepository Vehicles { get; }
        ICustomerRepository Customers { get; }
        int Complete();
    }
}

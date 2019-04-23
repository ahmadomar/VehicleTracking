using VehicleTracking.DataMS.DataContext;
using VehicleTracking.DataMS.Repositories;

namespace VehicleTracking.DataMS.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VehicleDBContext _context;
        public UnitOfWork(VehicleDBContext context)
        {
            _context = context;
            Vehicles = new VehicleRepository(_context);
            Customers = new CustomerRepository(_context);
        }
        public IVehicleRepository Vehicles { get; private set; }

        public ICustomerRepository Customers { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

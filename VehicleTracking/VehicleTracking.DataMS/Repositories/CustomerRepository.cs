using VehicleTracking.DataMS.DataContext;
using VehicleTracking.DataMS.Infrastructure;
using VehicleTracking.Models;

namespace VehicleTracking.DataMS.Repositories
{
    public class CustomerRepository : RepositoryBase<CustomerModel>, ICustomerRepository
    {
        public CustomerRepository(VehicleDBContext vehicleDBContext) : base(vehicleDBContext)
        {
        }
    }

    public interface ICustomerRepository : IRepository<CustomerModel>
    {
    }
}

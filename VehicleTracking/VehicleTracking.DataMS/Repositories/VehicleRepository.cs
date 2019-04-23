using VehicleTracking.DataMS.DataContext;
using VehicleTracking.DataMS.Infrastructure;
using VehicleTracking.Models;

namespace VehicleTracking.DataMS.Repositories
{
    public class VehicleRepository : RepositoryBase<VehicleModel>, IVehicleRepository
    {
        public VehicleRepository(VehicleDBContext vehicleDBContext)
            :base(vehicleDBContext)
        {

        }
    }

    public interface IVehicleRepository : IRepository<VehicleModel> { }
}
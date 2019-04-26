using VehicleTracking.DataMS.Infrastructure;

namespace VehicleTracking.DataMS.Services
{
    public class BaseService
    {
        public readonly IUnitOfWork unitOfWork;
        public BaseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}

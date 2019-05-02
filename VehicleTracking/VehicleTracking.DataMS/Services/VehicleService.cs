using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleTracking.DataMS.Infrastructure;
using VehicleTracking.DataMS.Repositories;
using VehicleTracking.Models;

namespace VehicleTracking.DataMS.Services
{
    public interface IVehicleService
    {
        Task<int> UpdateStatus(string vehicleNumber, string regNr, string status);
        IEnumerable<VehicleModel> GetAll();
    }
    public class VehicleService : BaseService, IVehicleService
    {
        private IVehicleRepository _repo;
        public VehicleService(IUnitOfWork unitOfWork, IVehicleRepository repo)
            : base(unitOfWork)
        {
            _repo = repo;
        }

        public async Task<int> UpdateStatus(string vehicleNumber, string regNr, string status)
        { 
            var existsVehicle = _repo.Get(v => v.VehicleNumber == vehicleNumber && v.RegNr == regNr);
            if (existsVehicle != null)
            {
                existsVehicle.Status = status;
                return await unitOfWork.CommitAsync();
            }
            return -1;
        }

        public IEnumerable<VehicleModel> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
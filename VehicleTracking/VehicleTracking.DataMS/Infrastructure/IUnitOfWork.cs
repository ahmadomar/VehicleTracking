using System.Threading.Tasks;

namespace VehicleTracking.DataMS.Infrastructure
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
    }
}

using System.Threading.Tasks;
using VehicleTracking.DataMS.DataContext;

namespace VehicleTracking.DataMS.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private VehicleDBContext dbContext;
        public UnitOfWork(VehicleDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}

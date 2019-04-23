using System.Threading.Tasks;

namespace VehicleTracking.Common.MQ.Commands
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}

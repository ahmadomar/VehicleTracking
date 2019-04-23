using System.Threading.Tasks;

namespace VehicleTracking.Common.MQ.Events
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}

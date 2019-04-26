using System;
using System.Threading.Tasks;
using VehicleTracking.API.Hubs;
using VehicleTracking.Common.MQ.Events;

namespace VehicleTracking.API.Handlers
{
    public class StatusChangedHandler : IEventHandler<StatusChangedEvent>
    {

        public async Task HandleAsync(StatusChangedEvent @event)
        {
            await Task.CompletedTask;

            Console.WriteLine($"Status changed: {@event.VehicleNumber}");
        }
    }
}

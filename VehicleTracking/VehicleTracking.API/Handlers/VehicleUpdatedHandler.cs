using System;
using System.Threading.Tasks;
using VehicleTracking.Common.MQ.Events;

namespace VehicleTracking.API.Handlers
{
    public class VehicleUpdatedHandler : IEventHandler<UpdateVehicleEvent>
    {

        public async Task HandleAsync(UpdateVehicleEvent @event)
        {
            await Task.CompletedTask;

            Console.WriteLine($"Vehicle status updated: {@event.VehicleNumber}");
        }
    }
}

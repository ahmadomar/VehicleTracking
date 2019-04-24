using RawRabbit;
using System;
using System.Threading.Tasks;
using VehicleTracking.Common.MQ.Commands;
using VehicleTracking.Common.MQ.Events;

namespace VehicleTracking.DataMS.Handlers
{
    public class UpdatedVehicleHandler : ICommandHandler<UpdateVehicleCommand>
    {

        private readonly IBusClient _busClient;
        public UpdatedVehicleHandler(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public async Task HandleAsync(UpdateVehicleCommand command)
        {
            Console.WriteLine($"Updating Vehicle: {command.VehicleNumber}");
            await _busClient.PublishAsync(new UpdateVehicleEvent(command.VehicleNumber));
        }
    }
}
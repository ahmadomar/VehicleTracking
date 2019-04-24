using RawRabbit;
using System;
using System.Threading.Tasks;
using VehicleTracking.Common.MQ.Commands;
using VehicleTracking.Common.MQ.Events;

namespace VehicleTracking.StatusMS.Handlers
{
    public class StatusChangedHandler : ICommandHandler<StatusChangeCommand>
    {

        private readonly IBusClient _busClient;
        public StatusChangedHandler(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public async Task HandleAsync(StatusChangeCommand command)
        {
            Console.WriteLine($"Changing Status: {command.VehicleNumber}");
            await _busClient.PublishAsync(new StatusChangedEvent(command.VehicleNumber, command.Status));
        }
    }
}

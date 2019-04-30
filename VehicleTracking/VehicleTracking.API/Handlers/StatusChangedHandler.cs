using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Threading.Tasks;
using VehicleTracking.Common.MQ.Commands;
using VehicleTracking.Common.MQ.Events;

namespace VehicleTracking.API.Handlers
{
    public class StatusChangedHandler : IEventHandler<StatusChangedEvent>
    {
        private readonly IBusClient _busClient;
        private readonly ILogger<StatusChangedHandler> _logger;
        public StatusChangedHandler(IBusClient busClient, ILogger<StatusChangedHandler> logger)
        {
            _busClient = busClient;
            _logger = logger;
        }

        public async Task HandleAsync(StatusChangedEvent @event)
        {
            _logger.LogInformation($"Status changed: {@event.VehicleNumber}");

            try
            {
                await _busClient.PublishAsync(new UpdateVehicleCommand
                {
                    VehicleNumber = @event.VehicleNumber,
                    RegNr = @event.RegNr,
                    Status = @event.Status
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}

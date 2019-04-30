using Microsoft.Extensions.Logging;
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
        private readonly ILogger<StatusChangedHandler> _logger;
        public StatusChangedHandler(IBusClient busClient,
            ILogger<StatusChangedHandler> logger)
        {
            _busClient = busClient;
            _logger = logger;
        }

        public async Task HandleAsync(StatusChangeCommand command)
        {
            _logger.LogInformation($"Changing Status for vehicle: {command.VehicleNumber}-{command.RegNr}");
            try
            {
                await _busClient.PublishAsync(new StatusChangedEvent(command.VehicleNumber, command.RegNr, command.Status));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}

using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Threading.Tasks;
using VehicleTracking.Common.MQ.Commands;
using VehicleTracking.Common.MQ.Events;
using VehicleTracking.DataMS.Services;

namespace VehicleTracking.DataMS.Handlers
{
    public class UpdatedVehicleHandler : ICommandHandler<UpdateVehicleCommand>
    {

        private readonly IBusClient _busClient;
        private readonly IVehicleService _vehicleService;
        private readonly ILogger<UpdatedVehicleHandler> _logger;

        public UpdatedVehicleHandler(IBusClient busClient, 
            IVehicleService vehicleService,
            ILogger<UpdatedVehicleHandler> logger)
        {
            _busClient = busClient;
            _vehicleService = vehicleService;
            _logger = logger;
        }

        public async Task HandleAsync(UpdateVehicleCommand command)
        {
            _logger.LogInformation($"Updating Vehicle: {command.VehicleNumber}");

            try
            {
                await _vehicleService.UpdateStatus(command.VehicleNumber, command.RegNr, command.Status);
                await _busClient.PublishAsync(new UpdateVehicleEvent
                    (command.VehicleNumber, command.RegNr, command.Status));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

        }
    }
}
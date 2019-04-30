using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Threading.Tasks;
using VehicleTracking.API.Hubs;
using VehicleTracking.Common.MQ.Events;

namespace VehicleTracking.API.Handlers
{
    public class VehicleUpdatedHandler : IEventHandler<UpdateVehicleEvent>
    {
        private readonly IBusClient _busClient;
        private readonly ILogger<VehicleUpdatedHandler> _logger;
        private readonly IHubContext<VehicleHub> _vehHub;

        public VehicleUpdatedHandler(IBusClient busClient, 
            ILogger<VehicleUpdatedHandler> logger,
             IHubContext<VehicleHub> vehHub)
        {
            _busClient = busClient;
            _logger = logger;
            _vehHub = vehHub;
        }

        public async Task HandleAsync(UpdateVehicleEvent @event)
        {
            _logger.LogInformation($"Vehicle status updated: {@event.VehicleNumber}");
            try
            {
                await _vehHub.Clients.All.SendAsync("ReceiveStatusChanges", new
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

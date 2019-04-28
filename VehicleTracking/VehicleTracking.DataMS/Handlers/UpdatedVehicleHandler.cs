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

        public UpdatedVehicleHandler(IBusClient busClient, IVehicleService vehicleService)
        {
            _busClient = busClient;
            _vehicleService = vehicleService;
        }
        
        public async Task HandleAsync(UpdateVehicleCommand command)
        {
            Console.WriteLine($"Updating Vehicle: {command.VehicleNumber}");
            await _busClient.PublishAsync(new UpdateVehicleEvent(command.VehicleNumber, command.RegNr, command.Status));
            
            //Update vehicle status
            await _vehicleService.UpdateStatus(command.VehicleNumber, command.RegNr, command.Status);
        }
    }
}
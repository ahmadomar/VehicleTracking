using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RawRabbit;
using System.Threading.Tasks;
using VehicleTracking.API.Hubs;
using VehicleTracking.Common.MQ.Commands;

namespace VehicleTracking.API.Controllers
{
    [Route("[controller]")]
    public class StatusController : Controller
    {
        private readonly IBusClient _busClient;
        private readonly IHubContext<VehicleHub> _vehHub;
        public StatusController(IBusClient busClient, IHubContext<VehicleHub> vehHub)
        {
            _busClient = busClient;
            _vehHub = vehHub;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StatusChangeCommand command)
        {
            await _busClient.PublishAsync(command);

            await _busClient.PublishAsync(new UpdateVehicleCommand
            {
                VehicleNumber = command.VehicleNumber,
                RegNr = command.RegNr,
                Status = command.Status
            });

            await _vehHub.Clients.All.SendAsync("ReceiveStatusChanges", command);

            return Accepted($"status/{command.VehicleNumber + command.RegNr}");
        }
    }
}

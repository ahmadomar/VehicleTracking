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
        private readonly IHubContext<VehicleStatusHub> _chatHub;
        public StatusController(IBusClient busClient, IHubContext<VehicleStatusHub> chatHub)
        {
            _busClient = busClient;
            _chatHub = chatHub;
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

            await _chatHub.Clients.All.SendAsync("ReceiveStatusChanges", command);

            return Accepted($"status/{command.VehicleNumber + command.RegNr}");
        }
    }
}

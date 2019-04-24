using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using System.Threading.Tasks;
using VehicleTracking.Common.MQ.Commands;

namespace VehicleTracking.API.Controllers
{
    [Route("[controller]")]
    public class StatusController : Controller
    {
        private readonly IBusClient _busClient;
        public StatusController(IBusClient busClient)
        {
            _busClient = busClient;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StatusChange command)
        {
            await _busClient.PublishAsync(command);

            return Accepted($"status/{command.VehicleNumber}");
        }
    }
}

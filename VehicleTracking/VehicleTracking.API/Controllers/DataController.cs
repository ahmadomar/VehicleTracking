using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using System.Threading.Tasks;
using VehicleTracking.Common.MQ.Commands;

namespace VehicleTracking.API.Controllers
{
    [Route("[controller]")]
    public class DataController : Controller
    {
        private readonly IBusClient _busClient;
        public DataController(IBusClient busClient)
        {
            _busClient = busClient;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UpdateVehicleCommand command)
        {
            await _busClient.PublishAsync(command);

            return Accepted($"data/{command.VehicleNumber}");
        }
    }
}

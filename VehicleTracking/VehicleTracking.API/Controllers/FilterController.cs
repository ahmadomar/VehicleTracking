using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RawRabbit;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleTracking.API.Hubs;
using VehicleTracking.Common.MQ.Commands;
using VehicleTracking.Models;

namespace VehicleTracking.API.Controllers
{
    [Route("[controller]")]
    public class FilterController : Controller
    {
        private readonly IBusClient _busClient;
        private readonly IHubContext<VehicleHub> _vehHub;
        public FilterController(IBusClient busClient, IHubContext<VehicleHub> vehHub)

        {
            _busClient = busClient;
            _vehHub = vehHub;
        }


        [HttpGet]
        public IEnumerable<VehicleModel> Get(string filter, string status)
        {

            var client = new RestClient("https://localhost:5050/api/Filter");
            var request = new RestRequest(Method.GET);
            request.AddParameter("filter", filter);
            request.AddParameter("status", status);

            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<List<VehicleModel>>(response.Content);
            //await _busClient.PublishAsync(command);

            //await _vehHub.Clients.All.SendAsync("ReadFilterResults", "Test");

            //return Accepted($"filter/{command.VehicleNumber}");
        }
    }
}

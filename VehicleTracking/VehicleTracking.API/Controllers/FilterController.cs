using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RawRabbit;
using RestSharp;
using System.Collections.Generic;
using VehicleTracking.API.Hubs;
using VehicleTracking.Models;

namespace VehicleTracking.API.Controllers
{
    [Route("[controller]")]
    public class FilterController : Controller
    {
        private readonly IBusClient _busClient;
        private readonly IHubContext<VehicleHub> _vehHub;
        private readonly IConfiguration _iConfig;
        public FilterController(IBusClient busClient, IHubContext<VehicleHub> vehHub,
            IConfiguration iConfig)

        {
            _busClient = busClient;
            _vehHub = vehHub;
            _iConfig = iConfig;
        }


        [HttpGet]
        public IEnumerable<VehicleViewModel> Get(string filter, string status)
        {
            var filterApi = _iConfig.GetValue<string>("DataMS-Filter");

            var client = new RestClient(filterApi);
            var request = new RestRequest(Method.GET);
            request.AddParameter("filter", filter);
            request.AddParameter("status", status);

            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<List<VehicleViewModel>>(response.Content);
        }
    }
}
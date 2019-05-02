using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using VehicleTracking.Models;

namespace VehicleTracking.API.Helpers
{
    public interface IExternalRequest
    {
        List<VehicleViewModel> ReadAllVehicles(string filter = null, string status = null);
    }

    public class ExternalRequest : IExternalRequest
    {
        private readonly IConfiguration _configuration;
        public ExternalRequest(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<VehicleViewModel> ReadAllVehicles(string filter = null, string status = null)
        {
            var filterApi = _configuration.GetValue<string>("DataMS-Filter");

            var client = new RestClient(filterApi);
            var request = new RestRequest(Method.GET);
            request.AddParameter("filter", filter);
            request.AddParameter("status", status);

            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<List<VehicleViewModel>>(response.Content);
        }
    }
}

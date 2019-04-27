using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using VehicleTracking.Models;

namespace VehicleTracking.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var vehiclesList = ReadVehicles();
            return View(vehiclesList);
        }

        [HttpGet]
        public IActionResult Filter(string filter= null, string status = null)
        {
            var results = ReadVehicles(filter, status);
            return PartialView("_FilterResultView", results);
        }

        private List<VehicleModel> ReadVehicles(string filter = null, string status = null)
        {
            var client = new RestClient("https://localhost:5001/Filter");
            var request = new RestRequest(Method.GET);
            request.AddParameter("filter", filter);
            request.AddParameter("status", status);

            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<List<VehicleModel>>(response.Content);
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using VehicleTracking.Models;

namespace VehicleTracking.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _iConfig;
        public HomeController(IConfiguration iConfig)
        {
            _iConfig = iConfig;
        }

        public IActionResult Index()
        {
            ViewBag.VehicleHub = _iConfig.GetValue<string>("GatewayAPI-SignalRHub");

            var vehiclesList = ReadVehicles();
            if (vehiclesList == null)
                vehiclesList = new List<VehicleViewModel>();
            return View(vehiclesList);
        }

        [HttpGet]
        public IActionResult Filter(string filter= null, string status = null)
        {
            var vehiclesList = ReadVehicles(filter, status);
            if (vehiclesList == null)
                vehiclesList = new List<VehicleViewModel>();

            return PartialView("_FilterResultView", vehiclesList);
        }

        private List<VehicleViewModel> ReadVehicles(string filter = null, string status = null)
        {
            try
            {
                var filterApi = _iConfig.GetValue<string>("GatewayAPI-Filter");

                var client = new RestClient(filterApi);
                var request = new RestRequest(Method.GET);
                request.AddParameter("filter", filter);
                request.AddParameter("status", status);

                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<List<VehicleViewModel>>(response.Content);
            }
            catch
            {
                return new List<VehicleViewModel>();
            }
        }
    }
}

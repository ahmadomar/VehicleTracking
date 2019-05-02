using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VehicleTracking.API.Helpers;
using VehicleTracking.Models;

namespace VehicleTracking.API.Controllers
{
    [Route("[controller]")]
    public class FilterController : Controller
    {
        private readonly IExternalRequest _externalRequest;
        public FilterController(IExternalRequest externalRequest)
        {
            _externalRequest = externalRequest;
        }


        [HttpGet]
        public IEnumerable<VehicleViewModel> Get(string filter, string status)
        {
            return _externalRequest.ReadAllVehicles(filter, status);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VehicleTracking.DataMS.Services;
using VehicleTracking.Models;

namespace FilterTracking.DataMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase

    {
        private readonly IVehicleService _vehicleService;
        public FilterController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }


        // GET api/Filter
        [HttpGet]
        public ActionResult<List<VehicleModel>> Get(string filter = null, string status = null)
        {
            var vehicles = _vehicleService.GetAll().ToList();

            if (string.IsNullOrEmpty(filter) && string.IsNullOrEmpty(status))
                return vehicles;

            if (!string.IsNullOrEmpty(filter))
            {
                vehicles = vehicles.Where(v => v.VehicleNumber.Contains(filter)).ToList();
            }

            if (!string.IsNullOrEmpty(status))
            {
                vehicles = vehicles.Where(v => v.Status.Contains(status)).ToList();
            }
            return vehicles;
        }
        
    }
}

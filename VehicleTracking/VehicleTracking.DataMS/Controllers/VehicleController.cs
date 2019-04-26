using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VehicleTracking.DataMS.DataContext;
using VehicleTracking.DataMS.Services;
using VehicleTracking.Models;

namespace VehicleTracking.DataMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase

    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }


        // GET api/Vehicle
        [HttpGet]
        public IEnumerable<VehicleModel> Get()
        {
            return _vehicleService.GetAll();
        }
        
        // GET api/Vehicle/vehicleId
        [HttpGet("{vehicleId}")]
        public ActionResult<VehicleModel> Get(string vehicleId)
        {
            var vehicle = _vehicleService.GetAll().Where(v => v.VehicleNumber == vehicleId).FirstOrDefault();
            return vehicle;
        }
    }
}

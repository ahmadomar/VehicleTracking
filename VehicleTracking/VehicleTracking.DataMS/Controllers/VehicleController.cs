using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VehicleTracking.DataMS.DataContext;
using VehicleTracking.Models;

namespace VehicleTracking.DataMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase

    {
        private readonly VehicleDBContext _db;
        public VehicleController(VehicleDBContext vehicleDBContext)
        {
            _db = vehicleDBContext;
        }


        // GET api/Vehicle
        [HttpGet]
        public ActionResult<IEnumerable<VehicleModel>> Get()
        {
            return _db.Vehicles;
        }
        
        // GET api/Vehicle/vehicleId
        [HttpGet("{vehicleId}")]
        public ActionResult<VehicleModel> Get(string vehicleId)
        {
            var vehicle = _db.Find<VehicleModel>(vehicleId);
            return vehicle;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VehicleTracking.DataMS.DataContext;
using VehicleTracking.Models;

namespace FilterTracking.DataMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase

    {
        private readonly VehicleDBContext _db;
        public FilterController(VehicleDBContext db)
        {
            _db = db;
        }


        // GET api/Filter
        [HttpGet]
        public ActionResult<List<VehicleModel>> Get(string customerName = null, string status = null)
        {
            var vehicles = _db.Vehicles.ToList();

            if (string.IsNullOrEmpty(customerName) && string.IsNullOrEmpty(status))
                return vehicles;

            if (!string.IsNullOrEmpty(customerName))
            {
                //vehicles = vehicles.Where(v => v.Customer.Name.Contains(customerName)).ToList();
            }
            else
            {
                vehicles = vehicles.Where(v => v.Status.Contains(status)).ToList();
            }
            return vehicles;
        }
        
    }
}

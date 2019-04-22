using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VehicleTracking.DataMS.DataContext;
using VehicleTracking.Models;

namespace VehicleTracking.DataMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase

    {
        private readonly VehicleDBContext _db;
        public CustomerController(VehicleDBContext vehicleDBContext)
        {
            _db = vehicleDBContext;
        }


        // GET api/Customer
        [HttpGet]
        public ActionResult<IEnumerable<CustomerModel>> Get()
        {
            return _db.Customers;
        }

        // GET api/Customer/customerName
        [HttpGet("{name}")]
        public ActionResult<List<CustomerModel>> Get(string name)
        {
            return _db.Customers.Where(c => c.Name.Contains(name)).ToList();
        }
    }
}

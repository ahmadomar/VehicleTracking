using Microsoft.AspNetCore.Mvc;

namespace VehicleTracking.API.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return Content("Hello from Gateway API!");
        }
    }
}
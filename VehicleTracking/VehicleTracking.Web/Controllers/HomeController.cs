using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VehicleTracking.Models;

namespace VehicleTracking.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var data = VehicleStaticData.ReadData();
            var vehiclesList = data.SelectMany(v => v.Vehicles.ToList()).ToList();
            return View(vehiclesList);
        }
    }
}

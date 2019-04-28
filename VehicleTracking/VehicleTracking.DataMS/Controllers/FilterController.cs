using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IVehicleService _vehicleService;
        public FilterController(IMapper mapper, IVehicleService vehicleService)
        {
            _mapper = mapper;
            _vehicleService = vehicleService;
        }


        // GET api/Filter
        [HttpGet]
        public ActionResult<List<VehicleViewModel>> Get(string filter = null, string status = null)
        {
            var vehicles = _vehicleService.GetAll().ToList();

            var mappedVehicles = _mapper.Map<List<VehicleViewModel>>(vehicles);

            if (string.IsNullOrEmpty(filter) && string.IsNullOrEmpty(status))
                return mappedVehicles;

            if (!string.IsNullOrEmpty(filter))
            {
                mappedVehicles = mappedVehicles.Where(v => v.VehicleNumber.Contains(filter)
                                               || v.CustomerName.Contains(filter)).ToList();
            }

            if (!string.IsNullOrEmpty(status))
            {
                mappedVehicles = mappedVehicles.Where(v => v.Status.Contains(status)).ToList();
            }
            
            return mappedVehicles;
        }
        
    }
}
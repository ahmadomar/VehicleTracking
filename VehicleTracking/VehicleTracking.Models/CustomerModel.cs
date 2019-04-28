using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace VehicleTracking.Models
{
    public class CustomerModel
    {
        private readonly ILazyLoader _lazyLoader;
        public CustomerModel()
        {
        }
        public CustomerModel(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        private List<VehicleModel> _vehicles;

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual List<VehicleModel> Vehicles
        {
            get => _lazyLoader.Load(this, ref _vehicles);
            set => _vehicles = value;
        }
    }
}

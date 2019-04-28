using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace VehicleTracking.Models
{
    public class VehicleModel
    {
        private CustomerModel _customer;

        public VehicleModel()
        {
        }

        private VehicleModel(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private ILazyLoader LazyLoader { get; set; }

        [Key]
        public string VehicleNumber { get; set; }
        public string RegNr { get; set; }
        public string Status { get; set; }

        public int CustomerId { get; set; }
        public CustomerModel Customer
        {
            get => LazyLoader.Load(this, ref _customer);
            set => _customer = value;
        }
    }
}
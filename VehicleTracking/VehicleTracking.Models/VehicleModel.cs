using System;
using System.ComponentModel.DataAnnotations;

namespace VehicleTracking.Models
{
    public class VehicleModel
    {
        [Key]
        public string VehicleId { get; set; }
        public string RegNr { get; set; }
        public string Status { get; set; }

        public int CustomerId { get; set; }
        public virtual CustomerModel Customer { get; set; }
    }
}

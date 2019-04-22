using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehicleTracking.Models
{
    public class CustomerModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<VehicleModel> Vehicles { get; set; }
    }
}

namespace VehicleTracking.Common.MQ.Commands
{
    public class UpdateVehicleCommand : ICommand
    {
        public string VehicleNumber { get; set; }
        public string Status { get; set; }
    }
}

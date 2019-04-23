namespace VehicleTracking.Common.MQ.Commands
{
    public class UpdateVehicle : ICommand
    {
        public string VehicleNumber { get; set; }
        public string Status { get; set; }
    }
}

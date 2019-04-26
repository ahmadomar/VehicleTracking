namespace VehicleTracking.Common.MQ.Commands
{
    public class UpdateVehicleCommand : ICommand
    {
        public string RegNr { get; set; }
        public string VehicleNumber { get; set; }
        public string Status { get; set; }
    }
}

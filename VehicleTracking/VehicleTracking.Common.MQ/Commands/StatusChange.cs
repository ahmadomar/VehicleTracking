namespace VehicleTracking.Common.MQ.Commands
{
    public class StatusChange : ICommand
    {
        public string VehicleNumber { get; set; }
        public string Status { get; set; }
    }
}

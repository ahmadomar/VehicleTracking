namespace VehicleTracking.Common.MQ.Commands
{
    public class StatusChangeCommand : ICommand
    {
        public string VehicleNumber { get; set; }
        public string Status { get; set; }
    }
}

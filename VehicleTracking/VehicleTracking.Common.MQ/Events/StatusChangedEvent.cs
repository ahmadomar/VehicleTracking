namespace VehicleTracking.Common.MQ.Events
{
    public class StatusChangedEvent : IEvent
    {
        public string VehicleNumber { get; }
        public string Status { get; }


        protected StatusChangedEvent()
        {

        }

        public StatusChangedEvent(string vehicleNumber, string status)
        {
            VehicleNumber = vehicleNumber;
            Status = status;
        }
    }
}
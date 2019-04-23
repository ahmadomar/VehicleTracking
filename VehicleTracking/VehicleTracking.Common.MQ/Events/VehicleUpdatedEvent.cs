namespace VehicleTracking.Common.MQ.Events
{
    public class VehicleUpdatedEvent : IEvent
    {
        public string VehicleNumber { get; }

        protected VehicleUpdatedEvent()
        {

        }

        public VehicleUpdatedEvent(string vehicleNumber)
        {
            VehicleNumber = vehicleNumber;
        }
    }
}

namespace VehicleTracking.Common.MQ.Events
{
    public class UpdateVehicleEvent : IEvent
    {
        public string VehicleNumber { get; }

        protected UpdateVehicleEvent()
        {

        }

        public UpdateVehicleEvent(string vehicleNumber)
        {
            VehicleNumber = vehicleNumber;
        }
    }
}

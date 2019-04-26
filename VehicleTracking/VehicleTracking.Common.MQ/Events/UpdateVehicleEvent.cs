namespace VehicleTracking.Common.MQ.Events
{
    public class UpdateVehicleEvent : IEvent
    {
        public string RegNr { get; }
        public string VehicleNumber { get; }
        public string Status{ get; set; }

        protected UpdateVehicleEvent()
        {

        }

        public UpdateVehicleEvent(string vehicleNumber, string regNr, string status)
        {
            VehicleNumber = vehicleNumber;
            RegNr = regNr;
            Status = status;
        }
    }
}

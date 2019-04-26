namespace VehicleTracking.Common.MQ.Events
{
    public class StatusChangedEvent : IEvent
    {
        public string VehicleNumber { get; }
        public string RegNr { get; }
        public string Status { get; }


        protected StatusChangedEvent()
        {

        }

        public StatusChangedEvent(string vehicleNumber, string regNr, string status)
        {
            VehicleNumber = vehicleNumber;
            RegNr = regNr;
            Status = status;
        }
    }
}
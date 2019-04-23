namespace VehicleTracking.Common.MQ.Events
{
    public class StatusChangeRejected : IRejectedEvent
    {
        public string VehicleNumber { get; }
        public string Status { get; }

        public string Reason { get; }

        public string Code { get; }

        protected StatusChangeRejected()
        {

        }

        public StatusChangeRejected(string vehicleNumber, string status, string reason, string code)
        {
            VehicleNumber = vehicleNumber;
            Status = status;
            Reason = reason;
            Code = code;
        }
    }
}

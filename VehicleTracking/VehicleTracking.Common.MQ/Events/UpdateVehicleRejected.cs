namespace VehicleTracking.Common.MQ.Events
{
    public class UpdateVehicleRejected : IRejectedEvent
    {
        public string VehicleNumber { get; }

        public string Reason { get; }

        public string Code { get; }

        protected UpdateVehicleRejected()
        {

        }

        public UpdateVehicleRejected(string vehicleNumber, string reason, string code)
        {
            VehicleNumber = vehicleNumber;
            Reason = reason;
            Code = code;
        }
    }
}

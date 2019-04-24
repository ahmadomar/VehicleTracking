using System;
using System.Runtime.Serialization;

namespace VehicleTracking.Common.MQ.Exceptions
{
    public class VehicleException : Exception
    {
        public string Code { get; }
        public VehicleException(string code)
        {
            Code = code;
        }

        public VehicleException(string code, string message) : base(message)
        {
            Code = code;
        }

        public VehicleException(string message, Exception innerException, string code) : base(message, innerException)
        {
            Code = code;
        }

        protected VehicleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

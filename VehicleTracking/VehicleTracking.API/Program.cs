using VehicleTracking.Common.MQ.Events;
using VehicleTracking.Common.MQ.Services;

namespace VehicleTracking.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToEvent<StatusChangedEvent>()
                .SubscribeToEvent<UpdateVehicleEvent>()
                .Build()
                .Run();
        }
    }
}

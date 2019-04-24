using VehicleTracking.Common.MQ.Commands;
using VehicleTracking.Common.MQ.Services;

namespace VehicleTracking.StatusMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToCommand<StatusChangeCommand>()
                .Build()
                .Run();
        }
        
    }
}
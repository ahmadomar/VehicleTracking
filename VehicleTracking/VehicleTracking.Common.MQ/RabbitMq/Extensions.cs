using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Common;
using RawRabbit.vNext;
using System.Reflection;
using VehicleTracking.Common.MQ.Commands;
using VehicleTracking.Common.MQ.Events;

namespace VehicleTracking.Common.MQ.RabbitMq
{
    public static class Extensions
    {
        public static ISubscription WithCommandHandlerAsync<TCommand>(this IBusClient bus,
            ICommandHandler<TCommand> handler) where TCommand : ICommand
        {


            return bus.SubscribeAsync<TCommand>((message, context) =>
                handler.HandleAsync(message)
            , cfg => cfg
                 .WithQueue(q => q.WithName(GetQueueName<TCommand>())));
        }

        public static ISubscription WithEventHandlerAsync<TEvent>(this IBusClient bus,
            IEventHandler<TEvent> handler) where TEvent : IEvent
        {
            
            return bus.SubscribeAsync<TEvent>((message, context) =>
                handler.HandleAsync(message)
            , cfg => cfg
                 .WithQueue(q => q.WithName(GetQueueName<TEvent>())));
        }


        public static void AddRabbitMq(this IServiceCollection service, IConfiguration configuration)
        {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection("rabbitmq");
            section.Bind(options);

            var client = BusClientFactory.CreateDefault(options);
            
            service.AddSingleton<IBusClient>(_ => client);
        }

        private static string GetQueueName<T>()
        {
            return $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";
        }
    }
}
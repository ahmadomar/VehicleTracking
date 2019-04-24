using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.vNext;
using System.Reflection;
using System.Threading.Tasks;
using VehicleTracking.Common.MQ.Commands;
using VehicleTracking.Common.MQ.Events;

namespace VehicleTracking.Common.MQ.RabbitMq
{
    public static class Extensions
    {
        public static async Task<RawRabbit.Common.ISubscription> WithCommandHandlerAsync<TCommand>(this IBusClient bus,
            ICommandHandler<TCommand> handler) where TCommand : ICommand
        {
            return bus.SubscribeAsync<TCommand>(async (message, context) =>
                await handler.HandleAsync(message)
            , cfg => cfg
                .WithQueue(q => q.WithName(GetQueueName<TCommand>()))
            );

            //return bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
            //    ctx => ctx.UseConsumerConfiguration(cfg =>
            //    cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TCommand>()))));
        }

        public static async Task<RawRabbit.Common.ISubscription> WithEventHandlerAsync<TEvent>(this IBusClient bus,
            IEventHandler<TEvent> handler) where TEvent : IEvent
        {
            //return bus.SubscribeAsync<TEvent>(async (msg) =>
            //{
            //    await handler.HandleAsync(msg);
            //});

            return bus.SubscribeAsync<TEvent>(async (message, context) =>
                await handler.HandleAsync(message)
            , cfg => cfg
                .WithQueue(q => q.WithName(GetQueueName<TEvent>()))
            );

            //var x = await bus.SubscribeAsync<TEvent>(async (msg, context) =>
            //{
            //    handler.HandleAsync(msg);
            //}, ctx => ctx.WithQueue(q => q.WithName(GetQueueName<TEvent>())));


            //return bus.SubscribeAsync<TEvent>(async msg => handler.HandleAsync(msg), ctx => ctx.WithQueue(q => q.WithName(GetQueueName<TEvent>())));

            //return bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
            //    ctx => ctx.UseConsumerConfiguration(cfg =>
            //    cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))));
        }


        public static void AddRabbitMq(this IServiceCollection service, IConfiguration configuration)
        {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection("rabbitmq");
            section.Bind(options);

            var client = BusClientFactory.CreateDefault(options);


            //var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            //{
            //    ClientConfiguration = options
            //});

            service.AddSingleton<IBusClient>(_ => client);
        }

        private static string GetQueueName<T>()
        {
            return $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";
        }
       

    }
}

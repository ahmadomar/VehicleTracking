using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VehicleTracking.API.Handlers;
using VehicleTracking.API.Hubs;
using VehicleTracking.Common.MQ.Events;
using VehicleTracking.Common.MQ.RabbitMq;

namespace VehicleTracking.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddCors(options => options.AddPolicy("CorsPolicy",
                             builder => { builder.WithOrigins("https://localhost:44323")
                                 .AllowAnyHeader().AllowAnyMethod().AllowCredentials(); }));

            services.AddLogging();
            services.AddMvc();
            services.AddRabbitMq(Configuration);
            services.AddScoped<IEventHandler<StatusChangedEvent>, StatusChangedHandler>();
            services.AddScoped<IEventHandler<UpdateVehicleEvent>, VehicleUpdatedHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");

            app.UseSignalR(route =>
            {
                route.MapHub<VehicleHub>("/VehicleHub");
            });
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

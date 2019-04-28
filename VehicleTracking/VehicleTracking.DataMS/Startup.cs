using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VehicleTracking.Common.MQ.Commands;
using VehicleTracking.Common.MQ.RabbitMq;
using VehicleTracking.DataMS.DataContext;
using VehicleTracking.DataMS.Handlers;
using VehicleTracking.DataMS.Infrastructure;
using VehicleTracking.DataMS.Repositories;
using VehicleTracking.DataMS.Services;

namespace VehicleTracking.DataMS
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
            services.AddAutoMapper();

            services.AddDbContext<VehicleDBContext>(options => options.UseInMemoryDatabase("VehicleTrackingDB"), ServiceLifetime.Singleton);

            services.AddSingleton(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddSingleton(typeof(IVehicleRepository), typeof(VehicleRepository));
            services.AddSingleton(typeof(IVehicleService), typeof(VehicleService));

            services.AddMvc()
                            .AddJsonOptions(
                                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                            );
            services.AddRabbitMq(Configuration);
            services.AddScoped<ICommandHandler<UpdateVehicleCommand>, UpdatedVehicleHandler>();
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

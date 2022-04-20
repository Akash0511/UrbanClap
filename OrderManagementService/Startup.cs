using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Util;
using OpenTracing;
using OpenTracing.Util;

namespace OrderManagementService
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

            services.AddControllers();

            services.AddMassTransit(config => {
                config.UsingRabbitMq((ctx, cfg) => {
                    cfg.Host(Configuration["EventBus:HostAddress"]);
                    cfg.UseHealthCheck(ctx);
                });
            });
            services.AddMassTransitHostedService();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrderManagementService", Version = "v1" });
            });
            services.AddSingleton<IHostedService, ServiceDiscoveryHostedService>();

            services.AddSingleton<ITracer>(serviceProvider =>
            {
                Environment.SetEnvironmentVariable("JAEGER_SERVICE_NAME", "ordermanagementservice");
                Environment.SetEnvironmentVariable("JAEGER_AGENT_HOST", "jaeger-allinone");
                Environment.SetEnvironmentVariable("JAEGER_AGENT_PORT", "6831");
                Environment.SetEnvironmentVariable("JAEGER_SAMPLER_TYPE", "const");
                var loggerFactory = new LoggerFactory();
                var config = Jaeger.Configuration.FromEnv(loggerFactory);
                var tracer = config.GetTracer();
                GlobalTracer.Register(tracer);
                return tracer;
            });
            services.AddOpenTracing();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrderManagementService v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var bus = app.ApplicationServices.GetService<IBusControl>();
            var busHandle = TaskUtil.Await(() =>
            {
                return bus.StartAsync();
            });

            lifetime.ApplicationStopping.Register(() =>
            {
                busHandle.Stop();
            });
        }
    }
}

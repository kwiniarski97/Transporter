using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Transporter.Core.Repositories;
using Transporter.Infrastructure.IoC.Modules;
using Transporter.Infrastructure.Mappers;
using Transporter.Infrastructure.Repositories;
using Transporter.Infrastructure.Services;

namespace Transporter.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        
        public IContainer ApplicationContainer { get; private set; }


        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDriverRepository, LocalDriverRepository>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IUserRepository, LocalUserRepository>();
            //gdy constructor dostanie IUserService to wywola implementacje UserService
            services.AddScoped<IUserService, UserService>(); 
            services.AddSingleton(AutoMapperConfig.InitMapper());
            services.AddMvc();
            
            //autofac
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule<CommandModule>();
            ApplicationContainer = builder.Build();
            
            return new AutofacServiceProvider(ApplicationContainer);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory, IApplicationLifetime applicationLifetime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            applicationLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
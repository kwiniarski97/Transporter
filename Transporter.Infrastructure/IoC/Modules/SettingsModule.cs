using Autofac;
using Microsoft.Extensions.Configuration;
using Transporter.Infrastructure.Extensions;
using Transporter.Infrastructure.Settings;

namespace Transporter.Infrastructure.IoC.Modules
{
    /// <summary>
    /// Adds a settings module to project
    /// </summary>
    public class SettingsModule : Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>())
                .SingleInstance();

            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>())
                .SingleInstance();
        }
    }
}
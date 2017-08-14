using Microsoft.Extensions.Configuration;

namespace Transporter.Infrastructure.Extensions
{
    public static class SettingsExtension
    {
        /// <summary>
        /// For every section binds a class that has propername
        /// </summary>
        public static T GetSettings<T>(this IConfiguration configuration) where T : new()
        {
            var section = typeof(T).Name.Replace("Settings", string.Empty);
            var configurationValue = new T();
            configuration.GetSection(section).Bind(configurationValue);

            return configurationValue;
        }
    }
}
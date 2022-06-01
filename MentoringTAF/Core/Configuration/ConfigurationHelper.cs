using Core.Helpers;
using Microsoft.Extensions.Configuration;

namespace Core.Configuration
{
    public static class ConfigurationHelper
    {
        public static IConfigurationRoot GetConfigurationRoot()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public static T GetApplicationConfiguration<T>()
        {
            var configuration = ObjectFactory.Get<T>();
            var iConfig = GetConfigurationRoot();
            iConfig.GetSection(typeof(T).Name)
                .Bind(configuration);
            return configuration;
        }
    }
}

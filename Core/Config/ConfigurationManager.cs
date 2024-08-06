using Microsoft.Extensions.Configuration;

namespace Core
{
    public static class ConfigurationManager
    {
        private static IConfigurationRoot configuration;

        static ConfigurationManager()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Path.Combine("Config", "webdriverconfig.json"))
                .AddJsonFile(Path.Combine("Config", "appsettings.json"));

            configuration = builder.Build();
        }

        public static string GetBrowser()
        {
            return configuration["WebDriver:Browser"];
        }

        public static string GetEnvironmentUrl(string environmentName)
        {
            return configuration[$"Environments:{environmentName}"];
        }
    }
}

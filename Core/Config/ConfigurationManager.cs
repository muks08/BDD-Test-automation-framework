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
                .AddJsonFile(Path.Combine("Config", "webdriverconfig.json"));

            configuration = builder.Build();
        }

        public static string GetBrowser()
        {
            return configuration["WebDriver:Browser"];
        }
    }
}

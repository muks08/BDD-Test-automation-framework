using Core.Config.AppSettings;
using Core.Utils;

namespace Core.Configuration
{
    public sealed class ConfigManager
    {
        private static readonly ConfigManager instance = new();
        private readonly JsonReader jsonReader = new();
        private readonly AppSettings appSettings;

        static ConfigManager() { }

        private ConfigManager()
        {
            try
            {
                var configPath = "Config/AppSettings/appConfig.json";
                if (!File.Exists(configPath))
                {
                    throw new FileNotFoundException($"Configuration file not found: {configPath}");
                }

                appSettings = jsonReader.GetFileContent<AppSettings>(configPath);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to load configuration.", ex);
            }
        }

        public static AppSettings AppSettings
        {
            get
            {
                return instance.appSettings;
            }
        }
    }
}

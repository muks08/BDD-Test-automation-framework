using Core.Configuration;
using Core.Services;

namespace Core.Config
{
    public class EnvironmentPropertiesHelper
    {
        private static string EnvironmentFilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"allure-results/environment.properties");

        public static void CreateAllureEnvironmentFile()
        {
            try
            {
                string env = ConfigManager.AppSettings.Environment;
                string browser = ConfigManager.AppSettings.Browser;
                string baseUiUrl = ConfigManager.AppSettings.BaseUiUrl;
                string baseApiUrl = ConfigManager.AppSettings.BaseApiUrl;
                string swaggerUrl = ConfigManager.AppSettings.SwaggerUrl;

                var environmentVariables = new[]
                {
                    $"Enviroment={env}",
                    $"Base_UI_URL={baseUiUrl}",
                    $"Browser={browser}",
                    $"Base_API_URL={baseApiUrl}",
                    $"Swagger_URL={swaggerUrl}"
                };

                File.WriteAllLines(EnvironmentFilePath, environmentVariables);
                LoggerService.Info($"Allure environment file created successfully in {EnvironmentFilePath}");
            }
            catch (Exception ex)
            {
                LoggerService.Error(ex, $"Error creating Allure environment file.");
            }
        }
    }
}

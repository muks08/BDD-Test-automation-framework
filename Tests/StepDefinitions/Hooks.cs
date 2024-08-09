using Core;
using Core.Configuration;
using Core.Services;
using OpenQA.Selenium;

namespace Tests.UI.StepDefinitions
{
    [Binding]
    public class Hooks
    {
        public static IWebDriver Driver;
        public static string BaseUrl;

        [BeforeScenario]
        public void Setup()
        {
            Driver = WebDriverFactory.CreateDriver();
            BaseUrl = ConfigManager.AppSettings.BaseUiUrl;
        }

        [AfterScenario]
        public void TearDown()
        {
            Driver.Quit();
        }

        [AfterStep]
        public void TakeScreenshotAfterFailure(ScenarioContext scenarioContext)
        {
            if (scenarioContext.TestError != null) // Перевірка на фейл тесту
            {
                string screenshotPath = CaptureScreenshot(scenarioContext.ScenarioInfo.Title);
                LoggerService.Info($"Screenshot saved to {screenshotPath}");
            }
        }

        private string CaptureScreenshot(string scenarioTitle)
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();

            var projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var screenshotsDirectory = Path.Combine(projectDirectory, "Screenshots");

            if (!Directory.Exists(screenshotsDirectory))
            {
                Directory.CreateDirectory(screenshotsDirectory);
            }

            var screenshotFilePath = Path.Combine(screenshotsDirectory, $"{scenarioTitle}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            screenshot.SaveAsFile(screenshotFilePath);

            return screenshotFilePath;
        }
    }
}

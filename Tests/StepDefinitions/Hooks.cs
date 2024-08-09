using Core;
using Core.Configuration;
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
    }
}

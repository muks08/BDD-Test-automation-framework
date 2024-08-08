using OpenQA.Selenium;

namespace Services.PageObjects
{
    public class BasePage
    {
        protected readonly IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
    }
}

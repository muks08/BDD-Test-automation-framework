using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Services.UI.PageObjects
{
    public class BasePage
    {
        protected readonly IWebDriver _driver;
        protected readonly WebDriverWait _wait;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public IWebElement FindElement(By by)
        {
            return _driver.FindElement(by);
        }

        public void ClickElement(By by)
        {
            FindElement(by).Click();
        }

        public void EnterText(By by, string text)
        {
            var element = FindElement(by);
            element.Clear();
            element.SendKeys(text);
        }

        public void SubmitForm(By by)
        {
            var element = FindElement(by);
            element.Submit();
        }

        public string GetElementText(By by)
        {
            return FindElement(by).Text;
        }

        public bool IsElementDisplayed(By by)
        {
            try
            {
                return FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public string GetTitle()
        {
            _wait.Until(drv => !string.IsNullOrEmpty(drv.Title));
            return _driver.Title;
        }

        public string GetUrl()
        {
            return _driver.Url;
        }

        public void WaitForElementToBeVisible(By by, TimeSpan timeout)
        {
            var wait = new WebDriverWait(_driver, timeout);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }
    }
}

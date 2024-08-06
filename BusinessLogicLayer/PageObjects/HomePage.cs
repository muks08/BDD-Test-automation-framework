using OpenQA.Selenium;

namespace BusinessLogicLayer.PageObjects
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private const string Url = "https://www.google.com";

        private IWebElement SearchField => _driver.FindElement(By.Name("q"));

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl(Url);
        }

        public void EnterSearchTerm(string searchTerm)
        {
            SearchField.Clear();
            SearchField.SendKeys(searchTerm);
        }

        public void SubmitSearch()
        {
            SearchField.Submit();
        }

        public bool IsAt()
        {
            return _driver.Title.Contains("Google");
        }
    }
}

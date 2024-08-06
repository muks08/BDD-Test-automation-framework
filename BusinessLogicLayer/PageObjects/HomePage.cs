using OpenQA.Selenium;

namespace BusinessLogicLayer.PageObjects
{
    public class HomePage : BasePage
    {
        private IWebElement SearchField => _driver.FindElement(By.Name("q"));

        public HomePage(IWebDriver driver) : base(driver) { }

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

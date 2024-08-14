using OpenQA.Selenium;

namespace Services.UI.PageObjects
{
    public class HomePage : BasePage
    {
        private static readonly By SearchBox = By.Name("q");

        public HomePage(IWebDriver driver) : base(driver) { }

        public void EnterSearchTerm(string searchTerm)
        {
            EnterText(SearchBox, searchTerm);
        }

        public void SubmitSearch()
        {
            SubmitForm(SearchBox);
        }

        public bool IsTitleContains(string text)
        {
            return GetTitle().Contains(text);
        }
    }
}

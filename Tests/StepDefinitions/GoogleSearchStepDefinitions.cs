using Core;
using Core.Configuration;
using OpenQA.Selenium;
using Services.PageObjects;

namespace Tests.StepDefinitions
{
    [Binding]
    public class GoogleSearchStepDefinitions
    {
        private IWebDriver _driver;
        private HomePage _homePage;
        private readonly string _baseUrl;

        public GoogleSearchStepDefinitions() => _baseUrl = ConfigManager.AppSettings.BaseUiUrl;

        [BeforeScenario]
        public void Setup()
        {
            _driver = WebDriverFactory.CreateDriver();
            _homePage = new HomePage(_driver);
        }

        [AfterScenario]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Given(@"I have navigated to the Google home page")]
        public void GivenIHaveNavigatedToTheGoogleHomePage()
        {
            _homePage.NavigateTo(_baseUrl);
            _homePage.IsAt().Should().BeTrue("Google home page is not displayed.");
        }

        [When(@"I enter ""([^""]*)"" into the search field")]
        public void WhenIEnterIntoTheSearchField(string searchTerm)
        {
            _homePage.EnterSearchTerm(searchTerm);
        }

        [When(@"I submit the search")]
        public void WhenISubmitTheSearch()
        {
            _homePage.SubmitSearch();
        }

        [Then(@"the search results page is displayed")]
        public void ThenTheSearchResultsPageIsDisplayed()
        {
            _driver.Title.Should().Contain("Google Search", "Search results page is not displayed.");
        }
    }
}

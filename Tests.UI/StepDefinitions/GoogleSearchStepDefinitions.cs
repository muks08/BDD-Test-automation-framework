using OpenQA.Selenium;
using Services.UI.PageObjects;

namespace Tests.UI.StepDefinitions
{
    [Binding]
    public class GoogleSearchStepDefinitions
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly string _baseUrl;

        public GoogleSearchStepDefinitions()
        {
            _driver = Hooks.Driver;
            _baseUrl = Hooks.BaseUrl;
            _homePage = new HomePage(_driver);
        }

        [Given(@"I have navigated to the ""([^""]*)"" home page")]
        public void GivenIHaveNavigatedToTheHomePage(string google)
        {
            _homePage.NavigateTo(_baseUrl);
            _homePage.IsTitleContains(google).Should().BeTrue("Google home page is not displayed.");
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

        [Then(@"the search results page must contains ""([^""]*)""")]
        public void ThenTheSearchResultsPageMustContains(string specFlow)
        {
            _homePage.IsTitleContains(specFlow).Should().BeTrue("Google home page is not displayed.");
        }

        [Then(@"I want to fail test with ""([^""]*)""")]
        public void ThenIWantToFailTestWith(string text)
        {
            _homePage.IsTitleContains(text).Should().BeTrue("Google home page is not displayed.");
        }

    }
}

Feature: Google Search
  As a user
  I want to use Google search
  So that I can find information on the internet

  Scenario: Search for a term
    Given I have navigated to the Google home page
    When I enter "SpecFlow" into the search field
    And I submit the search
    Then the search results page is displayed

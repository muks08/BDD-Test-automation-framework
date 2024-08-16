Feature: Google Search
  As a user
  I want to use Google search
  So that I can find information on the internet

  Scenario Outline: Search for a term
    Given I have navigated to the "Google" home page
    When I enter "<searchTerm>" into the search field
    And I submit the search
    Then the search results page must contains "<searchTerm>"

        Examples:
      | searchTerm |
      | SpecFlow   |
      | Selenium    |
      | C#          |

  Scenario Outline: Search for a term with fail
    Given I have navigated to the "Google" home page
    When I enter "<searchTerm>" into the search field
    And I submit the search
    Then I want to fail test with "Some failed text"

        Examples:
      | searchTerm |
      | SpecFlow   |
      | Selenium    |
      | C#          |

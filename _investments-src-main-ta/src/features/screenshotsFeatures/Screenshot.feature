Feature: Compare screenshots

  Scenario: Verify framework work
    When User navigates to "https://www.wikipedia.org/"
    Then User compares screenshot of Central Links section ".central-featured" to "central-featured.png"
      And User compares screenshot of Search Button "homePage|searchButton" to "searchButton.png"

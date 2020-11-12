@companyLinkInProfile
Feature: Global Admin verifies that company name in his profile is clickable

  @regression
  Scenario: Global Admin opens his profile and clicks Company name
    #flow
    Given User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks Profile Icon "header|profileButton"
    And User clicks Profile Link "header|profileMenuFirstLastNameLabel" by executing script
    When User clicks Company Name "userProfilePage|companyLink"
    Then Company Name "companyProfilePage|companyName" text is equal to "CompAuto"
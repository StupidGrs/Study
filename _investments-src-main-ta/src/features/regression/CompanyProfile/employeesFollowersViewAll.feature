@companyProfileViewAll
Feature: Company Admin verifies View All in Company Profile

  @regression
  Scenario Outline: Company Admin opens Company Profile and clicks View All in <tab_name> tab
    #flow
    Given User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Directories tab "navigation|directoriesTab"
    And User clicks Tab "directoriesPage|searchTabs" with text "Companies"
    And User clicks Company name "directoriesPage|nameList" with text "Mercer"
    And User clicks <tab_name> tab "companyProfilePage|<selector>"
    When User clicks View All button "companyProfilePage|viewAllButton"
    Then Pop-up header "companyProfilePage|headerTitle" with text "<header_title>" is displayed
    And Header Info "companyProfilePage|headerInfo1" with text "Connect with other Mercer users" is displayed
    And Header Info "companyProfilePage|headerInfo2" with text "who are part of the Strategic Research Community." is displayed
    Examples:
    |tab_name |selector    |header_title|
    |Employees|employeesTab|Employees   |
    |Followers|followersTab|Followers   |
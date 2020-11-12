@companyResearches
Feature: Company Admin verifies Researches in Company Content page

  @regression
  Scenario Outline: Company Admin clicks Research link in Published tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_<role>" publishes "Research" with all fields and title "$researchTitle" with API
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User enters "$researchTitle" in Search Field "companyContent|searchField"
    When User clicks Content Link "companyContent|contentLink" with text "$researchTitle"
    Then Research Title "researchDetailsPage|title" with text "$researchTitle" is displayed
    #postcondition
    And User deletes "Research" with "Title" equal to "$researchTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |

  @regression @knownIssue
  Scenario Outline: Company Admin clicks Research link (submitted by COMPANY <role>) in Pending Approval tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_<role>" publishes "Research" with all fields and title "$researchTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User clicks Pending Approval tab "companyContent|pendingApprovalTab"
    And User enters "$researchTitle" in Search Field "companyContent|searchField"
    When User clicks Content Link "companyContent|contentLink" with text "$researchTitle"
    Then Research Title "researchDetailsPage|title" with text "$researchTitle" is displayed
    #postcondition
    And User deletes "Research" with "Title" equal to "$researchTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |
    #    Egle:2020-09-07 Role AUTHOR is not working and fix with SRC-2759

  @regression @knownIssue
  Scenario Outline: Company Admin clicks Research link (submitted by COMPANY <role>) in Draft tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_<role>" saves Draft "Research" with all fields and title "$researchTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User clicks Draft tab "companyContent|draftTab"
#    Need add search result Egle: 2020-09-08
    And User enters "$researchTitle" in Search Field "companyContent|searchField"
    When User clicks Content Link "companyContent|contentLink" with text "$researchTitle"
    Then Research Title "researchDetailsPage|title" with text "$researchTitle" is displayed
    #postcondition
    And User deletes "Research" with "Title" equal to "$researchTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |
#    Egle:2020-09-07 Role AUTHOR is not working and fix with SRC-2759

  @regression @knownIssue
  Scenario Outline: Company Admin clicks Research link (submitted by COMPANY <role>) in Rejected tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_<role>" publishes "Research" with all fields and title "$researchTitle" with API
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" rejects "Research" with title "$researchTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User clicks Rejected tab "companyContent|rejectedTab"
#    Need add search result Egle: 2020-09-08
    And User enters "$researchTitle" in Search Field "companyContent|searchField"
    When User clicks Content Link "companyContent|contentLink" with text "$researchTitle"
    Then Research Title "researchDetailsPage|title" with text "$researchTitle" is displayed
    #postcondition
    And User deletes "Research" with "Title" equal to "$researchTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |
    #    Egle:2020-09-07 Role AUTHOR is not working and fix with SRC-2759
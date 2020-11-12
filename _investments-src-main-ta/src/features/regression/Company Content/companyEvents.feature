@companyEvents
Feature: Company Admin verifies Events on Company Content page

  @regression
  Scenario Outline: Company Admin clicks Event link (submitted by COMPANY <role>) in Published tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    Then User "COMPANY_<role>" publishes "Event" with all fields and title "$eventTitle" with API
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" approves "Event" with title "$eventTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User selects Events option "companyContent|eventsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User enters "$eventTitle" in Search Field "companyContent|searchField"
    When User clicks Content Link "companyContent|contentLink" with text "$eventTitle"
    Then Event Title "eventDetailsPage|title" with text "$eventTitle" is displayed
    #postcondition
    And User deletes "Event" with "Title" equal to "$eventTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |

  @regression @knownIssue
  Scenario Outline: Company Admin clicks Event link (submitted by COMPANY <role>) in Pending Approval tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    Then User "COMPANY_<role>" publishes "Event" with all fields and title "$eventTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User selects Events option "companyContent|eventsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User clicks Pending Approval tab "companyContent|pendingApprovalTab"
    And User enters "$eventTitle" in Search Field "companyContent|searchField"
    When User clicks Content Link "companyContent|contentLink" with text "$eventTitle"
    Then Event Title "eventDetailsPage|title" with text "$eventTitle" is displayed
    #postcondition
    And User deletes "Event" with "Title" equal to "$eventTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |
    #    Egle:2020-09-07 Role AUTHOR is not working and fix with SRC-2759

  @regression @knownIssue
  Scenario Outline: Company Admin clicks Event link (submitted by COMPANY <role>) in Draft tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    Then User "COMPANY_<role>" saves Draft "Event" with all fields and title "$eventTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User selects Events option "companyContent|eventsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User clicks Draft tab "companyContent|draftTab"
    When User clicks Content Link "companyContent|contentLink" with text "$eventTitle"
    Then Event Title "eventDetailsPage|title" with text "$eventTitle" is displayed
    #postcondition
    And User deletes "Event" with "Title" equal to "$eventTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |
    #    Egle:2020-09-07 Role AUTHOR is not working and fix with SRC-2759

  @regression @knownIssue
  Scenario Outline: Company Admin clicks Event link (submitted by COMPANY <role>) in Rejected tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    Then User "COMPANY_<role>" publishes "Event" with all fields and title "$eventTitle" with API
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" rejects "Event" with title "$eventTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User selects Events option "companyContent|eventsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User clicks Rejected tab "companyContent|rejectedTab"
    When User clicks Content Link "companyContent|contentLink" with text "$eventTitle"
    Then Event Title "eventDetailsPage|title" with text "$eventTitle" is displayed
    #postcondition
    And User deletes "Event" with "Title" equal to "$eventTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |
#    Egle:2020-09-07 Role AUTHOR is not working and fix with SRC-2759
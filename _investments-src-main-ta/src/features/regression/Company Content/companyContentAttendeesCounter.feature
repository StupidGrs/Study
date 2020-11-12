Feature: Company Admin verifies Attendees Counter on Company Content page

  @regression
  Scenario Outline: Company Admin verifies Attendees Counter for Events in <tab_name> tab by clicking I'm Not Going
    #precondition
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    Then User "COMPANY_ADMIN" publishes "Event" with all fields and title "$eventTitle" with API
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" <action> "Event" with title "$eventTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User selects Events option "companyContent|eventsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User enters "$eventTitle" in Search Field "companyContent|searchField"
    And User clicks <tab_name> tab "companyContent|<selector>"
    Then Event Title "companyContent|postNameCell" with text "$eventTitle" is displayed
    And Attendees Counter "companyContent|attendeesCell" text is equal to "0"
    When User clicks Event "companyContent|contentLink" with text "$eventTitle"
    Then Event Title "eventDetailsPage|title" with text "$eventTitle" is displayed
    And User clicks I'm Not Going button "eventDetailsPage|attendButton"
    When User clicks Back button "eventDetailsPage|backButton" by executing script
    And User selects Events option "companyContent|eventsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User enters "$eventTitle" in Search Field "companyContent|searchField"
    And User clicks <tab_name> tab "companyContent|<selector>"
    Then Event Title "companyContent|postNameCell" with text "$eventTitle" is displayed
    And Attendees Counter "companyContent|attendeesCell" text is equal to "<number>"
    #postcondition
    And User deletes "Event" with "Title" equal to "$eventTitle"
    Examples:
      |action  |tab_name          |selector            |number|
      |approves|Published         |publishedTab        |1     |
      |rejects |Rejected          |rejectedTab         |1     |

  @regression
  Scenario Outline: Company Admin verifies Attendees Counter for Events in <tab_name> tab by clicking I'm not going
    #precondition
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    Then User "COMPANY_ADMIN" <action> "Event" with all fields and title "$eventTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User selects Events option "companyContent|eventsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User enters "$eventTitle" in Search Field "companyContent|searchField"
    And User clicks <tab_name> tab "companyContent|<selector>"
    Then Event Title "companyContent|postNameCell" with text "$eventTitle" is displayed
    And Attendees Counter "companyContent|attendeesCell" text is equal to "0"
    When User clicks Event "companyContent|contentLink" with text "$eventTitle"
    Then Event Title "eventDetailsPage|title" with text "$eventTitle" is displayed
    And User clicks I'm Not Going button "eventDetailsPage|attendButton"
    When User clicks Back button "eventDetailsPage|backButton" by executing script
    And User selects Events option "companyContent|eventsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User enters "$eventTitle" in Search Field "companyContent|searchField"
    And User clicks <tab_name> tab "companyContent|<selector>"
    Then Event Title "companyContent|postNameCell" with text "$eventTitle" is displayed
    And Attendees Counter "companyContent|attendeesCell" text is equal to "<number>"
    #postcondition
    And User deletes "Event" with "Title" equal to "$eventTitle"
    Examples:
      |action      |tab_name        |selector            |number|
      |publishes   |Pending Approval|pendingApprovalTab  |1     |
      |saves Draft |Draft           |draftTab            |1     |

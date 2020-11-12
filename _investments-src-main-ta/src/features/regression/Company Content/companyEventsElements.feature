@companyEventsElements
Feature: Company Admin verifies Events in different statuses on Company Content page

  @regression
  Scenario Outline: Company Admin verifies Events in Published tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers current date in format "M/D/YYYY" as "currentDate"
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
    Then Content Type "companyContent|contentTypeCell" with text "event" is displayed
    And Featured Icon "companyContent|featuredIcon" is not displayed
    And Ratings number "companyContent|ratingsCell" is not displayed
    And Attendees counter "companyContent|attendeesCell" with text "0" is displayed
    And Event Title "companyContent|postNameCell" with text "$eventTitle" is displayed
    And Event Date "companyContent|eventDateCell" text is equal to "$currentDate"
    And Views Counter "companyContent|viewsCounterCell" with text "0" is displayed
    And Clickthroughs Counter "companyContent|clickthroughsCell" with text "0" is displayed
    And Downloads Counter "companyContent|downloadsCell" is not displayed
    And Actions Button "companyContent|actionsButton" is not displayed
    #postcondition
    And User deletes "Event" with "Title" equal to "$eventTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |

  @regression
  Scenario Outline: Company Admin verifies Events in Pending Approval tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers current date in format "M/D/YYYY" as "currentDate"
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    Then User "COMPANY_<role>" publishes "Event" with all fields and title "$eventTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User selects Events option "companyContent|eventsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User clicks Pending Approval tab "companyContent|pendingApprovalTab"
    And User enters "$eventTitle" in Search Field "companyContent|searchField"
    Then Content Type "companyContent|contentTypeCell" with text "event" is displayed
    And Featured Icon "companyContent|featuredIcon" is not displayed
    And Ratings number "companyContent|ratingsCell" is not displayed
    And Attendees counter "companyContent|attendeesCell" with text "0" is displayed
    And Event Title "companyContent|postNameCell" with text "$eventTitle" is displayed
    And Event Date "companyContent|eventDateCell" text is equal to "$currentDate"
    And Views Counter "companyContent|viewsCounterCell" with text "0" is displayed
    And Clickthroughs Counter "companyContent|clickthroughsCell" with text "0" is displayed
    And Downloads Counter "companyContent|downloadsCell" is not displayed
    And Actions Button "companyContent|actionsButton" is not displayed
    #postcondition
    And User deletes "Event" with "Title" equal to "$eventTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |

  @regression
  Scenario Outline: Company Admin verifies Event in Draft tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers current date in format "M/D/YYYY" as "currentDate"
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    Then User "COMPANY_<role>" saves Draft "Event" with all fields and title "$eventTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User clicks Draft tab "companyContent|draftTab"
    And User enters "$eventTitle" in Search Field "companyContent|searchField"
    And User selects Events option "companyContent|eventsOption" from Content Type dropdown "companyContent|contentTypeField"
    Then Content Type "companyContent|contentTypeCell" with text "event" is displayed
    And Featured Icon "companyContent|featuredIcon" is not displayed
    And Ratings number "companyContent|ratingsCell" is not displayed
    And Attendees counter "companyContent|attendeesCell" with text "0" is displayed
    And Event Title "companyContent|postNameCell" with text "$eventTitle" is displayed
    And Event Date "companyContent|eventDateCell" text is equal to "$currentDate"
    And Views Counter "companyContent|viewsCounterCell" with text "0" is displayed
    And Clickthroughs Counter "companyContent|clickthroughsCell" with text "0" is displayed
    And Downloads Counter "companyContent|downloadsCell" is not displayed
    And Actions Button "companyContent|actionsButton" is not displayed
    #postcondtion
    And User deletes "Event" with "Title" equal to "$eventTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |

  @regression
  Scenario Outline: Company Admin verifies Event in Rejected tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers current date in format "M/D/YYYY" as "currentDate"
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    Then User "COMPANY_<role>" publishes "Event" with all fields and title "$eventTitle" with API
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" rejects "Event" with title "$eventTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User clicks Rejected tab "companyContent|rejectedTab"
    And User enters "$eventTitle" in Search Field "companyContent|searchField"
    And User selects Events option "companyContent|eventsOption" from Content Type dropdown "companyContent|contentTypeField"
    Then Content Type "companyContent|contentTypeCell" with text "event" is displayed
    And Featured Icon "companyContent|featuredIcon" is not displayed
    And Ratings number "companyContent|ratingsCell" is not displayed
    And Attendees counter "companyContent|attendeesCell" with text "0" is displayed
    And Event Title "companyContent|postNameCell" with text "$eventTitle" is displayed
    And Event Date "companyContent|eventDateCell" text is equal to "$currentDate"
    And Views Counter "companyContent|viewsCounterCell" with text "0" is displayed
    And Clickthroughs Counter "companyContent|clickthroughsCell" with text "0" is displayed
    And Downloads Counter "companyContent|downloadsCell" is not displayed
    And Actions Button "companyContent|actionsButton" is not displayed
    #postcondition
    And User deletes "Event" with "Title" equal to "$eventTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |
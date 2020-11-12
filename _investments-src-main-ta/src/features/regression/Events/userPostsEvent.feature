@events
Feature: Company Author checks Events statuses in his Posts

  @regression
  Scenario: Company Admin verifies Event Status - [Approval Pending]
    #precondition
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle_1"
    Then User "COMPANY_ADMIN" publishes "Event" with title "$eventTitle_1" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Profile button "header|profileButton"
    And User clicks Posts link "header|postsLink" by executing script
    When User selects Event option "userPostsPage|eventOption"
    Then Event title "userPostsPage|eventTitle" with text "$eventTitle_1" is displayed
    And Event status "userPostsPage|eventStatus" text is equal to "Approval Pending" on Event item "userPostsPage|listItem" with text "$eventTitle_1"
    And Title separator "userPostsPage|titleSeparator" is displayed
    And Views counter icon "userPostsPage|viewsIcon" is displayed
    And Views counter text "userPostsPage|viewsCounter" with text "Views 0" is displayed
    #postcondition
    And User deletes "Events" with "Title" equal to "$eventTitle_1"

  @regression
  Scenario: Company Admin verifies Event Status - [Approved]
    #precondition
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle_1"
    Then User "COMPANY_ADMIN" publishes "Event" with title "$eventTitle_1" with API
    When User "GLOBAL_ADMIN" logs in with API
    And User "GLOBAL_ADMIN" approves "Event" with title "$eventTitle_1" with API
    Then User remembers current date in format "MMM D, YYYY" as "currentDate"
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Profile button "header|profileButton"
    And User clicks Posts link "header|postsLink" by executing script
    When User selects Event option "userPostsPage|eventOption"
    Then Event title "userPostsPage|eventTitle" with text "$eventTitle_1" is displayed
    And Event status "userPostsPage|eventStatus" contains "Approved on" text on Event item "userPostsPage|listItem" with text "$eventTitle_1"
    And Event status "userPostsPage|eventStatus" contains "$currentDate" text on Event item "userPostsPage|listItem" with text "$eventTitle_1"
    #todo: verify Approval date
    #postcondition
    And User deletes "Events" with "Title" equal to "$eventTitle_1"

  @regression
  Scenario: Company Admin verifies Event Status - [Rejected]
    #precondition
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle_1"
    Then User "COMPANY_ADMIN" publishes "Event" with title "$eventTitle_1" with API
    When User "GLOBAL_ADMIN" logs in with API
    And User "GLOBAL_ADMIN" rejects "Event" with title "$eventTitle_1" with API
    Then User remembers current date in format "MMM D, YYYY" as "currentDate"
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Profile button "header|profileButton"
    And User clicks Posts link "header|postsLink" by executing script
    When User selects Event option "userPostsPage|eventOption"
    Then Event title "userPostsPage|eventTitle" with text "$eventTitle_1" is displayed
    And Event status "userPostsPage|eventStatus" contains "Rejected on" text on Event item "userPostsPage|listItem" with text "$eventTitle_1"
    And Event status "userPostsPage|eventStatus" contains "$currentDate" text on Event item "userPostsPage|listItem" with text "$eventTitle_1"
    #postcondition
    And User deletes "Events" with "Title" equal to "$eventTitle_1"

  @regression
  Scenario: Company Admin verifies Event Status - [Draft]
    #precondition
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle_1"
    Then User "COMPANY_ADMIN" saves Draft "Event" with title "$eventTitle_1" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Profile button "header|profileButton"
    And User clicks Posts link "header|postsLink" by executing script
    When User selects Event option "userPostsPage|eventOption"
    Then Event title "userPostsPage|eventTitle" with text "$eventTitle_1" is displayed
    And Event status "userPostsPage|eventStatus" text is equal to "Draft" on Event item "userPostsPage|listItem" with text "$eventTitle_1"
    #postcondition
    And User deletes "Events" with "Title" equal to "$eventTitle_1"
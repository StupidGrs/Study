@events
Feature: Verify different Event Statuses on User Posts page by Company Admin

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"

    @smoke
    @regression
    Scenario: Verify Event is available in User's Posts with status: Draft
        When User "COMPANY_ADMIN" saves Draft "Event" with title "$eventTitle" with API
        Then User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
#        And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "event"
        And User selects item "option" with text "event" from Select Content Type dropdown "userPostsPage|selectContentTypeDropdownOptionsList"

        Then User Event "userPostsPage|articleTitlesList" with text "$eventTitle" is displayed
        And Post Status "userPostsPage|articleStatusesList" with text "Draft" on Post "userPostsPage|articlesList" with text "$eventTitle" is displayed
        And User deletes "Events" with "Title" equal to "$eventTitle"

    @smoke
    @regression
    Scenario: Verify Event is available in User's Posts with status: Pending
        When User "COMPANY_ADMIN" publishes "Event" with title "$eventTitle" with API
        Then User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User selects item "option" with text "event" from Select Content Type dropdown "userPostsPage|selectContentTypeDropdownOptionsList"
        Then User Event "userPostsPage|articleTitlesList" with text "$eventTitle" is displayed
        And Post Status "userPostsPage|articleStatusesList" with text "Approval Pending" on Post "userPostsPage|articlesList" with text "$eventTitle" is displayed
        And User deletes "Events" with "Title" equal to "$eventTitle"

    @smoke
    @regression
    Scenario: Verify Event is available in User's Posts with status: Approved
        When User "COMPANY_ADMIN" publishes "Event" with title "$eventTitle" with API
        Then User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" approves "Event" with title "$eventTitle" with API
        And User remembers current date in format "MMM D, YYYY" as "currentDate"
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User selects item "option" with text "event" from Select Content Type dropdown "userPostsPage|selectContentTypeDropdownOptionsList"
        Then User Event "userPostsPage|articleTitlesList" with text "$eventTitle" is displayed
        And Post Status "userPostsPage|articleStatusesList" contains "Approved on" text on Post "userPostsPage|articlesList" with text "$eventTitle"
        And Post Status "userPostsPage|articleStatusesList" contains "$currentDate" text on Post "userPostsPage|articlesList" with text "$eventTitle"
        And User deletes "Events" with "Title" equal to "$eventTitle"

    @smoke
    @regression
    Scenario: Verify Event is available in User's Posts with status: Rejected
        When User "COMPANY_ADMIN" publishes "Event" with title "$eventTitle" with API
        Then User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" rejects "Event" with title "$eventTitle" with API
        And User remembers current date in format "MMM D, YYYY" as "currentDate"
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User selects item "option" with text "event" from Select Content Type dropdown "userPostsPage|selectContentTypeDropdownOptionsList"
        Then User Event "userPostsPage|articleTitlesList" with text "$eventTitle" is displayed
        And Post Status "userPostsPage|articleStatusesList" contains "Rejected on" text on Post "userPostsPage|articlesList" with text "$eventTitle"
        And Post Status "userPostsPage|articleStatusesList" contains "$currentDate" text on Post "userPostsPage|articlesList" with text "$eventTitle"
        And User deletes "Events" with "Title" equal to "$eventTitle"
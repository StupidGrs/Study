@events
Feature: [Company Admin] verifies Event availability on Events page

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"

    @smoke
    @regression
    Scenario: [Company Admin] Verify Event is NOT available on Events page with status: Draft
        When User "COMPANY_ADMIN" saves Draft "Event" with title "$eventTitle" with API
        Then User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        When User clicks Events tab "navigation|eventsTab"
        And User enters "$eventTitle" in Search field "eventsPage|searchEventsField"
        And User presses Enter key in Search field "eventsPage|searchEventsField"
        And User waits 2 seconds
        Then Event "eventsPage|titlesList" with text "$eventTitle" is not displayed
        And User deletes "Events" with "Title" equal to "$eventTitle"

    @smoke
    @regression
    Scenario: [Company Admin] Verify Event is NOT available on Events page with status: Pending
        When User "COMPANY_ADMIN" publishes "Event" with title "$eventTitle" with API
        Then User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        When User clicks Events tab "navigation|eventsTab"
        And User enters "$eventTitle" in Search field "eventsPage|searchEventsField"
        And User presses Enter key in Search field "eventsPage|searchEventsField"
        And User waits 2 seconds
        Then Event "eventsPage|titlesList" with text "$eventTitle" is not displayed
        And User deletes "Events" with "Title" equal to "$eventTitle"

    @smoke
    @regression
    Scenario: [Company Admin] Verify Event is available on Events page with status: Approved
        When User "COMPANY_ADMIN" publishes "Event" with title "$eventTitle" with API
        Then User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" approves "Event" with title "$eventTitle" with API
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        When User clicks Events tab "navigation|eventsTab"
        And User selects item "eventsPage|sortByDropdownFieldOptionsList" with text "Relevance" from Sorting dropdown "eventsPage|sortByDropdownField"
        And User enters "$eventTitle" in Search field "eventsPage|searchEventsField"
        And User presses Enter key in Search field "eventsPage|searchEventsField"
        Then Approved Event "eventsPage|titlesList" with text "$eventTitle" is displayed
        And User deletes "Events" with "Title" equal to "$eventTitle"

    @smoke
    @regression
    Scenario: [Company Admin] Verify Event is NOT available on Events page with status: Rejected
        When User "COMPANY_ADMIN" publishes "Event" with title "$eventTitle" with API
        Then User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" rejects "Event" with title "$eventTitle" with API
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Events tab "navigation|eventsTab"
        And User enters "$eventTitle" in Search field "eventsPage|searchEventsField"
        And User presses Enter key in Search field "eventsPage|searchEventsField"
        And User waits 2 seconds
        Then Event "eventsPage|titlesList" with text "$eventTitle" is not displayed
        And User deletes "Events" with "Title" equal to "$eventTitle"
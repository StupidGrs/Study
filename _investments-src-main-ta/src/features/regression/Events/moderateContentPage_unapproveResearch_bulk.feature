@events
@bulk
Feature: Global Admin unapproves "Event" with Bulk Unapprove button

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_Event_Bulk_Unapprove" with added unique Id as "eventTitle_1"
        And User remembers text "Test_Auto_Event_Bulk_Unapprove" with added unique Id as "eventTitle_3"
        And User remembers text "Test_Auto_Event_Bulk_Unapprove" with added unique Id as "eventTitle_2"
        And User "COMPANY_ADMIN" publishes "Event" with title "$eventTitle_1" with API
        And User "COMPANY_ADMIN" publishes "Event" with title "$eventTitle_2" with API
        And User "COMPANY_ADMIN" publishes "Event" with title "$eventTitle_3" with API
        When User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" approves "Event" with title "$eventTitle_1" with API
        And User "GLOBAL_ADMIN" approves "Event" with title "$eventTitle_2" with API
        And User "GLOBAL_ADMIN" approves "Event" with title "$eventTitle_3" with API
        When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks Settings button "header|settingsButton"
        And User clicks Moderate Content link "header|moderateContentLink" by executing script
        And User waits 3 seconds
        And User selects item "option" with text "Approved" from Article Status dropdown "contentListPage|articleStatusDropdown"
        And User selects item "option" with text "event" from Article Type dropdown "contentListPage|articleTypeDropdown"
        And User enters "Test_Auto_Event_Bulk_Unapprove" in Search Content field "contentListPage|searchContentField"
        And User waits for Table Row "contentListPage|tableRowsList" visibility within 3 seconds
        Then User clicks checkbox "contentListPage|tableRowCheckboxLabelsList" on the row "contentListPage|tableRowsList" with text "$eventTitle_1"
        And User clicks checkbox "contentListPage|tableRowCheckboxLabelsList" on the row "contentListPage|tableRowsList" with text "$eventTitle_2"
        And User clicks checkbox "contentListPage|tableRowCheckboxLabelsList" on the row "contentListPage|tableRowsList" with text "$eventTitle_3"

    @regression
    Scenario: Global Admin unapproves "Event" with Bulk Unapprove button
        When User clicks Bulk Unapprove button "contentListPage|bulkUnapproveButton"
        And User waits 3 seconds
        Then Table Row "contentListPage|tableRowsList" with text "$eventTitle_1" is not displayed
        And Table Row "contentListPage|tableRowsList" with text "$eventTitle_2" is not displayed
        And Table Row "contentListPage|tableRowsList" with text "$eventTitle_3" is not displayed
        When User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
        Then Table Row "contentListPage|tableRowsList" with text "$eventTitle_1" is displayed
        And Table Row "contentListPage|tableRowsList" with text "$eventTitle_2" is displayed
        And Table Row "contentListPage|tableRowsList" with text "$eventTitle_3" is displayed
        #postcondition
        And User deletes "Events" with "Title" equal to "$eventTitle_1"
        And User deletes "Events" with "Title" equal to "$eventTitle_2"
        And User deletes "Events" with "Title" equal to "$eventTitle_3"

    @regression
    Scenario: Global Admin unapproves "Event" with Bulk Unapprove button and verifies that they are NOT available in Events tab
        When User clicks Bulk Unapprove button "contentListPage|bulkUnapproveButton"
        Then User clicks Events tab "navigation|eventsTab"
        And User waits 3 seconds
        And User selects item "eventsPage|sortByDropdownFieldOptionsList" with text "Relevance" from Sorting dropdown "eventsPage|sortByDropdownField"
        When User enters "$eventTitle_1" in Search field "eventsPage|searchEventsField"
        And User presses Enter key in Search field "eventsPage|searchEventsField"
        Then Unapproved Event "eventsPage|eventTitleList" with text "$eventTitle_1" is not displayed
        When User clears text from Search field "eventsPage|searchEventsField"
        And User enters "$eventTitle_2" in Search field "eventsPage|searchEventsField"
        And User presses Enter key in Search field "eventsPage|searchEventsField"
        Then Unapproved Event "eventsPage|eventTitleList" with text "$eventTitle_2" is not displayed
        When User clears text from Search field "eventsPage|searchEventsField"
        And User enters "$eventTitle_3" in Search field "eventsPage|searchEventsField"
        And User presses Enter key in Search field "eventsPage|searchEventsField"
        Then Unapproved Event "eventsPage|eventTitleList" with text "$eventTitle_3" is not displayed
        #postcondition
        And User deletes "Events" with "Title" equal to "$eventTitle_1"
        And User deletes "Events" with "Title" equal to "$eventTitle_2"
        And User deletes "Events" with "Title" equal to "$eventTitle_3"


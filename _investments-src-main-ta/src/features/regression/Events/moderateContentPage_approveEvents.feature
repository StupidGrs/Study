@events
Feature: Global Admin approves Pending/Rejected Events with row action button Approve 

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
        Then User "COMPANY_ADMIN" publishes "Event" with title "$eventTitle" with API

    @regression
    Scenario: Global Admin approves Pending Event
        When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks Settings button "header|settingsButton"
        And User clicks Moderate Content link "header|moderateContentLink" by executing script
        And User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
        And User selects item "option" with text "event" from Article Type dropdown "contentListPage|articleTypeDropdown"
        And User enters "$eventTitle" in Search Content field "contentListPage|searchContentField"
        And User waits for Table Row "contentListPage|tableRowsList" with text "$eventTitle" visibility within 3 seconds
        When User clicks [Approve] button "contentListPage|tableRowApproveButtonsList"
        Then Table Row "contentListPage|tableRowsList" with text "$eventTitle" is not displayed
        When User selects item "option" with text "Approved" from Article Status dropdown "contentListPage|articleStatusDropdown"
        Then Table Row "contentListPage|tableRowsList" with text "$eventTitle" is displayed
        #postcondition
        And User deletes "Events" with "Title" equal to "$eventTitle"

    @regression
    Scenario: Global Admin approves Rejected Event
        When User "GLOBAL_ADMIN" logs in with API
        Then User "GLOBAL_ADMIN" rejects "Event" with title "$eventTitle" with API
        When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks Settings button "header|settingsButton"
        And User clicks Moderate Content link "header|moderateContentLink" by executing script
        And User selects item "option" with text "Rejected" from Article Status dropdown "contentListPage|articleStatusDropdown"
        And User selects item "option" with text "event" from Article Type dropdown "contentListPage|articleTypeDropdown"
        And User enters "$eventTitle" in Search Content field "contentListPage|searchContentField"
        And User waits for Table Row "contentListPage|tableRowsList" with text "$eventTitle" visibility within 3 seconds
        When User clicks [Approve] button "contentListPage|tableRowApproveButtonsList"
        Then Table Row "contentListPage|tableRowsList" with text "$eventTitle" is not displayed
        When User selects item "option" with text "Approved" from Article Status dropdown "contentListPage|articleStatusDropdown"
        Then Table Row "contentListPage|tableRowsList" with text "$eventTitle" is displayed
        #postcondition
        And User deletes "Events" with "Title" equal to "$eventTitle"
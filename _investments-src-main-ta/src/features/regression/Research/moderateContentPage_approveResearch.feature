@research
Feature: Global Admin approves Pending/Rejected Research with row action button Approve 

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
        Then User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle" with API

    @regression
    Scenario: Global Admin approves Pending Research
        When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks Settings button "header|settingsButton"
        And User clicks Moderate Content link "header|moderateContentLink" by executing script
        And User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
        And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
        And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
        And User waits for Table Row "contentListPage|tableRowsList" with text "$researchTitle" visibility within 3 seconds
        When User clicks [Approve] button "contentListPage|tableRowApproveButtonsList"
        Then Table Row "contentListPage|tableRowsList" with text "$researchTitle" is not displayed
        When User selects item "option" with text "Approved" from Article Status dropdown "contentListPage|articleStatusDropdown"
        Then Table Row "contentListPage|tableRowsList" with text "$researchTitle" is displayed
        #postcondition
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @regression
    Scenario: Global Admin approves Rejected Research
        When User "GLOBAL_ADMIN" logs in with API
        Then User "GLOBAL_ADMIN" rejects "Research" with title "$researchTitle" with API
        When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks Settings button "header|settingsButton"
        And User clicks Moderate Content link "header|moderateContentLink" by executing script
        And User selects item "option" with text "Rejected" from Article Status dropdown "contentListPage|articleStatusDropdown"
        And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
        And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
        And User waits for Table Row "contentListPage|tableRowsList" with text "$researchTitle" visibility within 3 seconds
        When User clicks [Approve] button "contentListPage|tableRowApproveButtonsList"
        Then Table Row "contentListPage|tableRowsList" with text "$researchTitle" is not displayed
        When User selects item "option" with text "Approved" from Article Status dropdown "contentListPage|articleStatusDropdown"
        Then Table Row "contentListPage|tableRowsList" with text "$researchTitle" is displayed
        #postcondition
        And User deletes "Research" with "Title" equal to "$researchTitle"
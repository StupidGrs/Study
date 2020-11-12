@research
Feature: Global Admin unapproves Approved Research with row action button Unapprove

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
        Then User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle" with API
        When User "GLOBAL_ADMIN" logs in with API
        Then User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API

    @regression
    Scenario: Global Admin unapproves Approved Research
        When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks Settings button "header|settingsButton"
        And User clicks Moderate Content link "header|moderateContentLink" by executing script
        And User selects item "option" with text "Approved" from Article Status dropdown "contentListPage|articleStatusDropdown"
        And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
        And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
        And User waits for Table Row "contentListPage|tableRowsList" with text "$researchTitle" visibility within 3 seconds
        When User clicks [Unapprove] button "contentListPage|unapproveButtonsList"
        Then Table Row "contentListPage|tableRowsList" with text "$researchTitle" is not displayed
        When User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
        Then Table Row "contentListPage|tableRowsList" with text "$researchTitle" is displayed
        #postcondition
        And User deletes "Research" with "Title" equal to "$researchTitle"
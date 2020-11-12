@research
Feature: [Global Admin] Verify Research availability on Moderate Content page depending on Research Status

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"

    @smoke
    @regression
    Scenario: Verify Research is NOT available on Moderate Content page with status: Draft
        When User "COMPANY_ADMIN" saves Draft "Research" with title "$researchTitle" with API
        Then User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks navigation menu item "header|settingsButton"
        And User clicks Moderate Content link "header|moderateContentLink" by executing script
        And User waits 2 seconds
        #check Draft Research is not available in "Waiting for approval" list
        And User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
        And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
        And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
        Then Table Row "contentListPage|tableRowsList" is not displayed
        When User clears text from Search Content field "contentListPage|searchContentField"
        And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
        #check Draft Research is not available in "Approved" list
        And User selects item "option" with text "Approved" from Article Status dropdown "contentListPage|articleStatusDropdown"
        Then Table Row "contentListPage|tableRowsList" is not displayed
        When User clears text from Search Content field "contentListPage|searchContentField"
        And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
        #check Draft Research is not available in "Rejected" list
        And User selects item "option" with text "Rejected" from Article Status dropdown "contentListPage|articleStatusDropdown"
        Then Table Row "contentListPage|tableRowsList" is not displayed
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @smoke
    @regression
    Scenario: Verify Research is available on Moderate Content page with status: Pending
        When User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle" with API
        Then User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        When User clicks navigation menu item "header|settingsButton"
        And User clicks Moderate Content link "header|moderateContentLink" by executing script
        And User waits 2 seconds
        And User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
        And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
        And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
        Then User waits for Table Row "contentListPage|tableRowsList" with text "$researchTitle" visibility within 3 seconds
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @smoke
    @regression
    Scenario: Verify Research is available on Moderate Content page with status: Approved
        When User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle" with API
        Then User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API
        When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks navigation menu item "header|settingsButton"
        And User clicks Moderate Content link "header|moderateContentLink" by executing script
        And User waits 2 seconds
        And User selects item "option" with text "Approved" from Article Status dropdown "contentListPage|articleStatusDropdown"
        And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
        And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
        Then User waits for Table Row "contentListPage|tableRowsList" with text "$researchTitle" visibility within 3 seconds
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @smoke
    @regression
    Scenario: Verify Research is available on Moderate Content page with status: Rejected
        When User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle" with API
        Then User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" rejects "Research" with title "$researchTitle" with API
        When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks navigation menu item "header|settingsButton"
        And User clicks Moderate Content link "header|moderateContentLink" by executing script
        And User waits 2 seconds
        And User selects item "option" with text "Rejected" from Article Status dropdown "contentListPage|articleStatusDropdown"
        And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
        And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
        Then User waits for Table Row "contentListPage|tableRowsList" with text "$researchTitle" visibility within 3 seconds
        And User deletes "Research" with "Title" equal to "$researchTitle"
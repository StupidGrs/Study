@news
Feature: [Global Admin] Verify News availability on Moderate Content page depending on News Status

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_News" with added unique Id as "newsTitle"

    @smoke
    @regression
    Scenario: Verify News is NOT available on Moderate Content page with status: Draft
        When User "COMPANY_ADMIN" saves Draft "News" with title "$newsTitle" with API
        Then User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks navigation menu item "header|settingsButton"
        And User clicks Moderate Content link "header|moderateContentLink" by executing script
        #check Draft News is not available in "Waiting for approval" list
        And User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
        And User selects item "option" with text "blog/news post" from Article Type dropdown "contentListPage|articleTypeDropdown"
        And User enters "$newsTitle" in Search Content field "contentListPage|searchContentField"
        Then Table Row "contentListPage|tableRowsList" is not displayed
        When User clears text from Search Content field "contentListPage|searchContentField"
        And User enters "$newsTitle" in Search Content field "contentListPage|searchContentField"
        #check Draft News is not available in "Approved" list
        And User selects item "option" with text "Approved" from Article Status dropdown "contentListPage|articleStatusDropdown"
        Then Table Row "contentListPage|tableRowsList" is not displayed
        When User clears text from Search Content field "contentListPage|searchContentField"
        And User enters "$newsTitle" in Search Content field "contentListPage|searchContentField"
        #check Draft News is not available in "Rejected" list
        And User selects item "option" with text "Rejected" from Article Status dropdown "contentListPage|articleStatusDropdown"
        Then Table Row "contentListPage|tableRowsList" is not displayed
        And User deletes "News" with "Title" equal to "$newsTitle"

    @smoke
    @regression
    Scenario: Verify News is available on Moderate Content page with status: Pending
        When User "COMPANY_ADMIN" publishes "News" with title "$newsTitle" with API
        Then User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        When User clicks navigation menu item "header|settingsButton"
        And User clicks Moderate Content link "header|moderateContentLink" by executing script
        And User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
        And User selects item "option" with text "blog/news post" from Article Type dropdown "contentListPage|articleTypeDropdown"
        And User enters "$newsTitle" in Search Content field "contentListPage|searchContentField"
        Then User waits for Table Row "contentListPage|tableRowsList" with text "$newsTitle" visibility within 3 seconds
        And User deletes "News" with "Title" equal to "$newsTitle"

    @smoke
    @regression
    Scenario: Verify News is available on Moderate Content page with status: Approved
        When User "COMPANY_ADMIN" publishes "News" with title "$newsTitle" with API
        Then User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" approves "News" with title "$newsTitle" with API
        When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks navigation menu item "header|settingsButton"
        And User clicks Moderate Content link "header|moderateContentLink" by executing script
        And User selects item "option" with text "Approved" from Article Status dropdown "contentListPage|articleStatusDropdown"
        And User selects item "option" with text "blog/news post" from Article Type dropdown "contentListPage|articleTypeDropdown"
        And User enters "$newsTitle" in Search Content field "contentListPage|searchContentField"
        Then User waits for Table Row "contentListPage|tableRowsList" with text "$newsTitle" visibility within 3 seconds
        And User deletes "News" with "Title" equal to "$newsTitle"

    @smoke
    @regression
    Scenario: Verify News is available on Moderate Content page with status: Rejected
        When User "COMPANY_ADMIN" publishes "News" with title "$newsTitle" with API
        Then User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" rejects "News" with title "$newsTitle" with API
        When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks navigation menu item "header|settingsButton"
        And User clicks Moderate Content link "header|moderateContentLink" by executing script
        And User selects item "option" with text "Rejected" from Article Status dropdown "contentListPage|articleStatusDropdown"
        And User selects item "option" with text "blog/news post" from Article Type dropdown "contentListPage|articleTypeDropdown"
        And User enters "$newsTitle" in Search Content field "contentListPage|searchContentField"
        Then User waits for Table Row "contentListPage|tableRowsList" with text "$newsTitle" visibility within 3 seconds
        And User deletes "News" with "Title" equal to "$newsTitle"
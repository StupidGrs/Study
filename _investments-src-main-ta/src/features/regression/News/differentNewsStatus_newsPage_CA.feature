@news
Feature: [Company Admin] verifies News availability on News page

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_News" with added unique Id as "newsTitle"

    @smoke
    @regression
    Scenario: [Company Admin] Verify News is NOT available on News page with status: Draft
        When User "COMPANY_ADMIN" saves Draft "News" with title "$newsTitle" with API
        Then User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        When User clicks News tab "navigation|newsTab"
        And User enters "$newsTitle" in Search field "newsPage|searchArticleAutocompleteField"
        And User presses Enter key in Search field "newsPage|searchArticleAutocompleteField"
        And User waits 2 seconds
        Then News Item "newsPage|titlesList" with text "$newsTitle" is not displayed
        And User deletes "News" with "Title" equal to "$newsTitle"

    @smoke
    @regression
    Scenario: [Company Admin] Verify News is NOT available on News page with status: Pending
        When User "COMPANY_ADMIN" publishes "News" with title "$newsTitle" with API
        Then User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        When User clicks News tab "navigation|newsTab"
        And User enters "$newsTitle" in Search field "newsPage|searchArticleAutocompleteField"
        And User presses Enter key in Search field "newsPage|searchArticleAutocompleteField"
        And User waits 2 seconds
        Then News Item "newsPage|titlesList" with text "$newsTitle" is not displayed
        And User deletes "News" with "Title" equal to "$newsTitle"

    @smoke
    @regression
    Scenario: [Company Admin] Verify News is available on News page with status: Approved
        When User "COMPANY_ADMIN" publishes "News" with title "$newsTitle" with API
        Then User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" approves "News" with title "$newsTitle" with API
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks News tab "navigation|newsTab"
        And User selects item "newsPage|sortByDropdownFieldOptionsList" with text "Relevance" from Sorting dropdown "newsPage|sortByDropdownField"
        And User enters "$newsTitle" in Search field "newsPage|searchArticleAutocompleteField"
        And User presses Enter key in Search field "newsPage|searchArticleAutocompleteField"
        Then Approved News "newsPage|titlesList" with text "$newsTitle" is displayed
        And User deletes "News" with "Title" equal to "$newsTitle"

    @smoke
    @regression
    Scenario: [Company Admin] Verify News is NOT available on News page with status: Rejected
        When User "COMPANY_ADMIN" publishes "News" with title "$newsTitle" with API
        Then User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" rejects "News" with title "$newsTitle" with API
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks News tab "navigation|newsTab"
        And User selects item "newsPage|sortByDropdownFieldOptionsList" with text "Relevance" from Sorting dropdown "newsPage|sortByDropdownField"
        And User enters "$newsTitle" in Search field "newsPage|searchArticleAutocompleteField"
        And User presses Enter key in Search field "newsPage|searchArticleAutocompleteField"
        And User waits 2 seconds
        Then News Item "newsPage|titlesList" with text "$newsTitle" is not displayed
        And User deletes "News" with "Title" equal to "$newsTitle"
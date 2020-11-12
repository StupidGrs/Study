@research
Feature: [Global Admin] verifies Research availability on Research page

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"

    @smoke
    @regression
    Scenario: [Global Admin] Verify Research is NOT available on Researches page with status: Draft
        When User "COMPANY_ADMIN" saves Draft "Research" with title "$researchTitle" with API
        Then User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        When User clicks Research tab "navigation|researchTab"
        And User enters "$researchTitle" in Search field "researchPage|searchArticleAutocompleteField"
        And User presses Enter key in Search field "researchPage|searchArticleAutocompleteField"
        And User waits 2 seconds
        Then Research "researchPage|titlesList" with text "$researchTitle" is not displayed
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @smoke
    @regression
    Scenario: [Global Admin] Verify Research is NOT available on Researches page with status: Pending
        When User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle" with API
        Then User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        When User clicks Research tab "navigation|researchTab"
        And User enters "$researchTitle" in Search field "researchPage|searchArticleAutocompleteField"
        And User presses Enter key in Search field "researchPage|searchArticleAutocompleteField"
        And User waits 2 seconds
        Then Research "researchPage|titlesList" with text "$researchTitle" is not displayed
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @smoke
    @regression
    Scenario: [Global Admin] Verify Research is available on Researches page with status: Approved
        When User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle" with API
        Then User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API
        When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks Research tab "navigation|researchTab"
        And User selects item "researchPage|sortByDropdownFieldOptionsList" with text "Relevance" from Sorting dropdown "researchPage|sortByDropdownField"
        And User enters "$researchTitle" in Search field "researchPage|searchArticleAutocompleteField"
        And User presses Enter key in Search field "researchPage|searchArticleAutocompleteField"
        Then Approved Research "researchPage|titlesList" with text "$researchTitle" is displayed
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @smoke
    @regression
    Scenario: [Global Admin] Verify Research is NOT available on Researches page with status: Rejected
        When User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle" with API
        Then User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" rejects "Research" with title "$researchTitle" with API
        When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks Research tab "navigation|researchTab"
        And User enters "$researchTitle" in Search field "researchPage|searchArticleAutocompleteField"
        And User presses Enter key in Search field "researchPage|searchArticleAutocompleteField"
        And User waits 2 seconds
        Then Research "researchPage|titlesList" with text "$researchTitle" is not displayed
        And User deletes "Research" with "Title" equal to "$researchTitle"
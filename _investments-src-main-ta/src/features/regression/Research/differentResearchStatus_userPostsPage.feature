@research
Feature: Verify different Research Statuses on User Posts page by Company Admin

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"

    @smoke
    @regression
    Scenario: Verify Research is available in User's Posts with status: Draft
        When User "COMPANY_ADMIN" saves Draft "Research" with title "$researchTitle" with API
        Then User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "research post"
        Then User Post "userPostsPage|articleTitlesList" with text "$researchTitle" is displayed
        And Post Status "userPostsPage|articleStatusesList" with text "Draft" on Post "userPostsPage|articlesList" with text "$researchTitle" is displayed
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @smoke
    @regression
    Scenario: Verify Research is available in User's Posts with status: Pending
        When User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle" with API
        Then User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "research post"
        Then User Post "userPostsPage|articleTitlesList" with text "$researchTitle" is displayed
        And Post Status "userPostsPage|articleStatusesList" with text "Approval Pending" on Post "userPostsPage|articlesList" with text "$researchTitle" is displayed
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @smoke
    @regression
    Scenario: Verify Research is available in User's Posts with status: Approved
        When User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle" with API
        Then User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API
        And User remembers current date in format "MMM D, YYYY" as "currentDate"
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "research post"
        Then User Post "userPostsPage|articleTitlesList" with text "$researchTitle" is displayed
        And Post Status "userPostsPage|articleStatusesList" contains "Approved on" text on Post "userPostsPage|articlesList" with text "$researchTitle"
        And Post Status "userPostsPage|articleStatusesList" contains "$currentDate" text on Post "userPostsPage|articlesList" with text "$researchTitle"
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @smoke
    @regression
    Scenario: Verify Research is available in User's Posts with status: Rejected
        When User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle" with API
        Then User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" rejects "Research" with title "$researchTitle" with API
        And User remembers current date in format "MMM D, YYYY" as "currentDate"
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "research post"
        Then User Post "userPostsPage|articleTitlesList" with text "$researchTitle" is displayed
        And Post Status "userPostsPage|articleStatusesList" contains "Rejected on" text on Post "userPostsPage|articlesList" with text "$researchTitle"
        And Post Status "userPostsPage|articleStatusesList" contains "$currentDate" text on Post "userPostsPage|articlesList" with text "$researchTitle"
        And User deletes "Research" with "Title" equal to "$researchTitle"
@news
Feature: Verify different News  Statuses on User Posts page by Company Admin

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_News" with added unique Id as "newsTitle"

    @smoke
    @regression
    Scenario: Verify News  is available in User's Posts with status: Draft
        When User "COMPANY_ADMIN" saves Draft "News" with title "$newsTitle" with API
        Then User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
#        And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "blog/news post"
        And User selects item "option" with text "blog/news post" from Select Content Type dropdown "userPostsPage|selectContentTypeDropdownOptionsList"
        Then User Post "userPostsPage|articleTitlesList" with text "$newsTitle" is displayed
        And Post Status "userPostsPage|articleStatusesList" with text "Draft" on Post "userPostsPage|articlesList" with text "$newsTitle" is displayed
        And User deletes "News" with "Title" equal to "$newsTitle"

    @smoke
    @regression
    Scenario: Verify News  is available in User's Posts with status: Pending
        When User "COMPANY_ADMIN" publishes "News" with title "$newsTitle" with API
        Then User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
#        And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "blog/news post"
        And User selects item "option" with text "blog/news post" from Select Content Type dropdown "userPostsPage|selectContentTypeDropdownOptionsList"
        Then User Post "userPostsPage|articleTitlesList" with text "$newsTitle" is displayed
        And Post Status "userPostsPage|articleStatusesList" with text "Approval Pending" on Post "userPostsPage|articlesList" with text "$newsTitle" is displayed
        And User deletes "News" with "Title" equal to "$newsTitle"

    @smoke
    @regression
    Scenario: Verify News  is available in User's Posts with status: Approved
        When User "COMPANY_ADMIN" publishes "News" with title "$newsTitle" with API
        Then User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" approves "News" with title "$newsTitle" with API
        And User remembers current date in format "MMM D, YYYY" as "currentDate"
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
#        And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "blog/news post"
        And User selects item "option" with text "blog/news post" from Select Content Type dropdown "userPostsPage|selectContentTypeDropdownOptionsList"
        Then User Post "userPostsPage|articleTitlesList" with text "$newsTitle" is displayed
        And Post Status "userPostsPage|articleStatusesList" contains "Approved on" text on Post "userPostsPage|articlesList" with text "$newsTitle"
        And Post Status "userPostsPage|articleStatusesList" contains "$currentDate" text on Post "userPostsPage|articlesList" with text "$newsTitle"
        And User deletes "News" with "Title" equal to "$newsTitle"

    @smoke
    @regression
    Scenario: Verify News  is available in User's Posts with status: Rejected
        When User "COMPANY_ADMIN" publishes "News" with title "$newsTitle" with API
        Then User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" rejects "News" with title "$newsTitle" with API
        And User remembers current date in format "MMM D, YYYY" as "currentDate"
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
#        And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "blog/news post"
        And User selects item "option" with text "blog/news post" from Select Content Type dropdown "userPostsPage|selectContentTypeDropdownOptionsList"
        Then User Post "userPostsPage|articleTitlesList" with text "$newsTitle" is displayed
        And Post Status "userPostsPage|articleStatusesList" contains "Rejected on" text on Post "userPostsPage|articlesList" with text "$newsTitle"
        And Post Status "userPostsPage|articleStatusesList" contains "$currentDate" text on Post "userPostsPage|articlesList" with text "$newsTitle"
        And User deletes "News" with "Title" equal to "$newsTitle"
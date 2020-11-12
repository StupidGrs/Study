@companyProfile
Feature: Verify content published by Company's Users is tracked on Company Recently Published Page

    @research
    #@events
    @regression
    Scenario Outline: Verify [Publish <resource>] action made by [<user>] is tracked on Company Recently Published Page only after Admin Approval
        When User "<user>" logs in with API
        And User remembers text "Test_Auto" with added unique Id as "resourceTitle"
        And User "<user>" publishes "<resource>" with title "$resourceTitle" with API
        And User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks [Directories] Tab "navigation|directoriesTab"
        And User clicks Tab "directoriesPage|searchTabs" with text "Companies"
        And User enters "CompAuto" in [Search] field "directoriesPage|searchField"
        And User clicks Company Title "directoriesPage|nameList" with text equal to "CompAuto"
        Then User clicks Tab "companyProfilePage|mainTabsList" with text "Recently Published"
        #Check resource is not displayed in recently published list
        When User enters "$resourceTitle" in Article Search field "companyProfilePage|searchField"
        And User waits 2 seconds
        Then Resource Title "companyProfilePage|articleTitleList" with text "$resourceTitle" is not displayed
        #Approve resource by Global Admin
        When User "GLOBAL_ADMIN" logs in with API
        Then User "GLOBAL_ADMIN" approves "<resource>" with title "$resourceTitle" with API
        And User refreshes page
        #Check resource is displayed in recently published list
        When User clicks Tab "companyProfilePage|mainTabsList" with text "Recently Published"
        And User enters "$resourceTitle" in Article Search field "companyProfilePage|searchField"
        And User waits 2 seconds
        Then Resource Title "companyProfilePage|articleTitleList" with text "$resourceTitle" is displayed
        #delete resource
        And User deletes "<resource>" with "Title" equal to "$resourceTitle"
        Examples:
            | user          | resource |
            | GLOBAL_ADMIN  | research |
            | COMPANY_ADMIN | research |
            # | GLOBAL_ADMIN  | event    |
            # | COMPANY_ADMIN | event    |

    @research
    #@events
    @regression
    Scenario Outline: Verify [Save Draft - <resource>] action made by [<user>] is NOT tracked on Company Recently Published Page
        When User "<user>" logs in with API
        And User remembers text "Test_Auto" with added unique Id as "resourceTitle"
        And User "<user>" saves Draft "<resource>" with title "$resourceTitle" with API
        And User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks [Directories] Tab "navigation|directoriesTab"
        And User clicks Tab "directoriesPage|searchTabs" with text "Companies"
        And User enters "CompAuto" in [Search] field "directoriesPage|searchField"
        And User clicks Company Title "directoriesPage|nameList" with text equal to "CompAuto"
        And User clicks Tab "companyProfilePage|mainTabsList" with text "Recently Published"
        And User enters "$resourceTitle" in Article Search field "companyProfilePage|searchField"
        And User waits 2 seconds
        Then Resource Title "companyProfilePage|articleTitleList" with text "$resourceTitle" is not displayed
        #delete resource
        And User deletes "<resource>" with "Title" equal to "$resourceTitle"
        Examples:
            | user          | resource |
            | GLOBAL_ADMIN  | research |
            | COMPANY_ADMIN | research |
            # | GLOBAL_ADMIN  | event    |
            # | COMPANY_ADMIN | event    |

    @research
    #@events
    @regression
    Scenario Outline: Verify [Resubmit rejected <resource>] action made by [<user>] is tracked on Company Recently Published Page only after Admin Approval
        When User "<user>" logs in with API
        And User remembers text "Test_Auto" with added unique Id as "resourceTitle"
        When User "<user>" publishes "<resource>" with title "$resourceTitle" with API
        And User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" rejects "<resource>" with title "$resourceTitle" with API
        And User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks [Directories] Tab "navigation|directoriesTab"
        And User clicks Tab "directoriesPage|searchTabs" with text "Companies"
        And User enters "CompAuto" in [Search] field "directoriesPage|searchField"
        And User clicks Company Title "directoriesPage|nameList" with text equal to "CompAuto"
        And User clicks Tab "companyProfilePage|mainTabsList" with text "Recently Published"
        #Check resource is not displayed in recently published list
        And User enters "$resourceTitle" in Article Search field "companyProfilePage|searchField"
        And User waits 2 seconds
        Then Resource Title "companyProfilePage|articleTitleList" with text "$resourceTitle" is not displayed
        When User "GLOBAL_ADMIN" approves "<resource>" with title "$resourceTitle" with API
        And User refreshes page
        #Check resource is displayed in recently published list
        When User clicks Tab "companyProfilePage|mainTabsList" with text "Recently Published"
        And User enters "$resourceTitle" in Article Search field "companyProfilePage|searchField"
        And User waits 2 seconds
        Then Resource Title "companyProfilePage|articleTitleList" with text "$resourceTitle" is displayed
        #delete resource
        And User deletes "<resource>" with "Title" equal to "$resourceTitle"
        Examples:
            | user          | resource |
            | GLOBAL_ADMIN  | research |
            | COMPANY_ADMIN | research |
            # | GLOBAL_ADMIN  | event    |
            # | COMPANY_ADMIN | event    |
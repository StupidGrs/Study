@userProfile
Feature: Verify User actions are tracked on Recent Activity Page

    @research
    @events
    @regression
    @knownIssue @SRC-1564
    Scenario Outline: Verify [Publish <resource>] action made by [<user>] is tracked on User's Recent Activity Page only after Admin Approval
        When User "<user>" logs in with API
        And User remembers text "Test_Auto" with added unique Id as "resourceTitle"
        And User "<user>" publishes "<resource>" with title "$resourceTitle" with API
        And User logs in as "<user>" on "LOGIN_PAGE"
        And User clicks Profile Icon "header|profileButton"
        And User clicks User Name "header|profileMenuFirstLastNameLabel" by executing script
        #Check resource is not displayed in recent activity
        Then Recent Activity section "userProfilePage|recentActivitySection" is displayed
        And Resource Title "userProfilePage|activityResourceTitlesList" with text "$resourceTitle" is not displayed
        #Approve resource by Global Admin
        When User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" approves "<resource>" with title "$resourceTitle" with API
        And User refreshes page
        #Check resource is displayed in recent activity
        Then Resource Title "userProfilePage|activityResourceTitlesList" with text "$resourceTitle" is displayed
        And Activity Type "userProfilePage|activityTypesList" with text "submitted <resource>" on Activity Row "userProfilePage|recentActivityRowItemsList" with text "$resourceTitle" is displayed
        # verification for the full text "less than a minute ago" fails on STAGE, because it is very slow
        #And Activity Time "userProfilePage|activityTimeList" with text "less than a minute ago" on Activity Row "userProfilePage|recentActivityRowItemsList" with text "$resourceTitle" is displayed
        And Activity Time "userProfilePage|activityTimeList" with text "ago" on Activity Row "userProfilePage|recentActivityRowItemsList" with text "$resourceTitle" is displayed
        And Activity Icon "userProfilePage|activityIconsList" on Activity Row "userProfilePage|recentActivityRowItemsList" with text "$resourceTitle" is displayed
        #delete resource
        And User deletes "<resource>" with "Title" equal to "$resourceTitle"
        Examples:
            | user          | resource |
            | GLOBAL_ADMIN  | research |
            | GLOBAL_ADMIN  | event    |
            | COMPANY_ADMIN | research |
            | COMPANY_ADMIN | event    |

    @research
    @events
    @regression
    Scenario Outline: Verify [Save Draft - <resource>] action made by [<user>] is NOT tracked on User's Recent Activity Page
        When User "<user>" logs in with API
        And User remembers text "Test_Auto" with added unique Id as "resourceTitle"
        And User "<user>" saves Draft "<resource>" with title "$resourceTitle" with API
        And User logs in as "<user>" on "LOGIN_PAGE"
        And User clicks Profile Icon "header|profileButton"
        And User clicks User Name "header|profileMenuFirstLastNameLabel" by executing script
        Then Recent Activity section "userProfilePage|recentActivitySection" is displayed
        And Resource Title "userProfilePage|activityResourceTitlesList" with text "$resourceTitle" is not displayed
        #delete resource
        And User deletes "<resource>" with "Title" equal to "$resourceTitle"
        Examples:
            | user          | resource |
            | GLOBAL_ADMIN  | research |
            | GLOBAL_ADMIN  | event    |
            | COMPANY_ADMIN | research |
            | COMPANY_ADMIN | event    |

    @research
    @events
    @regression
    @knownIssue @SRC-1564
    Scenario Outline: Verify [Resubmit rejected <resource>] action made by [<user>] is tracked on Recent Activity Page only after Admin Approval
        When User "<user>" logs in with API
        And User remembers text "Test_Auto" with added unique Id as "resourceTitle"
        When User "<user>" publishes "<resource>" with title "$resourceTitle" with API
        And User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" rejects "<resource>" with title "$resourceTitle" with API
        And User logs in as "<user>" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User selects item "option" with text "<content type>" from Content Type dropdown "userPostsPage|selectContentTypeDropdown"
        And User clicks Post "userPostsPage|articleTitlesList" with text "$resourceTitle" using script
        And User clicks Resubmit button "<page>|resubmitButton"
        And User clicks Profile Icon "header|profileButton"
        And User clicks User Name "header|profileMenuFirstLastNameLabel" by executing script
        #Check resource is not displayed in recent activity
        Then Recent Activity section "userProfilePage|recentActivitySection" is displayed
        And Resource Title "userProfilePage|activityResourceTitlesList" with text "$resourceTitle" is not displayed
        When User "GLOBAL_ADMIN" approves "<resource>" with title "$resourceTitle" with API
        And User refreshes page
        #Check resource is displayed in recent activity
        Then Resource Title "userProfilePage|activityResourceTitlesList" with text "$resourceTitle" is displayed
        And Activity Type "userProfilePage|activityTypesList" with text "submitted <resource>" on Activity Row "userProfilePage|recentActivityRowItemsList" with text "$resourceTitle" is displayed
        # verification for the full text "less than a minute ago" fails on STAGE, because it is very slow
        #And Activity Time "userProfilePage|activityTimeList" with text "less than a minute ago" on Activity Row "userProfilePage|recentActivityRowItemsList" with text "$resourceTitle" is displayed
        And Activity Time "userProfilePage|activityTimeList" with text "ago" on Activity Row "userProfilePage|recentActivityRowItemsList" with text "$resourceTitle" is displayed
        And Activity Icon "userProfilePage|activityIconsList" on Activity Row "userProfilePage|recentActivityRowItemsList" with text "$resourceTitle" is displayed
        #delete resource
        And User deletes "<resource>" with "Title" equal to "$resourceTitle"
        Examples:
            | user          | resource | content type  | page                |
            | GLOBAL_ADMIN  | research | research post | publishResearchPage |
            | GLOBAL_ADMIN  | event    | event         | createEventPage     |
            | COMPANY_ADMIN | research | research post | publishResearchPage |
            | COMPANY_ADMIN | event    | event         | createEventPage     |

#TODO: Add follow/unfollow actions
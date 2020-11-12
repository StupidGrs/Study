
@follow
Feature: Verify follow / unfollow functionality across different screens

    @researchDetails
    @regression
    Scenario Outline: <resource> Details Page - User clicks [Follow] button and verifies that [Follow] buttons changed to [Following] and followers number increased
        When User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_" with added unique Id as "resourceTitle"
        Then User "COMPANY_ADMIN" publishes "<resource>" with title "$resourceTitle" with API
        And User "COMPANY_ADMIN" unfollows "CompAuto" Company with API
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User navigates to "<resource>" URL with title "$resourceTitle"
        Then [Follow] button in [Left Block] section "<resourceDetailsPage>|leftBlockFollowButton" is displayed
        And [Follow] button in [Author] section "<resourceDetailsPage>|authorFollowButton" is displayed
        #Click [Follow] button in the Left Block
        #Check that button is changed to [Following] and number of followers increased in both Left Block and Author sections
        When User remembers text of "<resourceDetailsPage>|leftBlockCompanyFollowers" as "followers"
        And User clicks [Follow] button in [Left Block] section "<resourceDetailsPage>|leftBlockFollowButton"
        And User waits for Followers number "<resourceDetailsPage>|leftBlockCompanyFollowers" initital text "$followers" change
        Then [Following] button in [Left Block] section "<resourceDetailsPage>|leftBlockUnfollowButton" is displayed
        And [Following] button in [Author] section "<resourceDetailsPage>|authorUnfollowButton" is displayed
        And Followers in [Left Block] section "<resourceDetailsPage>|leftBlockCompanyFollowers" value "$followers" is increased by 1
        And Followers in [Author] section "<resourceDetailsPage>|authorCompanyFollowers" value "$followers" is increased by 1
        #Unfollow
        And User "COMPANY_ADMIN" unfollows "CompAuto" Company with API
        And User deletes "<resource>" with "Title" equal to "$resourceTitle"
        Examples:
            | resource | resourceDetailsPage |
            | Research | researchDetailsPage |
            | Event    | eventDetailsPage    |
            | News     | newsDetailsPage     |

    @researchDetails
    @regression
    Scenario Outline: <resource> Details Page - User clicks [Unfollow] button and verifies that [Following] buttons changed to [Follow] and followers number decreased
        When User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_" with added unique Id as "resourceTitle"
        Then User "COMPANY_ADMIN" publishes "<resource>" with title "$resourceTitle" with API
        # Have to force unfollow, because additional follow request fails if User is already following this company
        And User "COMPANY_ADMIN" unfollows "CompAuto" Company with API
        And User "COMPANY_ADMIN" follows "CompAuto" Company with API
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User navigates to "<resource>" URL with title "$resourceTitle"
        Then [Following] button in [Left Block] section "<resourceDetailsPage>|leftBlockUnfollowButton" is displayed
        And [Following] button in [Author] section "<resourceDetailsPage>|authorUnfollowButton" is displayed
        #Click [Following] button in the Author section, to unfollow
        #Check that button is changed to [Follow] and number of followers decreased in both Left Block and Author sections
        When User remembers text of "<resourceDetailsPage>|leftBlockCompanyFollowers" as "followers"
        And User clicks [Following] button in [Author] section "<resourceDetailsPage>|authorUnfollowButton" by executing script
        And User waits for Followers number "<resourceDetailsPage>|leftBlockCompanyFollowers" initital text "$followers" change
        Then [Follow] button in [Author] section "<resourceDetailsPage>|authorFollowButton" is displayed
        And [Follow] button in [Left Block] section "<resourceDetailsPage>|leftBlockFollowButton" is displayed
        And Followers in [Left Block] section "<resourceDetailsPage>|leftBlockCompanyFollowers" value "$followers" is decreased by 1
        And Followers in [Author] section "<resourceDetailsPage>|authorCompanyFollowers" value "$followers" is decreased by 1
        #Unfollow
        And User deletes "<resource>" with "Title" equal to "$resourceTitle"
        Examples:
            | resource | resourceDetailsPage |
            | Research | researchDetailsPage |
            | Event    | eventDetailsPage    |
            | News     | newsDetailsPage     |

    @researchDetails
    @regression
    Scenario Outline: <resource> Details Page - User clicks [Follow] button in the [<section>] section and verifies that Company is added to his Following list
        When User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_" with added unique Id as "resourceTitle"
        Then User "COMPANY_ADMIN" publishes "<resource>" with title "$resourceTitle" with API
        And User "COMPANY_ADMIN" unfollows "CompAuto" Company with API
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User navigates to "<resource>" URL with title "$resourceTitle"
        Then User clicks [Follow] button in [<section>] section "<resourceDetailsPage>|<followBtnSelector>" by executing script
        When User clicks Profile Icon "header|profileButton"
        And User clicks User Name "header|profileMenuFirstLastNameLabel" by executing script
        And User clicks [Companies] Tab "userProfilePage|companiesTab"
        And Company "userProfilePage|nameList" with text "CompAuto" is displayed
        #Unfollow
        And User "COMPANY_ADMIN" unfollows "CompAuto" Company with API
        And User deletes "<resource>" with "Title" equal to "$resourceTitle"
        Examples:
            | resource | resourceDetailsPage | section    | followBtnSelector     |
            | Research | researchDetailsPage | Author     | authorFollowButton    |
            | Event    | eventDetailsPage    | Author     | authorFollowButton    |
            | News     | newsDetailsPage     | Author     | authorFollowButton    |
           #| Research | researchDetailsPage | Left Block | leftBlockFollowButton |
           #| Event    | eventDetailsPage    | Left Block | leftBlockFollowButton |
           #| News     | newsDetailsPage     | Left Block | leftBlockFollowButton |

    @researchDetails
    @regression
    Scenario Outline: <resource> Details Page - User clicks [Following] button in the [<section>] section and verifies that Company is removed from his Following list
        When User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_" with added unique Id as "resourceTitle"
        Then User "COMPANY_ADMIN" publishes "<resource>" with title "$resourceTitle" with API
        And User "COMPANY_ADMIN" follows "CompAuto" Company with API
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User navigates to "<resource>" URL with title "$resourceTitle"
        Then User clicks [Following] button in [<section>] section "<resourceDetailsPage>|<unfollowBtnSelector>"
        When User clicks Profile Icon "header|profileButton"
        And User clicks User Name "header|profileMenuFirstLastNameLabel" by executing script
        And User clicks [Companies] Tab "userProfilePage|companiesTab"
        And Company "userProfilePage|nameList" with text "CompAuto" is not displayed
        #Unfollow
        And User "COMPANY_ADMIN" unfollows "CompAuto" Company with API
        And User deletes "<resource>" with "Title" equal to "$resourceTitle"
        Examples:
            | resource | resourceDetailsPage | section    | unfollowBtnSelector     |
            | Research | researchDetailsPage | Left Block | leftBlockUnfollowButton |
            | Event    | eventDetailsPage    | Left Block | leftBlockUnfollowButton |
            | News     | newsDetailsPage     | Left Block | leftBlockUnfollowButton |
           #| Research | researchDetailsPage | Author     | authorUnfollowButton    |
           #| Event    | eventDetailsPage    | Author     | authorUnfollowButton    |
           #| News     | newsDetailsPage     | Author     | authorUnfollowButton    |
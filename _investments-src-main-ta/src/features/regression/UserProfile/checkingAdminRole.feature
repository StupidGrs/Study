@userProfile
Feature: Check Admin Role Guard

    @regression
    @knownIssue @SRC-1640
    Scenario: Company Author do not see admin page
        When User logs in as "COMPANY_AUTHOR" on "LOGIN_PAGE"
        And [Publish] button "header|publishButton" is displayed
        And Settings button "header|settingsButton" is not displayed
        And Notifications button "header|notificationButton" is displayed
        And User Logo icon "header|userLogo" is displayed
        And User Logo icon "header|userLogo" text is equal to "CA"
        And User navigates to "ADMIN_COMPANY_IMPORT"
        Then Page URL is equal to "HOME_PAGE"
        And User navigates to "ADMIN_RESEARCH_IMPORT"
        Then Page URL is equal to "HOME_PAGE"
        And User navigates to "ADMIN_RSS_CONFIGS"
        Then Page URL is equal to "HOME_PAGE"

    Scenario: Global Admin checks company import admin page
        When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And [Publish] button "header|publishButton" is displayed
        And Settings button "header|settingsButton" is displayed
        And Notifications button "header|notificationButton" is displayed
        And User Logo icon "header|userLogo" is displayed
        And User Logo icon "header|userLogo" text is equal to "GA"
        And User navigates to "ADMIN_COMPANY_IMPORT"
        And User waits 2 seconds
        Then Page URL is equal to "ADMIN_COMPANY_IMPORT"

    Scenario: Global Admin checks research import admin page
        When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And [Publish] button "header|publishButton" is displayed
        And Settings button "header|settingsButton" is displayed
        And Notifications button "header|notificationButton" is displayed
        And User Logo icon "header|userLogo" is displayed
        And User Logo icon "header|userLogo" text is equal to "GA"
        And User navigates to "ADMIN_RESEARCH_IMPORT"
        And User waits 2 seconds
        Then Page URL is equal to "ADMIN_RESEARCH_IMPORT"

    Scenario: Global Admin checks rss configs admin page
        When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And [Publish] button "header|publishButton" is displayed
        And Settings button "header|settingsButton" is displayed
        And Notifications button "header|notificationButton" is displayed
        And User Logo icon "header|userLogo" is displayed
        And User Logo icon "header|userLogo" text is equal to "GA"
        And User navigates to "ADMIN_RSS_CONFIGS"
        And User waits 2 seconds
        Then Page URL is equal to "ADMIN_RSS_CONFIGS"
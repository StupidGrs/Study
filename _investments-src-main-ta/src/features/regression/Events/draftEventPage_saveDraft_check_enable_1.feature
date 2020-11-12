#change date fields and check [save draft] enabled
@events
Feature: Verify [Save draft] button becomes enabled when User updates data in [Date\Time fields] on Draft Event Page

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        When User remembers text "Test_Auto_Draft_Event" with added unique Id as "eventTitle"
        And User "COMPANY_ADMIN" saves Draft "Event" with all fields and title "$eventTitle" with API
        And User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User selects item "option" with text "event" from Select Content Type dropdown "userPostsPage|selectContentTypeDropdownOptionsList"
        Then User Event "userPostsPage|articleTitlesList" with text "$eventTitle" is displayed
        And User clicks Post "userPostsPage|articleTitlesList" with text "$eventTitle" using script
        And [Save draft] button "createEventPage|saveDraftButton" is displayed
        And [Save draft] button "createEventPage|saveDraftButton" is disabled

    @regression
    @draftEventPage
    Scenario: Verify [Save draft] button becomes enabled when User - updates [Start Date] field
        When User clicks Date Picker icon "createEventPage|datepickerStartDate"
        And User clicks Next Month icon "calendar|nextMonthButton"
        And User clicks Day icon "calendar|daysList" with text "23"
        Then [Save draft] button "createEventPage|saveDraftButton" is enabled
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"

    @regression
    @draftEventPage
    Scenario: Verify [Save draft] button becomes enabled when User - updates [End Date] field
        When User clicks Date Picker icon "createEventPage|datepickerEndDate"
        And User clicks Next Month icon "calendar|nextMonthButton"
        And User clicks Day icon "calendar|daysList" with text "23"
        Then [Save draft] button "createEventPage|saveDraftButton" is enabled
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"

    @regression
    @draftEventPage
    Scenario Outline: Verify [Save draft] button becomes enabled when User - updates [<fieldDesc>] field
        When User clears text from [<fieldDesc>] field "createEventPage|<fieldSelector>"
        And User enters "01:33 AM" in [<fieldDesc>] field "createEventPage|<fieldSelector>"
        Then [Save draft] button "createEventPage|saveDraftButton" is enabled
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"
        Examples:
            | fieldDesc  | fieldSelector  |
            | Start Time | startTimeField |
            | End Time   | endTimeField   |
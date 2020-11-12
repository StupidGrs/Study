#change required fields and check [save draft] enabled
@events
Feature: Verify [Save draft] button becomes enabled when User updates data in [Required fields] on Draft Event Page

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
    Scenario: Verify [Save draft] button becomes enabled when User - changes [Event Type]
        When User selects item "option" with text "Networking" from Event Type dropdown "createEventPage|eventTypeField"
        Then [Save draft] button "createEventPage|saveDraftButton" is enabled
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"

    @regression
    @draftEventPage
    Scenario Outline: Verify [Save draft] button becomes enabled when User - updates [<fieldDesc>] field
        When User enters "<value>" in [<fieldDesc>] field "createEventPage|<fieldSelector>"
        Then [Save draft] button "createEventPage|saveDraftButton" is enabled
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"
        Examples:
            | fieldDesc  | fieldSelector  | value   |
            | Event Name | eventNameField | Updated |
            | Location   | locationField  | Updated |
            | Excerpt    | excerptField   | Updated |

    @regression
    @draftEventPage
    Scenario: Verify [Save draft] button becomes enabled when User - updates [Event Content] field
        When User enters "Updated" in Event Content field "createEventPage|contentField"
        When User clicks Event Content field "createEventPage|eventNameField"
        And  User waits 1 second
        Then [Save draft] button "createEventPage|saveDraftButton" is enabled
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"

    @regression
    @draftEventPage
    Scenario: Verify [Save draft] button becomes enabled when User - removes selected [Taxonomy]
        When User clicks Remove Selected Taxonomy Icon "createEventPage|taxonomiesRemoveIconsList"
        Then [Save draft] button "createEventPage|saveDraftButton" is enabled
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"

    @regression
    @draftEventPage
    Scenario: Verify [Save draft] button becomes enabled when User - adds one more [Taxonomy]
        When User selects item "option" with text "Strategy" from Taxonomies dropdown "createEventPage|taxonomyField"
        Then [Save draft] button "createEventPage|saveDraftButton" is enabled
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"
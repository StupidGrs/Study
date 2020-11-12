#change optional fields and check [save draft] enabled
@events
Feature: Verify [Save draft] button becomes enabled when User updates data in [Optional fields] on Draft Event Page

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
    Scenario: Verify [Save draft] button becomes enabled when User - removes selected [Tag]
        When User clicks Remove Selected Tag Icon "createEventPage|tagChipItemRemoveIcon"
        Then [Save draft] button "createEventPage|saveDraftButton" is enabled
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"

    @regression
    @draftEventPage
    Scenario: Verify [Save draft] button becomes enabled when User - adds one more [Tag]
        When User enters "Taxes" in the Tag field "createEventPage|tagsField"
        And User waits for Tag item "createEventPage|tagsAutoCompleteItem" with text "Taxes" visibility within 5 seconds
        And User clicks Tag item "createEventPage|tagsAutoCompleteItem" with text " Taxes "
        Then [Save draft] button "createEventPage|saveDraftButton" is enabled
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"

    @regression
    @draftEventPage
    Scenario: Verify [Save draft] button becomes enabled when User - unselects Region checkbox
        When User clicks Region field "createEventPage|regionFieldDropdown" with text "Regions"
#        Then Region options list "createEventPage|regionOptionRow" is displayed
#        And Checkbox "createEventPage|regionOptionCheckboxInput" on Region Option "createEventPage|regionOptionRow" with text "US" is selected
        When User clicks checkbox "createEventPage|regionOptionCheckboxLabel" with text "US"
        Then [Save draft] button "createEventPage|saveDraftButton" is enabled
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"

    @regression
    @draftEventPage
    Scenario: Verify [Save draft] button becomes enabled when User  - adds one more Region
        When User clicks Region field "createEventPage|regionFieldDropdown" with text "Regions"
        And User clicks checkbox "createEventPage|regionOptionCheckboxLabel" with text "UK"
        Then [Save draft] button "createEventPage|saveDraftButton" is enabled
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"

    @regression
    @draftEventPage
    Scenario: Verify [Save draft] button becomes enabled when User - removes Uploaded Featured Image
        When User clicks Image Icon "createEventPage|attachedImageDropdown" with text "Featured Image"
#        And User clicks Remove Uploaded Featured Image Icon "createEventPage|attachedImageRemoveIcon"
        Then [Save draft] button "createEventPage|saveDraftButton" is disabled
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"

    @regression
    @draftEventPage
    Scenario: Verify [Save draft] button becomes enabled when User  - uploads Featured Image
        When User makes upload of file "featuredForEvent.png" using Upload field "createEventPage|attachmentFieldInput"
        Then [Save draft] button "createEventPage|saveDraftButton" is enabled
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"

    @regression
    @draftEventPage
    Scenario: Verify [Save draft] button becomes enabled when User - updates [URL Link] field
        When User enters "Updated" in [URL Link] field "createEventPage|urlLinkField"
        Then [Save draft] button "createEventPage|saveDraftButton" is enabled
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"
@events
Feature: Verify Unsaved Changes popup on Draft Event page

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        When User remembers text "Test_Auto_Draft_Event" with added unique Id as "eventTitle"
        And User "COMPANY_ADMIN" saves Draft "Event" with title "$eventTitle" with API
        And User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User selects item "option" with text "event" from Select Content Type dropdown "userPostsPage|selectContentTypeDropdownOptionsList"
        Then User Event "userPostsPage|articleTitlesList" with text "$eventTitle" is displayed
        And User clicks Event "userPostsPage|articleTitlesList" with text "$eventTitle"

    @regression
    @draftEventPage
    @dirtyChecking
    Scenario Outline: Verify that Unsaved Changes popup does not appear if User clicks [<button>] button without entering any details on Create Event Page
        And User clicks [<button>] button "createEventPage|<buttonSelector>"
        Then Unsaved changes popup "unsavedChangesPopup|headerText" is not displayed
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"
        Examples:
            | button | buttonSelector |
            | Close  | closeIcon      |
           # | Cancel | cancelButton   |

    @regression
    @draftEventPage
    Scenario Outline: Verify text and buttons on Unsaved Changes popup on Create Event Page, when User clicks [<button>] button
        When User enters "Test_Auto_Event" in Event Name field "createEventPage|eventNameField"
        And User clicks [<button>] button "createEventPage|<buttonSelector>"
        Then Unsaved Changes Popup Header "unsavedChangesPopup|headerText" with text "Close Publish Form" is displayed
        And Unsaved Changes Popup Message "unsavedChangesPopup|messageText" with text "Warning, you have unpublished content. If you choose to Continue, you will lose your changes!" is displayed
        And Unsaved Changes Cancel Button "unsavedChangesPopup|cancelButton" with text "Cancel" is displayed
        And Unsaved Changes Continue Button "unsavedChangesPopup|continueButton" with text "Continue" is displayed
        And Unsaved Changes Close Button "unsavedChangesPopup|closeButton" is displayed
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"
        Examples:
            | button | buttonSelector |
            | Close  | closeIcon      |
            | Cancel | cancelButton   |

    @regression
    @draftEventPage
    Scenario Outline: Verify that Unsaved Changes popup closes and User stays on Create Event page if User clicks [<button>] button on Unsaved Changes popup
        When User clears text from Event Name field "createEventPage|eventNameField"
        And User enters "Test_Auto_Event" in Event Name field "createEventPage|eventNameField"
        And User clicks [Cancel] button on Create Event Page "createEventPage|cancelButton"
        Then Unsaved Changes Popup Header "unsavedChangesPopup|headerText" is displayed
        When User clicks [<button>] button on Unsaved Changes popup "unsavedChangesPopup|<buttonSelector>"
        Then Unsaved Changes Popup Header "unsavedChangesPopup|headerText" is not displayed
        And User scrolls page to top
        And Create Event Modal "createEventPage|modalContent" is displayed
        And Event Name field "createEventPage|eventNameField" is displayed
        And Attribute "value" of Event Name field "createEventPage|eventNameField" is equal to "Test_Auto_Event"
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"
        Examples:
            | button | buttonSelector |
            #| Close  | closeButton    |
            | Cancel | cancelButton   |

    @regression
    @draftEventPage
    Scenario: Verify that Create Event page closes if User clicks [Continue] button on Unsaved Changes popup
        When User clears text from Event Name field "createEventPage|eventNameField"
        And User enters "Test_Auto_Event" in Event Name field "createEventPage|eventNameField"
        And User clicks [Cancel] button on Create Event Page "createEventPage|cancelButton"
        Then Unsaved Changes Popup Header "unsavedChangesPopup|headerText" is displayed
        When User clicks [Continue] button on Unsaved Changes popup "unsavedChangesPopup|continueButton"
        Then Unsaved Changes Popup Header "unsavedChangesPopup|headerText" is not displayed
        And Create Event Page header "createEventPage|modalHeader" is not displayed
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"

#todo
#  @regression
#  @draftEventPage
#  Scenario:Company Admin populates all fields, clicks Cancel, then Cancel again and checks that values are left in the fields

#todo:
#  @regression
#  @draftEventPage
#Company Admin populates all fields, clicks Cancel, then Continue, opens Create Event Page and checks that no values are left in the fields.
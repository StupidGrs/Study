@events
Feature: Verify validations and Incomplete form modal on Draft Event Page

    Background:
        #create draft Event without Featured Image
        Given User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_Draft_Event" with added unique Id as "eventTitle"
        And User "COMPANY_ADMIN" saves Draft Event with title "$eventTitle" and Start Date "10/20/2020" and Time "9:00 AM" and End Date "10/21/2020" and Time "5:00 PM" with API
        #open created draft Event
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User selects item "option" with text "event" from Select Content Type dropdown "userPostsPage|selectContentTypeDropdownOptionsList"
        Then User Event "userPostsPage|articleTitlesList" with text "$eventTitle" is displayed
        And User clicks Post "userPostsPage|articleTitlesList" with text "$eventTitle" using script

    @regression
    @draftEventPage
    Scenario Outline: Company Admin opens Draft Event page, clears Mandatory fields, populates some non mandatory fields and clicks [<button>] button
        When User clears text from Event Name field "createEventPage|eventNameField"
        And User clears text from Location field "createEventPage|locationField"
#        And User clears text from Start Date field "createEventPage|startDateField"
        And User clears text from Start Time field "createEventPage|startTimeField"
#        And User clears text from End Date field "createEventPage|endDateField"
        And User clears text from End Time field "createEventPage|endTimeField"
        And User clicks Remove Selected Taxonomy Icon "createEventPage|taxonomiesRemoveIconsList"
        And User clears text from Excerpt field "createEventPage|excerptField"
        And User enters "" in Event Content field "createEventPage|contentField" by executing script
        And User enters "https://events.climateaction.org/sustainable-investment-forum-europe/" in URL link field "createEventPage|urlLinkField"
        And User clicks [<button>] button "createEventPage|<buttonSelector>"
        Then Incomplete form popup "incompleteFormPopup|headerText" with text "Incomplete form" is displayed
        And Message "incompleteFormPopup|bodyText" with text "Please check these mandatory fields:" is displayed
        And Message item list "incompleteFormPopup|bodyTextItem" contains values:
            | Taxonomy                  |
            | Event Excerpt             |
            | Event Content             |
#            | Start Date                |
#            | End Date                  |
            | Event Name                |
            | Location                  |
            | Start Time (ex. 11:00 AM) |
            | End Time (ex. 11:00 AM)   |
        And Message item list "incompleteFormPopup|bodyTextItem" count is equal to 7
        And [OK] button "incompleteFormPopup|okButton" with text "Ok" is displayed
        And Close Icon "incompleteFormPopup|closeButton" is displayed
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"
        Examples:
            | button     | buttonSelector  |
            | Submit     | submitButton    |
            | Save Draft | saveDraftButton |

    @regression
    @draftEventPage
    Scenario: Company Admin uploads featured image of size more than 2 mb
        When User makes upload of file "imageSizeError.jpg" using Upload field "createEventPage|attachmentFieldInput"
        Then Error popup "imageSizeErrorPopup|errorMessage" with text "Image size must be less than 2 MB." is displayed
        When User clicks Close button "incompleteFormPopup|closeButton"
        Then Error popup "imageSizeErrorPopup|errorMessage" is not displayed
        And Draft Event Modal "createEventPage|modalContent" is displayed
        And Uploaded file title "createEventPage|uploadedFileTitle" with text "imageSizeError.jpg" is not displayed
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"

    @regression
    @draftEventPage
    Scenario: Event End date is earlier than Start date
        When User clicks Calendar "createEventPage|datepickerStartDate"
        And User clicks Next month button "calendar|nextMonthButton"
        And User clicks Day in calendar "calendar|daysList" with text "23"
        And User clicks Header "createEventPage|modalHeader"
        And User clicks Calendar "createEventPage|datepickerEndDate"
        And User clicks Next month button "calendar|nextMonthButton"
        And User clicks Day in calendar "calendar|daysList" with text "22"
        And User clicks Header "createEventPage|modalHeader"
        When User clicks [Submit] button "createEventPage|submitButton"
        Then Incomplete form popup "incompleteFormPopup|headerText" with text "Incomplete form" is displayed
        And Message item "incompleteFormPopup|bodyTextItem" with text "Start date/time exceeds end date/time" is displayed
        And Message item list "incompleteFormPopup|bodyTextItem" count is equal to 1
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"

    @regression
    @draftEventPage
    Scenario Outline: Company Admin closes Incomplete form modal with [<button>] button
        When User clears text from Event Name field "createEventPage|eventNameField"
        And User clicks [Submit] button "createEventPage|submitButton"
        Then Incomplete form popup "incompleteFormPopup|headerText" is displayed
        When User clicks [<button>] button on Incomplete form popup "incompleteFormPopup|<buttonSelector>"
        Then Incomplete form popup "incompleteFormPopup|headerText" is not displayed
        And Draft Event Modal "createEventPage|modalContent" is displayed
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"
        Examples:
            | button | buttonSelector |
            | OK     | okButton       |
            | Close  | closeButton    |
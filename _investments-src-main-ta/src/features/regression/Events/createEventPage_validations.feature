@events
Feature: Verify validations and Incomplete form modal on Create Event Page

  Background:
    Given User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks [Publish] button "header|publishButton"
    When User clicks Event button "modalWindow|eventIcon"

  @regression
  @createEventPage
  Scenario Outline: Company Admin opens Create an Event page and clicks [<button>] button
    And User clicks [<button>] button "createEventPage|<buttonSelector>"
    Then Incomplete form popup "incompleteFormPopup|headerText" with text "Incomplete form" is displayed
    And Message "incompleteFormPopup|bodyText" with text "Please check these mandatory fields:" is displayed
    And Message item list "incompleteFormPopup|bodyTextItem" contains values:
      | Taxonomy                  |
      | Event Excerpt             |
      | Event Content             |
      | Event Type                |
      | Start Date                |
      | End Date                  |
      | Event Name                |
      | Location                  |
      | Start Time (ex. 11:00 AM) |
      | End Time (ex. 11:00 AM)   |


    And [OK] button "incompleteFormPopup|okButton" with text "Ok" is displayed
    And Close Icon "incompleteFormPopup|closeButton" is displayed
    Examples:
      | button              | buttonSelector         |
      | Submit              | submitButton           |
      | Submit and Post New | submitAndPostNewButton |

  @regression
  @createEventPage
  Scenario Outline: Company Admin populates some non mandatory fields and clicks [<button>] button
    And User enters "https://events.climateaction.org/sustainable-investment-forum-europe/" in URL link field "createEventPage|urlLinkField"
    And User clicks [<button>] button "createEventPage|<buttonSelector>"
    Then Incomplete form popup "incompleteFormPopup|headerText" with text "Incomplete form" is displayed
    And Message "incompleteFormPopup|bodyText" with text "Please check these mandatory fields:" is displayed
    And Message item list "incompleteFormPopup|bodyTextItem" contains values:
      | Taxonomy                  |
      | Event Excerpt             |
      | Event Content             |
      | Event Type                |
      | Start Date                |
      | End Date                  |
      | Event Name                |
      | Location                  |
      | Start Time (ex. 11:00 AM) |
      | End Time (ex. 11:00 AM)   |
    And [OK] button "incompleteFormPopup|okButton" with text "Ok" is displayed
    And Close Icon "incompleteFormPopup|closeButton" is displayed
    Examples:
      | button              | buttonSelector         |
      | Submit              | submitButton           |
      | Submit and Post New | submitAndPostNewButton |
      | Save Draft          | saveDraftButton        |

  @regression
  @createEventPage
  Scenario: Company Admin uploads featured image of size more than 2 mb
    When User makes upload of file "imageSizeError.jpg" using Upload field "createEventPage|attachmentFieldInput"
    Then Error popup "imageSizeErrorPopup|errorMessage" with text "Image size must be less than 2 MB." is displayed
    When User clicks Close button "incompleteFormPopup|closeButton"
    Then Error popup "imageSizeErrorPopup|errorMessage" is not displayed
    And Create Event Modal "createEventPage|modalContent" is displayed
    And Uploaded file title "createEventPage|uploadedFileTitle" with text "imageSizeError.jpg" is not displayed

  @regression
  @createEventPage
  Scenario: Event End date is earlier than Start date
    And Attribute "value" of Company Field "createEventPage|companyField" is equal to "CompAuto"
    And User selects item "option" with text "Conference" from Event Types "createEventPage|eventTypeField"
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    And User enters "$eventTitle" in Event Name field "createEventPage|eventNameField"
    And User enters "Toronto, Canada" in Location field "createEventPage|locationField" by executing script
#    And User clicks item "createEventPage|locationAutocompleteItem" with text "Toronto, Canada" by executing script
    And User clicks Calendar "createEventPage|datepickerStartDate"
    And User clicks Next month button "calendar|nextMonthButton"
    And User clicks Day in calendar "calendar|daysList" with text "23"
    And User clicks Header "createEventPage|modalHeader"
    And User enters "9:00 AM" in Start Time field "createEventPage|startTimeField"
    And User clicks Calendar "createEventPage|datepickerEndDate"
    And User clicks Next month button "calendar|nextMonthButton"
    And User clicks Day in calendar "calendar|daysList" with text "22"
    And User clicks Header "createEventPage|modalHeader"
    And User enters "5:00 PM" in End Time field "createEventPage|endTimeField"
    And User clicks item "createEventPage|taxonomyFieldOption" with text "Hot Topics"
    And User enters "TEXT:Event_Excerpt" in Excerpt field "createEventPage|excerptField"
    And User enters "TEXT:Event_Content" in Content field "createEventPage|contentField" by executing script
    When User clicks [Submit] button "createEventPage|submitButton"
    Then Incomplete form popup "incompleteFormPopup|headerText" with text "Incomplete form" is displayed
    And Message item "incompleteFormPopup|bodyTextItem" with text "Start date/time exceeds end date/time" is displayed

  @regression
  @createEventPage
  Scenario Outline: Company Admin closes Incomplete form modal with [<button>] button
    And User clicks [Submit] button "createEventPage|submitButton"
    Then Incomplete form popup "incompleteFormPopup|headerText" is displayed
    When User clicks [<button>] button on Incomplete form popup "incompleteFormPopup|<buttonSelector>"
    Then Incomplete form popup "incompleteFormPopup|headerText" is not displayed
    And Create Event Modal "createEventPage|modalContent" is displayed
    Examples:
      | button | buttonSelector |
      | OK     | okButton       |
      | Close  | closeButton    |
@events
Feature: Verify Unsaved Changes popup on Create Event page

  Background:
    Given User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks [Publish] button "header|publishButton"
    When User clicks Event button "modalWindow|eventIcon"

  @regression
  @createEventPage
  @knownIssue @knownIssue_IE @SRC-1012
  Scenario Outline: Verify that Unsaved Changes popup does not appear if User clicks [<button>] button without entering any details on Create Event Page
    And User clicks [<button>] button "createEventPage|<buttonSelector>"
    Then Unsaved changes popup "unsavedChangesPopup|headerText" is not displayed
    Examples:
      | button | buttonSelector |
      | Close  | closeIcon      |
      | Cancel | cancelButton   |

  @regression
  @createEventPage
  Scenario Outline: Verify text and buttons on Unsaved Changes popup on Create Event Page, when User clicks [<button>] button
    When User enters "Test_Auto_Event" in Event Name field "createEventPage|eventNameField"
    And User clicks [<button>] button "createEventPage|<buttonSelector>"
    Then Unsaved Changes Popup Header "unsavedChangesPopup|headerText" with text "Close Publish Form" is displayed
    And Unsaved Changes Popup Message "unsavedChangesPopup|messageText" with text "Warning, you have unpublished content. If you choose to Continue, you will lose your changes!" is displayed
    And Unsaved Changes Cancel Button "unsavedChangesPopup|cancelButton" with text "Cancel" is displayed
    And Unsaved Changes Continue Button "unsavedChangesPopup|continueButton" with text "Continue" is displayed
    And Unsaved Changes Close Button "unsavedChangesPopup|closeButton" is displayed
    Examples:
      | button | buttonSelector |
      | Close  | closeIcon      |
      | Cancel | cancelButton   |

  @regression
  @createEventPage
  Scenario Outline: Verify that Unsaved Changes popup closes and User stays on Create Event page if User clicks [<button>] button on Unsaved Changes popup
    When User enters "Test_Auto_Event" in Event Name field "createEventPage|eventNameField"
    And User clicks [Cancel] button on Create Event Page "createEventPage|cancelButton"
    Then Unsaved Changes Popup Header "unsavedChangesPopup|headerText" is displayed
    When User clicks [<button>] button on Unsaved Changes popup "unsavedChangesPopup|<buttonSelector>"
    Then Unsaved Changes Popup Header "unsavedChangesPopup|headerText" is not displayed
    And User scrolls page to top
    And Create Event Modal "createEventPage|modalContent" is displayed
    And Event Name field "createEventPage|eventNameField" is displayed
    And Attribute "value" of Event Name field "createEventPage|eventNameField" is equal to "Test_Auto_Event"
    Examples:
      | button | buttonSelector |
      | Close  | closeButton    |
      | Cancel | cancelButton   |

  @regression
  @createEventPage
  Scenario: Verify that Create Event page closes if User clicks [Continue] button on Unsaved Changes popup
    When User enters "Test_Auto_Event" in Event Name field "createEventPage|eventNameField"
    And User clicks [Cancel] button on Create Event Page "createEventPage|cancelButton"
    Then Unsaved Changes Popup Header "unsavedChangesPopup|headerText" is displayed
    When User clicks [Continue] button on Unsaved Changes popup "unsavedChangesPopup|continueButton"
    Then Unsaved Changes Popup Header "unsavedChangesPopup|headerText" is not displayed
    And Create Event Page header "createEventPage|modalHeader" is not displayed

#todo
#  @regression
#  @createEventPage
#  Scenario:Company Admin populates all fields, clicks Cancel, then Cancel again and checks that values are left in the fields

#todo:
#  @regression
#  @createEventPage
#Company Admin populates all fields, clicks Cancel, then Continue, opens Create Event Page and checks that no values are left in the fields.
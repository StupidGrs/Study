@research
Feature: Verify Unsaved Changes popup on Publish Research Page

  Background:
    Given User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks [Publish] button "header|publishButton"
    And User clicks on [Research / WhitePaper] icon "modalWindow|researchIcon"

  @regression
  @publishResearchPage
  Scenario Outline: Verify that Unsaved Changes popup does not appear if User clicks <button> button without entering any details on Publish Research Page
    And User clicks [<button>] button "publishResearchPage|<buttonSelector>"
    Then Unsaved changes popup "unsavedChangesPopup|headerText" is not displayed
    Examples:
      | button | buttonSelector |
      | Close  | closeButton    |
      | Cancel | cancelButton   |

  @regression
  @publishResearchPage
  Scenario Outline: Verify text and buttons on Unsaved Changes popup on Publish Research Page, when User clicks <button> button
    When User enters "Test_Auto_Research" in Title field "publishResearchPage|titleField"
    And User clicks [<button>] button "publishResearchPage|<buttonSelector>"
    Then Unsaved Changes Popup Header "unsavedChangesPopup|headerText" with text "Close Publish Form" is displayed
    And Unsaved Changes Popup Message "unsavedChangesPopup|messageText" with text "Warning, you have unpublished content. If you choose to Continue, you will lose your changes!" is displayed
    And Unsaved Changes Cancel Button "unsavedChangesPopup|cancelButton" with text "Cancel" is displayed
    And Unsaved Changes Continue Button "unsavedChangesPopup|continueButton" with text "Continue" is displayed
    And Unsaved Changes Close Button "unsavedChangesPopup|closeButton" is displayed
    Examples:
      | button | buttonSelector |
      | Close  | closeButton    |
      | Cancel | cancelButton   |

  @regression
  @publishResearchPage
  Scenario Outline: Verify that Unsaved Changes popup closes and User stays on Publish Research Page, when User clicks [<button>] button on Unsaved Changes popup
    When User enters "Test_Auto_Research" in Title field "publishResearchPage|titleField"
    And User clicks [Cancel] button on Publish Research Page "publishResearchPage|cancelButton"
    Then Unsaved Changes Popup Header "unsavedChangesPopup|headerText" is displayed
    When User clicks [<button>] button on Unsaved Changes popup "unsavedChangesPopup|<buttonSelector>"
    Then Unsaved Changes Popup Header "unsavedChangesPopup|headerText" is not displayed
    And Publish Research Page Header "publishResearchPage|header" is displayed
    And Research Title field "publishResearchPage|titleField" is displayed
    And Attribute "value" of Research Title field "publishResearchPage|titleField" is equal to "Test_Auto_Research"

    Examples:
      | button | buttonSelector |
      | Close  | closeButton    |
      | Cancel | cancelButton   |

  @regression
  @publishResearchPage
  Scenario: Verify that Publish Research Page closes, when User clicks [Continue] button on Unsaved Changes popup
    When User enters "Test_Auto_Research" in Title field "publishResearchPage|titleField"
    And User clicks [Cancel] button on Publish Research Page "publishResearchPage|cancelButton"
    Then Unsaved Changes Popup Header "unsavedChangesPopup|headerText" is displayed
    When User clicks [Continue] button on Unsaved Changes popup "unsavedChangesPopup|continueButton"
    Then Unsaved Changes Popup Header "unsavedChangesPopup|headerText" is not displayed
    And Publish Research Page Header "publishResearchPage|header" is not displayed


#todo
#  @regression
#  @publishResearchPag
#  Scenario:Company Admin populates all fields, clicks Cancel, then Cancel again and checks that values are left in the fields

#todo:
#  @regression
#  @publishResearchPag
#Company Admin populates all fields, clicks Cancel, then Continue, opens Publish Research Page and checks that no values are left in the fields.
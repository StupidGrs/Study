@research
Feature: Verify validations and Incomplete form modal on Publish Research Page

  Background:
    Given User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks [Publish] button "header|publishButton"
    And User clicks on [Research / WhitePaper] icon "modalWindow|researchIcon"

  @regression
  @publishResearchPage
  Scenario Outline: Company Admin opens Publish Research page and clicks [<button>] button
    When User clicks [<button>] button "publishResearchPage|<buttonSelector>"
    Then Incomplete form popup "incompleteFormPopup|headerText" with text "Incomplete form" is displayed
    And Message "incompleteFormPopup|bodyText" with text "Please check these mandatory fields:" is displayed
    And Message item list "incompleteFormPopup|bodyTextItem" contains values:
      | Title                           |
      | Research Type                   |
      | Executive Summary               |
      | Date                            |
      | Taxonomies                      |
      | Full Post Content               |
    And [OK] button "incompleteFormPopup|okButton" with text "Ok" is displayed
    And Close Icon "incompleteFormPopup|closeButton" is displayed
    Examples:
      | button               | buttonSelector            |
      | Submit               | submitButton              |
      | Submit & Add another | submitAndAddAnotherButton |

  @regression
  @publishResearchPage
  Scenario Outline: Company Admin populates some non mandatory fields and clicks [<button>] button
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Read time"
    And Number of Minutes field "publishResearchPage|numberOfMinutesField" is displayed
    And User clicks Number of Minutes field "publishResearchPage|numberOfMinutesField"
    Then User enters "10" in Number of Minutes field "publishResearchPage|numberOfMinutesField"
    When User clicks [<button>] button "publishResearchPage|<buttonSelector>"
    Then Incomplete form popup "incompleteFormPopup|headerText" with text "Incomplete form" is displayed
    And Message "incompleteFormPopup|bodyText" with text "Please check these mandatory fields:" is displayed
    And Message item list "incompleteFormPopup|bodyTextItem" contains values:
      | Title                           |
      | Research Type                   |
      | Executive Summary               |
      | Date                            |
      | Taxonomies                      |
      | Full Post Content               |
    And [OK] button "incompleteFormPopup|okButton" with text "Ok" is displayed
    And Close Icon "incompleteFormPopup|closeButton" is displayed
    Examples:
      | button               | buttonSelector            |
      | Submit               | submitButton              |
      | Submit & Add another | submitAndAddAnotherButton |
      | Save draft           | saveDraftButton           |

  @regression
  @publishResearchPage
  Scenario: Company Admin uploads featured image of size more than 2 mb
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Featured Image"
    And User makes upload of file "imageSizeError.jpg" using form "publishResearchPage|featuredImageFieldInput"
    Then Error popup "imageSizeErrorPopup|errorMessage" with text "Image size must be less than 2 MB." is displayed
    When User clicks Close button "incompleteFormPopup|closeButton"
    Then Error popup "imageSizeErrorPopup|errorMessage" is not displayed
    And Featured Image Dropzone "publishResearchPage|featuredImageDropzone" is displayed
    And  Uploaded Image "publishResearchPage|uploadedFeaturedImage" is not displayed

  @regression
  @publishResearchPage
  Scenario Outline: Company Admin closes Incomplete form modal with [<button>] button
    When User clicks [Submit] button "publishResearchPage|submitButton"
    Then Incomplete form popup "incompleteFormPopup|headerText" is displayed
    When User clicks [<button>] button on Incomplete form popup "incompleteFormPopup|<buttonSelector>"
    Then Incomplete form popup "incompleteFormPopup|headerText" is not displayed
    And Publish Research Page Header "publishResearchPage|header" is displayed
    Examples:
      | button | buttonSelector |
      | OK     | okButton       |
      | Close  | closeButton    |
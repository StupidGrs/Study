@news
Feature: Verify validations and Incomplete form modal on Publish News Page

  Background:
    Given User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks [Publish] button "header|publishButton"
    And User clicks on [News / Blog] icon "modalWindow|newsIcon"

  @regression
  @publishNewsPage
  Scenario Outline: Company Admin opens Publish News page and clicks [<button>] button
    When User clicks [<button>] button "publishNewsPage|<buttonSelector>"
    Then Incomplete form popup "incompleteFormPopup|headerText" with text "Incomplete form" is displayed
    And Message "incompleteFormPopup|bodyText" with text "Please check these mandatory fields:" is displayed
    And Message item list "incompleteFormPopup|bodyTextItem" contains values:
      | Title             |
      | Executive Summary |
      | Date              |
      | Taxonomies        |
      | Full Post Content |
    And [OK] button "incompleteFormPopup|okButton" with text "Ok" is displayed
    And Close Icon "incompleteFormPopup|closeButton" is displayed
    Examples:
      | button               | buttonSelector            |
      | Submit               | submitButton              |
      | Submit & Add another | submitAndAddAnotherButton |

  @regression
  @publishNewsPage
  Scenario Outline: Company Admin populates some non mandatory fields and clicks [<button>] button
    When User clicks Right Sidebar Item "publishNewsPage|rightSidebarAccordionHeadersTextsList" with text "Read time"
    And Number of Minutes field "publishNewsPage|numberOfMinutesField" is displayed
    And User clicks Number of Minutes field "publishNewsPage|numberOfMinutesField"
    Then User enters "10" in Number of Minutes field "publishNewsPage|numberOfMinutesField"
    When User clicks [<button>] button "publishNewsPage|<buttonSelector>"
    Then Incomplete form popup "incompleteFormPopup|headerText" with text "Incomplete form" is displayed
    And Message "incompleteFormPopup|bodyText" with text "Please check these mandatory fields:" is displayed
    And Message item list "incompleteFormPopup|bodyTextItem" contains values:
      | Title             |
      | Executive Summary |
      | Date              |
      | Taxonomies        |
      | Full Post Content |
    And [OK] button "incompleteFormPopup|okButton" with text "Ok" is displayed
    And Close Icon "incompleteFormPopup|closeButton" is displayed
    Examples:
      | button               | buttonSelector            |
      | Submit               | submitButton              |
      | Submit & Add another | submitAndAddAnotherButton |
      | Save draft           | saveDraftButton           |

  @regression
  @publishNewsPage
  Scenario: Company Admin uploads featured image of size more than 2 mb
    When User clicks Right Sidebar Item "publishNewsPage|rightSidebarAccordionHeadersTextsList" with text "Featured Image"
    And User makes upload of file "imageSizeError.jpg" using form "publishNewsPage|featuredImageFieldInput"
    Then Error popup "imageSizeErrorPopup|errorMessage" with text "Image size must be less than 2 MB." is displayed
    When User clicks Close button "incompleteFormPopup|closeButton"
    Then Error popup "imageSizeErrorPopup|errorMessage" is not displayed
    And Featured Image Dropzone "publishNewsPage|featuredImageDropzone" is displayed
    And  Uploaded Image "publishNewsPage|uploadedFeaturedImage" is not displayed

  @regression
  @publishNewsPage
  Scenario Outline: Company Admin closes Incomplete form modal with [<button>] button
    When User clicks [Submit] button "publishNewsPage|submitButton"
    Then Incomplete form popup "incompleteFormPopup|headerText" is displayed
    When User clicks [<button>] button on Incomplete form popup "incompleteFormPopup|<buttonSelector>"
    Then Incomplete form popup "incompleteFormPopup|headerText" is not displayed
    And Publish News Page Header "publishNewsPage|header" is displayed
    Examples:
      | button | buttonSelector |
      | OK     | okButton       |
      | Close  | closeButton    |
@research
Feature: Verify validations and Incomplete form modal on Draft Research Page

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_Draft_Research" with added unique Id as "researchTitle"
        And User "COMPANY_ADMIN" saves Draft "Research" with title "$researchTitle" with API
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "research post"
        Then User Post "userPostsPage|articleTitlesList" with text "$researchTitle" is displayed
        And User clicks Post "userPostsPage|articleTitlesList" with text "$researchTitle" using script
        And User waits 3 seconds

    @regression
    @draftResearchPage
    Scenario Outline: Company Admin opens Draft Research page, clears Mandatory fields, populates some non mandatory fields and clicks [<button>] button
        #NOTE:
        #Unable to reset Event Type dropdown
        When User clears text from Title field "publishResearchPage|titleField"
        And User clears text from Executive Summary field "publishResearchPage|executiveSummaryField"
        And User clears text from Link to Content field "publishResearchPage|linkToContent"
        And User enters "" in Research Content field "publishResearchPage|fullPostContentField" by executing script
        And User clicks Remove Selected Taxonomy Icon "publishResearchPage|taxonomiesRemoveIconsList"
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Read time"
        And Number of Minutes field "publishResearchPage|numberOfMinutesField" is displayed
        And User clicks Number of Minutes field "publishResearchPage|numberOfMinutesField"
        Then User enters "10" in Number of Minutes field "publishResearchPage|numberOfMinutesField"
        When User clicks [<button>] button "publishResearchPage|<buttonSelector>"
        Then Incomplete form popup "incompleteFormPopup|headerText" with text "Incomplete form" is displayed
        And Message "incompleteFormPopup|bodyText" with text "Please check these mandatory fields:" is displayed
        And Message item list "incompleteFormPopup|bodyTextItem" contains values:
            | Title             |
            | Executive Summary |
            | Taxonomies        |
            | Full Post Content |
        And [OK] button "incompleteFormPopup|okButton" with text "Ok" is displayed
        And Close Icon "incompleteFormPopup|closeButton" is displayed
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"
        Examples:
            | button     | buttonSelector  |
            | Submit     | submitButton    |
            | Save draft | saveDraftButton |

    @regression
    @draftResearchPage
    Scenario: Company Admin uploads featured image of size more than 2 mb
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Featured Image"
        And User makes upload of file "imageSizeError.jpg" using form "publishResearchPage|featuredImageFieldInput"
        Then Error popup "imageSizeErrorPopup|errorMessage" with text "Image size must be less than 2 MB." is displayed
        When User clicks Close button "incompleteFormPopup|closeButton"
        Then Error popup "imageSizeErrorPopup|errorMessage" is not displayed
        And Featured Image Dropzone "publishResearchPage|featuredImageDropzone" is displayed
        And  Uploaded Image "publishResearchPage|uploadedFeaturedImage" is not displayed
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @regression
    @draftResearchPage
    Scenario Outline: Company Admin closes Incomplete form modal with [<button>] button
        When User clears text from Title field "publishResearchPage|titleField"
        And User clicks [Submit] button "publishResearchPage|submitButton"
        Then Incomplete form popup "incompleteFormPopup|headerText" is displayed
        When User clicks [<button>] button on Incomplete form popup "incompleteFormPopup|<buttonSelector>"
        Then Incomplete form popup "incompleteFormPopup|headerText" is not displayed
        And Publish Research Page Header "publishResearchPage|header" is displayed
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"
        Examples:
            | button | buttonSelector |
            | OK     | okButton       |
            | Close  | closeButton    |
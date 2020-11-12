@research
Feature: Verify Unsaved Changes popup on Draft Research Page

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        When User remembers text "Test_Auto_Draft_Research" with added unique Id as "researchTitle"
        And User "COMPANY_ADMIN" saves Draft "Research" with title "$researchTitle" with API
        And User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "research post"
        Then User Post "userPostsPage|articleTitlesList" with text "$researchTitle" is displayed
        And User clicks Post "userPostsPage|articleTitlesList" with text "$researchTitle" using script
        And User waits 3 seconds

    @regression
    @draftResearchPage
    Scenario Outline: Verify that Unsaved Changes popup does not appear if User clicks <button> button without entering any details on Draft Research Page
        And User clicks [<button>] button "publishResearchPage|<buttonSelector>"
        Then Unsaved changes popup "unsavedChangesPopup|headerText" is not displayed
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"
        Examples:
            | button | buttonSelector |
            | Close  | closeButton    |
            | Cancel | cancelButton   |


    @regression
    @draftResearchPage
    Scenario Outline: Verify text and buttons on Unsaved Changes popup on Draft Research Page, when User clicks <button> button
        When User enters "Updated" in Title field "publishResearchPage|titleField"
        And User clicks [<button>] button "publishResearchPage|<buttonSelector>"
        Then Unsaved Changes Popup Header "unsavedChangesPopup|headerText" with text "Close Publish Form" is displayed
        And Unsaved Changes Popup Message "unsavedChangesPopup|messageText" with text "Warning, you have unpublished content. If you choose to Continue, you will lose your changes!" is displayed
        And Unsaved Changes Cancel Button "unsavedChangesPopup|cancelButton" with text "Cancel" is displayed
        And Unsaved Changes Continue Button "unsavedChangesPopup|continueButton" with text "Continue" is displayed
        And Unsaved Changes Close Button "unsavedChangesPopup|closeButton" is displayed
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"
        Examples:
            | button | buttonSelector |
            | Close  | closeButton    |
            | Cancel | cancelButton   |

    @regression
    @draftResearchPage
    Scenario Outline: Verify that Unsaved Changes popup closes and User stays on Draft Research Page, when User clicks [<button>] button on Unsaved Changes popup
        When User clears text from Title field "publishResearchPage|titleField"
        And User enters "Test_Auto_Research_Updated" in Title field "publishResearchPage|titleField"
        And User clicks [Cancel] button on Publish Research Page "publishResearchPage|cancelButton"
        Then Unsaved Changes Popup Header "unsavedChangesPopup|headerText" is displayed
        When User clicks [<button>] button on Unsaved Changes popup "unsavedChangesPopup|<buttonSelector>"
        Then Unsaved Changes Popup Header "unsavedChangesPopup|headerText" is not displayed
        And Publish Research Page Header "publishResearchPage|header" is displayed
        And Research Title field "publishResearchPage|titleField" is displayed
        And Attribute "value" of Research Title field "publishResearchPage|titleField" is equal to "Test_Auto_Research_Updated"
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"
        Examples:
            | button | buttonSelector |
            | Close  | closeButton    |
            | Cancel | cancelButton   |

    @regression
    @draftResearchPage
    Scenario: Verify that Draft Research Page closes, when User clicks [Continue] button on Unsaved Changes popup
        When User enters "Updated" in Title field "publishResearchPage|titleField"
        And User clicks [Cancel] button on Publish Research Page "publishResearchPage|cancelButton"
        Then Unsaved Changes Popup Header "unsavedChangesPopup|headerText" is displayed
        When User clicks [Continue] button on Unsaved Changes popup "unsavedChangesPopup|continueButton"
        Then Unsaved Changes Popup Header "unsavedChangesPopup|headerText" is not displayed
        And Publish Research Page Header "publishResearchPage|header" is not displayed
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

#todo
#  @regression
#  @publishResearchPag
#  Scenario:Company Admin populates all fields, clicks Cancel, then Cancel again and checks that values are left in the fields

#todo:
#  @regression
#  @publishResearchPag
#Company Admin populates all fields, clicks Cancel, then Continue, opens Publish Research Page and checks that no values are left in the fields.
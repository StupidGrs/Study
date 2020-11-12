@research
@pendo
Feature: Verify Pendo Popup for Research Fields on Publish Research Page and Draft Research Page

    #@regression
    @PublishResearchPage
    Scenario: User verifies Pendo Popup on Publish Research page
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks [Publish] button "header|publishButton"
        And User clicks on [Research / WhitePaper] icon "modalWindow|researchIcon"
        Then Header Info icon "publishResearchPage|headerInfoIcon" is displayed
        When User clicks Pendo info icon in the Header "publishResearchPage|headerInfoIcon" by executing script
        Then Pendo popup "publishResearchPage|infoPopup" is displayed
        And Message "publishResearchPage|infoPopupMessageText" is displayed
#        And Message "publishResearchPage|infoPopupMessageText" text is equal to "TEXT:Publish_research_info_message"
        And Message "publishResearchPage|infoPopupMessageText" text is equal to "Click [Here] to view the PDF guide that outlines the article fields and what data is required for publishing."
        And Close icon "publishResearchPage|infoPopupCloseIcon" is displayed
        And Close icon "publishResearchPage|infoPopupCloseIcon" is enabled
        And [OK] button "publishResearchPage|infoPopupOkButton" is displayed
        And [OK] button "publishResearchPage|infoPopupOkButton" is enabled
        And [Here] link "publishResearchPage|infoPopupHereLink" is displayed
        And Attribute "href" of [Here] link "publishResearchPage|infoPopupHereLink" contains ".pdf"
        When User clicks [OK] button "publishResearchPage|infoPopupOkButton"
        Then Info popup "publishResearchPage|infoPopup" is not displayed

    #@regression
    @draftResearchPage
    Scenario: User verifies Pendo Popup on Draft Research page
        When User "COMPANY_ADMIN" logs in with API
        Then User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
        And User "COMPANY_ADMIN" saves Draft "Research" with title "$researchTitle" with API
        And User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "research post"
        When User Post "userPostsPage|articleTitlesList" with text "$researchTitle" is displayed
        Then User clicks Post "userPostsPage|articleTitlesList" with text "$researchTitle" using script
        When User clicks Pendo info icon in the Header "publishResearchPage|headerInfoIcon" by executing script
        Then Pendo popup "publishResearchPage|infoPopup" is displayed
        And Message "publishResearchPage|infoPopupMessageText" is displayed
#        And Message "publishResearchPage|infoPopupMessageText" text is equal to "TEXT:Publish_research_info_message"
        And Message "publishResearchPage|infoPopupMessageText" text is equal to "Click [Here] to view the PDF guide that outlines the article fields and what data is required for publishing."
        And Close icon "publishResearchPage|infoPopupCloseIcon" is displayed
        And Close icon "publishResearchPage|infoPopupCloseIcon" is enabled
        And [OK] button "publishResearchPage|infoPopupOkButton" is displayed
        And [OK] button "publishResearchPage|infoPopupOkButton" is enabled
        And [Here] link "publishResearchPage|infoPopupHereLink" is displayed
        And Attribute "href" of [Here] link "publishResearchPage|infoPopupHereLink" contains ".pdf"
        When User clicks [OK] button "publishResearchPage|infoPopupOkButton"
        Then Info popup "publishResearchPage|infoPopup" is not displayed
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"
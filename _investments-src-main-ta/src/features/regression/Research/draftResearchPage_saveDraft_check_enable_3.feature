#change PDF\Image fields and check [save draft] enabled
@research
Feature: Verify [Save draft] button becomes enabled when User updates data in [PDF\Image fields] on Draft Research Page

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        When User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
        And User "COMPANY_ADMIN" saves Draft "Research" with all fields and title "$researchTitle" with API
        And User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "research post"
        Then User Post "userPostsPage|articleTitlesList" with text "$researchTitle" is displayed
        And User clicks Post "userPostsPage|articleTitlesList" with text "$researchTitle" using script
        And [Save draft] button "publishResearchPage|saveDraftButton" is displayed
        And [Save draft] button "publishResearchPage|saveDraftButton" is disabled

    @regression
    @draftResearchPage
    Scenario: Verify [Save draft] button becomes enabled when User - removes Uploaded [PDF file]
#        "2020-09-01 Egle: Add upload file step, because can't remove upload file if file not existing"
#        When User clicks Remove Uploaded PDF File Icon "publishResearchPage|attachedPDFRemoveIconsList"
#        Then [Save draft] button "publishResearchPage|saveDraftButton" is enabled
        When User makes upload of file "testContentForUpload.pdf" using Upload field "publishResearchPage|uploadPDFFieldInput"
        Then User clicks Remove Uploaded PDF File Icon "publishResearchPage|attachedPDFRemoveIconsList"
        And [Save draft] button "publishResearchPage|saveDraftButton" is enabled
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @regression
    @draftResearchPage
    Scenario: Verify [Save draft] button becomes enabled when User - removes and uploads [PDF file]
#        "2020-09-01 Egle: Add upload file step, because can't remove upload file if file not existing"
        When User makes upload of file "testContentForUpload.pdf" using Upload field "publishResearchPage|uploadPDFFieldInput"
        And User clicks Remove Uploaded PDF File Icon "publishResearchPage|attachedPDFRemoveIconsList"
        And User makes upload of file "testContentForUpload.pdf" using form "publishResearchPage|uploadPDFFieldInput"
        Then [Save draft] button "publishResearchPage|saveDraftButton" is enabled
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @regression
    @draftResearchPage
#    Scenario Outline: Verify [Save draft] button becomes enabled when User - removes uploaded [Featured Image] "Egle: Do not need Outline,because not use Example
    Scenario: Verify [Save draft] button becomes enabled when User - removes uploaded [Featured Image]
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Featured Image"
#        "2020-09-01 Egle: Add upload file step, because can't remove upload file if file not existing"
        And User makes upload of file "testContentForUpload.png" using form "publishResearchPage|featuredImageFieldInput"
        And User clicks Remove Uploaded Image Icon "publishResearchPage|removeUploadedFeaturedImageIcon"
        Then [Save draft] button "publishResearchPage|saveDraftButton" is enabled
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @regression
    @draftResearchPage
#    Scenario Outline: Verify [Save draft] button becomes enabled when User - removes and uploads [Featured Image] "Egle: Do not need Outline,because not use Example
    Scenario: Verify [Save draft] button becomes enabled when User - removes and uploads [Featured Image]
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Featured Image"
#        "2020-09-01 Egle: Add upload file step, because can't remove upload file if file not existing"
        And User makes upload of file "testContentForUpload.png" using form "publishResearchPage|featuredImageFieldInput"
        And User clicks Remove Uploaded Image Icon "publishResearchPage|removeUploadedFeaturedImageIcon"
        And User makes upload of file "testContentForUpload.png" using form "publishResearchPage|featuredImageFieldInput"
        Then [Save draft] button "publishResearchPage|saveDraftButton" is enabled
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"
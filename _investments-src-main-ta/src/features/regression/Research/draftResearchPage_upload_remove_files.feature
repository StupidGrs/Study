@research
Feature: Verify that Company Admin is able to upload / remove uploaded files on Draft Research Page

  @regression
  @publishResearchPage
  Scenario: Company Admin uploads Featured image and then removes it on Draft Research Page.
    #create draft research without Featured Image
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Draft_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_ADMIN" saves Draft "Research" with title "$researchTitle" with API
    #open created draft research
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Profile Button "header|profileButton"
    And User clicks Posts link "header|postsLink" by executing script
    And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
    And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "research post"
    Then User Post "userPostsPage|articleTitlesList" with text "$researchTitle" is displayed
    And User clicks Post "userPostsPage|articleTitlesList" with text "$researchTitle" using script
    #Upload Featured Image
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Featured Image"
    And User makes upload of file "testContentForUpload.png" using Upload field "publishResearchPage|featuredImageFieldInput"
    Then Featured Image Dropzone "publishResearchPage|featuredImageDropzone" is not displayed
    And Uploaded Image "publishResearchPage|uploadedFeaturedImage" is displayed
    And Remove Uploaded Image Icon "publishResearchPage|removeUploadedFeaturedImageIcon" is displayed
    #Remove uploaded Featured Image
    And User clicks Remove Uploaded Image Icon "publishResearchPage|removeUploadedFeaturedImageIcon"
    Then Uploaded Image "publishResearchPage|uploadedFeaturedImage" is not displayed
    And Remove Uploaded Image Icon "publishResearchPage|removeUploadedFeaturedImageIcon" is not displayed
    And Featured Image Dropzone "publishResearchPage|featuredImageDropzone" is displayed
    And Featured Image Dropzone message "publishResearchPage|uploadPDFDropzoneMessage" with text "Drag and drop to upload a file" is displayed
    And Featured Image Dropzone icon "publishResearchPage|uploadPDFDropzoneIcon" is displayed
    #delete research
    And User deletes "Research" with "Title" equal to "$researchTitle"

  @regression
  @publishResearchPage
  Scenario: Company Admin uploads PDF File and then removes it on Draft Research Page.
    #create draft research without PDF
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Draft_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_ADMIN" saves Draft "Research" with title "$researchTitle" with API
    #open created draft research
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Profile Button "header|profileButton"
    And User clicks Posts link "header|postsLink" by executing script
    And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
    And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "research post"
    Then User Post "userPostsPage|articleTitlesList" with text "$researchTitle" is displayed
    And User clicks Post "userPostsPage|articleTitlesList" with text "$researchTitle" using script
    #Upload PDF
    When User makes upload of file "testContentForUpload.pdf" using form "publishResearchPage|uploadPDFFieldInput"
#        "2020-09-01 Egle: Remove Attachment button no longer exist"
#    Then [Remove Attachments] button "publishResearchPage|removeAttachmentsLink" is displayed
#    And [Remove Attachments] button "publishResearchPage|removeAttachmentsLink" text is equal to "Reset Dropzone Attachments"
    Then [Remove Attachments] button "publishResearchPage|attachedPDFRemoveIconsList" is displayed
    #Remove uploaded PDF
#    When User clicks [Remove Attachments] button "publishResearchPage|removeAttachmentsLink"
    When User clicks [Remove Attachments] button "publishResearchPage|attachedPDFRemoveIconsList"
    And Upload PDF Dropzone message "publishResearchPage|uploadPDFDropzoneMessage" with text "Drag and drop to upload a file" is displayed
    And Upload PDF Dropzone icon "publishResearchPage|uploadPDFDropzoneIcon" is displayed
    And Remove Attachments button "publishResearchPage|removeAttachmentsLink" is not displayed
    #delete research
    And User deletes "Research" with "Title" equal to "$researchTitle"

  @regression
  @publishResearchPage
  Scenario: Company Admin removes Featured image and then uploads new on Draft Research Page.
    #create draft research with Featured Image
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Draft_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_ADMIN" saves Draft "Research" with all fields and title "$researchTitle" with API
    #open created draft research
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Profile Button "header|profileButton"
    And User clicks Posts link "header|postsLink" by executing script
    And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
    And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "research post"
    Then User Post "userPostsPage|articleTitlesList" with text "$researchTitle" is displayed
    And User clicks Post "userPostsPage|articleTitlesList" with text "$researchTitle" using script
    #Remove originally uploaded Featured Image
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Featured Image"
#    And User clicks Remove Uploaded Image Icon "publishResearchPage|removeUploadedFeaturedImageIcon"
#    Then Uploaded Image "publishResearchPage|uploadedFeaturedImage" is not displayed
#    And Remove Uploaded Image Icon "publishResearchPage|removeUploadedFeaturedImageIcon" is not displayed
    And Featured Image Dropzone "publishResearchPage|featuredImageDropzone" is displayed
    And Featured Image Dropzone message "publishResearchPage|featuredImageDropzoneMessage" with text "Drag and drop to upload a file" is displayed
    And Featured Image Dropzone icon "publishResearchPage|featuredImageDropzoneIcon" is displayed
    #Upload Featured Image
    And User makes upload of file "testContentForUpload.png" using Upload field "publishResearchPage|featuredImageFieldInput"
    Then Featured Image Dropzone "publishResearchPage|featuredImageDropzone" is not displayed
    And Uploaded Image "publishResearchPage|uploadedFeaturedImage" is displayed
    And Remove Uploaded Image Icon "publishResearchPage|removeUploadedFeaturedImageIcon" is displayed
    #delete research
    And User deletes "Research" with "Title" equal to "$researchTitle"

  @regression
  @publishResearchPage
  Scenario: Company Admin removes PDF File and then uploads new on Draft Research Page.
    #create draft research with PDF
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Draft_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_ADMIN" saves Draft "Research" with all fields and title "$researchTitle" with API
    #open created draft research
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Profile Button "header|profileButton"
    And User clicks Posts link "header|postsLink" by executing script
    And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
    And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "research post"
    Then User Post "userPostsPage|articleTitlesList" with text "$researchTitle" is displayed
    And User clicks Post "userPostsPage|articleTitlesList" with text "$researchTitle" using script
    #Remove originally uploaded PDF
#    When User clicks Remove Uploaded PDF File Icon "publishResearchPage|attachedPDFRemoveIconsList"
    And Upload PDF Dropzone message "publishResearchPage|uploadPDFDropzoneMessage" with text "Drag and drop to upload a file" is displayed
    And Upload PDF Dropzone icon "publishResearchPage|uploadPDFDropzoneIcon" is displayed
    And Remove Attachments button "publishResearchPage|removeAttachmentsLink" is not displayed
    #Upload PDF
    When User makes upload of file "testContentForUpload.pdf" using form "publishResearchPage|uploadPDFFieldInput"
    Then [Remove Attachments] button "publishResearchPage|attachedPDFRemoveIconsList" is displayed
    #        "2020-09-01 Egle: Remove Attachment button no longer exist"
#    Then [Remove Attachments] button "publishResearchPage|removeAttachmentsLink" is displayed
#    And [Remove Attachments] button "publishResearchPage|removeAttachmentsLink" text is equal to "Reset Dropzone Attachments"
    #delete research
    And User deletes "Research" with "Title" equal to "$researchTitle"


#TODO
#Add tests to upload file and save, open and check file is present
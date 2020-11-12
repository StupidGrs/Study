@research
Feature: Verify that Company Admin is able to remove uploaded files on Publish Research Page

    Background:
        Given User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks [Publish] button "header|publishButton"
        And User clicks on [Research / WhitePaper] icon "modalWindow|researchIcon"

    @regression
    @publishResearchPage
    Scenario: Company Admin uploads Featured image and then removes it on Publish Research Page
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Featured Image"
        And User makes upload of file "testContentForUpload.png" using Upload field "publishResearchPage|featuredImageFieldInput"
        Then Featured Image Dropzone "publishResearchPage|featuredImageDropzone" is not displayed
        And Uploaded Image "publishResearchPage|uploadedFeaturedImage" is displayed
        And Remove Uploaded Image Icon "publishResearchPage|removeUploadedFeaturedImageIcon" is displayed
        When User clicks Remove Uploaded Image Icon "publishResearchPage|removeUploadedFeaturedImageIcon"
        Then Uploaded Image "publishResearchPage|uploadedFeaturedImage" is not displayed
        And Remove Uploaded Image Icon "publishResearchPage|removeUploadedFeaturedImageIcon" is not displayed
        And Featured Image Dropzone "publishResearchPage|featuredImageDropzone" is displayed
        And Featured Image Dropzone message "publishResearchPage|uploadPDFDropzoneMessage" with text "Drag and drop to upload a file" is displayed
        And Featured Image Dropzone icon "publishResearchPage|uploadPDFDropzoneIcon" is displayed

    @regression
    @publishResearchPage
    Scenario: Company Admin uploads PDF File and then removes it on Publish Research Page
        When User makes upload of file "testContentForUpload.pdf" using form "publishResearchPage|uploadPDFFieldInput"
        Then [Remove Attachments] button "publishResearchPage|attachedPDFRemoveIconsList" is displayed
#        "2020-09-01 Egle: Remove Attachment button no longer exist"
#        Then [Remove Attachments] button "publishResearchPage|removeAttachmentsLink" is displayed
#        And [Remove Attachments] button "publishResearchPage|removeAttachmentsLink" text is equal to "Remove Attachment"
#        When User clicks [Remove Attachments] button "publishResearchPage|removeAttachmentsLink"
        When User clicks [Remove Attachments] button "publishResearchPage|attachedPDFRemoveIconsList"
        And Upload PDF Dropzone message "publishResearchPage|uploadPDFDropzoneMessage" with text "Drag and drop to upload a file" is displayed
        And Upload PDF Dropzone icon "publishResearchPage|uploadPDFDropzoneIcon" is displayed
        And Remove Attachments button "publishResearchPage|removeAttachmentsLink" is not displayed
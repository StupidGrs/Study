@news
Feature: Verify that Company Admin is able to remove uploaded files on Publsih News Page

    Background:
        Given User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks [Publish] button "header|publishButton"
        And User clicks on [News / Blog] icon "modalWindow|newsIcon"

    @regression
    @publishNewsPage
    Scenario: Company Admin uploads Featured image and then removes it on Publish News Page
        When User clicks Right Sidebar Item "publishNewsPage|rightSidebarAccordionHeadersTextsList" with text "Featured Image"
        And User makes upload of file "testContentForUpload.png" using Upload field "publishNewsPage|featuredImageFieldInput"
        Then Featured Image Dropzone "publishNewsPage|featuredImageDropzone" is not displayed
        And Uploaded Image "publishNewsPage|uploadedFeaturedImage" is displayed
        And Remove Uploaded Image Icon "publishNewsPage|removeUploadedFeaturedImageIcon" is displayed
        When User clicks Remove Uploaded Image Icon "publishNewsPage|removeUploadedFeaturedImageIcon"
        Then Uploaded Image "publishNewsPage|uploadedFeaturedImage" is not displayed
        And Remove Uploaded Image Icon "publishNewsPage|removeUploadedFeaturedImageIcon" is not displayed
        And Featured Image Dropzone "publishNewsPage|featuredImageDropzone" is displayed
        And Featured Image Dropzone message "publishNewsPage|uploadPDFDropzoneMessage" with text "Drag and drop to upload a file" is displayed
        And Featured Image Dropzone icon "publishNewsPage|uploadPDFDropzoneIcon" is displayed

    @regression
    @publishNewsPage
    Scenario: Company Admin uploads PDF File and then removes it on Publish News Page
        When User makes upload of file "testContentForUpload.pdf" using form "publishNewsPage|uploadPDFFieldInput"
#        Egle: 2020-09-09 Reset Dropzone Attachments button no longer exist
#        Then [Remove Attachments] button "publishNewsPage|removeAttachmentsLink" is displayed
#        And [Remove Attachments] button "publishNewsPage|removeAttachmentsLink" text is equal to "Reset Dropzone Attachments"
#        When User clicks [Remove Attachments] button "publishNewsPage|removeAttachmentsLink"
        When User clicks [Remove Attachments] button "publishResearchPage|attachedPDFRemoveIconsList"
        And Upload PDF Dropzone message "publishNewsPage|uploadPDFDropzoneMessage" with text "Drag and drop to upload a file" is displayed
        And Upload PDF Dropzone icon "publishNewsPage|uploadPDFDropzoneIcon" is displayed
        And Remove Attachments button "publishNewsPage|removeAttachmentsLink" is not displayed
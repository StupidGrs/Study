@research
Feature: Open Draft Research, click [Submit] button with\without changes, verify data

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
        And [Submit] button "publishResearchPage|submitButton" is displayed
        And [Submit] button "publishResearchPage|submitButton" is enabled

    @regression
    @draftResearchPage
    Scenario: Verify Success toast when User clicks [Submit] button on Draft Research Page
        When User clicks [Submit] button "publishResearchPage|submitButton"
        Then Toast message "toast|toastMessage" is displayed
        And Toast message "toast|toastMessage" text is equal to "TEXT:Publish_research_toast_success"
        And Publish Research Page Header "publishResearchPage|header" is not displayed
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @regression
    @draftResearchPage
    @knownIssue @SRC-1369
    Scenario: Verify User is able to [Submit] Draft Research without changes
        When User clicks [Submit] button "publishResearchPage|submitButton"
        #Open submitted research
        When User refreshes page
        Then User waits for Research "userPostsPage|articlesList" with text "$researchTitle" visibility within 10 seconds
        And Post Status "userPostsPage|articleStatusesList" with text "Approval Pending" on Post "userPostsPage|articlesList" with text "$researchTitle" is displayed
        #Check values
        When User clicks Post "userPostsPage|articleTitlesList" with text "$researchTitle" using script
        Then Research Title on Research Preview Page "researchDetailsPage|title" is displayed
        And Research Title "researchDetailsPage|title" text is equal to "$researchTitle"
        And Research Exceprt "researchDetailsPage|excerpt" text is equal to "Test_Auto Executive Summary"
        And Research Type "researchDetailsPage|researchType" text is equal to "Speech"
        And Research Header Company Name "researchDetailsPage|headerCompanyName" text is equal to "CompAuto"
        And Research Header Read Time "researchDetailsPage|headerReadTime" text is equal to "10 min read"
        And Research Content "researchDetailsPage|content" text is equal to "Test_Auto Content"
        #TODO
        #Add method to remember selected date and calculate "ago" time to check "articleHeaderDate" exact value
        #Date in the Header
        And Research Header Date "researchDetailsPage|headerDate" is displayed
        #Video
        And Video "researchDetailsPage|videoIframe" is displayed
        And Attribute "src" of Video "researchDetailsPage|videoIframe" is equal to "https://www.youtube.com/embed/W6NZfCO5SIk"
        #[Visit External Link] button
        And [Visit External Link] button "researchDetailsPage|visitExternalLinkButton" is displayed
        And Attribute "href" of [Visit External Link] button "researchDetailsPage|visitExternalLinkButton" is equal to "https://www.wikipedia.org/"
#        #[Download the full report] "2020-09-01 Egle: Remove [Download the full report] button no longer exist"
#        And [Download the full report] button "researchDetailsPage|downloadFullReportButton" is displayed
#        And Attribute "href" of [Download the full report] button "researchDetailsPage|downloadFullReportButton" contains ".pdf"
        #Tags in the Footer
        And Tags List "researchDetailsPage|footerTagsList" count is equal to 1
        And Tags List "researchDetailsPage|footerTagsList" text is equal to "Investing"
        #Check Left block elements
        And Left Block "researchDetailsPage|leftBlock" is displayed
#    "2020-09-01 Egle: Remove Download Attachment Icon no longer exist"
#        And Download Attachment Icon "researchDetailsPage|leftBlockDownloadAttachIcon" is displayed
#        And Attribute "href" of Download Attachment link "researchDetailsPage|leftBlockDownloadAttachLink" contains ".pdf"
        #Check Disclaimer
        And Disclaimer Label "researchDetailsPage|disclaimerLabel" text is equal to "Disclaimer"
        And Disclaimer Text "researchDetailsPage|disclaimerText" is displayed
        #Check video is loaded in iframe (step will fail in chrome if video is not displayed, but can pass in edge/firefox/ie)
        #And Video Error "researchDetailsPage|videoError" is not displayed in iframe "researchDetailsPage|videoIframe"
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @regression
    @draftResearchPage
    @knownIssue @SRC-1369
    Scenario: Verify user is able to [Submit] Draft Research with all changed fields
        #Update fields
        #Title
        When User enters "_UPDATED" in Title field "publishResearchPage|titleField"
        #Remember Title to delete Research
        And User remembers value of "value" attribute of "publishResearchPage|titleField" as "updatedResearchTitle"
        #Executive Summary
        And User clears text from Executive Summary field "publishResearchPage|executiveSummaryField"
        And User enters "Excerpt_UPDATED" in Executive Summary field "publishResearchPage|executiveSummaryField"
        #Uploaded PDF
        #        "2020-09-01 Egle: Add upload file step, because can't remove upload file if file not existing"
        And User makes upload of file "testContentForUpload.pdf" using Upload field "publishResearchPage|uploadPDFFieldInput"
        And User clicks Remove Uploaded PDF File Icon "publishResearchPage|attachedPDFRemoveIconsList"
        #Link to Content
        And User clears text from Link to Content field "publishResearchPage|linkToContent"
        And User enters "https://www.wikipedia.org/_UPDATED" in Link to Content field "publishResearchPage|linkToContent"
        #Full Post Content
        And User enters "Content_UPDATED" in Full Post Content field "publishResearchPage|fullPostContentField" by executing script
        #Date
        When User clicks Date Picker icon "publishResearchPage|datePickerIcon"
        And User clicks Next Month icon "calendar|nextMonthButton"
        And User clicks Day icon "calendar|daysList" with text "23"
        Then User remembers text of "publishResearchPage|dateFieldValue" as "updatedDate"
        #Research Type
        And User selects item "option" with text "Publication" from Research Type dropdown "publishResearchPage|researchTypeDropdownField"
        #Taxonomies
        And User selects item "option" with text "Strategy" from Taxonomies dropdown "publishResearchPage|taxonomiesDropdownField"
        #Tag
        And User enters "Taxes" in the Tag field "publishResearchPage|tagsField"
        And User waits for Tag item "publishResearchPage|tagsAutoCompleteItem" with text "Taxes" visibility within 5 seconds
        And User clicks Tag item "publishResearchPage|tagsAutoCompleteItem" with text "Taxes"
        #Read Time
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Read time"
        And User clicks Number of Minutes field "publishResearchPage|numberOfMinutesField"
        And User clears text from Read Time field "publishResearchPage|numberOfMinutesField"
        Then User enters "5" in Read Time field "publishResearchPage|numberOfMinutesField"
        #Featured Image
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Featured Image"
        #        "2020-09-01 Egle: Add upload file step, because can't remove upload file if file not existing"
        And User makes upload of file "featuredForEvent.png" using Upload field "publishResearchPage|featuredImageFieldInput"
        And User clicks Remove Uploaded Image Icon "publishResearchPage|removeUploadedFeaturedImageIcon"
        #Video Link
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Video Link"
        And User clicks Video Link field "publishResearchPage|videoLinkField"
        And User clears text from Video Link field "publishResearchPage|videoLinkField"
        Then User enters "https://www.youtube.com/watch?v=eIrMbAQSU34" in Video Link field "publishResearchPage|videoLinkField"
        #Authors
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Authors"
        And User clears text from Authors "publishResearchPage|authorField"
        Then User enters "Test_Auto Author Updated" in Authors field "publishResearchPage|authorField"
        #Regions
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Regions"
#        Then Checkbox "publishResearchPage|regionCheckBoxInputsList" on Row "publishResearchPage|regionRowsList" with text "UK" is selected
        When User clicks checkbox "publishResearchPage|regionCheckBoxLabelsList" with text "US" by executing script
#        Then Checkbox "publishResearchPage|regionCheckBoxInputsList" on Row "publishResearchPage|regionRowsList" with text "US" is selected
        #Audience
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Audience"
        Then Checkbox "publishResearchPage|targetAudienceCheckBoxInputsList" on Row "publishResearchPage|targetAudienceRowsList" with text "Asset Manager" is selected
        When User clicks checkbox "publishResearchPage|targetAudienceCheckBoxLabelsList" with text "Mercer Consultant"
        Then Checkbox "publishResearchPage|targetAudienceCheckBoxInputsList" on Row "publishResearchPage|targetAudienceRowsList" with text "Mercer Consultant" is selected
        #Click [Submit] button
        And User scrolls page to top
        When User clicks [Submit] button "publishResearchPage|submitButton"
        #Open Submitted research
        When User refreshes page
        Then User waits for Research "userPostsPage|articleTitlesList" with text "$updatedResearchTitle" visibility within 10 seconds
        And Post Status "userPostsPage|articleStatusesList" with text "Approval Pending" on Post "userPostsPage|articlesList" with text "$updatedResearchTitle" is displayed
        #Check updated values
        When User clicks Post "userPostsPage|articleTitlesList" with text "$updatedResearchTitle" using script
        And Research Title "researchDetailsPage|title" text is equal to "$updatedResearchTitle"
        And Research Exceprt "researchDetailsPage|excerpt" text is equal to "Excerpt_UPDATED"
        And Research Type "researchDetailsPage|researchType" text is equal to "Publication"
        And Research Header Company Logo "researchDetailsPage|headerCompanyLogoIcon" is displayed
        And Research Header Company Name "researchDetailsPage|headerCompanyName" text is equal to "CompAuto"
        And Research Header Read Time "researchDetailsPage|headerReadTime" text is equal to "5 min read"
        #TODO
        #Add method to remember selected date and calculate "ago" time to check "articleHeaderDate" exact value
        And Research Header Date "researchDetailsPage|headerDate" is displayed
        And Research Content "researchDetailsPage|content" text is equal to "Content_UPDATED"
        And Attribute "src" of Video Link "researchDetailsPage|videoIframe" is equal to "https://www.youtube.com/embed/eIrMbAQSU34"
        And Attribute "href" of [Visit External Link] button "researchDetailsPage|visitExternalLinkButton" is equal to "https://www.wikipedia.org/_UPDATED"
        And [Download the full report] button "researchDetailsPage|downloadFullReportButton" is not displayed
        And Tags list "researchDetailsPage|footerTagsList" count is equal to 2
        And Tag "researchDetailsPage|footerTagsList" with text "Investing" is displayed
        And Tag "researchDetailsPage|footerTagsList" with text "Taxes" is displayed
        #Check Left block elements
        And Left Block "researchDetailsPage|leftBlock" is displayed
        And Download Attachment Icon "researchDetailsPage|leftBlockDownloadAttachIcon" is not displayed
        #Check Disclaimer
        And Disclaimer Label "researchDetailsPage|disclaimerLabel" text is equal to "Disclaimer"
        And Disclaimer Text "researchDetailsPage|disclaimerText" is displayed
        #Check video is loaded in iframe (step will fail in chrome if video is not displayed, but can pass in edge/firefox/ie)
        #And Video Error "researchDetailsPage|videoError" is not displayed in iframe "researchDetailsPage|videoIframe"
        #delete research
        And User deletes "Research" with "Title" equal to "$updatedResearchTitle"
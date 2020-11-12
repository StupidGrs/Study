@research
Feature: Verify all fields of published Research in Admin

  Background:
    Given User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks [Publish] button "header|publishButton"
    And User clicks on [Research / WhitePaper] icon "modalWindow|researchIcon"
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    And User enters "$researchTitle" in Title field "publishResearchPage|titleField"
    And User enters "Test_Auto Executive Summary" in Executive Summary text area "publishResearchPage|executiveSummaryField"
    And User makes upload of file "testContentForUpload.pdf" using form "publishResearchPage|uploadPDFFieldInput"
    And User enters "https://www.wikipedia.org/" in Link to Content field "publishResearchPage|linkToContent"
    And User enters "Test_Auto Content" in Research Content field "publishResearchPage|fullPostContentField" by executing script
    And User clicks Date Picker icon "publishResearchPage|datePickerIcon"
    And User clicks Next Month icon "calendar|nextMonthButton"
    And User clicks Day icon "calendar|daysList" with text "23"
    And User remembers text of "publishResearchPage|dateFieldValue" as "researchDate"
    And User selects item "option" with text "Speech" from Research Type dropdown "publishResearchPage|researchTypeDropdownField"
    #And User enters "Automation Company" in Company field "publishResearchPage|mercerCompaniesAutocompleteField"
    #And User clicks company Item "publishResearchPage|mercerCompaniesAutocompleteItem" with text "Automation Company"
    And User selects item "option" with text "Hot Topics" from Taxonomies dropdown "publishResearchPage|taxonomiesDropdownField"
    And User enters "Investing" in the Tag field "publishResearchPage|tagsField"
    And User waits for Tag item "publishResearchPage|tagsAutoCompleteItem" with text "Investing" visibility within 5 seconds
    And User clicks Tag item "publishResearchPage|tagsAutoCompleteItem" with text "Investing"
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Read time"
    And User clicks Number of Minutes field "publishResearchPage|numberOfMinutesField"
    Then User enters "10" in Number of Minutes field "publishResearchPage|numberOfMinutesField"
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Featured Image"
    Then User makes upload of file "testContentForUpload.png" using form "publishResearchPage|featuredImageFieldInput"
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Video Link"
    And User clicks Video Link field "publishResearchPage|videoLinkField"
    Then User enters "https://www.youtube.com/watch?v=W6NZfCO5SIk" in Video Link field "publishResearchPage|videoLinkField"
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Regions"
    Then User clicks checkbox "publishResearchPage|regionCheckBoxLabelsList" with text "UK"
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Audience"
    Then User clicks checkbox "publishResearchPage|targetAudienceCheckBoxLabelsList" with text "Mercer Consultant"
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Authors"
    Then User enters "Test Automation User" in Author field "publishResearchPage|authorField"
    And User scrolls page to top
    When User clicks Submit button "publishResearchPage|submitButton"
    Then Toast message "toast|toastMessage" is displayed
    And Toast message "toast|toastMessage" text is equal to "TEXT:Publish_research_toast_success"
    And User clicks Profile button "header|profileButton"
    And User clicks Profile Menu Item "header|profileMenuItemsList" with text "Logout"

  @smoke
  @regression
  Scenario: Verify all fields of published Research in Admin
    #Login as Global Admin and open submitted research in Moderate Contant
    When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "header|settingsButton"
    And User clicks Moderate Content link "header|moderateContentLink" by executing script
    And User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
    And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
    And User waits for Table Row "contentListPage|tableRowsList" with text "$researchTitle" visibility within 3 seconds
    And User clicks Title "contentListPage|titleList" on Table Row "contentListPage|tableRowsList" with text "$researchTitle"
    #Verify all fields
    And User scrolls page to top
    And Attribute "value" of Title field "moderateResearchPage|titleField" is equal to "$researchTitle"
    And Attribute "value" of Content Url field "moderateResearchPage|contentUrlField" is equal to "https://www.wikipedia.org/"
    And Attribute "value" of Url Label field "moderateResearchPage|urlLabelField" is equal to ""
    And Excerpt field "moderateResearchPage|excerptField" text is equal to "Test_Auto Executive Summary"
    And Content field "moderateResearchPage|contentField" text is equal to "Test_Auto Content"
    And Attribute "value" of Read Time field "moderateResearchPage|readTimeField" is equal to "10"
    And Disclaimer field "moderateResearchPage|disclaimerField" text is equal to ""
    And Doc Type field "moderateResearchPage|articleDocTypeField" text is equal to "Speech "
#    And "moderateResearchPage|dateFieldInputValue" date is equal to "$researchDate" date
    And Attribute "value" of Company field "moderateResearchPage|companyAutocompleteField" is equal to "CompAuto"
    And Selected Region Option "moderateResearchPage|regionsSelectedOptionsList" with text "UK" is displayed
    And Target Audience checkbox "moderateResearchPage|targetAudienceCheckBoxInputsList" on Target Audience "moderateResearchPage|targetAudienceOptionsList" with text "Mercer Consultant" is selected
    And Taxonomy "moderateResearchPage|taxonomiesSelectedOptionsList" with text "Hot Topics" is displayed
    And Tag "moderateResearchPage|tagsSelectedList" with text "Investing" is displayed
    And Featured image dropzone "moderateResearchPage|featuredImageDropzone" is displayed
#    And Uploaded Featured image "moderateResearchPage|featuredImageUploaded" is displayed
#    And Remove Featured image button "moderateResearchPage|featureImageRemoveButton" is displayed
#    And Remove Featured image button "moderateResearchPage|featureImageRemoveButton" is enabled
#    And Attachments dropzone "moderateResearchPage|attachmentsDropzone" is not displayed
#    And Added Attachments "moderateResearchPage|attachmetsItemsList" with text "testContentForUpload.pdf" is displayed
    And User deletes "Research" with "Title" equal to "$researchTitle"
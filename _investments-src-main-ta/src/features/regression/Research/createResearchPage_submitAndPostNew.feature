@research
Feature: Company Admin creates Researches with [Submit & Add another] button

  Background:
    Given User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks [Publish] button "header|publishButton"
    And User clicks on [Research / WhitePaper] icon "modalWindow|researchIcon"
    And [Submit & Add another] button "publishResearchPage|submitAndAddAnotherButton" is displayed

  @regression
  @publishResearchPage
  Scenario: Company Admin submits Research with all fields populated and clicks [Submit & Add another] button
    When User remembers text "Test_Auto_Research" with added unique Id as "researchTitle_1"
    Then User enters "$researchTitle_1" in Title field "publishResearchPage|titleField"
    And User enters "Test_Auto Executive Summary" in Executive Summary text area "publishResearchPage|executiveSummaryField"
    And User makes upload of file "testContentForUpload.pdf" using form "publishResearchPage|uploadPDFFieldInput"
    And User enters "https://www.wikipedia.org/" in Link to Content field "publishResearchPage|linkToContent"
    And User enters "Test_Auto Content" in Research Content field "publishResearchPage|fullPostContentField" by executing script
    And User clicks Date Picker icon "publishResearchPage|datePickerIcon"
    And User clicks Next Month icon "calendar|nextMonthButton"
    And User clicks Day icon "calendar|daysList" with text "23"
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
    When User clicks [Submit & Add another] button "publishResearchPage|submitAndAddAnotherButton"
    Then Toast message "toast|toastMessage" is displayed
    And Toast message "toast|toastMessage" text is equal to "TEXT:Publish_research_toast_success"
    And User clicks Close button "toast|toastCloseIcon"
    And Publish Research Page Header "publishResearchPage|header" is displayed
    #2nd Research Submit
    When User remembers text "Test_Auto_Research" with added unique Id as "researchTitle_2"
    Then User enters "$researchTitle_2" in Title field "publishResearchPage|titleField"
    And User enters "Test_Auto Executive Summary" in Executive Summary text area "publishResearchPage|executiveSummaryField"
    And User makes upload of file "testContentForUpload.pdf" using form "publishResearchPage|uploadPDFFieldInput"
    And User enters "https://www.wikipedia.org/" in Link to Content field "publishResearchPage|linkToContent"
    And User enters "Test_Auto Content" in Research Content field "publishResearchPage|fullPostContentField" by executing script
    And User clicks Date Picker icon "publishResearchPage|datePickerIcon"
    And User clicks Next Month icon "calendar|nextMonthButton"
    And User clicks Day icon "calendar|daysList" with text "23"
    And User selects item "option" with text "Speech" from Research Type dropdown "publishResearchPage|researchTypeDropdownField"
    #And User enters "Automation Company" in Company field "publishResearchPage|mercerCompaniesAutocompleteField"
    #And User clicks company Item "publishResearchPage|mercerCompaniesAutocompleteItem" with text "Automation Company"
    And User selects item "option" with text "Hot Topics" from Taxonomies dropdown "publishResearchPage|taxonomiesDropdownField"
    And User enters "Investing" in the Tag field "publishResearchPage|tagsField"
    And User waits for Tag item "publishResearchPage|tagsAutoCompleteItem" with text "Investing" visibility within 5 seconds
    And User clicks Tag item "publishResearchPage|tagsAutoCompleteItem" with text "Investing"
    And User enters "10" in Number of Minutes field "publishResearchPage|numberOfMinutesField"
    And User makes upload of file "testContentForUpload.png" using form "publishResearchPage|featuredImageFieldInput"
    And User enters "https://www.youtube.com/watch?v=W6NZfCO5SIk" in Video Link field "publishResearchPage|videoLinkField"
    And User clicks checkbox "publishResearchPage|regionCheckBoxLabelsList" with text "UK"
    And User clicks checkbox "publishResearchPage|targetAudienceCheckBoxLabelsList" with text "Mercer Consultant"
    And User enters "Test Automation User" in Author field "publishResearchPage|authorField"
    And User scrolls page to top
    When User clicks [Submit] button "publishResearchPage|submitButton"
    Then Toast message "toast|toastMessage" is displayed
    And Toast message "toast|toastMessage" text is equal to "TEXT:Publish_research_toast_success"
    And Publish Research Page Header "publishResearchPage|header" is not displayed
    And User deletes "Research" with "Title" equal to "$researchTitle_1"
    And User deletes "Research" with "Title" equal to "$researchTitle_2"

  @smoke
  @publishResearchPage
  Scenario: Company Admin submits Research with mandatory fields populated
    When User remembers text "Test_Auto_Research" with added unique Id as "researchTitle_1"
    Then User enters "$researchTitle_1" in Title field "publishResearchPage|titleField"
    And User enters "Test_Auto Executive Summary" in Executive Summary text area "publishResearchPage|executiveSummaryField"
    And User enters "https://www.wikipedia.org/" in Link to Content field "publishResearchPage|linkToContent"
    And User enters "Test_Auto Content" in Research Content field "publishResearchPage|fullPostContentField" by executing script
    And User clicks Date Picker icon "publishResearchPage|datePickerIcon"
    And User clicks Next Month icon "calendar|nextMonthButton"
    And User clicks Day icon "calendar|daysList" with text "23"
    And User selects item "option" with text "Speech" from Research Type dropdown "publishResearchPage|researchTypeDropdownField"
    And User selects item "option" with text "Hot Topics" from Taxonomies dropdown "publishResearchPage|taxonomiesDropdownField"
    And User scrolls page to top
    When User clicks [Submit & Add another] button "publishResearchPage|submitAndAddAnotherButton"
    Then Toast message "toast|toastMessage" is displayed
    And Toast message "toast|toastMessage" text is equal to "TEXT:Publish_research_toast_success"
    And User clicks Close button "toast|toastCloseIcon"
    And Publish Research Page Header "publishResearchPage|header" is displayed
    #2nd Research Submit
    When User remembers text "Test_Auto_Research" with added unique Id as "researchTitle_2"
    Then User enters "$researchTitle_2" in Title field "publishResearchPage|titleField"
    And User enters "Test_Auto Executive Summary" in Executive Summary text area "publishResearchPage|executiveSummaryField"
    And User enters "https://www.wikipedia.org/" in Link to Content field "publishResearchPage|linkToContent"
    And User enters "Test_Auto Content" in Research Content field "publishResearchPage|fullPostContentField" by executing script
    And User clicks Date Picker icon "publishResearchPage|datePickerIcon"
    And User clicks Next Month icon "calendar|nextMonthButton"
    And User clicks Day icon "calendar|daysList" with text "23"
    And User selects item "option" with text "Speech" from Research Type dropdown "publishResearchPage|researchTypeDropdownField"
    And User selects item "option" with text "Hot Topics" from Taxonomies dropdown "publishResearchPage|taxonomiesDropdownField"
    And User scrolls page to top
    When User clicks [Submit] button "publishResearchPage|submitButton"
    Then Toast message "toast|toastMessage" is displayed
    And Toast message "toast|toastMessage" text is equal to "TEXT:Publish_research_toast_success"
    And Publish Research Page Header "publishResearchPage|header" is not displayed
    And User deletes "Research" with "Title" equal to "$researchTitle_1"
    And User deletes "Research" with "Title" equal to "$researchTitle_2"
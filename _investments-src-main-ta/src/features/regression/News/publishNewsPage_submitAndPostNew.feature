@news
Feature: Company Admin creates News with [Submit & Add another] button

  Background:
    Given User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks [Publish] button "header|publishButton"
    And User clicks on [News / Blog] icon "modalWindow|newsIcon"
    And [Submit & Add another] button "publishNewsPage|submitAndAddAnotherButton" is displayed

  @regression
  @publishNewsPage
  Scenario: Company Admin submits News with all fields populated and clicks [Submit & Add another] button
    When User remembers text "Test_Auto_News" with added unique Id as "newsTitle_1"
    Then User enters "$newsTitle_1" in Title field "publishNewsPage|titleField"
    And User enters "Test_Auto Executive Summary" in Executive Summary text area "publishNewsPage|executiveSummaryField"
    And User makes upload of file "testContentForUpload.pdf" using form "publishNewsPage|uploadPDFFieldInput"
    And User enters "https://www.wikipedia.org/" in Link to Content field "publishNewsPage|linkToContent"
    And User enters "Test_Auto News Content" in News Content field "publishNewsPage|fullPostContentField" by executing script
    And User clicks Date Picker icon "publishNewsPage|datePickerIcon"
    And User clicks Next Month icon "calendar|nextMonthButton"
    And User clicks Day icon "calendar|daysList" with text "23"
    #And User enters "Automation Company" in Company field "publishNewsPage|mercerCompaniesAutocompleteField"
    #And User clicks company Item "publishNewsPage|mercerCompaniesAutocompleteItem" with text "Automation Company"
    And User selects item "option" with text "Hot Topics" from Taxonomies dropdown "publishNewsPage|taxonomiesDropdownField"
    And User enters "Investing" in the Tag field "publishNewsPage|tagsField"
    And User waits for Tag item "publishNewsPage|tagsAutoCompleteItem" with text "Investing" visibility within 5 seconds
    And User clicks Tag item "publishNewsPage|tagsAutoCompleteItem" with text "Investing"
    When User clicks Right Sidebar Item "publishNewsPage|rightSidebarAccordionHeadersTextsList" with text "Read time"
    And User clicks Number of Minutes field "publishNewsPage|numberOfMinutesField"
    Then User enters "10" in Number of Minutes field "publishNewsPage|numberOfMinutesField"
    When User clicks Right Sidebar Item "publishNewsPage|rightSidebarAccordionHeadersTextsList" with text "Featured Image"
    Then User makes upload of file "testContentForUpload.png" using form "publishNewsPage|featuredImageFieldInput"
    When User clicks Right Sidebar Item "publishNewsPage|rightSidebarAccordionHeadersTextsList" with text "Video Link"
    And User clicks Video Link field "publishNewsPage|videoLinkField"
    Then User enters "https://www.youtube.com/watch?v=W6NZfCO5SIk" in Video Link field "publishNewsPage|videoLinkField"
    When User clicks Right Sidebar Item "publishNewsPage|rightSidebarAccordionHeadersTextsList" with text "Regions"
    Then User clicks checkbox "publishNewsPage|regionCheckBoxLabelsList" with text "UK"
    When User clicks Right Sidebar Item "publishNewsPage|rightSidebarAccordionHeadersTextsList" with text "Authors"
    And User clicks Authors field "publishNewsPage|authorField"
    Then User enters "Test Automation User" in Author field "publishNewsPage|authorField"
    And User scrolls page to top
    When User clicks [Submit & Add another] button "publishNewsPage|submitAndAddAnotherButton"
    Then Toast message "toast|toastMessage" is displayed
    And Toast message "toast|toastMessage" text is equal to "TEXT:Publish_news_toast_success"
    And User clicks Close Toast icon "toast|toastCloseIcon"
    And Publish News Page Header "publishNewsPage|header" is displayed
    #2nd News Submit
    When User remembers text "Test_Auto_News" with added unique Id as "newsTitle_2"
    Then User enters "$newsTitle_2" in Title field "publishNewsPage|titleField"
    And User enters "Test_Auto Executive Summary" in Executive Summary text area "publishNewsPage|executiveSummaryField"
    And User makes upload of file "testContentForUpload.pdf" using form "publishNewsPage|uploadPDFFieldInput"
    And User enters "https://www.wikipedia.org/" in Link to Content field "publishNewsPage|linkToContent"
    And User enters "Test_Auto News Content" in News Content field "publishNewsPage|fullPostContentField" by executing script
    And User clicks Date Picker icon "publishNewsPage|datePickerIcon"
    And User clicks Next Month icon "calendar|nextMonthButton"
    And User clicks Day icon "calendar|daysList" with text "23"
    #And User enters "Automation Company" in Company field "publishNewsPage|mercerCompaniesAutocompleteField"
    #And User clicks company Item "publishNewsPage|mercerCompaniesAutocompleteItem" with text "Automation Company"
    And User selects item "option" with text "Hot Topics" from Taxonomies dropdown "publishNewsPage|taxonomiesDropdownField"
    And User enters "Investing" in the Tag field "publishNewsPage|tagsField"
    And User waits for Tag item "publishNewsPage|tagsAutoCompleteItem" with text "Investing" visibility within 5 seconds
    And User clicks Tag item "publishNewsPage|tagsAutoCompleteItem" with text "Investing"
    And User enters "10" in Number of Minutes field "publishNewsPage|numberOfMinutesField"
    And User makes upload of file "testContentForUpload.png" using form "publishNewsPage|featuredImageFieldInput"
    And User enters "https://www.youtube.com/watch?v=W6NZfCO5SIk" in Video Link field "publishNewsPage|videoLinkField"
    And User clicks checkbox "publishNewsPage|regionCheckBoxLabelsList" with text "UK"
    And User enters "Test Automation User" in Author field "publishNewsPage|authorField"
    And User scrolls page to top
    When User clicks [Submit] button "publishNewsPage|submitButton"
    Then Toast message "toast|toastMessage" is displayed
    And Toast message "toast|toastMessage" text is equal to "TEXT:Publish_news_toast_success"
    And Publish News Page Header "publishNewsPage|header" is not displayed
    And User deletes "News" with "Title" equal to "$newsTitle_1"
    And User deletes "News" with "Title" equal to "$newsTitle_2"

  @smoke
  @publishNewsPage
  @regression
  Scenario: Company Admin submits News with mandatory fields populated
    When User remembers text "Test_Auto_News" with added unique Id as "newsTitle_1"
    Then User enters "$newsTitle_1" in Title field "publishNewsPage|titleField"
    And User enters "Test_Auto Executive Summary" in Executive Summary text area "publishNewsPage|executiveSummaryField"
    And User enters "https://www.wikipedia.org/" in Link to Content field "publishNewsPage|linkToContent"
    And User enters "Test_Auto News Content" in News Content field "publishNewsPage|fullPostContentField" by executing script
    And User clicks Date Picker icon "publishNewsPage|datePickerIcon"
    And User clicks Next Month icon "calendar|nextMonthButton"
    And User clicks Day icon "calendar|daysList" with text "23"
    And User selects item "option" with text "Hot Topics" from Taxonomies dropdown "publishNewsPage|taxonomiesDropdownField"
    And User scrolls page to top
    When User clicks [Submit & Add another] button "publishNewsPage|submitAndAddAnotherButton"
    Then Toast message "toast|toastMessage" is displayed
    And Toast message "toast|toastMessage" text is equal to "TEXT:Publish_news_toast_success"
    And User clicks Close Toast icon "toast|toastCloseIcon"
    And Publish News Page Header "publishNewsPage|header" is displayed
    #2nd News Submit
    When User remembers text "Test_Auto_News" with added unique Id as "newsTitle_2"
    Then User enters "$newsTitle_2" in Title field "publishNewsPage|titleField"
    And User enters "Test_Auto Executive Summary" in Executive Summary text area "publishNewsPage|executiveSummaryField"
    And User enters "https://www.wikipedia.org/" in Link to Content field "publishNewsPage|linkToContent"
    And User enters "Test_Auto News Content" in News Content field "publishNewsPage|fullPostContentField" by executing script
    And User clicks Date Picker icon "publishNewsPage|datePickerIcon"
    And User clicks Next Month icon "calendar|nextMonthButton"
    And User clicks Day icon "calendar|daysList" with text "23"
    And User selects item "option" with text "Hot Topics" from Taxonomies dropdown "publishNewsPage|taxonomiesDropdownField"
    And User scrolls page to top
    When User clicks [Submit] button "publishNewsPage|submitButton"
    Then Toast message "toast|toastMessage" is displayed
    And Toast message "toast|toastMessage" text is equal to "TEXT:Publish_news_toast_success"
    And Publish News Page Header "publishNewsPage|header" is not displayed
    And User deletes "News" with "Title" equal to "$newsTitle_1"
    And User deletes "News" with "Title" equal to "$newsTitle_2"
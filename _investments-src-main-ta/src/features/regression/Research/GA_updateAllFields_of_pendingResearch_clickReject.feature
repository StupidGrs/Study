@research
Feature: Global Admin updates all fields of Pending Research and clicks [Reject] / [Reject and open the next] button

  Background:
    # Given User restarts browser
    # And User waits for angular "false"
    Given User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    And User "COMPANY_ADMIN" publishes "Research" with all fields and title "$researchTitle" with API
    Then User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "header|settingsButton"
    And User clicks Moderate Content link "header|moderateContentLink" by executing script
    And User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
    And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
    And User waits for Table Row "contentListPage|tableRowsList" with text "$researchTitle" visibility within 3 seconds
    And User clicks Title "contentListPage|titleList" on Table Row "contentListPage|tableRowsList" with text "$researchTitle"
    And User scrolls page to top
    And User enters "_UPDATED" in Title field "moderateResearchPage|titleField"
    And User remembers value of "value" attribute of "moderateResearchPage|titleField" as "updatedResearchTitle"
    And User enters "_UPDATED" in Content Url field "moderateResearchPage|contentUrlField"
    And User enters "Url_UPDATED" in Url Label field "moderateResearchPage|urlLabelField"
    And User enters "Excerpt_UPDATED " in Excerpt field "moderateResearchPage|excerptFieldInput" by executing script
    And User enters "Content_UPDATED" in Content field "moderateResearchPage|contentFieldInput" by executing script
    And User clears text from Read Time field "moderateResearchPage|readTimeField"
    And User enters "1" in Read Time field "moderateResearchPage|readTimeField"
    And User enters "Disclaimer_UPDATED" in Disclaimer field "moderateResearchPage|disclaimerFieldInput" by executing script
    And User selects item "option" with text "Survey" from Doc Type dropdown "moderateResearchPage|articleDocTypeField"
    And User clears text from Date field "moderateResearchPage|dateFieldInput"
    And User enters "12/12/2020" in Date field "moderateResearchPage|dateFieldInput"
    # Unselect Region with text UK
    And User clicks Region "moderateResearchPage|regionsFieldOptionsList" with text "UK"
    # Select Region with text US
    And User selects Region "moderateResearchPage|regionsFieldOptionsList" with text "US"
    And User selects Target Audience "moderateResearchPage|targetAudienceCheckBoxLabelsList" with text "Asset Owner"
    And User clicks Taxonomy dropdown "moderateResearchPage|taxonomiesDropdownField"
    And User clicks Taxonomy "moderateResearchPage|taxonomiesOptionsList" with text "Strategy"
    And User enters "Taxes" in Tags field "moderateResearchPage|tagsField"
    And User clicks Tag item "moderateResearchPage|tagsAutoCompleteItem" with text "Taxes"
#    And User clicks Remove Featured Image button "moderateResearchPage|featureImageRemoveButton"
#    And User clicks Remove Attachment button "moderateResearchPage|attachmetsRemoveIconsList"

  @regression
  Scenario: Global Admin updates all fields, clicks [Reject] button and verifies that values are not changed
    And User clicks [Reject] button "moderateResearchPage|rejectButton"
    And User clicks [Reject] button on Reject Popup "moderateResearchPage|rejectPopupRejectButton"
    And User selects item "option" with text "Rejected" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User clears text from Search Content field "contentListPage|searchContentField"
    And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
    #Verify that changes made by Admin are not applied (research title is not changed), because research has been Rejected
    Then User waits for Table Row "contentListPage|tableRowsList" with text "$researchTitle" visibility within 3 seconds
    And User clicks Title "contentListPage|titleList" on Table Row "contentListPage|tableRowsList" with text "$researchTitle"
    #Verify all fields
    When User scrolls page to top
    Then Article Status "moderateResearchPage|articleStatus" with text "Status: REJECTED" is displayed
    And Attribute "value" of Title field "moderateResearchPage|titleField" is equal to "$researchTitle"
    And Attribute "value" of Content Url field "moderateResearchPage|contentUrlField" is equal to "https://www.wikipedia.org/"
    And Attribute "value" of Url Label field "moderateResearchPage|urlLabelField" is equal to ""
    And Excerpt field "moderateResearchPage|excerptField" text is equal to "Test_Auto Executive Summary"
    And Content field "moderateResearchPage|contentField" text is equal to "Test_Auto Content"
    And Attribute "value" of Read Time field "moderateResearchPage|readTimeField" is equal to "10"
    And Disclaimer field "moderateResearchPage|disclaimerField" text is equal to ""
    And Doc Type field "moderateResearchPage|articleDocTypeField" text is equal to "Speech "
    And "moderateResearchPage|dateFieldInputValue" date is equal to "Current Date" date
    And Attribute "value" of Disclaimer field "moderateResearchPage|companyAutocompleteField" is equal to "CompAuto"
    And Selected Regions list "moderateResearchPage|regionsSelectedOptionsList" count is equal to 1
    And Selected Region Option "moderateResearchPage|regionsSelectedOptionsList" text is equal to "UK"
    And Target Audience checkbox "moderateResearchPage|targetAudienceCheckBoxInputsList" on Target Audience "moderateResearchPage|targetAudienceOptionsList" with text "Asset Manager" is selected
    And Selected Taxonomies list "moderateResearchPage|taxonomiesSelectedOptionsList" count is equal to 1
    And Selected Taxonomy "moderateResearchPage|taxonomiesSelectedOptionsList" with text "Hot Topics" is displayed
    And Selected Tags list "moderateResearchPage|tagsSelectedList" count is equal to 1
    And Selected Tag "moderateResearchPage|tagsSelectedList" with text "Investing" is displayed
    And Featured image dropzone "moderateResearchPage|featuredImageDropzone" is displayed
#    And Remove Featured image button "moderateResearchPage|featureImageRemoveButton" is displayed
#    And Remove Featured image button "moderateResearchPage|featureImageRemoveButton" is enabled
#    And Attachments dropzone "moderateResearchPage|attachmentsDropzone" is not displayed
#    And Added Attachments "moderateResearchPage|attachmetsItemsList" contains "testContentForUpload.pdf" text
    And User deletes "Research" with "Title" equal to "$researchTitle"

  @regression
  Scenario: Global Admin updates all fields, clicks [Reject and open the next] button and verifies that values are not changed
    When User clicks [Reject and open the next] button "moderateResearchPage|rejectAndOpenNextButton"
    And User clicks [Reject] button on Reject Popup "moderateResearchPage|rejectPopupRejectButton"
    #Check that the next pending research is opened
    Then User waits 2 seconds
    And User scrolls page to top
    And Page Header "moderateResearchPage|pageHeader" with text "Moderate research" is displayed
    And Article Status "moderateResearchPage|articleStatus" with text "Status: PENDING" is displayed
    And Attribute "value" of Title field "moderateResearchPage|titleField" is not equal to "$researchTitle"
    When User clicks navigation menu item "header|settingsButton"
    And User clicks Moderate Content link "header|moderateContentLink" by executing script
    And User selects item "option" with text "Rejected" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User clears text from Search Content field "contentListPage|searchContentField"
    And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
    Then User waits for Table Row "contentListPage|tableRowsList" with text "$researchTitle" visibility within 3 seconds
    And User clicks Title "contentListPage|titleList" on Table Row "contentListPage|tableRowsList" with text "$researchTitle"
    #Verify all fields
    And User scrolls page to top
    And Article Status "moderateResearchPage|articleStatus" with text "Status: REJECTED" is displayed
    And Attribute "value" of Title field "moderateResearchPage|titleField" is equal to "$researchTitle"
    And Attribute "value" of Content Url field "moderateResearchPage|contentUrlField" is equal to "https://www.wikipedia.org/"
    And Attribute "value" of Url Label field "moderateResearchPage|urlLabelField" is equal to ""
    And Excerpt field "moderateResearchPage|excerptField" text is equal to "Test_Auto Executive Summary"
    And Content field "moderateResearchPage|contentField" text is equal to "Test_Auto Content"
    And Attribute "value" of Read Time field "moderateResearchPage|readTimeField" is equal to "10"
    And Disclaimer field "moderateResearchPage|disclaimerField" text is equal to ""
    And Doc Type field "moderateResearchPage|articleDocTypeField" text is equal to "Speech "
    And "moderateResearchPage|dateFieldInputValue" date is equal to "Current Date" date
    And Attribute "value" of Disclaimer field "moderateResearchPage|companyAutocompleteField" is equal to "CompAuto"
    And Selected Regions list "moderateResearchPage|regionsSelectedOptionsList" count is equal to 1
    And Selected Region Option "moderateResearchPage|regionsSelectedOptionsList" text is equal to "UK"
    And Target Audience checkbox "moderateResearchPage|targetAudienceCheckBoxInputsList" on Target Audience "moderateResearchPage|targetAudienceOptionsList" with text "Asset Manager" is selected
    And Selected Taxonomies list "moderateResearchPage|taxonomiesSelectedOptionsList" count is equal to 1
    And Selected Taxonomy "moderateResearchPage|taxonomiesSelectedOptionsList" with text "Hot Topics" is displayed
    And Selected Tags list "moderateResearchPage|tagsSelectedList" count is equal to 1
    And Selected Tag "moderateResearchPage|tagsSelectedList" with text "Investing" is displayed
    And Featured image dropzone "moderateResearchPage|featuredImageDropzone" is displayed
#    And Remove Featured image button "moderateResearchPage|featureImageRemoveButton" is displayed
#    And Remove Featured image button "moderateResearchPage|featureImageRemoveButton" is enabled
#    And Added Attachments "moderateResearchPage|attachmetsItemsList" contains "testContentForUpload.pdf" text
    And User deletes "Research" with "Title" equal to "$researchTitle"
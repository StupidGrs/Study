@research
Feature:  Global Admin updates all fields of Pending Research and clicks [Approve] / [Approve and open the next] button

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
    And User clicks Title field "moderateResearchPage|titleField"
    And User enters "_UPDATED" in Title field "moderateResearchPage|titleField"
    And User remembers value of "value" attribute of "moderateResearchPage|titleField" as "updatedResearchTitle"
    And User clears text from Content Url field "moderateResearchPage|contentUrlField"
    And User enters "https://www.wikipedia.org/_UPDATED" in Content Url field "moderateResearchPage|contentUrlField"
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
  Scenario: Global Admin updates all fields, clicks [Approve] button and verifies updated values
    And User clicks [Approve] button "moderateResearchPage|approveButton"
    When User selects item "option" with text "Approved" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User clears text from Search Content field "contentListPage|searchContentField"
    And User enters "$updatedResearchTitle" in Search Content field "contentListPage|searchContentField"
    Then User waits for Table Row "contentListPage|tableRowsList" with text "$updatedResearchTitle" visibility within 3 seconds
    And User clicks Title "contentListPage|titleList" on Table Row "contentListPage|tableRowsList" with text "$updatedResearchTitle"
    #Verify all fields
    And User scrolls page to top
    And Article Status "moderateResearchPage|articleStatus" with text "Status: APPROVED" is displayed
    And Attribute "value" of Title field "moderateResearchPage|titleField" is equal to "$updatedResearchTitle"
    And Attribute "value" of Content Url field "moderateResearchPage|contentUrlField" is equal to "https://www.wikipedia.org/_UPDATED"
    And Attribute "value" of Url Label field "moderateResearchPage|urlLabelField" is equal to "Url_UPDATED"
    And Excerpt field "moderateResearchPage|excerptField" text is equal to "Excerpt_UPDATED"
    And Content field "moderateResearchPage|contentField" text is equal to "Content_UPDATED"
    And Attribute "value" of Read Time field "moderateResearchPage|readTimeField" is equal to "1"
    And Disclaimer field "moderateResearchPage|disclaimerField" text is equal to "Disclaimer_UPDATED"
    And Doc Type field "moderateResearchPage|articleDocTypeField" text is equal to "Survey "
    And "moderateResearchPage|dateFieldInputValue" date is equal to "12/12/2020" date
    And Attribute "value" of Disclaimer field "moderateResearchPage|companyAutocompleteField" is equal to "CompAuto"
    And Selected Regions list "moderateResearchPage|regionsSelectedOptionsList" count is equal to 1
    And Selected Region "moderateResearchPage|regionsSelectedOptionsList" with text "US" is displayed
    And Target Audience checkbox "moderateResearchPage|targetAudienceCheckBoxInputsList" on Target Audience "moderateResearchPage|targetAudienceOptionsList" with text "Asset Manager" is selected
    And Target Audience checkbox "moderateResearchPage|targetAudienceCheckBoxInputsList" on Target Audience "moderateResearchPage|targetAudienceOptionsList" with text "Asset Owner" is selected
    And Selected Taxonomies list "moderateResearchPage|taxonomiesSelectedOptionsList" count is equal to 2
    And Selected Taxonomy "moderateResearchPage|taxonomiesSelectedOptionsList" with text "Hot Topics" is displayed
    And Selected Taxonomy "moderateResearchPage|taxonomiesSelectedOptionsList" with text "Strategy" is displayed
    And Selected Tags list "moderateResearchPage|tagsSelectedList" count is equal to 2
    And Selected Tag "moderateResearchPage|tagsSelectedList" with text "Investing" is displayed
    And Selected Tag "moderateResearchPage|tagsSelectedList" with text "Taxes" is displayed
    And Featured image dropzone "moderateResearchPage|featuredImageDropzone" is displayed
    And Remove Featured image button "moderateResearchPage|featuredImageUploadedDiv" is not displayed
    And Attachments dropzone "moderateResearchPage|attachmentsDropzone" is displayed
    And Added Attachments "moderateResearchPage|attachmetsItemsList" is not displayed
    And User deletes "Research" with "Title" equal to "$updatedResearchTitle"

  @regression
  Scenario: Global Admin updates all fields, clicks [Approve and open the next] button and verifies updated values
    When User clicks [Approve and open the next] button "moderateResearchPage|approveAndOpenNextButton"
    #Check that the next pending research is opened
    Then User waits 2 seconds
    And User scrolls page to top
    And Page Header "moderateResearchPage|pageHeader" with text "Moderate research" is displayed
    #Sometimes it opens already updated article, so status can differ
    #And Article Status "moderateResearchPage|articleStatus" with text "Status: PENDING" is displayed
    #And Attribute "value" of Title field "moderateResearchPage|titleField" is not equal to "$updatedResearchTitle"
    When User clicks navigation menu item "header|settingsButton"
    And User clicks Moderate Content link "header|moderateContentLink" by executing script
    And User waits for Table Row "contentListPage|tableRowsList" visibility within 5 seconds
    And User selects item "option" with text "Approved" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User enters "$updatedResearchTitle" in Search Content field "contentListPage|searchContentField"
    Then User waits for Table Row "contentListPage|tableRowsList" with text "$updatedResearchTitle" visibility within 3 seconds
    And User clicks Title "contentListPage|titleList" on Table Row "contentListPage|tableRowsList" with text "$updatedResearchTitle"
    Then User waits 2 seconds
    And User scrolls page to top
    #Verify all fields
    And Article Status "moderateResearchPage|articleStatus" with text "Status: APPROVED" is displayed
    And Attribute "value" of Title field "moderateResearchPage|titleField" is equal to "$updatedResearchTitle"
    And Attribute "value" of Content Url field "moderateResearchPage|contentUrlField" is equal to "https://www.wikipedia.org/_UPDATED"
    And Attribute "value" of Url Label field "moderateResearchPage|urlLabelField" is equal to "Url_UPDATED"
    And Excerpt field "moderateResearchPage|excerptField" text is equal to "Excerpt_UPDATED"
    And Content field "moderateResearchPage|contentField" text is equal to "Content_UPDATED"
    And Attribute "value" of Read Time field "moderateResearchPage|readTimeField" is equal to "1"
    And Disclaimer field "moderateResearchPage|disclaimerField" text is equal to "Disclaimer_UPDATED"
    And Doc Type field "moderateResearchPage|articleDocTypeField" text is equal to "Survey "
    And "moderateResearchPage|dateFieldInputValue" date is equal to "12/12/2020" date
    And Attribute "value" of Disclaimer field "moderateResearchPage|companyAutocompleteField" is equal to "CompAuto"
    And Selected Regions list "moderateResearchPage|regionsSelectedOptionsList" count is equal to 1
    And Selected Region "moderateResearchPage|regionsSelectedOptionsList" with text "US" is displayed
    And Target Audience checkbox "moderateResearchPage|targetAudienceCheckBoxInputsList" on Target Audience "moderateResearchPage|targetAudienceOptionsList" with text "Asset Manager" is selected
    And Target Audience checkbox "moderateResearchPage|targetAudienceCheckBoxInputsList" on Target Audience "moderateResearchPage|targetAudienceOptionsList" with text "Asset Owner" is selected
    And Selected Taxonomies list "moderateResearchPage|taxonomiesSelectedOptionsList" count is equal to 2
    And Selected Taxonomy "moderateResearchPage|taxonomiesSelectedOptionsList" with text "Hot Topics" is displayed
    And Selected Taxonomy "moderateResearchPage|taxonomiesSelectedOptionsList" with text "Strategy" is displayed
    And Selected Tags list "moderateResearchPage|tagsSelectedList" count is equal to 2
    And Selected Tag "moderateResearchPage|tagsSelectedList" with text "Investing" is displayed
    And Selected Tag "moderateResearchPage|tagsSelectedList" with text "Taxes" is displayed
    And Featured image dropzone "moderateResearchPage|featuredImageDropzone" is displayed
    And Remove Featured image button "moderateResearchPage|featuredImageUploadedDiv" is not displayed
    And Attachments dropzone "moderateResearchPage|attachmentsDropzone" is displayed
    And Added Attachments "moderateResearchPage|attachmetsItemsList" is not displayed
    And User deletes "Research" with "Title" equal to "$updatedResearchTitle"
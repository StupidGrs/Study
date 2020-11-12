@research
Feature: Global Admin updates all fields of Pending Research and clicks [Save] / [Save and Preview] button

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
    And User clicks in Title field "moderateResearchPage|titleField"
    And User enters "_UPDATED" in Title field "moderateResearchPage|titleField"
    And User remembers value of "value" attribute of "moderateResearchPage|titleField" as "updatedResearchTitle"
    And User clicks in Content Url field "moderateResearchPage|titleField"
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
  Scenario: Global Admin updates all fields, clicks [SAVE] button and verifies updated values
    When User clicks [SAVE] button "moderateResearchPage|saveButton"
    Then User waits for toast message "toast|toastMessage" with text "Item was successfully updated." visibility within 5 seconds
    When User clears text from Search Content field "contentListPage|searchContentField"
    Then User enters "$updatedResearchTitle" in Search Content field "contentListPage|searchContentField"
    And User waits for Table Row "contentListPage|tableRowsList" with text "$updatedResearchTitle" visibility within 3 seconds
    And User clicks Title "contentListPage|titleList" on Table Row "contentListPage|tableRowsList" with text "$updatedResearchTitle"
    #Verify all fields
    And User scrolls page to top
    And Article Status "moderateResearchPage|articleStatus" with text "Status: PENDING" is displayed
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
#    And Remove Featured image button "moderateResearchPage|featuredImageUploadedDiv" is not displayed
#    And Attachments dropzone "moderateResearchPage|attachmentsDropzone" is displayed
#    And Added Attachments "moderateResearchPage|attachmetsItemsList" is not displayed
    And User deletes "Research" with "Title" equal to "$updatedResearchTitle"

  @regression
  @knownIssue @SRC-1369
  Scenario: Global Admin updates all fields, clicks [Save and Preview] button and verifies updated values on Preview page
    When User clicks [Save and Preview] button "moderateResearchPage|saveAndPreviewButton"
    Then User waits for toast message "toast|toastMessage" with text "Item was successfully updated." visibility within 5 seconds
    And User waits for Research Title on Preview Page "researchDetailsPage|title" visibility within 3 seconds
    And User scrolls page to top
    And Research Title "researchDetailsPage|title" text is equal to "$updatedResearchTitle"
    And Research Exceprt "researchDetailsPage|excerpt" text is equal to "Excerpt_UPDATED"
    And Research Type "researchDetailsPage|researchType" text is equal to "Survey"
    And Research Header Company Logo "researchDetailsPage|headerCompanyLogoIcon" is displayed
    And Research Header Company Name "researchDetailsPage|headerCompanyName" text is equal to "CompAuto"
    And Research Header Read Time "researchDetailsPage|headerReadTime" text is equal to "1 min read"
    #TODO
    #Add method to remember selected date and calculate "ago" time to check "articleHeaderDate" exact value
    And Research Header Date "researchDetailsPage|headerDate" is displayed
    And Research Content "researchDetailsPage|content" text is equal to "Content_UPDATED"
    And Attribute "src" of Video Link "researchDetailsPage|videoIframe" is equal to "https://www.youtube.com/embed/W6NZfCO5SIk"
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
    And Disclaimer Text "researchDetailsPage|disclaimerText" text is equal to "Disclaimer_UPDATED"
    #Check video is loaded in iframe (step will fail in chrome if video is not displayed, but can pass in edge/firefox/ie)
    #And Video Error "researchDetailsPage|videoError" is not displayed in iframe "researchDetailsPage|videoIframe"
    And User deletes "Research" with "Title" equal to "$updatedResearchTitle"

@news
Feature: Verify all elements on Publish News Page

  Background:
    Given User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks [Publish] button "header|publishButton"
    And User clicks on [News / Blog] icon "modalWindow|newsIcon"

  @regression
  @publishNewsPage
  Scenario: User verifies that all Publish News page elements are displayed
    #Header
    Then Header title "publishNewsPage|headerTitle" text is equal to "Publish Your News"
#todo: to uncomment after Pendo icon is added
#    And Header Info icon "publishNewsPage|headerInfoIcon" is displayed
    And Header Divider Line "publishNewsPage|headerDividerLine" is displayed
    And Header message "publishNewsPage|headerMessage" text is equal to "TEXT:Publish_news_header_message"
    #Main Buttons
    And [Cancel] button "publishNewsPage|cancelButton" with text "Cancel" is displayed
    And [Cancel] button "publishNewsPage|cancelButton" is enabled
    And [Save Draft] button "publishNewsPage|saveDraftButton" with text "Save Draft" is displayed
    And [Save Draft] button "publishNewsPage|saveDraftButton" is disabled
    And [Save Draft] button icon "publishNewsPage|saveDraftButtonIcon" is displayed
    And [Submit] button "publishNewsPage|submitButton" with text "Submit" is displayed
    And [Submit] button "publishNewsPage|submitButton" is enabled
    And [Submit and Post New] button "publishNewsPage|submitAndAddAnotherButton" with text "Submit & Add Another" is displayed
    And [Submit and Post New] button "publishNewsPage|submitAndAddAnotherButton" is enabled
    And [Close] button "publishNewsPage|closeButton" is displayed
    And [Close] button "publishNewsPage|closeButton" is enabled
    #Title
    And Title Label "publishNewsPage|titleFieldLabel" text is equal to "Title *"
#    And Title Label "publishNewsPage|titleFieldLabel" text is equal to "Title*"
    And Title Field "publishNewsPage|titleField" is displayed
    And Title Field "publishNewsPage|titleField" is enabled
    And Attribute "value" of Title Field "publishNewsPage|titleField" is equal to ""
    And Attribute "placeholder" of Title Field "publishNewsPage|titleField" is equal to ""
    #Executive Summary
    And Executive Summary Label "publishNewsPage|executiveSummaryFieldLabel" is displayed
    And Executive Summary Label "publishNewsPage|executiveSummaryFieldLabel" text is equal to "Executive Summary *"
    And Executive Summary Field "publishNewsPage|executiveSummaryField" is displayed
    And Executive Summary Field "publishNewsPage|executiveSummaryField" is enabled
    And Attribute "value" of Executive Summary Field "publishNewsPage|executiveSummaryField" is equal to ""
    And Attribute "placeholder" of Executive Summary Field "publishNewsPage|executiveSummaryField" is equal to ""
    #Upload PDF
    And Upload PDF Label "publishNewsPage|uploadPDFFieldLabel" text is equal to "Upload Attachments"
    And Upload PDF Dropzone "publishNewsPage|uploadPDFDropzone" is displayed
    And Upload PDF Dropzone message "publishNewsPage|uploadPDFDropzoneMessage" with text "Drag and drop to upload a file" is displayed
    And Upload PDF Dropzone icon "publishNewsPage|uploadPDFDropzoneIcon" is displayed
    And Remove Attachments button "publishNewsPage|removeAttachmentsLink" is not displayed
    #Link to Content
    And Link to Content Label "publishNewsPage|linkToContentLabel" text is equal to "Link to Content *"
#    And Link to Content Label "publishNewsPage|linkToContentLabel" text is equal to "Link to Content*"
    And Link to Content Field "publishNewsPage|linkToContent" is displayed
    And Link to Content Field "publishNewsPage|linkToContent" is enabled
    And Attribute "value" of Link to Content Field "publishNewsPage|linkToContent" is equal to ""
    And Attribute "placeholder" of Link to Content Field "publishNewsPage|linkToContent" is equal to "https://"
    #Full Post Content
    And Full Post Content Label "publishNewsPage|fullPostContentFieldLabel" text is equal to "Full Post Content *"
    And Attribute "data-placeholder" of Content Editor "publishNewsPage|fullPostContentEditor" is equal to "Insert text here ..."
    #Date
    And Date Label "publishNewsPage|dateLabel" text is equal to "Date *"
    And Date Label in the Date Field "publishNewsPage|dateFieldLabel" text is equal to "Date"
    And Date Field Value "publishNewsPage|dateFieldValue" text is equal to "MM/DD/YYYY"
    And Date Picker Icon "publishNewsPage|datePickerIcon" is displayed
    #Company
    And Company Label "publishNewsPage|mercerCompaniesAutocompleteFieldLabel" text is equal to "Company *"
    And Company Field "publishNewsPage|mercerCompaniesAutocompleteField" is displayed
    And Company Field "publishNewsPage|mercerCompaniesAutocompleteField" is disabled
    And Attribute "value" of Company Field "publishNewsPage|mercerCompaniesAutocompleteField" is equal to "CompAuto"
    #Taxonomy
    And Taxonomies Label "publishNewsPage|taxonomiesDropdownFieldLabel" text is equal to "Taxonomies *"
    And Taxonomies Field "publishNewsPage|taxonomiesDropdownField" is displayed
    And Taxonomies Field "publishNewsPage|taxonomiesDropdownField" is enabled
    And Taxonomies Field "publishNewsPage|taxonomiesDropdownField" text is equal to "Select Taxonomy"
    #Tags
    And Tags Label "publishNewsPage|tagsFieldLabel" text is equal to "Tags"
    And Tags Field "publishNewsPage|tagsField" is displayed
    And Tags Field "publishNewsPage|tagsField" is enabled
    And Attribute "value" of Tags Field "publishNewsPage|tagsField" is equal to ""
    And Attribute "placeholder" of Tags Field "publishNewsPage|tagsField" is equal to "Search Tags"
    #Section Headers
    And Right Sidebar Items Headers list "publishNewsPage|rightSidebarAccordionHeadersTextsList" contains values:
      | Post Info       |
      | Taxonomy & Tags |
      | Read time       |
      | Featured Image  |
      | Video Link      |
      | Regions         |
      | Audience        |
      | Authors         |
    #Read Time
    When User clicks Right Sidebar Item "publishNewsPage|rightSidebarAccordionHeadersTextsList" with text "Read time"
    Then Number of Minutes Label "publishNewsPage|numberOfMinutesFieldLabel" text is equal to "Number of Minutes"
    And Number of Minutes Field "publishNewsPage|numberOfMinutesField" is displayed
    And Number of Minutes Field "publishNewsPage|numberOfMinutesField" is enabled
    And Attribute "value" of Number of Minutes Field "publishNewsPage|numberOfMinutesField" is equal to ""
    And Attribute "placeholder" of Number of Minutes Field "publishNewsPage|numberOfMinutesField" is equal to ""
    And [Calculate] button "publishNewsPage|calculateButton" is displayed
    And [Calculate] button "publishNewsPage|calculateButton" is enabled
    #Featured Image
    When User clicks Right Sidebar Item "publishNewsPage|rightSidebarAccordionHeadersTextsList" with text "Featured Image"
    Then Featured Image Dropzone "publishNewsPage|featuredImageDropzone" is displayed
    #Video Link
    When User clicks Right Sidebar Item "publishNewsPage|rightSidebarAccordionHeadersTextsList" with text "Video Link"
    Then Video Embed Label "publishNewsPage|videoLinkFieldLabel" text is equal to "Video Embed"
    And Video Link Field "publishNewsPage|videoLinkField" is displayed
    And Video Link Field "publishNewsPage|videoLinkField" is enabled
    And Attribute "value" of Video Link Field "publishNewsPage|videoLinkField" is equal to ""
    And Attribute "placeholder" of Video Link Field "publishNewsPage|videoLinkField" is equal to "HTML Embed Accepted"
    #Regions
    When User clicks Right Sidebar Item "publishNewsPage|rightSidebarAccordionHeadersTextsList" with text "Regions"
    #TODO:
    #Investigate why list of rigions displayed in different order every time
    # Then Regions list "publishNewsPage|regionCheckBoxLabelsList" contains values:
    #     | All Regions  |
    #     | Asia         |
    #     | Australia/NZ |
    #     | Canada       |
    #     | EMEA         |
    #     | Japan        |
    #     | UK           |
    #     | US           |
    And Checkbox "publishNewsPage|regionCheckBoxLabelsList" with text "All Regions" is displayed
    And Checkbox "publishNewsPage|regionCheckBoxLabelsList" with text "Asia" is displayed
    And Checkbox "publishNewsPage|regionCheckBoxLabelsList" with text "Australia/NZ" is displayed
    And Checkbox "publishNewsPage|regionCheckBoxLabelsList" with text "Canada" is displayed
    And Checkbox "publishNewsPage|regionCheckBoxLabelsList" with text "EMEA" is displayed
    And Checkbox "publishNewsPage|regionCheckBoxLabelsList" with text "Japan" is displayed
    And Checkbox "publishNewsPage|regionCheckBoxLabelsList" with text "UK" is displayed
    And Checkbox "publishNewsPage|regionCheckBoxLabelsList" with text "US" is displayed
    And User verifies each Regions checkbox "publishNewsPage|regionCheckBoxInputsList" item is not selected
    #Authors
    When User clicks Right Sidebar Item "publishNewsPage|rightSidebarAccordionHeadersTextsList" with text "Authors"
    Then Author/s Label "publishNewsPage|authorFieldLabel" with text "Author/s" is displayed
    And Authors Field "publishNewsPage|authorField" is displayed
    And Authors Field "publishNewsPage|authorField" is enabled
    And Attribute "value" of Authors Field "publishNewsPage|authorField" is equal to ""
    And Attribute "placeholder" of Authors Field "publishNewsPage|authorField" is equal to "Type Here..."

# todo: to uncomment after pendo icon is added
#  @regression
#  @publishNewsPage
#  Scenario: User verifies Pendo Popup on Publish News page
#    When User clicks Pendo info icon in the Header "publishNewsPage|headerInfoIcon"
#    Then Pendo popup "publishNewsPage|infoPopup" is displayed
#    And Message "publishNewsPage|infoPopupMessageText" is displayed
#    And Message "publishNewsPage|infoPopupMessageText" text is equal to "TEXT:Publish_news_info_message"
#    And Close icon "publishNewsPage|infoPopupCloseIcon" is displayed
#    And Close icon "publishNewsPage|infoPopupCloseIcon" is enabled
#    And [OK] button "publishNewsPage|infoPopupOkButton" is displayed
#    And [OK] button "publishNewsPage|infoPopupOkButton" is enabled
#    And [Here] link "publishNewsPage|infoPopupHereLink" is displayed
#    And Attribute "href" of [Here] link "publishNewsPage|infoPopupHereLink" contains ".pdf"
#    When User clicks [OK] button "publishNewsPage|infoPopupOkButton"
#    Then Info popup "publishNewsPage|infoPopup" is not displayed

  @regression
  @publishNewsPage
  Scenario: User verifies available options in Taxonomies dropdown on Publish News page
    When User clicks Taxonomies Field "publishNewsPage|taxonomiesDropdownField"
    Then Taxonomies Groups list "publishNewsPage|taxonomiesOptionsGroupsList" is displayed
    And Taxonomies Options list "publishNewsPage|taxonomiesOptionsList" is displayed
    And Option "publishNewsPage|taxonomiesOptionsList" with text "Hot Topics" is displayed
    And Option "publishNewsPage|taxonomiesOptionsList" with text "Broad Equity" is displayed
    And Option "publishNewsPage|taxonomiesOptionsList" with text "Defensive Equity" is displayed
    And Option "publishNewsPage|taxonomiesOptionsList" with text "Small Cap Equity" is displayed
    And Option "publishNewsPage|taxonomiesOptionsList" with text "Emerging Market Equity" is displayed
    And Option "publishNewsPage|taxonomiesOptionsList" with text "Growth Fixed Income" is displayed
    And Option "publishNewsPage|taxonomiesOptionsList" with text "Defensive Fixed Income" is displayed
    And Option "publishNewsPage|taxonomiesOptionsList" with text "Real Estate" is displayed
    And Option "publishNewsPage|taxonomiesOptionsList" with text "Liquid Alternatives" is displayed
    And Option "publishNewsPage|taxonomiesOptionsList" with text "Private Markets" is displayed
    And Option "publishNewsPage|taxonomiesOptionsList" with text "Listed Real Assets" is displayed
    And Option "publishNewsPage|taxonomiesOptionsList" with text "Other Alternatives" is displayed
    And Option "publishNewsPage|taxonomiesOptionsList" with text "Dynamic Asset Allocation" is displayed
    And Option "publishNewsPage|taxonomiesOptionsList" with text "Themes and Opportunities" is displayed
    And Option "publishNewsPage|taxonomiesOptionsList" with text "Research Perspectives" is displayed
    And Option "publishNewsPage|taxonomiesOptionsList" with text "Implementation" is displayed
    And Option "publishNewsPage|taxonomiesOptionsList" with text "Responsible Investment" is displayed
    And Option "publishNewsPage|taxonomiesOptionsList" with text "Strategy" is displayed
    And Option "publishNewsPage|taxonomiesOptionsList" with text "Regulatory" is displayed
@research
Feature: Verify all elements on Publish Research Page

  Background:
    Given User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks [Publish] button "header|publishButton"
    And User clicks on [Research / WhitePaper] icon "modalWindow|researchIcon"

  @regression
  @publishResearchPage
  Scenario: User verifies that all Publish Research page elements are displayed
    #Header
    Then Header title "publishResearchPage|headerTitle" text is equal to "Publish Your Research"
    #And Header Info icon "publishResearchPage|headerInfoIcon" is displayed
    And Header Divider Line "publishResearchPage|headerDividerLine" is displayed
    And Header message "publishResearchPage|headerMessage" text is equal to "TEXT:Publish_research_header_message"
    #Main Buttons
    And [Cancel] button "publishResearchPage|cancelButton" with text "Cancel" is displayed
    And [Cancel] button "publishResearchPage|cancelButton" is enabled
    And [Save Draft] button "publishResearchPage|saveDraftButton" with text "Save Draft" is displayed
    And [Save Draft] button "publishResearchPage|saveDraftButton" is disabled
    And [Save Draft] button icon "publishResearchPage|saveDraftButtonIcon" is displayed
    And [Submit] button "publishResearchPage|submitButton" with text "Submit" is displayed
    And [Submit] button "publishResearchPage|submitButton" is enabled
    And [Submit and Post New] button "publishResearchPage|submitAndAddAnotherButton" with text "Submit & Add Another" is displayed
    And [Submit and Post New] button "publishResearchPage|submitAndAddAnotherButton" is enabled
    And [Close] button "publishResearchPage|closeButton" is displayed
    And [Close] button "publishResearchPage|closeButton" is enabled
    #Title
    And Title Label "publishResearchPage|titleFieldLabel" text is equal to "Title *"
#    And Title Label "publishResearchPage|titleFieldLabel" text is equal to "Title*"
    And Title Field "publishResearchPage|titleField" is displayed
    And Title Field "publishResearchPage|titleField" is enabled
    And Attribute "value" of Title Field "publishResearchPage|titleField" is equal to ""
    And Attribute "placeholder" of Title Field "publishResearchPage|titleField" is equal to ""
    #Executive Summary
    And Executive Summary Label "publishResearchPage|executiveSummaryFieldLabel" is displayed
    And Executive Summary Label "publishResearchPage|executiveSummaryFieldLabel" text is equal to "Executive Summary *"
    And Executive Summary Field "publishResearchPage|executiveSummaryField" is displayed
    And Executive Summary Field "publishResearchPage|executiveSummaryField" is enabled
    And Attribute "value" of Executive Summary Field "publishResearchPage|executiveSummaryField" is equal to ""
    And Attribute "placeholder" of Executive Summary Field "publishResearchPage|executiveSummaryField" is equal to ""
    #Upload PDF
    And Upload PDF Label "publishResearchPage|uploadPDFFieldLabel" text is equal to "Upload Attachments"
    And Upload PDF Dropzone "publishResearchPage|uploadPDFDropzone" is displayed
    And Upload PDF Dropzone message "publishResearchPage|uploadPDFDropzoneMessage" with text "Drag and drop to upload a file" is displayed
    And Upload PDF Dropzone icon "publishResearchPage|uploadPDFDropzoneIcon" is displayed
    And Remove Attachments button "publishResearchPage|removeAttachmentsLink" is not displayed
    #Link to Content
    And Link to Content Label "publishResearchPage|linkToContentLabel" text is equal to "Link to Content *"
#    And Link to Content Label "publishResearchPage|linkToContentLabel" text is equal to "Link to Content*"
    And Link to Content Field "publishResearchPage|linkToContent" is displayed
    And Link to Content Field "publishResearchPage|linkToContent" is enabled
    And Attribute "value" of Link to Content Field "publishResearchPage|linkToContent" is equal to ""
    And Attribute "placeholder" of Link to Content Field "publishResearchPage|linkToContent" is equal to "https://"
    #Full Post Content
    And Full Post Content Label "publishResearchPage|fullPostContentFieldLabel" text is equal to "Full Post Content *"
    And Attribute "data-placeholder" of Content Editor "publishResearchPage|fullPostContentEditor" is equal to "Insert text here ..."
    #Date
    And Date Label "publishResearchPage|dateLabel" text is equal to "Date *"
    And Date Label in the Date Field "publishResearchPage|dateFieldLabel" text is equal to "Date"
    And Date Field Value "publishResearchPage|dateFieldValue" text is equal to "MM/DD/YYYY"
    And Date Picker Icon "publishResearchPage|datePickerIcon" is displayed
    #Research Type
    And Label "publishResearchPage|researchTypeDropdownFieldLabel" text is equal to "Research Type *"
    And Research Type Field "publishResearchPage|researchTypeDropdownField" is displayed
    And Research Type Field "publishResearchPage|researchTypeDropdownField" is enabled
    And Attribute "value" of Research Type Field "publishResearchPage|researchTypeDropdownField" is equal to ""
    #Company
    And Company Label "publishResearchPage|mercerCompaniesAutocompleteFieldLabel" text is equal to "Company *"
    And Company Field "publishResearchPage|mercerCompaniesAutocompleteField" is displayed
    And Company Field "publishResearchPage|mercerCompaniesAutocompleteField" is disabled
    And Attribute "value" of Company Field "publishResearchPage|mercerCompaniesAutocompleteField" is equal to "CompAuto"
    #Taxonomy
    And Taxonomies Label "publishResearchPage|taxonomiesDropdownFieldLabel" text is equal to "Taxonomies *"
    And Taxonomies Field "publishResearchPage|taxonomiesDropdownField" is displayed
    And Taxonomies Field "publishResearchPage|taxonomiesDropdownField" is enabled
    And Taxonomies Field "publishResearchPage|taxonomiesDropdownField" text is equal to "Select Taxonomy"
    #Tags
    And Tags Label "publishResearchPage|tagsFieldLabel" text is equal to "Tags"
    And Tags Field "publishResearchPage|tagsField" is displayed
    And Tags Field "publishResearchPage|tagsField" is enabled
    And Attribute "value" of Tags Field "publishResearchPage|tagsField" is equal to ""
    And Attribute "placeholder" of Tags Field "publishResearchPage|tagsField" is equal to "Search Tags"
    #Section Headers
    And Right Sidebar Items Headers list "publishResearchPage|rightSidebarAccordionHeadersTextsList" contains values:
      | Post Info       |
      | Taxonomy & Tags |
      | Read time       |
      | Featured Image  |
      | Video Link      |
      | Regions         |
      | Audience        |
      | Authors         |
    #Read Time
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Read time"
    Then Number of Minutes Label "publishResearchPage|numberOfMinutesFieldLabel" text is equal to "Number of Minutes"
    And Number of Minutes Field "publishResearchPage|numberOfMinutesField" is displayed
    And Number of Minutes Field "publishResearchPage|numberOfMinutesField" is enabled
    And Attribute "value" of Number of Minutes Field "publishResearchPage|numberOfMinutesField" is equal to ""
    And Attribute "placeholder" of Number of Minutes Field "publishResearchPage|numberOfMinutesField" is equal to ""
    And [Calculate] button "publishResearchPage|calculateButton" is displayed
    And [Calculate] button "publishResearchPage|calculateButton" is enabled
    #Featured Image
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Featured Image"
    Then Featured Image Dropzone "publishResearchPage|featuredImageDropzone" is displayed
    #Video Link
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Video Link"
    Then Video Embed Label "publishResearchPage|videoLinkFieldLabel" text is equal to "Video Embed"
    And Video Link Field "publishResearchPage|videoLinkField" is displayed
    And Video Link Field "publishResearchPage|videoLinkField" is enabled
    And Attribute "value" of Video Link Field "publishResearchPage|videoLinkField" is equal to ""
    And Attribute "placeholder" of Video Link Field "publishResearchPage|videoLinkField" is equal to "HTML Embed Accepted"
    #Regions
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Regions"
    #TODO:
    #Investigate why list of rigions displayed in different order every time
    # Then Regions list "publishResearchPage|regionCheckBoxLabelsList" contains values:
    #     | All Regions  |
    #     | Asia         |
    #     | Australia/NZ |
    #     | Canada       |
    #     | EMEA         |
    #     | Japan        |
    #     | UK           |
    #     | US           |
    And Checkbox "publishResearchPage|regionCheckBoxLabelsList" with text "All Regions" is displayed
    And Checkbox "publishResearchPage|regionCheckBoxLabelsList" with text "Asia" is displayed
    And Checkbox "publishResearchPage|regionCheckBoxLabelsList" with text "Australia/NZ" is displayed
    And Checkbox "publishResearchPage|regionCheckBoxLabelsList" with text "Canada" is displayed
    And Checkbox "publishResearchPage|regionCheckBoxLabelsList" with text "EMEA" is displayed
    And Checkbox "publishResearchPage|regionCheckBoxLabelsList" with text "Japan" is displayed
    And Checkbox "publishResearchPage|regionCheckBoxLabelsList" with text "UK" is displayed
    And Checkbox "publishResearchPage|regionCheckBoxLabelsList" with text "US" is displayed
    And User verifies each Regions checkbox "publishResearchPage|regionCheckBoxInputsList" item is not selected
    #Audience
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Audience"
    And User waits 2 seconds
    Then Audience list "publishResearchPage|targetAudienceCheckBoxLabelsList" contains values:
      | Asset Manager       |
      | Asset Owner         |
      | Mercer Consultant   |
      | External Consultant |
      | Industry Vendor     |
    And User verifies each Audience checkbox "publishResearchPage|targetAudienceCheckBoxInputsList" item is not selected
    #Authors
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Authors"
    Then Author/s Label "publishResearchPage|authorFieldLabel" with text "Author/s" is displayed
    And Authors Field "publishResearchPage|authorField" is displayed
    And Authors Field "publishResearchPage|authorField" is enabled
    And Attribute "value" of Authors Field "publishResearchPage|authorField" is equal to ""
    And Attribute "placeholder" of Authors Field "publishResearchPage|authorField" is equal to "Type Here..."

#  @regression
#  @publishResearchPage
#  Scenario: User verifies available options in Research Type dropdown on Publish Research page
#    When User clicks Research Type DropDonw Field "publishResearchPage|researchTypeDropdownField"
#    Then Research Type Options list "publishResearchPage|researchTypeOptionsList" is displayed
#    And Then Research Type Options list "publishResearchPage|researchTypeOptionsList" contains values:
#      | Select Research Type             |
#      | House View                       |
#      | Market Perspective               |
#      | Discussion Paper                 |
#      | Forum / Regional Seminar Content |
#      | Survey                           |
#      | Video / Podcast                  |
#      | Press Release                    |
#      | Speech                           |
#      | Publication                      |
#
#  @regression
#  @publishResearchPage
#  Scenario: User verifies available options in Taxonomies dropdown on Publish Research age
#    When User clicks Taxonomies Field "publishResearchPage|taxonomiesDropdownField"
#    Then Taxonomies Groups list "publishResearchPage|taxonomiesOptionsGroupsList" is displayed
#    And Taxonomies Options list "publishResearchPage|taxonomiesOptionsList" is displayed
#    And Option "publishResearchPage|taxonomiesOptionsList" with text "Hot Topics" is displayed
#    And Option "publishResearchPage|taxonomiesOptionsList" with text "Broad Equity" is displayed
#    And Option "publishResearchPage|taxonomiesOptionsList" with text "Defensive Equity" is displayed
#    And Option "publishResearchPage|taxonomiesOptionsList" with text "Small Cap Equity" is displayed
#    And Option "publishResearchPage|taxonomiesOptionsList" with text "Emerging Market Equity" is displayed
#    And Option "publishResearchPage|taxonomiesOptionsList" with text "Growth Fixed Income" is displayed
#    And Option "publishResearchPage|taxonomiesOptionsList" with text "Defensive Fixed Income" is displayed
#    And Option "publishResearchPage|taxonomiesOptionsList" with text "Real Estate" is displayed
#    And Option "publishResearchPage|taxonomiesOptionsList" with text "Liquid Alternatives" is displayed
#    And Option "publishResearchPage|taxonomiesOptionsList" with text "Private Markets" is displayed
#    And Option "publishResearchPage|taxonomiesOptionsList" with text "Listed Real Assets" is displayed
#    And Option "publishResearchPage|taxonomiesOptionsList" with text "Other Alternatives" is displayed
#    And Option "publishResearchPage|taxonomiesOptionsList" with text "Dynamic Asset Allocation" is displayed
#    And Option "publishResearchPage|taxonomiesOptionsList" with text "Themes and Opportunities" is displayed
#    And Option "publishResearchPage|taxonomiesOptionsList" with text "Research Perspectives" is displayed
#    And Option "publishResearchPage|taxonomiesOptionsList" with text "Implementation" is displayed
#    And Option "publishResearchPage|taxonomiesOptionsList" with text "Responsible Investment" is displayed
#    And Option "publishResearchPage|taxonomiesOptionsList" with text "Strategy" is displayed
#    And Option "publishResearchPage|taxonomiesOptionsList" with text "Regulatory" is displayed
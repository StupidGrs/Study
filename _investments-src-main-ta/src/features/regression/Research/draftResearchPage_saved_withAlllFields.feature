@research
Feature: Verify all elements and fields on Draft Research Page, when Research saved with all fields

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

    @regression
    @draftResearchPage
    Scenario: Verify Draft Research Page, when Research saved with all fields
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
        And [Submit and Post New] button "publishResearchPage|submitAndAddAnotherButton" is not displayed
        And [Close] button "publishResearchPage|closeButton" is displayed
        And [Close] button "publishResearchPage|closeButton" is enabled
        #Title
        And Title Label "publishResearchPage|titleFieldLabel" text is equal to "Title *"
#        And Title Label "publishResearchPage|titleFieldLabel" text is equal to "Title*"
        And Title Field "publishResearchPage|titleField" is displayed
        And Title Field "publishResearchPage|titleField" is enabled
        And Attribute "value" of Title Field "publishResearchPage|titleField" is equal to "$researchTitle"
        #Executive Summary
        And Executive Summary Label "publishResearchPage|executiveSummaryFieldLabel" is displayed
        And Executive Summary Label "publishResearchPage|executiveSummaryFieldLabel" text is equal to "Executive Summary *"
        And Executive Summary Field "publishResearchPage|executiveSummaryField" is displayed
        And Executive Summary Field "publishResearchPage|executiveSummaryField" is enabled
        And Attribute "value" of Executive Summary Field "publishResearchPage|executiveSummaryField" is equal to "Test_Auto Executive Summary"
        #Upload PDF
        And Upload PDF Label "publishResearchPage|uploadPDFFieldLabel" text is equal to "Upload Attachments"
#        And Upload PDF Dropzone "publishResearchPage|uploadPDFDropzone" is not displayed
#        And Uploaded PDF File Name "publishResearchPage|attachedPDFLabelsList" text is equal to "testContentForUpload.pdf"
#        And Remove Uploaded PDF File Icon "publishResearchPage|attachedPDFRemoveIconsList" is displayed
        #Link to Content
        And Link to Content Label "publishResearchPage|linkToContentLabel" text is equal to "Link to Content *"
#        And Link to Content Label "publishResearchPage|linkToContentLabel" text is equal to "Link to Content*"
        And Link to Content Field "publishResearchPage|linkToContent" is displayed
        And Link to Content Field "publishResearchPage|linkToContent" is enabled
        And Attribute "value" of Link to Content Field "publishResearchPage|linkToContent" is equal to "https://www.wikipedia.org/"
        #Full Post Content
        And Full Post Content Label "publishResearchPage|fullPostContentFieldLabel" text is equal to "Full Post Content *"
        And Full Post Content Field "publishResearchPage|fullPostContentField" text is equal to "Test_Auto Content"
        #Date
        And Date Label "publishResearchPage|dateLabel" text is equal to "Date *"
        And Date Label in the Date Field "publishResearchPage|dateFieldLabel" text is equal to "Date"
        And User remembers current date in format "MM/DD/YYYY" as "currentDate"
#        And Date Field Value "publishResearchPage|dateFieldValue" text is equal to "$currentDate"
        And Date Picker Icon "publishResearchPage|datePickerIcon" is displayed
        #Research Type
        And Label "publishResearchPage|researchTypeDropdownFieldLabel" text is equal to "Research Type *"
        And Research Type Field "publishResearchPage|researchTypeDropdownField" is displayed
        And Research Type Field "publishResearchPage|researchTypeDropdownField" is enabled
        And Research Type Field "publishResearchPage|researchTypeDropdownField" text is equal to "Speech"
        #Verify available options in Research Type dropdown
        When User clicks Research Type DropDonw Field "publishResearchPage|researchTypeDropdownField"
        Then Research Type Options list "publishResearchPage|researchTypeOptionsList" is displayed
#        And Then Research Type Options list "publishResearchPage|researchTypeOptionsList" contains values: // WB, needs re-write
#            | Select Research Type             |
#            | House View                       |
#            | Market Perspective              |
#            |  Discussion Paper                  |
#            | Forum / Regional Seminar Content |
#            | Survey                           |
#            | Video / Podcast                  |
#            | Press Release                    |
#            | Speech                           |
#            | Publication                      |
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
        And Selected Taxonomy "publishResearchPage|taxonomiesSelectedOptionsList" contains "Hot Topics" text
        And Remove Selected Taxonomy Icon "publishResearchPage|taxonomiesRemoveIconsList" is displayed
        #Verify available options in Taxonomies dropdown
        When User clicks Taxonomies Field "publishResearchPage|taxonomiesDropdownField"
        Then Taxonomies Groups list "publishResearchPage|taxonomiesOptionsGroupsList" is displayed
        And Taxonomies Options list "publishResearchPage|taxonomiesOptionsList" is displayed
        And Disabled Option "publishResearchPage|taxonomiesDisabledOptionsList" with text "Hot Topics" is displayed
        And Option "publishResearchPage|taxonomiesOptionsList" with text "Broad Equity" is displayed
        And Option "publishResearchPage|taxonomiesOptionsList" with text "Defensive Equity" is displayed
        And Option "publishResearchPage|taxonomiesOptionsList" with text "Small Cap Equity" is displayed
        And Option "publishResearchPage|taxonomiesOptionsList" with text "Emerging Market Equity" is displayed
        And Option "publishResearchPage|taxonomiesOptionsList" with text "Growth Fixed Income" is displayed
        And Option "publishResearchPage|taxonomiesOptionsList" with text "Defensive Fixed Income" is displayed
        And Option "publishResearchPage|taxonomiesOptionsList" with text "Real Estate" is displayed
        And Option "publishResearchPage|taxonomiesOptionsList" with text "Liquid Alternatives" is displayed
        And Option "publishResearchPage|taxonomiesOptionsList" with text "Private Markets" is displayed
        And Option "publishResearchPage|taxonomiesOptionsList" with text "Listed Real Assets" is displayed
        And Option "publishResearchPage|taxonomiesOptionsList" with text "Other Alternatives" is displayed
        And Option "publishResearchPage|taxonomiesOptionsList" with text "Dynamic Asset Allocation" is displayed
        And Option "publishResearchPage|taxonomiesOptionsList" with text "Themes and Opportunities" is displayed
        And Option "publishResearchPage|taxonomiesOptionsList" with text "Research Perspectives" is displayed
        And Option "publishResearchPage|taxonomiesOptionsList" with text "Implementation" is displayed
        And Option "publishResearchPage|taxonomiesOptionsList" with text "Responsible Investment" is displayed
        And Option "publishResearchPage|taxonomiesOptionsList" with text "Strategy" is displayed
        And Option "publishResearchPage|taxonomiesOptionsList" with text "Regulatory" is displayed
        #Tags
        And Tags Label "publishResearchPage|tagsFieldLabel" text is equal to "Tags"
        And Tags Field "publishResearchPage|tagsField" is displayed
        And Tags Field "publishResearchPage|tagsField" is enabled
        And Attribute "value" of Tags Field "publishResearchPage|tagsField" is equal to ""
        And Attribute "placeholder" of Tags Field "publishResearchPage|tagsField" is equal to "Search Tags"
        And Selected Tag "publishResearchPage|tagsSelectedList" contains "Investing" text
        And Remove Selected Tag Icon "publishResearchPage|tagsRemoveIconsList" is displayed
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
        And Attribute "value" of Number of Minutes Field "publishResearchPage|numberOfMinutesField" is equal to "10"
        And Attribute "placeholder" of Number of Minutes Field "publishResearchPage|numberOfMinutesField" is equal to ""
        And [Calculate] button "publishResearchPage|calculateButton" is displayed
        And [Calculate] button "publishResearchPage|calculateButton" is enabled
        #Featured Image
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Featured Image"
#        Then Featured Image Dropzone "publishResearchPage|featuredImageDropzone" is not displayed
#        And Uploaded Image "publishResearchPage|uploadedFeaturedImage" is displayed
#        And Remove Uploaded Image Icon "publishResearchPage|removeUploadedFeaturedImageIcon" is displayed
        #Video Link
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Video Link"
        Then Video Embed Label "publishResearchPage|videoLinkFieldLabel" text is equal to "Video Embed"
        And Video Link Field "publishResearchPage|videoLinkField" is displayed
        And Video Link Field "publishResearchPage|videoLinkField" is enabled
        And Attribute "value" of Video Link Field "publishResearchPage|videoLinkField" is equal to "https://www.youtube.com/watch?v=W6NZfCO5SIk"
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
#        And Checkbox "publishResearchPage|regionCheckBoxInputsList" on Row "publishResearchPage|regionRowsList" with text "UK" is selected // WB, needs re-write
        #Audience
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Audience"
        And User waits 2 seconds
        Then Audience list "publishResearchPage|targetAudienceCheckBoxLabelsList" contains values:
            | Asset Manager       |
            | Asset Owner         |
            | Mercer Consultant   |
            | External Consultant |
            | Industry Vendor     |
        And Checkbox "publishResearchPage|targetAudienceCheckBoxInputsList" on Row "publishResearchPage|targetAudienceRowsList" with text "Asset Manager" is selected
        #Authors
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Authors"
        Then Author/s Label "publishResearchPage|authorFieldLabel" with text "Author/s" is displayed
        And Authors Field "publishResearchPage|authorField" is displayed
        And Authors Field "publishResearchPage|authorField" is enabled
        And Attribute "value" of Authors Field "publishResearchPage|authorField" is equal to "Test_Auto Author"
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"
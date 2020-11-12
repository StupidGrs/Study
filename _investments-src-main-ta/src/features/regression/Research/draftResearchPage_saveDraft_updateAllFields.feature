@research
Feature: Company Admin updates all fields and clicks [Save draft] button on Draft Research Page

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
        And [Save draft] button "publishResearchPage|saveDraftButton" is displayed

    @regression
    @draftResearchPage
    @knownIssue @SRC-???
    Scenario: Verify Success toast when User clicks [Save draft] button on Draft Research Page
        When User enters "_UPDATED" in Executive Summary field "publishResearchPage|executiveSummaryField"
        Then [Save draft] button "publishResearchPage|saveDraftButton" is enabled
        When User clicks [Save draft] button "publishResearchPage|saveDraftButton"
        Then Toast message "toast|toastMessage" is displayed
#        And Toast message "toast|toastMessage" text is equal to "TEXT:Research_draft_saved_toast"
        And Toast message "toast|toastMessage" text is equal to "Your research was successfully updated."
        And User clicks Close Toast icon "toast|toastCloseIcon"
        And Toast message "toast|toastMessage" is not displayed
        And Publish Research Page Header "publishResearchPage|header" is not displayed
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @regression
    @draftResearchPage
    Scenario: Company Admin updates all fields and clicks [Save draft] button on Draft Research Page
        #Title
        When User enters "_UPDATED" in Title field "publishResearchPage|titleField"
        #Remember Title to delete Research
        And User remembers value of "value" attribute of "publishResearchPage|titleField" as "updatedResearchTitle"
        #Executive Summary
        And User clears text from Executive Summary field "publishResearchPage|executiveSummaryField"
        And User enters "Excerpt_UPDATED" in Executive Summary field "publishResearchPage|executiveSummaryField"
        #Uploaded PDF
#        And User clicks Remove Uploaded PDF File Icon "publishResearchPage|attachedPDFRemoveIconsList"
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
#        Egle:2020-09-10 Need to this step. If this steps is not exist then line 161 failed, because need to remove uploaded file
        And User clicks Remove Uploaded Image Icon "publishResearchPage|removeUploadedFeaturedImageIcon"
        #Video Link
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Video Link"
        And User clicks Video Link field "publishResearchPage|videoLinkField"
        And User clears text from Video Link field "publishResearchPage|videoLinkField"
        Then User enters "https://www.youtube.com/watch?v=W6NZfCO5SIk_UPDATED" in Video Link field "publishResearchPage|videoLinkField"
        #Authors
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Authors"
        And User clicks Author input field "publishResearchPage|authorField"
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
        #Click Save draft
        When User scrolls page to top
        And [Save draft] button "publishResearchPage|saveDraftButton" is enabled
        And User clicks [Save draft] button "publishResearchPage|saveDraftButton"
        #Open updated research
        When User refreshes page
        Then User waits for Research "userPostsPage|articleTitlesList" with text "$updatedResearchTitle" visibility within 10 seconds
        And Post Status "userPostsPage|articleStatusesList" with text "Draft" on Post "userPostsPage|articlesList" with text "$updatedResearchTitle" is displayed
        #Check updated values
        When User clicks Post "userPostsPage|articleTitlesList" with text "$researchTitle" using script
        Then Header title "publishResearchPage|headerTitle" text is equal to "Publish Your Research"
        #Check main buttons
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
        And Title Field "publishResearchPage|titleField" is displayed
        And Title Field "publishResearchPage|titleField" is enabled
        And Attribute "value" of Title Field "publishResearchPage|titleField" is equal to "$updatedResearchTitle"
        #Executive Summary
        And Executive Summary Field "publishResearchPage|executiveSummaryField" is displayed
        And Executive Summary Field "publishResearchPage|executiveSummaryField" is enabled
        And Attribute "value" of Executive Summary Field "publishResearchPage|executiveSummaryField" is equal to "Excerpt_UPDATED"
        #Upload PDF
        And Upload PDF Dropzone "publishResearchPage|uploadPDFDropzone" is displayed
        And Uploaded PDF File Name "publishResearchPage|attachedPDFLabelsList" is not displayed
        #Link to Content
        And Link to Content Field "publishResearchPage|linkToContent" is displayed
        And Link to Content Field "publishResearchPage|linkToContent" is enabled
        And Attribute "value" of Link to Content Field "publishResearchPage|linkToContent" is equal to "https://www.wikipedia.org/_UPDATED"
        #Full Post Content
        And Full Post Content Field "publishResearchPage|fullPostContentField" text is equal to "Content_UPDATED"
        #Date
        And Date Field Value "publishResearchPage|dateFieldValue" text is equal to "$updatedDate"
        #Research Type
        And Research Type Field "publishResearchPage|researchTypeDropdownField" is displayed
        And Research Type Field "publishResearchPage|researchTypeDropdownField" is enabled
        And Research Type Field "publishResearchPage|researchTypeDropdownField" text is equal to "Publication"
        #Company
        And Company Field "publishResearchPage|mercerCompaniesAutocompleteField" is displayed
        And Company Field "publishResearchPage|mercerCompaniesAutocompleteField" is disabled
        And Attribute "value" of Company Field "publishResearchPage|mercerCompaniesAutocompleteField" is equal to "CompAuto"
        #Taxonomy
        And Taxonomies Field "publishResearchPage|taxonomiesDropdownField" is displayed
        And Taxonomies Field "publishResearchPage|taxonomiesDropdownField" is enabled
        And Taxonomies Field "publishResearchPage|taxonomiesDropdownField" text is equal to "Select Taxonomy"
        And Selected Taxonomy "publishResearchPage|taxonomiesSelectedOptionsList" with text "Hot Topics" is displayed
        And Selected Taxonomy "publishResearchPage|taxonomiesSelectedOptionsList" with text "Strategy" is displayed
        #Tags
        And Tags Field "publishResearchPage|tagsField" is displayed
        And Tags Field "publishResearchPage|tagsField" is enabled
        And Attribute "value" of Tags Field "publishResearchPage|tagsField" is equal to ""
        And Attribute "placeholder" of Tags Field "publishResearchPage|tagsField" is equal to "Search Tags"
        And Selected Tag "publishResearchPage|tagsSelectedList" with text "Investing" is displayed
        And Selected Tag "publishResearchPage|tagsSelectedList" with text "Taxes" is displayed
        #Read Time
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Read time"
        Then Number of Minutes Field "publishResearchPage|numberOfMinutesField" is displayed
        And Number of Minutes Field "publishResearchPage|numberOfMinutesField" is enabled
        And Attribute "value" of Number of Minutes Field "publishResearchPage|numberOfMinutesField" is equal to "5"
        #Featured Image
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Featured Image"
        Then Featured Image Dropzone "publishResearchPage|featuredImageDropzone" is displayed
        And Uploaded Image "publishResearchPage|uploadedFeaturedImage" is not displayed
        #Video Link
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Video Link"
        Then Video Link Field "publishResearchPage|videoLinkField" is displayed
        And Video Link Field "publishResearchPage|videoLinkField" is enabled
        And Attribute "value" of Video Link Field "publishResearchPage|videoLinkField" is equal to "https://www.youtube.com/watch?v=W6NZfCO5SIk_UPDATED"
        #Regions
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Regions"
#        Then Checkbox "publishResearchPage|regionCheckBoxInputsList" on Row "publishResearchPage|regionRowsList" with text "UK" is selected
#        And Checkbox "publishResearchPage|regionCheckBoxInputsList" on Row "publishResearchPage|regionRowsList" with text "US" is selected
        #Audience
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Audience"
        Then Checkbox "publishResearchPage|targetAudienceCheckBoxInputsList" on Row "publishResearchPage|targetAudienceRowsList" with text "Asset Manager" is selected
        And Checkbox "publishResearchPage|targetAudienceCheckBoxInputsList" on Row "publishResearchPage|targetAudienceRowsList" with text "Mercer Consultant" is selected
        #Authors
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Authors"
        Then Authors Field "publishResearchPage|authorField" is displayed
        And Authors Field "publishResearchPage|authorField" is enabled
        And Attribute "value" of Authors Field "publishResearchPage|authorField" is equal to "Test_Auto Author Updated"
        #delete research
        And User deletes "Research" with "Title" equal to "$updatedResearchTitle"
@events
Feature: Verify all elements and fields on Draft Event Page, when Event saved with all fields

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        When User remembers text "Test_Auto_Draft_Event" with added unique Id as "eventTitle"
        And User "COMPANY_ADMIN" saves Draft Event with all fields and title "$eventTitle" and Start Date "10/20/2020" and Time "04:10 PM" and End Date "10/20/2021" and Time "05:10 PM" with API
        And User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User selects item "option" with text "event" from Select Content Type dropdown "userPostsPage|selectContentTypeDropdownOptionsList"
        Then User Event "userPostsPage|articleTitlesList" with text "$eventTitle" is displayed
        And User clicks Post "userPostsPage|articleTitlesList" with text "$eventTitle" using script

    @regression
    @draftEventPage
    @saveDraftState
    @dirtyChecking
    Scenario: Verify Draft Event Page, when Event saved with all fields
        #Header
#        Then Modal header "createEventPage|modalHeader" with text "Update an Event" is displayed
        And Modal header "createEventPage|modalHeader" with text "Publish Your" is displayed
        And Close button "createEventPage|closeIcon" is displayed
        #Company
        And Company field label "createEventPage|companyFieldLabel" with text "Company" is displayed
        And Company Field "createEventPage|companyField" is displayed
        And Company Field "createEventPage|companyField" is disabled
        And Company Field "createEventPage|companyField" input text is equal to "CompAuto"
        #Event Type
        And Event Type field Label "createEventPage|eventTypeFieldLabel" with text "Event Type" is displayed
        And Event Type field Label Span "createEventPage|eventTypeFieldLabelSpan" with text "*" is displayed
        And Event Type field "createEventPage|eventTypeField" is displayed
        And Event Type field "createEventPage|eventTypeField" is enabled
        And Event Type field "createEventPage|eventTypeField" with text "Webinar" is displayed
        #Event Name
        And Event Name field Label "createEventPage|eventNameFieldLabel" with text "Event Name" is displayed
        And Event Name field Label Span "createEventPage|eventNameFieldLabelSpan" with text "*" is displayed
        And Event Name Field "createEventPage|eventNameField" is displayed
        And Event Name Field "createEventPage|eventNameField" is enabled
        And Event Name Field "createEventPage|eventNameField" input text is equal to "$eventTitle"
        #Location
        And Location field Label "createEventPage|locationFieldLabel" with text "Location" is displayed
        And Location field Label Span "createEventPage|locationFieldLabelSpan" with text "*" is displayed
        And Location field "createEventPage|locationField" is displayed
        And Location field "createEventPage|locationField" is enabled
        And Location field "createEventPage|locationField" input text is equal to "San Francisco, United States"
        #Region
        And Region field Label "createEventPage|regionFieldLabel" with text "Region" is displayed
        And Region field "createEventPage|regionFieldDropdown" is displayed
        And Region field "createEventPage|regionFieldDropdown" is enabled
#        When User clicks Region field "createEventPage|regionFieldDropdown"
        And User clicks Region dropdown "createEventPage|regionFieldDropdown" with text "Regions"
#        Then Region options list "createEventPage|regionOptionRow" is displayed
#        And Checkbox "createEventPage|regionOptionCheckboxInput" on Region Option "createEventPage|regionOptionRow" with text "US" is selected
#        And Checkbox "createEventPage|regionOptionCheckboxInput" on Region Option "createEventPage|regionOptionCheckbox_US" with text "US" is selected
        #Start Date
        And Start date field Label "createEventPage|startDateFieldLabel" with text "Start Date" is displayed
        And Start date calendar Icon "createEventPage|datepickerStartDate" is displayed
        And Start date field "createEventPage|startDateField" is displayed
        And Start date field "createEventPage|startDateField" is enabled
        And Start date field "createEventPage|startDateField" text is equal to "10/20/2020"
        #Start Time
        #todo: add Start time icon is displayed
        And Start time field Label "createEventPage|startTimeFieldLabel" with text "Start Time" is displayed
        And Start time field Label Span "createEventPage|startTimeFieldLabelSpan" with text "*" is displayed
        And Start time field "createEventPage|startTimeField" is displayed
        And Start time field "createEventPage|startTimeField" is enabled
        And Start time field "createEventPage|startTimeField" input text is equal to "04:10 PM"
        #End Date
        And End date field Label "createEventPage|endDateFieldLabel" with text "End Date" is displayed
        And End date calendar Icon "createEventPage|datepickerEndDate" is displayed
        And End date field "createEventPage|endDateField" is displayed
        And End date field "createEventPage|endDateField" is enabled
        And End date field "createEventPage|endDateField" text is equal to "10/20/2021"
        #End Time
        #todo: End time icon is displayed
        And End time field Label "createEventPage|endTimeFieldLabel" with text "End Time" is displayed
        And End time field Label Span "createEventPage|endTimeFieldLabelSpan" with text "*" is displayed
        And End time field "createEventPage|endTimeField" is displayed
        And End time field "createEventPage|endTimeField" is enabled
        And End time field "createEventPage|endTimeField" input text is equal to "05:10 PM"
        #Url link
        And URL link field Label "createEventPage|urlLinkFieldLabel" with text "URL Link" is displayed
        And URL link field "createEventPage|urlLinkField" is displayed
        And URL link field "createEventPage|urlLinkField" is enabled
        And URL link field "createEventPage|urlLinkField" input text is equal to "https://events.climateaction.org/sustainable-investment-forum-europe/"
        #Taxonomy
        And Taxonomy field "createEventPage|taxonomyField" is displayed
        And Taxonomy field "createEventPage|taxonomyField" is enabled
        And Taxonomy field option "createEventPage|taxonomyFieldOption" with text "Select Taxonomy" is displayed
        And Taxonomy field Label "createEventPage|taxonomyFieldLabel" with text "Taxonomies" is displayed
        And Taxonomy field Label Span "createEventPage|taxonomyFieldLabelSpan" with text "*" is displayed
        And Selected Taxonomy "createEventPage|taxonomiesSelectedOptionsList" with text "Hot Topics" is displayed
        And Remove Selected Taxonomy Icon "createEventPage|taxonomiesRemoveIconsList" is displayed
        #Tag
        And Tags field "createEventPage|tagsField" is displayed
        And Tags field "createEventPage|tagsField" is enabled
        And Attribute "placeholder" of Tags field "createEventPage|tagsField" is equal to "Search Tags"
        And Tags field label "createEventPage|tagsFieldLabel" with text "Tags" is displayed
        And Tag chip "createEventPage|tagChipItem" with text "Markets & Economy" is displayed
        And Remove Tag Icon "createEventPage|tagChipItemRemoveIcon" is displayed
        #Excerpt
        And Excerpt field Label "createEventPage|excerptFieldLabel" with text "Event Excerpt" is displayed
        And Excerpt field Label Span "createEventPage|excerptFieldLabelSpan" with text "*" is displayed
        And Excerpt field "createEventPage|excerptField" is displayed
        And Excerpt field "createEventPage|excerptField" is enabled
        And Excerpt field "createEventPage|excerptField" input text is equal to "Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla."
        #Content
        #todo: add counter check
        And Content field Label "createEventPage|contentFieldLabel" with text "Event Content" is displayed
        And Content field Label span "createEventPage|contentFieldLabelSpan" with text "*" is displayed
        And Content field Toolbar "createEventPage|contentFieldToolbar" is displayed
        And Content field "createEventPage|contentField" is displayed
        And Content field "createEventPage|contentField" text is equal to "Donec quis orci eget orci vehicula condimentum. Curabitur in libero ut massa volutpat convallis."
#        #Feature Image
#        And File DropZone  "createEventPage|fileDropZone" is displayed
#        And Attachment field Label "createEventPage|attachmentFieldLabel" with text "Upload Featured Image" is displayed
#        And Attachment field message "createEventPage|attachmentFieldMessage" with text " Drag and drop to upload a file" is displayed
#        And Attachment field icon "createEventPage|attachmentFieldIcon" is displayed
#        And Uploaded Image "createEventPage|attachedImageLabel" text is equal to "featuredForEvent.png"
#        And Remove Uploaded Image Icon "createEventPage|attachedImageRemoveIcon" is displayed
        #Buttons
        And [Cancel] button "createEventPage|cancelButton" with text "Cancel" is displayed
        And [Cancel] button "createEventPage|cancelButton" is enabled
        And [Save Draft] button "createEventPage|saveDraftButton" with text "Save Draft" is displayed
        And [Save Draft] button "createEventPage|saveDraftButton" is disabled
        And [Save Draft] button icon "createEventPage|saveDraftButtonIcon" is displayed
        And [Submit] button "createEventPage|submitButton" with text "Submit" is displayed
        And [Submit] button "createEventPage|submitButton" is enabled
        And [Submit and Post New] button "createEventPage|submitAndPostNewButton" is not displayed
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"
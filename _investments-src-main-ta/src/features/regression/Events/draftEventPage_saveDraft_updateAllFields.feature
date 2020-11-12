@events
Feature: Company Admin updates all fields and clicks [Save draft] button on Draft Event Page

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        When User remembers text "Test_Auto_Draft_Event" with added unique Id as "eventTitle"
        And User "COMPANY_ADMIN" saves Draft "Event" with all fields and title "$eventTitle" with API
        And User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User selects item "option" with text "event" from Select Content Type dropdown "userPostsPage|selectContentTypeDropdownOptionsList"
        Then User Event "userPostsPage|articleTitlesList" with text "$eventTitle" is displayed
        And User clicks Post "userPostsPage|articleTitlesList" with text "$eventTitle" using script
        And [Save draft] button "createEventPage|saveDraftButton" is displayed

#    @regression
#    @draftEventPage
#    Scenario: Verify Success toast when User clicks [Save draft] button on Draft Event Page
#        When User enters "_UPDATED" in Excerpt field "createEventPage|excerptField"
#        Then [Save draft] button "createEventPage|saveDraftButton" is enabled
#        When User clicks [Save draft] button "createEventPage|saveDraftButton"
#        Then Success toast "toast|toastMessage" is displayed
#        And Success toast "toast|toastMessage" text is equal to "TEXT:Event_draft_saved_toast"
#        And User clicks Close Toast icon "toast|toastCloseIcon"
#        And Toast message "toast|toastMessage" is not displayed
#        And Update Event Page Header "createEventPage|modalHeader" is not displayed
#        #delete event
#        And User deletes "Event" with "Title" equal to "$eventTitle"

    @regression
    @draftEventPage
    @saveDraftState
    @dirtyChecking
    Scenario: Company Admin updates all fields and clicks [Save draft] button on Draft Event Page
        #Event Name
        When User enters "_UPDATED" in Event Name Field "createEventPage|eventNameField"
        #Remember Title to delete Research
        And User remembers value of "value" attribute of "createEventPage|eventNameField" as "updatedEventTitle"
        #Event Type
        And User selects item "option" with text "Networking" from Event Type dropdown "createEventPage|eventTypeField"
        And User clicks Header "createEventPage|modalHeader"
        #Location
        And User clears text from Location field "createEventPage|locationField"
        And User enters "Toronto" in Location field "createEventPage|locationField"
        And User clicks Header "createEventPage|modalHeader"
        And User clicks Location field "createEventPage|locationField"
        And User clicks item "createEventPage|locationAutocompleteItem" with text "Toronto, Canada"



        #Region
#        And User clicks Region field "createEventPage|regionFieldDropdown"
        And User clicks Region field "createEventPage|regionFieldDropdown" with text "Regions"
        And User clicks checkbox "createEventPage|regionOptionCheckboxLabel" with text "UK" by executing script
        And User clicks Region field "createEventPage|regionFieldDropdown" with text "Regions"
        #Start Date
        And User clicks Start Date Picker icon "createEventPage|datepickerStartDate"
        And User clicks Next Month icon "calendar|nextMonthButton"
        And User clicks Day icon "calendar|daysList" with text "23"
        And User remembers text of "createEventPage|startDateField" as "updatedStartDate"
        And User clicks Header "createEventPage|modalHeader"
        #Start Time
        And User clears text from Start Time field "createEventPage|startTimeField"
        And User enters "01:33 PM" in Start Time field "createEventPage|startTimeField"
        #End Date
        And User clicks End Date Picker icon "createEventPage|datepickerEndDate"
        And User clicks Next Month icon "calendar|nextMonthButton"
        And User clicks Day icon "calendar|daysList" with text "23"
        And User remembers text of "createEventPage|endDateField" as "updatedEndDate"
        And User clicks Header "createEventPage|modalHeader"
        #End Time
        And User clears text from End Time field "createEventPage|endTimeField"
        And User enters "02:33 PM" in End Time field "createEventPage|endTimeField"
        #Url link
        And User clears text from URL Link field "createEventPage|urlLinkField"
        And User enters "https://www.wikipedia.org/_UPDATED" in  URL Link field "createEventPage|urlLinkField"
        #Taxonomy
        And User selects item "option" with text "Strategy" from Taxonomies dropdown "createEventPage|taxonomyField"
        #Tag
        And User enters "Taxes" in the Tag field "createEventPage|tagsField"
        And User clicks Header "createEventPage|modalHeader"
        And User clicks Tag field "createEventPage|tagsField"
        And User waits for Tag item "createEventPage|tagsAutoCompleteItem" with text "Taxes" visibility within 5 seconds
        And User clicks Tag item "createEventPage|tagsAutoCompleteItem" with text " Taxes "
        #Excerpt
        And User clears text from Excerpt field "createEventPage|excerptField"
        And User enters "Excerpt_UPDATED" in Excerpt field "createEventPage|excerptField"
        #Content
        And User enters "Content_UPDATED" in Event Content field "createEventPage|contentField" by executing script
        #Feature Image
#        And User clicks Featured Image drop down "createEventPage|attachedImageDropdown"
#        And User clicks Featured Image drop down "createEventPage|attachedImageDropdown" with text "Featured Image"
#        And User clicks Remove Uploaded Featured Image Icon "createEventPage|attachedImageRemoveIcon"
#        And User makes upload of file "testContentForUpload.png" using Upload field "createEventPage|attachmentFieldInput"
        #Click Save draft
        When [Save draft] button "createEventPage|saveDraftButton" is enabled
        And User clicks [Save draft] button "createEventPage|saveDraftButton"
        #Open updated Event
        When User refreshes page
        And User scrolls page to top
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User selects item "option" with text "event" from Select Content Type dropdown "userPostsPage|selectContentTypeDropdownOptionsList"
        Then User waits for Event "userPostsPage|articleTitlesList" with text "$updatedEventTitle" visibility within 10 seconds
        And Post Status "userPostsPage|articleStatusesList" with text "Draft" on Post "userPostsPage|articlesList" with text "$updatedEventTitle" is displayed
        When User clicks Post "userPostsPage|articleTitlesList" with text "$updatedEventTitle" using script
#        Then Modal header "createEventPage|modalHeader" with text "Update an Event" is displayed
        And Modal header "createEventPage|modalHeader" with text "Publish Your" is displayed
        #Check updated values
        #Check main buttons
        And [Cancel] button "createEventPage|cancelButton" with text "Cancel" is displayed
        And [Cancel] button "createEventPage|cancelButton" is enabled
        And [Save Draft] button "createEventPage|saveDraftButton" with text "Save Draft" is displayed
        And [Save Draft] button "createEventPage|saveDraftButton" is disabled
        And [Save Draft] button icon "createEventPage|saveDraftButtonIcon" is displayed
        And [Submit] button "createEventPage|submitButton" with text "Submit" is displayed
        And [Submit] button "createEventPage|submitButton" is enabled
        And [Submit and Post New] button "createEventPage|submitAndPostNewButton" is not displayed
        And Close button "createEventPage|closeIcon" is displayed
        #Company
        And Company Field "createEventPage|companyField" is displayed
        And Company Field "createEventPage|companyField" is disabled
        And Company Field "createEventPage|companyField" input text is equal to "CompAuto"
        #Event Type
        And Event Type field "createEventPage|eventTypeField" is displayed
        And Event Type field "createEventPage|eventTypeField" is enabled
        And Event Type field "createEventPage|eventTypeField" with text "Networking" is displayed
        #Event Name
        And Event Name Field "createEventPage|eventNameField" is displayed
        And Event Name Field "createEventPage|eventNameField" is enabled
        And Event Name Field "createEventPage|eventNameField" input text is equal to "$updatedEventTitle"
        #Location
        And Location field "createEventPage|locationField" is displayed
        And Location field "createEventPage|locationField" is enabled
        And Location field "createEventPage|locationField" input text is equal to "Toronto, Canada"
        #Region
        And Region field "createEventPage|regionFieldDropdown" is displayed
        And Region field "createEventPage|regionFieldDropdown" is enabled
        When User clicks Region field "createEventPage|regionFieldDropdown" with text "Regions"
#        Then Region options list "createEventPage|regionOptionRow" is displayed
#        And Checkbox "createEventPage|regionOptionCheckboxInput" on Region Option "createEventPage|regionOptionRow" with text "US" is selected
#        And Checkbox "createEventPage|regionOptionCheckboxInput" on Region Option "createEventPage|regionOptionRow" with text "UK" is selected
        #Start Date
        And Start date field Label "createEventPage|startDateFieldLabel" with text "Start Date" is displayed
        And Start date field "createEventPage|startDateField" is displayed
        And Start date field "createEventPage|startDateField" is enabled
        And Start date field "createEventPage|startDateField" text is equal to "$updatedStartDate"
        #Start Time
        #todo: add Start time icon is displayed
        And Start time field "createEventPage|startTimeField" is displayed
        And Start time field "createEventPage|startTimeField" is enabled
        And Start time field "createEventPage|startTimeField" input text is equal to "01:33 PM"
        #End Date
        And End date field Label "createEventPage|endDateFieldLabel" with text "End Date" is displayed
        And End date calendar Icon "createEventPage|datepickerEndDate" is displayed
        And End date field "createEventPage|endDateField" is displayed
        And End date field "createEventPage|endDateField" is enabled
        And End date field "createEventPage|endDateField" text is equal to "$updatedEndDate"
        #End Time
        #todo: End time icon is displayed
        And End time field Label "createEventPage|endTimeFieldLabel" with text "End Time" is displayed
        And End time field Label Span "createEventPage|endTimeFieldLabelSpan" with text "*" is displayed
        And End time field "createEventPage|endTimeField" is displayed
        And End time field "createEventPage|endTimeField" is enabled
        And End time field "createEventPage|endTimeField" input text is equal to "02:33 PM"
        #Url link
        And URL link field "createEventPage|urlLinkField" is displayed
        And URL link field "createEventPage|urlLinkField" is enabled
        And URL link field "createEventPage|urlLinkField" input text is equal to "https://www.wikipedia.org/_UPDATED"
        #Taxonomy
        And Taxonomy field "createEventPage|taxonomyField" is displayed
        And Taxonomy field "createEventPage|taxonomyField" is enabled
        And Taxonomy field option "createEventPage|taxonomyFieldOption" with text "Select Taxonomy" is displayed
        And Selected Taxonomy "createEventPage|taxonomiesSelectedOptionsList" with text "Hot Topics" is displayed
        And Selected Taxonomy "createEventPage|taxonomiesSelectedOptionsList" with text "Strategy" is displayed
        #Tag
        And Tags field "createEventPage|tagsField" is displayed
        And Tags field "createEventPage|tagsField" is enabled
        And Attribute "placeholder" of Tags field "createEventPage|tagsField" is equal to "Search Tags"
        And Tag chip "createEventPage|tagChipItem" with text "Markets & Economy" is displayed
        And Tag chip "createEventPage|tagChipItem" with text "Taxes" is displayed
        #Excerpt
        And Excerpt field "createEventPage|excerptField" is displayed
        And Excerpt field "createEventPage|excerptField" is enabled
        And Excerpt field "createEventPage|excerptField" input text is equal to "Excerpt_UPDATED"
        #Content
        #todo: add counter check
        And Content field "createEventPage|contentField" is displayed
        And Content field "createEventPage|contentField" is enabled
        And Content field "createEventPage|contentField" text is equal to "Content_UPDATED"
#        #Feature Image
        And User clicks Region dropdown "createEventPage|attachedImageDropdown" with text "Featured Image"
#        And File DropZone  "createEventPage|fileDropZone" is displayed
#        And Attachment field Label "createEventPage|attachmentFieldLabel" with text "Upload Featured Image" is displayed
#        And Attachment field message "createEventPage|attachmentFieldMessage" with text " Drag and drop to upload a file" is displayed
#        And Attachment field icon "createEventPage|attachmentFieldIcon" is displayed
#        And Uploaded Image "createEventPage|attachedImageLabel" text is equal to "testContentForUpload.png"
        #delete event
        And User deletes "Event" with "Title" equal to "$updatedEventTitle"

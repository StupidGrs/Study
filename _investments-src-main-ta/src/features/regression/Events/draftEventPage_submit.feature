@events
Feature: Open Draft Event, click [Submit] button with\without changes, verify data

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        When User remembers text "Test_Auto_Draft_Event" with added unique Id as "eventTitle"
        And User "COMPANY_ADMIN" saves Draft Event with all fields and title "$eventTitle" and Start Date "05/20/2020" and Time "04:10 PM" and End Date "05/20/2021" and Time "05:10 PM" with API
        And User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User selects item "option" with text "event" from Select Content Type dropdown "userPostsPage|selectContentTypeDropdownOptionsList"
        Then User Event "userPostsPage|articleTitlesList" with text "$eventTitle" is displayed
        And User clicks Post "userPostsPage|articleTitlesList" with text "$eventTitle" using script
        And [Submit] button "createEventPage|submitButton" is displayed
        And [Submit] button "createEventPage|submitButton" is enabled

    @regression
    @draftEventPage
    Scenario: Verify Success toast when User clicks [Submit] button on Draft Event Page
        When User clicks [Submit] button "createEventPage|submitButton"
        Then Success toast "toast|toastMessage" is displayed
        And Success toast "toast|toastMessage" text is equal to "TEXT:Event_update_submitted_toast"
        And Modal header "createEventPage|modalHeader" is not displayed
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"

    @regression
    @draftEventPage
    Scenario: Verify User is able to [Submit] Draft Event without changes
        When User clicks [Submit] button "createEventPage|submitButton"
        #Open submitted event
        Then User refreshes page
        And User scrolls page to top
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User selects item "option" with text "event" from Select Content Type dropdown "userPostsPage|selectContentTypeDropdownOptionsList"
        And Post Status "userPostsPage|articleStatusesList" with text "Approval Pending" on Post "userPostsPage|articlesList" with text "$eventTitle" is displayed
        When User clicks Event "userPostsPage|articleTitlesList" with text "$eventTitle"
        #Check values
        Then Event Title "eventDetailsPage|title" is displayed
        And Event Title "eventDetailsPage|title" text is equal to "$eventTitle"
        And Excerpt "eventDetailsPage|excerpt" text is equal to "Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla."
        And Event Type "eventDetailsPage|eventTypeChip" text is equal to "Webinar"
        And Event Date in the Header details "eventDetailsPage|dateTimeHeader" contains Start Date "05/20/2020" and Time "04:10 PM" and End Date "05/20/2021" and Time "05:10 PM" in short format with GMT offset
        And Company Name in the Header "eventDetailsPage|companyNameHeader" with text "CompAuto" is displayed
        And Event Location in the Header "eventDetailsPage|locationHeader" with text "San Francisco, United States" is displayed
        And Event Content "eventDetailsPage|content" text is equal to "Donec quis orci eget orci vehicula condimentum. Curabitur in libero ut massa volutpat convallis."
        And Tag "eventDetailsPage|eventTagChip" text is equal to "Markets & Economy"
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"

    @regression
    @draftEventPage
    Scenario: Verify user is able to [Submit] Draft Event with all changed fields
        #Event Name
        When User enters "_UPDATED" in Event Name Field "createEventPage|eventNameField"
        #Remember Title to delete Research
        And User remembers value of "value" attribute of "createEventPage|eventNameField" as "updatedEventTitle"
        #Event Type
        And User selects item "option" with text "Networking" from Event Type dropdown "createEventPage|eventTypeField"
        And User clicks Header "createEventPage|modalHeader"
        #Location
        #buggy field
        And User clears text from Location field "createEventPage|locationField"
        And User enters "Toronto" in Location field "createEventPage|locationField"
        And User clicks Header "createEventPage|modalHeader"
        And User clicks Location field "createEventPage|locationField"
        And User clicks item "createEventPage|locationAutocompleteItem" with text "Toronto, Canada"
        #Region
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
#        #Feature Image
#        And User clicks Remove Uploaded Featured Image Icon "createEventPage|attachedImageRemoveIcon"
#        And User makes upload of file "testContentForUpload.png" using Upload field "createEventPage|attachmentFieldInput"
        #Click Submit draft
        And User clicks [Submit] button "createEventPage|submitButton"
        #Open updated Event
        When User refreshes page
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User selects item "option" with text "event" from Select Content Type dropdown "userPostsPage|selectContentTypeDropdownOptionsList"
        Then User waits for Event "userPostsPage|articleTitlesList" with text "$updatedEventTitle" visibility within 10 seconds
        And Post Status "userPostsPage|articleStatusesList" with text "Approval Pending" on Post "userPostsPage|articlesList" with text "$updatedEventTitle" is displayed
        When User clicks Post "userPostsPage|articleTitlesList" with text "$updatedEventTitle" using script
        #Check updated values
        #Check values
        Then Event Title "eventDetailsPage|title" is displayed
        And Event Title "eventDetailsPage|title" text is equal to "$updatedEventTitle"
        And Excerpt "eventDetailsPage|excerpt" text is equal to "Excerpt_UPDATED"
        And Event Type "eventDetailsPage|eventTypeChip" text is equal to "Networking"
        And Company Name in the Header "eventDetailsPage|companyNameHeader" with text "CompAuto" is displayed
        And Event Location in the Header "eventDetailsPage|locationHeader" with text "Toronto, Canada" is displayed
        And Event Content "eventDetailsPage|content" text is equal to "Content_UPDATED"
        And Tag "eventDetailsPage|eventTagChip" with text "Markets & Economy" is displayed
        And Tag "eventDetailsPage|eventTagChip" with text "Taxes" is displayed
        And Event Date in the Header details "eventDetailsPage|dateTimeHeader" contains Start Date "$updatedStartDate" and Time "01:33 PM" and End Date "$updatedEndDate" and Time "02:33 PM" in short format with GMT offset
        #delete event
        And User deletes "Event" with "Title" equal to "$updatedEventTitle"
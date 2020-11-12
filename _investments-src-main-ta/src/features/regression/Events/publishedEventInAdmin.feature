@events
Feature: Verify all fields of published Event in Admin

  Background:
    Given User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks [Publish] button "header|publishButton"
    When User clicks [Event] button "modalWindow|eventIcon"
    And User selects item "option" with text "Webinar" from Event Types "createEventPage|eventTypeField"
    And User clicks Event Type Label "createEventPage|eventTypeFieldLabel"
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    And User enters "$eventTitle" in Event Name field "createEventPage|eventNameField"
    And User enters "San Francisco, United" in Location field "createEventPage|locationField"
    And User clicks item "createEventPage|locationAutocompleteItem" with text "San Francisco, United States"
    And User clicks Region dropdown "createEventPage|regionFieldDropdown" with text "Regions"
    And User clicks Region "createEventPage|regionOptionCheckboxLabel" with text "US" by executing script
    And User clicks Region dropdown "createEventPage|regionFieldDropdown" with text "Regions"
    And User clicks Calendar "createEventPage|datepickerStartDate"
    And User clicks Next month button "calendar|nextMonthButton"
    And User clicks Day in calendar "calendar|daysList" with text "23"
    And User clicks Header "createEventPage|modalHeader"
    And User remembers text of "createEventPage|startDateField" as "startDate"
    And User enters "9:30 AM" in Start Time field "createEventPage|startTimeField"
    And User clicks Calendar "createEventPage|datepickerEndDate"
    And User clicks Next month button "calendar|nextMonthButton"
    And User clicks Day in calendar "calendar|daysList" with text "23"
    And User clicks Header "createEventPage|modalHeader"
    And User remembers text of "createEventPage|endDateField" as "endDate"
    And User enters "5:00 PM" in End Time field "createEventPage|endTimeField"
    And User enters "https://events.climateaction.org/sustainable-investment-forum-europe/" in URL link field "createEventPage|urlLinkField"
    And User clicks item "createEventPage|taxonomyFieldOption" with text "Hot Topics"
    And User enters "markets & economy" in Tags field "createEventPage|tagsField"
    And User clicks item "createEventPage|tagsAutoCompleteItem" with text "Markets & Economy"
    And User enters "TEXT:Event_Excerpt" in Excerpt field "createEventPage|excerptField"
    And User enters "TEXT:Event_Content" in Content field "createEventPage|contentField" by executing script
    And User makes upload of file "featuredForEvent.png" using Upload field "createEventPage|attachmentFieldInput"
    When User clicks button "createEventPage|submitButton" with text "Submit"
    And Success toast "toast|toastMessage" is displayed
    And Success toast "toast|toastMessage" text is equal to "TEXT:Event_submitted_toast"
    Then Modal header "createEventPage|modalHeader" with text "Create an Event" is not displayed
    And User clicks Profile button "header|profileButton"
    And User clicks Profile Menu Item "header|profileMenuItemsList" with text "Logout"

  @smoke
  @regression
  Scenario: Verify all fields of published Event in Admin
    #Login as Global Admin and open submitted event in Moderate Contant
    When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "header|settingsButton"
    And User clicks Moderate Content link "header|moderateContentLink" by executing script
    And User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User selects item "option" with text "event" from Article Type dropdown "contentListPage|articleTypeDropdown"
    And User enters "$eventTitle" in Search Content field "contentListPage|searchContentField"
    And User waits for Table Row "contentListPage|tableRowsList" with text "$eventTitle" visibility within 3 seconds
    And User clicks Title "contentListPage|titleList" on Table Row "contentListPage|tableRowsList" with text "$eventTitle"
    #Verify all fields
    And User scrolls page to top
    And Attribute "value" of Title field "moderateEventPage|titleField" is equal to "$eventTitle"
    And Attribute "value" of Content Url field "moderateEventPage|contentUrlField" is equal to "https://events.climateaction.org/sustainable-investment-forum-europe/"
    And Attribute "value" of Url Label field "moderateEventPage|urlLabelField" is equal to ""
    And Excerpt field "moderateEventPage|excerptField" text is equal to "TEXT:Event_Excerpt"
    And Content field "moderateEventPage|contentField" text is equal to "TEXT:Event_Content"
    And Attribute "value" of Event Location field "moderateEventPage|eventLocationAutocompleteField" is equal to "San Francisco, United States"
    And Attribute "value" of Company field "moderateEventPage|companyAutocompleteField" is equal to "CompAuto"
    And Selected Region Option "moderateEventPage|regionsSelectedOptionsList" with text "US" is displayed
    And Event Type field "moderateEventPage|eventTypeDropdownField" input contains "Webinar" text
    #    lin: fixed at 31/Aug/2020
    #    And Attribute "value" of Start Date field "moderateEventPage|eventStartDateInput" is equal to "$startDate"
    And Start Date field "moderateEventPage|eventStartDateInput" contains "$startDate" text
    And Attribute "value" of Start Time field "moderateEventPage|eventStartTimeInput" is equal to "9:30 AM"
    #    And Attribute "value" of End Date field "moderateEventPage|eventEndDateInput" is equal to "$endDate"
    And Start Date field "moderateEventPage|eventEndDateInput" contains "$endDate" text
    And Attribute "value" of End Time field "moderateEventPage|eventEndTimeInput" is equal to "5:00 PM"
    And User verifies each Target Audience checkbox "moderateEventPage|targetAudienceCheckBoxInputsList" is not selected
    And Taxonomy "moderateEventPage|taxonomiesSelectedOptionsList" with text "Hot Topics" is displayed
    And Tag "moderateEventPage|tagsSelectedList" with text "Markets & Economy" is displayed
    And Featured image dropzone "moderateEventPage|featuredImageDropzone" is displayed
#    And Uploaded Featured image "moderateEventPage|eventFeaturedImageUploaded" is displayed
#    And Remove Featured image button "moderateEventPage|eventRemoveFeaturedImageButton" is displayed
#    And Remove Featured image button "moderateEventPage|eventRemoveFeaturedImageButton" is enabled
    And User deletes "Event" with "Title" equal to "$eventTitle"
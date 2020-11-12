@events
Feature: Company Admin creates Event with [Submit and Post New] button

  Background:
    Given User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks [Publish] button "header|publishButton"
    When User clicks Event button "modalWindow|eventIcon"

  @regression
  @createEventPage
  Scenario: Company Admin populates all fields and clicks Submit and Post New
    Then Attribute "value" of Company Field "createEventPage|companyField" is equal to "CompAuto"
    #1st Event submit
#    And Modal header "createEventPage|modalHeader" with text "Create an Event" is displayed
    And Modal header "createEventPage|modalHeader" with text "Publish Your" is displayed
    And User selects item "option" with text "Networking" from Event Types "createEventPage|eventTypeField"
    And User clicks Event Types "createEventPage|eventTypeField"
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle_3"
    And User enters "$eventTitle_3" in Event Name field "createEventPage|eventNameField"
    And User enters "Edinburgh" in Location field "createEventPage|locationField"
    And User clicks item "createEventPage|locationAutocompleteItem" with text "Edinburgh, United Kingdom"
    And User clicks Region dropdown "createEventPage|regionFieldDropdown" with text "Regions"
    And User clicks Region "createEventPage|regionOptionCheckboxLabel" with text "UK" by executing script
#    And User clicks Region UK Types "createEventPage|regionOptionCheckboxLabel_UK" by executing script
    And User clicks Region dropdown "createEventPage|regionFieldDropdown" with text "Regions"
    And User clicks Calendar "createEventPage|datepickerStartDate"
    And User clicks Next month button "calendar|nextMonthButton"
    And User clicks Day in calendar "calendar|daysList" with text "23"
    And User clicks Company Label "createEventPage|companyFieldLabel"
    And User enters "9:00 AM" in Start Time field "createEventPage|startTimeField"
    And User clicks Calendar "createEventPage|datepickerEndDate"
    And User clicks Next month button "calendar|nextMonthButton"
    And User clicks Day in calendar "calendar|daysList" with text "23"
    And User clicks Company Label "createEventPage|companyFieldLabel"
    And User enters "5:00 PM" in End Time field "createEventPage|endTimeField"
    And User enters "https://events.climateaction.org/sustainable-investment-forum-europe/" in URL link field "createEventPage|urlLinkField"
    And User clicks item "createEventPage|taxonomyFieldOption" with text "Hot Topics"
    And User enters "drivers" in Tags field "createEventPage|tagsField"
    And User clicks item "createEventPage|tagsAutoCompleteItem" with text "Drivers Of Value"
    And User enters "TEXT:Event_Excerpt" in Excerpt field "createEventPage|excerptField"
    And User enters "TEXT:Event_Content" in Content field "createEventPage|contentField" by executing script
    And User makes upload of file "featuredForEvent.png" using Upload field "createEventPage|attachmentFieldInput"
#    And User clicks button "createEventPage|modalFooterButtons" with text "Submit and Post New"
    And User clicks button "createEventPage|SubmitAndAddAnother" with text "Submit & Add Another"
    And Success toast "toast|toastMessage" is displayed
    And Success toast "toast|toastMessage" text is equal to "TEXT:Event_submitted_toast"
    And User clicks Close Toast icon "toast|toastCloseIcon"
#    And Modal header "createEventPage|modalHeader" with text "Create an Event" is displayed
    And Modal header "createEventPage|modalHeader" with text "Publish Your" is displayed
    #2nd Event Submit
    And User selects item "option" with text "Round table" from Event Types "createEventPage|eventTypeField"
    And User clicks Event Types "createEventPage|eventTypeField"
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle_4"
    And User enters "$eventTitle_4" in Event Name field "createEventPage|eventNameField"
    And User enters "Sydney" in Location field "createEventPage|locationField"
    And User clicks item "createEventPage|locationAutocompleteItem" with text "Sydney, Australia"
    And User clicks Region dropdown "createEventPage|regionFieldDropdown" with text "Regions"
    And User clicks Region "createEventPage|regionOptionCheckboxLabel" with text "Australia/NZ" by executing script
    And User clicks Region dropdown "createEventPage|regionFieldDropdown" with text "Regions"
    And User clicks Calendar "createEventPage|datepickerStartDate"
    And User clicks Next month button "calendar|nextMonthButton"
    And User clicks Day in calendar "calendar|daysList" with text "23"
    And User clicks Company Label "createEventPage|companyFieldLabel"
    And User enters "9:00 AM" in Start Time field "createEventPage|startTimeField"
    And User clicks Calendar "createEventPage|datepickerEndDate"
    And User clicks Next month button "calendar|nextMonthButton"
    And User clicks Day in calendar "calendar|daysList" with text "23"
    And User clicks Company Label "createEventPage|companyFieldLabel"
    And User enters "5:00 PM" in End Time field "createEventPage|endTimeField"
    And User enters "https://events.climateaction.org/sustainable-investment-forum-europe/" in URL link field "createEventPage|urlLinkField"
    And User clicks item "createEventPage|taxonomyFieldOption" with text "Hot Topics"
    And User enters "investment" in Tags field "createEventPage|tagsField"
    And User clicks item "createEventPage|tagsAutoCompleteItem" with text "Investment Industry"
    And User enters "TEXT:Event_Excerpt" in Excerpt field "createEventPage|excerptField"
    And User enters "TEXT:Event_Content" in Content field "createEventPage|contentField" by executing script
    And User makes upload of file "featuredForEvent.png" using Upload field "createEventPage|attachmentFieldInput"
#    And User clicks button "createEventPage|modalFooterButtons" with text "Submit"
    And User clicks button "createEventPage|Submit" with text "Submit"
    And Success toast "toast|toastMessage" is displayed
    And Success toast "toast|toastMessage" text is equal to "TEXT:Event_submitted_toast"
#    And Modal header "createEventPage|modalHeader" with text "Create an Event" is not displayed
    And Modal header "createEventPage|modalHeader" with text "Publish Your" is not displayed
    #postcondition: to remove test events from db
#    And User deletes "Events" with "Title" equal to "$eventTitle_3"
#    And User deletes "Events" with "Title" equal to "$eventTitle_4"

  @regression
  @createEventPage
  Scenario: Company Admin populates mandatory fields only and clicks Submit and Post New
    Then Attribute "value" of Company Field "createEventPage|companyField" is equal to "CompAuto"
    #1st Event
    And User selects item "option" with text "Road show" from Event Types "createEventPage|eventTypeField"
    And User clicks Event Types "createEventPage|eventTypeField"
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle_1"
    And User enters "$eventTitle_1" in Event Name field "createEventPage|eventNameField"
    And User enters "Hong Kong" in Location field "createEventPage|locationField"
    # And User clicks Company Label "createEventPage|companyFieldLabel"
    # And User clicks Location field "createEventPage|locationField"
    And User clicks item "createEventPage|locationAutocompleteItem" with text "Hong Kong, Hong Kong S.A.R."
    And User clicks Calendar "createEventPage|datepickerStartDate"
    And User clicks Next month button "calendar|nextMonthButton"
    And User clicks Day in calendar "calendar|daysList" with text "23"
    And User clicks Company Label "createEventPage|companyFieldLabel"
    And User enters "9:00 AM" in Start Time field "createEventPage|startTimeField"
    And User clicks Calendar "createEventPage|datepickerEndDate"
    And User clicks Next month button "calendar|nextMonthButton"
    And User clicks Day in calendar "calendar|daysList" with text "23"
    And User clicks Company Label "createEventPage|companyFieldLabel"
    And User enters "5:00 PM" in End Time field "createEventPage|endTimeField"
    And User clicks item "createEventPage|taxonomyFieldOption" with text "Hot Topics"
    And User enters "TEXT:Event_Excerpt" in Excerpt field "createEventPage|excerptField"
    And User enters "TEXT:Event_Content" in Content field "createEventPage|contentField" by executing script
    #And User clicks button "createEventPage|modalFooterButtons" with text "Submit and Post New"
    And User clicks button "createEventPage|SubmitAndAddAnother" with text "Submit & Add Another"
    And Success toast "toast|toastMessage" is displayed
    And Success toast "toast|toastMessage" text is equal to "TEXT:Event_submitted_toast"
    And User clicks Close Toast icon "toast|toastCloseIcon"
    #And Modal header "createEventPage|modalHeader" with text "Create an Event" is displayed
    And Modal header "createEventPage|modalHeader" with text "Publish Your" is displayed
    #2nd Event
    And User selects item "option" with text "Training" from Event Types "createEventPage|eventTypeField"
    And User clicks Event Types "createEventPage|eventTypeField"
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle_2"
    And User enters "$eventTitle_2" in Event Name field "createEventPage|eventNameField"
    And User enters "Zurich," in Location field "createEventPage|locationField"
    And User clicks item "createEventPage|locationAutocompleteItem" with text "Zürich, Switzerland"
    And User clicks Calendar "createEventPage|datepickerStartDate"
    And User clicks Next month button "calendar|nextMonthButton"
    And User clicks Day in calendar "calendar|daysList" with text "23"
    And User clicks Company Label "createEventPage|companyFieldLabel"
    And User enters "9:00 AM" in Start Time field "createEventPage|startTimeField"
    And User clicks Calendar "createEventPage|datepickerEndDate"
    And User clicks Next month button "calendar|nextMonthButton"
    And User clicks Day in calendar "calendar|daysList" with text "23"
    And User clicks Company Label "createEventPage|companyFieldLabel"
    And User enters "5:00 PM" in End Time field "createEventPage|endTimeField"
    And User clicks item "createEventPage|taxonomyFieldOption" with text "Hot Topics"
    And User enters "TEXT:Event_Excerpt" in Excerpt field "createEventPage|excerptField"
    And User enters "TEXT:Event_Content" in Content field "createEventPage|contentField" by executing script
    And User clicks button "createEventPage|Submit" with text "Submit"
    And Success toast "toast|toastMessage" is displayed
    And Success toast "toast|toastMessage" text is equal to "TEXT:Event_submitted_toast"
#    And Modal header "createEventPage|modalHeader" with text "Create an Event" is not displayed
    And Modal header "createEventPage|modalHeader" with text "Publish Your" is not displayed
    #postcondition: to remove test events from db
    #And User deletes "Events" with "Title" equal to "$eventTitle_1"
    #And User deletes "Events" with "Title" equal to "$eventTitle_2"
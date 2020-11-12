@events
Feature: [Global Admin] Verify Save Draft functionality on Create Event page

  Background:
    Given User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks [Publish] button "header|publishButton"
    When User clicks Event button "modalWindow|eventIcon"

  @regression
  @createEventPage
  Scenario: Global Admin populates all fields and clicks Save Draft button
#    Then Modal header "createEventPage|modalHeader" with text "Create an Event" is displayed
    And Modal header "createEventPage|modalHeader" with text "Publish Your" is displayed
    And Attribute "value" of Company Field "createEventPage|companyField" is equal to "CompAuto"
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
    And User enters "9:30 AM" in Start Time field "createEventPage|startTimeField"
    And User clicks Calendar "createEventPage|datepickerEndDate"
    And User clicks Next month button "calendar|nextMonthButton"
    And User clicks Day in calendar "calendar|daysList" with text "23"
    And User clicks Header "createEventPage|modalHeader"
    And User enters "5:00 PM" in End Time field "createEventPage|endTimeField"
    And User enters "https://events.climateaction.org/sustainable-investment-forum-europe/" in URL link field "createEventPage|urlLinkField"
    And User clicks item "createEventPage|taxonomyFieldOption" with text "Hot Topics"
    And User enters "markets & economy" in Tags field "createEventPage|tagsField"
    And User clicks item "createEventPage|tagsAutoCompleteItem" with text "Markets & Economy"
    And User enters "TEXT:Event_Excerpt" in Excerpt field "createEventPage|excerptField"
    And User enters "TEXT:Event_Content" in Content field "createEventPage|contentField" by executing script
    And User makes upload of file "featuredForEvent.png" using Upload field "createEventPage|attachmentFieldInput"
    When User clicks button "createEventPage|saveDraftButton" with text "Save Draft"
    Then Success toast "toast|toastMessage" is displayed
    And Success toast "toast|toastMessage" text is equal to "TEXT:Event_draft_saved_toast"
#    And Modal header "createEventPage|modalHeader" with text "Create an Event" is not displayed
    And Modal header "createEventPage|modalHeader" with text "Publish Your" is not displayed
#    #postcondition
#    And User deletes "Events" with "Title" equal to "$eventTitle"

  @regression
  @createEventPage
  Scenario: Global Admin populates mandatory fields only and clicks Save Draft button
#    Then Modal header "createEventPage|modalHeader" with text "Create an Event" is displayed
    And Modal header "createEventPage|modalHeader" with text "Publish Your" is displayed
    And Attribute "value" of Company Field "createEventPage|companyField" is equal to "CompAuto"
    And User selects item "option" with text "Conference" from Event Types "createEventPage|eventTypeField"
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    And User enters "$eventTitle" in Event Name field "createEventPage|eventNameField"
    And User enters "Toronto" in Location field "createEventPage|locationField"
    And User clicks item "createEventPage|locationAutocompleteItem" with text "Toronto, Canada"
    And User clicks Calendar "createEventPage|datepickerStartDate"
    And User clicks Next month button "calendar|nextMonthButton"
    And User clicks Day in calendar "calendar|daysList" with text "23"
    And User clicks Header "createEventPage|modalHeader"
    And User enters "9:00 AM" in Start Time field "createEventPage|startTimeField"
    And User clicks Calendar "createEventPage|datepickerEndDate"
    And User clicks Next month button "calendar|nextMonthButton"
    And User clicks Day in calendar "calendar|daysList" with text "23"
    And User clicks Header "createEventPage|modalHeader"
    And User enters "5:00 PM" in End Time field "createEventPage|endTimeField"
    And User clicks item "createEventPage|taxonomyFieldOption" with text "Hot Topics"
    And User enters "TEXT:Event_Excerpt" in Excerpt field "createEventPage|excerptField"
    And User enters "TEXT:Event_Content" in Content field "createEventPage|contentField" by executing script
    When User clicks button "createEventPage|saveDraftButton" with text "Save Draft"
    Then Success toast "toast|toastMessage" is displayed
    And Success toast "toast|toastMessage" text is equal to "TEXT:Event_draft_saved_toast"
#    And Modal header "createEventPage|modalHeader" with text "Create an Event" is not displayed
    And Modal header "createEventPage|modalHeader" with text "Publish Your" is not displayed
#    #postcondition
#    And User deletes "Events" with "Title" equal to "$eventTitle"
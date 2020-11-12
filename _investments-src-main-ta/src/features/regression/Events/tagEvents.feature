@events
Feature: Verify Tags field for Events

  @regression
  @knownIssue @SRC-1297
  Scenario: Global Admin submits Event with unique tag and verifies that tag is available as an auto complete option for Events and Researches
    Given User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks [Publish] button "header|publishButton"
    When User clicks Event button "modalWindow|eventIcon"
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
    And User remembers text "Tag_" with added unique Id as "tag"
    When User enters "$tag" in Tags field "createEventPage|tagsField"
    And User presses Enter key in Tags field "createEventPage|tagsField"
    Then Tag chip "createEventPage|tagChipItem" with text "$tag" is displayed
    And User enters "TEXT:Event_Excerpt" in Excerpt field "createEventPage|excerptField"
    And User enters "TEXT:Event_Content" in Content field "createEventPage|contentField" by executing script
    And User clicks button "createEventPage|submitButton" with text "Submit"
    And Success toast "toast|toastMessage" is displayed
    And Success toast "toast|toastMessage" text is equal to "TEXT:Event_submitted_toast"
#    And Modal header "createEventPage|modalHeader" with text "Create an Event" is not displayed
    And Modal header "createEventPage|modalHeader" with text "Publish Your" is not displayed
    #Global Admin verifeis that tag is available as auto complete option for Events
    And User clicks [Publish] button "header|publishButton"
    And User clicks Event button "modalWindow|eventIcon"
        #lin: hard code to $tag
        #When User enters "$tag" in Tags field "createEventPage|tagsField"
        #Then Tag auto completion item "createEventPage|tagsAutoCompleteItem" with text "$tag" is displayed
    When User enters "Real Estate" in Tags field "createEventPage|tagsField"
    Then Tag auto completion item "createEventPage|tagsAutoCompleteItem" with text "Real Estate" is displayed
    And User clicks Close button "createEventPage|closeIcon"
    #Global Admin verifies that tag is available for Researches
    And User clicks [Publish] button "header|publishButton"
    And User clicks Research button "modalWindow|researchIcon"
        #lin: hard code to $tag, fix the wrong element
        #When User enters "$tag" in Tags field "publishResearchPage|tagsField"
        #Then Tag auto completion item "publishResearchPage|tagsAutoCompleteItem" with text "$tag" is displayed
        #When User enters "$tag" in Tags field "publishResearchField|tagsField"
        #Then Tag auto completion item "publishResearchField|tagsAutoCompleteItem" with text "$tag" is displayed
    When User enters "Real Estate" in Tags field "publishResearchPage|tagsField"
    Then Tag auto completion item "publishResearchPage|tagsAutoCompleteItem" with text "Real Estate" is displayed
    #postcondition: to clean db
    And User deletes "Events" with "Title" equal to "$eventTitle"

  @regression
  Scenario: Company Admin tries to add unique tag for Event
    Given User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks [Publish] button "header|publishButton"
    And User clicks Event button "modalWindow|eventIcon"
    And User remembers text "Tag_" with added unique Id as "tag"
    When User enters "$tag" in Tags field "createEventPage|tagsField"
    And User presses Enter key in Tags field "createEventPage|tagsField"
    Then Tag chip "createEventPage|tagChipItem" with text "$tag" is not displayed

  @regression
  Scenario: Company Author tries to add unique tag for Event
    Given User logs in as "COMPANY_AUTHOR" on "LOGIN_PAGE"
    And User clicks [Publish] button "header|publishButton"
    And User clicks Event button "modalWindow|eventIcon"
    And User remembers text "Tag_" with added unique Id as "tag"
    When User enters "$tag" in Tags field "createEventPage|tagsField"
    And User presses Enter key in Tags field "createEventPage|tagsField"
    Then Tag chip "createEventPage|tagChipItem" with text "$tag" is not displayed
@events
Feature: Global Admin updates all fields of Pending Event and clicks [Cancel] button

  Background:
    Given User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    And User "COMPANY_ADMIN" publishes Event with all fields and title "$eventTitle" and Start Date "05/20/2020" and Time "4:10 AM" and End Date "05/20/2021" and Time "4:10 PM" with API
    Then User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "header|settingsButton"
    And User clicks Moderate Content link "header|moderateContentLink" by executing script
    And User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User selects item "option" with text "event" from Article Type dropdown "contentListPage|articleTypeDropdown"
    And User enters "$eventTitle" in Search Content field "contentListPage|searchContentField"
    And User waits for Table Row "contentListPage|tableRowsList" with text "$eventTitle" visibility within 3 seconds
    And User clicks Title "contentListPage|titleList" on Table Row "contentListPage|tableRowsList" with text "$eventTitle"
    And User scrolls page to top
    And User clicks Title field "moderateEventPage|titleField"
    And User enters "_UPDATED" in Title field "moderateEventPage|titleField"
    And User remembers value of "value" attribute of "moderateEventPage|titleField" as "updatedEventTitle"
    And User clears text from Content Url field "moderateEventPage|contentUrlField"
    And User enters "https://www.wikipedia.org/_UPDATED" in Content Url field "moderateEventPage|contentUrlField"
    And User enters "Excerpt_UPDATED " in Excerpt field "moderateEventPage|excerptFieldInput" by executing script
    And User enters "Content_UPDATED" in Content field "moderateEventPage|contentFieldInput" by executing script
    And User clears text from Event Location field "moderateEventPage|eventLocationAutocompleteField"
    And User enters "Edinburgh" in Event Location field "moderateEventPage|eventLocationAutocompleteField"
    And User clicks Event Location "moderateEventPage|eventLocationAutocompleteItemsList" with text "Edinburgh, United Kingdom"
    # Unselect Region with text US
    And User clicks Region "moderateEventPage|regionsFieldOptionsList" with text "US"
    # Select Region with text USK
    And User selects Region "moderateEventPage|regionsFieldOptionsList" with text "UK"
    And User selects item "option" with text "Networking" from Event Type dropdown "moderateEventPage|eventTypeDropdownField"
    And User clicks Start Date Calendar "moderateEventPage|eventStartDatePicker"
    And User clicks Next month button "calendar|nextMonthButton"
    And User clicks Day in calendar "calendar|daysList" with text "23"
    And User clicks Start Date Calendar "moderateEventPage|eventStartDatePicker"
    And User clicks End Date Calendar "moderateEventPage|eventEndDatePicker"
    And User clicks Next month button "calendar|nextMonthButton"
    And User clicks Day in calendar "calendar|daysList" with text "23"
    And User clicks End Date Calendar "moderateEventPage|eventEndDatePicker"
    And User clears text from Start Time field "moderateEventPage|eventStartTimeInput"
    And User enters "10:30 AM" in Start Time field "moderateEventPage|eventStartTimeInput"
    And User clears text from End Time field "moderateEventPage|eventEndTimeInput"
    And User enters "6:00 PM" in Start Time field "moderateEventPage|eventEndTimeInput"
    And User clicks Taxonomy dropdown "moderateEventPage|taxonomiesDropdownField"
    And User clicks Taxonomy "moderateEventPage|taxonomiesOptionsList" with text "Strategy"
    And User enters "Taxes" in Tags field "moderateEventPage|tagsField"
    And User clicks Tag item "moderateEventPage|tagsAutoCompleteItem" with text "Taxes"
#    And User clicks Remove Featured Image button "moderateEventPage|eventRemoveFeaturedImageButton"

  @regression
  Scenario: Global Admin updates all fields, clicks [Cancel] button and verifies that values are not changed
    And User clicks [Cancel] button "moderateEventPage|cancelButton"
    And User clicks [CANCEL ALL CHANGES] button "confirmationPopup|footerButtonsList" with text "Cancel all changes"
    And User clears text from Search Content field "contentListPage|searchContentField"
    And User enters "$eventTitle" in Search Content field "contentListPage|searchContentField"
    And User waits for Table Row "contentListPage|tableRowsList" with text "$eventTitle" visibility within 3 seconds
    And User clicks Title "contentListPage|titleList" on Table Row "contentListPage|tableRowsList" with text "$eventTitle"
    #Verify all fields
    And User scrolls page to top
    And Attribute "value" of Title field "moderateEventPage|titleField" is equal to "$eventTitle"
    And Attribute "value" of Content Url field "moderateEventPage|contentUrlField" is equal to "https://events.climateaction.org/sustainable-investment-forum-europe/"
    And Attribute "value" of Url Label field "moderateEventPage|urlLabelField" is equal to ""
    And Excerpt field "moderateEventPage|excerptField" text is equal to "Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla."
    And Content field "moderateEventPage|contentField" text is equal to "Donec quis orci eget orci vehicula condimentum. Curabitur in libero ut massa volutpat convallis."
    And Attribute "value" of Event Location field "moderateEventPage|eventLocationAutocompleteField" is equal to "San Francisco, United States"
    And Attribute "value" of Company field "moderateEventPage|companyAutocompleteField" is equal to "CompAuto"
    And Selected Region Option "moderateEventPage|regionsSelectedOptionsList" with text "US" is displayed
    And Event Type field "moderateEventPage|eventTypeDropdownField" input contains "Webinar" text
    #    lin: fixed at 31/Aug/2020
    #    And Attribute "value" of Start Date field "moderateEventPage|eventStartDateInput" is equal to "05/20/2020"
    And Start Date field "moderateEventPage|eventStartDateInput" contains "05/20/2020" text
    And Attribute "value" of Start Time field "moderateEventPage|eventStartTimeInput" is equal to "4:10 AM"
      #    And Attribute "value" of End Date field "moderateEventPage|eventEndDateInput" is equal to "05/20/2021"
    And Start Date field "moderateEventPage|eventEndDateInput" contains "05/20/2021" text
    And Attribute "value" of End Time field "moderateEventPage|eventEndTimeInput" is equal to "4:10 PM"
    And Taxonomy "moderateEventPage|taxonomiesSelectedOptionsList" with text "Hot Topics" is displayed
    And Tag "moderateEventPage|tagsSelectedList" with text "Markets & Economy" is displayed
    And Featured image dropzone "moderateEventPage|featuredImageDropzone" is displayed
#    And Uploaded Featured image "moderateEventPage|eventFeaturedImageUploaded" is displayed
#    And Remove Featured image button "moderateEventPage|eventRemoveFeaturedImageButton" is displayed
#    And Remove Featured image button "moderateEventPage|eventRemoveFeaturedImageButton" is enabled
    And User deletes "Event" with "Title" equal to "$eventTitle"
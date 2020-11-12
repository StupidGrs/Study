@events
Feature: Global Admin updates all fields of Pending Event and clicks [Save] / [Save and Preview] button

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
    #    lin: fixed at 31/Aug/2020
    #    And User remembers value of "value" attribute of "moderateEventPage|eventStartDateInput" as "updatedStartDate"
    And User remembers text of "moderateEventPage|eventStartDateInput" as "updatedStartDate"
    And User clicks End Date Calendar "moderateEventPage|eventEndDatePicker"
    And User clicks Next month button "calendar|nextMonthButton"
    And User clicks Day in calendar "calendar|daysList" with text "23"
    And User clicks End Date Calendar "moderateEventPage|eventEndDatePicker"
    #    lin: fixed at 31/Aug/2020
    #    And User remembers value of "value" attribute of "moderateEventPage|eventEndDateInput" as "updatedEndDate"
    And User remembers text of "moderateEventPage|eventEndDateInput" as "updatedEndDate"
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
  Scenario: Global Admin updates all fields, clicks [SAVE] button and verifies updated values
    When User clicks [SAVE] button "moderateEventPage|saveButton"
    Then Success toast "toast|toastMessage" is displayed
    And Success toast "toast|toastMessage" text is equal to "Item was successfully updated."
    When User clears text from Search Content field "contentListPage|searchContentField"
    Then User enters "$updatedEventTitle" in Search Content field "contentListPage|searchContentField"
    And User waits for Table Row "contentListPage|tableRowsList" with text "$updatedEventTitle" visibility within 3 seconds
    And User clicks Title "contentListPage|titleList" on Table Row "contentListPage|tableRowsList" with text "$updatedEventTitle"
    #Verify all fields
    And User scrolls page to top
    And Event Status "moderateEventPage|articleStatus" with text "Status: PENDING" is displayed
    And Attribute "value" of Title field "moderateEventPage|titleField" is equal to "$updatedEventTitle"
    And Attribute "value" of Content Url field "moderateEventPage|contentUrlField" is equal to "https://www.wikipedia.org/_UPDATED"
    And Excerpt field "moderateEventPage|excerptField" text is equal to "Excerpt_UPDATED"
    And Content field "moderateEventPage|contentField" text is equal to "Content_UPDATED"
    And Attribute "value" of Event Location field "moderateEventPage|eventLocationAutocompleteField" is equal to "Edinburgh, United Kingdom"
    And Attribute "value" of Company field "moderateEventPage|companyAutocompleteField" is equal to "CompAuto"
    And Selected Region Option "moderateEventPage|regionsSelectedOptionsList" with text "UK" is displayed
    And Event Type field "moderateEventPage|eventTypeDropdownField" input contains "Networking" text
    #    lin: fixed at 31/Aug/2020
    #    And Attribute "value" of Start Date field "moderateEventPage|eventStartDateInput" is equal to "$updatedStartDate"
    And Start Date field "moderateEventPage|eventStartDateInput" contains "$updatedStartDate" text
    And Attribute "value" of Start Time field "moderateEventPage|eventStartTimeInput" is equal to "10:30 AM"
    #    And Attribute "value" of End Date field "moderateEventPage|eventEndDateInput" is equal to "$updatedEndDate"
    And Start Date field "moderateEventPage|eventEndDateInput" contains "$updatedEndDate" text
    And Attribute "value" of End Time field "moderateEventPage|eventEndTimeInput" is equal to "6:00 PM"
    And Selected Regions list "moderateEventPage|regionsSelectedOptionsList" count is equal to 1
    And Selected Region "moderateEventPage|regionsSelectedOptionsList" with text "UK" is displayed
    And Selected Taxonomies list "moderateEventPage|taxonomiesSelectedOptionsList" count is equal to 2
    And Selected Taxonomy "moderateEventPage|taxonomiesSelectedOptionsList" with text "Hot Topics" is displayed
    And Selected Taxonomy "moderateEventPage|taxonomiesSelectedOptionsList" with text "Strategy" is displayed
    And Selected Tags list "moderateEventPage|tagsSelectedList" count is equal to 2
    And Selected Tag "moderateEventPage|tagsSelectedList" with text "Markets & Economy" is displayed
    And Selected Tag "moderateEventPage|tagsSelectedList" with text "Taxes" is displayed
#    And Featured image dropzone "moderateEventPage|featuredImageDropzone" is displayed
#    And Uploaded Featured image "moderateEventPage|eventFeaturedImageUploaded" is not displayed
#    And Remove Featured image button "moderateEventPage|eventRemoveFeaturedImageButton" is not displayed
    And User deletes "Event" with "Title" equal to "$updatedEventTitle"

  @regression
  @knwonIssue @SRC-1340
  Scenario: Global Admin updates all fields, clicks [Save and Preview] button and verifies updated values on Preview page
    When User clicks [Save and Preview] button "moderateEventPage|saveAndPreviewButton"
    Then Success toast "toast|toastMessage" is displayed
    And Success toast "toast|toastMessage" text is equal to "Item was successfully updated."
    And User waits for Event Title on Preview Page "eventDetailsPage|title" visibility within 3 seconds
    And User scrolls page to top
    # Verify Header elements
    Then Event Title "eventDetailsPage|title" text is equal to "$updatedEventTitle"
    And Event Exceprt "eventDetailsPage|excerpt" text is equal to "Excerpt_UPDATED"
    And Event Type "eventDetailsPage|eventTypeChip" text is equal to "Networking"
    And Event Date "eventDetailsPage|dateTimeHeader" contains Start Date "$updatedStartDate" and Time "10:30 AM" and End Date "$updatedEndDate" and Time "6:00 PM" in short format with GMT offset
    And Company Icon "eventDetailsPage|companyIconHeader" is displayed
    And Company Name "eventDetailsPage|companyNameHeader" contains "CompAuto" text
    And Location Icon "eventDetailsPage|locationIconHeader" is displayed
    And Location "eventDetailsPage|locationHeader" contains "Edinburgh, United Kingdom" text
    And [Tickets] Button "eventDetailsPage|ticketsButton" is displayed
    And [Tickets] Button "eventDetailsPage|ticketsButton" contains "Tickets & Info" text
    And [Tickets] Button "eventDetailsPage|ticketsButton" is enabled
    And Attribute "href" of [Tickets] Button "eventDetailsPage|ticketsButton" is equal to "https://www.wikipedia.org/_UPDATED"
    And [Back] Button "eventDetailsPage|backButton" is displayed
    # Verify date in circle
    And Days in Circle "eventDetailsPage|dateCircleDay" text is equal to "23-23"
    And Months in Circle "eventDetailsPage|dateCircleMonth" text is equal to "Sep-Jun"
    And Years in Circle "eventDetailsPage|dateCircleYear" contains "2020-2021" text
    # Verify Images
    And Event Header Background Image "eventDetailsPage|headerBackgroundImage" is displayed
    And Attribute "style" of Event Header Background Image "eventDetailsPage|headerBackgroundImage" contains "default-feature-image.png"
    And Event Featured Image "eventDetailsPage|headerFeaturedImage" is displayed
    And Attribute "style" of Event Featured Image "eventDetailsPage|headerFeaturedImage" contains "default-feature-image.png"
    And User compares screenshot of Featured Image "eventDetailsPage|headerFeaturedImage" to "eventDetails_featuredImage_default.png"
    # Content
    And Event Content "eventDetailsPage|content" text is equal to "Content_UPDATED"
    # Date & Time section
    And Date & Time label "eventDetailsPage|dateTimeLabelBottom" with text "Date & Time" is displayed
    And Calendar Icon "eventDetailsPage|calendarIconBottom" is displayed
    And Date "eventDetailsPage|dateBottom" text is equal to "Wednesday September 23, 2020 – Wednesday June 23, 2021"
    And Time "eventDetailsPage|timeBottom" contains "10:30am – 6:00pm" text with GMT offset
    # Location
    And Location label "eventDetailsPage|locationLabelBottom" with text "Location" is displayed
    And Location Icon "eventDetailsPage|locationIconBottom" is displayed
    And Location "eventDetailsPage|locationBottom" text is equal to "Edinburgh, United Kingdom"
    # Tag
    And Tags List "eventDetailsPage|eventTagChip" count is equal to 2
    And Tag "eventDetailsPage|eventTagChip" with text "Markets & Economy" is displayed
    And Tag "eventDetailsPage|eventTagChip" with text "Taxes" is displayed
    And User deletes "Event" with "Title" equal to "$updatedEventTitle"

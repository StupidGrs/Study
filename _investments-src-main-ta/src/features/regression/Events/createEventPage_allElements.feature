@events
Feature: Verify all elements on Create Event Page

  Background:
    Given User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks [Publish] button "header|publishButton"
    When User clicks Event button "modalWindow|eventIcon"

  @regression
  @createEventPage
  @knownIssue @knownIssue_IE @SRC-1950
  Scenario: User verifies that all Create an Event page elements are displayed.
    Then Close button "createEventPage|closeIcon" is displayed
#    And Modal header "createEventPage|modalHeader" with text "Create an Event" is displayed
    And Modal header "createEventPage|modalHeader" with text "Publish Your" is displayed
    And Company field label "createEventPage|companyFieldLabel" with text "Company" is displayed
    And Attribute "value" of Company Field "createEventPage|companyField" is equal to "CompAuto"
    And Close button "createEventPage|closeIcon" is displayed
    And Event Type field Label "createEventPage|eventTypeFieldLabel" with text "Event Type" is displayed
    And Event Type field "createEventPage|eventTypeFieldOption" with text "Select Type" is displayed
    And Event Type field Label Span "createEventPage|eventTypeFieldLabelSpan" with text "*" is displayed
    And Event Name field Label "createEventPage|eventNameFieldLabel" with text "Event Name" is displayed
    And Event Name field Label Span "createEventPage|eventNameFieldLabelSpan" with text "*" is displayed
    And Attribute "placeholder" of Event Name field "createEventPage|eventNameField" is equal to ""
    And Location field Label "createEventPage|locationFieldLabel" with text "Location" is displayed
    And Location field Label Span "createEventPage|locationFieldLabelSpan" with text "*" is displayed
    And Attribute "placeholder" of Event Location field "createEventPage|locationField" is equal to "Begin Typing"
    And Region field Label "createEventPage|regionFieldLabel" with text "Region" is displayed
    And Region field "createEventPage|regionFieldDropdown" is displayed
#    And Region Field Span "createEventPage|regionFieldSpan" with text "Pick One" is displayed
    And Start date field "createEventPage|startDateField" is displayed
    And Start date field Label "createEventPage|startDateFieldLabel" with text "Start Date" is displayed
    And Start date calendar Icon "createEventPage|datepickerStartDate" is displayed
    And Start time field "createEventPage|startTimeField" is displayed
    And Start time field Label "createEventPage|startTimeFieldLabel" with text "Start Time" is displayed
    And Start time field Label Span "createEventPage|startTimeFieldLabelSpan" with text "*" is displayed
    And Attribute "placeholder" of Start Time field "createEventPage|startTimeField" is equal to "12:00 PM"
    And End date field "createEventPage|endDateField" is displayed
    And End date field Label "createEventPage|endDateFieldLabel" with text "End Date" is displayed
    And End date calendar Icon "createEventPage|datepickerEndDate" is displayed
    And End time field "createEventPage|endTimeField" is displayed
    And End time field Label "createEventPage|endTimeFieldLabel" with text "End Time" is displayed
    And End time field Label Span "createEventPage|endTimeFieldLabelSpan" with text "*" is displayed
    And Attribute "placeholder" of End Time field "createEventPage|endTimeField" is equal to "12:00 PM"
    #todo: End time icon is displayed
    And URL link field "createEventPage|urlLinkField" is displayed
    And URL link field Label "createEventPage|urlLinkFieldLabel" with text "URL Link" is displayed
    And Attribute "placeholder" of URL link field "createEventPage|urlLinkField" is equal to "https://"
    And Taxonomy field option "createEventPage|taxonomyFieldOption" with text "Select Taxonomy" is displayed
    And Taxonomy field Label "createEventPage|taxonomyFieldLabel" with text "Taxonomies" is displayed
    And Taxonomy field Label Span "createEventPage|taxonomyFieldLabelSpan" with text "*" is displayed
    And Tags field "createEventPage|tagsField" is displayed
    And Attribute "placeholder" of Tags field "createEventPage|tagsField" is equal to "Search Tags"
    And Tags field label "createEventPage|tagsFieldLabel" with text "Tags" is displayed
    And Excerpt field "createEventPage|excerptField" is displayed
    And Attribute "placeholder" of Excerpt field "createEventPage|excerptField" is equal to ""
    And Excerpt field Label "createEventPage|excerptFieldLabel" with text "Event Excerpt" is displayed
    And Excerpt field Label Span "createEventPage|excerptFieldLabelSpan" with text "*" is displayed
    #todo: add counter check
    And Content field "createEventPage|contentField" is displayed
    And Attribute "data-placeholder" of Content Field "createEventPage|contentField" is equal to "Insert text here ..."
    And Content field Toolbar "createEventPage|contentField" is displayed
    And Content field Label "createEventPage|contentFieldLabel" with text "Event Content" is displayed
    And Content field Label span "createEventPage|contentFieldLabelSpan" with text "*" is displayed

#    And File DropZone  "createEventPage|fileDropZone" is displayed
#    And Attachment field Label "createEventPage|attachmentFieldLabel" with text "Upload Featured Image" is displayed
#    And Attachment field message "createEventPage|attachmentFieldMessage" with text " Drag and drop to upload a file" is displayed
#    And Attachment field icon "createEventPage|attachmentFieldIcon" is displayed

    And button "createEventPage|cancelButton" with text "Cancel" is displayed
    And button "createEventPage|saveDraftButton" with text "Save Draft" is displayed
    And Save Draft button "createEventPage|saveDraftButton" is disabled
    And Save Draft button Icon "createEventPage|saveDraftButtonIcon" is displayed
#    And button "createEventPage|modalFooterButtons" with text "Submit" is displayed
    And button "createEventPage|Submit" with text "Submit" is displayed
#    And button "createEventPage|modalFooterButtons" with text "Submit and Post New" is displayed
    And button "createEventPage|SubmitAndAddAnother" with text "Submit & Add Another" is displayed
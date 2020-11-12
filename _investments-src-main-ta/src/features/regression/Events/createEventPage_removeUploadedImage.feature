#@events
#Feature: Verify that Company Admin is able to remove uploaded image
#
#  Background:
#    Given User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
#    And User clicks [Publish] button "header|publishButton"
#    When User clicks Event button "modalWindow|eventIcon"
#
#  @regression
#  @createEventPage
#  Scenario: Company Admin uploads Featured image and then removes it.
#    Then User makes upload of file "featuredForEvent.png" using Upload field "createEventPage|attachmentFieldInput"
##    And Button "createEventPage|removeImageButton" with text "Remove Image" is displayed // WB: 2020-06-30 commented
#    And Uploaded file "createEventPage|uploadedFileTitle" text is equal to "featuredForEvent.png"
#    When User clicks button "createEventPage|removeImageButton" with text "Remove Image"
#    Then Button "createEventPage|removeImageButton" with text "Remove Image" is not displayed
#    And Attachment field message "createEventPage|attachmentFieldMessage" with text " Drag and drop to upload a file" is displayed
#    And Attachment field icon "createEventPage|attachmentFieldIcon" is displayed
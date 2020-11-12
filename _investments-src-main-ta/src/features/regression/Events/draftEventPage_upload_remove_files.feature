#@events
#Feature: Verify that Company Admin is able to upload / remove uploaded files on Draft Event Page
#
#  @ignore
#  @regression
#  @draftEventPage
#  Scenario: Company Admin uploads Featured image and then removes it on Draft Event Page.
#    #create draft Event without Featured Image
#    When User "COMPANY_ADMIN" logs in with API
#    And User remembers text "Test_Auto_Draft_Event" with added unique Id as "eventTitle"
#    Then User "COMPANY_ADMIN" saves Draft "Event" with title "$eventTitle" with API
#    #open created draft Event
#    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
#    And User clicks Profile Button "header|profileButton"
#    And User clicks Posts link "header|postsLink" by executing script
#    And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
#    And User selects item "option" with text "event" from Select Content Type dropdown "userPostsPage|selectContentTypeDropdownOptionsList"
#    Then User Event "userPostsPage|articleTitlesList" with text "$eventTitle" is displayed
#    And User clicks Post "userPostsPage|articleTitlesList" with text "$eventTitle" using script
#    #Upload Featured Image
#    When User makes upload of file "featuredForEvent.png" using Upload field "createEventPage|attachmentFieldInput"
#    Then Button "createEventPage|removeImageButton" with text "Remove Image" is displayed
#    And Uploaded file "createEventPage|uploadedFileTitle" text is equal to "featuredForEvent.png"
#    #Remove uploaded Featured Image
#    When User clicks button "createEventPage|removeImageButton" with text "Remove Image"
#    Then Button "createEventPage|removeImageButton" with text "Remove Image" is not displayed
#    And Attachment field message "createEventPage|attachmentFieldMessage" with text "Drag and drop to upload a file" is displayed
#    And Attachment field icon "createEventPage|attachmentFieldIcon" is displayed
#    #delete research
#    And User deletes "Event" with "Title" equal to "$eventTitle"
#
#  @ignore
#  @regression
#  @draftEventPage
#  Scenario: Company Admin removes Featured image and then uploads new on Draft Event Page.
#    #create draft Event without Featured Image
#    When User "COMPANY_ADMIN" logs in with API
#    And User remembers text "Test_Auto_Draft_Event" with added unique Id as "eventTitle"
#    Then User "COMPANY_ADMIN" saves Draft "Event" with all fields and title "$eventTitle" with API
#    #open created draft Event
#    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
#    And User clicks Profile Button "header|profileButton"
#    And User clicks Posts link "header|postsLink" by executing script
#    And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
#    And User selects item "option" with text "event" from Select Content Type dropdown "userPostsPage|selectContentTypeDropdownOptionsList"
#    Then User Event "userPostsPage|articleTitlesList" with text "$eventTitle" is displayed
#    And User clicks Post "userPostsPage|articleTitlesList" with text "$eventTitle" using script
#    #Remove originally uploaded Featured Image
#    When User clicks Remove Uploaded Image Icon "createEventPage|attachedImageRemoveIcon"
#    Then Uploaded Image "createEventPage|attachedImageLabel" is not displayed
#    And Remove Uploaded Image Icon "createEventPage|attachedImageRemoveIcon" is not displayed
#    And Attachment field message "createEventPage|attachmentFieldMessage" with text "Drag and drop to upload a file" is displayed
#    And Attachment field icon "createEventPage|attachmentFieldIcon" is displayed
#    #Upload Featured Image
#    When User makes upload of file "featuredForEvent.png" using Upload field "createEventPage|attachmentFieldInput"
#    Then Button "createEventPage|removeImageButton" with text "Remove Image" is displayed
#    And Uploaded file "createEventPage|uploadedFileTitle" text is equal to "featuredForEvent.png"
#    #delete research
#    And User deletes "Event" with "Title" equal to "$eventTitle"
#
##TODO
##Add tests to upload file and save, open and check file is present
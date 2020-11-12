@approveRejectEvent
@resubmitEvent
Feature: Company Admin resubmits Rejected event

  Background:
    Given User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    Then User "COMPANY_ADMIN" publishes "Event" with title "$eventTitle" with API
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" rejects "Event" with title "$eventTitle" with API
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Profile Button "header|profileButton"
    And User clicks Posts link "header|postsLink" by executing script
    And User selects item "option" with text "event" from Content Type dropdown "userPostsPage|selectContentTypeDropdown"
    And User clicks Post "userPostsPage|articleTitlesList" with text "$eventTitle" using script

  @smoke
  @regression
  Scenario: Company Admin resubmits Rejected event without changes
    When User clicks Resubmit button "createEventPage|resubmitButton"
    Then User refreshes page
    And User selects item "option" with text "event" from Content Type dropdown "userPostsPage|selectContentTypeDropdown"
    And User Post "userPostsPage|articleTitlesList" with text "$eventTitle" is displayed
    And Post Status "userPostsPage|articleStatusesList" text is equal to "Approval Pending" on Post "userPostsPage|articlesList" with text "$eventTitle"
    And User deletes "Event" with "Title" equal to "$eventTitle"

  @regression
  Scenario: Company Admin verifies toast message when resubmits Rejected event
    When User clicks Resubmit button "createEventPage|resubmitButton"
    Then Toast message "toast|toastMessage" is displayed
    And Toast message "toast|toastMessage" text is equal to "TEXT:Event_update_submitted_toast"
    And User clicks Close Toast icon "toast|toastCloseIcon"
    And User deletes "Event" with "Title" equal to "$eventTitle"

  @smoke
  @regression
  Scenario: Company Admin resubmits Rejected event with updated Title
    And User enters "_UPDATED" in Title field "createEventPage|eventNameField"
    And User remembers value of "value" attribute of "createEventPage|eventNameField" as "updatedEventTitle"
    And User clicks Resubmit button "createEventPage|resubmitButton"
    Then User refreshes page
    And User selects item "option" with text "event" from Content Type dropdown "userPostsPage|selectContentTypeDropdown"
    And User Post "userPostsPage|articleTitlesList" with text "$updatedEventTitle" is displayed
    And Post Status "userPostsPage|articleStatusesList" text is equal to "Approval Pending" on Post "userPostsPage|articlesList" with text "$updatedEventTitle"
    And User deletes "Event" with "Title" equal to "$updatedEventTitle"

  @smoke
  @regression
  Scenario: Global Admin checks resubmitted event
    When User clicks Resubmit button "createEventPage|resubmitButton"
    And User clicks Profile button "header|profileButton"
    And User clicks Profile Menu Item "header|profileMenuItemsList" with text "Logout"
    When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "header|settingsButton"
    And User clicks Moderate Content link "header|moderateContentLink" by executing script
    And User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User selects item "option" with text "event" from Article Type dropdown "contentListPage|articleTypeDropdown"
    And User enters "$eventTitle" in Search Content field "contentListPage|searchContentField"
    And User waits for Table Row "contentListPage|tableRowsList" with text "$eventTitle" visibility within 3 seconds
    And User deletes "Event" with "Title" equal to "$eventTitle"
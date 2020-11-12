@viewApprovedEvent
Feature: Global Admin verifies View Event feature in Moderate Content

  @regression
  Scenario: Global Admin approves Event and clicks View
    #precondition
    Given User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    And User "COMPANY_ADMIN" publishes "Event" with title "$eventTitle" with API
    Given User "GLOBAL_ADMIN" logs in with API
    And User "GLOBAL_ADMIN" approves "Event" with title "$eventTitle" with API
    #flow
    Given User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "header|settingsButton"
    And User clicks Moderate Content link "header|moderateContentLink" by executing script
    And User selects item "option" with text "Approved" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User selects item "option" with text "event" from Article Type dropdown "contentListPage|articleTypeDropdown"
    And User enters "$eventTitle" in Search Content field "contentListPage|searchContentField"
    And User waits for Table Row "contentListPage|tableRowsList" with text "$eventTitle" visibility within 3 seconds
    When User clicks View button "contentListPage|viewButtonsList"
    Then Event Title "eventDetailsPage|title" with text "$eventTitle" is displayed
    #postcondition
    And User deletes "Event" with "Title" equal to "$eventTitle"
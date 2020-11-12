@viewApprovedResearch
Feature: Global Admin verifies View Research feature in Moderate Content

  @regression
  Scenario: Global Admin approves Research and clicks View
    #precondition
    Given User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    And User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle" with API
    Given User "GLOBAL_ADMIN" logs in with API
    And User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API
    #flow
    Given User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "header|settingsButton"
    And User clicks Moderate Content link "header|moderateContentLink" by executing script
    And User selects item "option" with text "Approved" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
    And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
    And User waits for Table Row "contentListPage|tableRowsList" with text "$researchTitle" visibility within 3 seconds
    When User clicks View button "contentListPage|viewButtonsList"
    Then Research Title "researchDetailsPage|title" with text "$researchTitle" is displayed
    #postcondition
    And User deletes "Research" with "Title" equal to "$researchTitle"
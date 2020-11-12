@viewApprovedNewsItem
Feature: Global Admin verifies View News Item feature in Moderate Content

  @regression
  Scenario: Global Admin approves News Item and clicks View
    #precondition
    Given User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_News_Item" with added unique Id as "newsTitle"
    And User "COMPANY_ADMIN" publishes "News" with title "$newsTitle" with API
    Given User "GLOBAL_ADMIN" logs in with API
    And User "GLOBAL_ADMIN" approves "News" with title "$newsTitle" with API
    #flow
    Given User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "header|settingsButton"
    And User clicks Moderate Content link "header|moderateContentLink" by executing script
    And User selects item "option" with text "Approved" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User selects item "option" with text "blog/news post" from Article Type dropdown "contentListPage|articleTypeDropdown"
    And User enters "$newsTitle" in Search Content field "contentListPage|searchContentField"
    And User waits for Table Row "contentListPage|tableRowsList" with text "$newsTitle" visibility within 3 seconds
    When User clicks View button "contentListPage|viewButtonsList"
    Then News Item Title "newsDetailsPage|title" with text "$newsTitle" is displayed
    #postcondition
    And User deletes "News" with "Title" equal to "$newsTitle"
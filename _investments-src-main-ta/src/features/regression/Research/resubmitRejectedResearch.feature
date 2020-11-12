@approveRejectResearch
@resubmitResearch
Feature: Company Admin resubmits Rejected research

  Background:
    Given User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle" with API
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" rejects "Research" with title "$researchTitle" with API
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Profile Button "header|profileButton"
    And User clicks Posts link "header|postsLink" by executing script
    And User selects item "option" with text "research post" from Content Type dropdown "userPostsPage|selectContentTypeDropdown"
    And User clicks Post "userPostsPage|articleTitlesList" with text "$researchTitle" using script

  @smoke
  @regression
  Scenario: Company Admin resubmits Rejected research without changes
    When User clicks Resubmit button "publishResearchPage|resubmitButton"
    Then User refreshes page
    And User Post "userPostsPage|articleTitlesList" with text "$researchTitle" is displayed
    And Post Status "userPostsPage|articleStatusesList" text is equal to "Approval Pending" on Post "userPostsPage|articlesList" with text "$researchTitle"
    And User deletes "Research" with "Title" equal to "$researchTitle"

  @regression
  Scenario: Company Admin verifies toast message when resubmits Rejected research
    When User clicks Resubmit button "publishResearchPage|resubmitButton"
    Then Toast message "toast|toastMessage" is displayed
    And Toast message "toast|toastMessage" text is equal to "TEXT:Publish_research_toast_success"
    And User clicks Close Toast icon "toast|toastCloseIcon"
    And User deletes "Research" with "Title" equal to "$researchTitle"

  @smoke
  @regression
  Scenario: Company Admin resubmits Rejected research with updated Title
    And User enters "_UPDATED" in Title field "publishResearchPage|titleField"
    And User remembers value of "value" attribute of "publishResearchPage|titleField" as "updatedResearchTitle"
    And User clicks Resubmit button "publishResearchPage|resubmitButton"
    Then User refreshes page
    And User Post "userPostsPage|articleTitlesList" with text "$updatedResearchTitle" is displayed
    And Post Status "userPostsPage|articleStatusesList" text is equal to "Approval Pending" on Post "userPostsPage|articlesList" with text "$updatedResearchTitle"
    And User deletes "Research" with "Title" equal to "$updatedResearchTitle"

  @smoke
  @regression
  Scenario: Global Admin checks resubmitted research
    When User clicks Resubmit button "publishResearchPage|resubmitButton"
    And User clicks Profile button "header|profileButton"
    And User clicks Profile Menu Item "header|profileMenuItemsList" with text "Logout"
    When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "header|settingsButton"
    And User clicks Moderate Content link "header|moderateContentLink" by executing script
    And User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
    And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
    And User waits for Table Row "contentListPage|tableRowsList" with text "$researchTitle" visibility within 3 seconds
    And User deletes "Research" with "Title" equal to "$researchTitle"
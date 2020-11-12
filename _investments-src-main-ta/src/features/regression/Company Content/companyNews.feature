@companyNews
Feature: Company Admin verifies News Items in Company Content page

  @regression
  Scenario Outline: Company Admin clicks News Item link (submitted by COMPANY <role>) in Published tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers text "Test_Auto_News_Item" with added unique Id as "newsTitle"
    Then User "COMPANY_<role>" publishes "News" with all fields and title "$newsTitle" with API
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" approves "News" with title "$newsTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User selects News option "companyContent|newsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User enters "$newsTitle" in Search Field "companyContent|searchField"
    When User clicks Content Link "companyContent|contentLink" with text "$newsTitle"
    Then News Item Title "newsDetailsPage|title" with text "$newsTitle" is displayed
    #postcondition
    And User deletes "News" with "Title" equal to "$newsTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |

  @regression  @knownIssue
  Scenario Outline: Company Admin clicks News Item link (submitted by COMPANY <role>) in Pending Approval tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers text "Test_Auto_News_Item" with added unique Id as "newsTitle"
    Then User "COMPANY_<role>" publishes "News" with all fields and title "$newsTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User selects News option "companyContent|newsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User clicks Pending Approval tab "companyContent|pendingApprovalTab"
    And User enters "$newsTitle" in Search Field "companyContent|searchField"
    When User clicks Content Link "companyContent|contentLink" with text "$newsTitle"
    Then News Item Title "newsDetailsPage|title" with text "$newsTitle" is displayed
    #postcondition
    And User deletes "News" with "Title" equal to "$newsTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |
#    Egle:2020-09-07 Role AUTHOR is not working and fix with SRC-2759

  @regression @knownIssue
  Scenario Outline: Company Admin clicks News Item link (submitted by COMPANY <role>) in Draft tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers text "Test_Auto_News_Item" with added unique Id as "newsTitle"
    Then User "COMPANY_<role>" saves Draft "News" with all fields and title "$newsTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User selects News option "companyContent|newsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User clicks Draft tab "companyContent|draftTab"
    When User clicks Content Link "companyContent|contentLink" with text "$newsTitle"
    Then News Item Title "newsDetailsPage|title" with text "$newsTitle" is displayed
    #postcondition
    And User deletes "News" with "Title" equal to "$newsTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |
#    Egle:2020-09-07 Role AUTHOR is not working and fix with SRC-2759

  @regression  @knownIssue
  Scenario Outline: Company Admin clicks News Item link (submitted by COMPANY <role>) in Rejected tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers text "Test_Auto_News_Item" with added unique Id as "newsTitle"
    Then User "COMPANY_<role>" publishes "News" with all fields and title "$newsTitle" with API
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" rejects "News" with title "$newsTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User selects News option "companyContent|newsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User clicks Rejected tab "companyContent|rejectedTab"
    When User clicks Content Link "companyContent|contentLink" with text "$newsTitle"
    Then News Item Title "newsDetailsPage|title" with text "$newsTitle" is displayed
    #postcondition
    And User deletes "News" with "Title" equal to "$newsTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |
    #    Egle:2020-09-07 Role AUTHOR is not working and fix with SRC-2759
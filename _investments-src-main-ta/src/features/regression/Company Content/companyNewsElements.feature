@companyNewsElements
Feature: Company Admin verifies News Items in different statuses on Company Content page

  @regression
  Scenario Outline: Company Admin verifies News Item in Published tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers current date in format "M/D/YYYY" as "currentDate"
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
    Then Content Type "companyContent|contentTypeCell" with text "article/blog" is displayed
    And Featured Icon "companyContent|featuredIcon" is not displayed
    And Ratings number "companyContent|ratingsCell" with text "-" is displayed
    And News Item Title "companyContent|postNameCell" with text "$newsTitle" is displayed
    And Post Date "companyContent|postDateCell" text is equal to "$currentDate"
    And Views Counter "companyContent|viewsCounterCell" with text "0" is displayed
    And Clickthroughs Counter "companyContent|clickthroughsCell" with text "0" is displayed
    And Downloads Counter "companyContent|downloadsCell" with text "0" is displayed
#    And Actions Button "companyContent|actionsButton" is displayed
    #postcondition
    And User deletes "News" with "Title" equal to "$newsTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |

  @regression
  Scenario Outline: Company Admin verifies News Item in Pending Approval tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers current date in format "M/D/YYYY" as "currentDate"
    And User remembers text "Test_Auto_News_Item" with added unique Id as "newsTitle"
    Then User "COMPANY_<role>" publishes "News" with all fields and title "$newsTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User selects News option "companyContent|newsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User clicks Pending Approval tab "companyContent|pendingApprovalTab"
    And User enters "$newsTitle" in Search Field "companyContent|searchField"
    Then Content Type "companyContent|contentTypeCell" with text "article/blog" is displayed
    And Featured Icon "companyContent|featuredIcon" is not displayed
    And Ratings number "companyContent|ratingsCell" with text "-" is displayed
    And News Item Title "companyContent|postNameCell" with text "$newsTitle" is displayed
    And Post Date "companyContent|postDateCell" text is equal to "$currentDate"
    And Views Counter "companyContent|viewsCounterCell" with text "0" is displayed
    And Clickthroughs Counter "companyContent|clickthroughsCell" with text "0" is displayed
    And Downloads Counter "companyContent|downloadsCell" with text "0" is displayed
#    And Actions Button "companyContent|actionsButton" is displayed
    #postcondition
    And User deletes "News" with "Title" equal to "$newsTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |

  @regression
  Scenario Outline: Company Admin verifies News Item in Draft tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers current date in format "M/D/YYYY" as "currentDate"
    And User remembers text "Test_Auto_News_Item" with added unique Id as "newsTitle"
    Then User "COMPANY_<role>" saves Draft "News" with all fields and title "$newsTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User clicks Draft tab "companyContent|draftTab"
    And User enters "$newsTitle" in Search Field "companyContent|searchField"
    And User selects News option "companyContent|newsOption" from Content Type dropdown "companyContent|contentTypeField"
    Then Content Type "companyContent|contentTypeCell" with text "article/blog" is displayed
    And Featured Icon "companyContent|featuredIcon" is not displayed
    And Ratings number "companyContent|ratingsCell" with text "-" is displayed
    And News Item Title "companyContent|postNameCell" with text "$newsTitle" is displayed
    And Post Date "companyContent|postDateCell" text is equal to "$currentDate"
    And Views Counter "companyContent|viewsCounterCell" with text "0" is displayed
    And Clickthroughs Counter "companyContent|clickthroughsCell" with text "0" is displayed
    And Downloads Counter "companyContent|downloadsCell" with text "0" is displayed
#    And Actions Button "companyContent|actionsButton" is displayed
    #postcondtion
    And User deletes "News" with "Title" equal to "$newsTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |

  @regression
  Scenario Outline: Company Admin verifies News Item in Rejected tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers current date in format "M/D/YYYY" as "currentDate"
    And User remembers text "Test_Auto_News_Item" with added unique Id as "newsTitle"
    Then User "COMPANY_<role>" publishes "News" with all fields and title "$newsTitle" with API
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" rejects "News" with title "$newsTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User clicks Rejected tab "companyContent|rejectedTab"
    And User enters "$newsTitle" in Search Field "companyContent|searchField"
    And User selects News option "companyContent|newsOption" from Content Type dropdown "companyContent|contentTypeField"
    Then Content Type "companyContent|contentTypeCell" with text "article/blog" is displayed
    And Featured Icon "companyContent|featuredIcon" is not displayed
    And Ratings number "companyContent|ratingsCell" with text "-" is displayed
    And News Item Title "companyContent|postNameCell" with text "$newsTitle" is displayed
    And Post Date "companyContent|postDateCell" text is equal to "$currentDate"
    And Views Counter "companyContent|viewsCounterCell" with text "0" is displayed
    And Clickthroughs Counter "companyContent|clickthroughsCell" with text "0" is displayed
    And Downloads Counter "companyContent|downloadsCell" with text "0" is displayed
#    And Actions Button "companyContent|actionsButton" is displayed
    #postcondition
    And User deletes "News" with "Title" equal to "$newsTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |
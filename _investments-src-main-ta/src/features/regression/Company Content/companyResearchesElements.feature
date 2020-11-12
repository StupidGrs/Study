@companyResearchesElements
Feature: Company Admin verifies Researches in different statuses on Company Content page

  @regression
  Scenario Outline: Company Admin verifies Research in Published tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    And User remembers current date in format "M/D/YYYY" as "currentDate"
    Then User "COMPANY_<role>" publishes "Research" with all fields and title "$researchTitle" with API
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User enters "$researchTitle" in Search Field "companyContent|searchField"
    Then Content Type "companyContent|contentTypeCell" with text "research" is displayed
    And Featured Icon "companyContent|featuredIcon" is displayed
    And Ratings number "companyContent|ratingsCell" with text "-" is displayed
    And Post Name "companyContent|postNameCell" with text "$researchTitle" is displayed
    And Post Date "companyContent|postDateCell" text is equal to "$currentDate"
    And Views Counter "companyContent|viewsCounterCell" with text "0" is displayed
    And Clickthroughs Counter "companyContent|clickthroughsCell" with text "0" is displayed
    And Downloads Counter "companyContent|downloadsCell" with text "0" is displayed
#    Egle:2020-09-08 Action button no long exist
#    And Actions Button "companyContent|actionsButton" is displayed
    #postcondition
    And User deletes "Research" with "Title" equal to "$researchTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |

  @regression
  Scenario Outline: Company Admin verifies Research in Pending Approval tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers current date in format "M/D/YYYY" as "currentDate"
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_<role>" publishes "Research" with all fields and title "$researchTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User clicks Pending Approval tab "companyContent|pendingApprovalTab"
    And User enters "$researchTitle" in Search Field "companyContent|searchField"
    Then Content Type "companyContent|contentTypeCell" with text "research" is displayed
    And Featured Icon "companyContent|featuredIcon" is displayed
    And Ratings number "companyContent|ratingsCell" with text "-" is displayed
    And Post Name "companyContent|postNameCell" with text "$researchTitle" is displayed
    And Post Date "companyContent|postDateCell" text is equal to "$currentDate"
    And Views Counter "companyContent|viewsCounterCell" with text "0" is displayed
    And Clickthroughs Counter "companyContent|clickthroughsCell" with text "0" is displayed
    And Downloads Counter "companyContent|downloadsCell" with text "0" is displayed
    #    Egle:2020-09-08 Action button no long exist
#    And Actions Button "companyContent|actionsButton" is displayed
    #postcondition
    And User deletes "Research" with "Title" equal to "$researchTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |
    #    Egle:2020-09-07 Role AUTHOR is not working and fix with SRC-2759

  @regression
  Scenario Outline: Company Admin verifies Research in Draft tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers current date in format "M/D/YYYY" as "currentDate"
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_<role>" saves Draft "Research" with all fields and title "$researchTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User clicks Draft tab "companyContent|draftTab"
    And User enters "$researchTitle" in Search Field "companyContent|searchField"
    Then Content Type "companyContent|contentTypeCell" with text "research" is displayed
    And Featured Icon "companyContent|featuredIcon" is displayed
    And Ratings number "companyContent|ratingsCell" with text "-" is displayed
    And Post Name "companyContent|postNameCell" with text "$researchTitle" is displayed
    And Post Date "companyContent|postDateCell" text is equal to "$currentDate"
    And Views Counter "companyContent|viewsCounterCell" with text "0" is displayed
    And Clickthroughs Counter "companyContent|clickthroughsCell" with text "0" is displayed
    And Downloads Counter "companyContent|downloadsCell" with text "0" is displayed
    #    Egle:2020-09-08 Action button no long exist
#    And Actions Button "companyContent|actionsButton" is displayed
    #postcondtion
    And User deletes "Research" with "Title" equal to "$researchTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |
    #    Egle:2020-09-07 Role AUTHOR is not working and fix with SRC-2759

  @regression
  Scenario Outline: Company Admin verifies Research in Rejected tab
    #precondition
    When User "COMPANY_<role>" logs in with API
    And User remembers current date in format "M/D/YYYY" as "currentDate"
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_<role>" publishes "Research" with all fields and title "$researchTitle" with API
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" rejects "Research" with title "$researchTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User clicks Rejected tab "companyContent|rejectedTab"
    And User enters "$researchTitle" in Search Field "companyContent|searchField"
    Then Content Type "companyContent|contentTypeCell" with text "research" is displayed
    And Featured Icon "companyContent|featuredIcon" is displayed
    And Ratings number "companyContent|ratingsCell" with text "-" is displayed
    And Post Name "companyContent|postNameCell" with text "$researchTitle" is displayed
    And Post Date "companyContent|postDateCell" text is equal to "$currentDate"
    And Views Counter "companyContent|viewsCounterCell" with text "0" is displayed
    And Clickthroughs Counter "companyContent|clickthroughsCell" with text "0" is displayed
    And Downloads Counter "companyContent|downloadsCell" with text "0" is displayed
    #    Egle:2020-09-08 Action button no long exist
#    And Actions Button "companyContent|actionsButton" is displayed
    #postcondition
   And User deletes "Research" with "Title" equal to "$researchTitle"
    Examples:
      |role  |
      |AUTHOR|
      |ADMIN |
    #    Egle:2020-09-07 Role AUTHOR is not working and fix with SRC-2759
@companyContentViews
Feature: Company Admin verifies Views counter on Company Content page

  @regression
  Scenario Outline: Company Admin verifies Views Counter for Researches in <tab_name> tab by opening Research
    #precondition
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_ADMIN" publishes "Research" with all fields and title "$researchTitle" with API
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" <action> "Research" with title "$researchTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User clicks <tab_name> tab "companyContent|<selector>"
    And User enters "$researchTitle" in Search Field "companyContent|searchField"
    Then Post Name "companyContent|postNameCell" with text "$researchTitle" is displayed
    And Views Counter "companyContent|viewsCounterCell" text is equal to "0"
    When User clicks Research Title "companyContent|contentLink" with text "$researchTitle"
    Then Research Title "researchDetailsPage|title" with text "$researchTitle" is displayed
    And Views Counter "researchDetailsPage|headerViewsCount" text is equal to "1"
    When User clicks Back button "researchDetailsPage|backButton" by executing script
    And User clicks <tab_name> tab "companyContent|<selector>"
    And User enters "$researchTitle" in Search Field "companyContent|searchField"
    Then Post Name "companyContent|postNameCell" with text "$researchTitle" is displayed
    And Views Counter "companyContent|viewsCounterCell" text is equal to "<number>"
    #postcondition
    And User deletes "Research" with "Title" equal to "$researchTitle"
    Examples:
      |action  |tab_name          |selector            |number|
      |approves|Published         |publishedTab        |1     |
      |rejects |Rejected          |rejectedTab         |0     |

  @regression
  Scenario Outline: Company Admin verifies Views Counter for Researches in <tab_name> tab by opening Research
    #precondition
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_ADMIN" <action> "Research" with all fields and title "$researchTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User clicks <tab_name> tab "companyContent|<selector>"
    And User enters "$researchTitle" in Search Field "companyContent|searchField"
    Then Post Name "companyContent|postNameCell" with text "$researchTitle" is displayed
    And Views Counter "companyContent|viewsCounterCell" text is equal to "0"
    When User clicks Research Title "companyContent|contentLink" with text "$researchTitle"
    Then Research Title "researchDetailsPage|title" with text "$researchTitle" is displayed
    And Views Counter "researchDetailsPage|headerViewsCount" text is equal to "1"
    When User clicks Back button "researchDetailsPage|backButton" by executing script
    And User clicks <tab_name> tab "companyContent|<selector>"
    And User enters "$researchTitle" in Search Field "companyContent|searchField"
    Then Post Name "companyContent|postNameCell" with text "$researchTitle" is displayed
    And Views Counter "companyContent|viewsCounterCell" with text "<number>" is displayed
    #postcondition
    And User deletes "Research" with "Title" equal to "$researchTitle"
    Examples:
      |action      |tab_name        |selector            |number|
      |publishes   |Pending Approval|pendingApprovalTab  |0     |
      |saves Draft |Draft           |draftTab            |0     |

  @regression
  Scenario Outline: Company Admin verifies Views Counter for News Items in <tab_name> tab by opening News Item
    #precondition
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_News_Item" with added unique Id as "newsTitle"
    Then User "COMPANY_ADMIN" publishes "News" with all fields and title "$newsTitle" with API
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" <action> "News" with title "$newsTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User selects News option "companyContent|newsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User enters "$newsTitle" in Search Field "companyContent|searchField"
    And User clicks <tab_name> tab "companyContent|<selector>"
    Then News Item "companyContent|postNameCell" with text "$newsTitle" is displayed
    And Views Counter "companyContent|viewsCounterCell" text is equal to "0"
    When User clicks News Item "companyContent|contentLink" with text "$newsTitle"
    Then News Item "newsDetailsPage|title" with text "$newsTitle" is displayed
    And Views Counter "newsDetailsPage|headerViewsCount" text is equal to "1"
    When User clicks Back button "newsDetailsPage|backButton" by executing script
    And User selects News option "companyContent|newsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User enters "$newsTitle" in Search Field "companyContent|searchField"
    And User clicks <tab_name> tab "companyContent|<selector>"
    Then News Item "companyContent|postNameCell" with text "$newsTitle" is displayed
    And Views Counter "companyContent|viewsCounterCell" text is equal to "<number>"
    #postcondition
    And User deletes "News" with "Title" equal to "$newsTitle"
    Examples:
      |action  |tab_name          |selector            |number|
      |approves|Published         |publishedTab        |1     |
      |rejects |Rejected          |rejectedTab         |0     |

  @regression
  Scenario Outline: Company Admin verifies Views Counter for News Items in <tab_name> tab by opening News Item
    #precondition
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_News_Item" with added unique Id as "newsTitle"
    Then User "COMPANY_ADMIN" <action> "News" with all fields and title "$newsTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User selects News option "companyContent|newsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User enters "$newsTitle" in Search Field "companyContent|searchField"
    And User clicks <tab_name> tab "companyContent|<selector>"
    Then News Item "companyContent|postNameCell" with text "$newsTitle" is displayed
    And Views Counter "companyContent|viewsCounterCell" text is equal to "0"
    When User clicks News Item "companyContent|contentLink" with text "$newsTitle"
    Then News Item "newsDetailsPage|title" with text "$newsTitle" is displayed
    And Views Counter "newsDetailsPage|headerViewsCount" text is equal to "1"
    When User clicks Back button "newsDetailsPage|backButton" by executing script
    And User selects News option "companyContent|newsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User enters "$newsTitle" in Search Field "companyContent|searchField"
    And User clicks <tab_name> tab "companyContent|<selector>"
    Then News Item "companyContent|postNameCell" with text "$newsTitle" is displayed
    And Views Counter "companyContent|viewsCounterCell" text is equal to "<number>"
    #postcondition
    And User deletes "News" with "Title" equal to "$newsTitle"
    Examples:
      |action      |tab_name        |selector            |number|
      |publishes   |Pending Approval|pendingApprovalTab  |0     |
      |saves Draft |Draft           |draftTab            |0     |

  @regression
  Scenario Outline: Company Admin verifies Views Counter for Events in <tab_name> tab by opening Event
    #precondition
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    Then User "COMPANY_ADMIN" publishes "Event" with all fields and title "$eventTitle" with API
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" <action> "Event" with title "$eventTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User selects Events option "companyContent|eventsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User enters "$eventTitle" in Search Field "companyContent|searchField"
    And User clicks <tab_name> tab "companyContent|<selector>"
    Then Event Title "companyContent|postNameCell" with text "$eventTitle" is displayed
    And Views Counter "companyContent|viewsCounterCell" text is equal to "0"
    When User clicks Event "companyContent|contentLink" with text "$eventTitle"
    Then Event Title "eventDetailsPage|title" with text "$eventTitle" is displayed
    When User clicks Back button "eventDetailsPage|backButton" by executing script
    And User selects Events option "companyContent|eventsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User enters "$eventTitle" in Search Field "companyContent|searchField"
    And User clicks <tab_name> tab "companyContent|<selector>"
    Then Event Title "companyContent|postNameCell" with text "$eventTitle" is displayed
    And Views Counter "companyContent|viewsCounterCell" text is equal to "<number>"
    #postcondition
    And User deletes "Event" with "Title" equal to "$eventTitle"
    Examples:
      |action  |tab_name          |selector            |number|
      |approves|Published         |publishedTab        |1     |
      |rejects |Rejected          |rejectedTab         |0     |

  @regression
  Scenario Outline: Company Admin verifies Views Counter for Events in <tab_name> tab by opening Event
    #precondition
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    Then User "COMPANY_ADMIN" <action> "Event" with all fields and title "$eventTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User selects Events option "companyContent|eventsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User enters "$eventTitle" in Search Field "companyContent|searchField"
    And User clicks <tab_name> tab "companyContent|<selector>"
    Then Event Title "companyContent|postNameCell" with text "$eventTitle" is displayed
    And Views Counter "companyContent|viewsCounterCell" text is equal to "0"
    When User clicks Event "companyContent|contentLink" with text "$eventTitle"
    Then Event Title "eventDetailsPage|title" with text "$eventTitle" is displayed
    When User clicks Back button "eventDetailsPage|backButton" by executing script
    And User selects Events option "companyContent|eventsOption" from Content Type dropdown "companyContent|contentTypeField"
    And User enters "$eventTitle" in Search Field "companyContent|searchField"
    And User clicks <tab_name> tab "companyContent|<selector>"
    Then Event Title "companyContent|postNameCell" with text "$eventTitle" is displayed
    And Views Counter "companyContent|viewsCounterCell" text is equal to "<number>"
    #postcondition
    And User deletes "Event" with "Title" equal to "$eventTitle"
    Examples:
      |action      |tab_name        |selector            |number|
      |publishes   |Pending Approval|pendingApprovalTab  |0     |
      |saves Draft |Draft           |draftTab            |0     |
@companyContentDownloads
@knwonIssue
@SRC-2136
Feature: Company Admin verifies Downloads counter on Company Content page

  @regression
  Scenario Outline: Company Admin verifies Downloads Counter for Researches in <tab_name> tab by clicking Download Full Report
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
    And Downloads Counter "companyContent|downloadsCell" text is equal to "0"
#    When User clicks Research Title "companyContent|contentLink" with text "$researchTitle"
#    Then Research Title "researchDetailsPage|title" with text "$researchTitle" is displayed
#    And User clicks Download Full Report "researchDetailsPage|downloadFullReportButton"
#    And User goes to 1 browser tab
#    When User clicks Back button "researchDetailsPage|backButton" by executing script
#    And User clicks <tab_name> tab "companyContent|<selector>"
#    And User enters "$researchTitle" in Search Field "companyContent|searchField"
    Then Post Name "companyContent|postNameCell" with text "$researchTitle" is displayed
    And Downloads Counter "companyContent|downloadsCell" text is equal to "<number>"
    #postcondition
    And User deletes "Research" with "Title" equal to "$researchTitle"
    Examples:
      |action  |tab_name          |selector            |number|
      |approves|Published         |publishedTab        |0     |
      |rejects |Rejected          |rejectedTab         |0     |

  @regression
  Scenario Outline: Company Admin verifies Downloads Counter for Researches in <tab_name> tab by clicking Download Full Report
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
    And Downloads Counter "companyContent|downloadsCell" text is equal to "0"
#    When User clicks Research Title "companyContent|contentLink" with text "$researchTitle"
#    Then Research Title "researchDetailsPage|title" with text "$researchTitle" is displayed
#    And User clicks Download Full Report "researchDetailsPage|downloadFullReportButton"
#    And User goes to 1 browser tab
#    When User clicks Back button "researchDetailsPage|backButton" by executing script
#    And User clicks <tab_name> tab "companyContent|<selector>"
#    And User enters "$researchTitle" in Search Field "companyContent|searchField"
    Then Post Name "companyContent|postNameCell" with text "$researchTitle" is displayed
    And Downloads Counter "companyContent|downloadsCell" with text "<number>" is displayed
    #postcondition
    And User deletes "Research" with "Title" equal to "$researchTitle"
    Examples:
      |action      |tab_name        |selector            |number|
      |publishes   |Pending Approval|pendingApprovalTab  |0     |
      |saves Draft |Draft           |draftTab            |0     |

  @regression
  Scenario Outline: Company Admin verifies Downloads Counter for Researches in <tab_name> tab by clicking Actions/Download
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
    And Downloads Counter "companyContent|downloadsCell" text is equal to "0"
#    When User clicks Actions button "companyContent|actionsButton"
#    And User clicks Download link "companyContent|downloadLink"
#    And User refreshes page
#    And User clicks <tab_name> tab "companyContent|<selector>"
#    And User enters "$researchTitle" in Search Field "companyContent|searchField"
    Then Post Name "companyContent|postNameCell" with text "$researchTitle" is displayed
    And Downloads Counter "companyContent|downloadsCell" text is equal to "<number>"
    #postcondition
    And User deletes "Research" with "Title" equal to "$researchTitle"
    Examples:
      |action  |tab_name          |selector            |number|
      |approves|Published         |publishedTab        |0     |
      |rejects |Rejected          |rejectedTab         |0     |

  @regression
  Scenario Outline: Company Admin verifies Downloads Counter for Researches in <tab_name> tab by clicking Actions/Download
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
    And Downloads Counter "companyContent|downloadsCell" text is equal to "0"
#    When User clicks Actions button "companyContent|actionsButton"
#    And User clicks Download link "companyContent|downloadLink"
#    And User refreshes page
#    And User clicks <tab_name> tab "companyContent|<selector>"
#    And User enters "$researchTitle" in Search Field "companyContent|searchField"
    Then Post Name "companyContent|postNameCell" with text "$researchTitle" is displayed
    And Downloads Counter "companyContent|downloadsCell" with text "<number>" is displayed
    #postcondition
    And User deletes "Research" with "Title" equal to "$researchTitle"
    Examples:
      |action      |tab_name        |selector            |number|
      |publishes   |Pending Approval|pendingApprovalTab  |0     |
      |saves Draft |Draft           |draftTab            |0     |

  @regression
  Scenario Outline: Company Admin verifies Downloads Counter for News Items in <tab_name> tab by clicking Download News Post
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
    And Downloads Counter "companyContent|downloadsCell" text is equal to "0"
#    When User clicks News Item "companyContent|contentLink" with text "$newsTitle"
#    Then News Item "newsDetailsPage|title" with text "$newsTitle" is displayed
#    And User clicks Download News Post "newsDetailsPage|downloadNewsPostButton"
#    And User goes to 1 browser tab
#    When User clicks Back button "newsDetailsPage|backButton" by executing script
#    And User selects News option "companyContent|newsOption" from Content Type dropdown "companyContent|contentTypeField"
#    And User enters "$newsTitle" in Search Field "companyContent|searchField"
#    And User clicks <tab_name> tab "companyContent|<selector>"
    Then News Item "companyContent|postNameCell" with text "$newsTitle" is displayed
    And Downloads Counter "companyContent|downloadsCell" text is equal to "<number>"
    #postcondition
    And User deletes "News" with "Title" equal to "$newsTitle"
    Examples:
      |action  |tab_name          |selector            |number|
      |approves|Published         |publishedTab        |0     |
      |rejects |Rejected          |rejectedTab         |0     |

  @regression
  Scenario Outline: Company Admin verifies Downloads Counter for News Items in <tab_name> tab by clicking Download News Post
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
    And Downloads Counter "companyContent|downloadsCell" text is equal to "0"
#    When User clicks News Item "companyContent|contentLink" with text "$newsTitle"
#    Then News Item "newsDetailsPage|title" with text "$newsTitle" is displayed
#    And User clicks Download News Post "newsDetailsPage|downloadNewsPostButton"
#    And User goes to 1 browser tab
#    When User clicks Back button "newsDetailsPage|backButton" by executing script
#    And User selects News option "companyContent|newsOption" from Content Type dropdown "companyContent|contentTypeField"
#    And User enters "$newsTitle" in Search Field "companyContent|searchField"
#    And User clicks <tab_name> tab "companyContent|<selector>"
    Then News Item "companyContent|postNameCell" with text "$newsTitle" is displayed
    And Downloads Counter "companyContent|downloadsCell" text is equal to "<number>"
    #postcondition
    And User deletes "News" with "Title" equal to "$newsTitle"
    Examples:
      |action      |tab_name        |selector            |number|
      |publishes   |Pending Approval|pendingApprovalTab  |0     |
      |saves Draft |Draft           |draftTab            |0     |

  @regression
  Scenario Outline: Company Admin verifies Downloads Counter for News Items in <tab_name> tab by clicking Actions/Download
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
    And Downloads Counter "companyContent|downloadsCell" text is equal to "0"
#    When User clicks Actions button "companyContent|actionsButton"
#    And User clicks Download link "companyContent|downloadLink"
#    And User refreshes page
#    And User selects News option "companyContent|newsOption" from Content Type dropdown "companyContent|contentTypeField"
#    And User enters "$newsTitle" in Search Field "companyContent|searchField"
#    And User clicks <tab_name> tab "companyContent|<selector>"
    Then News Item "companyContent|postNameCell" with text "$newsTitle" is displayed
    And Downloads Counter "companyContent|downloadsCell" text is equal to "<number>"
    #postcondition
    And User deletes "News" with "Title" equal to "$newsTitle"
    Examples:
      |action  |tab_name          |selector            |number|
      |approves|Published         |publishedTab        |0     |
      |rejects |Rejected          |rejectedTab         |0     |

  @regression
  Scenario Outline: Company Admin verifies Downloads Counter for News Items in <tab_name> tab by clicking Actions/Download
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
    And Downloads Counter "companyContent|downloadsCell" text is equal to "0"
#    When User clicks Actions button "companyContent|actionsButton"
#    And User clicks Download link "companyContent|downloadLink"
#    And User refreshes page
#    And User selects News option "companyContent|newsOption" from Content Type dropdown "companyContent|contentTypeField"
#    And User enters "$newsTitle" in Search Field "companyContent|searchField"
#    And User clicks <tab_name> tab "companyContent|<selector>"
    Then News Item "companyContent|postNameCell" with text "$newsTitle" is displayed
    And Downloads Counter "companyContent|downloadsCell" text is equal to "<number>"
    #postcondition
    And User deletes "News" with "Title" equal to "$newsTitle"
    Examples:
      |action      |tab_name        |selector            |number|
      |publishes   |Pending Approval|pendingApprovalTab  |0     |
      |saves Draft |Draft           |draftTab            |0     |
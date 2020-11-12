Feature: Company Admin verifies Company Featured Token

  Background:
#    Egle:2020-09-08 Need use COMPANY_ADMIN user to remove all tokens, with GLOBAL_ADMIN user is not working
#    Given User "GLOBAL_ADMIN" logs in with API
#    And User "GLOBAL_ADMIN" removes "ALL" Company Featured Tokens from Company Researches with API
    Given User "COMPANY_ADMIN" logs in with API
    And User "COMPANY_ADMIN" removes "ALL" Company Featured Tokens from Company Researches with API

  @regression
  Scenario: Company Admin sets and removes Featured token
    #precondition
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    And User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle" with API
    And User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User enters "$researchTitle" in Search Field "companyContent|searchField"
    And Remaining Tokens "companyContent|remainingTokensText" text is equal to "1"
    When User clicks Featured Icon "companyContent|featuredIcon"
    And User waits 2 seconds
    Then Remaining Tokens "companyContent|remainingTokensText" text is equal to "0"
    When User clicks Featured Icon "companyContent|featuredIcon"
    And User waits 2 seconds
    Then Remaining Tokens "companyContent|remainingTokensText" text is equal to "1"
    #postcondition
    And User deletes "Research" with "Title" equal to "$researchTitle"

  @regression
  Scenario: Company Admin tries to set more Featured Tokens than his Company has
    #precondition
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle_1"
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle_2"
    And User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle_1" with API
    And User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle_2" with API
    And User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle_1" with API
    And User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle_2" with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User enters "$researchTitle_1" in Search Field "companyContent|searchField"
    And Remaining Tokens "companyContent|remainingTokensText" text is equal to "1"
    When User clicks Featured Icon "companyContent|featuredIcon"
    And User waits 2 seconds
    Then Remaining Tokens "companyContent|remainingTokensText" text is equal to "0"
    And User clears text from Search Field "companyContent|searchField"
    And User enters "$researchTitle_2" in Search Field "companyContent|searchField"
    When User clicks Featured Icon "companyContent|featuredIcon"
    Then Error toast "toast|toastMessage" with text "Featured articles limit reached." is displayed
    #postcondition
    And User clears text from Search Field "companyContent|searchField"
    And User enters "$researchTitle_1" in Search Field "companyContent|searchField"
    When User clicks Featured Icon "companyContent|featuredIcon"
    And User waits 2 seconds
    Then Remaining Tokens "companyContent|remainingTokensText" text is equal to "1"
    And User deletes "Research" with "Title" equal to "$researchTitle_1"
    And User deletes "Research" with "Title" equal to "$researchTitle_2"

  @regression
  Scenario: Company Admin tries to set Featured Token to more than 30 days old Research
    #precondition
    When User "COMPANY_ADMIN" logs in with API
    And User remembers current date "minus" "30 Days, 1 minutes" as "publishDate"
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_ADMIN" publishes "research" with title "$researchTitle" and publish date "$publishDate" with API
    And User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API
#    Egle:2020-09-08 Need use COMPANY_ADMIN user to remove all tokens, with GLOBAL_ADMIN user is not working
#    And User "GLOBAL_ADMIN" removes "ALL" Company Featured Tokens from Company Researches with API
    And User "COMPANY_ADMIN" removes "ALL" Company Featured Tokens from Company Researches with API
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User enters "$researchTitle" in Search Field "companyContent|searchField"
    And Remaining Tokens "companyContent|remainingTokensText" text is equal to "1"
    When User clicks Featured Icon "companyContent|featuredIcon"
    Then Error toast "toast|toastMessage" with text "Only items published in the past 30 days can be featured." is displayed
    #postcondition
    And User deletes "Research" with "Title" equal to "$researchTitle"
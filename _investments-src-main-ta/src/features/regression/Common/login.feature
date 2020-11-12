@login
Feature: Login with valid credentials

  @smoke
  @regression
  Scenario: Verify login work
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    Then Page URL is equal to "HOME_PAGE"


  @regression
  Scenario: Check API login
    When User "COMPANY_ADMIN" logs in with API
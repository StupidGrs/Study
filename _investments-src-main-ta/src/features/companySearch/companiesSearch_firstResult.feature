@companySearchAll
Feature: Verify Company search with API - search by Full Company Name and check the first result

    Scenario: Full Name - First Result
        When User "COMPANY_ADMIN" logs in with API
        Then User "COMPANY_ADMIN" performs Company search by Full Company Name and checks the first 1 result - test "ALL" companies
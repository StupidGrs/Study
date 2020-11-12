@companySearchAll
Feature: Verify Company search with API - search by First 2 words from Company Name and check first 14 results

    Scenario: First 2 Words - 14 Results
        When User "COMPANY_ADMIN" logs in with API
        Then User "COMPANY_ADMIN" performs Company search by First 2 words from Company Name and checks first 14 results - test "ALL" companies
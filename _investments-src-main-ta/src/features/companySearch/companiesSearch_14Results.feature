@companySearchAll
Feature: Verify Company search with API - search by Full Company Name and check first 14 results
    
    Scenario: Full Name - 14 Results
        When User "COMPANY_ADMIN" logs in with API
        Then User "COMPANY_ADMIN" performs Company search by Full Company Name and checks the first 14 results - test "ALL" companies
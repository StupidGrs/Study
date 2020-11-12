@companySearch
Feature: Verify Company search with API

    Background:
        Given User "COMPANY_ADMIN" logs in with API

    @regression
    Scenario: Full Name - First Result
        Then User "COMPANY_ADMIN" performs Company search by Full Company Name and checks the first 1 result - test "50" companies

    @regression
    Scenario: Full Name - 14 Results
        Then User "COMPANY_ADMIN" performs Company search by Full Company Name and checks the first 14 results - test "50" companies

    @regression
    Scenario: First Word - 14 Results
        Then User "COMPANY_ADMIN" performs Company search by First 1 word from Company Name and checks first 14 results - test "50" companies

    @regression
    Scenario: First 2 Words - 14 Results
        Then User "COMPANY_ADMIN" performs Company search by First 2 words from Company Name and checks first 14 results - test "50" companies




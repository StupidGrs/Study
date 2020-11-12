Feature: Test API

  Scenario: Verify framework API test steps by getting list of elements
    When User sends "deleteCountryFeature1" API request
    Given User sends "countries" API request
    Then User remembers response property "$.._id" as "firstCountryId_feature1"
    Then Status Code is "200"
      And Response "responseText" is an "object"
      And Response "responseText.documents" is an "Array"
      And Response "responseText.documents" size is "greater than" "0"
      And Response "responseText.RestResponse.result" contains:
        | name               |
        | alpha2_code        |
        | alpha3_code        |
      And Response "every property" "name" in "responseText.RestResponse.result" is an "String"
      And Response "every property" "alpha2_code" in "responseText.RestResponse.result" is an "String"
      And Response "every property" "alpha3_code" in "responseText.RestResponse.result" is an "String"

  Scenario: Verify framework API test steps by getting one element
    Given User sends "renameCountryFeature1" API request
    Then Status Code is "200"
      And Response "property" "alpha3_code" in "responseText.RestResponse.result" is an "String"
      And Response "property" "name" in "responseText.RestResponse.result" is "equal to" "India"
    When User sends "deleteCountryFeature1" API request
    Then Status Code is "200"
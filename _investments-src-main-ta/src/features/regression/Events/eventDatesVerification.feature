@eventDatesFormat
Feature: Verify Event Date formats on the Event Details Page in the Header

  @regression
  Scenario Outline: Verify Dates format with <datesDescription>
    When User "GLOBAL_ADMIN" logs in with API
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    And User "GLOBAL_ADMIN" publishes Event with title "$eventTitle" and Start Date "<startDate> 4:10 AM" and End Date "<endDate> 5:10 PM" with API
    Then User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And Events Tab "navigation|eventsTab" is displayed
    And User navigates to "Event" URL with title "$eventTitle"
#    And Event Date in the Header details "eventDetailsPage|dateTimeHeader" contains Start Date "<startDate>" and Time "4:10 AM" and End Date "<endDate>" and Time "5:10 PM" in short format with GMT offset
#    Egle:2020-09-10 Need update script, because time zone is GTM +2
    And Event Date in the Header details "eventDetailsPage|dateTimeHeader" contains Start Date "<startDate>" and Time "4:10 AM" and End Date "<endDate>" and Time "5:10 PM" in short format with GMT +02:00
    And User deletes "Event" with "Title" equal to "$eventTitle"
    Examples:
      | datesDescription                      | startDate | endDate   |
      | Different Years                       | 1/20/2020 | 1/20/2021 |
      | Same Year, Different Month            | 1/20/2020 | 2/20/2020 |
      | Same Year, Same Month, Different Days | 1/20/2020 | 1/22/2020 |
      | Same Year, Same Month, Same Day       | 1/20/2020 | 1/20/2020 |

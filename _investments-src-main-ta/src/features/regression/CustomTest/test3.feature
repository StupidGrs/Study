@customTest
@regression
Feature: Create Event with required fields only

    Scenario Outline: Create Event with specified Title - <test>
        When User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
        Then User "COMPANY_ADMIN" publishes "Event" with title "$eventTitle" with API
        And User deletes "Events" with "Title" equal to "$eventTitle"
        Examples:
            | test |
            | 1    |
            | 2    |
            | 3    |
            | 4    |
            | 5    |
            | 6    |
            | 7    |
            | 8    |
            | 9    |
            | 10   |
            | 11   |
            | 12   |
            | 13   |
            | 14   |
            | 15   |
            | 16   |
            | 17   |
            | 18   |
            | 19   |
            | 20   |
            # | 21   |
            # | 22   |
            # | 23   |
            # | 24   |
            # | 25   |
            # | 26   |
            # | 27   |
            # | 28   |
            # | 29   |
            # | 30   |
            # | 31   |
            # | 32   |
            # | 33   |
            # | 34   |
            # | 35   |
            # | 36   |
            # | 37   |
            # | 38   |
            # | 39   |
            # | 40   |
            # | 41   |
            # | 42   |
            # | 43   |
            # | 44   |
            # | 45   |
            # | 46   |
            # | 47   |
            # | 48   |
            # | 49   |
            # | 50   |
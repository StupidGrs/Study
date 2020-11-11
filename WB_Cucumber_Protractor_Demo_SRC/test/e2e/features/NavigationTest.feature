Feature: Navigation Test

  Background:
    Given User logs in as 'glob.admin@src.mercer.com'

  Scenario: User navigates to Events Page
    When User clicks tab "Events"
    Then "Events" page displays with header 'Upcoming Events'


  Scenario Outline: User navigates to <tab> page
    When User clicks tab '<tab>'
    Then '<tab>' page displays with header '<header>'

    Examples:
    |tab      |header         |
    |Events   |Upcoming Events|
    |Research |Research       |
    |News     |News           |
    |TestErr  |TestErr        |




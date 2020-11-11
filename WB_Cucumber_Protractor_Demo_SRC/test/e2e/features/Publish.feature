Feature: Publish Event/Research/News

  Background:
    Given User logs in as 'glob.admin@src.mercer.com'

  Scenario Outline: User publish <type>
    When User clicks publish -> '<type>'
    And User fills in the basic info '<name>', '<excerpt>', '<url>', '<content>'
    And User fills in the Company, EventType, Location info '<company>', '<eventType>', '<location>'
    And User fills in Start Date and Start Time '', '<startTime>'
    And User fills in End Date and End Time '', '<endTime>'
    And User fills in Taxonomy and Tags '<taxonomy>', '<tag>'
    And User uploads featured image '<image>'
    And User selects regions '<region>'
    And User sleeps 5 seconds


    Examples:
    |type   |name     |excerpt    |url              |content    |company  |eventType|location       |startTime  |endTime  |taxonomy   |tag  |image                      |region |
    |Event  |0_Event  |0_excerpt  |https://test.com |0_content  |CompAuto |Webinar  |Shanghai, Chin |11:00 AM   |10:00 PM |Real Estate|Team |../data/in/Test_Image.jpg  |Asia   |





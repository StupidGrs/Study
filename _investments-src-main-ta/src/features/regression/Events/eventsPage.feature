@events
@eventsPage
Feature: Verify events page elements

  @smoke
  @regression
  Scenario: Verify events page main labels
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "navigation|horizontalNavigationMenuItemsList" with text "Events"
    Then Main Article Title "eventsPage|mercerArticlesListHeaderTitle" with text "Upcoming Events" is displayed
    Then Label "eventsPage|filtersListIconText" with text "Filter" is displayed
    Then Label "eventsPage|topEventsLabel" with text "Popular Events" is displayed

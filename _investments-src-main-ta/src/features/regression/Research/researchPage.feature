@researchPage
@research
Feature: Verify research page elements

  @smoke
  @regression
  Scenario: Verify research page main labels
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "navigation|horizontalNavigationMenuItemsList" with text "Research"
    Then Main Article Title "researchPage|articlesPageSubheaderTitleLabel" with text "Research" is displayed
    Then Label "researchPage|filtersListIconText" with text "Filter" is displayed
    Then Label "researchPage|popularArticlesHeader" with text "Popular Research" is displayed
    Then Button "button" with text "Load more" is displayed
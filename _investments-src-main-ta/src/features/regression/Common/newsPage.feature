@newsPage
Feature: Verify news page elements

  @smoke
  @regression
  Scenario: Verify news page main labels
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "navigation|horizontalNavigationMenuItemsList" with text "News"
    Then Title "newsPage|articlesPageSubheaderTitleLabel" with text "News" is displayed
    Then Label "newsPage|filtersListIconText" with text "Filter" is displayed
    Then Label "newsPage|popularArticlesHeader" with text "Popular News" is displayed
    Then Button "button" with text "Load more" is displayed

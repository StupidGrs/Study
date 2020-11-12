@directoriesPage
Feature: Verify directories page main functionality

  @smoke
  @regression
  Scenario: Verify directories page main labels
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "navigation|horizontalNavigationMenuItemsList" with text "Directories"
    Then Main Article Title "directoriesPage|mercerArticlesListHeaderTitle" with text "Directories" is displayed
    Then Attribute "placeholder" of Search Field "directoriesPage|searchField" is equal to "Search Members"
    And Directories header "directoriesPage|copy" text is equal to "Follow the posts and activity of SRC Users and Companies "


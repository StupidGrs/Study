@homePage
Feature: Verify home page main section

  @smoke
  @regression
  Scenario: Verify home page main labels
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    #Dashboard home page has dynamic content and main (featured) article may be missing
    #Then Main Article Title "homePage|mainArticleTitle" is not empty
    And Title "homePage|trendingNewsAndBlogsSectionLabel" with text "Trending News & Blogs" is displayed
    And Title "homePage|topNewsAndBlogsSectionLabel" with text "Top News & Blogs" is displayed
    And Title "homePage|trendingResearchSectionLabel" with text "Trending Research" is displayed
    And Label "homePage|topResearchSectionLabel" with text "Top Research" is displayed
    And Label "homePage|upcomingEventsSectionLabel" with text "Upcoming Events" is displayed
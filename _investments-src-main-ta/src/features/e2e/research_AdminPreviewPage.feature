@e2e
Feature: Global Admin clicks [Save and Preview] button on Moderate Research page and verifies all elements on Preview Research page

  Scenario: Global Admin clicks [Save and Preview] button on Moderate Research page and verifies:
    Given User "COMPANY_ADMIN" logs in with API
    When User remembers text "Test_Auto_Research_Admin_Preview" with added unique Id as "researchTitle"
    And User "COMPANY_ADMIN" publishes "Research" with all fields and title "$researchTitle" with API
    And User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Moderate Content link "header|moderateContentLink" by executing script
    And User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
    When User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
    Then Table Row "contentListPage|tableRowsList" with text "$researchTitle" is displayed
    And User clicks Title "contentListPage|titleList" on Table Row "contentListPage|tableRowsList" with text "$researchTitle"
    And User scrolls page to top
    When User clicks [Save and Preview] button "moderateResearchPage|saveAndPreviewButton"

  Scenario: Success toast
    Then User waits for toast message "toast|toastMessage" with text "Item was successfully updated." visibility within 5 seconds

  Scenario: Title text
    And Element "researchDetailsPage|title" is displayed
    And Element "researchDetailsPage|title" text is equal to "$researchTitle"

  Scenario Outline: <element> text
    And Element "researchDetailsPage|<element>" is displayed
    And Element "researchDetailsPage|<element>" text is equal to "<text>"
    Examples:
      | element           | text                        |
      | excerpt           | Test_Auto Executive Summary |
      | researchType      | Speech                      |
      | headerCompanyName | CompAuto                    |
      | headerReadTime    | 10 min read                 |
      | content           | Test_Auto Research Content  |

  Scenario: Company Logo in the Header
    And Research Header Company Logo "researchDetailsPage|headerCompanyLogoIcon" is displayed

  #TODO
  #Add method to remember selected date and calculate "ago" time to check "articleHeaderDate" exact value
  Scenario: Date in the Header
    And Research Header Date "researchDetailsPage|headerDate" is displayed

  Scenario: Video
    And Video "researchDetailsPage|videoIframe" is displayed
    And Attribute "src" of Video "researchDetailsPage|videoIframe" is equal to "https://www.youtube.com/embed/W6NZfCO5SIk"
    And Video Error "researchDetailsPage|videoError" is not displayed in iframe "researchDetailsPage|videoIframe"

  Scenario: [Visit External Link] button
    And [Visit External Link] button "researchDetailsPage|visitExternalLinkButton" is displayed
    And Attribute "href" of [Visit External Link] button "researchDetailsPage|visitExternalLinkButton" is equal to "https://www.wikipedia.org/"

  Scenario: [Download the full report] button
    And [Download the full report] button "researchDetailsPage|downloadFullReportButton" is displayed
    And Attribute "href" of [Download the full report] button "researchDetailsPage|downloadFullReportButton" contains ".pdf"

  Scenario: Tags in the Footer
    And Tags List "researchDetailsPage|footerTagsList" count is equal to 1
    And Tags List "researchDetailsPage|footerTagsList" text is equal to "Investing"

  Scenario Outline: Views And Stars Section in the header: <elementDescription>
    And <elementDescription> "researchDetailsPage|<element>" is displayed
    Examples:
      | elementDescription      | element                    |
      | Views And Stars Section | headerViewsAndStarsSection |
      | Views Icon              | headerViewsIcon            |
      | Views Count value       | headerViewsCount           |
      | Rating Stars Icons Set  | headerRatingStarsIconsSet  |
      | Rating Count value      | headerRatingCount          |

  Scenario: Left block elements
    And Left Block "researchDetailsPage|leftBlock" is displayed
    And Company Name "researchDetailsPage|leftBlockCompanyName" text is equal to "CompAuto"
    And Followers number "researchDetailsPage|leftBlockCompanyFollowers" is displayed
    And Followers number "researchDetailsPage|leftBlockCompanyFollowers" contains "followers" text
    And Follow button "researchDetailsPage|leftBlockFollowButton" is enabled
    And Follow button "researchDetailsPage|leftBlockFollowButton" text is equal to "FOLLOW"
    And Star Icon "researchDetailsPage|leftBlockRateThisStarIcon" is displayed
    And Rate This "researchDetailsPage|leftBlockRateThisText" text is equal to "Rate This"
    And Bookmark Icon "researchDetailsPage|leftBlockBookmarkIcon" is displayed
    And Download Attachment Icon "researchDetailsPage|leftBlockDownloadAttachIcon" is displayed
    And Attribute "href" of Download Attachment link "researchDetailsPage|leftBlockDownloadAttachLink" contains ".pdf"

  Scenario: Disclaimer
    And Disclaimer Label "researchDetailsPage|disclaimerLabel" text is equal to "Disclaimer"
    And Disclaimer Text "researchDetailsPage|disclaimerText" is displayed

  Scenario: Rate This elements in the Footer
    And Star Icon "researchDetailsPage|footerRateThisStarIcon" is displayed
    And Rate This "researchDetailsPage|footerRateThisText" text is equal to "Rate This"
    And Rating Stars Set "researchDetailsPage|footerRatingStarsIconsSet" is displayed
    And Rating Count "researchDetailsPage|footerRatingCount" is displayed

  Scenario: Author elements in the Footer
    And Company Logo "researchDetailsPage|authorCompanyLogo" is displayed
    And Company Name "researchDetailsPage|authorCompanyName" text is equal to "CompAuto"
    And Followers number "researchDetailsPage|authorCompanyFollowers" is displayed
    And Followers number "researchDetailsPage|authorCompanyFollowers" contains "followers" text
    And Follow button "researchDetailsPage|authorFollowButton" is enabled
    And Follow button "researchDetailsPage|authorFollowButton" text is equal to "FOLLOW"

  Scenario: Related Researches section
    And Related Researches section "researchDetailsPage|relatedSection" is displayed
    And Related Researches Header Title "researchDetailsPage|relatedSectionHeader" text is equal to "Related Research"
    And Explore Research link "researchDetailsPage|relatedSectionExploreLink" contains "Explore Research" text
    And Attribute "href" of [Explore Research] link "researchDetailsPage|relatedSectionExploreLink" contains "/research"
    And Explore Research link icon "researchDetailsPage|relatedSectionExploreLinkIcon" is displayed
    And Related Articles List "researchDetailsPage|relatedArticlesList" is displayed

  Scenario Outline: Each Related Research contains: <elementDescription>
    And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains <elementDescription> "researchDetailsPage|<element>"
    Examples:
      | elementDescription | element                                |
      | Title              | relatedArticlesTitlesList              |
      | Type               | relatedArticlesTypesList               |
      #| Excerpt            | relatedArticlesExcerptList             |
      | Company Logo       | relatedArticlesCompanyLogoIcons        |
      | Company Name       | relatedArticlesCompanyNamesList        |
      | Date               | relatedArticlesDatesList               |
      | Views icon         | relatedArticlesViewsIconsList          |
      | Views value        | relatedArticlesViewsCountList          |
      | Stars Icons Set    | relatedArticlesRatingStarsIconsSetList |
      | Rating value       | relatedArticlesRatingCountList         |
      | Bookmark           | relatedArticlesBookmarkIconsList       |
      | Image              | relatedArticlesImagesList              |

  Scenario: User logs out
    When User navigates to "HOME_PAGE"
    Then User clicks Profile Button "header|profileButton"
    And User clicks Profile Menu Item "header|profileMenuItemsList" with text "Logout"

  Scenario: Delete submitted research
    When User "GLOBAL_ADMIN" logs in with API
    And User deletes "Research" with "Title" equal to "$researchTitle"
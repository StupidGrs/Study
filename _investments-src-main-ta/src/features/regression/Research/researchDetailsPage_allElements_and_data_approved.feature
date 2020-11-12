@research
@researchDetails
Feature: Verify elements and data on Research Details Page - Approved

    @regression
    @knownIssue @SRC-1369
    Scenario: Verify Details page of Approved Research with all fields
        #Create research with all fields
        When User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
        Then User "COMPANY_ADMIN" publishes "Research" with all fields and title "$researchTitle" with API
        #Approve research
        When User "GLOBAL_ADMIN" logs in with API
        Then User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API
        #Login and open research
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User navigates to "Research" URL with title "$researchTitle"
        #Verify Header elements
        Then Research Title "researchDetailsPage|title" text is equal to "$researchTitle"
        And Research Exceprt "researchDetailsPage|excerpt" text is equal to "Test_Auto Executive Summary"
        And Research Type "researchDetailsPage|researchType" text is equal to "Speech"
        And Research Header Company Logo "researchDetailsPage|headerCompanyLogoIcon" is displayed
        And Research Header Company Name "researchDetailsPage|headerCompanyName" text is equal to "CompAuto"
        And Research Header Read Time "researchDetailsPage|headerReadTime" text is equal to "10 min read"
        And [Back] button "researchDetailsPage|backButton" is displayed
        #Verify Images
        And Research Header Background Image "researchDetailsPage|headerBackgroundImage" is displayed
#        And Attribute "style" of Research Header Background Image "researchDetailsPage|headerBackgroundImage" does not contain "default-feature-image.png"
        And Research Featured Image "researchDetailsPage|headerFeaturedImage" is displayed
#        And Attribute "style" of Research Featured Image "researchDetailsPage|headerFeaturedImage" does not contain "default-feature-image.png"
#        And User compares screenshot of Featured Image "researchDetailsPage|headerFeaturedImage" to "researchDetails_featuredImage.png"
        #TODO
        #Add method to remember selected date and calculate "ago" time to check "articleHeaderDate" exact value
        And Research Header Date "researchDetailsPage|headerDate" is displayed
        And Research Header Date "researchDetailsPage|headerDate" contains "ago" text
        And Research Content "researchDetailsPage|content" text is equal to "Test_Auto Content"
        And Video "researchDetailsPage|videoIframe" is displayed
        And Attribute "src" of Video Link "researchDetailsPage|videoIframe" is equal to "https://www.youtube.com/embed/W6NZfCO5SIk"
        # And Video Error "researchDetailsPage|videoError" is not displayed in iframe "researchDetailsPage|videoIframe"
        And [Visit External Link] button "researchDetailsPage|visitExternalLinkButton" is displayed
        And Attribute "href" of [Visit External Link] button "researchDetailsPage|visitExternalLinkButton" is equal to "https://www.wikipedia.org/"
#        And [Download the full report] button "researchDetailsPage|downloadFullReportButton" is displayed
#        And Attribute "href" of [Download the full report] button "researchDetailsPage|downloadFullReportButton" contains ".pdf"
        And Tags List "researchDetailsPage|footerTagsList" count is equal to 1
        And Tags List "researchDetailsPage|footerTagsList" text is equal to "Investing"
        # Views And Stars Section in the header
        And Views And Stars Section "researchDetailsPage|headerViewsAndStarsSection" is displayed
        And Views Icon "researchDetailsPage|headerViewsIcon" is displayed
        And Views Count "researchDetailsPage|headerViewsCount" is displayed
        And Rating Stars Set "researchDetailsPage|headerRatingStarsIconsSet" is displayed
        And Rating Stars "researchDetailsPage|headerRatingStarsIconsList" count is equal to 5
        And Rating Count "researchDetailsPage|headerRatingCount" is displayed
        # Left block elements
        And Left Block "researchDetailsPage|leftBlock" is displayed
        And Company Name "researchDetailsPage|leftBlockCompanyName" text is equal to "CompAuto"
        And Followers number "researchDetailsPage|leftBlockCompanyFollowers" is displayed
        And Followers number "researchDetailsPage|leftBlockCompanyFollowers" contains "followers" text
        And Follow button "researchDetailsPage|leftBlockFollowButton" is enabled
        And Follow button "researchDetailsPage|leftBlockFollowButton" text is equal to "FOLLOW"
        And Star Icon "researchDetailsPage|leftBlockRateThisStarIcon" is displayed
        And Rate This "researchDetailsPage|leftBlockRateThisText" text is equal to "Rate This"
        And Bookmark Icon "researchDetailsPage|leftBlockBookmarkIcon" is displayed
#        And Download Attachment Icon "researchDetailsPage|leftBlockDownloadAttachIcon" is displayed
#        And Attribute "href" of Download Attachment link "researchDetailsPage|leftBlockDownloadAttachLink" contains ".pdf"
        # Disclaimer
        And Disclaimer Label "researchDetailsPage|disclaimerLabel" text is equal to "Disclaimer"
        And Disclaimer Text "researchDetailsPage|disclaimerText" is displayed
        # Rate This elements in the footer
        And Star Icon "researchDetailsPage|footerRateThisStarIcon" is displayed
        And Rate This "researchDetailsPage|footerRateThisText" text is equal to "Rate This"
        And Rating Stars Set "researchDetailsPage|footerRatingStarsIconsSet" is displayed
        And Rating Stars "researchDetailsPage|footerRatingStarsIconsList" count is equal to 5
        And Rating Count "researchDetailsPage|footerRatingCount" is displayed
        # Author elements in the footer
        And Company Logo "researchDetailsPage|authorCompanyLogo" is displayed
        And Company Name "researchDetailsPage|authorCompanyName" text is equal to "CompAuto"
        And Followers number "researchDetailsPage|authorCompanyFollowers" is displayed
        And Followers number "researchDetailsPage|authorCompanyFollowers" contains "followers" text
        And Follow button "researchDetailsPage|authorFollowButton" is enabled
        And Follow button "researchDetailsPage|authorFollowButton" text is equal to "FOLLOW"
        # Related Researches section
        And Related Researches section "researchDetailsPage|relatedSection" is displayed
        And Related Researches Header Title "researchDetailsPage|relatedSectionHeader" text is equal to "Related Research"
        And Explore Research link "researchDetailsPage|relatedSectionExploreLink" contains "Explore Research" text
        And Attribute "href" of [Explore Research] link "researchDetailsPage|relatedSectionExploreLink" contains "/research"
        And Explore Research link icon "researchDetailsPage|relatedSectionExploreLinkIcon" is displayed
        And Related Articles List "researchDetailsPage|relatedArticlesList" is displayed
        And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Title "researchDetailsPage|relatedArticlesTitlesList"
        And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Type "researchDetailsPage|relatedArticlesTypesList"
        # And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Excerpt "researchDetailsPage|relatedArticlesExcerptList"
       #     "2020-09-01 Egle: Remove Company Logo"
        # And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Company Logo "researchDetailsPage|relatedArticlesCompanyLogoIcons"
        And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Company Name "researchDetailsPage|relatedArticlesCompanyNamesList"
        And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Date "researchDetailsPage|relatedArticlesDatesList"
        And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Views icon "researchDetailsPage|relatedArticlesViewsIconsList"
        And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Views value "researchDetailsPage|relatedArticlesViewsCountList"
        And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Stars Icons Set "researchDetailsPage|relatedArticlesRatingStarsIconsSetList"
        And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Rating value "researchDetailsPage|relatedArticlesRatingCountList"
        And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Bookmark "researchDetailsPage|relatedArticlesBookmarkIconsList"
        And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Image "researchDetailsPage|relatedArticlesImagesList"
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @regression
    Scenario: Verify Detials page of Approved Research with required fields only
        #Create research with required fields
        When User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
        Then User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle" with API
        #Approve research
        When User "GLOBAL_ADMIN" logs in with API
        Then User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API
        #Login and open research
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User navigates to "Research" URL with title "$researchTitle"
        #Verify Header elements
        Then Research Title "researchDetailsPage|title" text is equal to "$researchTitle"
        And Research Exceprt "researchDetailsPage|excerpt" text is equal to "Test_Auto Executive Summary"
        And Research Type "researchDetailsPage|researchType" text is equal to "Speech"
        And Research Header Company Logo "researchDetailsPage|headerCompanyLogoIcon" is displayed
        And Research Header Company Name "researchDetailsPage|headerCompanyName" text is equal to "CompAuto"
        And Research Header Read Time "researchDetailsPage|headerReadTime" is not displayed
        And [Back] button "researchDetailsPage|backButton" is displayed
        #Verify Images
        And Research Header Background Image "researchDetailsPage|headerBackgroundImage" is displayed
        And Attribute "style" of Research Header Background Image "researchDetailsPage|headerBackgroundImage" contains "default-feature-image.png"
        And Research Featured Image "researchDetailsPage|headerFeaturedImage" is displayed
        And Attribute "style" of Research Featured Image "researchDetailsPage|headerFeaturedImage" contains "default-feature-image.png"
        And User compares screenshot of Featured Image "researchDetailsPage|headerFeaturedImage" to "researchDetails_featuredImage_default.png"
        #TODO
        #Add method to remember selected date and calculate "ago" time to check "articleHeaderDate" exact value
        And Research Header Date "researchDetailsPage|headerDate" is displayed
        And Research Header Date "researchDetailsPage|headerDate" contains "ago" text
        And Research Content "researchDetailsPage|content" text is equal to "Test_Auto Content"
        And Video "researchDetailsPage|videoIframe" is not displayed
        And [Visit External Link] button "researchDetailsPage|visitExternalLinkButton" is displayed
        And Attribute "href" of [Visit External Link] button "researchDetailsPage|visitExternalLinkButton" is equal to "https://www.wikipedia.org/"
        And Tags List "researchDetailsPage|footerTagsList" is not displayed
        # Views And Stars Section in the header
        And Views And Stars Section "researchDetailsPage|headerViewsAndStarsSection" is displayed
        And Views Icon "researchDetailsPage|headerViewsIcon" is displayed
        And Views Count "researchDetailsPage|headerViewsCount" is displayed
        And Rating Stars Set "researchDetailsPage|headerRatingStarsIconsSet" is displayed
        And Rating Stars "researchDetailsPage|headerRatingStarsIconsList" count is equal to 5
        And Rating Count "researchDetailsPage|headerRatingCount" is displayed
        # Left block elements
        And Left Block "researchDetailsPage|leftBlock" is displayed
        And Company Name "researchDetailsPage|leftBlockCompanyName" text is equal to "CompAuto"
        And Followers number "researchDetailsPage|leftBlockCompanyFollowers" is displayed
        And Followers number "researchDetailsPage|leftBlockCompanyFollowers" contains "followers" text
        And Follow button "researchDetailsPage|leftBlockFollowButton" is enabled
        And Follow button "researchDetailsPage|leftBlockFollowButton" text is equal to "FOLLOW"
        And Star Icon "researchDetailsPage|leftBlockRateThisStarIcon" is displayed
        And Rate This "researchDetailsPage|leftBlockRateThisText" text is equal to "Rate This"
        And Bookmark Icon "researchDetailsPage|leftBlockBookmarkIcon" is displayed
        And Download Attachment Icon "researchDetailsPage|leftBlockDownloadAttachIcon" is not displayed
        # Disclaimer
        And Disclaimer Label "researchDetailsPage|disclaimerLabel" text is equal to "Disclaimer"
        And Disclaimer Text "researchDetailsPage|disclaimerText" is displayed
        # Rate This elements in the footer
        And Star Icon "researchDetailsPage|footerRateThisStarIcon" is displayed
        And Rate This "researchDetailsPage|footerRateThisText" text is equal to "Rate This"
        And Rating Stars Set "researchDetailsPage|footerRatingStarsIconsSet" is displayed
        And Rating Stars "researchDetailsPage|footerRatingStarsIconsList" count is equal to 5
        And Rating Count "researchDetailsPage|footerRatingCount" is displayed
        # Author elements in the footer
        And Company Logo "researchDetailsPage|authorCompanyLogo" is displayed
        And Company Name "researchDetailsPage|authorCompanyName" text is equal to "CompAuto"
        And Followers number "researchDetailsPage|authorCompanyFollowers" is displayed
        And Followers number "researchDetailsPage|authorCompanyFollowers" contains "followers" text
        And Follow button "researchDetailsPage|authorFollowButton" is enabled
        And Follow button "researchDetailsPage|authorFollowButton" text is equal to "FOLLOW"
        # Related Researches section
        And Related Researches section "researchDetailsPage|relatedSection" is displayed
        And Related Researches Header Title "researchDetailsPage|relatedSectionHeader" text is equal to "Related Research"
        And Explore Research link "researchDetailsPage|relatedSectionExploreLink" contains "Explore Research" text
        And Attribute "href" of [Explore Research] link "researchDetailsPage|relatedSectionExploreLink" contains "/research"
        And Explore Research link icon "researchDetailsPage|relatedSectionExploreLinkIcon" is displayed
        And Related Articles List "researchDetailsPage|relatedArticlesList" is displayed
        And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Title "researchDetailsPage|relatedArticlesTitlesList"
        And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Type "researchDetailsPage|relatedArticlesTypesList"
        # And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Excerpt "researchDetailsPage|relatedArticlesExcerptList"
        #     "2020-09-01 Egle: Remove Company Logo"
        # And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Company Logo "researchDetailsPage|relatedArticlesCompanyLogoIcons"
        And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Company Name "researchDetailsPage|relatedArticlesCompanyNamesList"
        And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Date "researchDetailsPage|relatedArticlesDatesList"
        And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Views icon "researchDetailsPage|relatedArticlesViewsIconsList"
        And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Views value "researchDetailsPage|relatedArticlesViewsCountList"
        And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Stars Icons Set "researchDetailsPage|relatedArticlesRatingStarsIconsSetList"
        And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Rating value "researchDetailsPage|relatedArticlesRatingCountList"
        And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Bookmark "researchDetailsPage|relatedArticlesBookmarkIconsList"
        And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Image "researchDetailsPage|relatedArticlesImagesList"
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"
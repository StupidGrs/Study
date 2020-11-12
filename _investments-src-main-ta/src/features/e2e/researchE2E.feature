@e2e
Feature: Company Admin submits a research and checks that it is not available in Research tab and is present in his Posts

  Scenario: Company Admin submits a research
    Given User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks [Publish] button "header|publishButton"
    And User clicks on [Research / WhitePaper] icon "modalWindow|researchIcon"
    #Fill in all fields
    When User remembers text "Test_Auto_Research" with added unique Id as "researchTitle_1"
    Then User enters "$researchTitle_1" in Title field "publishResearchPage|titleField"
    And User enters "Test_Auto Executive Summary" in Executive Summary text area "publishResearchPage|executiveSummaryField"
    #Automation step for file upload does not work on local Edge, but works good in sauce labs
    And User makes upload of file "testContentForUpload.pdf" using form "publishResearchPage|uploadPDFFieldInput"
    And User enters "https://www.wikipedia.org/" in Link to Content field "publishResearchPage|linkToContent"
    And User enters "Test_Auto Content" in Research Content field "publishResearchPage|fullPostContentField" by executing script
    #TODO
    #Add method to remember selected date and transform it from MM/DD/YYYY to MMM DD, YYYY
    And User clicks Date Picker icon "publishResearchPage|datePickerIcon"
    And User clicks Next Month icon "calendar|nextMonthButton"
    And User clicks Day icon "calendar|daysList" with text "23"
    And User selects item "option" with text "Speech" from Research Type dropdown "publishResearchPage|researchTypeDropdownField"
    And User selects item "option" with text "Hot Topics" from Taxonomies dropdown "publishResearchPage|taxonomiesDropdownField"
    And User enters "Investing" in the Tag field "publishResearchPage|tagsField"
    And User waits for Tag item "publishResearchPage|tagsAutoCompleteItem" with text "Investing" visibility within 5 seconds
    And User clicks Tag item "publishResearchPage|tagsAutoCompleteItem" with text "Investing"
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Read time"
    Then User enters "10" in Number of Minutes field "publishResearchPage|numberOfMinutesField"
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Featured Image"
    Then User makes upload of file "testContentForUpload.png" using form "publishResearchPage|featuredImageFieldInput"
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Video Link"
    Then User enters "https://www.youtube.com/watch?v=W6NZfCO5SIk" in Video Link field "publishResearchPage|videoLinkField"
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Regions"
    Then User clicks checkbox "publishResearchPage|regionCheckBoxLabelsList" with text "UK"
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Audience"
    Then User clicks checkbox "publishResearchPage|targetAudienceCheckBoxLabelsList" with text "Mercer Consultant"
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Authors"
    Then User enters "Test_Auto User" in Author field "publishResearchPage|authorField"
    And User scrolls page to top
    When User clicks Submit button "publishResearchPage|submitButton"
    And User clicks Close Toast icon "toast|toastCloseIcon"
    
  Scenario: Company Admin checks that submitted research is not available on Research page
    #Verify created research not available on Research page
    When User waits 10 seconds
    When User clicks Research tab "navigation|researchTab"
    Then List of Research Articles "researchPage|articlesList" is displayed
    When User enters "$researchTitle_1" in Search field "researchPage|searchArticleAutocompleteField"
    And User presses Enter key in Search field "researchPage|searchArticleAutocompleteField"
    Then List of Research Articles "researchPage|articlesList" is not displayed
    And No results message "researchPage|noResultsMessage" with text "No research to display. Try changing your search." is displayed

  Scenario: Company Admin checks that submitted research is available in User's Posts and has Approval Pending status
    #Open Profile->Posts and verify that post is available
    When User clicks Profile Button "header|profileButton"
    And User clicks Posts link "header|postsLink" by executing script
    When User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
    And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "research post"
    Then User Post "userPostsPage|articleTitlesList" with text "$researchTitle_1" is displayed
    And Post Status "userPostsPage|articleStatusesList" text is equal to "Approval Pending" on Post "userPostsPage|articlesList" with text "$researchTitle_1"

  Scenario: Company Admin checks submitted research data on Research Detials page
    When User clicks Post "userPostsPage|articleTitlesList" with text "$researchTitle_1" using script
    Then Research Title "researchDetailsPage|title" text is equal to "$researchTitle_1"
    And Research Exceprt "researchDetailsPage|excerpt" text is equal to "Test_Auto Executive Summary"
    And Research Type "researchDetailsPage|researchType" text is equal to "Speech"
    And Research Header Company Logo "researchDetailsPage|headerCompanyLogoIcon" is displayed
    And Research Header Company Name "researchDetailsPage|headerCompanyName" text is equal to "CompAuto"
    And Research Header Read Time "researchDetailsPage|headerReadTime" text is equal to "10 min read"
    #TODO
    #Add method to remember selected date and calculate "ago" time to check "articleHeaderDate" exact value
    And Research Header Date "researchDetailsPage|headerDate" is displayed
    And Research Content "researchDetailsPage|content" text is equal to "Test_Auto Content"
    And Video "researchDetailsPage|videoIframe" is displayed
    And Research Content "researchDetailsPage|content" text is equal to "Test_Auto Content"
    And Attribute "src" of Video Link "researchDetailsPage|videoIframe" is equal to "https://www.youtube.com/embed/W6NZfCO5SIk"
    #And Video Error "researchDetailsPage|videoError" is not displayed in iframe "researchDetailsPage|videoIframe"
    And Attribute "href" of [Visit External Link] button "researchDetailsPage|visitExternalLinkButton" is equal to "https://www.wikipedia.org/"
    And Attribute "href" of [Download the full report] button "researchDetailsPage|downloadFullReportButton" contains ".pdf"
    And Tags List "researchDetailsPage|footerTagsList" count is equal to 1
    And Tags List "researchDetailsPage|footerTagsList" text is equal to "Investing"

  Scenario: Company Admin checks other elements on research details page: Views And Stars Section in the header
    And Views And Stars Section "researchDetailsPage|headerViewsAndStarsSection" is displayed
    And Views Icon "researchDetailsPage|headerViewsIcon" is displayed
    And Views Count "researchDetailsPage|headerViewsCount" is displayed
    And Rating Stars Set "researchDetailsPage|headerRatingStarsIconsSet" is displayed
    And Rating Stars "researchDetailsPage|headerRatingStarsIconsList" count is equal to 5
    And Rating Count "researchDetailsPage|headerRatingCount" is displayed

  Scenario: Company Admin checks other elements on research details page: Left block elements
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

  Scenario: Company Admin checks other elements on research details page: Disclaimer
    And Disclaimer Label "researchDetailsPage|disclaimerLabel" text is equal to "Disclaimer"
    And Disclaimer Text "researchDetailsPage|disclaimerText" is displayed

  Scenario: Company Admin checks other elements on research details page: Rate This elements in the footer
    And Star Icon "researchDetailsPage|footerRateThisStarIcon" is displayed
    And Rate This "researchDetailsPage|footerRateThisText" text is equal to "Rate This"
    And Rating Stars Set "researchDetailsPage|footerRatingStarsIconsSet" is displayed
    And Rating Stars "researchDetailsPage|footerRatingStarsIconsList" count is equal to 5
    And Rating Count "researchDetailsPage|footerRatingCount" is displayed

  Scenario: Company Admin checks other elements on research details page: Author elements in the footer
    And Company Logo "researchDetailsPage|authorCompanyLogo" is displayed
    And Company Name "researchDetailsPage|authorCompanyName" text is equal to "CompAuto"
    And Followers number "researchDetailsPage|authorCompanyFollowers" is displayed
    And Followers number "researchDetailsPage|authorCompanyFollowers" contains "followers" text
    And Follow button "researchDetailsPage|authorFollowButton" is enabled
    And Follow button "researchDetailsPage|authorFollowButton" text is equal to "FOLLOW"

  Scenario: Company Admin checks other elements on research details page: Related Researches section
    And Related Researches section "researchDetailsPage|relatedSection" is displayed
    And Related Researches Header Title "researchDetailsPage|relatedSectionHeader" text is equal to "Related Research"
    And Explore Research link "researchDetailsPage|relatedSectionExploreLink" contains "Explore Research" text
    And Attribute "href" of [Explore Research] link "researchDetailsPage|relatedSectionExploreLink" contains "/research"
    And Explore Research link icon "researchDetailsPage|relatedSectionExploreLinkIcon" is displayed
    And Related Articles List "researchDetailsPage|relatedArticlesList" is displayed
    And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Title "researchDetailsPage|relatedArticlesTitlesList"
    And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Type "researchDetailsPage|relatedArticlesTypesList"
    #And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Excerpt "researchDetailsPage|relatedArticlesExcerptList"
    And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Company Logo "researchDetailsPage|relatedArticlesCompanyLogoIcons"
    And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Company Name "researchDetailsPage|relatedArticlesCompanyNamesList"
    And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Date "researchDetailsPage|relatedArticlesDatesList"
    And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Views icon "researchDetailsPage|relatedArticlesViewsIconsList"
    And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Views value "researchDetailsPage|relatedArticlesViewsCountList"
    And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Stars Icons Set "researchDetailsPage|relatedArticlesRatingStarsIconsSetList"
    And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Rating value "researchDetailsPage|relatedArticlesRatingCountList"
    And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Bookmark "researchDetailsPage|relatedArticlesBookmarkIconsList"
    And User verifies each Related Articles "researchDetailsPage|relatedArticlesList" contains Image "researchDetailsPage|relatedArticlesImagesList"

  Scenario: Company Admin submits two researches with "Submit and Add another" button
    When User clicks [Publish] button "header|publishButton"
    And User clicks on [Research / WhitePaper] icon "modalWindow|researchIcon"
    #Fill in all fields
    When User remembers text "Test_Auto_Research" with added unique Id as "researchTitle_2_1"
    Then User enters "$researchTitle_2_1" in Title field "publishResearchPage|titleField"
    And User enters "Test_Auto Executive Summary" in Executive Summary text area "publishResearchPage|executiveSummaryField"
    And User makes upload of file "testContentForUpload.pdf" using form "publishResearchPage|uploadPDFFieldInput"
    And User enters "https://www.wikipedia.org/" in Link to Content field "publishResearchPage|linkToContent"
    And User enters "Test_Auto Content" in Research Content field "publishResearchPage|fullPostContentField" by executing script
    #TODO
    #Add method to remember selected date and transform it from MM/DD/YYYY to MMM DD, YYYY
    And User clicks Date Picker icon "publishResearchPage|datePickerIcon"
    And User clicks Next Month icon "calendar|nextMonthButton"
    And User clicks Day icon "calendar|daysList" with text "23"
    And User selects item "option" with text "Speech" from Research Type dropdown "publishResearchPage|researchTypeDropdownField"
    And User selects item "option" with text "Hot Topics" from Taxonomies dropdown "publishResearchPage|taxonomiesDropdownField"
    And User enters "Investing" in the Tag field "publishResearchPage|tagsField"
    And User waits for Tag item "publishResearchPage|tagsAutoCompleteItem" with text "Investing" visibility within 5 seconds
    And User clicks Tag item "publishResearchPage|tagsAutoCompleteItem" with text "Investing"
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Read Time"
    Then User enters "10" in Number of Minutes field "publishResearchPage|numberOfMinutesField"
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Featured Image"
    Then User makes upload of file "testContentForUpload.png" using form "publishResearchPage|featuredImageFieldInput"
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Video Link"
    Then User enters "https://www.youtube.com/watch?v=W6NZfCO5SIk" in Video Link field "publishResearchPage|videoLinkField"
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Regions"
    Then User clicks checkbox "publishResearchPage|regionCheckBoxLabelsList" with text "UK"
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Audience"
    Then User clicks checkbox "publishResearchPage|targetAudienceCheckBoxLabelsList" with text "Mercer Consultant"
    When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Authors"
    Then User enters "Test_Auto User" in Author field "publishResearchPage|authorField"
    And User scrolls page to top
    When User clicks Submit and Add Another button "publishResearchPage|submitAndAddAnotherButton"
    And User clicks Close Toast icon "toast|toastCloseIcon"
    #Create one more research
    When User remembers text "Test_Auto_Research" with added unique Id as "researchTitle_2_2"
    Then User enters "$researchTitle_2_2" in Title field "publishResearchPage|titleField"
    And User enters "Test_Auto Executive Summary" in Executive Summary text area "publishResearchPage|executiveSummaryField"
    And User makes upload of file "testContentForUpload.pdf" using form "publishResearchPage|uploadPDFFieldInput"
    And User enters "https://www.wikipedia.org/" in Link to Content field "publishResearchPage|linkToContent"
    And User enters "Test_Auto Content" in Research Content field "publishResearchPage|fullPostContentField" by executing script
    And User clicks Date Picker icon "publishResearchPage|datePickerIcon"
    And User clicks Next Month icon "calendar|nextMonthButton"
    And User clicks Day icon "calendar|daysList" with text "23"
    And User selects item "option" with text "Speech" from Research Type dropdown "publishResearchPage|researchTypeDropdownField"
    And User selects item "option" with text "Hot Topics" from Taxonomies dropdown "publishResearchPage|taxonomiesDropdownField"
    And User enters "Investing" in the Tag field "publishResearchPage|tagsField"
    And User waits for Tag item "publishResearchPage|tagsAutoCompleteItem" with text "Investing" visibility within 5 seconds
    And User clicks Tag item "publishResearchPage|tagsAutoCompleteItem" with text "Investing"
    And User enters "10" in Number of Minutes field "publishResearchPage|numberOfMinutesField"
    And User makes upload of file "testContentForUpload.png" using form "publishResearchPage|featuredImageFieldInput"
    And User enters "https://www.youtube.com/watch?v=W6NZfCO5SIk" in Video Link field "publishResearchPage|videoLinkField"
    And User clicks checkbox "publishResearchPage|regionCheckBoxLabelsList" with text "UK"
    And User clicks checkbox "publishResearchPage|targetAudienceCheckBoxLabelsList" with text "Mercer Consultant"
    And User enters "Test_Auto User" in Author field "publishResearchPage|authorField"
    And User scrolls page to top
    When User clicks Submit button "publishResearchPage|submitButton"
    And User clicks Close Toast icon "toast|toastCloseIcon"

  Scenario: Company Admin checks that two submitted researches are not available on Research page
    #Verify that the first research is not available
    When User clicks Research tab "navigation|researchTab"
    And User clears text from Search field "researchPage|searchArticleAutocompleteField"
    Then List of Research Articles "researchPage|articlesList" is displayed
    When User enters "$researchTitle_2_1" in Search field "researchPage|searchArticleAutocompleteField"
    And User presses Enter key in Search field "researchPage|searchArticleAutocompleteField"
    Then List of Research Articles "researchPage|articlesList" is not displayed
    And No results message "researchPage|noResultsMessage" with text "No research to display. Try changing your search." is displayed
    #Verify that the second research is not available
    When User clears text from Search field "researchPage|searchArticleAutocompleteField"
    Then List of Research Articles "researchPage|articlesList" is displayed
    When User enters "$researchTitle_2_2" in Search field "researchPage|searchArticleAutocompleteField"
    And User presses Enter key in Search field "researchPage|searchArticleAutocompleteField"
    Then List of Research Articles "researchPage|articlesList" is not displayed
    And No results message "researchPage|noResultsMessage" with text "No research to display. Try changing your search." is displayed

  Scenario: Company Admin checks that two submitted researches are available in User's Posts and have Approval Pending status
    #Open Profile->Posts and verify that posts are available
    Then User clicks Profile Button "header|profileButton"
    And User clicks Posts link "header|postsLink" by executing script
    When User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
    And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "research post"
    Then User Post "userPostsPage|articleTitlesList" with text "$researchTitle_2_1" is displayed
    And User Post "userPostsPage|articleTitlesList" with text "$researchTitle_2_2" is displayed
    And Post Status "userPostsPage|articleStatusesList" text is equal to "Approval Pending" on Post "userPostsPage|articlesList" with text "$researchTitle_2_1"
    And Post Status "userPostsPage|articleStatusesList" text is equal to "Approval Pending" on Post "userPostsPage|articlesList" with text "$researchTitle_2_2"

  Scenario: Company Admin checks data of two submitted researches: checks the first report
    #Verify data of the 1st post
    When User clicks Post "userPostsPage|articleTitlesList" with text "$researchTitle_2_1" using script
    Then Research Details Title "researchDetailsPage|title" text is equal to "$researchTitle_2_1"
    And Research Exceprt "researchDetailsPage|excerpt" text is equal to "Test_Auto Executive Summary"
    And Research Type "researchDetailsPage|researchType" text is equal to "Speech"
    And Research Header Company Logo "researchDetailsPage|headerCompanyLogoIcon" is displayed
    And Research Header Company Name "researchDetailsPage|headerCompanyName" text is equal to "CompAuto"
    And Research Header Read Time "researchDetailsPage|headerReadTime" text is equal to "10 min read"
    #TODO
    #Add method to remember selected date and calculate "ago" time to check "articleHeaderDate" exact value
    And Research Header Date "researchDetailsPage|headerDate" is displayed
    And Video "researchDetailsPage|videoIframe" is displayed
    And Research Content "researchDetailsPage|content" text is equal to "Test_Auto Content"
    And Attribute "src" of Video Link "researchDetailsPage|videoIframe" is equal to "https://www.youtube.com/embed/W6NZfCO5SIk"
    #And Video Error "researchDetailsPage|videoError" is not displayed in iframe "researchDetailsPage|videoIframe"
    And Attribute "href" of [Visit External Link] button "researchDetailsPage|visitExternalLinkButton" is equal to "https://www.wikipedia.org/"
    And Attribute "href" of [Download the full report] button "researchDetailsPage|downloadFullReportButton" contains ".pdf"
    And Tags List "researchDetailsPage|footerTagsList" count is equal to 1
    And Tags List "researchDetailsPage|footerTagsList" text is equal to "Investing"

  Scenario: Company Admin checks data of two submitted researches: checks the second report
    #Open the 2nd post
    When User clicks Profile Button "header|profileButton"
    And User clicks Posts link "header|postsLink" by executing script
    And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
    And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "research post"
    #Verify data of the 2nd post
    And User clicks Post "userPostsPage|articleTitlesList" with text "$researchTitle_2_2" using script
    Then Research Details Title "researchDetailsPage|title" text is equal to "$researchTitle_2_2"
    And Research Exceprt "researchDetailsPage|excerpt" text is equal to "Test_Auto Executive Summary"
    And Research Type "researchDetailsPage|researchType" text is equal to "Speech"
    And Research Header Company Logo "researchDetailsPage|headerCompanyLogoIcon" is displayed
    And Research Header Company Name "researchDetailsPage|headerCompanyName" text is equal to "CompAuto"
    And Research Header Read Time "researchDetailsPage|headerReadTime" text is equal to "10 min read"
    #TODO
    #Add method to remember selected date and calculate "ago" time to check "articleHeaderDate" exact value
    And Research Header Date "researchDetailsPage|headerDate" is displayed
    And Research Content "researchDetailsPage|content" text is equal to "Test_Auto Content"
    And Video "researchDetailsPage|videoIframe" is displayed
    And Research Content "researchDetailsPage|content" text is equal to "Test_Auto Content"
    And Attribute "src" of Video Link "researchDetailsPage|videoIframe" is equal to "https://www.youtube.com/embed/W6NZfCO5SIk"
    #And Video Error "researchDetailsPage|videoError" is not displayed in iframe "researchDetailsPage|videoIframe"
    And Attribute "href" of [Visit External Link] button "researchDetailsPage|visitExternalLinkButton" is equal to "https://www.wikipedia.org/"
    And Attribute "href" of [Download the full report] button "researchDetailsPage|downloadFullReportButton" contains ".pdf"
    And Tags List "researchDetailsPage|footerTagsList" count is equal to 1
    And Tags List "researchDetailsPage|footerTagsList" text is equal to "Investing"

  Scenario: User logs out
    When User navigates to "HOME_PAGE"
    Then User clicks Profile Button "header|profileButton"
    And User clicks Profile Menu Item "header|profileMenuItemsList" with text "Logout"

  Scenario Outline: Delete submitted research
    When User "GLOBAL_ADMIN" logs in with API
    And User deletes "Research" with "Title" equal to "$<researchTitle>"
    Examples:
      | researchTitle     |
      | researchTitle_1   |
      | researchTitle_2_1 |
      | researchTitle_2_2 |

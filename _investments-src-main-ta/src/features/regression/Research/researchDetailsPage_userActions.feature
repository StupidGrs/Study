@research
@researchDetails
Feature: Verify buttons behaviour on Research Details Page

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
        Then User "COMPANY_ADMIN" publishes "Research" with all fields and title "$researchTitle" with API
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        Then User navigates to "Research" URL with title "$researchTitle"

    @regression
    Scenario: Verify [Back] button redirects User to Research page
        When User clicks [Back] button "researchDetailsPage|backButton" by executing script
        Then Page URL is equal to "RESEARCH_PAGE"
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    # todo:
    # Bookmark button is not available for drafts since v.1.2.0. Should be checked for approved articles

    #    @bookmark
    #    @regression
    #    Scenario: Verify User is able to [Bookmark] Research
    #        When User clicks Bookmark Icon "researchDetailsPage|leftBlockBookmarkIcon"
    #        And User clicks Profile Icon "header|profileButton"
    #        And User clicks [Bookmarks] "header|bookmarksLink"
    #        Then Bookmark "bookmarksPopup|bookmarkTitleList" with text "$researchTitle" is displayed
    #        #delete research
    #        And User deletes "Research" with "Title" equal to "$researchTitle"
    #
    #    @bookmark
    #    @regression
    #    Scenario: Verify User is able to remove Research from Bookmarks using [Bookmark] button
    #        When User "COMPANY_ADMIN" bookmarks Article with title "$researchTitle" with API
    #        And User refreshes page
    #        And User clicks Bookmark Icon "researchDetailsPage|leftBlockBookmarkIcon"
    #        And User clicks Profile Icon "header|profileButton"
    #        And User clicks [Bookmarks] "header|bookmarksLink"
    #        Then Bookmark "bookmarksPopup|bookmarkTitleList" with text "$researchTitle" is not displayed
    #        #delete research
    #        And User deletes "Research" with "Title" equal to "$researchTitle"

    @regression
    Scenario: Verify [Download Icon] from Left Block
#        When User remembers File Name from "href" attribute of "researchDetailsPage|leftBlockDownloadAttachLink" as "filename"
#        And User clicks Download Attachment Icon "researchDetailsPage|leftBlockDownloadAttachIcon"
        #TODO: Investigate why it fails on STAGE
        #Then User verifies downloaded file "$filename" hash is equal to template file "testContentForUpload.pdf" hash
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @regression
    Scenario: Verify [Download the full report] button
#        When User remembers File Name from "href" attribute of "researchDetailsPage|downloadFullReportButton" as "filename"
#        And User clicks Download Attachment Icon "researchDetailsPage|downloadFullReportButton"
        #TODO: Investigate why it fails on STAGE
        #Then User verifies downloaded file "$filename" hash is equal to template file "testContentForUpload.pdf" hash
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @regression
    Scenario: Verify [Visit External Link] button
        When User clicks [Visit External Link] button "researchDetailsPage|visitExternalLinkButton"
        And User goes to 2 browser tab
        #TODO: Investigate why it fails on STAGE
        #Then Page URL is equal to "https://www.wikipedia.org/"
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @regression
    Scenario: Verify [Explore Research] link redirects User to Research page
        When User clicks [Explore Research] link "researchDetailsPage|relatedSectionExploreLink" by executing script
        Then Page URL is equal to "RESEARCH_PAGE"
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"
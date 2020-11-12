#change required fields and check [save draft] enabled
@research
Feature: Verify [Save draft] button becomes enabled when User updates data in [Required fields] on Draft Research Page

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        When User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
        And User "COMPANY_ADMIN" saves Draft "Research" with all fields and title "$researchTitle" with API
        And User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User clicks Profile Button "header|profileButton"
        And User clicks Posts link "header|postsLink" by executing script
        And User clicks Select Content Type Dropdown "userPostsPage|selectContentTypeDropdown"
        And User clicks Select Content Type Dropdown Option "userPostsPage|selectContentTypeDropdownOptionsList" with text "research post"
        Then User Post "userPostsPage|articleTitlesList" with text "$researchTitle" is displayed
        And User clicks Post "userPostsPage|articleTitlesList" with text "$researchTitle" using script
        And [Save draft] button "publishResearchPage|saveDraftButton" is displayed
        And [Save draft] button "publishResearchPage|saveDraftButton" is disabled

    @regression
    @draftResearchPage
    Scenario Outline: Verify [Save draft] button becomes enabled when User - updates [<fieldDesc>] field
        When User enters "<value>" in <fieldDesc> field "publishResearchPage|<fieldSelector>"
        Then [Save draft] button "publishResearchPage|saveDraftButton" is enabled
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"
        Examples:
            | fieldDesc         | fieldSelector         | value   |
            | Title             | titleField            | Updated |
            | Executive Summary | executiveSummaryField | Updated |
            | Link to Content   | linkToContent         | Updated |

    @regression
    @draftResearchPage
    Scenario: Verify [Save draft] button becomes enabled when User - updates [Full Post Content] field
        When User enters "Updated" in Full Post Content field "publishResearchPage|fullPostContentField" by executing script
        And User clicks Full Post Content Label icon "publishResearchPage|fullPostContentFieldLabel"
        And User waits 2 seconds
        Then [Save draft] button "publishResearchPage|saveDraftButton" is enabled
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @regression
    @draftResearchPage
    Scenario: Verify [Save draft] button becomes enabled when User - updates [Date] field
        When User clicks Date Picker icon "publishResearchPage|datePickerIcon"
        And User clicks Next Month icon "calendar|nextMonthButton"
        And User clicks Day icon "calendar|daysList" with text "23"
        Then [Save draft] button "publishResearchPage|saveDraftButton" is enabled
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @regression
    @draftResearchPage
    Scenario: Verify [Save draft] button becomes enabled when User - changes Research Type
        When User selects item "option" with text "Publication" from Research Type dropdown "publishResearchPage|researchTypeDropdownField"
        Then [Save draft] button "publishResearchPage|saveDraftButton" is enabled
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @regression
    @draftResearchPage
    Scenario: Verify [Save draft] button becomes enabled when User - removes selected [Taxonomy]
        When User clicks Remove Selected Taxonomy Icon "publishResearchPage|taxonomiesRemoveIconsList"
        Then [Save draft] button "publishResearchPage|saveDraftButton" is enabled
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @regression
    @draftResearchPage
    Scenario: Verify [Save draft] button becomes enabled when User - adds one more [Taxonomy]
        When User selects item "option" with text "Strategy" from Taxonomies dropdown "publishResearchPage|taxonomiesDropdownField"
        Then [Save draft] button "publishResearchPage|saveDraftButton" is enabled
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"
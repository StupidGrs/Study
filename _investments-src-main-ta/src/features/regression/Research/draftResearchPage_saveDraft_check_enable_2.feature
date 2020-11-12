#change optional fields and check [save draft] enabled
@research
Feature: Verify [Save draft] button becomes enabled when User updates data in [Optional fields] on Draft Research Page

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
    Scenario: Verify [Save draft] button becomes enabled when User - removes selected [Tag]
        When User clicks Remove Selected Tag Icon "publishResearchPage|tagsRemoveIconsList"
        Then [Save draft] button "publishResearchPage|saveDraftButton" is enabled
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @regression
    @draftResearchPage
    Scenario: Verify [Save draft] button becomes enabled when User - adds one more [Tag]
        When User enters "Taxes" in the Tag field "publishResearchPage|tagsField"
        And User waits for Tag item "publishResearchPage|tagsAutoCompleteItem" with text "Taxes" visibility within 5 seconds
        And User clicks Tag item "publishResearchPage|tagsAutoCompleteItem" with text "Taxes"
        Then [Save draft] button "publishResearchPage|saveDraftButton" is enabled
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @regression
    @draftResearchPage
    Scenario Outline: Verify [Save draft] button becomes enabled when User - updates field in [<sectionName>] section
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "<sectionName>"
        And User clicks Input field "publishResearchPage|<fieldSelector>"
        And User enters "<value>" in <sectionName> field "publishResearchPage|<fieldSelector>"
        Then [Save draft] button "publishResearchPage|saveDraftButton" is enabled
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"
        Examples:
            | sectionName | fieldSelector        | value   |
            | Read time   | numberOfMinutesField | 5       |
            | Video Link  | videoLinkField       | Updated |
            | Authors     | authorField          | Updated |

    @regression
    @draftResearchPage
    Scenario: Verify [Save draft] button becomes enabled when User - clicks [Calculate] button
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "Read time"
        And User clicks [Calculate] button "publishResearchPage|calculateButton"
        Then [Save draft] button "publishResearchPage|saveDraftButton" is enabled
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @regression
    @draftResearchPage
    Scenario Outline: Verify [Save draft] button becomes enabled when User - unselects checkbox in [<sectionName>] section
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "<sectionName>"
        Then Checkbox "publishResearchPage|<checkBox>CheckBoxInputsList" on Row "publishResearchPage|<checkBox>RowsList" with text "<checkboxText>" is selected
        When User clicks checkbox "publishResearchPage|<checkBox>CheckBoxLabelsList" with text "<checkboxText>"
        Then [Save draft] button "publishResearchPage|saveDraftButton" is enabled
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"
        Examples:
            | sectionName | checkBox       | checkboxText  |
#            | Regions     | region         | UK            |
            | Audience    | targetAudience | Asset Manager |

    @regression
    @draftResearchPage
    Scenario Outline: Verify [Save draft] button becomes enabled when User - selects one more checkbox in [<sectionName>] section
        When User clicks Right Sidebar Item "publishResearchPage|rightSidebarAccordionHeadersTextsList" with text "<sectionName>"
        Then Checkbox "publishResearchPage|<checkBox>CheckBoxInputsList" on Row "publishResearchPage|<checkBox>RowsList" with text "<checkboxText>" is not selected
        When User clicks checkbox "publishResearchPage|<checkBox>CheckBoxLabelsList" with text "<checkboxText>"
        Then [Save draft] button "publishResearchPage|saveDraftButton" is enabled
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"
        Examples:
            | sectionName | checkBox       | checkboxText      |
            | Regions     | region         | US                |
            | Audience    | targetAudience | Mercer Consultant |
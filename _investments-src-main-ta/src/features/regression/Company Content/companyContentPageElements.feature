@companyContentPage
Feature: Company Admin verifies Company Content page elements

  @regression
  Scenario: Company Admin opens Company Content page and verifies all elements on the page (Researches)
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    #Back button
    Then Back Button "companyContent|backButton" is displayed
    #Page title
    And Page Title "companyContent|pageTitle" with text "Your Company Content" is displayed
    And Page Subtitle "companyContent|pageSubtitle" with text "A snapshot of all your company's published content" is displayed
    #filters section
    And Content Type Field Title "companyContent|contentTypeFieldTitle" with text "Content Type:" is displayed
    And Content Type Field "companyContent|contentTypeField" is displayed
    And Default option "companyContent|researchOption" with text "Research" is displayed
    And Search Field Title "companyContent|searchFieldTitle" with text "Filter Posts:" is displayed
    And Search Field "companyContent|searchField" is displayed
    And Attribute "placeholder" of Search Field "companyContent|searchField" is equal to "Begin Typing Post Name"
    And Remaining Tokens Counter "companyContent|remainingTokensCount" text is equal to "1 Featured Tokens Remaining"
    #status tabs
    #Published
    And Tab "companyContent|publishedTab" with text "Published" is displayed
    And Attribute "class" of the Tab "companyContent|statusTabsList" with text "Published" contains "--active"
    #Pending Approval
    And Tab "companyContent|pendingApprovalTab" with text "Pending Approval" is displayed
    And Attribute "class" of the Tab "companyContent|statusTabsList" with text "Pending Approval" does not contain "--active"
    #Draft
    And Tab "companyContent|draftTab" with text "Draft" is displayed
    And Attribute "class" of the Tab "companyContent|statusTabsList" with text "Draft" does not contain "--active"
    #Rejected
    And Tab "companyContent|rejectedTab" with text "Rejected" is displayed
    And Attribute "class" of the Tab "companyContent|statusTabsList" with text "Rejected" does not contain "--active"
    #Columns
    #Type
    And Column "companyContent|sortingHeadersList" with text "Type" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Type" contains "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Type" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Type" contains "arrow_downward"
    #Featured
    And Column "companyContent|sortingHeadersList" with text "Featured" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Featured" does not contain "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Featured" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Featured" contains "arrow_upward"
    #Ratings
    And Column "companyContent|sortingHeadersList" with text "Ratings" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Ratings" does not contain "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Ratings" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Ratings" contains "arrow_upward"
    #Post Name
    And Column "companyContent|sortingHeadersList" with text "Post Name" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Post Name" does not contain "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Post Name" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Post Name" contains "arrow_upward"
    #Post Date
    And Column "companyContent|sortingHeadersList" with text "Post Date" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Post Date" does not contain "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Post Date" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Post Date" contains "arrow_upward"
    #Views
    And Column "companyContent|sortingHeadersList" with text "Views" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Views" does not contain "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Views" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Views" contains "arrow_upward"
    #Clickthroughs
    And Column "companyContent|sortingHeadersList" with text "Clickthroughs" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Clickthroughs" does not contain "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Clickthroughs" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Clickthroughs" contains "arrow_upward"
    #Downloads
    And Column "companyContent|sortingHeadersList" with text "Downloads" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Downloads" does not contain "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Downloads" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Downloads" contains "arrow_upward"
    #Actions
#    And Column "companyContent|sortingHeadersList" with text "Actions" is displayed
#    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Actions" does not contain "--active"

  @regression
  Scenario: Company Admin opens Company Content page and verifies all elements on the page (News)
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User selects News option "companyContent|newsOption" from Content Type dropdown "companyContent|contentTypeField"
    #Back button
    Then Back Button "companyContent|backButton" is displayed
    #Page title
    And Page Title "companyContent|pageTitle" with text "Your Company Content" is displayed
    And Page Subtitle "companyContent|pageSubtitle" with text "A snapshot of all your company's published content" is displayed
    #filters section
    And Content Type Field Title "companyContent|contentTypeFieldTitle" with text "Content Type:" is displayed
    And Content Type Field "companyContent|contentTypeField" is displayed
    And Option "companyContent|newsOption" with text "News" is displayed
    And Search Field Title "companyContent|searchFieldTitle" with text "Filter Posts:" is displayed
    And Search Field "companyContent|searchField" is displayed
    And Attribute "placeholder" of Search Field "companyContent|searchField" is equal to "Begin Typing Post Name"
    And Remaining Tokens Counter "companyContent|remainingTokensCount" text is equal to "1 Featured Tokens Remaining"
    #status tabs
    #Published
    And Tab "companyContent|publishedTab" with text "Published" is displayed
    And Attribute "class" of the Tab "companyContent|statusTabsList" with text "Published" contains "--active"
    #Pending Approval
    And Tab "companyContent|pendingApprovalTab" with text "Pending Approval" is displayed
    And Attribute "class" of the Tab "companyContent|statusTabsList" with text "Pending Approval" does not contain "--active"
    #Draft
    And Tab "companyContent|draftTab" with text "Draft" is displayed
    And Attribute "class" of the Tab "companyContent|statusTabsList" with text "Draft" does not contain "--active"
    #Rejected
    And Tab "companyContent|rejectedTab" with text "Rejected" is displayed
    And Attribute "class" of the Tab "companyContent|statusTabsList" with text "Rejected" does not contain "--active"
    #Columns
    #Type
    And Column "companyContent|sortingHeadersList" with text "Type" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Type" contains "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Type" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Type" contains "arrow_downward"
    #Featured
    And Column "companyContent|sortingHeadersList" with text "Featured" is not displayed
    #Ratings
    And Column "companyContent|sortingHeadersList" with text "Ratings" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Ratings" does not contain "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Ratings" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Ratings" contains "arrow_upward"
    #Post Name
    And Column "companyContent|sortingHeadersList" with text "Post Name" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Post Name" does not contain "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Post Name" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Post Name" contains "arrow_upward"
    #Post Date
    And Column "companyContent|sortingHeadersList" with text "Post Date" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Post Date" does not contain "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Post Date" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Post Date" contains "arrow_upward"
    #Views
    And Column "companyContent|sortingHeadersList" with text "Views" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Views" does not contain "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Views" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Views" contains "arrow_upward"
    #Clickthroughs
    And Column "companyContent|sortingHeadersList" with text "Clickthroughs" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Clickthroughs" does not contain "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Clickthroughs" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Clickthroughs" contains "arrow_upward"
    #Downloads
    And Column "companyContent|sortingHeadersList" with text "Downloads" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Downloads" does not contain "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Downloads" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Downloads" contains "arrow_upward"
    #Actions
#    And Column "companyContent|sortingHeadersList" with text "Actions" is displayed
#    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Actions" does not contain "--active"

  @regression
  Scenario: Company Admin opens Company Content page and verifies all elements on the page (Events)
    #flow
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User clicks Settings button "header|settingsButton"
    And User clicks Company Content button "header|companyContent" by executing script
    And User selects Events option "companyContent|eventsOption" from Content Type dropdown "companyContent|contentTypeField"
    #Back button
    Then Back Button "companyContent|backButton" is displayed
    #Page Title
    And Page Title "companyContent|pageTitle" with text "Your Company Content" is displayed
    And Page Subtitle "companyContent|pageSubtitle" with text "A snapshot of all your company's published content" is displayed
    #filters section
    And Content Type Field Title "companyContent|contentTypeFieldTitle" with text "Content Type:" is displayed
    And Content Type Field "companyContent|contentTypeField" is displayed
    And Option "companyContent|eventsOption" with text "Events" is displayed
    And Search Field Title "companyContent|searchFieldTitle" with text "Filter Posts:" is displayed
    And Search Field "companyContent|searchField" is displayed
    And Attribute "placeholder" of Search Field "companyContent|searchField" is equal to "Begin Typing Post Name"
    And Remaining Tokens Counter "companyContent|remainingTokensCount" text is equal to "1 Featured Tokens Remaining"
    #status tabs
    #Published
    And Tab "companyContent|publishedTab" with text "Published" is displayed
    And Attribute "class" of the Tab "companyContent|statusTabsList" with text "Published" contains "--active"
    #Pending Approval
    And Tab "companyContent|pendingApprovalTab" with text "Pending Approval" is displayed
    And Attribute "class" of the Tab "companyContent|statusTabsList" with text "Pending Approval" does not contain "--active"
    #Draft
    And Tab "companyContent|draftTab" with text "Draft" is displayed
    And Attribute "class" of the Tab "companyContent|statusTabsList" with text "Draft" does not contain "--active"
    #Rejected
    And Tab "companyContent|rejectedTab" with text "Rejected" is displayed
    And Attribute "class" of the Tab "companyContent|statusTabsList" with text "Rejected" does not contain "--active"
    #Columns
    #Type
    And Column "companyContent|sortingHeadersList" with text "Type" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Type" contains "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Type" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Type" contains "arrow_downward"
    #Featured
    And Column "companyContent|sortingHeadersList" with text "Featured" is not displayed
    #Attendees
    And Column "companyContent|sortingHeadersList" with text "Attendees" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Attendees" does not contain "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Attendees" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Attendees" contains "arrow_upward"
    #Event Name
    And Column "companyContent|sortingHeadersList" with text "Event Name" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Event Name" does not contain "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Event Name" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Event Name" contains "arrow_upward"
    #Event Date
    And Column "companyContent|sortingHeadersList" with text "Event Date" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Event Date" does not contain "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Event Date" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Event Date" contains "arrow_upward"
    #Views
    And Column "companyContent|sortingHeadersList" with text "Views" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Views" does not contain "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Views" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Views" contains "arrow_upward"
    #Clickthroughs
    And Column "companyContent|sortingHeadersList" with text "Clickthroughs" is displayed
    And Attribute "class" of Column "companyContent|sortingHeadersList" with text "Clickthroughs" does not contain "--active"
    And Icon "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Clickthroughs" is displayed
    And Attribute "icon" of Icon element "companyContent|sortingIconsList" on Column "companyContent|sortingHeadersList" with text "Clickthroughs" contains "arrow_upward"
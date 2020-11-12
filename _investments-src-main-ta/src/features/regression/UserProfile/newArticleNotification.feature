@userProfile
Feature: Checks new article notification function

    @regression
    @knownIssue @SRC-2448
    Scenario Outline: [<user>] checks toast notification and bell icon
        When User logs in as "<user>" on "LOGIN_PAGE"
        Then Page URL is equal to "HOME_PAGE"
        #Research article
        And User clicks [Publish] button "header|publishButton"
        And User clicks on [Research / WhitePaper] icon "modalWindow|researchIcon"
          #Header
        Then Header title "publishResearchPage|headerTitle" text is equal to "Publish Your Research"
         #Title
        And Title Label "publishResearchPage|titleFieldLabel" text is equal to "Title *"
        And Attribute "value" of Title Field "publishResearchPage|titleField" is equal to ""
        And User enters "test" in Title field "publishResearchPage|titleField"
        And Attribute "value" of Title Field "publishResearchPage|titleField" is equal to "test"
        #Executive Summary
        And Executive Summary Label "publishResearchPage|executiveSummaryFieldLabel" text is equal to "Executive Summary *"
        And Attribute "value" of Executive Summary Field "publishResearchPage|executiveSummaryField" is equal to ""
        And User enters "Test_Auto Executive Summary" in Executive Summary text area "publishResearchPage|executiveSummaryField"
        And Attribute "value" of Executive Summary Field "publishResearchPage|executiveSummaryField" is equal to "Test_Auto Executive Summary"
        #Link to Content
        And Link to Content Label "publishResearchPage|linkToContentLabel" text is equal to "Link to Content *"
        And Link to Content Field "publishResearchPage|linkToContent" is displayed
        And Attribute "value" of Link to Content Field "publishResearchPage|linkToContent" is equal to ""
        #Full Post Content
        And Full Post Content Label "publishNewsPage|fullPostContentFieldLabel" text is equal to "Full Post Content *"
        And User enters "Content_TEST" in Full Post Content field "publishResearchPage|fullPostContentField" by executing script
        And Full Post Content field "publishResearchPage|fullPostContentField" text is equal to "Content_TEST"
        #Date
        And Date Label "publishResearchPage|dateLabel" text is equal to "Date *"
        And User clicks Date Picker icon "publishResearchPage|datePickerIcon"
        And User clicks Next Month icon "calendar|nextMonthButton"
        And User clicks Day icon "calendar|daysList" with text "23"
        #Research Type
        And Label "publishResearchPage|researchTypeDropdownFieldLabel" text is equal to "Research Type *"
        And Attribute "value" of Research Type Field "publishResearchPage|researchTypeDropdownField" is equal to ""
        And User selects item "option" with text "Speech" from Research Type dropdown "publishResearchPage|researchTypeDropdownField"
        And Attribute "value" of Research Type Field "publishResearchPage|researchTypeDropdownField" is equal to "8: Speech"
        #Company
        And Company Label "publishResearchPage|mercerCompaniesAutocompleteFieldLabel" text is equal to "Company *"
        And Attribute "value" of Company Field "publishResearchPage|mercerCompaniesAutocompleteField" is equal to "CompAuto"
        #Taxonomy
        And Taxonomies Label "publishResearchPage|taxonomiesDropdownFieldLabel" text is equal to "Taxonomies *"
        And Taxonomies Field "publishResearchPage|taxonomiesDropdownField" text is equal to "Select Taxonomy"
        And User selects item "option" with text "Hot Topics" from Taxonomies dropdown "publishResearchPage|taxonomiesDropdownField"
        And User scrolls page to top
        And User clicks [Submit] "publishResearchPage|submitButton"
        #Check toast notification
        And Page URL is equal to "HOME_PAGE"
        Then Success toast "toast|toastMessage" is displayed
        And Toast message "toast|toastMessage" text is equal to "Thank you for your research article submission. Please note that all submissions are sent to moderation for admin approval. You will be notified when your submission is approved." with break line
        And Close Toast icon "toast|toastCloseIcon" is displayed
        And User clicks Close Toast icon "toast|toastCloseIcon"
        #News article
        And User navigates to "NEWS_PAGE"
        And User waits 2 seconds
        And Page URL is equal to "NEWS_PAGE"
        And User clicks [Publish] button "header|publishButton"
        And User clicks on [News / Blog] icon "modalWindow|newsIcon"
        #Header
        Then Header title "publishNewsPage|headerTitle" text is equal to "Publish Your News"
        #Title
        And Title Label "publishNewsPage|titleFieldLabel" text is equal to "Title *"
        And Attribute "value" of Title Field "publishNewsPage|titleField" is equal to ""
        And User enters "test" in Title field "publishNewsPage|titleField"
        And Attribute "value" of Title Field "publishNewsPage|titleField" is equal to "test"
        #Executive Summary
        And Executive Summary Label "publishNewsPage|executiveSummaryFieldLabel" text is equal to "Executive Summary *"
        And Attribute "value" of Executive Summary Field "publishNewsPage|executiveSummaryField" is equal to ""
        And User enters "Test_Auto Executive Summary" in Executive Summary text area "publishNewsPage|executiveSummaryField"
        And Attribute "value" of Executive Summary Field "publishNewsPage|executiveSummaryField" is equal to "Test_Auto Executive Summary"
        #Link to Content
        And Link to Content Label "publishNewsPage|linkToContentLabel" text is equal to "Link to Content *"
        And Attribute "value" of Link to Content Field "publishNewsPage|linkToContent" is equal to ""
        #Full Post Content
        And Full Post Content Label "publishNewsPage|fullPostContentFieldLabel" text is equal to "Full Post Content *"
        And Full Post Content field "publishNewsPage|fullPostContentField" text is equal to ""
        And User enters "Content_TEST" in Full Post Content field "publishNewsPage|fullPostContentField" by executing script
        And Full Post Content field "publishNewsPage|fullPostContentField" text is equal to "Content_TEST"
        #Date
        And Date Label "publishNewsPage|dateLabel" text is equal to "Date *"
        And User clicks Date Picker icon "publishNewsPage|datePickerIcon"
        And User clicks Next Month icon "calendar|nextMonthButton"
        And User clicks Day icon "calendar|daysList" with text "23"
        #Company
        And Company Label "publishNewsPage|mercerCompaniesAutocompleteFieldLabel" text is equal to "Company *"
        And Attribute "value" of Company Field "publishNewsPage|mercerCompaniesAutocompleteField" is equal to "CompAuto"
        #Taxonomy
        And Taxonomies Label "publishNewsPage|taxonomiesDropdownFieldLabel" text is equal to "Taxonomies *"
        And Taxonomies Field "publishNewsPage|taxonomiesDropdownField" text is equal to "Select Taxonomy"
        And User selects item "option" with text "Hot Topics" from Taxonomies dropdown "publishNewsPage|taxonomiesDropdownField"
        And User clicks [Submit] "publishNewsPage|submitButton"
         #Check toast notification
        And Page URL is equal to "NEWS_PAGE"
        Then Success toast "toast|toastMessage" is displayed
        And Toast message "toast|toastMessage" text is equal to "Thank you for your news article submission. Please note that all submissions are sent to moderation for admin approval. You will be notified when your submission is approved." with break line
        And Close Toast icon "toast|toastCloseIcon" is displayed
        And User clicks Close Toast icon "toast|toastCloseIcon"
        #Event article
        And User navigates to "EVENTS_PAGE"
        And User waits 2 seconds
        And Page URL is equal to "EVENTS_PAGE"
        And User clicks [Publish] button "header|publishButton"
        And User clicks Event button "modalWindow|eventIcon"
        #Header
        Then Modal header "createEventPage|modalHeader" with text "Publish Your" is displayed
        And Attribute "value" of Company Field "createEventPage|companyField" is equal to "CompAuto"
        And User selects item "option" with text "Webinar" from Event Types "createEventPage|eventTypeField"
        And User clicks Event Type Label "createEventPage|eventTypeFieldLabel"
        And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
        And User enters "$eventTitle" in Event Name field "createEventPage|eventNameField"
        And User enters "Edinburgh of the " in Location field "createEventPage|locationInput"
        And User clicks item "createEventPage|locationSelectList"
        And User clears text from Location field "createEventPage|locationField"
        And User enters "Edinburgh Partners" in Location field "createEventPage|locationField"
        And User clicks item "createEventPage|locationAutocompleteItem" with text "Edinburgh Partners"
        And User clicks Region dropdown "createEventPage|regionFieldDropdown" with text "Regions"
        And User clicks Region "createEventPage|regionOptionCheckboxLabel" with text "US" by executing script
        And User clicks Region dropdown "createEventPage|regionFieldDropdown" with text "Regions"
        And User clicks Calendar "createEventPage|datepickerStartDate"
        And User clicks Next month button "calendar|nextMonthButton"
        And User clicks Day in calendar "calendar|daysList" with text "23"
        And User clicks Header "createEventPage|modalHeader"
        And User enters "9:30 AM" in Start Time field "createEventPage|startTimeField"
        And User clicks Calendar "createEventPage|datepickerEndDate"
        And User clicks Next month button "calendar|nextMonthButton"
        And User clicks Day in calendar "calendar|daysList" with text "23"
        And User clicks Header "createEventPage|modalHeader"
        And User enters "5:00 PM" in End Time field "createEventPage|endTimeField"
        And User enters "https://events.climateaction.org/sustainable-investment-forum-europe/" in URL link field "createEventPage|urlLinkField"
        And User clicks item "createEventPage|taxonomyFieldOption" with text "Hot Topics"
        And User enters "markets & economy" in Tags field "createEventPage|tagsField"
        And User clicks item "createEventPage|tagsAutoCompleteItem" with text "Markets & Economy"
        And User enters "TEXT:Event_Excerpt" in Excerpt field "createEventPage|excerptField"
        And User enters "TEXT:Event_Content" in Content field "createEventPage|contentField" by executing script
        And User makes upload of file "featuredForEvent.png" using Upload field "createEventPage|attachmentFieldInput"
        And User clicks [Submit] button "createEventPage|Submit" with text "Submit"
        #Check toast notification
        And Page URL is equal to "EVENTS_PAGE"
        Then Success toast "toast|toastMessage" is displayed
        And Toast message "toast|toastMessage" text is equal to "Thank you for your event submission. Please note that all submissions are sent to moderation for admin approval. You will be notified when your submission is approved." with break line
        And Close Toast icon "toast|toastCloseIcon" is displayed
        And User clicks Close Toast icon "toast|toastCloseIcon"
        #[<user>] check notification drawer under bell icon when <user> has read and unread notifications
        And Bell icon "header|notificationButton" is displayed
        And User clicks Bell icon "header|notificationButton"
        And Notification component "header|notificationComponent" is displayed
        And Notification header "header|notificationHeader" is displayed
        And Notification header "header|notificationHeader" text is equal to " Notifications "
        And Mark All As Read "header|markAllAsRead" is displayed
        And Mark All As Read "header|markAllAsRead" text is equal to " Mark all as Read"
        And First notification message "header|firstNotificationMessage" is displayed
        And First notification Company Logo "header|firstNotificationCompanyLog" is displayed
        And First notification Company Logo "header|firstNotificationCompanyLog" text is equal to "C"
        And First notification Company Name "header|firstNotificationCompanyName" is displayed
        And First notification Company Name "header|firstNotificationCompanyName" text is equal to " CompAuto "
        And First notification message "header|firstNotificationText" is displayed
        And First notification message "header|firstNotificationText" text is equal to "000_Test_Auto_63f75cf0-a4a5-4493-b1cd-98bce0e563bb"
        And User clicks on first notification message "header|firstNotificationText"
        And Bell icon "header|notificationButton" is displayed
        And User clicks Bell icon "header|notificationButton"
        And Notification component "header|notificationComponent" is displayed
        And First check icon "header|firstNotificationCheckIcon" is displayed
        # <user> check 'See All' on notification drawer when user has more than 5 notifications
        And Mark All As Read "header|markAllAsRead" is displayed
        And Mark All As Read "header|markAllAsRead" text is equal to " Mark all as Read"
        And First notification message "header|firstNotificationMessage" is displayed
        And Second notification message "header|secondNotificationMessage" is displayed
        And Third notification message "header|thirdNotificationMessage" is displayed
        And Fourth notification message "header|fourthNotificationMessage" is displayed
        And Fifth notification message "header|fifthNotificationMessage" is displayed
        And See All "header|seeAllButton" is displayed
        And See All "header|seeAllButton" text is equal to "See All"
        And User clicks on See All "header|seeAllButton"
        And Notification page "notification|notificationHeader" is displayed
        And Notification page "notification|notificationHeader" text is equal to "Notifications"
        And Notification settings "notification|notificationSetting" is displayed
        And Notification settings "notification|notificationSetting" text is equal to " Notification settings "
        And Mark All As Read "notification|markAllAsReadButton" is displayed
        And Mark All As Read "notification|markAllAsReadButton" text is equal to " Mark all as Read"
        And First notification message "notification|firstNotificationMessage" is displayed
        And Second notification message "notification|secondNotificationMessage" is displayed
        And Third notification message "notification|thirdNotificationMessage" is displayed
        And Fourth notification message "notification|fourthNotificationMessage" is displayed
        And Fifth notification message "notification|fifthNotificationMessage" is displayed
        And Sixth notification message "notification|sixthNotificationMessage" is displayed
        #<user> check “Mark as Read” on notification page
        And User moves mouse over second notification message "notification|secondNotificationMessage"
        And User clicks on Mark as Read "notification|secondNotificationText"
        And Second notification check icon "notification|secondNotificationCheckIcon" is displayed

        Examples:
            | user          |
            | GLOBAL_ADMIN  |

    Scenario Outline: [<user>] check 'Mark all as Read' and 'See All' on notification drawer when user hasn't notifications
        When User logs in as "<user>" on "LOGIN_PAGE"
        Then Page URL is equal to "HOME_PAGE"
        And Bell icon "header|notificationButton" is displayed
        And User clicks Bell icon "header|notificationButton"
        And Notification component "header|notificationComponent" is displayed
        And Notification header "header|notificationHeader" is displayed
        And Notification header "header|notificationHeader" text is equal to " Notifications "
        And Mark All As Read "header|markAllAsRead" is not displayed
        And See All "header|seeAllButton" is not displayed
        And No new notifications "header|noNewNotification" text is equal to " No new notifications "

        Examples:
            | user        |
            | GLOBAL_USER |

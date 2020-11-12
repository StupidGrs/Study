@research
@researchDetails
Feature: Verify [Rate This] buttons behaviour on Research Details Page

    @rate
    @regression
    @knownIssue @knownIssue_sauce
    Scenario: User clicks [Rate This] buttons and checks displayed stars and hints
        #Precondition: create and approve research for different company
        When User "GLOBAL_ADMIN" logs in with API
        And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
        And User "GLOBAL_ADMIN" publishes "Research" with title "$researchTitle" and company "Mercer" with API
        And User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        Then User navigates to "Research" URL with title "$researchTitle"
        #verification
        When User clicks Star Icon in Left Block "researchDetailsPage|leftBlockRateThisStarIcon"
        Then Set Rating Block "setRatingBlock|starsBlock" is displayed
        # known issue
        # mouse over does not work in SauceLabs in IE\Edge
        When User moves mouse over 1st Star Icon "setRatingBlock|star1"
        Then Star Hint "setRatingBlock|starHint" with text "Poor" is displayed
        When User moves mouse over 2nd Star Icon "setRatingBlock|star2"
        Then Star Hint "setRatingBlock|starHint" with text "Fair" is displayed
        When User moves mouse over 3d Star Icon "setRatingBlock|star3"
        Then Star Hint "setRatingBlock|starHint" with text "Good" is displayed
        When User moves mouse over 4th Star Icon "setRatingBlock|star4"
        Then Star Hint "setRatingBlock|starHint" with text "Very Good" is displayed
        When User moves mouse over 5th Star Icon "setRatingBlock|star5"
        Then Star Hint "setRatingBlock|starHint" with text "Excellent" is displayed
        When User clicks Star Icon in Footer "researchDetailsPage|footerRateThisStarIcon" by executing script
        Then Set Rating Block "setRatingBlock|starsBlock" is displayed
        When User moves mouse over 1st Star Icon "setRatingBlock|star1"
        Then Star Hint "setRatingBlock|starHint" with text "Poor" is displayed
        When User moves mouse over 2nd Star Icon "setRatingBlock|star2"
        Then Star Hint "setRatingBlock|starHint" with text "Fair" is displayed
        When User moves mouse over 3d Star Icon "setRatingBlock|star3"
        Then Star Hint "setRatingBlock|starHint" with text "Good" is displayed
        When User moves mouse over 4th Star Icon "setRatingBlock|star4"
        Then Star Hint "setRatingBlock|starHint" with text "Very Good" is displayed
        When User moves mouse over 5th Star Icon "setRatingBlock|star5"
        Then Star Hint "setRatingBlock|starHint" with text "Excellent" is displayed
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @rate
    @regression
    Scenario: Verify User is able to Rate Research using Rating Elements from Left Block
        #Precondition: create and approve research for different company
        When User "GLOBAL_ADMIN" logs in with API
        And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
        And User "GLOBAL_ADMIN" publishes "Research" with title "$researchTitle" and company "Mercer" with API
        And User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        Then User navigates to "Research" URL with title "$researchTitle"
        #verification
        When User remembers text of "researchDetailsPage|headerRatingCount" as "original_ratings_count"
        #Rate article using elements from Left Block
        And User clicks Star Icon in Left Block "researchDetailsPage|leftBlockRateThisStarIcon"
        Then Set Rating Block "setRatingBlock|starsBlock" is displayed
        When User clicks 5th Star Icon "setRatingBlock|star5"
        Then Set Rating Block "setRatingBlock|starsBlock" is not displayed
        And User waits 2 seconds
        #Verify Rating applied and Rating elements are changed in the Left Block
        And Rate This "researchDetailsPage|leftBlockRateThisText" text is equal to "Your Rating: 5"
        #Verify Rating elements are changed in the Footer
        And Star Icon "researchDetailsPage|footerRateThisStarIcon" is not displayed
        And Rate This "researchDetailsPage|footerRateThisText" is not displayed
        And Rating Stars Set "researchDetailsPage|footerRatingStarsIconsSet" is displayed
        And Rating "researchDetailsPage|footerRatingCount" text is equal to "You rated this"
        #Verify Rating elements are changed in the Header
        And Total Rating Count "researchDetailsPage|headerRatingCount" value "$original_ratings_count" is increased by 1
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @rate
    @regression
    Scenario: Verify User is able to Rate Research using Rating Elements from Footer
        #Precondition: create and approve research for different company
        When User "GLOBAL_ADMIN" logs in with API
        And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
        And User "GLOBAL_ADMIN" publishes "Research" with title "$researchTitle" and company "Mercer" with API
        And User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        Then User navigates to "Research" URL with title "$researchTitle"
        #verification
        When User remembers text of "researchDetailsPage|headerRatingCount" as "original_ratings_count"
        #Rate article using elements from Footer
        And User clicks Star Icon in Footer "researchDetailsPage|footerRateThisStarIcon" by executing script
        Then Set Rating Block "setRatingBlock|starsBlock" is displayed
        When User clicks 1st Star Icon "setRatingBlock|star1" by executing script
        Then Set Rating Block "setRatingBlock|starsBlock" is not displayed
        And User waits 2 seconds
        #Verify Rating applied and Rating elements are changed in the Left Block
        And Rate This "researchDetailsPage|leftBlockRateThisText" text is equal to "Your Rating: 1"
        #Verify Rating elements are changed in the Footer
        And Star Icon "researchDetailsPage|footerRateThisStarIcon" is not displayed
        And Rate This "researchDetailsPage|footerRateThisText" is not displayed
        And Rating Stars Set "researchDetailsPage|footerRatingStarsIconsSet" is displayed
        And Rating "researchDetailsPage|footerRatingCount" text is equal to "You rated this"
        #Verify Rating elements are changed in the Header
        And Total Rating Count "researchDetailsPage|headerRatingCount" value "$original_ratings_count" is increased by 1
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"

    @rate
    @regression
    Scenario Outline: Verify User [<user>] is NOT able to Rate Research of his Company
        #Precondition: create and approve research for different company
        When User "GLOBAL_ADMIN" logs in with API
        And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
        And User "GLOBAL_ADMIN" publishes "Research" with title "$researchTitle" with API
        And User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API
        When User logs in as "<user>" on "LOGIN_PAGE"
        Then User navigates to "Research" URL with title "$researchTitle"
        #verification
        When User remembers text of "researchDetailsPage|headerRatingCount" as "original_ratings_count"
        #Rate article using elements from Left Block
        And User clicks Star Icon in Left Block "researchDetailsPage|leftBlockRateThisStarIcon"
        Then Set Rating Block "setRatingBlock|starsBlock" is displayed
        When User clicks 5th Star Icon "setRatingBlock|star5"
        #verify error message
        Then Toast message "toast|toastMessage" is displayed
        And Toast message "toast|toastMessage" text is equal to "TEXT:Rate_content_toast"
        #TODO: Uncomment "When User clicks Close button" step when bug is fixed
        #When User clicks Close button "toast|toastCloseIcon"
        #Verify Rating not applied and Rating elements are not changed in the Left Block
        #TODO: Edge issue: Investigate why "starsBlock" does not disappear even after click on other elements
        And User clicks Title "researchDetailsPage|title"
        Then Set Rating Block "setRatingBlock|starsBlock" is not displayed
        And Star Icon "researchDetailsPage|leftBlockRateThisStarIcon" is displayed
        And Rate This "researchDetailsPage|leftBlockRateThisText" text is equal to "Rate This"
        #Verify Rating elements are not changed in the Footer
        And Star Icon "researchDetailsPage|footerRateThisStarIcon" is displayed
        And Rate This "researchDetailsPage|footerRateThisText" text is equal to "Rate This"
        And Rating Stars Set "researchDetailsPage|footerRatingStarsIconsSet" is displayed
        And Rating Stars "researchDetailsPage|footerRatingStarsIconsList" count is equal to 5
        And Rating Count "researchDetailsPage|footerRatingCount" is displayed
        #Verify Rating elements are changed in the Header
        And Total Rating Count "researchDetailsPage|headerRatingCount" text is equal to "$original_ratings_count"
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle"
        Examples:
            | user          |
            | COMPANY_ADMIN |
            | GLOBAL_ADMIN  |
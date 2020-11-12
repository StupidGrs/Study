Feature: User check the rating modal in the News page
  @regression
  @knownIssue @SRC-788

  Scenario: User check the rating modal show once for every 3 News article read
    #Create research with all fields
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_News" with added unique Id as "newsTitle"
    Then User "COMPANY_ADMIN" publishes "News" with all fields and title "$newsTitle" with API
   #Approve research
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" approves "News" with title "$newsTitle" with API
   #Login and open research
    When User logs in as "GLOBAL_USER" on "LOGIN_PAGE"
    And User navigates to "News" URL with title "$newsTitle"
   # Verify Header elements
    Then News Title "newsDetailsPage|title" text is equal to "$newsTitle"
    And Star Icon "newsDetailsPage|leftBlockRateThisStarIcon" is displayed
    And Rate This "newsDetailsPage|leftBlockRateThisText" text is equal to "Rate This"
    #Verify Rating elements are changed in the Footer
    And Star Icon "newsDetailsPage|footerRateThisStarIcon" is displayed
    And Rate This "newsDetailsPage|footerRateThisText" is displayed
#  Three times clicking on the external link
    And [Read the Full Article] button "newsDetailsPage|readFullButtonLink" is displayed
    And User clicks [Read the Full Article] button "newsDetailsPage|readFullButtonLink"
    And User goes to 1 browser tab
    And User clicks [Read the Full Article] button "newsDetailsPage|readFullButtonLink"
    And User goes to 1 browser tab
    And User clicks [Read the Full Article] button "newsDetailsPage|readFullButtonLink"
    And User goes to 1 browser tab
    And Rating modal "newsDetailsPage|ratingModalTitle" is displayed
    And [X] button "newsDetailsPage|ratingModalXButton" is displayed
    And User clicks [X] button "newsDetailsPage|ratingModalXButton"
    And Rating modal "newsDetailsPage|ratingModalTitle" is not displayed
  #Verify Rating elements are changed in the Footer
    And Star Icon "newsDetailsPage|footerRateThisStarIcon" is displayed
    And Rate This "newsDetailsPage|footerRateThisText" is displayed
  #Three times clicking on the download document
    And First attachment file "newsDetailsPage|downloadFirstAttachmentFile" is displayed
    And User clicks download first attachment file "newsDetailsPage|downloadFirstAttachmentFile"
    And User clicks download first attachment file "newsDetailsPage|downloadFirstAttachmentFile"
    And User clicks download first attachment file "newsDetailsPage|downloadFirstAttachmentFile"
    And Rating modal "newsDetailsPage|ratingModalTitle" is displayed
    And [X] button "newsDetailsPage|ratingModalXButton" is displayed
    And User clicks [X] button "newsDetailsPage|ratingModalXButton"
    And Rating modal "newsDetailsPage|ratingModalTitle" is not displayed
  #Verify Rating elements are changed in the Footer
    And Star Icon "newsDetailsPage|footerRateThisStarIcon" is displayed
    And Rate This "newsDetailsPage|footerRateThisText" is displayed
#    wait 80% of read time
    And User clicks [Read the Full Article] button "newsDetailsPage|readFullButtonLink"
    And User goes to 1 browser tab
    And User clicks [Read the Full Article] button "newsDetailsPage|readFullButtonLink"
    And User goes to 1 browser tab
    And User waits 97 seconds
    And Rating modal "newsDetailsPage|ratingModalTitle" is displayed

  Scenario Outline: SRC user check the rating modal
   #Create research with all fields
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_News" with added unique Id as "newsTitle"
    Then User "COMPANY_ADMIN" publishes "News" with all fields and title "$newsTitle" with API
   #Approve research
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" approves "News" with title "$newsTitle" with API
   #Login and open research
    When User logs in as "GLOBAL_USER" on "LOGIN_PAGE"
    And User navigates to "News" URL with title "$newsTitle"
   # Verify Header elements
    Then News Title "newsDetailsPage|title" text is equal to "$newsTitle"
   #  Three times clicking on the external link
    And [Read the Full Article] button "newsDetailsPage|readFullButtonLink" is displayed
    And User clicks [Read the Full Article] button "newsDetailsPage|readFullButtonLink"
    And User goes to 1 browser tab
    And User clicks [Read the Full Article] button "newsDetailsPage|readFullButtonLink"
    And User goes to 1 browser tab
    And User clicks [Read the Full Article] button "newsDetailsPage|readFullButtonLink"
    And User goes to 1 browser tab
    And Rating modal "newsDetailsPage|ratingModalTitle" is displayed
    And Rating modal label "newsDetailsPage|ratingModalTitle" text is equal to " Enjoying This Content? "
    And Rating modal first line "newsDetailsPage|ratingModalTextFirstLine" text is equal to "<text>" with break line
    And Poor rating star "newsDetailsPage|ratingModalFirstRatingStar" is displayed
    And User moves mouse over 1st Star Icon "newsDetailsPage|ratingModalFirstRatingStar"
    And Star Hint "newsDetailsPage|ratingModalToolTips" with text "Poor" is displayed
    And Fair rating star "newsDetailsPage|ratingModalSecondRatingStar" is displayed
    And User moves mouse over 2st Star Icon "newsDetailsPage|ratingModalSecondRatingStar"
    And Star Hint "newsDetailsPage|ratingModalToolTips" with text "Fair" is displayed
    And Good rating star "newsDetailsPage|ratingModalThirdRatingStar" is displayed
    And User moves mouse over 3st Star Icon "newsDetailsPage|ratingModalThirdRatingStar"
    And Star Hint "newsDetailsPage|ratingModalToolTips" with text "Good" is displayed
    And Very Good rating star "newsDetailsPage|ratingModalFourthRatingStar" is displayed
    And User moves mouse over 3st Star Icon "newsDetailsPage|ratingModalFourthRatingStar"
    And Star Hint "newsDetailsPage|ratingModalToolTips" with text "Very Good" is displayed
    And Excellent rating star "newsDetailsPage|ratingModalFifthRatingStar" is displayed
    And User moves mouse over 3st Star Icon "newsDetailsPage|ratingModalFifthRatingStar"
    And Star Hint "newsDetailsPage|ratingModalToolTips" with text "Excellent" is displayed
    And Information text in the rating modal "newsDetailsPage|ratingModalInformationText" is displayed
    And Information text in the rating modal "newsDetailsPage|ratingModalInformationText" text is equal to " Tap a star to rate it. "
    And User clicks Good rating star "newsDetailsPage|ratingModalThirdRatingStar"
    And Rating modal "newsDetailsPage|ratingModalTitle" is not displayed
      # Rate This elements in the Left block
    And User waits 2 seconds
    And Star Icon "newsDetailsPage|leftBlockRateThisStarIcon" is displayed
    And Rate This "newsDetailsPage|leftBlockRateThisText" text is equal to "Your Rating: 3"
      #Verify Rating elements are changed in the Footer
    And Star Icon "newsDetailsPage|footerRateThisStarIcon" is not displayed
    And Rate This "newsDetailsPage|footerRateThisText" is not displayed
    And Rating Stars Set "newsDetailsPage|footerRatingStarsIconsSet" is displayed
    And Rating "newsDetailsPage|footerRatingCount" text is equal to "You rated this"

    Examples:
    |text                                                                                                                                         |
    |Please take a moment to rate the content you are reading. The Strategic Research Community works best when the entire community participates.|

  Scenario Outline: SRC user check the rating modal not show
   #Create research with all fields
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_News" with added unique Id as "newsTitle"
    Then User "COMPANY_ADMIN" publishes "News" with all fields and title "$newsTitle" with API
   #Approve research
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" approves "News" with title "$newsTitle" with API
   #Login and open research
    When User logs in as "GLOBAL_USER" on "LOGIN_PAGE"
    And User navigates to "News" URL with title "$newsTitle"
   # Verify Header elements
    Then News Title "newsDetailsPage|title" text is equal to "$newsTitle"
   #  Three times clicking on the external link
    And [Read the Full Article] button "newsDetailsPage|readFullButtonLink" is displayed
    And User clicks [Read the Full Article] button "newsDetailsPage|readFullButtonLink"
    And User goes to 1 browser tab
    And User clicks [Read the Full Article] button "newsDetailsPage|readFullButtonLink"
    And User goes to 1 browser tab
    And User clicks [Read the Full Article] button "newsDetailsPage|readFullButtonLink"
    And User goes to 1 browser tab
    And Rating modal "newsDetailsPage|ratingModalTitle" is displayed
    And Rating modal label "newsDetailsPage|ratingModalTitle" text is equal to " Enjoying This Content? "
    And Rating modal first line "newsDetailsPage|ratingModalTextFirstLine" text is equal to "<text>" with break line
    And Poor rating star "newsDetailsPage|ratingModalFirstRatingStar" is displayed
    And User waits 2 seconds
    And Poor rating star "newsDetailsPage|ratingModalFirstRatingStar" is displayed
    And User moves mouse over 1st Star Icon "newsDetailsPage|ratingModalFirstRatingStar"
    And Star Hint "newsDetailsPage|ratingModalToolTips" with text "Poor" is displayed
    And Fair rating star "newsDetailsPage|ratingModalSecondRatingStar" is displayed
    And User moves mouse over 2st Star Icon "newsDetailsPage|ratingModalSecondRatingStar"
    And Star Hint "newsDetailsPage|ratingModalToolTips" with text "Fair" is displayed
    And Good rating star "newsDetailsPage|ratingModalThirdRatingStar" is displayed
    And User moves mouse over 3st Star Icon "newsDetailsPage|ratingModalThirdRatingStar"
    And Star Hint "newsDetailsPage|ratingModalToolTips" with text "Good" is displayed
    And Very Good rating star "newsDetailsPage|ratingModalFourthRatingStar" is displayed
    And User moves mouse over 3st Star Icon "newsDetailsPage|ratingModalFourthRatingStar"
    And Star Hint "newsDetailsPage|ratingModalToolTips" with text "Very Good" is displayed
    And Excellent rating star "newsDetailsPage|ratingModalFifthRatingStar" is displayed
    And User moves mouse over 3st Star Icon "newsDetailsPage|ratingModalFifthRatingStar"
    And Star Hint "newsDetailsPage|ratingModalToolTips" with text "Excellent" is displayed
    And Information text in the rating modal "newsDetailsPage|ratingModalInformationText" is displayed
    And Information text in the rating modal "newsDetailsPage|ratingModalInformationText" text is equal to " Tap a star to rate it. "
    And User clicks Very Good rating star "newsDetailsPage|ratingModalFourthRatingStar"
    And Rating modal "newsDetailsPage|ratingModalTitle" is not displayed
      # Rate This elements in the Left block
    And User waits 2 seconds
    And Star Icon "newsDetailsPage|leftBlockRateThisStarIcon" is displayed
    And Rate This "newsDetailsPage|leftBlockRateThisText" text is equal to "Your Rating: 4"
      #Verify Rating elements are changed in the Footer
    And Star Icon "newsDetailsPage|footerRateThisStarIcon" is not displayed
    And Rate This "newsDetailsPage|footerRateThisText" is not displayed
    And Rating Stars Set "newsDetailsPage|footerRatingStarsIconsSet" is displayed
    And Rating "newsDetailsPage|footerRatingCount" text is equal to "You rated this"
     #  Three times clicking on the external link
    And [Read the Full Article] button "newsDetailsPage|readFullButtonLink" is displayed
    And User clicks [Read the Full Article] button "newsDetailsPage|readFullButtonLink"
    And User goes to 1 browser tab
    And User clicks [Read the Full Article] button "newsDetailsPage|readFullButtonLink"
    And User goes to 1 browser tab
    And User clicks [Read the Full Article] button "newsDetailsPage|readFullButtonLink"
    And User goes to 1 browser tab
    And Rating modal "newsDetailsPage|ratingModalTitle" is not displayed
#Verify Rating elements are changed in the Footer
    And Star Icon "newsDetailsPage|footerRateThisStarIcon" is not displayed
    And Rate This "newsDetailsPage|footerRateThisText" is not displayed
    And Rating Stars Set "newsDetailsPage|footerRatingStarsIconsSet" is displayed
    And Rating "newsDetailsPage|footerRatingCount" text is equal to "You rated this"
# Three times clicking on the download document
    And First attachment file "newsDetailsPage|downloadFirstAttachmentFile" is displayed
    And User clicks download first attachment file "newsDetailsPage|downloadFirstAttachmentFile"
    And User clicks download first attachment file "newsDetailsPage|downloadFirstAttachmentFile"
    And User clicks download first attachment file "newsDetailsPage|downloadFirstAttachmentFile"
    And Rating modal "newsDetailsPage|ratingModalTitle" is not displayed
    #Verify Rating elements are changed in the Footer
    And Star Icon "newsDetailsPage|footerRateThisStarIcon" is not displayed
    And Rate This "newsDetailsPage|footerRateThisText" is not displayed
    And Rating Stars Set "newsDetailsPage|footerRatingStarsIconsSet" is displayed
    And Rating "newsDetailsPage|footerRatingCount" text is equal to "You rated this"

    Examples:
      |text                                                                                                                                         |
      |Please take a moment to rate the content you are reading. The Strategic Research Community works best when the entire community participates.|

  Scenario: SRC user check the rating modal not show when user and News article has same company
   #Create research with all fields
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_News" with added unique Id as "newsTitle"
    Then User "COMPANY_ADMIN" publishes "News" with all fields and title "$newsTitle" with API
   #Approve research
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" approves "News" with title "$newsTitle" with API
   #Login and open research
    When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
    And User navigates to "News" URL with title "$newsTitle"
   # Verify Header elements
    Then News Title "newsDetailsPage|title" text is equal to "$newsTitle"
     #  Three times clicking on the external link
    And [Read the Full Article] button "newsDetailsPage|readFullButtonLink" is displayed
    And User clicks [Read the Full Article] button "newsDetailsPage|readFullButtonLink"
    And User goes to 1 browser tab
    And User clicks [Read the Full Article] button "newsDetailsPage|readFullButtonLink"
    And User goes to 1 browser tab
    And User clicks [Read the Full Article] button "newsDetailsPage|readFullButtonLink"
    And User goes to 1 browser tab
    And Rating modal "newsDetailsPage|ratingModalTitle" is not displayed
    #Verify Rating elements are changed in the Footer
    And Star Icon "newsDetailsPage|footerRateThisStarIcon" is displayed
    And Rate This "newsDetailsPage|footerRateThisText" is displayed
# Three times clicking on the download document
    And First attachment file "newsDetailsPage|downloadFirstAttachmentFile" is displayed
    And User clicks download first attachment file "newsDetailsPage|downloadFirstAttachmentFile"
    And User clicks download first attachment file "newsDetailsPage|downloadFirstAttachmentFile"
    And User clicks download first attachment file "newsDetailsPage|downloadFirstAttachmentFile"
    And Rating modal "newsDetailsPage|ratingModalTitle" is not displayed
  #Verify Rating elements are changed in the Footer
    And Star Icon "newsDetailsPage|footerRateThisStarIcon" is displayed
    And Rate This "newsDetailsPage|footerRateThisText" is displayed

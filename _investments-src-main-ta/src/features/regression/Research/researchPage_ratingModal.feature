@research
Feature: User check the rating modal in the Research page
  @regression
  @knownIssue @SRC-788

  Scenario: User check the rating modal show once for every 3 Research article read
   #Create research with all fields
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_ADMIN" publishes "Research" with all fields and title "$researchTitle" with API
   #Approve research
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API
   #Login and open research
    When User logs in as "GLOBAL_USER" on "LOGIN_PAGE"
    And User navigates to "Research" URL with title "$researchTitle"
   # Verify Header elements
    Then Research Title "researchDetailsPage|title" text is equal to "$researchTitle"
    And Star Icon "researchDetailsPage|leftBlockRateThisStarIcon" is displayed
    And Rate This "researchDetailsPage|leftBlockRateThisText" text is equal to "Rate This"
    #Verify Rating elements are changed in the Footer
    And Star Icon "researchDetailsPage|footerRateThisStarIcon" is displayed
    And Rate This "researchDetailsPage|footerRateThisText" is displayed
#  Three times clicking on the external link
    And [Visit External Link] button "researchDetailsPage|visitExternalLinkButton" is displayed
    And User clicks [Visit External Link] button "researchDetailsPage|visitExternalLinkButton"
    And User goes to 1 browser tab
    And User clicks [Visit External Link] button "researchDetailsPage|visitExternalLinkButton"
    And User goes to 1 browser tab
    And User clicks [Visit External Link] button "researchDetailsPage|visitExternalLinkButton"
    And User goes to 1 browser tab
    And Rating modal "researchDetailsPage|ratingModalTitle" is displayed
    And [X] button "researchDetailsPage|ratingModalXButton" is displayed
    And User clicks [X] button "researchDetailsPage|ratingModalXButton"
    And Rating modal "researchDetailsPage|ratingModalTitle" is not displayed
    #Verify Rating elements are changed in the Footer
    And Star Icon "researchDetailsPage|footerRateThisStarIcon" is displayed
    And Rate This "researchDetailsPage|footerRateThisText" is displayed
# Three times clicking on the download document
    And First attachment file "researchDetailsPage|downloadFirstAttachmentFile" is displayed
    And User clicks download first attachment file "researchDetailsPage|downloadFirstAttachmentFile"
    And User clicks download first attachment file "researchDetailsPage|downloadFirstAttachmentFile"
    And User clicks download first attachment file "researchDetailsPage|downloadFirstAttachmentFile"
    And Rating modal "researchDetailsPage|ratingModalTitle" is displayed
    And [X] button "researchDetailsPage|ratingModalXButton" is displayed
    And User clicks [X] button "researchDetailsPage|ratingModalXButton"
    And Rating modal "researchDetailsPage|ratingModalTitle" is not displayed
  #Verify Rating elements are changed in the Footer
    And Star Icon "researchDetailsPage|footerRateThisStarIcon" is displayed
    And Rate This "researchDetailsPage|footerRateThisText" is displayed
#    wait 80% of read time
    And User clicks [Read the Full Article] button "researchDetailsPage|readFullButtonLink"
    And User goes to 1 browser tab
    And User clicks [Read the Full Article] button "researchDetailsPage|readFullButtonLink"
    And User goes to 1 browser tab
    And User waits 97 seconds
    And Rating modal "researchDetailsPage|ratingModalTitle" is displayed

  Scenario Outline: SRC user check the rating modal
   #Create research with all fields
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_ADMIN" publishes "Research" with all fields and title "$researchTitle" with API
   #Approve research
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API
   #Login and open research
    When User logs in as "GLOBAL_USER" on "LOGIN_PAGE"
    And User navigates to "Research" URL with title "$researchTitle"
   # Verify Header elements
    Then Research Title "researchDetailsPage|title" text is equal to "$researchTitle"
   #  Three times clicking on the external link
    And [Visit External Link] button "researchDetailsPage|visitExternalLinkButton" is displayed
    And User clicks [Visit External Link] button "researchDetailsPage|visitExternalLinkButton"
    And User goes to 1 browser tab
    And User clicks [Visit External Link] button "researchDetailsPage|visitExternalLinkButton"
    And User goes to 1 browser tab
    And User clicks [Visit External Link] button "researchDetailsPage|visitExternalLinkButton"
    And User goes to 1 browser tab
    And Rating modal "researchDetailsPage|ratingModalTitle" is displayed
    And Rating modal label "researchDetailsPage|ratingModalTitle" text is equal to " Enjoying This Content? "
    And Rating modal first line "researchDetailsPage|ratingModalTextFirstLine" text is equal to "<text>" with break line
    And Poor rating star "researchDetailsPage|ratingModalFirstRatingStar" is displayed
    And User moves mouse over 1st Star Icon "researchDetailsPage|ratingModalFirstRatingStar"
    And Star Hint "researchDetailsPage|ratingModalToolTips" with text "Poor" is displayed
    And Fair rating star "researchDetailsPage|ratingModalSecondRatingStar" is displayed
    And User moves mouse over 2st Star Icon "researchDetailsPage|ratingModalSecondRatingStar"
    And Star Hint "researchDetailsPage|ratingModalToolTips" with text "Fair" is displayed
    And Good rating star "researchDetailsPage|ratingModalThirdRatingStar" is displayed
    And User moves mouse over 3st Star Icon "researchDetailsPage|ratingModalThirdRatingStar"
    And Star Hint "researchDetailsPage|ratingModalToolTips" with text "Good" is displayed
    And Very Good rating star "researchDetailsPage|ratingModalFourthRatingStar" is displayed
    And User moves mouse over 3st Star Icon "researchDetailsPage|ratingModalFourthRatingStar"
    And Star Hint "researchDetailsPage|ratingModalToolTips" with text "Very Good" is displayed
    And Excellent rating star "researchDetailsPage|ratingModalFifthRatingStar" is displayed
    And User moves mouse over 3st Star Icon "researchDetailsPage|ratingModalFifthRatingStar"
    And Star Hint "researchDetailsPage|ratingModalToolTips" with text "Excellent" is displayed
    And Information text in the rating modal "researchDetailsPage|ratingModalInformationText" is displayed
    And Information text in the rating modal "researchDetailsPage|ratingModalInformationText" text is equal to " Tap a star to rate it. "
    And User clicks Good rating star "researchDetailsPage|ratingModalThirdRatingStar"
    And Rating modal "researchDetailsPage|ratingModalTitle" is not displayed
      # Rate This elements in the Left block
    And User waits 2 seconds
    And Star Icon "researchDetailsPage|leftBlockRateThisStarIcon" is displayed
    And Rate This "researchDetailsPage|leftBlockRateThisText" text is equal to "Your Rating: 3"
      #Verify Rating elements are changed in the Footer
    And Star Icon "researchDetailsPage|footerRateThisStarIcon" is not displayed
    And Rate This "researchDetailsPage|footerRateThisText" is not displayed
    And Rating Stars Set "researchDetailsPage|footerRatingStarsIconsSet" is displayed
    And Rating "researchDetailsPage|footerRatingCount" text is equal to "You rated this"

    Examples:
      |text                                                                                                                                         |
      |Please take a moment to rate the content you are reading. The Strategic Research Community works best when the entire community participates.|

  Scenario Outline: SRC user check the rating modal not show
   #Create research with all fields
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_ADMIN" publishes "Research" with all fields and title "$researchTitle" with API
   #Approve research
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API
   #Login and open research
    When User logs in as "GLOBAL_USER" on "LOGIN_PAGE"
    And User navigates to "Research" URL with title "$researchTitle"
   # Verify Header elements
    Then Research Title "researchDetailsPage|title" text is equal to "$researchTitle"
   #  Three times clicking on the external link
    And [Visit External Link] button "researchDetailsPage|visitExternalLinkButton" is displayed
    And User clicks [Visit External Link] button "researchDetailsPage|visitExternalLinkButton"
    And User goes to 1 browser tab
    And User clicks [Visit External Link] button "researchDetailsPage|visitExternalLinkButton"
    And User goes to 1 browser tab
    And User clicks [Visit External Link] button "researchDetailsPage|visitExternalLinkButton"
    And User goes to 1 browser tab
    And Rating modal "researchDetailsPage|ratingModalTitle" is displayed
    And Rating modal label "researchDetailsPage|ratingModalTitle" text is equal to " Enjoying This Content? "
    And Rating modal first line "researchDetailsPage|ratingModalTextFirstLine" text is equal to "<text>" with break line
    And Poor rating star "researchDetailsPage|ratingModalFirstRatingStar" is displayed
    And User waits 2 seconds
    And Poor rating star "researchDetailsPage|ratingModalFirstRatingStar" is displayed
    And User moves mouse over 1st Star Icon "researchDetailsPage|ratingModalFirstRatingStar"
    And Star Hint "researchDetailsPage|ratingModalToolTips" with text "Poor" is displayed
    And Fair rating star "researchDetailsPage|ratingModalSecondRatingStar" is displayed
    And User moves mouse over 2st Star Icon "researchDetailsPage|ratingModalSecondRatingStar"
    And Star Hint "researchDetailsPage|ratingModalToolTips" with text "Fair" is displayed
    And Good rating star "researchDetailsPage|ratingModalThirdRatingStar" is displayed
    And User moves mouse over 3st Star Icon "researchDetailsPage|ratingModalThirdRatingStar"
    And Star Hint "researchDetailsPage|ratingModalToolTips" with text "Good" is displayed
    And Very Good rating star "researchDetailsPage|ratingModalFourthRatingStar" is displayed
    And User moves mouse over 3st Star Icon "researchDetailsPage|ratingModalFourthRatingStar"
    And Star Hint "researchDetailsPage|ratingModalToolTips" with text "Very Good" is displayed
    And Excellent rating star "researchDetailsPage|ratingModalFifthRatingStar" is displayed
    And User moves mouse over 3st Star Icon "researchDetailsPage|ratingModalFifthRatingStar"
    And Star Hint "researchDetailsPage|ratingModalToolTips" with text "Excellent" is displayed
    And Information text in the rating modal "researchDetailsPage|ratingModalInformationText" is displayed
    And Information text in the rating modal "researchDetailsPage|ratingModalInformationText" text is equal to " Tap a star to rate it. "
    And User clicks Very Good rating star "researchDetailsPage|ratingModalFourthRatingStar"
    And Rating modal "researchDetailsPage|ratingModalTitle" is not displayed
      # Rate This elements in the Left block
    And User waits 2 seconds
    And Star Icon "researchDetailsPage|leftBlockRateThisStarIcon" is displayed
    And Rate This "researchDetailsPage|leftBlockRateThisText" text is equal to "Your Rating: 4"
          #Verify Rating elements are changed in the Footer
    And Star Icon "researchDetailsPage|footerRateThisStarIcon" is not displayed
    And Rate This "researchDetailsPage|footerRateThisText" is not displayed
    And Rating Stars Set "researchDetailsPage|footerRatingStarsIconsSet" is displayed
    And Rating "researchDetailsPage|footerRatingCount" text is equal to "You rated this"
     #  Three times clicking on the external link
    And [Visit External Link] button "researchDetailsPage|visitExternalLinkButton" is displayed
    And User clicks [Visit External Link] button "researchDetailsPage|visitExternalLinkButton"
    And User goes to 1 browser tab
    And User clicks [Visit External Link] button "researchDetailsPage|visitExternalLinkButton"
    And User goes to 1 browser tab
    And User clicks [Visit External Link] button "researchDetailsPage|visitExternalLinkButton"
    And User goes to 1 browser tab
    And Rating modal "researchDetailsPage|ratingModalTitle" is not displayed
#Verify Rating elements are changed in the Footer
    And Star Icon "researchDetailsPage|footerRateThisStarIcon" is not displayed
    And Rate This "researchDetailsPage|footerRateThisText" is not displayed
    And Rating Stars Set "researchDetailsPage|footerRatingStarsIconsSet" is displayed
    And Rating "researchDetailsPage|footerRatingCount" text is equal to "You rated this"
# Three times clicking on the download document
    And First attachment file "researchDetailsPage|downloadFirstAttachmentFile" is displayed
    And User clicks download first attachment file "researchDetailsPage|downloadFirstAttachmentFile"
    And User clicks download first attachment file "researchDetailsPage|downloadFirstAttachmentFile"
    And User clicks download first attachment file "researchDetailsPage|downloadFirstAttachmentFile"
    And Rating modal "researchDetailsPage|ratingModalTitle" is not displayed
#Verify Rating elements are changed in the Footer
    And Star Icon "researchDetailsPage|footerRateThisStarIcon" is not displayed
    And Rate This "researchDetailsPage|footerRateThisText" is not displayed
    And Rating Stars Set "researchDetailsPage|footerRatingStarsIconsSet" is displayed
    And Rating "researchDetailsPage|footerRatingCount" text is equal to "You rated this"

    Examples:
      |text                                                                                                                                         |
      |Please take a moment to rate the content you are reading. The Strategic Research Community works best when the entire community participates.|

  Scenario: SRC user check the rating modal not show when user and Research article has same company
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
   # Verify Header elements
    Then Research Title "researchDetailsPage|title" text is equal to "$researchTitle"
     #  Three times clicking on the external link
    And [Visit External Link] button "researchDetailsPage|visitExternalLinkButton" is displayed
    And User clicks [Visit External Link] button "researchDetailsPage|visitExternalLinkButton"
    And User goes to 1 browser tab
    And User clicks [Visit External Link] button "researchDetailsPage|visitExternalLinkButton"
    And User goes to 1 browser tab
    And User clicks [Visit External Link] button "researchDetailsPage|visitExternalLinkButton"
    And User goes to 1 browser tab
    And Rating modal "researchDetailsPage|ratingModalTitle" is not displayed
          #Verify Rating elements are changed in the Footer
    And Star Icon "researchDetailsPage|footerRateThisStarIcon" is displayed
    And Rate This "researchDetailsPage|footerRateThisText" is displayed
# Three times clicking on the download document
    And First attachment file "researchDetailsPage|downloadFirstAttachmentFile" is displayed
    And User clicks download first attachment file "researchDetailsPage|downloadFirstAttachmentFile"
    And User clicks download first attachment file "researchDetailsPage|downloadFirstAttachmentFile"
    And User clicks download first attachment file "researchDetailsPage|downloadFirstAttachmentFile"
    And Rating modal "researchDetailsPage|ratingModalTitle" is not displayed
          #Verify Rating elements are changed in the Footer
    And Star Icon "researchDetailsPage|footerRateThisStarIcon" is displayed
    And Rate This "researchDetailsPage|footerRateThisText" is displayed
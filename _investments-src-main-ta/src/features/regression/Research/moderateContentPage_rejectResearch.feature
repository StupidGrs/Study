@research
Feature: Global Admin rejects Pending/Approved Research with row action button Reject 

  Background:
    Given User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle" with API

  @smoke
  @regression
  Scenario: Verify text and buttons on Reject popup
    When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "header|settingsButton"
    And User clicks Moderate Content link "header|moderateContentLink" by executing script
    And User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
    And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
    And User waits for Table Row "contentListPage|tableRowsList" with text "$researchTitle" visibility within 3 seconds
    And User clicks [Reject] button "contentListPage|tableRowRejectButtonsList"
    Then Reject Popup Header "contentListPage|rejectPopupHeaderText" with text "Enter your reason for rejection" is displayed
    And Reject Popup Reason Input field "contentListPage|rejectPopupInputField" is displayed
    And Attribute "value" of Reject Popup Reason Input field "contentListPage|rejectPopupInputField" is equal to ""
    And Attribute "placeholder" of Reject Popup Reason Input field "contentListPage|rejectPopupInputField" is equal to "Please enter your reason here"
    And Reject Popup [Cancel] button "contentListPage|rejectPopupCancelButton" is displayed
    And Reject Popup [Reject] button "contentListPage|rejectPopupRejectButton" is displayed
    And Reject Popup [Close] button "contentListPage|rejectPopupСloseButton" is displayed
    And User deletes "Research" with "Title" equal to "$researchTitle"

  @smoke
  @regression
  Scenario: Global Admin clicks [Close] button on Reject popup
    When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "header|settingsButton"
    And User clicks Moderate Content link "header|moderateContentLink" by executing script
    And User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
    And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
    And User waits for Table Row "contentListPage|tableRowsList" with text "$researchTitle" visibility within 3 seconds
    When User clicks [Reject] button "contentListPage|tableRowRejectButtonsList"
    And User clicks [Close] Reject Popup button "contentListPage|rejectPopupСloseButton"
    Then Reject Popup Header "contentListPage|rejectPopupHeaderText" is not displayed
    And Table Row "contentListPage|tableRowsList" with text "$researchTitle" is displayed
    And User deletes "Research" with "Title" equal to "$researchTitle"

  @smoke
  @regression
  Scenario:[Pending Research] Global Admin clicks [Reject] and specifies the reason
    When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "header|settingsButton"
    And User clicks Moderate Content link "header|moderateContentLink" by executing script
    And User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
    And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
    And User waits for Table Row "contentListPage|tableRowsList" with text "$researchTitle" visibility within 3 seconds
    When User clicks [Reject] button "contentListPage|tableRowRejectButtonsList"
    When User enters "Test_Auto - Reject reason for " in Reject Reason Input field "contentListPage|rejectPopupInputField"
    And User enters "$researchTitle" in Reject Reason Input field "contentListPage|rejectPopupInputField"
    And User clicks [Reject] button "contentListPage|rejectPopupRejectButton"
    Then Reject Popup Header "contentListPage|rejectPopupHeaderText" is not displayed
    And Table Row "contentListPage|tableRowsList" with text "$researchTitle" is not displayed
    When User selects item "option" with text "Rejected" from Article Status dropdown "contentListPage|articleStatusDropdown"
    Then Table Row "contentListPage|tableRowsList" with text "$researchTitle" is displayed
    And User deletes "Research" with "Title" equal to "$researchTitle"

  @smoke
  @regression
  Scenario:[Pending Research] Global Admin clicks [Reject] without specifying the reason
    When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "header|settingsButton"
    And User clicks Moderate Content link "header|moderateContentLink" by executing script
    And User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
    And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
    And User waits for Table Row "contentListPage|tableRowsList" with text "$researchTitle" visibility within 3 seconds
    When User clicks [Reject] button "contentListPage|tableRowRejectButtonsList"
    And User clicks [Reject] button "contentListPage|rejectPopupRejectButton"
    Then Reject Popup Header "contentListPage|rejectPopupHeaderText" is not displayed
    And Table Row "contentListPage|tableRowsList" with text "$researchTitle" is not displayed
    When User selects item "option" with text "Rejected" from Article Status dropdown "contentListPage|articleStatusDropdown"
    Then Table Row "contentListPage|tableRowsList" with text "$researchTitle" is displayed
    And User deletes "Research" with "Title" equal to "$researchTitle"

  @smoke
  @regression
  Scenario:[Pending Research] Global Admin specifies the Rejection reason, clicks [Cancel] button on Reject popup and then opens Reject popup again and clicks [Reject]
    When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "header|settingsButton"
    And User clicks Moderate Content link "header|moderateContentLink" by executing script
    And User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
    And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
    And User waits for Table Row "contentListPage|tableRowsList" with text "$researchTitle" visibility within 3 seconds
    When User clicks [Reject] button "contentListPage|tableRowRejectButtonsList"
    Then User enters "Test_Auto - Reject reason" in Reject Reason Input field "contentListPage|rejectPopupInputField"
    And User clicks [Cancel] button "contentListPage|rejectPopupCancelButton"
    Then Reject Popup Header "contentListPage|rejectPopupHeaderText" is not displayed
    And Table Row "contentListPage|tableRowsList" with text "$researchTitle" is displayed
    When User clicks [Reject] button "contentListPage|tableRowRejectButtonsList"
    And Attribute "value" of Reject Popup Reason Input field "contentListPage|rejectPopupInputField" is equal to ""
    When User enters "Test_Auto - Reject reason for " in Reject Reason Input field "contentListPage|rejectPopupInputField"
    And User enters "$researchTitle" in Reject Reason Input field "contentListPage|rejectPopupInputField"
    And User clicks [Reject] button "contentListPage|rejectPopupRejectButton"
    When User selects item "option" with text "Rejected" from Article Status dropdown "contentListPage|articleStatusDropdown"
    Then Table Row "contentListPage|tableRowsList" with text "$researchTitle" is displayed
    And User deletes "Research" with "Title" equal to "$researchTitle"

  @smoke
  @regression
  Scenario:[Approved Research] Global Admin clicks [Reject] and specifies the reason
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API
    When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "header|settingsButton"
    And User clicks Moderate Content link "header|moderateContentLink" by executing script
    And User selects item "option" with text "Approved" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
    And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
    And User waits for Table Row "contentListPage|tableRowsList" with text "$researchTitle" visibility within 3 seconds
    When User clicks [Reject] button "contentListPage|tableRowRejectButtonsList"
    When User enters "Test_Auto - Reject reason for " in Reject Reason Input field "contentListPage|rejectPopupInputField"
    And User enters "$researchTitle" in Reject Reason Input field "contentListPage|rejectPopupInputField"
    And User clicks [Reject] button "contentListPage|rejectPopupRejectButton"
    Then Reject Popup Header "contentListPage|rejectPopupHeaderText" is not displayed
    And Table Row "contentListPage|tableRowsList" with text "$researchTitle" is not displayed
    When User selects item "option" with text "Rejected" from Article Status dropdown "contentListPage|articleStatusDropdown"
    Then Table Row "contentListPage|tableRowsList" with text "$researchTitle" is displayed
    And User deletes "Research" with "Title" equal to "$researchTitle"

  @smoke
  @regression
  Scenario:[Approved Research] Global Admin clicks [Reject] without specifying the reason
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API
    When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "header|settingsButton"
    And User clicks Moderate Content link "header|moderateContentLink" by executing script
    And User selects item "option" with text "Approved" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
    And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
    And User waits for Table Row "contentListPage|tableRowsList" with text "$researchTitle" visibility within 3 seconds
    When User clicks [Reject] button "contentListPage|tableRowRejectButtonsList"
    And User clicks [Reject] button "contentListPage|rejectPopupRejectButton"
    Then Reject Popup Header "contentListPage|rejectPopupHeaderText" is not displayed
    And Table Row "contentListPage|tableRowsList" with text "$researchTitle" is not displayed
    When User selects item "option" with text "Rejected" from Article Status dropdown "contentListPage|articleStatusDropdown"
    Then Table Row "contentListPage|tableRowsList" with text "$researchTitle" is displayed
    And User deletes "Research" with "Title" equal to "$researchTitle"

  @smoke
  @regression
  Scenario:[Approved Research] Global Admin specifies the Rejection reason, clicks [Cancel] button on Reject popup and then opens Reject popup again and clicks [Reject]
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle" with API
    When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
    And User clicks navigation menu item "header|settingsButton"
    And User clicks Moderate Content link "header|moderateContentLink" by executing script
    And User selects item "option" with text "Approved" from Article Status dropdown "contentListPage|articleStatusDropdown"
    And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
    And User enters "$researchTitle" in Search Content field "contentListPage|searchContentField"
    And User waits for Table Row "contentListPage|tableRowsList" with text "$researchTitle" visibility within 3 seconds
    When User clicks [Reject] button "contentListPage|tableRowRejectButtonsList"
    Then User enters "Test_Auto - Reject reason" in Reject Reason Input field "contentListPage|rejectPopupInputField"
    And User clicks [Cancel] button "contentListPage|rejectPopupCancelButton"
    Then Reject Popup Header "contentListPage|rejectPopupHeaderText" is not displayed
    And Table Row "contentListPage|tableRowsList" with text "$researchTitle" is displayed
    When User clicks [Reject] button "contentListPage|tableRowRejectButtonsList"
    And Attribute "value" of Reject Popup Reason Input field "contentListPage|rejectPopupInputField" is equal to ""
    When User enters "Test_Auto - Reject reason for " in Reject Reason Input field "contentListPage|rejectPopupInputField"
    And User enters "$researchTitle" in Reject Reason Input field "contentListPage|rejectPopupInputField"
    And User clicks [Reject] button "contentListPage|rejectPopupRejectButton"
    When User selects item "option" with text "Rejected" from Article Status dropdown "contentListPage|articleStatusDropdown"
    Then Table Row "contentListPage|tableRowsList" with text "$researchTitle" is displayed
    And User deletes "Research" with "Title" equal to "$researchTitle"
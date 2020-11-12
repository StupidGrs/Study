@research
@bulk
Feature:  Global Admin rejects Pending/Approved Research with Bulk Reject button

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_Bulk_Reject" with added unique Id as "researchTitle_1"
        And User remembers text "Test_Auto_Bulk_Reject" with added unique Id as "researchTitle_2"
        And User remembers text "Test_Auto_Bulk_Reject" with added unique Id as "researchTitle_3"
        And User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle_1" with API
        And User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle_2" with API
        And User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle_3" with API

    @regression
    Scenario: Global Admin rejects Pending Research with Bulk Reject button and specifies the reason
        When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks Settings button "header|settingsButton"
        And User clicks Moderate Content link "header|moderateContentLink" by executing script
        And User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
        And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
        And User enters "Test_Auto_Bulk_Reject" in Search Content field "contentListPage|searchContentField"
        And User waits for Table Row "contentListPage|tableRowsList" visibility within 3 seconds
        Then User clicks checkbox "contentListPage|tableRowCheckboxLabelsList" on the row "contentListPage|tableRowsList" with text "$researchTitle_1"
        And User clicks checkbox "contentListPage|tableRowCheckboxLabelsList" on the row "contentListPage|tableRowsList" with text "$researchTitle_2"
        And User clicks checkbox "contentListPage|tableRowCheckboxLabelsList" on the row "contentListPage|tableRowsList" with text "$researchTitle_3"
        When User clicks Bulk Reject button "contentListPage|bulkRejectButton"
        Then User enters "Test_Auto - Reject reason for " in Reject Reason Input field "contentListPage|rejectPopupInputField"
        And User clicks [Reject] button "contentListPage|rejectPopupRejectButton"
        Then Reject Popup Header "contentListPage|rejectPopupHeaderText" is not displayed
        And User waits 3 seconds
        Then Table Row "contentListPage|tableRowsList" with text "$researchTitle_1" is not displayed
        And Table Row "contentListPage|tableRowsList" with text "$researchTitle_2" is not displayed
        And Table Row "contentListPage|tableRowsList" with text "$researchTitle_3" is not displayed
        When User selects item "option" with text "Rejected" from Article Status dropdown "contentListPage|articleStatusDropdown"
        Then Table Row "contentListPage|tableRowsList" with text "$researchTitle_1" is displayed
        And Table Row "contentListPage|tableRowsList" with text "$researchTitle_2" is displayed
        And Table Row "contentListPage|tableRowsList" with text "$researchTitle_3" is displayed
        #postcondition
        And User deletes "Research" with "Title" equal to "$researchTitle_1"
        And User deletes "Research" with "Title" equal to "$researchTitle_2"
        And User deletes "Research" with "Title" equal to "$researchTitle_3"

    @regression
    Scenario: Global Admin rejects Pending Research with Bulk Reject button and verifies that they are not available in Research tab
        When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks Settings button "header|settingsButton"
        And User clicks Moderate Content link "header|moderateContentLink" by executing script
        And User selects item "option" with text "Waiting for approval" from Article Status dropdown "contentListPage|articleStatusDropdown"
        And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
        And User enters "Test_Auto_Bulk_Reject" in Search Content field "contentListPage|searchContentField"
        And User waits for Table Row "contentListPage|tableRowsList" visibility within 3 seconds
        Then User clicks checkbox "contentListPage|tableRowCheckboxLabelsList" on the row "contentListPage|tableRowsList" with text "$researchTitle_1"
        And User clicks checkbox "contentListPage|tableRowCheckboxLabelsList" on the row "contentListPage|tableRowsList" with text "$researchTitle_2"
        And User clicks checkbox "contentListPage|tableRowCheckboxLabelsList" on the row "contentListPage|tableRowsList" with text "$researchTitle_3"
        When User clicks Bulk Reject button "contentListPage|bulkRejectButton"
        And User clicks [Reject] button "contentListPage|rejectPopupRejectButton"
        Then User clicks Research tab "navigation|researchTab"
        And User waits 3 seconds
        And User selects item "researchPage|sortByDropdownFieldOptionsList" with text "Relevance" from Sorting dropdown "researchPage|sortByDropdownField"
        When User enters "$researchTitle_1" in Search field "researchPage|searchArticleAutocompleteField"
        And User presses Enter key in Search field "researchPage|searchArticleAutocompleteField"
        Then Rejected Research "researchPage|titlesList" with text "$researchTitle_1" is not displayed
        When User clears text from Search field "researchPage|searchArticleAutocompleteField"
        And User enters "$researchTitle_2" in Search field "researchPage|searchArticleAutocompleteField"
        And User presses Enter key in Search field "researchPage|searchArticleAutocompleteField"
        Then Rejected Research "researchPage|titlesList" with text "$researchTitle_2" is not displayed
        When User clears text from Search field "researchPage|searchArticleAutocompleteField"
        And User enters "$researchTitle_3" in Search field "researchPage|searchArticleAutocompleteField"
        And User presses Enter key in Search field "researchPage|searchArticleAutocompleteField"
        Then Rejected Research "researchPage|titlesList" with text "$researchTitle_3" is not displayed
        #postcondition
        And User deletes "Research" with "Title" equal to "$researchTitle_1"
        And User deletes "Research" with "Title" equal to "$researchTitle_2"
        And User deletes "Research" with "Title" equal to "$researchTitle_3"

    @regression
    Scenario: Global Admin rejects Approved Research with Bulk Reject button and specifies the reason
        #precondition
        When User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle_1" with API
        And User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle_2" with API
        And User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle_3" with API
        #flow
        When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks Settings button "header|settingsButton"
        And User clicks Moderate Content link "header|moderateContentLink" by executing script
        And User selects item "option" with text "Approved" from Article Status dropdown "contentListPage|articleStatusDropdown"
        And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
        And User enters "Test_Auto_Bulk_Reject" in Search Content field "contentListPage|searchContentField"
        And User waits for Table Row "contentListPage|tableRowsList" visibility within 3 seconds
        Then User clicks checkbox "contentListPage|tableRowCheckboxLabelsList" on the row "contentListPage|tableRowsList" with text "$researchTitle_1"
        And User clicks checkbox "contentListPage|tableRowCheckboxLabelsList" on the row "contentListPage|tableRowsList" with text "$researchTitle_2"
        And User clicks checkbox "contentListPage|tableRowCheckboxLabelsList" on the row "contentListPage|tableRowsList" with text "$researchTitle_3"
        When User clicks Bulk Reject button "contentListPage|bulkRejectButton"
        Then User enters "Test_Auto - Reject reason for " in Reject Reason Input field "contentListPage|rejectPopupInputField"
        And User clicks [Reject] button "contentListPage|rejectPopupRejectButton"
        Then Reject Popup Header "contentListPage|rejectPopupHeaderText" is not displayed
        And User waits 3 seconds
        Then Table Row "contentListPage|tableRowsList" with text "$researchTitle_1" is not displayed
        And Table Row "contentListPage|tableRowsList" with text "$researchTitle_2" is not displayed
        And Table Row "contentListPage|tableRowsList" with text "$researchTitle_3" is not displayed
        When User selects item "option" with text "Rejected" from Article Status dropdown "contentListPage|articleStatusDropdown"
        Then Table Row "contentListPage|tableRowsList" with text "$researchTitle_1" is displayed
        And Table Row "contentListPage|tableRowsList" with text "$researchTitle_2" is displayed
        And Table Row "contentListPage|tableRowsList" with text "$researchTitle_3" is displayed
        #postcondition
        And User deletes "Research" with "Title" equal to "$researchTitle_1"
        And User deletes "Research" with "Title" equal to "$researchTitle_2"
        And User deletes "Research" with "Title" equal to "$researchTitle_3"

    @regression
    Scenario: Global Admin rejects Approved Research with Bulk Reject button and verifies that they are not available in Research tab
        #precondition
        When User "GLOBAL_ADMIN" logs in with API
        And User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle_1" with API
        And User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle_2" with API
        And User "GLOBAL_ADMIN" approves "Research" with title "$researchTitle_3" with API
        #flow
        When User logs in as "GLOBAL_ADMIN" on "LOGIN_PAGE"
        And User clicks Settings button "header|settingsButton"
        And User clicks Moderate Content link "header|moderateContentLink" by executing script
        And User selects item "option" with text "Approved" from Article Status dropdown "contentListPage|articleStatusDropdown"
        And User selects item "option" with text "research post" from Article Type dropdown "contentListPage|articleTypeDropdown"
        And User enters "Test_Auto_Bulk_Reject" in Search Content field "contentListPage|searchContentField"
        And User waits for Table Row "contentListPage|tableRowsList" visibility within 3 seconds
        Then User clicks checkbox "contentListPage|tableRowCheckboxLabelsList" on the row "contentListPage|tableRowsList" with text "$researchTitle_1"
        And User clicks checkbox "contentListPage|tableRowCheckboxLabelsList" on the row "contentListPage|tableRowsList" with text "$researchTitle_2"
        And User clicks checkbox "contentListPage|tableRowCheckboxLabelsList" on the row "contentListPage|tableRowsList" with text "$researchTitle_3"
        When User clicks Bulk Reject button "contentListPage|bulkRejectButton"
        And User clicks [Reject] button "contentListPage|rejectPopupRejectButton"
        Then User clicks Research tab "navigation|researchTab"
        And User waits 3 seconds
        And User selects item "researchPage|sortByDropdownFieldOptionsList" with text "Relevance" from Sorting dropdown "researchPage|sortByDropdownField"
        When User enters "$researchTitle_1" in Search field "researchPage|searchArticleAutocompleteField"
        And User presses Enter key in Search field "researchPage|searchArticleAutocompleteField"
        Then Rejected Research "researchPage|titlesList" with text "$researchTitle_1" is not displayed
        When User clears text from Search field "researchPage|searchArticleAutocompleteField"
        And User enters "$researchTitle_2" in Search field "researchPage|searchArticleAutocompleteField"
        And User presses Enter key in Search field "researchPage|searchArticleAutocompleteField"
        Then Rejected Research "researchPage|titlesList" with text "$researchTitle_2" is not displayed
        When User clears text from Search field "researchPage|searchArticleAutocompleteField"
        And User enters "$researchTitle_3" in Search field "researchPage|searchArticleAutocompleteField"
        And User presses Enter key in Search field "researchPage|searchArticleAutocompleteField"
        Then Rejected Research "researchPage|titlesList" with text "$researchTitle_3" is not displayed
        #postcondition
        And User deletes "Research" with "Title" equal to "$researchTitle_1"
        And User deletes "Research" with "Title" equal to "$researchTitle_2"
        And User deletes "Research" with "Title" equal to "$researchTitle_3"
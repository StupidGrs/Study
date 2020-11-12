@research
@researchDetails
Feature: Verify Screenshots

#    @ignore
    Scenario: Verify Screenshots
        #Create research with all fields
        Given User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle_1"
        Then User "COMPANY_ADMIN" publishes "Research" with all fields and title "$researchTitle_1" with API
        And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle_2"
        Then User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle_2" with API
        #Login and open research
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User navigates to "Research" URL with title "$researchTitle_1"
#        Then User compares screenshot of Featured Image "researchDetailsPage|headerFeaturedImage" to "researchDetails_featuredImage.png"
        When User navigates to "Research" URL with title "$researchTitle_2"
        Then User compares screenshot of Featured Image "researchDetailsPage|headerFeaturedImage" to "researchDetails_featuredImage_default.png"
        #delete research
        And User deletes "Research" with "Title" equal to "$researchTitle_1"
        And User deletes "Research" with "Title" equal to "$researchTitle_2"
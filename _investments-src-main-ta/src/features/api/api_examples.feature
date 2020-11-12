@apiTest
Feature: Test api

  Scenario: Create Research with specified Title
    When User "GLOBAL_ADMIN" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    Then User "GLOBAL_ADMIN" publishes "Research" with title "$researchTitle" with API
    And User deletes "Research" with "Title" equal to "$researchTitle"

  Scenario: Create Research with specified Title and Company
    When User "GLOBAL_ADMIN" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    Then User "GLOBAL_ADMIN" publishes "Research" with title "$researchTitle" and company "Mercer" with API
    And User deletes "Research" with "Title" equal to "$researchTitle"

  Scenario: Create Research with all fields and specified Title
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_ADMIN" publishes "Research" with all fields and title "$researchTitle" with API
    And User deletes "Research" with "Title" equal to "$researchTitle"

  Scenario: Create Research with specified Title and custom attributes
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle" and "'regions':['Asia','EMEA'], 'taxonomies':['Real Estate', 'Broad Equity'], 'tags':'Investing'" with API
    And User deletes "Research" with "Title" equal to "$researchTitle"

  Scenario: Create Event with specified Title
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    Then User "COMPANY_ADMIN" publishes "Event" with title "$eventTitle" with API
    And User deletes "Events" with "Title" equal to "$eventTitle"

  Scenario: Create Event with all fields and specified Title
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    Then User "COMPANY_ADMIN" publishes "Event" with all fields and title "$eventTitle" with API
    And User deletes "Events" with "Title" equal to "$eventTitle"

  Scenario:  Create Event with specified Title and custom attributes
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    Then User "COMPANY_ADMIN" publishes "Event" with title "$eventTitle" and "'regions':['Asia','EMEA'], 'taxonomies':['Real Estate', 'Broad Equity'], 'tags':'Investing', 'type':'Webinar', 'start_date':'9/30/2019', 'end_date':'10/10/2019'" with API
    And User deletes "Events" with "Title" equal to "$eventTitle"

  Scenario: Create Events with Start and End Dates with API methods
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle1"
    And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle2"
    #different date formats
    And User "COMPANY_ADMIN" publishes Event with title "$eventTitle" and Start Date "2019-09-30 4:10" and End Date "30 Jan 2020 5:10" with API
    #Zulu time
    And User "COMPANY_ADMIN" publishes Event with title "$eventTitle1" and Start Date "2019-09-30T04:10:00.000Z" and End Date "2019-09-30T05:10:00.000Z" with API
    #date with time
    And User "COMPANY_ADMIN" publishes Event with title "$eventTitle2" and Start Date "9/30/2019" and Time "4:10" and End Date "9/30/2019" and Time "5:10" with API
    #delete created events
    Then User deletes "Events" with "Title" equal to "$eventTitle"
    And User deletes "Events" with "Title" equal to "$eventTitle1"
    And User deletes "Events" with "Title" equal to "$eventTitle2"

  Scenario: Remember Start Date of Event with Title
    When User "COMPANY_ADMIN" logs in with API
    Then User "COMPANY_ADMIN" publishes "Event" with title "Test_Auto_Event_Start_Date" with API
    And User remembers Start Date of Event with title "Test_Auto_Event_Start_Date" as "eventStartDate"
    Then User remembers Start Date of Event with title "Test_Auto_Event_Start_Date" in format "MMM Do, YYYY" as "eventStartDateFormat"
    And User deletes "Events" with "Title" equal to "Test_Auto_Event_Start_Date"

  Scenario: Remember End Date of Event with Title
    When User "COMPANY_ADMIN" logs in with API
    And User "COMPANY_ADMIN" publishes "Event" with title "Test_Auto_Event_End_Date" with API
    And User remembers Start Date of Event with title "Test_Auto_Event_End_Date" as "eventEndDate"
    Then User remembers End Date of Event with title "Test_Auto_Event_End_Date" in format "MMM Do, YYYY" as "eventEndDateFormat"
    And User deletes "Events" with "Title" equal to "Test_Auto_Event_End_Date"

  Scenario: Create draft Research with specified Title
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Draft_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_ADMIN" saves Draft "Research" with title "$researchTitle" with API
    And User deletes "Research" with "Title" equal to "$researchTitle"

  Scenario: Create draft Research with all fields and specified Title
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Draft_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_ADMIN" saves Draft "Research" with all fields and title "$researchTitle" with API
    And User deletes "Research" with "Title" equal to "$researchTitle"

  Scenario: Create draft Event with specified Title
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Draft_Event" with added unique Id as "eventTitle"
    Then User "COMPANY_ADMIN" saves Draft "Event" with title "$eventTitle" with API
    And User deletes "Events" with "Title" equal to "$eventTitle"

  Scenario: Create draft Event with all fields and specified Title
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Draft_Event" with added unique Id as "eventTitle"
    Then User "COMPANY_ADMIN" saves Draft "Event" with all fields and title "$eventTitle" with API
    And User deletes "Events" with "Title" equal to "$eventTitle"

  Scenario: Create draft News with specified Title
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Draft_News" with added unique Id as "newsTitle"
    Then User "COMPANY_ADMIN" saves Draft "News" with title "$newsTitle" with API
    And User deletes "News" with "Title" equal to "$newsTitle"

  Scenario: Create draft News with all fields and specified Title
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Draft_News" with added unique Id as "newsTitle"
    Then User "COMPANY_ADMIN" saves Draft "News" with all fields and title "$newsTitle" with API
    And User deletes "News" with "Title" equal to "$newsTitle"

  Scenario: Create News with specified Title
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_News" with added unique Id as "newsTitle"
    Then User "COMPANY_ADMIN" publishes "News" with title "$newsTitle" with API
    And User deletes "News" with "Title" equal to "$newsTitle"

  Scenario: Create News with all fields and specified Title
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_News" with added unique Id as "newsTitle"
    Then User "COMPANY_ADMIN" publishes "News" with all fields and title "$newsTitle" with API
    And User deletes "News" with "Title" equal to "$newsTitle"

  Scenario:  Create News with specified Title and custom attributes
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_News" with added unique Id as "newsTitle"
    Then User "COMPANY_ADMIN" publishes "News" with title "$newsTitle" and "'regions':['Asia','EMEA'], 'taxonomies':['Real Estate', 'Broad Equity'], 'tags':'Investing', 'type':'Webinar'" with API
    And User deletes "News" with "Title" equal to "$newsTitle"

  Scenario Outline: Approve/Unapprove/Reject <resource> with specified Title
    When User "GLOBAL_ADMIN" logs in with API
    And User remembers text "Test_Auto" with added unique Id as "resourceTitle"
    And User "GLOBAL_ADMIN" publishes "<resource>" with title "$resourceTitle" with API
    Then User "GLOBAL_ADMIN" approves "<resource>" with title "$resourceTitle" with API
    Then User "GLOBAL_ADMIN" unapproves "<resource>" with title "$resourceTitle" with API
    Then User "GLOBAL_ADMIN" rejects "<resource>" with title "$resourceTitle" with API
    And User deletes "<resource>" with "Title" equal to "$resourceTitle"
    Examples:
      | resource |
      | event    |
      | research |
      | news     |

  Scenario Outline: Create <resource> with specified Title and Publish Date
    When User "COMPANY_ADMIN" logs in with API
    And User remembers current date "minus" "10 Days, 2 Hours, 10 Minutes" as "publishDate1"
    And User remembers current date "plus" "10 Days, 2 Hours, 10 Minutes" as "publishDate2"
    Then User "COMPANY_ADMIN" publishes "<resource>" with title "Test_Auto_Publish_Date_1" and publish date "$publishDate1" with API
    And  User "COMPANY_ADMIN" publishes "<resource>" with all fields and title "Test_Auto_Publish_Date_2" and publish date "$publishDate2" with API
    And User deletes "<resource>" with "Title" equal to "Test_Auto_Publish_Date_1"
    And User deletes "<resource>" with "Title" equal to "Test_Auto_Publish_Date_2"
    Examples:
      | resource |
      | research |
      | news     |

  Scenario: Create Research with specified Title and mark it as Featured by Global Admin
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    Then User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle" with API
    When User "GLOBAL_ADMIN" logs in with API
    Then User "GLOBAL_ADMIN" sets Featured "true" for "Research" with title "$researchTitle" with API
    And User deletes "Research" with "Title" equal to "$researchTitle"

  Scenario: Create Research with specified Title and mark it as Company Featured by Company Admin
    When User "COMPANY_ADMIN" logs in with API
    And User remembers text "Test_Auto_Research" with added unique Id as "researchTitle"
    And User "COMPANY_ADMIN" publishes "Research" with title "$researchTitle" with API
    Then User "COMPANY_ADMIN" sets Company Featured "false" for "Research" with title "$researchTitle" with API
    And User deletes "Research" with "Title" equal to "$researchTitle"

  Scenario: Create Research with specified Title and mark it as Company Featured by Company Admin
    When Company Admin creates Research with Company "Mercer", isFeatured = "false", isCompanyFeatured = "false" and remembers Title as "researchTitle" with API
    And User deletes "Research" with "Title" equal to "$researchTitle"

  Scenario: Change User Company for Current User
    When User "GLOBAL_ADMIN" logs in with API
    When User "GLOBAL_ADMIN" changes Company to "CompAuto" with API

  Scenario: Change User Company for Another User
    When User "GLOBAL_ADMIN" logs in with API
    When User "GLOBAL_ADMIN" changes Company to "CompAuto" for User "COMPANY_ADMIN" with API

  Scenario: Set "Private" flag for Current User
    When User "COMPANY_ADMIN" logs in with API
    When User "COMPANY_ADMIN" makes Account Private = "true" with API
    When User "COMPANY_ADMIN" makes Account Private = "false" with API

  Scenario: Set "Private" flag for Another User
    When User "GLOBAL_ADMIN" logs in with API
    When User "GLOBAL_ADMIN" makes "COMPANY_ADMIN" Account Private = "true" with API
    When User "GLOBAL_ADMIN" makes "COMPANY_ADMIN" Account Private = "false" with API

  Scenario: Unmark Company Featured
    When User "COMPANY_ADMIN" logs in with API
    Then User "COMPANY_ADMIN" removes "ALL" Company Featured Tokens from Company Researches with API

  Scenario: Verify Lead Stories
    Then Research with title "Another Test" is included in the Lead Stories list

  Scenario: Set role to another user
    When Global Admin sets role "COMPANY_AUTHOR" to User "COMPANY_AUTHOR"

# @deleteR
# Scenario: Delete all TEST_AUTO researches
#   And User deletes all "Researches" with "Title" that contains text "Test_Auto"

# @deleteE
# Scenario: Delete all TEST_AUTO events
#   And User deletes all "Events" with "Title" that contains text "Test_Auto"

# @deleteN
# Scenario: Delete all TEST_AUTO news
#   And User deletes all "News" with "Title" that contains text "Test_Auto"

#####################################################################################################################################################
############## API STEPS COMMENTED OUT in api-step-definitions
#####################################################################################################################################################
# Scenario: Create Research with specified Status and Featured and Company Featured flags and remember its Title - 1 step version
#   When User creates "Research" in "Rejected" status with flag isFeatured = "true" and remembers Title as "researchTitle" with API
#   And User deletes "Research" with "Title" equal to "$researchTitle"

# Scenario: Create Research with specified Status and Company Featured flag and remember its Title - 1 step version
#   When User creates "Research" in "Approved" status with flag isCompanyFeatured = "false" and remembers Title as "researchTitle" with API
#   Then User deletes "Research" with "Title" equal to "$researchTitle"

# Scenario: Create Research with specified Status and Featured flag and remember its Title - 1 step version
#   When User creates "Research" in "Pending" status with flags isFeatured = "false" and isCompanyFeatured = "false" and remembers Title as "researchTitle" with API
#   Then User deletes "Research" with "Title" equal to "$researchTitle"
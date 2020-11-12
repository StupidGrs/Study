@events
@eventDetails
Feature: Verify elements and data on Event Details Page - Pending

    @regression
    Scenario: Verify Details page of Pending Event with all fields
        # Create event with all fields
        When User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
        Then User "COMPANY_ADMIN" publishes Event with all fields and title "$eventTitle" and Start Date "05/20/2020" and Time "4:10 AM" and End Date "05/20/2021" and Time "4:10 PM" with API
        # Login and open event
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User navigates to "Event" URL with title "$eventTitle"
        # Verify Header elements
        Then Event Title "eventDetailsPage|title" text is equal to "$eventTitle"
        And Event Excerpt "eventDetailsPage|excerpt" text is equal to "Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla."
        And Event Type "eventDetailsPage|eventTypeChip" text is equal to "Webinar"
        And Calendar Icon next to the Event Date "eventDetailsPage|calendarIconHeader" is displayed
        And Event Date "eventDetailsPage|dateTimeHeader" contains Start Date "05/20/2020" and Time "4:10 AM" and End Date "05/20/2021" and Time "4:10 PM" in short format with GMT offset
        And Company Icon "eventDetailsPage|companyIconHeader" is displayed
        And Company Name "eventDetailsPage|companyNameHeader" contains "CompAuto" text
        And Location Icon "eventDetailsPage|locationIconHeader" is displayed
        And Location "eventDetailsPage|locationHeader" contains "San Francisco, United States" text
        And [Attend] Button "eventDetailsPage|attendButton" is displayed
        And [Attend] Button "eventDetailsPage|attendButton" contains "I'm Not Going" text
        And [Attend] Button "eventDetailsPage|attendButton" is enabled
        And User compares screenshot of [I'm Not Going] button "eventDetailsPage|attendButton" to "attend_btn_not_going.png"
        And [Tickets] Button "eventDetailsPage|ticketsButton" is displayed
        And [Tickets] Button "eventDetailsPage|ticketsButton" contains "Tickets & Info" text
        And [Tickets] Button "eventDetailsPage|ticketsButton" is enabled
        And Attribute "href" of [Tickets] Button "eventDetailsPage|ticketsButton" is equal to "https://events.climateaction.org/sustainable-investment-forum-europe/"
        And User scrolls page to top
        And [Back] Button "eventDetailsPage|backButton" is displayed
        # Verify date in circle
        And Days in Circle "eventDetailsPage|dateCircleDay" text is equal to "20-20"
        And Months in Circle "eventDetailsPage|dateCircleMonth" text is equal to "MAY-MAY"
        And Years in Circle "eventDetailsPage|dateCircleYear" contains "2020-2021" text
        # Verify Images
        And Event Header Background Image "eventDetailsPage|headerBackgroundImage" is displayed
#        And Attribute "style" of Event Header Background Image "eventDetailsPage|headerBackgroundImage" does not contain "default-feature-image.png"
        And Event Featured Image "eventDetailsPage|headerFeaturedImage" is displayed
#        And Attribute "style" of Event Featured Image "eventDetailsPage|headerFeaturedImage" does not contain "default-feature-image.png"
        And User compares screenshot of Featured Image "eventDetailsPage|headerFeaturedImage" to "eventDetails_featuredImage.png"
        # Content
        And Event Content "eventDetailsPage|content" text is equal to "Donec quis orci eget orci vehicula condimentum. Curabitur in libero ut massa volutpat convallis."
        # Date & Time section
        And Date & Time label "eventDetailsPage|dateTimeLabelBottom" with text "Date & Time" is displayed
        And Calendar Icon "eventDetailsPage|calendarIconBottom" is displayed
        And Date "eventDetailsPage|dateBottom" text is equal to "Wednesday May 20, 2020 – Thursday May 20, 2021"
        And Time "eventDetailsPage|timeBottom" contains "4:10am – 4:10pm" text with GMT offset
        And [Add to calendar] dropdown link "eventDetailsPage|addToCalendarDropdownLink" is displayed
        And [Add to calendar] dropdown link "eventDetailsPage|addToCalendarDropdownLink" text is equal to "Add to calendar"
        And [Add to calendar] icon "eventDetailsPage|addToCalendarIcon" is displayed
        # Location
        And Location label "eventDetailsPage|locationLabelBottom" with text "Location" is displayed
        And Location Icon "eventDetailsPage|locationIconBottom" is displayed
        And Location "eventDetailsPage|locationBottom" text is equal to "San Francisco, United States"
        # Tag
        And Tags List "eventDetailsPage|eventTagChip" count is equal to 1
        And Tag "eventDetailsPage|eventTagChip" text is equal to "Markets & Economy"
        # Attend circle button in the footer
        And User compares screenshot of [Attend] big circle button "eventDetailsPage|footerAttendButton" to "attendCircleBtn_not_going_Big.png"
        And Attendees counter "eventDetailsPage|footerAttendeesCounter" text is equal to "0 going"
        # Author elements in the footer
        And Company Logo "eventDetailsPage|authorCompanyLogo" is displayed
        And Company Name "eventDetailsPage|authorCompanyName" text is equal to "CompAuto"
        And Followers number "eventDetailsPage|authorCompanyFollowers" is displayed
        And Followers number "eventDetailsPage|authorCompanyFollowers" contains "followers" text
        And Follow button "eventDetailsPage|authorFollowButton" is enabled
        And Follow button "eventDetailsPage|authorFollowButton" text is equal to "FOLLOW"
        # Left block elements
        And User scrolls page to top
        And Left Block "researchDetailsPage|leftBlock" is displayed
        And Company Name "researchDetailsPage|leftBlockCompanyName" text is equal to "CompAuto"
        And Followers number "researchDetailsPage|leftBlockCompanyFollowers" is displayed
        And Followers number "researchDetailsPage|leftBlockCompanyFollowers" contains "followers" text
        And Follow button "researchDetailsPage|leftBlockFollowButton" is enabled
        And Follow button "researchDetailsPage|leftBlockFollowButton" text is equal to "FOLLOW"
        And User compares screenshot of [Attend] small circle button "eventDetailsPage|leftBlockAttendButton" to "attendCircleBtn_not_going_Small.png"
        And Attendees counter "eventDetailsPage|leftBlockAttendeesCounter" text is equal to "0"
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"

@regression
Scenario: Verify Details page of Pending Event with required fields only
        # Create event with required fields only
        When User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
        Then User "COMPANY_ADMIN" publishes Event with title "$eventTitle" and Start Date "05/20/2020" and Time "4:10 AM" and End Date "05/20/2021" and Time "4:10 PM" with API
        # Login and open event
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        And User navigates to "Event" URL with title "$eventTitle"
        # Verify Header elements
        Then Event Title "eventDetailsPage|title" text is equal to "$eventTitle"
        And Event Excerpt "eventDetailsPage|excerpt" text is equal to "Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla."
        And Event Type "eventDetailsPage|eventTypeChip" text is equal to "Webinar"
        And Calendar Icon next to the Event Date "eventDetailsPage|calendarIconHeader" is displayed
        And Event Date "eventDetailsPage|dateTimeHeader" contains Start Date "05/20/2020" and Time "4:10 AM" and End Date "05/20/2021" and Time "4:10 PM" in short format with GMT offset
        And Company Icon "eventDetailsPage|companyIconHeader" is displayed
        And Company Name "eventDetailsPage|companyNameHeader" contains "CompAuto" text
        And Location Icon "eventDetailsPage|locationIconHeader" is displayed
        And Location "eventDetailsPage|locationHeader" contains "San Francisco, United States" text
        And [Attend] Button "eventDetailsPage|attendButton" is displayed
        And [Attend] Button "eventDetailsPage|attendButton" contains "I'm Not Going" text
        And [Attend] Button "eventDetailsPage|attendButton" is enabled
        And User compares screenshot of [I'm Not Going] button "eventDetailsPage|attendButton" to "attend_btn_not_going.png"
        And User scrolls page to top
        And [Back] Button "eventDetailsPage|backButton" is displayed
        # Verify date in circle
        And Days in Circle "eventDetailsPage|dateCircleDay" text is equal to "20-20"
        And Months in Circle "eventDetailsPage|dateCircleMonth" text is equal to "MAY-MAY"
        And Years in Circle "eventDetailsPage|dateCircleYear" contains "2020-2021" text
        # Verify Images
        And Event Header Background Image "eventDetailsPage|headerBackgroundImage" is displayed
        And Attribute "style" of Event Header Background Image "eventDetailsPage|headerBackgroundImage" contains "default-feature-image.png"
        And Event Featured Image "eventDetailsPage|headerFeaturedImage" is displayed
        And Attribute "style" of Event Featured Image "eventDetailsPage|headerFeaturedImage" contains "default-feature-image.png"
        And User compares screenshot of Featured Image "eventDetailsPage|headerFeaturedImage" to "eventDetails_featuredImage_default.png"
        # Content
        And Event Content "eventDetailsPage|content" text is equal to "Donec quis orci eget orci vehicula condimentum. Curabitur in libero ut massa volutpat convallis."
        # Date & Time section
        And Date & Time label "eventDetailsPage|dateTimeLabelBottom" with text "Date & Time" is displayed
        And Calendar Icon "eventDetailsPage|calendarIconBottom" is displayed
        And Date "eventDetailsPage|dateBottom" text is equal to "Wednesday May 20, 2020 – Thursday May 20, 2021"
        And Time "eventDetailsPage|timeBottom" contains "4:10am – 4:10pm" text with GMT offset
        And [Add to calendar] dropdown link "eventDetailsPage|addToCalendarDropdownLink" is displayed
        And [Add to calendar] dropdown link "eventDetailsPage|addToCalendarDropdownLink" text is equal to "Add to calendar"
        And [Add to calendar] icon "eventDetailsPage|addToCalendarIcon" is displayed
        # Location
        And Location label "eventDetailsPage|locationLabelBottom" with text "Location" is displayed
        And Location Icon "eventDetailsPage|locationIconBottom" is displayed
        And Location "eventDetailsPage|locationBottom" text is equal to "San Francisco, United States"
        # Tag
        And Tags List "eventDetailsPage|eventTagChip" is not displayed
        # Attend circle button in the footer
        And User compares screenshot of [Attend] big circle button "eventDetailsPage|footerAttendButton" to "attendCircleBtn_not_going_Big.png"
        And Attendees counter "eventDetailsPage|footerAttendeesCounter" text is equal to "0 going"
        # Author elements in the footer
        And Company Logo "eventDetailsPage|authorCompanyLogo" is displayed
        And Company Name "eventDetailsPage|authorCompanyName" text is equal to "CompAuto"
        And Followers number "eventDetailsPage|authorCompanyFollowers" is displayed
        And Followers number "eventDetailsPage|authorCompanyFollowers" contains "followers" text
        And Follow button "eventDetailsPage|authorFollowButton" is enabled
        And Follow button "eventDetailsPage|authorFollowButton" text is equal to "FOLLOW"
        # Left block elements
        And User scrolls page to top
        And Left Block "researchDetailsPage|leftBlock" is displayed
        And Company Name "researchDetailsPage|leftBlockCompanyName" text is equal to "CompAuto"
        And Followers number "researchDetailsPage|leftBlockCompanyFollowers" is displayed
        And Followers number "researchDetailsPage|leftBlockCompanyFollowers" contains "followers" text
        And Follow button "researchDetailsPage|leftBlockFollowButton" is enabled
        And Follow button "researchDetailsPage|leftBlockFollowButton" text is equal to "FOLLOW"
        And User compares screenshot of [Attend] small circle button "eventDetailsPage|leftBlockAttendButton" to "attendCircleBtn_not_going_Small.png"
        And Attendees counter "eventDetailsPage|leftBlockAttendeesCounter" text is equal to "0"
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"
@events
@eventDetails
Feature: Verify buttons behaviour on Event Details Page

    Background:
        Given User "COMPANY_ADMIN" logs in with API
        And User remembers text "Test_Auto_Event" with added unique Id as "eventTitle"
        Then User "COMPANY_ADMIN" publishes "Event" with all fields and title "$eventTitle" with API
        When User "GLOBAL_ADMIN" logs in with API
        Then User "GLOBAL_ADMIN" approves "Event" with title "$eventTitle" with API
        When User logs in as "COMPANY_ADMIN" on "LOGIN_PAGE"
        Then User navigates to "Event" URL with title "$eventTitle"

    @regression
    Scenario Outline: User clicks [Attend] button in the [<btnDescription>] and verifies attendees counter and other attend elements are changed
        When User clicks [Attend] button in the <btnDescription> "eventDetailsPage|<btnCss>"
        And User waits 2 seconds
        Then [I'm Going] button "eventDetailsPage|attendButton" with text "I'm Going" is displayed
        And User compares screenshot of [I'm Going] button "eventDetailsPage|attendButton" to "attend_btn_going.png"
        And User compares screenshot of [Attend] button in the Left Block "eventDetailsPage|leftBlockAttendButton" to "attendCircleBtn_going_Small.png"
        And User compares screenshot of [Attend] button in the Footer "eventDetailsPage|footerAttendButton" to "attendCircleBtn_going_Big.png"
        And Attendees counter in the Left Block "eventDetailsPage|leftBlockAttendeesCounter" text is equal to "1"
        And Attendees counter in the Footer "eventDetailsPage|footerAttendeesCounter" text is equal to "1 going"
        When User scrolls page to top
        And User clicks [Attend] button in the <btnDescription> "eventDetailsPage|attendButton"
        And User waits 2 seconds
        Then [I'm Not Going] button "eventDetailsPage|attendButton" with text "I'm Not Going" is displayed
        # Click by Title (or any other point on the page) is needed to remove hover effect from [I'm Not Going] button, so screenshot "attend_btn_not_going.png" will match
        And User clicks Event Title "eventDetailsPage|title"
        And User compares screenshot of [I'm Not Going] button "eventDetailsPage|attendButton" to "attend_btn_not_going.png"
        And User compares screenshot of [Attend] button in the Left Block "eventDetailsPage|leftBlockAttendButton" to "attendCircleBtn_not_going_Small.png"
        And User compares screenshot of [Attend] button in the Footer "eventDetailsPage|footerAttendButton" to "attendCircleBtn_not_going_Big.png"
        And Attendees counter in the Left Block "eventDetailsPage|leftBlockAttendeesCounter" text is equal to "0"
        And Attendees counter in the Footer "eventDetailsPage|footerAttendeesCounter" text is equal to "0 going"
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"
        Examples:
            | btnCss                | btnDescription |
            | attendButton          | Header         |
            | leftBlockAttendButton | Left Block     |
            | footerAttendButton    | Footer         |

    @regression
    Scenario: User clicks [Tickets & Info] button and verifies opened URL
        When User clicks [Tickets & Info] button "eventDetailsPage|ticketsButton"
        And User waits 3 seconds
        And User goes to 2 browser tab
        Then Page URL is equal to "https://events.climateaction.org/sustainable-investment-forum-europe/"
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"

    @regression
    Scenario: Verify [Add to calendar] options list
        When User clicks [Add to calendar] button "eventDetailsPage|addToCalendarDropdownLink"
        Then Calendar options list "eventDetailsPage|calendarOptionsList" is displayed
        And Calendar option "eventDetailsPage|calendarOptionsList" with text "iCalendar" is displayed
        And Calendar option "eventDetailsPage|calendarOptionsList" with text "Outlook" is displayed
        And Calendar option "eventDetailsPage|calendarOptionsList" with text "Outlook Live" is displayed
        And Calendar option "eventDetailsPage|calendarOptionsList" with text "Google" is displayed
        And Calendar option "eventDetailsPage|calendarOptionsList" with text "Yahoo" is displayed
        And User verifies each Calendar option "eventDetailsPage|calendarOptionsList" contains Icon "eventDetailsPage|calendarOptionsIconsList"
        And User compares screenshot of [Add to calendar] options "eventDetailsPage|calendarOptionsDiv" to "add_to_calendar_options.png"
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"

    @regression
    Scenario: Verify [Back] button redirects User to Event page
        When User clicks [Back] button "eventDetailsPage|backButton" by executing script
        And User waits 2 seconds
        Then Page URL is equal to "EVENTS_PAGE"
        #delete event
#        And User deletes "Event" with "Title" equal to "$eventTitle"

    @regression
    Scenario: Verify [All Upcoming Events] link redirects User to Events page
        When User clicks [All Upcoming Events] link "eventDetailsPage|relatedSectionUpcomingEventsLink" by executing script
        And User waits 2 seconds
        Then Page URL is equal to "EVENTS_PAGE"
        #delete event
        And User deletes "Event" with "Title" equal to "$eventTitle"
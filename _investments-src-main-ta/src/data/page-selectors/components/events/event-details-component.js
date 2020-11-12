/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */

//TODO: research/news/event details page layouts are almost the same, 
// need to combine the same selectors under one component
const leftSocialBlock = `#social-part-left_347603499`;
const authorSection = `#author-footer-company_content`;
const relatedEventsDetails = `div.src-c-event-list-card__event-info`;

const followButton = `#follow-button_follow`;


const unfollowButton = `#follow-button_following`;
const attendButton = `#event-going-button_317877342`;
const attendeesCounter = `#event-going-button_872087467`;

module.exports = {
    // header
    backButton: '[icon="arrow_back"]',
    eventTypeChip: `#article-type-chip div`,
    title: `#article-header_330418031 h1`,
    excerpt: `#article-header_330418031 h4`,
    calendarIconHeader: '#event-page-header_881626824',
    dateTimeHeader: `#event-page-header_61938590`,
    companyIconHeader: '#event-page-header_41670240',
    companyNameHeader: `#event-page-header_279290677`,
    locationIconHeader: '#event-page-header_55707080',
    locationHeader: `#event-page-header_44047696`,
    attendButtonIconBusy: '#event-page-header_284516965[ng-reflect-icon="event_busy"]',
    attendButtonIconAvailable: '#event-page-header_284516965[ng-reflect-icon="event_available"]',
    attendButton: '#event-page-header_351164239',
    ticketsButton: '#event-page-header_734192705',
    dateCircleDay: `#event-page-header_924732234 h1`,
    dateCircleMonth: `#event-page-header_924732234 [class*="month-year"]:nth-child(1)`,
    dateCircleYear: `#event-page-header_924732234 [class*="month-year"]:nth-child(2)`,
    headerBackgroundImage: `#article-header_485970809`,
    headerFeaturedImage: `#article-header > div > div:nth-child(2)`,

    // left social block 
    leftBlock: `${leftSocialBlock}`,
    leftBlockCompanyName: `#social-part-left_443770915`,
    leftBlockCompanyFollowers: `#social-part-left_349784862`,
    leftBlockFollowButton: `${leftSocialBlock} ${followButton}`,
    leftBlockUnfollowButton: `${leftSocialBlock} ${unfollowButton}`,
    leftBlockAttendButton: `${leftSocialBlock} ${attendButton}`,
    leftBlockAttendeesCounter: `${leftSocialBlock} ${attendeesCounter}`,
    leftBlockFacebookLink: `${leftSocialBlock} #social-part-left_280983942`,
    leftBlockFacebookIcon: `${leftSocialBlock} #social-part-left_993713579`,
    leftBlockLinkedinLink: `${leftSocialBlock} #social-part-left_419371065`,
    leftBlockLinkedinIcon: `${leftSocialBlock} #social-part-left_911977205`,
    leftBlockTwitterLink: `${leftSocialBlock} #social-part-left_525814708`,
    leftBlockTwitterIcon: `${leftSocialBlock} #social-part-left_359528010`,

    // content
    content: `div.src-c-article-content__content`,

    // content bottom part
    addToCalendarDropdownLink: `#event-page-content_101987904 h5`,
    addToCalendarIcon: `#event-page-content_101987904 mercer-icon`,
    calendarOptionsDiv: `.mos-c-dropdown__list`,
    calendarOptionsList: `.mos-c-dropdown__list a`,
    calendarOptionsIconsList: `.mos-c-dropdown__list a >:nth-child(1)`,
    calendarIconBottom: '#event-page-content_319640912',
    dateTimeLabelBottom: `#event-page-content_182021744`,
    dateBottom: `#event-page-content_168932685`,
    timeBottom: `#event-page-content_396075781`,
    locationBottom: `#event-page-content_907418113`,
    locationIconBottom: `#event-page-content_732094410`,
    locationLabelBottom: `#event-page-content_423686623`,
    eventTagChip: `[id^="event-page-content_tag"] div`,

    //event footer
    //attend elements
    footerAttendButton: `#event-page-content_427071429 ${attendButton}`,
    footerAttendeesCounter: `#event-page-content_427071429 ${attendeesCounter}`,
    //social links
    footerFacebookLink: `#event-page-content_675582484`,
    footerFacebookIcon: `#event-page-content_582781873`,
    footerLinkedinLink: `#event-page-content_389154525`,
    footerLinkedinIcon: `#event-page-content_997841521`,
    footerTwitterLink: `#event-page-content_206666246`,
    footerBlockTwitterIcon: `#event-page-content_507410841`,

    //author section in the footer
    authorCompanyLogo: `${authorSection} #company-logo`,
    authorCompanyName: `${authorSection} #author-footer-company_name`,
    authorCompanyFollowers: `${authorSection} #author-footer-company_followers`,
    authorFollowButton: `${authorSection} ${followButton}`,
    authorUnfollowButton: `${authorSection} ${unfollowButton}`,

    //related events section
    relatedSection: `mercer-item-card-list-container > div`,
    relatedEventsList: `mercer-event-list-card > div`,
    relatedSectionHeader: `h2.src-c-item-card-list-container__title`,
    relatedSectionUpcomingEventsLink: `a.src-c-item-card-list-container__explore`,

    relatedSectionUpcomingEventsIcon: `a.src-c-item-card-list-container__explore mercer-icon`,
    //related events details
    relatedEventsTitlesList: `.src-c-event-list-card__title`,
    relatedEventsDateTimeList: `${relatedEventsDetails} > div:nth-child(1) mercer-icon` ,
    relatedEventsCalendarIconsList: `${relatedEventsDetails} > div:nth-child(1) div`,
    relatedEventsCompanyIconsList: `${relatedEventsDetails} > div:nth-child(2) mercer-icon` ,
    relatedEventsCompanyNamesList: `${relatedEventsDetails} > div:nth-child(2) div div` ,
    relatedEventsLocationIconsList: `${relatedEventsDetails} > div:nth-child(3) mercer-icon` ,
    relatedEventsLocationsList: `${relatedEventsDetails} > div:nth-child(3) div div` ,
    // views and attendees
    relatedEventsViewsIconsList: `div.src-c-mercer-show-views__icon`,
    relatedEventsViewsCountList: `div.src-c-mercer-show-views__count`,
    relatedEventsAttendeesCalendarIconList: `div.src-c-mercer-show-attendees__icon`,
    relatedEventsAttendeesCounterList: `div.src-c-mercer-show-attendees__count`,
    // image
    relatedEventsImagesList: `div.src-c-event-list-card__foto-container`,
    relatedEventsDayCircle: `h2.src-c-event-date-circle__circle__day`,
    relatedEventsMonthYearCircle: `#event-page-related-events_18312777 .src-c-event-date-circle__circle > div`,
    
};
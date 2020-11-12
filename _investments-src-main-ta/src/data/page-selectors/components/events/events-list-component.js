/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */

module.exports = {
    eventsList: `.src-c-events-list__items>div>div`,
    eventsListItem: `[id^="user-content-item"]`,
    eventTitleList: `[id^="events-container_event_"]`,
};
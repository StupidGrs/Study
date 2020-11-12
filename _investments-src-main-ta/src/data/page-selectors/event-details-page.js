/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */

const eventDetailsComponent = require('./components/events/event-details-component');

module.exports = {
    ...eventDetailsComponent
};
/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */
const contentModerationComponent = require('./components/content-moderation-component');
const rejectPopup = require('./popups/rejectReason');

module.exports = {
  ...contentModerationComponent,
  ...rejectPopup,
}
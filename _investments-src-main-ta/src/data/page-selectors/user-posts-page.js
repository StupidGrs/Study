/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */

const userPostsListComponent = require('./components/articles/articles-list-component');
const userPostsEventComponent = require('./components/events/user-posts-event-component');

module.exports = {
  ...userPostsListComponent,
  selectContentTypeDropdown: `#selectedContentType`,
  // selectContentTypeDropdownOptionsList: `#user-content-item-list div`,
    selectContentTypeDropdownOptionsList: `#selectedContentType`,
  eventOption: `#user-content-item-list_option_event`,
  ...userPostsEventComponent
};

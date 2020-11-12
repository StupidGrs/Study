/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */
const peopleCompaniesListComponent = require('./components/people-company-list-component');

module.exports = {
  mercerArticlesListHeaderTitle: '#directories-container_40441557',
  searchField: '#directories-container_762925831',
  searchTabs: '#directories-container_259972753 a',
  copy: '#directories-container_312020639',
  ...peopleCompaniesListComponent
};
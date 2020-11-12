/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */
const eventsFilterComponent = require('./components/events/events-filter-component');
const eventsListComponent = require('./components/events/events-list-component');
const eventsTopFiltersComponent = require('./components/articles/articles-top-filters-component')

module.exports = {
  ...eventsFilterComponent,
  ...eventsListComponent,
  ...eventsTopFiltersComponent,
  titlesList: '.src-c-content-list-card__title',
  mercerArticlesListHeaderTitle: 'mercer-articles-list-header h1',
  topEventsLabel: '#countable-item-list h2'
};
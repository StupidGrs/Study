/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */
const newsArticlesListComponent = require('./components/articles/articles-list-component');
const newsFilterComponent = require('./components/articles/articles-filter-component');
const topNewsSectionComponent = require('./components/articles/articles-top-list-component');
const newsPageSubheaderComponent = require('./components/articles/articles-page-subheader-component');
const newsTopFiltersComponent = require('./components/articles/articles-top-filters-component');

module.exports = {
  ...newsArticlesListComponent,
  ...newsFilterComponent,
  ...topNewsSectionComponent,
  ...newsPageSubheaderComponent,
  ...newsTopFiltersComponent,
  titlesList: '.src-c-content-list-card__title'
};
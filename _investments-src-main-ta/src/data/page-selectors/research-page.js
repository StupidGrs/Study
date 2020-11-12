/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */
const researchArticlesListComponent = require('./components/articles/articles-list-component');
const researchFilterComponent = require('./components/articles/articles-filter-component');
const topResearchSectionComponent = require('./components/articles/articles-top-list-component');
const researchPageSubheaderComponent = require('./components/articles/articles-page-subheader-component');
const researchTopFiltersComponent = require('./components/articles/articles-top-filters-component');

module.exports = {
  ...researchArticlesListComponent,
  ...researchFilterComponent,
  ...topResearchSectionComponent,
  ...researchPageSubheaderComponent,
  ...researchTopFiltersComponent,
  titlesList: '.src-c-content-list-card__title'
};

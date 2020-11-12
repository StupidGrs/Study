/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */
const researchDetailsComponent = require('./components/articles/article-details-component');

module.exports = {
  ...researchDetailsComponent,
};

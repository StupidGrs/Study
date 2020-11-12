/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */
const topArticlesSection = `mercer-popular-articles-container`;
const topArticlesList = `${topArticlesSection} mercer-popular-article div`

module.exports = {
  popularArticlesHeader: `#countable-item-list h2`,
  topArticlesList: `${topArticlesList}`,
  topArticlesHeaderLabelsList: `${topArticlesList} h5`,
  topArticlesTitlesList: `${topArticlesList} h3`,

};
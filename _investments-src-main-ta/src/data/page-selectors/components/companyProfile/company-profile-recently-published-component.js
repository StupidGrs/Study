/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */
const articlesList = '[id^=company-articles-tab-list_article]';
const articleFooterDiv = `${articlesList} .src-c-company-articles-tab-list__item-footer`;

module.exports = {
    articlesList: `${articlesList}`,
    articleTitleList: `${articlesList} .src-c-company-articles-tab-list__title`,
    articleCompanyNameList: `${articlesList} .src-c-company-articles-tab-list__company-name`,
    articleDateList: `${articlesList} .src-c-company-articles-tab-list__date`,
    articleReadTimeList: `${articlesList} .src-c-company-articles-tab-list__read-time`,
    articleTypeList: `${articlesList} .src-c-company-articles-tab-list__item-footer-article-type`,    

    articleViewsIconsList: `${articleFooterDiv} .src-c-company-articles-tab-list__views-count`,
    articleViewsLabelsList: `${articleFooterDiv} > div:nth-child(2)`,
    articleRatingsStarsIconsSetList: `${articleFooterDiv} mercer-show-ratings .src-c-mercer-show-ratings div:nth-child(1)`,
    articleRatingsCountList: `${articleFooterDiv} mercer-show-ratings .src-c-mercer-show-ratings div:nth-child(2)`,
  
    loadMoreButton: `#company-articles-tab_910563804`,

    sortByLabel: `#company-articles-tab_529689119`,
    sortByDropdown: `#sortSelect`,
    sortByDropdowOptionsList: `#sortSelect option`,
    searchField: `#company-articles-tab_293711953`,
    
};

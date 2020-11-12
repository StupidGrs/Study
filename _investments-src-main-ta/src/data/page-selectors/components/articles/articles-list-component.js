/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */
const articlesList = 'mercer-list-item';
const articleActionsDiv = `${articlesList} .actions`;
const articleFooterDiv = `${articlesList} .info-block`;

module.exports = {
  articlesList: `${articlesList}`,
  articleCompanyReadTimeDateInfoLabelList: `${articlesList} [class*="content"] .mos-o-subheader-4`,
  articleCompanyLogosList: `${articlesList} .src-c-company-logo__image`,
  articleTitlesList: `${articlesList} a`,
  articleActionIconsList: `${articleActionsDiv} mercer-icon`,
  articleAddToBookmarkIcon: `${articleActionsDiv} .action-circle mercer-icon:not(.bookmarked-icon)`,
  articleBookmarkedIconsList: `${articleActionsDiv} .bookmarked-icon`,
  articleDownloadIcon: `${articleActionsDiv} a`,
  articleViewsIconsList: `${articleFooterDiv} mercer-icon[alt="Views!"]`,
  articleViewsLabelsList: `${articleFooterDiv} p`,
  articleRatingsStarsIconsSetList: `${articleFooterDiv} mercer-show-ratings .src-c-mercer-show-ratings div:nth-child(1)`,
  articleRatingsCountList: `${articleFooterDiv} mercer-show-ratings .src-c-mercer-show-ratings div:nth-child(2)`,
  articleResearchTypesList: `${articleFooterDiv} h5`,

  articleStatusesList: `${articleActionsDiv} p`,

  noResultsMessage: `[class*='list__container__items'] .row div div`,

  loadMoreButton: `button.mos-c-button--md`,
  
};
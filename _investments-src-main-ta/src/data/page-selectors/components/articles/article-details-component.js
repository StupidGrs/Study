/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */
const headerSection = `#article-header`;
const headerInfoBlock = `#article-header-info-block`;
const leftBlock = `#social-part-left_347603499`;
const footerSection = `#article-footer_905203046`;
const authorSection = `#author-footer-company_content`;
const relatedSection = `.src-c-item-card-list-container`;
const relatedArticlesList = `${relatedSection} .src-c-item-card-list-container__card`;

const viewsAndStarsElement = `#views-and-stars`;
const viewsIcon = `.src-c-mercer-show-views__icon mercer-icon`;
const viewsCount = `.src-c-mercer-show-views__count`;
const ratingStarsIconsSet = `#show-ratings div:nth-child(1)`;
const ratingStarsIconsList = `[id^=show-ratings_star]`;
const ratingCount = `.src-c-mercer-show-ratings__rate-count`;

const headerViewsAndStarsSection = `${headerInfoBlock} ${viewsAndStarsElement}`;
const relatedArticlesViewsAndStarsList = `${relatedArticlesList} ${viewsAndStarsElement}`;

const followButton = `#follow-button_follow`;
const unfollowButton = `#follow-button_following`;

module.exports = {
  //article header 
  headerBackgroundImage: `#article-header_485970809`,
  headerBackgroundColor: `#article-header_330418031`,
  //trying another selector for FeaturedImage, because edge uses for screenshot wrong element
  headerFeaturedImage: `${headerSection} > div > div:nth-child(2)`,
  //original headerFeaturedImage selector
  //headerFeaturedImage: `${headerSection} div.src-c-article-header__feature-image:nth-child(2)`,
  backButton: `${headerSection} .src-c-article-header__back-button`,

  title: `${headerSection} h1`,
  excerpt: `${headerSection} h4`,
  researchType: `${headerSection} #article-type-chip div`,

  headerCompanyReadTimeDateInfo: `#article-header-info-block_927198473`,
  headerCompanyLogoIcon: `${headerSection} #company-logo`,
  headerCompanyLogoText: `${headerSection} #company-logo_abbreviation`,
  headerCompanyName: `${headerInfoBlock} .src-c-article-card-info__company-name`,
  headerDate: `${headerInfoBlock} .src-c-article-card-info__date`,
  headerReadTime: `${headerInfoBlock} .src-c-article-card-info__readtime`,

  headerViewsAndStarsSection: `${headerViewsAndStarsSection}`,
  headerViewsIcon: `${headerViewsAndStarsSection} ${viewsIcon}`,
  headerViewsCount: `${headerViewsAndStarsSection} ${viewsCount}`,

  headerRatingStarsIconsSet: `${headerViewsAndStarsSection} ${ratingStarsIconsSet}`,
  headerRatingStarsIconsList: `${headerViewsAndStarsSection} ${ratingStarsIconsList}`,
  headerRatingCount: `${headerViewsAndStarsSection} ${ratingCount}`,

  newsSourceLabel: `${headerSection} .src-c-article-card-info__source`,
  //article left social block
  leftBlock: `${leftBlock}`,
  leftBlockCompanyName: `#social-part-left_443770915`,
  leftBlockCompanyFollowers: `#social-part-left_349784862`,
  leftBlockFollowButton: `${leftBlock} ${followButton}`,
  leftBlockUnfollowButton: `${leftBlock} ${unfollowButton}`,
  leftBlockRateThisButton: `${leftBlock} #set-ratings`,
  leftBlockRateThisStarIcon: `${leftBlock} #set-ratings_ratings`,
  leftBlockRateThisText: `${leftBlock} #set-ratings_rate-this`,
  leftBlockSetRatingPopup: `${leftBlock} .src-c-set-ratings__stars-block`,
  leftBlockSetRatingPopupStarsIconsList: `${leftBlock} mercer-icon[id^=set-ratings_rate]`,
  leftBlockBookmarkIcon: `${leftBlock} #bookmark-button`,
  leftBlockDownloadAttachIcon: `${leftBlock} #attachment-button_icon mercer-icon`,
  leftBlockDownloadAttachLink: `${leftBlock} #attachment-button_link`,
  leftBlockFacebookLink: `${leftBlock} #social-part-left_280983942`,
  leftBlockFacebookIcon: `${leftBlock} #social-part-left_993713579`,
  leftBlockLinkedinLink: `${leftBlock} #social-part-left_419371065`,
  leftBlockLinkedinIcon: `${leftBlock} #social-part-left_911977205`,
  leftBlockTwitterLink: `${leftBlock} #social-part-left_525814708`,
  leftBlockTwitterIcon: `${leftBlock} #social-part-left_359528010`,

  //article content
  content: `div.src-c-article-content__content`,
  //article video
  videoIframe: `#link_596078255 iframe`,
  videoError: `div#sub-frame-error`,
  videoErrorText: `div#sub-frame-error-details`,
  //article content buttons
  researchUrlLabel: `#research-page-container_748324181`, //not visible element, but contains attribute titile which could be set from Admin as Url Label field
  visitExternalLinkButton: `#link_42496557 a`,
  visitExternalLinkButtonIcon: `#link_42496557 a mercer-icon`,
  downloadFullReportButton: `[id^=attachment_item] a`,
  downloadFullReportButtonIcon: `[id^=attachment_item] a mercer-icon`,
  downloadFirstAttachmentFile: '#item-attachment-view_title_0',
  downloadNewsPostButton: `#article-read-full_attachment_button`,
  readFullButton: `#article-read-full_button`,
  readFullButtonLink: `#article-read-full_link`,
  //article disclaimer
  disclaimerLabel: `mercer-article-disclaimer h4`,
  disclaimerText: `mercer-article-disclaimer p`,

  //article footer
  //article tags
  footerTagsList: `[id^=article-footer_badge]`,
  //article rate this elements
  footerRateThisButton: `${footerSection} #set-ratings`,
  footerRateThisStarIcon: `${footerSection} #set-ratings_ratings-rated`,
  footerRateThisText: `${footerSection} #set-ratings_rate-this`,
  footerSetRatingPopup: `${footerSection} .src-c-set-ratings__stars-block`,
  footerSetRatingPopupStarsIconsList: `${footerSection} mercer-icon[id^=set-ratings_rate]`,
  footerRatingStarsIconsSet: `${footerSection} ${ratingStarsIconsSet}`,
  footerRatingStarsIconsList: `${footerSection} ${ratingStarsIconsList}`,
  //once article is rated - then this element will display text "You rated this" instead of count (in footer only)
  footerRatingCount: `${footerSection} ${ratingCount}`,
  //social links
  footerFacebookLink: `${footerSection} #article-footer_338574927`,
  footerFacebookIcon: `${footerSection} #article-footer_989714759`,
  footerLinkedinLink: `${footerSection} #article-footer_682826457`,
  footerLinkedinIcon: `${footerSection} #article-footer_807100450`,
  footerTwitterLink: `${footerSection} #article-footer_921162624`,
  footerBlockTwitterIcon: `${footerSection} #article-footer_100129229`,

  //author section in the footer
  authorCompanyLogo: `${authorSection} #company-logo`,
  authorCompanyName: `${authorSection} #author-footer-company_name`,
  authorCompanyFollowers: `${authorSection} #author-footer-company_followers`,
  authorFollowButton: `${authorSection} ${followButton}`,
  authorUnfollowButton: `${authorSection} ${unfollowButton}`,

  //related articles section
  relatedSection: `${relatedSection}`,
  relatedArticlesList: `${relatedArticlesList}`,
  relatedSectionHeader: `${relatedSection} h2`,
  relatedSectionExploreLink: `a.src-c-item-card-list-container__explore`,
  relatedSectionExploreLinkIcon: `a.src-c-item-card-list-container__explore mercer-icon`,
  //related articles details
  relatedArticlesList: `${relatedArticlesList}`,
  relatedArticlesTypesList: `${relatedArticlesList} mercer-badge`,
  relatedArticlesTitlesList: `${relatedArticlesList} .src-c-content-list-card__title`,
  relatedArticlesExcerptList: `${relatedArticlesList} .src-c-mercer-article-list-card__body`,
  relatedArticlesCompanyReadTimeDateInfoList: `${relatedArticlesList} .src-c-article-card-info`,
  relatedArticlesCompanyLogoIcons: `${relatedArticlesList} #company-logo`,
  relatedArticlesCompanyLogoTextsList: `${relatedArticlesList} #company-logo_abbreviation`,
  relatedArticlesCompanyNamesList: `${relatedArticlesList} .src-c-article-card-info__company-name`,
  relatedArticlesDatesList: `${relatedArticlesList} .src-c-article-card-info__date`,
  relatedArticlesReadTimeList: `${relatedArticlesList} .src-c-article-card-info__readtime`,
  relatedArticlesViewsAndStarsList: `${relatedArticlesViewsAndStarsList}`,
  relatedArticlesViewsIconsList: `${relatedArticlesViewsAndStarsList} ${viewsIcon}`,
  relatedArticlesViewsCountList: `${relatedArticlesViewsAndStarsList} ${viewsCount}`,
  relatedArticlesRatingStarsIconsSetList: `${relatedArticlesViewsAndStarsList} ${ratingStarsIconsSet}`,
  relatedArticlesRatingStarsIconsList: `${relatedArticlesViewsAndStarsList} ${ratingStarsIconsList}`,
  relatedArticlesRatingCountList: `${relatedArticlesViewsAndStarsList} ${ratingCount}`,
  relatedArticlesBookmarkIconsList: `${relatedArticlesList} #bookmark-button mercer-icon`,
  relatedArticlesDownloadAttachIconsList: `${relatedArticlesList} #attachment-button_icon mercer-icon`,
  relatedArticlesDownloadAttachLinksList: `${relatedArticlesList} #attachment-button_link`,
  relatedArticlesImagesList: `${relatedArticlesList} .src-c-content-list-card__image-container `,

  // rating modal
  ratingModalTitle: 'mercer-set-rating-modal > mercer-modal-header > div > h2',
  ratingModalTextFirstLine: 'mercer-set-rating-modal > mercer-modal-content p',
  ratingModalTextSecondLine: 'mercer-set-rating-modal > mercer-modal-content p > br:nth-child(1)',
  ratingModalTextThirdLine: 'mercer-set-rating-modal > mercer-modal-content p > br:nth-child(2)',
  ratingModalFirstRatingStar: '#set-ratings_rate-0',
  ratingModalToolTips: 'body > div.mos-c-tooltip.mos-c-tooltip__top.mos-c-tooltip--md.mos--fade-in > div.mos-c-tooltip-text',
  ratingModalSecondRatingStar: '#set-ratings_rate-1',
  ratingModalThirdRatingStar: '#set-ratings_rate-2',
  ratingModalFourthRatingStar: '#set-ratings_rate-3',
  ratingModalFifthRatingStar: '#set-ratings_rate-4',
  ratingModalInformationText: 'mercer-set-rating-modal > mercer-modal-footer > div > div div:nth-child(2)',
  ratingModalXButton: 'div > button > mercer-icon',
};
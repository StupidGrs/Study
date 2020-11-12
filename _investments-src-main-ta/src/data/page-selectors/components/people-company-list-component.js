/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */
const rowsList = `[class*=list__row]`;

module.exports = {
rowsList: `${rowsList}`,
companyLogoList: `[class*=list__logo]`,
personAvatarList: `[class*=list__row] [id^='person-avatar_person'] div`,
nameList: `[class*=list__title]`,
infoList: `[class*=list__subtitle]`,
unfollowButtonList: `${rowsList} #follow-button_following`,
followButtonList: `${rowsList} #follow-button_follow`,
};
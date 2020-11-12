/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */
const profileMenuSection = '.mos-c-dropdown__list';

module.exports = {
  profileMenuSection: `${profileMenuSection}`,
  profileMenuFirstLastNameLabel: `#header_416515434`,
  profileMenuAvatarImage: `#header_685283248`,
  profileMenuItemsList: `${profileMenuSection} .src-c-header__menu-row`,
  profileMenuItemsIconsList: `${profileMenuSection} .src-c-header__menu-row mercer-icon`,
  personAvatar: `#header_439256671 [id^="person-avatar"]`,
  profileLink: `#header_416515434`,
  eventsLink: `#header_579881403`,
  bookmarksLink: `#header_404322177`,
  postsLink: `#header_846395584`,
  logoutLink: `#header_475962491`
};
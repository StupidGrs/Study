const bookmarkResultsDiv = `#bookmarks-modal_131726849`;

module.exports = {
    headerText: `#bookmarks-modal_341726935`,
    headerDividerLine: `#bookmarks-modal_5309134 hr`,
    searchField: `#bookmarks-modal_74569131`,
    searchIcon: `#bookmarks-modal_183078935`,
    viewByLabel: `#bookmarks-modal_600218940`,
    viewByDropDownField: `#sortSelect`,
    viewByDropDownFieldOptionsList: `#sortSelect option`,
    noBookmarksTextMessage: `#bookmarks-modal_613565047`,
    bookmarkItemList: `[id^=bookmarks-modal_bookmark_]:not([id*=remove])`,
    bookmarkAvatarList: `${bookmarkResultsDiv} mercer-avatar`,
    bookmarkDateList: `${bookmarkResultsDiv} .src-c-bookmarks-modal__bookmark-date`,
    bookmarkTitleList: `${bookmarkResultsDiv} .src-c-bookmarks-modal__bookmark-title`,
    bookmarkRemoveIconList: `[id^=bookmarks-modal_bookmark_remove_] mercer-icon`,
    
    closeButton: `div.mos-c-modal-wrapper:not(.mos-c-modal-wrapper__edit-mode) button.mos-c-modal__close`,
};
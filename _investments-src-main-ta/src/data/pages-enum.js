/**
 * Used for library tests
 */

const loginPage = require('./page-selectors/login-page');
const mssoLoginPage = require('./page-selectors/msso-login-page');
const homePage = require('./page-selectors/home-page');
const newsPage = require('./page-selectors/news-page');
const researchPage = require('./page-selectors/research-page');
const publishResearchPage = require('./page-selectors/components/articles/publish-article-component');
const publishNewsPage = require('./page-selectors/components/articles/publish-article-component');
const createEventPage = require('./page-selectors/create-event-page');
const eventsPage = require('./page-selectors/events-page');
const directoriesPage = require('./page-selectors/directories-page');
const navigation = require('./page-selectors/navigation');
const modalWindow = require('./page-selectors/modal-window');
const header = require('./page-selectors/header');
const general = require('./page-selectors/general');
const toast = require('./page-selectors/popups/toast');
const calendar = require('./page-selectors/popups/calendar');
const contentListPage = require('./page-selectors/content-list-page');
const userPostsPage = require('./page-selectors/user-posts-page');
const researchDetailsPage = require('./page-selectors/research-details-page');
const newsDetailsPage = require('./page-selectors/news-details-page');
const eventDetailsPage = require('./page-selectors/components/events/event-details-component');
const unsavedChangesPopup = require('./page-selectors/popups/unsaved-changes');
const moderateResearchPage = require('./page-selectors/moderate-research-page');
const confirmationPopup = require('./page-selectors/popups/confirmation-popup');
const incompleteFormPopup = require('./page-selectors/popups/incomplete-form');
const imageSizeErrorPopup = require('./page-selectors/popups/image-size-error');
const userProfilePage = require('./page-selectors/user-profile-page');
const companyProfilePage = require('./page-selectors/company-profile-page');
const setRatingBlock = require('./page-selectors/set-rating-block');
const bookmarksPopup = require('./page-selectors/popups/bookmarks-popup');
const companyContent = require('./page-selectors/company-content-page');
const moderateUsersPage = require('./page-selectors/moderate-users-page');
const moderateEventPage = require('./page-selectors/moderate-event-page');
const notification = require('./page-selectors/components/notification');

module.exports = {
  general,
  navigation,
  loginPage,
  mssoLoginPage,
  homePage,
  newsPage,
  researchPage,
  eventsPage,
  directoriesPage,
  publishResearchPage,
  publishNewsPage,
  createEventPage,
  modalWindow,
  header,
  toast,
  calendar,
  contentListPage,
  userPostsPage,
  researchDetailsPage,
  newsDetailsPage,
  eventDetailsPage,
  unsavedChangesPopup,
  moderateResearchPage,
  moderateUsersPage,
  confirmationPopup,
  incompleteFormPopup,
  imageSizeErrorPopup,
  userProfilePage,
  companyProfilePage,
  setRatingBlock,
  bookmarksPopup,
  companyContent,
  moderateEventPage,
  notification
  // should be added all application pages depends on project needs
};

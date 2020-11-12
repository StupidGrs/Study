const dbDataAccess = require('../dbDataAccess');
const followCompanyData = require('../requestTemplates/followCompany');
const bookmarkArticle = require('../requestTemplates/bookmarkArticle');
const rateArticle = require('../requestTemplates/rateArticle');
const updateTargetUserData = require('../requestTemplates/updateTargetUser');
const updateCurrentUserProfileData = require('../requestTemplates/updateCurrentUserProfile');

module.exports = {

  getCurrentUserProfile: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "GET",
    path: '/personprofiles/current',
  }),

  updateCurrentUserProfile: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "PATCH",
    path: '/personprofiles/update-form',
    body: updateCurrentUserProfileData
  }),

  followCompany: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "PATCH",
    path: '/personprofiles/follow',
    contentType: 'application/json',
    body: followCompanyData
  }),

  unfollowCompany: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "PATCH",
    path: '/personprofiles/unfollow',
    contentType: 'application/json',
    body: followCompanyData
  }),

  rateArticle: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "PATCH",
    path: '/personprofiles/rate',
    contentType: 'application/json',
    body: rateArticle
  }),

  bookmarkArticle: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "PATCH",
    path: '/personprofiles/bookmark',
    contentType: 'application/json',
    body: bookmarkArticle
  }),

  getUsers: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "GET",
    path: '/personprofiles/search-persons',
    contentType: 'application/json'
  }),

  updateUser: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "PATCH",
    path: '/personprofiles/update-form',
    body: updateTargetUserData
  }),
};
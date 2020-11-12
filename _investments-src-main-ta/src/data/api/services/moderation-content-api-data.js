const dbDataAccess = require('../dbDataAccess');
const setApprovalStatus = require('../requestTemplates/setApprovalStatus');

module.exports = {

  setStatus: Object.assign({}, { baseUrl: dbDataAccess.baseUrl_BE }, {
    method: 'PUT',
    path: '/moderation-content/status/',
    contentType: 'application/json',
    body: setApprovalStatus
  }),

  getResearch: Object.assign({}, { baseUrl: dbDataAccess.baseUrl_BE }, {
    method: 'GET',
    path: '/moderation-content/research/',
    contentType: 'application/json'
  }),

  getNews: Object.assign({}, { baseUrl: dbDataAccess.baseUrl_BE }, {
    method: 'GET',
    path: '/moderation-content/news/',
    contentType: 'application/json'
  }),

  getEvent: Object.assign({}, { baseUrl: dbDataAccess.baseUrl_BE }, {
    method: 'GET',
    path: '/moderation-content/event/',
    contentType: 'application/json'
  }),

  updateResearch: Object.assign({}, { baseUrl: dbDataAccess.baseUrl_BE }, {
    method: 'PUT',
    path: '/moderation-content/form/research/',
    contentType: 'application/json'
  }),

  updateNews: Object.assign({}, { baseUrl: dbDataAccess.baseUrl_BE }, {
    method: 'PUT',
    path: '/moderation-content/form/news/',
    contentType: 'application/json'
  }),

  updateEvent: Object.assign({}, { baseUrl: dbDataAccess.baseUrl_BE }, {
    method: 'PUT',
    path: '/moderation-content/form/event/',
    contentType: 'application/json'
  }),

};
const dbDataAccess = require('../dbDataAccess');

module.exports = {

  getTaxonomies: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "GET",
    path: '/taxonomies',
  }),

};
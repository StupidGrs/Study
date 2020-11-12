const dbDataAccess = require('../dbDataAccess');

module.exports = {

  getCompanies: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "GET",
    path: '/companies',
  }),

  filterContent: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "GET",
    path: '/companies/filter-content',
  }),
};
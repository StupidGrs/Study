const dbDataAccess = require('../dbDataAccess');

module.exports = {

  getRegions: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "GET",
    path: '/regions',
  }),

};
const dbDataAccess = require('../dbDataAccess');

module.exports = {

  getUserRoles: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "GET",
    path: '/userroles',
  }),

};
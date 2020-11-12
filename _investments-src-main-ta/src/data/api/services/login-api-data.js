const dbDataAccess = require('../dbDataAccess');

module.exports = {

  mssoLoginWhitelist: Object.assign({}, { baseUrl: dbDataAccess.baseUrl_BE }, {
    method: "POST",
    path: '/msso/login/whitelist',
    contentType: 'application/json',
    body: {
      username: '',
      password: ''
    }
  }),
  skipLogin: Object.assign({}, { baseUrl: dbDataAccess.baseUrl_BE }, {
    method: "GET",
    path: '/msso/dev/login/'
  }),  
};
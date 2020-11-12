const dbDataAccess = require('../dbDataAccess');
module.exports = {

  getAllCountries: Object.assign({}, dbDataAccess, {
    method: "GET",
    path: '/countries',
    parameters: [
      {
        name: "collectionName",
        value: "countries"
      }
    ]
  }),

  addCountry: Object.assign({}, dbDataAccess, {
    method: "POST",
    path: '/countries/add',
  }),

  updateCountry: Object.assign({}, dbDataAccess, {
    method: "PUT",
    path: '/countries/update',
  }),

  deleteCountry: Object.assign({}, dbDataAccess, {
    method: "DELETE",
    path: '/countries/delete',
  }),

};
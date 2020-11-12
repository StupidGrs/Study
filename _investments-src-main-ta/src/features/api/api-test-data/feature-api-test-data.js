const countryApi = require("../../../data/api/services/country-api-data");
const automationCode = "feature1";
module.exports = {
  addNewCountriesSprint1Feature1: Object.assign({}, countryApi.addCountry, {
    body: [{
      name: "country1",
      automation: "true",
      automationCode: `${automationCode}`
    }, {
      name: "country2",
      automation: "true",
      automationCode: `${automationCode}`
    },]
  }),
  renameCountrySprint1Feature1: Object.assign({}, countryApi.updateCountry, {
    body: {
      countryId: "UNIQUE:firstCountryId_feature1:UNIQUE",
      newCountryName: "country1_renamed"
    }
  }),
  deleteCountrySprint1Feature1: Object.assign({}, countryApi.deleteCountry, {
    parameters:[
      {
        name: "countryId",
        value: "UNIQUE:firstCountryId_feature1:UNIQUE"
      }
    ]
  })

};
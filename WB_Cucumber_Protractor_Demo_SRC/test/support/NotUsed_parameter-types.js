/**
 * 2020-09-28
 * WB: this file is not used unless user want to customize the gherken description
 */




const textData = require('../../data/text-data.js');
const {defineParameterType} = require('cucumber');
const {stringHelper} = require('../helps/string-helper');
const userData = require('../../data/user-data');
const page = require('../../data/pages-enum');
const fileDataHash = require('../../data/file-data-hash.js');
const apiData = require("../../data/api/api-data-services");
const apiUtils = require("../../utils/api-util");
const Memory = require("../step-definitions/memory/Memory");
const utils = require("../step-definitions/utils/utils");

/**
 * @STRING_REGEXP
 * Regular expression for reading value inside the double quotes
 * double quotes are excluded from result
 * will work in case string contains more than one value inside the double quotes
 *
 * Examples:
 *
 * Code field "#form-question-code" is displayed
 * Preview table ".form-question-preview" with text "Question preview" is displayed
 */
const STRING_REGEXP = /"([^"\\]*(\\.[^"\\]*)*)"/;

/**
 * Used for adding description to elements.
 */
defineParameterType({
  regexp: /[^"]*/,
  name: 'detail',
  useForSnippets: false
});

/**
 * Used for CSS locators.
 * Json-nesting can be any. It depends on project needs.
 * But first parameter should obligatory be page name from page-enum.js.
 * Last parameter should obligatory be element name.
 *
 * @return {string} css locator as it was passed
 * or take it from data folder.
 */
defineParameterType({
  regexp: STRING_REGEXP,
  name: 'css',
  useForSnippets: true,
  transformer: function (string) {
    if (string.indexOf('|') !== -1) {
      const array = string.split('|');
      const pageName = array[0];
      const element = array[array.length - 1];
      let objectPath = page[pageName];

      for (let i = 1; i < array.length - 1; i++) {
        objectPath = objectPath[array[i]];
      }

      return objectPath[element];
    }

    return string;
  }
});

/**
 * Used for urls.
 * If string starts with 'http', will return string as it is.
 * Else will parse value and return it from user-data.js
 *
 * @return {string}
 */
defineParameterType({
  regexp: STRING_REGEXP,
  name: 'landing-url',
  useForSnippets: false,
  transformer: function (string) {
    if (string.indexOf('http') === 0) {
      return string;
    }
    const environment = browser.params.env;
    const url = userData.urls.ENV[environment] + userData.urls[string];

    return url;
  }
});

/**
 * Used for reading users from user-data.js
 */
defineParameterType({
  regexp: STRING_REGEXP,
  name: 'user',
  useForSnippets: false,
  transformer: function (role) {
    return userData.users[role];
  }
});

defineParameterType({
  regexp: STRING_REGEXP,
  name: 'map',
  useForSnippets: false,
  transformer: function (string) {
    return string.split('=');
  }
});

/**
 * Used for text values.
 * If string starts with "REGEXP:" - get string as regular expression.
 * If string starts with 'UNIQUE:' or 'UNIQUE-EMAIL:' - generate unique text value.
 * or read already generated unique value from global uniqueMap parameter.
 * @return {string}
 */
defineParameterType({
  regexp: STRING_REGEXP,
  name: 'text',
  useForSnippets: true,
  transformer: function (string) {
    let result = string.replace(/\\"/g, '"');

    result = stringHelper.getUniqueTextIfNeeded(result);
    result = stringHelper.convertToRegexpIfNeeded(result);
    result = Memory.parseValue(result);
    result = utils.textFromFileComporator(result);

    return result;
  }
});

/**
 * Used for hash values.
 * If string starts with 'HASH:' then value after ':' will be used for verification.
 * If HASH: is not set then hash should be defined in data/file-data-hash.js and name field should be provided
 * @return {string}
 */
defineParameterType({
  regexp: STRING_REGEXP,
  name: 'hash',
  useForSnippets: true,
  transformer: function (hash) {
    hash = hash.replace(/\\"/g, '"');
    if (hash.indexOf('HASH:') >= 0) {
      return hash.split('HASH:').pop();
    }

    return fileDataHash.hashes[hash];
  }
});

/**
 * Used for reading services from api-data.js
 * Allow to use "UNIQUE:{paramName}:UNIQUE" in service body to insert data saved in global.uniqueMap["{paramName}"] on air
 * EXAMPLE:
 * body: {
      "data": {
      "id": "UNIQUE:storyNum_stored_expected_id:UNIQUE"
      }
    }
 * @return {string}
 */
defineParameterType({
  regexp: STRING_REGEXP,
  name: 'service',
  useForSnippets: false,
  transformer: (service) => {
    if (service.includes('DELETE')) {
      return browser.getSession().then(session => {
       // apiData.services[service].id = global.uniqueMap[`${session['id_']}_id`];
      }).then(() => {
        return apiData.services[service];
      });
    }
    // Replace data that contains UNIQUE:{someValue}:UNIQUE tag in body with data from global.uniqueMap
    if (typeof apiData.services[service].body !== "undefined") {
      const allNodes = apiUtils.getAllNodesFromJson(apiData.services[service].body);
      for (let node of allNodes) {
        if (typeof node.value === "string") {
          apiUtils.replaceValueInProperty(apiData.services[service].body, node.path, stringHelper.getUniqueTextIfNeeded(node.value));
        }
      }
    }


    return apiData.services[service];
  }
});

/**
 * Used for returning api functions
 * @return {string}
 */
defineParameterType({
  regexp: STRING_REGEXP,
  name: 'request',
  useForSnippets: false,
  transformer: (request) => {
    return request.toUpperCase();
  }
});

/**
 * Used for localized text values.
 * Checks global parameter "lan" and get appropriate value from text-data.js
 * Format of text initialisation "LOGINPAGE|loginErrorEmpty"
 * If string starts with "REGEXP:" - get string as regular expression.
 * Used for library tests
 * For example: loginErrorEmpty: 'REGEXP:Bad Request'
 * @return {string}
 */
defineParameterType({
  regexp: STRING_REGEXP,
  name: 'localized-text',
  useForSnippets: true,
  transformer(string) {
    if (string.indexOf('|') > 0) {
      const dataArray = string.split('|');
      const pageWithText = dataArray[0];
      const language = browser.params.language;
      let textPath = textData[pageWithText][language];
      for (let i = 1; i < dataArray.length; i++) {
        textPath = textPath[dataArray[i]];
      }

      return stringHelper.convertToRegexpIfNeeded(textPath);
    }

    return stringHelper.getUniqueTextIfNeeded(string);
  }
});
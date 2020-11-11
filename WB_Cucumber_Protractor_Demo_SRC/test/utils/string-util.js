const uuidv4 = require('uuid/v4');

const getTextWithUniqueGuid = (text) => {
  return text + '_' + uuidv4();
};

/**
 * @example str
 * 'regions':['Asia'], 'taxonomies':['Real Estate']
 * 
 * @example from test step
 * Then User "COMPANY_ADMIN" publishes "Event" with title "$eventTitle" and "'regions':['Asia'], 'taxonomies':['Real Estate']" with API
 * 
 * @param str - attributes passed as a string in the test
 */
const parseStringAttributes = (str) => {
  const jsonStr = '{' + str.replace(/'/g, '"') + '}';
  const jsonObj = JSON.parse(jsonStr);

  return jsonObj;
};

module.exports = {
  getTextWithUniqueGuid,
  parseStringAttributes
}
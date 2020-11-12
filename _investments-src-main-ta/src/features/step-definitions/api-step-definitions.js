const { Given, When, Then } = require('cucumber');
const { endpointHelper } = require('ngpd-merceros-testautomation-ta');
const expect = require('chai').expect;
const utils = require("../../utils/api-util");
const api_requests = require("../step-definitions/utils/api_requests");
const stringUtils = require('../../utils/string-util');
const userData = require('../../data/user-data');
const Memory = require("./memory/Memory");

const GLOBAL_ADMIN_USER = userData.users['GLOBAL_ADMIN'];
const COMPANY_ADMIN_USER = userData.users['COMPANY_ADMIN'];

// /**
//  * Send request to the API
//  *
//  * @example
//  * User sends "POST" request to "countryPOST" API
//  *
//  * @example
//  * How api data should look like
//  * countryPOST: {
//         path: '/country',
//         appName: "geography",
//         body: {
//             "data": {
//                 "countryCode": "BEL",
//                 "countryName": "BELARUS",
//                 "extendedProperties": {
//                     "effectiveDate": "2017-06-01T00:00:00.000+0000",
//                     "effectiveEndDate": "9999-12-31T00:00:00.000+0000"
//                 },
//                 "currencies": [{
//                     "currencyCode": "Ruble",
//                     "startDate": "2017-06-01T00:00:00.000+0000",
//                     "endDate": "9999-12-31T00:00:00.000+0000",
//                     "default": true
//                 }]
//             }
//         }
//     }
//  * @param request should be named as one of the http functions (GET, POST, PUT, DELETE)
//  * @param service should be named as in api-data.js
//  * @param withOrWithoutBody should be named as "without body" or "with body" for request with body or not
//  */
// Given('User sends {request} request to {service} API', (request, service) => {
//   return browser.getSession().then(session => {
//     const id = service.id || global.uniqueMap[`_id`] || "";
//     const queryParams = service.parameters ? utils.query(service.parameters) : "";
//     const serviceUri = `${service.baseUrl}${service.path}${id}${queryParams}`;
//     const map = new Map();

//     map.set("Content-Type", "application/json");

//     const serviceBody = typeof service.body !== "undefined" ? JSON.stringify(service.body) : "";

//     return endpointHelper.sendRequest(request, serviceUri, serviceBody, map).then(response => {
//       response.requestFunction = request;
//       response.serviceUri = serviceUri;
//       response.requestBody = serviceBody;

//       // store response to global.uniqueMap to be able to use it in next steps
//       global.uniqueMap[`${session['id_']}response`] = response;
//     });
//   });
// });


// Given('User sends {service} API request', (service) => {
//   return browser.getSession().then(session => {
//     const request = service.method;
//     const id = service.id || global.uniqueMap[`_id`] || "";
//     const queryParams = service.parameters ? utils.query(service.parameters) : "";
//     const serviceUri = `${service.baseUrl}${service.path}${id}${queryParams}`;
//     const map = new Map();

//     map.set("Content-Type", "application/json");
//     const serviceBody = typeof service.body !== "undefined" ? JSON.stringify(service.body) : "";

//     return endpointHelper.sendRequest(request, serviceUri, serviceBody, map).then(response => {
//       response.requestFunction = request;
//       response.serviceUri = serviceUri;
//       response.requestBody = serviceBody;

//       // store response to global.uniqueMap to be able to use it in next steps
//       global.uniqueMap[`${session['id_']}response`] = response;
//     });
//   });

// });

// /**
//  * Comparing response status code with given
//  *
//  * @example
//  * Status Code is "200"
//  *
//  * @param statusCode should be valid status code
//  */
// Then('Status Code is {text}', (statusCode) => {
//   return browser.getSession().then(session => {
//     const response = global.uniqueMap[`${session['id_']}response`];
//     const requestBody = response.requestBody || '';

//     expect(response.status, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: '${requestBody}'\n`).to.equal(parseInt(statusCode));
//   });
// });

// /**
//  * Verifying that response contains all models
//  *
//  * @example
//  * Response "body.data" contains:
//  *       | _id                   |
//  *       | appId                 |
//  *       | serviceCategory       |
//  *
//  * @param responseElement response property nesting by "."
//  * @param dataTable given data table with all properties
//  */
// Then('Response {text} contains:', (responseElement, dataTable) => {
//   return browser.getSession().then(session => {
//     const response = global.uniqueMap[`${session['id_']}response`];
//     const property = utils.objectParser(response, responseElement);
//     const requestBody = response.requestBody || '';

//     if (Array.isArray(property) && property.length > 0) {
//       property.forEach(data => {
//         dataTable.rawTable.join().split(",").forEach(value => {
//           expect(data, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: '${requestBody}'\n`).to.have.property(value);
//         })
//       });
//     } else {
//       dataTable.rawTable.join().split(",").forEach(value => {
//         expect(property, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: '${requestBody}'\n`).to.have.property(value);
//       })
//     }
//   });
// });

// /**
//  * Verifying that response model has necessary type
//  *
//  * @example
//  * Response "body.data" is an "array"
//  *
//  * @param responseElement response property nesting by "."
//  * @param type should be named as expected value type
//  */
// Then('Response {text} is a(n) {text}', (responseElement, type) => {
//   return browser.getSession().then(session => {
//     const response = global.uniqueMap[`${session['id_']}response`];
//     const property = utils.objectParser(response, responseElement);
//     const requestBody = response.requestBody || '';
//     expect(property, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: '${requestBody}'\n`).to.be.an(type);
//   });
// });

// /**
//  * Verify that array size is equal to|less than|greater than given number
//  *
//  * @example
//  * Response "body.data" size is "greater than" "0"
//  *
//  * @param responseElement response property nesting by "."
//  * @param action should be named as expected action (equal to|less than|greater)
//  * @param expectedValue Number for comparing with array size
//  */
// Then('Response {text} size is {text} {text}', (responseElement, action, expectedValue) => {
//   return browser.getSession().then(session => {
//     const response = global.uniqueMap[`${session['id_']}response`];
//     const count = utils.objectParser(response, responseElement).length;
//     const requestBody = response.requestBody || '';
//     switch (action) {
//       case "equal to":
//         return expect(count, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: '${requestBody}'\n`).to.equal(parseInt(expectedValue));
//       case "less than":
//         return expect(count, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: '${requestBody}'\n`).to.be.lessThan(parseInt(expectedValue));
//       case "greater than":
//         return expect(count, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: '${requestBody}'\n`).to.be.greaterThan(parseInt(expectedValue));
//       default:
//         throw Error(`${action} is not defined`);
//     }
//   });
// });

// /**
//  * Verifying that every item in array or just one response model has necessary type
//  *
//  * @example
//  * Response "every property" "_id" in "body.data" is a "String"
//  *
//  * @param every flag for checking array every value's or not
//  * @param property response model property
//  * @param responseElement response property nesting by "."
//  * @param type should be named as expected value type
//  */
// Then('Response {text} {text} in {text} is a(n) {text}', (every, property, responseElement, type) => {
//   return browser.getSession().then(session => {
//     const response = global.uniqueMap[`${session['id_']}response`];
//     const responseProperty = utils.objectParser(response, responseElement);
//     const requestBody = response.requestBody || '';
//     if (every.toLowerCase() === "every property") {
//       responseProperty.forEach(data => {
//         expect(data[property], `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: '${requestBody}'\n`).to.be.an(type);
//       });
//     } else {
//       expect(responseProperty[property], `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: '${requestBody}'\n`).to.be.an(type);
//     }
//   });
// });

// /**
//  * Verifying that every item in array or just one response model is equal to given value
//  *
//  * @example
//  * Response "property" "serviceCategory" in "body.data" is "equal to" "5afda076883f893c2c68ddc4"
//  *
//  * @param every flag for checking array value's or not
//  * @param property response model property
//  * @param responseElement response property nesting by "."
//  * @param expected should be named as expected action (be equal to|contain)
//  * @param value value for comparing with model property
//  */
// Then('Response {text} {text} in {text} is {text} {text}', (every, property, responseElement, expected, value) => {
//   return browser.getSession().then(session => {
//     const response = global.uniqueMap[`${session['id_']}response`];
//     const responseProperty = utils.objectParser(response, responseElement);
//     value = value.startsWith("$") ? global.uniqueMap[`${value.slice(1)}`].slice(1) : value;

//     if (every.toLowerCase() === "every property") {
//       responseProperty.forEach(data => {
//         utils.stringComparator(data[property], value, expected);
//       });
//     } else {
//       utils.stringComparator(responseProperty[property], value, expected);
//     }
//   });
// });

// /**
//  * Remembering model property in to the memory for future work
//  *
//  * @example
//  * User remembers response property "_id" in "responseText.body.data"
//  * or
//  * User remembers response property "_id" in "responseText.data" as "yourParameterName"
//  *
//  * @param responseElement response property nesting by "."
//  * @param property response model property
//  */
// When('User remembers response property {text} in {text} as {text}', async (property, responseElement, rememberAs) => {
//   const session = await browser.getSession();
//   const response = global.uniqueMap[`${session['id_']}response`];
//   const responseProperty = utils.objectParser(response, responseElement);

//   global.uniqueMap[rememberAs] = responseProperty[property];
// });

// /**
//  * Remembering model property in to the memory for future work using jsonPath as finder
//  *
//  * @example
//  * User remembers response property "$.._id" as "yourParameterName"
//  *
//  * @param pathQuery json path query to find a property
//  * @param rememberAs param name to store value fond by pathQuery
//  * path query examples: https://www.npmjs.com/package/jsonpath
//  */
// When('User remembers response property {text} as {text}', async (pathQuery, rememberAs) => {
//   const session = await browser.getSession();
//   const response = global.uniqueMap[`${session['id_']}response`];
//   global.uniqueMap[rememberAs] = utils.getValueOfPropertyFromJson(response, pathQuery);
// });

// /**
//  * Replace the value of property in object using jsonPath and send an updated request
//  *
//  * @example
//  *  Given User replace value of property "$..team" with new value "test" in "BOF_125_CreateNewUserJuniorConsultant" and send it
//  *  example replace all "team" properties found with new value provided
//  *
//  * @param propertyPath use jsonPath rules to provide path to property
//  * @newPropertyValue property response model property
//  */
// Given('User replace value of property {string} with new value {text} in {service} and send it', (propertyPath, newPropertyValue, service) => {
//   return browser.getSession().then(session => {
//     const path = service.path;
//     const id = service.id || global.uniqueMap[`_id`] || "";
//     const queryParams = service.parameters ? utils.query(service.parameters) : "";
//     const serviceUri = `${service.baseUrl}${path}${id}${queryParams}`;
//     const map = new Map();
//     let newService = Object.create(service);
//     utils.replaceValueInProperty(newService.body, propertyPath, newPropertyValue);
//     map.set("Content-Type", "application/json");

//     return endpointHelper.sendRequest(newService.method, serviceUri, JSON.stringify(newService.body), map).then(response => {
//       response.requestFunction = newService.method;
//       response.serviceUri = serviceUri;
//       response.requestBody = JSON.stringify(newService.body);

//       global.uniqueMap[`${session['id_']}response`] = response;
//     });
//   });
// });

// /**
//  * Compare response property value with expected using jsonPath as finder
//  *
//  * @example
//  * User verify response contains property "_id" with value "123123123"
//  *
//  * @param propertyName any JSON property
//  * @param expectedValue param name compare with actual property value found
//  * path query examples: https://www.npmjs.com/package/jsonpath
//  */
// When('User verify response contains property {text} with value {text}', async (propertyName, expectedValue) => {
//   const pathQuery = `$..[?(@.${propertyName}=='${expectedValue}')]`;
//   const session = await browser.getSession();
//   const response = global.uniqueMap[`${session['id_']}response`];

//   return expect(utils.getValueOfPropertyFromJson(response, pathQuery), `${response.body} doesn't contain expected value: ${expectedValue}`).not.to.be.undefined;
// });
// /**
//  * Verify response doesn't contain property with expected value using jsonPath as finder
//  *
//  * @example
//  * User verify response doesn't contain property "_id" with value "123123123"
//  *
//  * @param propertyName any JSON property
//  * @param expectedValue param name compare with actual property value found
//  * path query examples: https://www.npmjs.com/package/jsonpath
//  */
// When('User verify response doesn\'t contain property {text} with value {text}', async (propertyName, expectedValue) => {
//   const pathQuery = `$..[?(@.${propertyName}=='${expectedValue}')]`;
//   const session = await browser.getSession();
//   const response = global.uniqueMap[`${session['id_']}response`];

//   return expect(utils.getValueOfPropertyFromJson(response, pathQuery), `${response.body} doesn't contain expected value: ${expectedValue}`).to.be.undefined;
// });

/**
 * Login as specified user to perform API calls
 * 
 * @example
 * User "USER_PUBLISHER" logs in with API
 * 
 * @param user user role from user-data.js
 */
When('User {user} logs in with API', async function (user) {
  const response = await api_requests.setAuthorizationHeader(user);
  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(302);
});

/**
 * Sends request to delete specified Resource which Attribute equal to specified Value
 * 
 * @example
 * User deletes "Research" with "Title" equal to "Test_Auto_Research_Title"
 * @example
 * User deletes "Events" with "Title" equal to "Test_Auto_Event_Title"
 * 
 * @param resource resource to be deleted
 * @param attr attribute of resource object
 * @param searchValue expected value of attribute
 */
When('User deletes {text} with {text} equal to {text}', async function (resource, attr, searchValue) {
  //remember data to delete, it will be delete once all tests are finished in onComplete action
  //return global.uniqueMap['DeleteAfterTestRun'].push({'resource': resource, 'attr': attr, 'searchValue': searchValue });

  return api_requests.deleteResourceByAttr(resource, searchValue, attr);
});

/**
 * Sends request on behalf of specified User to create specified Resource within specified Title
 * 
 * @example
 * User "COMPANY_ADMIN" publishes "Research" with title "Test_Auto_Research_Title" with API
 * @example
 * User "COMPANY_ADMIN" publishes "Event" with title "Test_Auto_Event_Title" with API
 * 
 * @param user user role from user-data.js
 * @param resource resource to be created
 * @param resourceTitle title of the resource to be created
 * 
 */
When('User {user} publishes {text} with title {text} with API', async function (user, resource, resourceTitle) {
  const response = await api_requests.submitResource(user, resource, { 'title': resourceTitle });
  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(201);
});

/**
 * Sends request on behalf of specified User to create specified Resource within specified Title on behalf of specified Company
 * 
 * @example
 * User "COMPANY_ADMIN" publishes "Research" with title "Test_Auto_Research_Title" and company "Mercer" with API
 * @example
 * User "COMPANY_ADMIN" publishes "Event" with title "Test_Auto_Event_Title" and company "Mercer" with API
 * 
 * @param user user role from user-data.js
 * @param resource resource to be created
 * @param resourceTitle title of the resource to be created
 * 
 */
When('User {user} publishes {text} with title {text} and company {text} with API', async function (user, resource, resourceTitle, companyName) {
  const company = (await api_requests.getCompanies(user, companyName))[0];
  const response = await api_requests.submitResource(user, resource, { 'title': resourceTitle, 'company': company });
  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(201);
});

/**
 * Sends request to delete all Resources with specified Attribute that contains specified Value
 * 
 * @example
 * User deletes all "Researches" with "Title" that contains text "Test_Auto"
 * @example
 * User deletes all "Events" with "Title" that contains text "Test_Auto"
 * 
 * @param resource resource to be deleted
 * @param attr attribute of resource object
 * @param searchValue expected value of attribute
 */
When('User deletes all {text} with {text} that contains text {text}', async function (resource, attr, searchValue) {
  return api_requests.deleteResourceByAttr(resource, searchValue, attr, '_contains');
});

/**
 * Sends request on behalf of specified User to set Pending status (Unapprove) for Resource with specified Title
 * 
 * @example
 * User "GLOBAL_ADMIN" unapproves "Event" with title "Test_Auto_Events_Title" with API
 * User "GLOBAL_ADMIN" unapproves "Research" with title "Test_Auto_Events_Title" with API
 * User "GLOBAL_ADMIN" unapproves "News" with title "Test_Auto_Events_Title" with API
 * 
 * @param user user role from user-data.js
 * @param resource resource type
 * @param resourceTitle resource title
 * 
 */
When('User {user} unapproves {text} with title {text} with API', async function (user, resource, resourceTitle) {


  const response = await api_requests.setApprovalStatusByTitle(user, resource, resourceTitle, 'pending');
  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(200);
});

/**
 * Sends request on behalf of specified User to set Approved status for Resource with specified Title
 * 
 * @example
 * User "GLOBAL_ADMIN" approves "Event" with title "Test_Auto_Events_Title" with API
 * User "GLOBAL_ADMIN" approves "Research" with title "Test_Auto_Events_Title" with API
 * User "GLOBAL_ADMIN" approves "News" with title "Test_Auto_Events_Title" with API
 * 
 * @param user user role from user-data.js
 * @param resource resource type
 * @param resourceTitle resource title
 * 
 */
When('User {user} approves {text} with title {text} with API', async function (user, resource, resourceTitle) {

    console.log("------ User {user} approves {text} with title {text} with API ----------");
    console.log("user: " + user);
    console.log("resource: " + resource);
    console.log("resourceTitle: " + resourceTitle);
  const response = await api_requests.setApprovalStatusByTitle(user, resource, resourceTitle, 'approved');
  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(200);
});


/**
 * Sends request on behalf of specified User to set Rejected status for Resource with specified Title
 * 
 * @example
 * User "GLOBAL_ADMIN" rejects "Event" with title "Test_Auto_Events_Title" with API
 * User "GLOBAL_ADMIN" rejects "Research" with title "Test_Auto_Events_Title" with API
 * User "GLOBAL_ADMIN" rejects "News" with title "Test_Auto_Events_Title" with API
 * 
 * @param user user role from user-data.js
 * @param resource resource type
 * @param resourceTitle resource title
 * 
 */
When('User {user} rejects {text} with title {text} with API', async function (user, resource, resourceTitle) {
  const response = await api_requests.setApprovalStatusByTitle(user, resource, resourceTitle, 'rejected', `Test_Auto Rejected Reason for ${resourceTitle}`);
  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(200);
});

/**
 * Sends request on behalf of specified User to create Event within specified Title and Start and End dates with time
 * 
 * @example
 * User "COMPANY_ADMIN" publishes Event with title "$eventTitle1" and Start Date "9/30/2019" and Time "4:10" and End Date "9/30/2019" and Time "5:10" with API
 * 
 * @param user user role from user-data.js
 * @param eventTitle event title
 * @param startDate event Start date
 * @param startTime event Start time
 * @param endDate event End date
 * @param endTime event End time
 * 
 */
When('User {user} publishes Event with title {text} and Start Date {text} and Time {text} and End Date {text} and Time {text} with API', async function (user, eventTitle, startDate, startTime, endDate, endTime) {
  let startDateTime = startTime ? (startDate + ' ' + startTime) : startDate;
  let endDateTime = endTime ? (endDate + ' ' + endTime) : endDate;

  const eventData = {
    title: eventTitle,
    start_date: startDateTime,
    end_date: endDateTime
  };

  const response = await api_requests.submitResource(user, 'Events', eventData);

  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(201);
});


/**
 * Sends request on behalf of specified User to create Event within specified Title and Start and End dates
 * 
 * @example
 * User "COMPANY_ADMIN" publishes Event with title "Test_Auto_Event_Title" and Start Date "" and End Date "" with API
 * 
 * @param user user role from user-data.js
 * @param eventTitle event title
 * @param startDate event Start date
 * @param endDate event End date
 * 
 */
When('User {user} publishes Event with title {text} and Start Date {text} and End Date {text} with API', async function (user, eventTitle, startDate, endDate) {

  const eventData = {
    title: eventTitle,
    start_date: startDate,
    end_date: endDate
  };

  const response = await api_requests.submitResource(user, 'Events', eventData);

  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(201);
});

/**
 * Sends request on behalf of specified User to create specified Resource (Event or Research) within specified Title and additional specified attributes
 * 
 * @example
 * User "GLOBAL_ADMIN" publishes "Event" with title "$eventTitle" and "'regions':['Asia','EMEA'], 'taxonomies':['Real Estate', 'Broad Equity'], 'tags':'Investing', 'type':'Webinar', 'start_date':'9/30/2019', 'end_date':'10/10/2019'" with API
 * 
 * @param user user role from user-data.js
 * @param resource resource to be created
 * @param resourceTitle title of the resource to be created
 * @param additionalAttributes additional attributes
 * 
 */
When('User {user} publishes {text} with title {text} and {text} with API', async function (user, resource, resourceTitle, additionalAttributes) {

  const fieldsData = stringUtils.parseStringAttributes(additionalAttributes);
  const inputData = {
    title: resourceTitle,
    ...fieldsData
  };
  const response = await api_requests.submitResource(user, resource, inputData);

  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(201);
});

/**
 * Sends request on behalf of specified User to create specified Resource within specified Title
 * 
 * @example
 * User "COMPANY_ADMIN" publishes "Research" with title "Test_Auto_Research_Title" with API
 * @example
 * User "COMPANY_ADMIN" publishes "Event" with title "Test_Auto_Event_Title" with API
 * 
 * @param user user role from user-data.js
 * @param resource resource to be created
 * @param resourceTitle title of the resource to be created
 * 
 */
When('User {user} publishes {text} with all fields and title {text} with API', async function (user, resource, resourceTitle) {
  const response = await api_requests.submitResourceWithAllFields(user, resource, { 'title': resourceTitle });
  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(201);
});

/**
 * Sends request on behalf of specified User to create specified Resource in Draft Status within specified Title and all fields
 * 
 * @example
 * User "COMPANY_ADMIN" saves Draft "Research" with title "Test_Auto_Research_Title" with API
 * @example
 * User "COMPANY_ADMIN" saves Draft "Event" with title "Test_Auto_Event_Title" with API
 * 
 * @param user user role from user-data.js
 * @param resource resource to be created
 * @param resourceTitle title of the resource to be created
 * 
 */
When('User {user} saves Draft {text} with all fields and title {text} with API', async function (user, resource, resourceTitle) {
  const response = await api_requests.saveDraftResourceWithAllFields(user, resource, { 'title': resourceTitle });
  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(201);
});

/**
 * Sends request on behalf of specified User to create specified Resource in Draft Status within specified Title
 * 
 * @example
 * User "COMPANY_ADMIN" saves Draft "Research" with title "Test_Auto_Research_Title" with API
 * @example
 * User "COMPANY_ADMIN" saves Draft "Event" with title "Test_Auto_Event_Title" with API
 * 
 * @param user user role from user-data.js
 * @param resource resource to be created
 * @param resourceTitle title of the resource to be created
 * 
 */
When('User {user} saves Draft {text} with title {text} with API', async function (user, resource, resourceTitle) {
  const response = await api_requests.saveDraftResource(user, resource, { 'title': resourceTitle });
  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(201);
});

/**
 * Sends request on behalf of specified User to save Draft Event with all fields and specified Title, Start and End dates with time
 * 
 * @example
 * User "COMPANY_ADMIN" saves Draft Event with all fields and title "$eventTitle1" and Start Date "9/30/2019" and Time "4:10" and End Date "9/30/2019" and Time "5:10" with API
 * 
 * @param user user role from user-data.js
 * @param eventTitle event title
 * @param startDate event Start date
 * @param startTime event Start time
 * @param endDate event End date
 * @param endTime event End time
 * 
 */
When('User {user} saves Draft Event with all fields and title {text} and Start Date {text} and Time {text} and End Date {text} and Time {text} with API', async function (user, eventTitle, startDate, startTime, endDate, endTime) {
  let startDateTime = startTime ? (startDate + ' ' + startTime) : startDate;
  let endDateTime = endTime ? (endDate + ' ' + endTime) : endDate;

  const eventData = {
    title: eventTitle,
    start_date: startDateTime,
    end_date: endDateTime
  };

  const response = await api_requests.saveDraftResourceWithAllFields(user, 'Events', eventData);

  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(201);
});

/**
 * Sends request on behalf of specified User to save Draft Event within specified Title and Start and End dates with time
 * 
 * @example
 * User "COMPANY_ADMIN" saves Draft Event with title "$eventTitle1" and Start Date "9/30/2019" and Time "4:10" and End Date "9/30/2019" and Time "5:10" with API
 * 
 * @param user user role from user-data.js
 * @param eventTitle event title
 * @param startDate event Start date
 * @param startTime event Start time
 * @param endDate event End date
 * @param endTime event End time
 * 
 */
When('User {user} saves Draft Event with title {text} and Start Date {text} and Time {text} and End Date {text} and Time {text} with API', async function (user, eventTitle, startDate, startTime, endDate, endTime) {
  let startDateTime = startTime ? (startDate + ' ' + startTime) : startDate;
  let endDateTime = endTime ? (endDate + ' ' + endTime) : endDate;

  const eventData = {
    title: eventTitle,
    start_date: startDateTime,
    end_date: endDateTime
  };

  const response = await api_requests.saveDraftResource(user, 'Events', eventData);

  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(201);
});

/**
 * Sends request on behalf of specified User to publish Event with all fields and specified Title, Start and End dates with time
 * 
 * @example
 * User "COMPANY_ADMIN" publishes Event with all fields and title "$eventTitle1" and Start Date "9/30/2019" and Time "4:10" and End Date "9/30/2019" and Time "5:10" with API
 * 
 * @param user user role from user-data.js
 * @param eventTitle event title
 * @param startDate event Start date
 * @param startTime event Start time
 * @param endDate event End date
 * @param endTime event End time
 * 
 */
When('User {user} publishes Event with all fields and title {text} and Start Date {text} and Time {text} and End Date {text} and Time {text} with API', async function (user, eventTitle, startDate, startTime, endDate, endTime) {
  let startDateTime = startTime ? (startDate + ' ' + startTime) : startDate;
  let endDateTime = endTime ? (endDate + ' ' + endTime) : endDate;

  const eventData = {
    title: eventTitle,
    start_date: startDateTime,
    end_date: endDateTime
  };

  const response = await api_requests.submitResourceWithAllFields(user, 'Events', eventData);

  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(201);
});

/**
 * Sends request on behalf of specified User to follow Company
 * 
 * @example
 * User "COMPANY_ADMIN" follows "CompAuto" Company with API
 * 
 * @param user user role from user-data.js
 * @param companyName company name
 * 
 */
When('User {user} follows {text} Company with API', async function (user, companyName) {
  const response = await api_requests.followCompanyByName(user, companyName, true);

  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(200);
});


/**
 * Sends request on behalf of specified User to unfollow Company
 * 
 * @example
 * User "COMPANY_ADMIN" follows "CompAuto" Company with API
 * 
 * @param user user role from user-data.js
 * @param companyName company name
 * 
 */
When('User {user} unfollows {text} Company with API', async function (user, companyName) {
  const response = await api_requests.followCompanyByName(user, companyName, false);

  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(200);
});

/**
 * Sends request on behalf of specified User to rate Article
 * 
 * @example
 * User "COMPANY_ADMIN" sets 5 stars to Article with title "Test_Auto" with API
 * 
 * @param user user role from user-data.js
 * @param rate rate
 * @param articleTitle article title
 * 
 */
When('User {user} sets {int} stars to Article with title {text} with API', async function (user, rate, articleTitle) {
  const response = await api_requests.rateArticleByTitle(user, articleTitle, rate);

  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(200);
});

/**
 * Sends request on behalf of specified User to unfollow from all Companies
 * 
 * @example
 * User "COMPANY_ADMIN" unfollows from all Companies with API
 * 
 * @param user user role from user-data.js
 * @param companyName company name
 * 
 */
When('User {user} unfollows from all Companies with API', async function (user) {
  const response = await api_requests.unfollowUserFromAllCompanies(user);

  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}`).to.equal(200);
});

/**
 * Sends request on behalf of specified User to bookmark specified Article (or remove bookmark)
 * 
 * @example
 * User "COMPANY_ADMIN" bookmarks Article with title "Test_Auto" with API
 * 
 * @param user user role from user-data.js
 * @param articleTitle article title
 * 
 */
When('User {user} bookmarks Article with title {text} with API', async function (user, articleTitle) {
  const response = await api_requests.bookmarkArticleByTitle(user, articleTitle);

  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}`).to.equal(200);
});

/**
 * Sends request on behalf of specified User to create specified Resource within specified Title and Publish Date
 * 
 * @example
 * User "COMPANY_ADMIN" publishes "Research" with title "Test_Auto_Research_Title" and publish date "2020-12-20T00:00:00.000Z" with API
 * @example
 * User "COMPANY_ADMIN" publishes "News" with title "Test_Auto_News_Title" and publish date "2020-12-20" with API
 * 
 * @param user user role from user-data.js
 * @param resource resource to be created
 * @param resourceTitle title of the resource to be created
 * 
 */
When('User {user} publishes {text} with title {text} and publish date {text} with API', async function (user, resource, resourceTitle, date) {
  date = new Date(date).toISOString();
  const response = await api_requests.submitResource(user, resource, { 'title': resourceTitle, 'date': date });
  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(201);
});

/** 
 * Sends request on behalf of specified User to create specified Resource with all fields and within specified Title and Publish Date
 * 
 * @example
 * User "COMPANY_ADMIN" publishes "Research" with all fields and title "Test_Auto_Research_Title" and publish date "2020-12-20T00:00:00.000Z" with API
 * @example
 * User "COMPANY_ADMIN" publishes "News" with all fields and title "Test_Auto_News_Title" and publish date "2020-12-20" with API
 * 
 * @param user user role from user-data.js
 * @param resource resource to be created
 * @param resourceTitle title of the resource to be created
 * 
 */
When('User {user} publishes {text} with all fields and title {text} and publish date {text} with API', async function (user, resource, resourceTitle, date) {
  date = new Date(date).toISOString();
  const response = await api_requests.submitResourceWithAllFields(user, resource, { 'title': resourceTitle, 'date': date });
  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(201);
});

/** 
 * Sends request on behalf of specified User to set "is_featured" flag to the Resource within specified Title
 * 
 * @example
 * User "GLOBAL_ADMIN" sets Featured "true" for "News" with title "$newsTitle" with API
 * 
 * @param user user role from user-data.js
 * @param isFeatured boolean flag
 * @param resource resource to be created
 * @param resourceTitle title of the resource to be created
 * 
 */
When('User {user} sets Featured {text} for {text} with title {text} with API', async function (user, isFeatured, resource, resourceTitle) {
  const response = await api_requests.setIsFeaturedByTitle(user, resource, resourceTitle, isFeatured);
  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(200);
});

/** 
 * Sends request on behalf of specified User to set "is_company_featured" flag to the Resource within specified Title
 * 
 * @example
 * User "COMPANY_ADMIN" sets Company Featured "true" for "Research" with title "$researchTitle" with API
 * 
 * @param user user role from user-data.js
 * @param isCompanyFeatured boolean flag
 * @param resource resource to be created
 * @param resourceTitle title of the resource to be created
 * 
 */
When('User {user} sets Company Featured {text} for {text} with title {text} with API', async function (user, isCompanyFeatured, resource, resourceTitle) {
  const response = await api_requests.setIsCompanyFeaturedByTitle(user, resource, resourceTitle, isCompanyFeatured);
  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(200);
});

// /** 
//  * Sends request to create specified resource within specified Title and "is_featured" flag
//  * 
//  * @example
//  * User creates "Research" in "Pending" status with flag isFeatured = "true" and remembers Title as "pendingResearch" with API
//  * 
//  * @param resource resource to be created
//  * @param isFeatured boolean flag
//  * @param status resource status
//  * @param key memory key that stores resource Title
//  * 
//  */
// When('User creates {text} in {text} status with flag isFeatured = {text} and remembers Title as {text} with API', async function (resource, status, isFeatured, key) {
//   // generate and remember resource Title
//   const resourceTitle = stringUtils.getTextWithUniqueGuid('Test_Auto');
//   await Memory.setValue(key, resourceTitle);
//   // create resource and set specified status
//   const resourceData = { 'title': resourceTitle };
//   await api_requests.setAuthorizationHeader(GLOBAL_ADMIN_USER);
//   const resourceId = await api_requests.createResourceAndSetStatus(GLOBAL_ADMIN_USER, GLOBAL_ADMIN_USER, resource, resourceData, status);
//   const response = await api_requests.setIsFeaturedById(GLOBAL_ADMIN_USER, resource, resourceId, isFeatured);

//   return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(200);
// });

// /** 
//  * Sends request to create Research within specified Title and "is_company_featured" flag
//  * 
//  * @example
//  * User creates "Research" in "Pending" status with flag isCompanyFeatured = "true" and remembers Title as "pendingResearch" with API
//  * 
//  * @param resource resource to be created
//  * @param status resource status
//  * @param isCompanyFeatured boolean flag
//  * @param key memory key that stores resource Title
//  * 
//  */
// When('User creates {text} in {text} status with flag isCompanyFeatured = {text} and remembers Title as {text} with API', async function (resource, status, isCompanyFeatured, key) {
//   // generate and remember resource Title
//   const resourceTitle = stringUtils.getTextWithUniqueGuid('Test_Auto');
//   await Memory.setValue(key, resourceTitle);
//   // create resource and set specified status
//   const resourceData = { 'title': resourceTitle };
//   await api_requests.setAuthorizationHeader(GLOBAL_ADMIN_USER);
//   await api_requests.setAuthorizationHeader(COMPANY_ADMIN_USER);
//   const resourceId = await api_requests.createResourceAndSetStatus(COMPANY_ADMIN_USER, GLOBAL_ADMIN_USER, resource, resourceData, status);
//   const response = await api_requests.setIsCompanyFeaturedById(COMPANY_ADMIN_USER, resource, resourceId, isCompanyFeatured);

//   return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(200);
// });


// /** 
//  * Sends request to create specified resource within specified "is_featured" and "is_company_featured" flags and remember its Title
//  * 
//  * @example
//  * User creates "Research" with flags isFeatured "true" and isCompanyFeatured "false" and remembers its Title as "resourceTitle" with API
//  * 
//  * @param resource resource to be created
//  * @param isFeatured boolean flag
//  * @param isCompanyFeatured boolean flag
//  * @param key memory key that stores resource Title
//  * 
//  */
// When('User creates {text} in {text} status with flags isFeatured = {text} and isCompanyFeatured = {text} and remembers Title as {text} with API', async function (resource, status, isFeatured, isCompanyFeatured, key) {
//   // generate and remember resource Title
//   const resourceTitle = stringUtils.getTextWithUniqueGuid('Test_Auto');
//   await Memory.setValue(key, resourceTitle);
//   // create resource and set specified status
//   const resourceData = { 'title': resourceTitle };
//   await api_requests.setAuthorizationHeader(GLOBAL_ADMIN_USER);
//   await api_requests.setAuthorizationHeader(COMPANY_ADMIN_USER);
//   const resourceId = await api_requests.createResourceAndSetStatus(COMPANY_ADMIN_USER, GLOBAL_ADMIN_USER, resource, resourceData, status);
//   const setFeaturedRequest = await api_requests.setIsFeaturedById(GLOBAL_ADMIN_USER, resource, resourceId, isFeatured);
//   const setCompanyFeaturedRequest = await api_requests.setIsCompanyFeaturedById(COMPANY_ADMIN_USER, resource, resourceId, isCompanyFeatured);
//   const success = ((setFeaturedRequest.statusCode === 200) && (setCompanyFeaturedRequest.statusCode === 200)) ? true : false;

//   return expect(success, `SetFeaturedRequest Status Code: ${setFeaturedRequest.statusCode}, SetCompanyFeaturedRequest Status Code: ${setCompanyFeaturedRequest.statusCode}`).to.be.true;
// });

/** 
 * Sends request to create Research within specified Company, "is_featured" and "is_company_featured" flags and remembers its Title
 * 
 * @example
 * Company Admin creates Research with Company "Mercer", isFeatured = "false", isCompanyFeatured = "false" and remembers Title as "researchTitle" with API
 * 
 * @param companyName company name
 * @param isFeatured boolean flag
 * @param isCompanyFeatured boolean flag
 * @param key memory key that stores resource Title
 * 
 */
When('Company Admin creates Research with Company {text}, isFeatured = {text}, isCompanyFeatured = {text} and remembers Title as {text} with API', async function (companyName, isFeatured, isCompanyFeatured, key) {
  await api_requests.setAuthorizationHeader(GLOBAL_ADMIN_USER);
  await api_requests.setAuthorizationHeader(COMPANY_ADMIN_USER);
  const oldCompanyName = (await api_requests.getCompanyOfTargetUser(GLOBAL_ADMIN_USER, COMPANY_ADMIN_USER)).company_name;
  // set new specified User Company
  await api_requests.updateUserCompany(GLOBAL_ADMIN_USER, COMPANY_ADMIN_USER, companyName);

  let setFeaturedRequest;
  let setCompanyFeaturedRequest;
  try {
    // generate and remember resource Title
    const resourceTitle = stringUtils.getTextWithUniqueGuid('Test_Auto');
    await Memory.setValue(key, resourceTitle);
    // create resource and set specified status
    const resourceData = { 'title': resourceTitle };
    const resourceId = await api_requests.createResourceAndSetStatus(COMPANY_ADMIN_USER, GLOBAL_ADMIN_USER, 'research', resourceData, 'approved');
    setFeaturedRequest = await api_requests.setIsFeaturedById(GLOBAL_ADMIN_USER, 'research', resourceId, isFeatured);
    setCompanyFeaturedRequest = await api_requests.setIsCompanyFeaturedById(COMPANY_ADMIN_USER, 'research', resourceId, isCompanyFeatured);
  } catch (e) {
    // set old user company in case of any exceptions / failed requests by some reasons
    await api_requests.updateUserCompany(GLOBAL_ADMIN_USER, COMPANY_ADMIN_USER, oldCompanyName);
    throw new Error(e);
  };
  // set old User Company;
  await api_requests.updateUserCompany(GLOBAL_ADMIN_USER, COMPANY_ADMIN_USER, oldCompanyName);
  const success = ((setFeaturedRequest.statusCode === 200) && (setCompanyFeaturedRequest.statusCode === 200)) ? true : false;

  return expect(success, `SetFeaturedRequest Status Code: ${setFeaturedRequest.statusCode}, SetCompanyFeaturedRequest Status Code: ${setCompanyFeaturedRequest.statusCode}`).to.be.true;
});

/** 
 * Sends request on behalf of specified User to set "private" flag for another User
 * 
 * @example
 * User "GLOBAL_ADMIN" makes "COMPANY_ADMIN" Account "Private" with API
 * 
 * @param userRequestSender user role from user-data.js - request sender
 * @param isPrivateModeOn boolean flag
 * @param targetUser user role from user-data.js - request will update "private" property for this user
 * 
 */
When('User {user} makes {user} Account Private = {text} with API', async function (userRequestSender, targetUser, isPrivateModeOn) {
  const response = await api_requests.setPrivateModeForTargetUser(userRequestSender, targetUser, isPrivateModeOn);
  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(200);
});

/** 
 * Sends request to set "private" flag for current user
 * 
 * @example
 * User "GLOBAL_ADMIN" makes his Account "Private" with API
 * 
 * @param user user role from user-data.js
 * @param isPrivateModeOn boolean flag
 * 
 */
When('User {user} makes Account Private = {text} with API', async function (user, isPrivateModeOn) {
  const response = await api_requests.setPrivateModeForCurrentUser(user, isPrivateModeOn);
  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(200);
});

/** 
 * Sends request on behalf of specified User to change company for another User
 * 
 * @example
 * User "GLOBAL_ADMIN" changes Company to "Mercer" with API
 * 
 * @param user user role from user-data.js
 * @param companyName company name
 * 
 */
When('User {user} changes Company to {text} with API', async function (user, companyName) {
  const response = await api_requests.updateCurrentUserCompany(user, companyName);
  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(200);
});

/** 
 * Sends request on behalf of specified User to change company for another User
 * 
 * @example
 * User "GLOBAL_ADMIN" changes Company to "Mercer" for User "COMPANY_ADMIN" with API
 * 
 * @param userRequestSender user role from user-data.js - request sender
 * @param companyName company name
 * @param targetUser user role from user-data.js - request will update "private" property for this user
 * 
 */
When('User {user} changes Company to {text} for User {user} with API', async function (userRequestSender, companyName, targetUser) {
  const response = await api_requests.updateUserCompany(userRequestSender, targetUser, companyName);
  return expect(response.statusCode, `\nIssue while '${response.requestFunction}' request\nService URI: ${response.serviceUri}\nWith body: ${JSON.stringify(response.requestBody)}\nResponse Status Code: ${response.statusCode}\n`).to.equal(200);
});

/** 
 * Sends request on behalf of specified User to unmark specified number of marked as company featured researches
 * 
 * @example
 * User "COMPANY_ADMIN" removes "All" Company Featured Tokens from Company Researches with API
 * 
 * @param user user role from user-data.js
 * @param numberOfTokens number of tokens to be removed from researches
 * 
 */
When('User {user} removes {text} Company Featured Tokens from Company Researches with API', async function (user, numberOfTokens) {
  numberOfTokens = (numberOfTokens.toLowerCase() === 'all') ? null : numberOfTokens;
  return api_requests.removeCompanyFeaturedTokensFromResearches(user, numberOfTokens);
});

/** 
 * Send request to get lead stories and verify that the research within specified title is included in the result list (list of featured researches on Home page)
 * 
 * @example
 * Research with title {text} is included in the Lead Stories list
 * 
 * @param researchTitle research title
 * 
 */
Then('Research with title {text} is included in the Lead Stories list', async function (researchTitle) {
  await api_requests.setAuthorizationHeader(GLOBAL_ADMIN_USER);
  const leadStories = await api_requests.getLeadStoriesTitles(GLOBAL_ADMIN_USER);
  const isIncluded = leadStories.includes(researchTitle);
  return expect(isIncluded, `Research with Title "${researchTitle}" is not included in the lead stories list. Lead Stories list: ${leadStories}`).to.be.true;
});


/** 
 * Sends request to set Role to User
 * 
 * @example
 * Global Admin sets role "GLOBAL_ADMIN" to User "COMPANY_ADMIN"
 * 
 * @param role - role name, GLOBAL_ADMIN, COMPANY_ADMIN, COMPANY_AUTHOR, COMPANY_USER
 * @param targetUser user from user-data.js
 *
 */
When('Global Admin sets role {text} to User {user}', async function (role, targetUser) {
  await api_requests.setAuthorizationHeader(GLOBAL_ADMIN_USER);
  return api_requests.updateUserRoles(GLOBAL_ADMIN_USER, targetUser, role);
});


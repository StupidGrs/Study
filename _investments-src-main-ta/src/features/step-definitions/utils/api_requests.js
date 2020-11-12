const Memory = require('../memory/Memory');
const utils = require('../../../features/step-definitions/utils/utils');
const { endpointHelper } = require('ngpd-merceros-testautomation-ta');
const services = require('../../../data/api/api-data-services').services;
const userData = require('../../../data/user-data');
const dateUtils = require('../../../utils/date-util');
const environment = browser.params.env;
const httpsProxyAgent = require('https-proxy-agent');
const proxy = process.env.http_proxy || 'http://10.2.30.39:8080';
const agent = (environment.includes('AWS')) ? new httpsProxyAgent(proxy) : undefined;


const _mapResourceNames = (resource) => {
    if (resource.toLowerCase().includes('research')) {
        resource = 'Research'
    };
    if (resource.toLowerCase().includes('news')) {
        resource = 'News'
    };
    if (resource.toLowerCase().includes('event')) {
        resource = 'Events'
    };

    return resource;
};


const setAuthorizationHeader = async (user) => {
  // get service info used for authentication
  const service = services.login;
  const serviceUri = `${service.baseUrl}${service.path}${user.email}`;

  let Authorization_Header;
  // try to execute request
  try {
    // const session = await browser.getSession();
    let response = await endpointHelper.sendRequest(service.method, serviceUri, null, null, {'followRedirect': false, agent: agent });
    if (response.statusCode === 500 || response.statusCode === 502 || response.code === 'ETIMEDOUT') {
      const dateTime = (new Date).toISOString();
      console.log(`${dateTime}: [Auth Request Failed]\nMethod '${service.method}'\nService URI: ${serviceUri}\nTrying to send request one more time`);
      response = await endpointHelper.sendRequest(service.method, serviceUri, null, null, {'followRedirect': false, agent: agent });
    }

    response.requestFunction = service.method;
    response.serviceUri = serviceUri;
    Authorization_Header = response.headers['authentication'];
    // save recieved authorization header in Memory
    const memoryKey = user.login + '_Authorization_Header';
    await Memory.setValue(memoryKey, Authorization_Header);
    // store response to global.uniqueMap to be able to use it in next steps
    // global.uniqueMap[`${session['id_']}response`] = response;
    return response;
  }
  catch (error) {
    console.log('Error: ', error);
    console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\nWith body: ${JSON.stringify(body)}\n`);
    error.requestFunction = service.method;
    error.serviceUri = serviceUri;
    return error;
  };
};

const _getAuthorizationHeaderMap = async (user) => {
    // TODO: talk to devs to increase token lifetime and then remove workaround
    // setAuthorizationHeader method added as a workaround, because token expires too fast
    const authResponse = await setAuthorizationHeader(user);
    const authorizationHeader = authResponse.headers['authentication'];
    // end of workaround
    // const AuthorizationHeaderKey = '$' + user.login + '_Authorization_Header';
    // const authorizationHeader = await Memory.parseValue(AuthorizationHeaderKey);
    const headersMap = new Map();
    headersMap.set("Authorization", authorizationHeader);

    return headersMap;
};

const getArticleDataForPublish = async (user, articleType, inputData, action, setAllFields) => {
    let service;
    switch (articleType) {
        case 'News':
            service = services.createNews;
            break;
        case 'Research':
            service = services.createResearch;
            break;
    };
    //prepare news article test data
    const articleData = JSON.parse(JSON.stringify(service.articleData));
    //set title (required)
    articleData.title = inputData.title || 'Text_Auto_Default_Title';
    //set article_type (required)
    articleData.article_type = inputData.article_type || 'Speech';
    //set content_url (required)
    articleData.content_url = inputData.content_url || 'https://www.wikipedia.org/';
    //set content (required)
    articleData.content = inputData.content || '<p>Test_Auto Content</p>';
    //set Executive Summary (required)
    articleData.excerpt = inputData.excerpt || 'Test_Auto Executive Summary';
    //set date (required)
    articleData.date = inputData.date || new Date().toISOString();
    //set company (required)
    if (inputData.company) {
        articleData.company = inputData.company;
    } else {
        articleData.company = await getCompanyOfCurrentUser(user);
    };
    //set taxonimies Id (required)
    if (inputData.taxonomies) {
        articleData.taxonomies = [];
        const namesArr = inputData.taxonomies;
        for (const name of namesArr) {
            //try to execute request
            const id = await getTaxonomyIdByName(user, name);
            articleData.taxonomies.push(id);
        };
    } else {
        articleData.taxonomies[0] = await getTaxonomyIdByName(user, 'Hot Topics');
    };

    //set Author
    if (inputData.authorTxt || setAllFields) {
        articleData.authorTxt = inputData.authorTxt || 'Test_Auto Author'
    };
    //set video_link
    if (inputData.video_link || setAllFields) {
        articleData.video_link = inputData.video_link || 'https://www.youtube.com/watch?v=W6NZfCO5SIk';
    };
    //set tags
    if (inputData.video_link || setAllFields) {
        articleData.tags = inputData.tags || 'Investing';
    };
    //set read_time
    if (inputData.read_time || setAllFields) {
        articleData.read_time = inputData.read_time || 2;
    };
    //set regions
    if (inputData.regions) {
        articleData.regions = [];
        const regionsNamesArr = inputData.regions;
        for (const regionName of regionsNamesArr) {
            //try to execute request
            const regionId = await getRegionIdByName(user, regionName);
            articleData.regions.push(regionId);
        };
    } else {
        if (setAllFields) {
            articleData.regions[0] = await getRegionIdByName(user, 'UK');
        };
    };

    //set business_roles (for research only)
    if ((articleType === 'Research') && (inputData.business_roles || setAllFields)) {
        articleData.business_roles = inputData.business_roles || ['Asset Manager'];
    };
    //prepare formData
    const formData = {
        'content': JSON.stringify(articleData),
        'action': action
    };

    //add featured_image: testContentForUpload.png
    if (inputData.featured_image || setAllFields) {
        const fileName = inputData.featured_image || 'testContentForUpload.png';
        formData.featured_image = utils.getFileDetailsForUpload(fileName);
    };
    //add PDF attach: testContentForUpload.pdf
    if (inputData.attachments || setAllFields) {
        const fileName = inputData.attachments || 'testContentForUpload.pdf';
        formData.attachments = utils.getFileDetailsForUpload(fileName);
    };

    return formData;
};

const getEventDataForPublish = async (user, inputData, action, setAllFields) => {
    const service = services.createEvents;

    //prepare Event test data
    const eventData = JSON.parse(JSON.stringify(service.eventData));
    //set title (required)
    eventData.title = inputData.title || 'Text_Auto_Default_Event_Title';
    //set excerpt (required)
    eventData.excerpt = inputData.excerpt || 'Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla.';
    //set content (required)
    eventData.content = inputData.content || '<p>Donec quis orci eget orci vehicula condimentum. Curabitur in libero ut massa volutpat convallis.</p>';
    //set event type (required)
    eventData.type = inputData.type || 'Webinar';
    //set taxonomies (required)
    if (inputData.taxonomies) {
        eventData.taxonomies = [];
        const namesArr = inputData.taxonomies;
        for (const name of namesArr) {
            //try to execute request
            const id = await getTaxonomyIdByName(user, name);
            eventData.taxonomies.push(id);
        };
    } else {
        eventData.taxonomies[0] = await getTaxonomyIdByName(user, 'Hot Topics');
    };
    //set dates (required)
    //set start date
    const currentDate = new Date();
    if (inputData.start_date) {
        eventData.start_date = dateUtils.getDateInZuluFormat(inputData.start_date);
    } else {
        eventData.start_date = currentDate.toISOString();
    };
    //set end date
    if (inputData.end_date) {
        eventData.end_date = dateUtils.getDateInZuluFormat(inputData.end_date);
    } else {
        eventData.end_date = new Date(currentDate.setDate(currentDate.getDate() + 30));
    };
    //set location (required)
    eventData.location = inputData.location || 'San Francisco, United States';
    //set company (required)
    if (inputData.company) {
        eventData.company = inputData.company;
    } else {
        eventData.company = await getCompanyOfCurrentUser(user);
    };
    //set tags
    if (inputData.tags || setAllFields) {
        eventData.tags = inputData.tags || 'Markets & Economy';
    };
    //set content url
    if (inputData.content_url || setAllFields) {
        eventData.content_url = inputData.content_url || 'https://events.climateaction.org/sustainable-investment-forum-europe/';
    };
    //set regions
    if (inputData.regions) {
        eventData.regions = [];
        const regionsNamesArr = inputData.regions;
        for (const regionName of regionsNamesArr) {
            //try to execute request
            const regionId = await getRegionIdByName(user, regionName);
            eventData.regions.push(regionId);
        };
    } else {
        if (setAllFields) {
            eventData.regions[0] = await getRegionIdByName(user, 'US');
        };
    };

    //prepare formData
    const formData = {
        'content': JSON.stringify(eventData),
        'action': action
    };

    //add image
    if (inputData.featured_image || setAllFields) {
        const fileName = inputData.featured_image || 'featuredForEvent.png';
        formData.featured_image = utils.getFileDetailsForUpload(fileName);
    };

    return formData;
};


const getResearchDataForPublish = async (user, inputData, action, setAllFields) => {
    const articleType = 'Research';
    return getArticleDataForPublish(user, articleType, inputData, action, setAllFields);
};

const createResearch = async (user, researchData, action = 'submit', setAllFields = false) => {
  // get service to send request to create research
  const service = services.createResearch;
  const serviceUri = `${service.baseUrl}${service.path}`;

  // get authorization header
  const headersMap = await _getAuthorizationHeaderMap(user);



  // prepare research article test data
  const formData = await getResearchDataForPublish(user, researchData, action, setAllFields);

  // try to execute request
  try {
    // const session = await browser.getSession();
    const response = await endpointHelper.sendRequest(service.method, serviceUri, null, headersMap, { 'formData': formData, agent: agent });
    response.requestFunction = service.method;
    response.serviceUri = serviceUri;
    response.requestBody = formData;

    // store response to global.uniqueMap to be able to use it in next steps
    // global.uniqueMap[`${session['id_']}response`] = response;

    return response;
  }
  catch (error) {
    console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\nWith formData: ${JSON.stringify(formData)}\n`);
    console.log('Error: ', error);
    error.requestFunction = service.method;
    error.serviceUri = serviceUri;
    error.requestBody = formData;
    return error;
  };

};

const createEvent = async (user, eventData, action = 'submit', setAllFields = false) => {
  // get service to send request to create event
  const service = services.createEvents;
  const serviceUri = `${service.baseUrl}${service.path}`;

  // get authorization header
  const headersMap = await _getAuthorizationHeaderMap(user);

  // prepare Event test data
  const formData = await getEventDataForPublish(user, eventData, action, setAllFields);

  // try to execute request
  try {
    // const session = await browser.getSession();
    const response = await endpointHelper.sendRequest(service.method, serviceUri, null, headersMap, { 'formData': formData, agent: agent });
    response.requestFunction = service.method;
    response.serviceUri = serviceUri;
    response.requestBody = formData;

    // store response to global.uniqueMap to be able to use it in next steps
    // global.uniqueMap[`${session['id_']}response`] = response;

    return response;
  }
  catch (error) {
    console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\nWith formData: ${JSON.stringify(formData)}\n`);
    console.log('Error: ', error);
    error.requestFunction = service.method;
    error.serviceUri = serviceUri;
    error.requestBody = formData;
    return error;
  };

};

const createResource = async (user, resource, inputData, action, setAllFields = false) => {
  // get resource name
  resource = _mapResourceNames(resource);
  // get service to send request to create resource
  let service;
  let formData;
  switch (resource) {
    case 'Research':
      service = services.createResearch;
      formData = await getResearchDataForPublish(user, inputData, action, setAllFields);
      break;
    case 'News':
      service = services.createNews;
      formData = await getNewsDataForPublish(user, inputData, action, setAllFields);
      break;
    case 'Events':
      service = services.createEvents;
      formData = await getEventDataForPublish(user, inputData, action, setAllFields);
      break;

    default:
      throw Error(`${resource} is not supported. Supported options: Research, News, Events`);
  };

  const serviceUri = `${service.baseUrl}${service.path}`;

  // get authorization header
  const headersMap = await _getAuthorizationHeaderMap(user);

  // try to execute request
  try {
    // const session = await browser.getSession();
    let response = await endpointHelper.sendRequest(service.method, serviceUri, null, headersMap, { 'formData': formData, agent: agent });
    if (response.statusCode === 500 || response.statusCode === 502 || response.code === 'ETIMEDOUT') {
      const dateTime = (new Date).toISOString();
      console.log(`${dateTime}: [Request Failed.\nMethod '${service.method}'\nService URI: ${serviceUri}\nTrying to send request one more time`);
      response = await endpointHelper.sendRequest(service.method, serviceUri, null, headersMap, { 'formData': formData, agent: agent });
    };
    response.requestFunction = service.method;
    response.serviceUri = serviceUri;
    response.requestBody = formData;

    // store response to global.uniqueMap to be able to use it in next steps
    // global.uniqueMap[`${session['id_']}response`] = response;

    return response;
  }
  catch (error) {
    console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\nWith formData: ${JSON.stringify(formData)}\n`);
    console.log('Error: ', error);
    error.requestFunction = service.method;
    error.serviceUri = serviceUri;
    error.requestBody = formData;
    return error;
  };

};

const getResourceByAttr = async (user, resource, searchValue, attr = 'title', method) => {
    resource = _mapResourceNames(resource);
    //get service to send request to get Resource by Attr
    let service;
    switch (resource) {
        case 'Articles': service = services.getArticles;
            break;
        case 'Research': service = services.getArticles;
            break;
        case 'News': service = services.getArticles;
            break;
        case 'Events': service = services.getEvents;
            break;
        case 'Taxonomies': service = services.getTaxonomies;
            break;
        case 'Regions': service = services.getRegions;
            break;
        default:
            throw Error(`Get ${resource} is not supported. Supported options: Research, News, Events, Taxonomies, Regions`);
    };
    // prepare serviceUri for request
    attr = attr.toLowerCase();
    let serviceUri;
    if (method) {
        method = method.toLowerCase();
        serviceUri = `${service.baseUrl}${service.path}?${attr}${method}=${searchValue}`;
    } else {
        serviceUri = `${service.baseUrl}${service.path}?${attr}=${searchValue}`;
    };

    // get authorization header - required for requests to BE, but should be null for requests to STRAPI
    let headersMap = null;
    if ((resource === 'Taxonomies') || resource === 'Regions') {
        headersMap = await _getAuthorizationHeaderMap(user);
    };

    // try to execute request
    let resourceArr;
    try {
        // const session = await browser.getSession();
        const response = await endpointHelper.sendRequest(service.method, serviceUri, null, headersMap, { agent: agent });
        // if (response.body.length < 1) {
        //   console.log(`${resource}: getResourceByAttr response`, response);
        // };
        response.requestFunction = service.method;
        response.serviceUri = serviceUri;
        resourceArr = response.body;

        // store response to global.uniqueMap to be able to use it in next steps
        // global.uniqueMap[`${session['id_']}response`] = response;

        return resourceArr;
    }
    catch (error) {
        console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\n`);
        console.log('Error: ', error);
        error.requestFunction = service.method;
        error.serviceUri = serviceUri;
        return error;
    };
};

const getResourceIdByAttr = async (user, resource, searchValue, attr, method) => {
    resource = _mapResourceNames(resource);
    let resourceIdsArr;

    console.log("------ getResourceIdByAttr ----------");
    console.log("user: " + user);
    console.log("resource: " + resource);
    console.log("searchValue: " + searchValue);
    console.log("attr: " + attr);
    console.log("method: " + method);

    const foundResourcesArr = await getResourceByAttr(user, resource, searchValue, attr, method);
    console.log("foundResourcesArr: " + foundResourcesArr);
    if (foundResourcesArr.length > 0) {
        resourceIdsArr = foundResourcesArr.map(a => {
            switch (resource) {
                case 'Events':
                    return a._id;
                default:
                    return a.id;
            }
        });

        return resourceIdsArr;
    } else {
        throw Error(`No ${resource} found. searchValue: ${searchValue}, searchAttr: ${attr}, method: ${method}.`);
    };

};

const deleteResourceById = async (resource, resourceId) => {
  resource = _mapResourceNames(resource);
  // get service to send request to delete Article
  let service;
  switch (resource) {
    case 'Research': service = services.deleteResearch;
      break;
    case 'News': service = services.deleteNews;
      break;
    case 'Events': service = services.deleteEvents;
      break;

    default:
      throw Error(`Delete ${resource} is not supported. Supported options: Research, News, Events`);
  };

  const serviceUri = `${service.baseUrl}${service.path}${resourceId}`;

  // try to execute request
  try {
    // const session = await browser.getSession();
    const response = await endpointHelper.sendRequest(service.method, serviceUri, null, null, { agent: agent });
    response.requestFunction = service.method;
    response.serviceUri = serviceUri;

    // store response to global.uniqueMap to be able to use it in next steps
    // global.uniqueMap[`${session['id_']}response`] = response;

    return response;
  }
  catch (error) {
    console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\n`);
    console.log('Error: ', error);
    error.requestFunction = service.method;
    error.serviceUri = serviceUri;
    return error;
  };

};

const deleteResourceByAttr = async (resource, value, attr = 'title', searchMethod) => {
  resource = _mapResourceNames(resource);
  // get resource Ids to delete
  const resourceIdsToDelete = await getResourceIdByAttr(null, resource, value, attr, searchMethod);
  // get service to send request to delete resource
  let service;
  switch (resource) {
    case 'Research': service = services.deleteResearch;
      break;
    case 'News': service = services.deleteNews;
      break;
    case 'Events': service = services.deleteEvents;
      break;

    default:
      throw Error(`Delete ${resource} is not supported. Supported options: Research, News, Event`);
  };

  for (const resourceId of resourceIdsToDelete) {
    // try to execute request
    try {
      await deleteResourceById(resource, resourceId);
    }
    catch (error) {
      console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\n`);
      console.log('Error: ', error);
      error.requestFunction = service.method;
      error.serviceUri = serviceUri;
      return error;
    };
  };
};


const _mapResourceContentType = (resource) => {
    let contentType;
    if (resource.toLowerCase().includes('research')) {
        contentType = 'research post'
    };
    if (resource.toLowerCase().includes('event')) {
        contentType = 'event'
    };
    if (resource.toLowerCase().includes('news')) {
        contentType = 'blog/news post'
    };
    return contentType;
};


const getCurrentUserProfile = async (user) => {
  // get service to send request to get user profile of currently logged in user
  const service = services.getCurrentUserProfile;
  const serviceUri = `${service.baseUrl}${service.path}`;
  const headersMap = await _getAuthorizationHeaderMap(user);
  let userProfile;

  //try to execute request
  try {
    //const session = await browser.getSession();
    const response = await endpointHelper.sendRequest(service.method, serviceUri, null, headersMap, { agent: agent });
    response.requestFunction = service.method;
    response.serviceUri = serviceUri;
    userProfile = response.body;
    // store response to global.uniqueMap to be able to use it in next steps
    //global.uniqueMap[`${session['id_']}response`] = response;
    return userProfile;
  }
  catch (error) {
    console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\n`);
    console.log('Error: ', error);
    error.requestFunction = service.method;
    error.serviceUri = serviceUri;
    return error;
  };

};

const setApprovalStatusById = async (user, resource, resourceId, status, rejectReason = "") => {
  const resourceContentType = _mapResourceContentType(resource);
  //get service to send request to delete Article
  const service = services.setContentStatus;
  const serviceUri = `${service.baseUrl}${service.path}${resourceId}`;

  const requestBody = JSON.parse(JSON.stringify(service.body));
  requestBody.id = resourceId;
  requestBody.approval_status = status;
  //add reject reason if any
  if (status === 'rejected') {
    requestBody.reason = rejectReason;
  };
  requestBody.type = resourceContentType;
  requestBody.approved_date = new Date().toISOString();

  const headersMap = await _getAuthorizationHeaderMap(user);
  headersMap.set("Content-Type", service.contentType);

  //try to execute request
  try {
    //const session = await browser.getSession();
    const response = await endpointHelper.sendRequest(service.method, serviceUri, JSON.stringify(requestBody), headersMap, { agent: agent });
    response.requestFunction = service.method;
    response.serviceUri = serviceUri;
    response.requestBody = requestBody;
    // store response to global.uniqueMap to be able to use it in next steps
    //global.uniqueMap[`${session['id_']}response`] = response;

    return response;
  }
  catch (error) {
    console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\nWith body: ${JSON.stringify(requestBody)}\n`);
    console.log('Error: ', error);
    error.requestFunction = service.method;
    error.serviceUri = serviceUri;
    error.requestBody = requestBody;
    return error;
  };

};

const setApprovalStatusByTitle = async (user, resource, resourceTitle, status, rejectReason) => {

    console.log("----- setApprovalStatusByTitle  -------");
    console.log("user: " + user);
    console.log("resource: " + resource);
    console.log("resourceTitle: " + resourceTitle);
    console.log("status: " + status);
    console.log("rejectReason: " + rejectReason);

  const resourceId = (await getResourceIdByAttr(user, resource, resourceTitle))[0];
    console.log("resourceId: " + resourceId);
  return setApprovalStatusById(user, resource, resourceId, status, rejectReason);
};

const getRegionIdByName = async (user, regionName) => {
  return (await getResourceIdByAttr(user, 'Regions', regionName, 'region_name'))[0];
};

const getTaxonomyIdByName = async (user, taxonomieGroupName) => {
  let taxonomyId;
  //try to find taxanomy by group name
  let foundTaxonomiesArr = await getResourceByAttr(user, 'Taxonomies', taxonomieGroupName, 'group');
  //if taxonomy not found by group name, then try to find by sub_group name
  if (!foundTaxonomiesArr.length) {
    foundTaxonomiesArr = await getResourceByAttr(user, 'Taxonomies', taxonomieGroupName, 'sub_group');
  };

  if (foundTaxonomiesArr.length) {
    taxonomyId = foundTaxonomiesArr[0].id;
  } else {
    //if taxonomy not found by sub_group name, then throw error
    throw Error(`No Taxonomies found by name: ${taxonomieGroupName}`);
  };

  return taxonomyId;
};

const getCompanyOfCurrentUser = async (user) => {
  const userProfile = await getCurrentUserProfile(user);
  return userProfile.company;
};



const getResourceUrlByTitle = async (resource, resourceTitle) => {
  const resourceData = (await getResourceByAttr(null, resource, resourceTitle))[0];
  const partialUrl = `${userData.urls.ENV[environment]}/${resource.toLowerCase()}`;
  const resourceUrl = `${partialUrl}/${resourceData.id}/${resourceData.url}`;

  return resourceUrl;
};

const getEventStartDateByTitle = async (eventTitle) => {
  const eventData = (await getResourceByAttr(null, 'Events', eventTitle))[0];

  return eventData.start_date;
};

const getEventEndDateByTitle = async (eventTitle) => {
  const eventData = (await getResourceByAttr(null, 'Events', eventTitle))[0];

  return eventData.end_date;
};



const getNewsDataForPublish = async (user, inputData, action, setAllFields) => {
  const articleType = 'News';
  return getArticleDataForPublish(user, articleType, inputData, action, setAllFields);
};

const submitResource = async (user, resource, inputData) => {
  return createResource(user, resource, inputData, 'submit', false);
};

const submitResourceWithAllFields = async (user, resource, inputData) => {
  return createResource(user, resource, inputData, 'submit', true);
};

const saveDraftResource = async (user, resource, inputData) => {
  return createResource(user, resource, inputData, 'saveDraft', false);
};

const saveDraftResourceWithAllFields = async (user, resource, inputData) => {
  return createResource(user, resource, inputData, 'saveDraft', true);
};





// const getCompaniesByName = async (user, companyName) => {
//   //get service to send request to find company by company name
//   const service = services.getCompanies;
//   const encodedCompanyName = encodeURIComponent(companyName);
//   const serviceUri = `${service.baseUrl}${service.path}/search?q=${encodedCompanyName}`;
//   const headersMap = await _getAuthorizationHeaderMap(user);
//   let companies;

//   //try to execute request
//   try {
//     //const session = await browser.getSession();
//     const response = await endpointHelper.sendRequest(service.method, serviceUri, null, headersMap, { agent: agent });
//     response.requestFunction = service.method;
//     response.serviceUri = serviceUri;
//     companies = response.body.items;
//     // store response to global.uniqueMap to be able to use it in next steps
//     //global.uniqueMap[`${session['id_']}response`] = response;
//     return companies;
//   }
//   catch (error) {
//     console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\n`);
//     console.log('Error: ', error);
//     error.requestFunction = service.method;
//     error.serviceUri = serviceUri;
//     return error;
//   };
// };

const getCompanies = async (user, query) => {
  //get service to send request to find company by company name
  const service = services.getCompanies;
  const serviceUri = query ? `${service.baseUrl}${service.path}/search?q=${encodeURIComponent(query)}` : `${service.baseUrl}${service.path}`;
  const headersMap = await _getAuthorizationHeaderMap(user);
  //try to execute request
  try {
    const response = await endpointHelper.sendRequest(service.method, serviceUri, null, headersMap, { agent: agent });
    const foundCompanies = query ? response.body.items : response.body;
    return foundCompanies;
  }
  catch (error) {
    console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\n`);
    console.log('Error: ', error);
    error.requestFunction = service.method;
    error.serviceUri = serviceUri;
    return error;
  };
};

const getCompanyIdByName = async (user, companyName) => {
  const foundCompanies = await getCompanies(user, companyName);
  if (foundCompanies.length > 0) {
    const company = foundCompanies[0];
    return company._id;
  } else {
    return false;
  };
};

const getEnabledCompanyNames = async (user) => {
  const foundCompanies = await getCompanies(user);
  const companyNames = foundCompanies.reduce((companyNamesArr, company) => {
    if (company.company_status === 'active') {
      companyNamesArr.push(company.company_name);
    };
    return companyNamesArr;
  }, []);

  return companyNames;
};


const followCompanyById = async (user, companyId, setFollow) => {
  //get service to send request to follow or unfollow company  depending on 'follow' flag
  const service = setFollow ? services.followCompany : services.unfollowCompany;
  const serviceUri = `${service.baseUrl}${service.path}`;
  const requestBody = JSON.parse(JSON.stringify(service.body));
  requestBody.itemId = companyId;
  const headersMap = await _getAuthorizationHeaderMap(user);
  headersMap.set("Content-Type", service.contentType);

  //try to execute request
  try {
    //const session = await browser.getSession();
    const response = await endpointHelper.sendRequest(service.method, serviceUri, JSON.stringify(requestBody), headersMap, { agent: agent });
    response.requestFunction = service.method;
    response.serviceUri = serviceUri;
    response.requestBody = requestBody;
    // store response to global.uniqueMap to be able to use it in next steps
    //`${session['id_']}response`] = response;
    return response;
  }
  catch (error) {
    console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\n`);
    console.log('Error: ', error);
    error.requestFunction = service.method;
    error.serviceUri = serviceUri;
    error.requestBody = requestBody;
    return error;
  };
};

const followCompanyByName = async (user, companyName, setFollow) => {
  const companyId = await getCompanyIdByName(user, companyName);
  let response;
  if (companyId) {
    response = await followCompanyById(user, companyId, setFollow);
  } else {
    throw Error(`Company ${companyName} not found`);
  };

  return response;
};


const rateArticleById = async (user, articleId, rate) => {
  //get service to send request to rate article
  const service = services.rateArticle;
  const serviceUri = `${service.baseUrl}${service.path}`;
  const requestBody = JSON.parse(JSON.stringify(service.body));
  requestBody._id = articleId;
  requestBody.rate = rate;
  const headersMap = await _getAuthorizationHeaderMap(user);
  headersMap.set("Content-Type", service.contentType);

  //try to execute request
  try {
    //const session = await browser.getSession();
    const response = await endpointHelper.sendRequest(service.method, serviceUri, JSON.stringify(requestBody), headersMap, { agent: agent });
    response.requestFunction = service.method;
    response.serviceUri = serviceUri;
    response.requestBody = requestBody;
    // store response to global.uniqueMap to be able to use it in next steps
    //global.uniqueMap[`${session['id_']}response`] = response;
    return response;
  }
  catch (error) {
    console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\n`);
    console.log('Error: ', error);
    error.requestFunction = service.method;
    error.serviceUri = serviceUri;
    error.requestBody = requestBody;
    return error;
  };
};

const rateArticleByTitle = async (user, articleTitle, rate) => {
  const articleId = (await getResourceIdByAttr(user, 'Articles', articleTitle))[0];
  let response;
  if (articleId) {
    response = await rateArticleById(user, articleId, rate);
  } else {
    throw Error(`Article ${articleTitle} not found`);
  };

  return response;
};

const unfollowUserFromAllCompanies = async (user) => {
  const userProfile = await getCurrentUserProfile(user);
  const followedCompanies = userProfile.followed_companies;
  let result = {};
  if (followedCompanies.length > 0) {
    const companiesIdsArr = followedCompanies.map(company => company._id);
    for (const companyId of companiesIdsArr) {
      //try to execute request
      try {
        result = await followCompanyById(user, companyId, false);
      }
      catch (error) {
        return error;
      };
    };
  } else {
    result.statusCode = 200;
  };
  return result;
};

const bookmarkArticleById = async (user, articleId) => {
  //get service to send request to bookmark Article
  const service = services.bookmarkArticle;
  const serviceUri = `${service.baseUrl}${service.path}`;
  const requestBody = JSON.parse(JSON.stringify(service.body));
  requestBody.id = articleId;
  const headersMap = await _getAuthorizationHeaderMap(user);
  headersMap.set("Content-Type", service.contentType);

  //try to execute request
  try {
    //const session = await browser.getSession();
    const response = await endpointHelper.sendRequest(service.method, serviceUri, JSON.stringify(requestBody), headersMap, { agent: agent });
    response.requestFunction = service.method;
    response.serviceUri = serviceUri;
    response.requestBody = requestBody;
    // store response to global.uniqueMap to be able to use it in next steps
    //global.uniqueMap[`${session['id_']}response`] = response;
    return response;
  }
  catch (error) {
    console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\n`);
    console.log('Error: ', error);
    error.requestFunction = service.method;
    error.serviceUri = serviceUri;
    error.requestBody = requestBody;
    return error;
  };
};

const bookmarkArticleByTitle = async (user, articleTitle) => {
  const articleId = (await getResourceIdByAttr(user, 'Articles', articleTitle))[0];
  let response;
  if (articleId) {
    response = await bookmarkArticleById(user, articleId);
  } else {
    throw Error(`Article ${articleTitle} not found`);
  };

  return response;
};

const searchCompanyTest = async (user, numberOfWords, numberOfResults, numberOfTestCompanies) => {
  //report filename
  const fileName = `notFoundCompanies_[${numberOfWords}_words]_[first_${numberOfResults}_results]`;
  //get list of all enabled companies
  let companyNames = await getEnabledCompanyNames(user);
  //exclude companies with name 'CompAuto'
  companyNames = companyNames.filter(name => !(name.includes('CompAuto')));
  console.log('Total Companies:', companyNames.length);
  console.log(`Will test ${numberOfTestCompanies} Companies`);
  if (numberOfTestCompanies !== 'ALL') {
    //shuffle all companies and take specified number of companies for test
    numberOfTestCompanies = parseInt(numberOfTestCompanies);
    companyNames = utils.shuffleArr(companyNames).slice(0, numberOfTestCompanies);
  };

  let notFound = [];
  let failedRequests = [];
  //perform search test for each company name
  for (const companyName of companyNames) {
    //get search value depending on specified numberOfWords param
    let searchValue;
    switch (numberOfWords) {
      case 'fullName':
        searchValue = companyName;
        break;
      default:
        const notAWord = ['the'];
        const companyWords = companyName.split(' ');
        let companyFirstWord = companyWords[0];
        if (numberOfWords === 1 && (companyFirstWord.length === 1 || notAWord.includes(companyFirstWord.toLowerCase()))) {
          numberOfWords = numberOfWords + 1;
        };
        companyFirstWord = companyWords.slice(0, numberOfWords).join(' ');
        searchValue = companyFirstWord.replace(/,\s*$/, "");
        break;
    };
    try {
      //perform search request
      let foundCompanies = await getCompanies(user, searchValue);
      //re-send request on timeout
      if (foundCompanies.code === 'ETIMEDOUT') {
        const dateTime = (new Date).toISOString();
        console.log(`${dateTime} #${i}: [Request Timed Out]. Trying to send request one more time`);
        foundCompanies = await getCompanies(user, searchValue);
      };
      //get list of company names as result
      const foundCompanyNames = foundCompanies.map(company => company.company_name);
      let companyResultPosition = foundCompanyNames.indexOf(companyName) + 1;
      //check if result contains expected company and it is on expected position
      if ((companyResultPosition === 0) || (companyResultPosition > numberOfResults)) {
        foundCompanyNamesStr = foundCompanyNames.join("\n");
        const notFoundObj = {
          "Company Name": companyName,
          "Search Value": searchValue,
          "Result": foundCompanyNamesStr,
          "Position": companyResultPosition || 'Not Found'
        };
        notFound.push(notFoundObj);
      };
    } catch (error) {
      console.log(error);
      const notFoundObj = {
        "Company Name": companyName,
        "Search Value": searchValue,
      };
      failedRequests.push(notFoundObj);
    };
  };

  if (failedRequests.length > 0) {
    console.log('Failed requests:');
    failedRequests.forEach(item => {
      console.log(item["Company Name"]);
    });
    notFound = [...notFound, ...failedRequests];
  };

  if (notFound.length > 0) {
    console.log('Not found companies:', notFound.length);
    notFound.forEach(item => {
      console.log(item["Company Name"]);
    });
    console.log('Details:');
    notFound.forEach(item => {
      console.log(`Company Name: ${item["Company Name"]}`);
      console.log(`Search Value: ${item["Search Value"]}`);
      console.log(item["Result"].split("\n"));
    });
    //write report file
    const expectedPositionText = `Expected Postion <= ${numberOfResults}`;
    const headers = ["Company Name", "Search Value", "Result", "Position", expectedPositionText];
    utils.saveJsonToXlsx(notFound, headers, fileName);
  };

  const notFoundComapyNames = notFound.map(obj => obj["Company Name"]);
  return notFoundComapyNames;
};

const getResourceDataToModerateById = async (user, resource, resourceId) => {
  resource = _mapResourceNames(resource);
  // get service to send request to delete Article
  let service;
  switch (resource) {
    case 'Research': service = services.getResearchModerateFormData;
      break;
    case 'News': service = services.getNewsModerateFormData;
      break;
    case 'Events': service = services.getEventModerateFormData;
      break;

    default:
      throw Error(`Resource ${resource} is not supported. Supported options: Research, News, Events`);
  };

  const serviceUri = `${service.baseUrl}${service.path}${resourceId}`;

  // get authorization header
  const headersMap = await _getAuthorizationHeaderMap(user);

  // try to execute request
  try {
    // const session = await browser.getSession();
    const response = await endpointHelper.sendRequest(service.method, serviceUri, null, headersMap, { agent: agent });
    response.requestFunction = service.method;
    response.serviceUri = serviceUri;
    const resourceData = response.body;
    // store response to global.uniqueMap to be able to use it in next steps
    // global.uniqueMap[`${session['id_']}response`] = response;

    return resourceData;
  }
  catch (error) {
    console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\n`);
    console.log('Error: ', error);
    error.requestFunction = service.method;
    error.serviceUri = serviceUri;
    return error;
  };
};

const moderateResourceById = async (user, resource, resourceId, formData) => {
  resource = _mapResourceNames(resource);
  // get service to send request to delete Article
  let service;
  switch (resource) {
    case 'Research': service = services.moderateResearch;
      break;
    case 'News': service = services.moderateNews;
      break;
    case 'Events': service = services.moderateEvent;
      break;

    default:
      throw Error(`Moderate ${resource} is not supported. Supported options: Research, News, Events`);
  };

  const serviceUri = `${service.baseUrl}${service.path}${resourceId}`;

  // get authorization header
  const headersMap = await _getAuthorizationHeaderMap(user);

  // try to execute request
  try {
    // const session = await browser.getSession();
    const response = await endpointHelper.sendRequest(service.method, serviceUri, null, headersMap, { 'formData': formData, agent: agent });
    response.requestFunction = service.method;
    response.serviceUri = serviceUri;

    // store response to global.uniqueMap to be able to use it in next steps
    // global.uniqueMap[`${session['id_']}response`] = response;

    return response;
  }
  catch (error) {
    console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\n`);
    console.log('Error: ', error);
    error.requestFunction = service.method;
    error.serviceUri = serviceUri;
    return error;
  };
};

const setIsFeaturedById = async (user, resource, resourceId, isFeatured) => {
  //convert isFeatured string to boolean
  isFeatured = (isFeatured === 'true');

  const resourceData = await getResourceDataToModerateById(user, resource, resourceId);
  resourceData.is_featured = isFeatured;
  const formData = {
    'content': JSON.stringify(resourceData)
  };

  const response = await moderateResourceById(user, resource, resourceId, formData);

  return response;
};

const setIsFeaturedByTitle = async (user, resource, resourceTitle, isFeatured) => {
  const resourceId = (await getResourceIdByAttr(user, resource, resourceTitle))[0];
  let response;
  if (resourceId) {
    response = await setIsFeaturedById(user, resource, resourceId, isFeatured);
  } else {
    throw Error(`Resource ${resourceTitle} not found`);
  };

  return response;
};

const setIsCompanyFeaturedById = async (user, resourceId, isCompanyFeatured) => {
  //convert isFeatured string to boolean
  isCompanyFeatured = (isCompanyFeatured === 'true');
  //get service to send request to mark /unmark resource as Company Featured
  const service = isCompanyFeatured ? services.markAsCompanyFeatured : services.unmarkAsCompanyFeatured;
  const serviceUri = `${service.baseUrl}${service.path}${resourceId}`;

  // get authorization header
  const headersMap = await _getAuthorizationHeaderMap(user);

  // try to execute request
  try {
    // const session = await browser.getSession();
    const response = await endpointHelper.sendRequest(service.method, serviceUri, null, headersMap, { agent: agent });
    response.requestFunction = service.method;
    response.serviceUri = serviceUri;

    // store response to global.uniqueMap to be able to use it in next steps
    // global.uniqueMap[`${session['id_']}response`] = response;

    return response;
  }
  catch (error) {
    console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\n`);
    console.log('Error: ', error);
    error.requestFunction = service.method;
    error.serviceUri = serviceUri;
    return error;
  };
};

const setIsCompanyFeaturedByTitle = async (user, resource, resourceTitle, isCompanyFeatured) => {
  const resourceId = (await getResourceIdByAttr(user, resource, resourceTitle))[0];
  let response;
  if (resourceId) {
    response = await setIsCompanyFeaturedById(user, resourceId, isCompanyFeatured);
  } else {
    throw Error(`Resource ${resourceTitle} not found`);
  };

  return response;
};

const createResourceAndSetStatus = async (createByUser, setStatusByUser, resource, resourceData, status, setAllfields = false) => {
  status = status.toLowerCase();
  // create resource
  const createAction = (status === 'draft') ? 'saveDraft' : 'submit';
  const createResourceResponse = await createResource(createByUser, resource, resourceData, createAction, setAllfields);
  const resourceId = createResourceResponse.body.id;

  // set approved / rejected status if needed
  if (status === 'approved' || status === 'rejected') {
    await setApprovalStatusById(setStatusByUser, resource, resourceId, status);
  };

  return resourceId;
};


const getUsers = async (user, query) => {
  //get service to send getUsers request
  const service = services.getUsers;
  const serviceUri = query ? `${service.baseUrl}${service.path}?query=${query}` : `${service.baseUrl}${service.path}`;

  // get authorization header
  const headersMap = await _getAuthorizationHeaderMap(user);

  // try to execute request
  try {
    // const session = await browser.getSession();
    const response = await endpointHelper.sendRequest(service.method, serviceUri, null, headersMap, { agent: agent });
    const foundUsers = query ? response.body.items : response.body;
    // store response to global.uniqueMap to be able to use it in next steps
    // global.uniqueMap[`${session['id_']}response`] = response;

    return foundUsers;
  }
  catch (error) {
    console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\n`);
    console.log('Error: ', error);
    error.requestFunction = service.method;
    error.serviceUri = serviceUri;
    return error;
  };
};

const getUserIdByEmail = async (userRequestSender, email) => {
  const foundUsers = await getUsers(userRequestSender, email);

  return foundUsers[0].id;
};

const getUserDataByEmail = async (userRequestSender, email) => {
  const foundUsers = await getUsers(userRequestSender, email);

  return foundUsers[0];
};

const updateUser = async (userRequestSender, targetUser, inputData) => {
  //get service to send updateUser request
  const service = services.updateUser;
  const serviceUri = `${service.baseUrl}${service.path}`;

  // get authorization header
  const headersMap = await _getAuthorizationHeaderMap(userRequestSender);

  // prepare user data
  let newUserData;
  // get real user data
  const userData = await getUserDataByEmail(userRequestSender, targetUser.email);
  if (userData !== false) {
    // get template data for update user request
    newUserData = { ...services.updateUser.body };
    // update template data with real user values
    for (const prop in newUserData) {
      const realValue = userData.hasOwnProperty(prop) ? userData[prop] : null;
      newUserData[prop] = realValue;
    };

    // update template data with input data values
    for (const prop in inputData) {
      newUserData[prop] = inputData[prop];
    };
  } else {
    throw Error(`User with email "${targetUserEmail}" not found`);
  };

  // prepare formData
  const formData = {
    'content': JSON.stringify(newUserData)
  };

  // try to execute request
  try {
    // const session = await browser.getSession();
    const response = await endpointHelper.sendRequest(service.method, serviceUri, null, headersMap, { 'formData': formData, agent: agent });
    response.requestFunction = service.method;
    response.serviceUri = serviceUri;

    // store response to global.uniqueMap to be able to use it in next steps
    // global.uniqueMap[`${session['id_']}response`] = response;

    return response;
  }
  catch (error) {
    console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\n`);
    console.log('Error: ', error);
    error.requestFunction = service.method;
    error.serviceUri = serviceUri;
    return error;
  };
};

const getCompanyOfTargetUser = async (userRequestSender, targetUser) => {
  const userData = await getUserDataByEmail(userRequestSender, targetUser.email);
  return userData.company;
};

const updateUserCompany = async (userRequestSender, targetUser, companyName) => {
  const companyData = (await getCompanies(userRequestSender, companyName))[0];
  return updateUser(userRequestSender, targetUser, { 'company': companyData });
};

const updateCurrentUserCompany = async (user, companyName) => {
  const companyData = (await getCompanies(user, companyName))[0];
  return updateCurrentUserProfile(user, { 'company': companyData });
};

const updateUserRoles = async (userRequestSender, targetUser, role) => {
  let roleNamesArr = [];
  switch (role) {
    case 'GLOBAL_ADMIN':
      roleNamesArr.push('global administrator');
      break;
    case 'COMPANY_ADMIN':
      roleNamesArr.push('company administrator');
      roleNamesArr.push('content contributor');
      break;
    case 'COMPANY_AUTHOR':
      roleNamesArr.push('content contributor');
      break;
    case 'COMPANY_USER':
      break;

    default:
      throw Error(`${role} is not supported. Supported options: GLOBAL_ADMIN, COMPANY_ADMIN, COMPANY_AUTHOR,COMPANY_USER`)
  };
  let rolesObjectsArr = []
  for (const roleName of roleNamesArr) {
    const roleObj = await getRoleByName(userRequestSender, roleName);
    rolesObjectsArr = [...rolesObjectsArr, ...roleObj];
  };

  return updateUser(userRequestSender, targetUser, { 'user_roles': rolesObjectsArr });
};

const setPrivateModeForCurrentUser = async (user, isPrivateModeOn) => {
  isPrivateModeOn = (isPrivateModeOn === 'true');
  return updateCurrentUserProfile(user, { 'private': isPrivateModeOn });
};

const setPrivateModeForTargetUser = async (userRequestSender, targetUser, isPrivateModeOn) => {
  isPrivateModeOn = (isPrivateModeOn === 'true');
  return updateUser(userRequestSender, targetUser, { 'private': isPrivateModeOn });
};

const updateCurrentUserProfile = async (user, inputData) => {
  const currentUserProfile = await getCurrentUserProfile(user);
  //get service to send request to mark /unmark resource as Company Featured
  const service = services.updateCurrentUserProfile;
  const serviceUri = `${service.baseUrl}${service.path}`;

  //check if user is Global User (API uses different DTOs depending on User Roles)
  const userRoles = currentUserProfile.user_roles.map(userRoleObj => userRoleObj.role_name);
  const isGlobalUser = userRoles.includes('global administrator');
  // get user profile data
  const userProfile = isGlobalUser ? { ...service.body.GLOBAL_ADMIN_USER } : { ...service.body.NOT_GLOBAL_ADMIN_USER };
  for (const prop in userProfile) {
    userProfile[prop] = currentUserProfile[prop];
  };
  // update user profile data with input data values
  for (const prop in inputData) {
    userProfile[prop] = inputData[prop];
  };
  // get authorization header
  const headersMap = await _getAuthorizationHeaderMap(user);

  // prepare formData
  const formData = {
    'content': JSON.stringify(userProfile)
  };

  // try to execute request
  try {
    // const session = await browser.getSession();
    const response = await endpointHelper.sendRequest(service.method, serviceUri, null, headersMap, { 'formData': formData, agent: agent });
    response.requestFunction = service.method;
    response.serviceUri = serviceUri;

    // store response to global.uniqueMap to be able to use it in next steps
    // global.uniqueMap[`${session['id_']}response`] = response;

    return response;
  }
  catch (error) {
    console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\n`);
    console.log('Error: ', error);
    error.requestFunction = service.method;
    error.serviceUri = serviceUri;
    return error;
  };

};

const isGlobalUser = async (currentUser) => {
  const currentUserProfile = await getCurrentUserProfile(currentUser);
  const userRoles = currentUserProfile.user_roles.map(userRoleObj => userRoleObj.role_name);
  const isGlobalUser = userRoles.includes('global administrator');

  return isGlobalUser;
};

const removeCompanyFeaturedTokensFromResearches = async (user, numberOfTokens) => {
  const researchStatus = ['draft', 'pending', 'approved', 'rejected'];
  //send request to collect all researches with Company Featured tokens
  let featuredResearches = [];
  for (const status of researchStatus) {
    const foundResearches = await getCompanyContent(user, 'research', status);
    featuredResearches = [...featuredResearches, ...foundResearches];
  };
  const researchIdArr = featuredResearches.map(research => research._id);
  const researchesToRemoveToken = researchIdArr.slice(numberOfTokens);

  for (const researchId of researchesToRemoveToken) {
    await setIsCompanyFeaturedById(user, researchId, false);
  };

  return;
};

const getCompanyContent = async (user, resource, status, query = '') => {
  const resourceContentType = _mapResourceContentType(resource);
  query = encodeURIComponent(query);
  //get service to send request to get Company Content
  const service = services.getCompanyContent;
  const serviceUri = `${service.baseUrl}${service.path}?type=${resourceContentType}&query=${query}&status=${status}`;

  // get authorization header
  const headersMap = await _getAuthorizationHeaderMap(user);

  // try to execute request
  try {
    // const session = await browser.getSession();
    const response = await endpointHelper.sendRequest(service.method, serviceUri, null, headersMap, { agent: agent });
    const resourceArr = response.body.items;
    // store response to global.uniqueMap to be able to use it in next steps
    // global.uniqueMap[`${session['id_']}response`] = response;

    return resourceArr;
  }
  catch (error) {
    console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\n`);
    console.log('Error: ', error);
    error.requestFunction = service.method;
    error.serviceUri = serviceUri;
    return error;
  };
};

const getLeadStories = async (user, limit) => {
  //get service to send request to get lead stories
  const service = services.getLeadStories;
  const serviceUri = `${service.baseUrl}${service.path}?limit=${limit}`;

  // get authorization header
  const headersMap = await _getAuthorizationHeaderMap(user);

  // try to execute request
  try {
    // const session = await browser.getSession();
    const response = await endpointHelper.sendRequest(service.method, serviceUri, null, headersMap, { agent: agent });
    const leadStoriesArr = response.body;
    // store response to global.uniqueMap to be able to use it in next steps
    // global.uniqueMap[`${session['id_']}response`] = response;

    return leadStoriesArr;
  }
  catch (error) {
    console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\n`);
    console.log('Error: ', error);
    error.requestFunction = service.method;
    error.serviceUri = serviceUri;
    return error;
  };
};

const getLeadStoriesTitles = async (user, limit = 4) => {
  const leadStories = await getLeadStories(user, limit);
  const leadStorieTitles = leadStories.map(item => item.title);

  return leadStorieTitles;
};

const getRoles = async (user) => {
  //get service to send request to get lead stories
  const service = services.getUserRoles;
  const serviceUri = `${service.baseUrl}${service.path}`;

  // get authorization header
  const headersMap = await _getAuthorizationHeaderMap(user);

  // try to execute request
  try {
    // const session = await browser.getSession();
    const response = await endpointHelper.sendRequest(service.method, serviceUri, null, headersMap, { agent: agent });
    const rolesArr = response.body;
    // store response to global.uniqueMap to be able to use it in next steps
    // global.uniqueMap[`${session['id_']}response`] = response;

    return rolesArr;
  }
  catch (error) {
    console.log(`\nRequest failed:\nMethod '${service.method}'\nService URI: ${serviceUri}\n`);
    console.log('Error: ', error);
    error.requestFunction = service.method;
    error.serviceUri = serviceUri;
    return error;
  };
};

const getRoleByName = async (user, roleName) => {
  const rolesArr = await getRoles(user);
  const roleObj = rolesArr.filter(roleObj => roleObj.role_name === roleName);

  return roleObj;
};


module.exports = {
  setAuthorizationHeader,
  createResearch,
  createEvent,
  deleteResourceById,
  getResourceIdByAttr,
  deleteResourceByAttr,
  getCurrentUserProfile,
  setApprovalStatusById,
  getRegionIdByName,
  getTaxonomyIdByName,
  getEventStartDateByTitle,
  getEventEndDateByTitle,
  getCompanyOfCurrentUser,
  followCompanyById,
  followCompanyByName,
  rateArticleById,
  rateArticleByTitle,
  unfollowUserFromAllCompanies,
  bookmarkArticleByTitle,
  getEnabledCompanyNames,
  getCompanies,
  searchCompanyTest,
  getNewsDataForPublish,
  getArticleDataForPublish,
  submitResource,
  submitResourceWithAllFields,
  saveDraftResource,
  saveDraftResourceWithAllFields,
  setApprovalStatusByTitle,
  getResourceDataToModerateById,
  moderateResourceById,
  setIsFeaturedById,
  setIsFeaturedByTitle,
  setIsCompanyFeaturedById,
  setIsCompanyFeaturedByTitle,
  createResource,
  createResourceAndSetStatus,
  getResourceByAttr,
  getUsers,
  getUserIdByEmail,
  getUserDataByEmail,
  updateUser,
  updateUserCompany,
  getCompanyOfTargetUser,
  isGlobalUser,
  updateCurrentUserProfile,
  setPrivateModeForTargetUser,
  setPrivateModeForCurrentUser,
  updateCurrentUserCompany,
  removeCompanyFeaturedTokensFromResearches,
  getLeadStories,
  getLeadStoriesTitles,
  getRoles,
  updateUserRoles,
  getRoleByName,
  getResourceUrlByTitle
}
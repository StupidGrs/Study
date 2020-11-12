const request = require("request-promise");
const services = require("./src/data/api/api-data-services").services;

const _getResourceIdByAttr = async (user, resource, searchValue, attr = 'title', searchMethod) => {
    //console.log(`Search params: resource: ${resource}, attribute: ${attr}, search method: ${searchMethod}, search value: ${searchValue}`)
    //get service to send request to get Resource by Attr
    let service;
    switch (resource) {
        case 'Articles': service = services.getArticles;
            break;
        case 'Events': service = services.getEvents;
            break;
        case 'Taxonomies': service = services.getTaxonomies;
            break;
        case 'Regions': service = services.getRegions;
            break;
        default:
            throw Error(`Get ${resource} is not supported. Supported options: Articles, Events, Taxonomies, Regions`);
    };
    //prepare serviceUri for request
    attr = attr.toLowerCase();
    let serviceUri;
    if (searchMethod) {
        searchMethod = searchMethod.toLowerCase();
        serviceUri = `${service.baseUrl}${service.path}?_limit=1000&${attr}${searchMethod}=${searchValue}`;
    } else {
        serviceUri = `${service.baseUrl}${service.path}?_limit=1000&${attr}=${searchValue}`;
    };
    console.log(`Full request URL: ${serviceUri}`);

    //try to execute request
    let resourceIdsArr;

    const options = {
        method: 'GET',
        uri: serviceUri,
        json: true
    };

    try {
        const response = await request(options);
        resourceTitlesArr = response.map(a => {
            return a.title
        });
        resourceIdsArr = response.map(a => {
            switch (resource) {
                case 'Events':
                    return a._id;
                default:
                    return a.id;
            }
        });
        console.log(`Found ${resourceIdsArr.length} ${resource}:`);
        resourceTitlesArr.forEach(title => console.log(title));
        return resourceIdsArr;
    }
    catch (error) {
        console.log('Error: ', error);
        return false;
    };
};

const _deleteResourceById = async (resource, resourceId) => {

    //get service to send request to delete resource
    let service;
    switch (resource) {
        case 'Articles': service = services.deleteArticles;
            break;
        case 'Events': service = services.deleteEvents;
            break;

        default:
            throw Error(`Delete ${resource} is not supported. Supported options: Articles, Events`);
    };
    const serviceUri = `${service.baseUrl}${service.path}${resourceId}`;
    const options = {
        method: 'DELETE',
        uri: serviceUri,
    };
    //try to execute request
    try {
        const response = await request(options);
        console.log(`Deleted ${resource} by id ${resourceId}`);
        return response;
    }
    catch (error) {
        //console.log('Error: ', error);
        return false;
    };

};

const _deleteResourceByAttr = async (resource, value, attr = 'title', searchMethod) => {
    //get resource Ids to delete
    //console.log(`Trying to find ${resource} to delete`);
    const resourceIdsToDelete = await _getResourceIdByAttr(null, resource, value, attr, searchMethod);
    //get service to send request to delete resource
    if (resourceIdsToDelete.length) {
        //console.log(`The following ${resourceIdsToDelete.length} ${resource} to be deleted: ${resourceIdsToDelete}`);
        for (const resourceId of resourceIdsToDelete) {
            //try to execute request
            try {
                await _deleteResourceById(resource, resourceId);
            }
            catch (error) {
                console.log('Error: ', error);
                return false;
            };
        };
    } else {
        console.log(`No ${resource} to delete`);
    }
};

const cleanUpTestData = async () => {
    console.log('Cleanup process started');
    await _deleteResourceByAttr('Articles', 'Test_Auto', 'title', '_contains');
    await _deleteResourceByAttr('Events', 'Test_Auto', 'title', '_contains');

    // const objectsToDelete = global.uniqueMap['DeleteAfterTestRun'];
    // const deleteAllPromise = Promise.all(objectsToDelete.map(obj => {
    //     console.log(`Delete ${obj.resource} ${obj.attr} = ${obj.searchValue}`);
    //     return _deleteResourceByAttr(obj.resource, obj.searchValue, obj.attr);
    // }));
    // const cleanUpResult = deleteAllPromise.then(result => {
    //     global.uniqueMap['DeleteAfterTestRun'] = [];
    //     return result;
    // });

    // return cleanUpResult;
};

module.exports = {
    cleanUpTestData
}
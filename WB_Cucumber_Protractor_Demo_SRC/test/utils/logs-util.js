
const path = require('path');
const fs = require('fs');
// const baseUrl_BE = require('../data/api/dbDataAccess').baseUrl_BE;

//full information about Network Events 
//https://chromedevtools.github.io/devtools-protocol/tot/Network/

//resourceTypes: ['XHR', 'Document', 'Stylesheet', 'Image', 'Media', 'Font', 'Script', 'TextTrack', 'Fetch', 'EventSource', 'WebSocket', 'Manifest', 'SignedExchange', 'Ping', 'CSPViolationReport', 'Other']
//events: full events list can be found here:  https://chromedevtools.github.io/devtools-protocol/tot/Network/
//urls: filter by urls


// function _getFilterSettings() {
//     const filter = {
//         resourceType: ['XHR'],
//         eventType: ['Network.requestWillBeSent', 'Network.responseReceived', 'Network.loadingFailed', 'Page.navigatedWithinDocument'],
//         requestUrl: [baseUrl_BE],
//         responseUrl: [baseUrl_BE],
//         documentUrl: null
//     };
//
//     return filter;
// };
//
// function _getLogs(logsType) {
//     return browser.manage().logs().get(logsType);
// };
//
// function _compareLogMessageWithFilter(log) {
//     const message = JSON.parse(log.message).message;
//     const filter = _getFilterSettings();
//     //check message event type
//     if (filter.eventType) {
//         const messageEventType = message.method;
//         isEventTypeMatch = ((filter.eventType).indexOf(messageEventType) > -1);
//
//         if (!isEventTypeMatch) return false;
//     };
//
//     //check other message properties against filter
//     let result;
//     switch (_getEventDomain(message.method)) {
//         case 'Network':
//             result = _comapreNetworkEventWithFilter(message, filter);
//             break;
//         case 'Page':
//             result = _comaprePageEventWithFilter(message, filter);
//             break;
//
//     };
//     return result;
// };
//
// function _comapreNetworkEventWithFilter(message, filter) {
//     if (filter.resourceType) {
//         const messageResourceType = message.params.type;
//         isResourceTypeMatch = ((filter.resourceType).indexOf(messageResourceType) > -1);
//
//         if (!isResourceTypeMatch) return false;
//     };
//
//     if (filter.requestUrl && (message.method === 'Network.requestWillBeSent')) {
//         const messageRequestUrl = message.params.request.url;
//         isRequestUrlMatch = (filter.requestUrl).some(url => messageRequestUrl.includes(url));
//
//         if (!isRequestUrlMatch) return false;
//     };
//
//     if (filter.documentUrl && (message.method === 'Network.requestWillBeSent')) {
//         const messageDocumentUrl = message.params.documentURL;
//         isDocumentUrlMatch = (filter.documentUrl).some(url => messageDocumentUrl.includes(url));
//
//         if (!isDocumentUrlMatch) return false;
//
//     };
//     if (filter.responseUrl && (message.method === 'Network.responseReceived')) {
//         const messageResponseUrl = message.params.response.url;
//         isResponseUrlMatch = (filter.responseUrl).some(url => messageResponseUrl.includes(url));
//
//         if (!isResponseUrlMatch) return false;
//     };
//
//     return true;
// };
// function _comaprePageEventWithFilter(message, filter) {
//     if (filter.documentUrl) {
//         const messageUrl = message.params.url;
//         isPageNavUrlMatch = (filter.documentUrl).some(url => messageUrl.includes(url));
//
//         if (!isPageNavUrlMatch) return false;
//
//     };
//
//     return true;
// };
//
// function _getEventDomain(eventType) {
//     return eventType.split('.')[0];
// };
//
// function _getPostData(message) {
//     const request = message.params.request;
//     const contentType = request.headers["Content-Type"];
//     //in some cases postData is unavailable (example: requests with multipart/form-data)
//     let postData;
//     if ((request.hasOwnProperty('postData')) && (contentType === 'application/json')) {
//         postData = JSON.parse(request.postData);
//         //find login request and mask password
//         if (_isLoginRequest(request.url)) {
//             postData = _maskPassword(postData);
//         };
//         postData = JSON.stringify(postData);
//     } else {
//         postData = request.postData;
//     };
//
//     return postData;
// };
//
// function _isLoginRequest(requestUrl) {
//     const loginPartialUrl = 'msso/login/whitelist';
//     return (requestUrl.includes(loginPartialUrl))
// };
//
// function _maskPassword(postData) {
//     postData.password = '******';
//
//     return postData;
// };
//
// function _parseNetworkLog(logs) {
//     return logs.reduce((accumulator, log) => {
//         let message = JSON.parse(log.message).message;
//         switch (message.method) {
//             case 'Network.requestWillBeSent':
//                 message = _parseRequestWillBeSentMessage(message);
//                 break;
//             case 'Network.responseReceived':
//                 message = _parseResponseReceivedMessage(logs, message);
//                 break;
//             case 'Network.loadingFailed':
//                 message = _parseLoadingFailedMessage(logs, message);
//                 break;
//             case 'Page.navigatedWithinDocument':
//                 message = _parseNavigatedWithinDocumentMessage(message);
//                 break;
//             default:
//                 message = _parseMessageDefault(message);
//                 break;
//         };
//         accumulator.push(message);
//
//         return accumulator;
//     }, []);
// };
//
// function _parseRequestWillBeSentMessage(message) {
//     const requestId = message.params.requestId;
//     const request = message.params.request;
//
//     const dateTime = (new Date(message.params.wallTime * 1000)).toISOString();
//     let requestBody = '';
//     const postData = _getPostData(message);
//     if (postData) {
//         requestBody = `Request body: ${postData}`;
//     };
//
//     return `${dateTime} (${requestId}) ${request.method} ${request.url} ${requestBody}`;
// };
//
// function _parseResponseReceivedMessage(logs, message) {
//     const requestId = message.params.requestId;
//     const response = message.params.response;
//     //get details of original request
//     const request = _getRequestParamsByRequestId(logs, requestId);
//
//     return `Response received:       (${requestId}) ${request.method} ${response.url} -- ${response.status}`;
// };
//
// function _parseLoadingFailedMessage(logs, message) {
//     const requestId = message.params.requestId;
//     const canceled = message.params.canceled;
//     const errorText = message.params.errorText;
//     //get details of original request
//     const request = _getRequestParamsByRequestId(logs, requestId);
//
//     if (canceled) {
//         return `Request canceled:        (${requestId}) ${request.method} ${request.url} -- error: "${errorText}"`;
//     } else {
//         return `Loading failed:          (${requestId}) ${request.method} ${request.url} -- error: "${errorText}"`;
//     };
// };
//
// function _parseMessageDefault(message) {
//     const requestId = message.params.requestId;
//     const eventType = message.method;
//     const params = JSON.stringify(message.params);
//     return `${eventType}: (${requestId}) params: ${params}`;
// };
//
// function _parseNavigatedWithinDocumentMessage(message) {
//     const url = message.params.url;
//
//     return `Navigate to: ${url}`;
// };
//
// function _getRequestParamsByRequestId(logs, requestId) {
//     const requestLog = logs.filter(log => {
//         const message = JSON.parse(log.message).message;
//         return (message.method === 'Network.requestWillBeSent') ? (message.params.requestId === requestId) : false
//     })[0];
//
//     let request = {};
//     if (requestLog) {
//         request = JSON.parse(requestLog.message).message.params.request;
//     };
//
//     return request;
// };
//
// function _isLocalReporter() {
//     return browser.params.env.includes('LOCAL');
// };
//
// function _attachToCIReporter(world, string) {
//     if (!_isLocalReporter()) {
//         world.attach(Buffer.from(string).toString('base64'));
//     };
// };
//
// function _attachToLocalReporter(world, attachment, mime = 'text/plain') {
//     if (_isLocalReporter()) {
//         world.attach(attachment, mime);
//     };
// };
//
// function _writeLogsInFile(testCase, logs, logsDescription) {
//     const featureName = testCase.pickle.name.replace(/\s|\/|\?|<|>|\\|:|\*|\||"/g, '_');
//     const logsDir = path.join(process.cwd(), 'reports', 'logs');
//     const logsFileName = `${featureName}${Date.now()}_${logsDescription}.json`;
//
//     if (!fs.existsSync(logsDir)) {
//         fs.mkdirSync(logsDir);
//     };
//
//     try {
//         fs.writeFileSync(path.join(logsDir, logsFileName), JSON.stringify(logs, null, 2), 'utf8');
//     } catch (err) {
//         console.error(err);
//     };
//
//     return logsFileName;
// };

function writeNetworkLogs(world, testCase) {
    return (
        _getLogs('performance').then((logs) => {
            const filteredLogs = logs.filter(_compareLogMessageWithFilter);
            const parsedLogs = _parseNetworkLog(filteredLogs);
            const logsFile = _writeLogsInFile(testCase, parsedLogs, '_Network');

            _attachToCIReporter(world, 'Network requests:');

            parsedLogs.forEach((message) => {
                _attachToCIReporter(world, message);
                _attachToLocalReporter(world, message);
            });

            _attachToCIReporter(world, `See all network logs in build artifacts: ${logsFile}`);
            _attachToLocalReporter(world, `See all network logs in build artifacts: ${logsFile}`);

            //clear performance log
            return (logs.length = 0);
        }));
};

function writeConsoleLogs(world, testCase) {
    return (
        _getLogs('browser').then((logs) => {
            const logsFile = _writeLogsInFile(testCase, logs, '_Console');

            _attachToCIReporter(world, 'Console errors:');

            logs.forEach((log) => {
                _attachToCIReporter(world, log.message);
                _attachToLocalReporter(world, JSON.stringify(log), 'application/json');
            });

            _attachToCIReporter(world, `See all network logs in build artifacts: ${logsFile}`);
            _attachToLocalReporter(world, `See all network logs in build artifacts: ${logsFile}`);

            //clear browser log
            return (logs.length = 0);
        }));
};

module.exports = {
    writeNetworkLogs,
    writeConsoleLogs
};
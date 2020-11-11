const request = require('request');

const endpointHelper = {
  /**
   * Send request to the server with specified URL and return response body as text
   *
   * @param {String} uri
   * @param {String} body type of String
   * @param {String} Optional httpHeaders
   * @param {String} httpMethod default value is GET. You may provide any other method to get response
   * @returns {promise.Promise<string>} responseText
   */
  getResponseText: function (httpMethod = 'GET', uri, body = JSON.stringify({}), httpHeaders) {
    return endpointHelper.sendRequest(httpMethod, uri, body, httpHeaders)
      .then(response => response.responseText);
  },

  /**
   * Send request to the server with specified URL and return response status code
   *
   * @param {String} uri
   * @param {String} body type of String
   * @param {String} Optional httpHeaders
   * @param {String} httpMethod default value is GET. You may provide any other method to get response
   * @returns {promise.Promise<number>} response status code
   */
  getResponseStatus: function (httpMethod = 'GET', uri, body = JSON.stringify({}), httpHeaders) {
    return endpointHelper.sendRequest(httpMethod, uri, body, httpHeaders)
      .then(response => response.status);
  },

  /**
   * Send request to the server with specified URL and return response headers
   *
   * @param {String} uri
   * @param {String} body type of String
   * @param {String} Optional httpHeaders
   * @param {String} httpMethod default value is GET. You may provide any other method to get response
   * @returns {promise.Promise<any>} response status code
   */
  getResponseHeaders: function (httpMethod = 'GET', uri, body = JSON.stringify({}), httpHeaders) {
    return endpointHelper.sendRequest(httpMethod, uri, body, httpHeaders)
      .then(response => response.headers);
  },

  /**
   * Send request to the server and return response
   *
   * @param {String} method default value is POST. You may provide any other method to get response
   * @param {String} uri
   * @param {String} body body type of String
   * @param {Object} headers httpHeaders
   * @param {Object} additionalOptions please see all options - https://github.com/request/request#requestoptions-callback
   * @returns {Promise<any>}
   *
   * agentOptions: { rejectUnauthorized: false }
   * to fix errors with selfsigned ssl certificates
   * all options - https://github.com/request/request#requestoptions-callback
   */

  sendRequest: function (method = 'POST', uri, body, headers, additionalOptions) {
    return new Promise((resolve, reject) => {
      const options = {
        method,
        uri,
        body,
        headers: processHeaders(headers),
        agentOptions: { rejectUnauthorized: false },
        ...additionalOptions
      };

      request(options, function (error, response, _body) {
        if (error) {
          console.error('request error:', error);
          reject(error);
          return;
        }

        const responseObj = response.toJSON();
        responseObj.statusMessage = response.statusMessage;

        // old version used this
        responseObj.responseText = responseObj.body;
        responseObj.statusText = response.statusMessage;
        responseObj.status = responseObj.statusCode;

        if (responseObj.body) {
          try {
            responseObj.body = JSON.parse(responseObj.body);
          } catch (err) {
            if (!err.message.match(/Unexpected token .* in JSON/)) {
              // if it's not error with parsing json
              throw err;
            }
          }
        }

        resolve(responseObj);
      });
    });
  }
};

module.exports = endpointHelper;

function processHeaders(rawHeaders) {
  // convert map to object
  let headers = {};

  if (rawHeaders instanceof Map) {
    rawHeaders.forEach((value, key) => {
      headers[key] = value;
    });
  } else {
    headers = rawHeaders;
  }

  return headers;
}

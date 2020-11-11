/**
 * Created by webber-ling on 7/10/2020.
 */

"use strict";

let fs = require('fs');
let ec = protractor.ExpectedConditions;
const dateformat = require('dateformat');
const path = require('path');
let Request = require("request");




const api_func = function () {



    this.__api_ReturnTotalRecentArticles = function () {

        let deffered = protractor.promise.defer(); //create a promise

        let status;

        Request.get({
            rejectUnauthorized: false,

            "headers": { "apikey": "xBnWRZClTXf0YpMlOLQz0UQjPzZplPLA" },
            "url": "https://api.src.us-east-1.dev.int.mercer.com/v1/api/articles/public/recent",

        }, (error, response, body) => {
            if(error) {
                return console.dir(error);
            }
            console.dir("Response Code ****:"+response.statusCode);
            // expect(response.statusCode).toBe(200);

            status = response.statusCode;

            console.dir(" --------------- Start Body ------------------");
            let contents = JSON.parse(body);
            console.log('Total articles returned: ' + contents.length);

            console.dir(" --------------- End Body ------------------");

            deffered.fulfill(contents);

        });

        return deffered.promise; //return the created promise.


    };







};
module.exports = api_func;




/**
 * Created by webber-ling on 7/18/2020.
 */


"use strict";

let fs = require('fs');
let ec = protractor.ExpectedConditions;
const dateformat = require('dateformat');
const path = require('path');
let util_windows = require('../../common/utilities/util_windows');
let futil_windows = new util_windows();
let util_timer = require('../../common/utilities/util_timer');
let futil_timer = new util_timer();
let util_xlsx = require('../../common/utilities/util_xlsx');
let futil_xlsx = new util_xlsx();
let common_obj = require('../../common/common_obj');
let fcommon_obj = new common_obj();
let common_page = require('../../page-objects/common_page');
let pcommon_page = new common_page();
let common_test = require('../common_test/common_test');
let fcommon_test = new common_test();

let strapi_page = require('../../page-objects/strapi');
let pstrapi_page = new strapi_page();
let login_page = require('../../page-objects/login');
let plogin_page = new login_page();
let onboarding_page = require('../../page-objects/onboarding');
let ponboarding_page = new onboarding_page();
let dashboard_page = require('../../page-objects/dashboard');
let pdashboard_page = new dashboard_page();
let research_page = require('../../page-objects/research');
let presearch_page = new research_page();
let news_page = require('../../page-objects/news');
let pnews_page = new news_page();

let common_publish = require('../../page-objects/common_publish');
let pcommon_publish = new common_publish();





let td = {
        "Strapi_URL": browser.params.url_strapi.url_test,
        "Strapi_Username": browser.params.url_strapi.username,
        "Strapi_Password": browser.params.url_strapi.password,
        "Strapi_UserName": "Webber Ling",
        "Internal": true,
        "Email": "webber.ling@mercer.com",
        "OKTA_ID": "1002150",
        "OKTA_PSW": "qassword011!",
        "Upload_FeaturedImage": "../data/in/featuredImage.jpg",
    };





beforeAll(function () {
    fcommon_obj.__log('------------ before all');

});
afterAll(function () {
    fcommon_obj.__log('------------ after all');
});





let td_News = {
    "User": browser.params.login.login_globAdmin,
    // "User": browser.params.login.login_compAdmin,
    // "User": browser.params.login.login_compAuthor,

    "Title":    fcommon_test.__GenerateRandomString('AutoNews_DNT_'),
    "ExecutiveSummary": 'This is ExecutiveSummary: ' + futil_timer.__returnYYYYMMDDHMS(),
    "URL": 'https://colleagueconnect.mmc.com/en-us/Pages/HomePage.aspx',
    "Content": 'This is News Content: ' + futil_timer.__returnYYYYMMDDHMS(),

    "Company": 'CompAuto',
    "Type": 'House View',
    "Location": 'Shanghai, Chin',
    "Taxonomy": 'Broad Equity',
    "Tag": 'Technology',
    "NumOfMins": '8',
    "VideoLink": 'https://www.youtube.com/watch?v=haSX6qLGA3w',
    "Region": 'Asia', // hard coded in scripts
    "Audience": 'Asset Manager', // hard coded in scripts
    "Author": 'webber.ling@mercer.com',

    "Upload_FeaturedImage": "../data/in/Test_Image.jpg",
    "Upload_Attachemnts": '../data/in/\"\"Test_PDF.pdf\"\" \"\"Test_Word.docx\"\" \"\"Test_Excel.xls\"\" \"\"Test_PPT.pptx\"\""',

    "SuccessMsg": 'Thank you for your news article submission. Please note that all submissions are sent to moderation for admin approval. You will be notified when your submission is approved.'
};
describe('Completed - Submit a News', function () {

    fcommon_test.__GivenUserSubmitAnArtical(td_News, false);

});

let td_ResearchDetails = {
    "User": browser.params.login.login_globAdmin,
    // "User": browser.params.login.login_compAdmin,
    // "User": browser.params.login.login_compAuthor,

    "Title":    fcommon_test.__GenerateRandomString('AutoResearch_DNT_'),
    "ExecutiveSummary": 'This is ExecutiveSummary: ' + futil_timer.__returnYYYYMMDDHMS(),
    "URL": 'https://colleagueconnect.mmc.com/en-us/Pages/HomePage.aspx',
    "Content": 'This is Research Content: ' + futil_timer.__returnYYYYMMDDHMS(),

    "Company": 'CompAuto',
    "Type": 'House View',
    "Location": 'Shanghai, Chin',
    "Taxonomy": 'Broad Equity',
    "Tag": 'Technology',
    "NumOfMins": '8',
    "VideoLink": 'https://www.youtube.com/watch?v=haSX6qLGA3w',
    "Region": 'Asia', // hard coded in scripts
    "Audience": 'Asset Manager', // hard coded in scripts
    "Author": 'webber.ling@mercer.com',

    "Upload_FeaturedImage": "../data/in/Test_Image.jpg",
    "Upload_Attachemnts": '../data/in/\"\"Test_PDF.pdf\"\" \"\"Test_Word.docx\"\" \"\"Test_Excel.xls\"\" \"\"Test_PPT.pptx\"\""',

    "SuccessMsg": 'Thank you for your research article submission. Please note that all submissions are sent to moderation for admin approval. You will be notified when your submission is approved.'
};
describe('Completed - Submit an Research', function () {

    fcommon_test.__GivenUserSubmitAnArtical(td_ResearchDetails);


});

let td_EventDetails = {
    "User": browser.params.login.login_globAdmin,
    // "User": browser.params.login.login_compAdmin,
    // "User": browser.params.login.login_compAuthor,

    "EventName":    fcommon_test.__GenerateRandomString('AutoEvent_DNT'),
    "EventExcerpt": 'This is Event Excerpt: ' + futil_timer.__returnYYYYMMDDHMS(),
    "URL": 'https://colleagueconnect.mmc.com/en-us/Pages/HomePage.aspx',
    "EventContent": 'This is Event Content: ' + futil_timer.__returnYYYYMMDDHMS(),

    "Company": 'CompAuto',
    "EventType": 'Webinar',
    "Location": 'Shanghai, Chin',
    "Taxonomy": 'Broad Equity',
    "Tag": 'Technology',
    "Region": 'Asia', // hard coded in scripts
    "Audience": 'Asset Manager', // hard coded in scripts

    "Upload_FeaturedImage": "../data/in/Test_Image.jpg",
    "SuccessMsg": 'Thank you for your event submission. Please note that all submissions are sent to moderation for admin approval. You will be notified when your submission is approved.'
};
describe('Completed - Submit an Event', function () {

    fcommon_test.__GivenUserSubmitAnEvent(td_EventDetails);


});







/**
 * Created by webber-ling on 6/18/2020.
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
let contentList = require('../../page-objects/contentList');
let pcontentList = new contentList();



let td = {
    "User": browser.params.login.login_globAdmin,
    
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
    browser.getCapabilities().then(function(txt){
        console.log(txt.get('browserName'));
        if(txt.get('browserName') === 'internet explorer')
            console.log('yes');

    });
});
afterAll(function () {
    fcommon_obj.__log('------------ after all');
});




let td_News = {
    "User": browser.params.login.login_globAdmin,
    // "User": browser.params.login.login_compAdmin,
    // "User": browser.params.login.login_compAuthor,

    // "Title":    fcommon_test.__GenerateRandomString('0_AutoNews_'),
    "Title":    '0_AutoNews_' + futil_timer.__returnYYYYMMDDHMS(),
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
describe('Completed - Approve the News just submitted', function () {

    xit('User login as: ' + td_News.User, function () {
        fcommon_test.__GivenTheUserHasLoginSRC(td_News.User);
    });

    it('User goes to Setting -> : Moderate Content', function () {
        pcommon_page.__gotoSetting('Moderate Content');
    });

    it('User searches the item to be Approved: ' + td_News.Title, function () {
        pcontentList.__doSearch('Waiting for approval', 'blog/news post', td_News.Title);
    });

    it('User approves the item: ' + td_News.Title, function () {
        pcontentList.__doApproveReject(td_News.Title, true);
    });

});
describe('Completed - Verify the approved News displays on News Page', function () {

    xit('User login as: ' + td_News.User, function () {
        fcommon_test.__GivenTheUserHasLoginSRC(td_News.User);
    });

    it('User waits for 5 seconds', function () {
        browser.sleep(browser.params.userSleep.medium);
    });

    it('User goes to tab News', function () {
        pcommon_page.__selectMenu('News');
    });

    it('User searches / verify visiblity of the item just Approved: ' + td_News.Title, function () {
        pcommon_page.__searchAndVerifyExist(td_News.Title);
    });


});


let td_ResearchDetails = {
    "User": browser.params.login.login_globAdmin,
    // "User": browser.params.login.login_compAdmin,
    // "User": browser.params.login.login_compAuthor,

    // "Title":    fcommon_test.__GenerateRandomString('0_AutoResearch_'),
    "Title":    '0_AutoResearch_' + futil_timer.__returnYYYYMMDDHMS(),
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
describe('Completed - Approve the Research just submitted', function () {

    xit('User login as: ' + td_ResearchDetails.User, function () {
        fcommon_test.__GivenTheUserHasLoginSRC(td_ResearchDetails.User);
    });

    it('User goes to Setting -> : Moderate Content', function () {
        pcommon_page.__gotoSetting('Moderate Content');
    });

    it('User searches the item to be Approved: ' + td_ResearchDetails.Title, function () {
        pcontentList.__doSearch('Waiting for approval', 'research post', td_ResearchDetails.Title);
    });

    it('User approves the item: ' + td_ResearchDetails.Title, function () {
        pcontentList.__doApproveReject(td_ResearchDetails.Title, true);
    });

});
describe('Completed -Verify aproved Research displays on Research Page', function () {

    xit('User login as: ' + td_ResearchDetails.User, function () {
    fcommon_test.__GivenTheUserHasLoginSRC(td_ResearchDetails.User);
});

    it('User waits for 5 seconds', function () {
        browser.sleep(browser.params.userSleep.medium);
    });

    it('User goes to tab Research', function () {
        pcommon_page.__selectMenu('Research');
    });

    it('User searches / verify visiblity of the item just Approved: ' + td_ResearchDetails.Title, function () {
        pcommon_page.__searchAndVerifyExist(td_ResearchDetails.Title);
    });




});


let td_EventDetails = {
    "User": browser.params.login.login_globAdmin,
    // "User": browser.params.login.login_compAdmin,
    // "User": browser.params.login.login_compAuthor,

    // "EventName":    fcommon_test.__GenerateRandomString('0_AutoEvent_'),
    "EventName":    '0_AutoEvent_' + futil_timer.__returnYYYYMMDDHMS(),
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
describe('Completed - Approve the Event just submitted', function () {

    xit('User login as: ' + td_EventDetails.User, function () {
        fcommon_test.__GivenTheUserHasLoginSRC(td_EventDetails.User);
    });

    it('User goes to Setting -> : Moderate Content', function () {
        pcommon_page.__gotoSetting('Moderate Content');
    });

    it('User searches the item to be Approved: ' + td_EventDetails.EventName, function () {
        pcontentList.__doSearch('Waiting for approval', 'event', td_EventDetails.EventName);
    });

    it('User approves the item: ' + td_EventDetails.EventName, function () {
        pcontentList.__doApproveReject(td_EventDetails.EventName, true);
    });

});
describe('Completed - Verify approved Event displays on Events Page', function () {

    xit('User login as: ' + td_EventDetails.User, function () {
        fcommon_test.__GivenTheUserHasLoginSRC(td_EventDetails.User);
    });

    it('User waits for 5 seconds', function () {
        browser.sleep(browser.params.userSleep.medium);
    });

    it('User waits for 5 seconds', function () {
        browser.sleep(browser.params.userSleep.medium);
    });

    it('User goes to tab Events', function () {
        pcommon_page.__selectMenu('Events');
    });



    it('User searches / verify visiblity of the item just Approved: ' + td_EventDetails.EventName, function () {
        pcommon_page.__searchAndVerifyExist(td_EventDetails.EventName);
    });


});


xdescribe('debug: ', function () {


    it('test', function () {

        fcommon_test.__GivenTheUserHasLoginSRC(td.User);
        
        // pcommon_page.__gotoSetting('Moderate Content');
        //
        // pcontentList.__doSearch('Waiting for approval', 'research post', 'AutoResearch');
        //
        // pcontentList.__doApproveReject('AutoResearch', true);


        pcommon_page.__selectMenu('Research');
        pcommon_page.__searchAndVerifyExist('AutoResearchxxx', false);
        

    });


    it('sleep', function () {


        browser.sleep(15000);
        fcommon_obj.__log('a***test');

    });


});









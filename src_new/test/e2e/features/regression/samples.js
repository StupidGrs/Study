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
let contentList = require('../../page-objects/contentList');
let pcontentList = new contentList();




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


xdescribe('debug: ', function () {

    it('OKTA login / logout ', function () {
        //plogin_page.__login(browser.params.url.url_test, td.Email);
        // plogin_page.__login_okta(td.OKTA_ID, td.OKTA_PSW);
        // fcommon_obj.__wait4ElementVisible(pdashboard_page._txtTrendingNewsAndBlogs, 'Trending News & Blogs');
        //pcommon_page.__logout();

    });


    it('test: ', function () {

        fcommon_test.__GivenTheUserHasLoginSRC(browser.params.login.login_globAdmin);

        pcommon_publish.__Publish('Event');
        expect(pcommon_publish._txtStartDate.getText()).toBe('');
        expect(pcommon_publish._txtEndDate.getText()).toBe('');

        expect(pcommon_publish._txtStartTime.getAttribute('placeholder')).toBe('');
        expect(pcommon_publish._txtEndTime.getAttribute('placeholder')).toBe('');



        let currentDate = new Date();
        let startDate = dateformat(currentDate, 'd-mmm-yyyy');
        fcommon_obj.__executeScript(pcommon_publish._txtStartDate, 'startdate', "click");
        pcommon_page.__setCalender(startDate);
        fcommon_obj.__executeScript(pcommon_publish._labelStartTime, '_labelStartTime', "click");


        let endDate = dateformat(currentDate.setDate(currentDate.getDate() + 1), 'd-mmm-yyyy');
        fcommon_obj.__executeScript(pcommon_publish._txtEndDate, 'endDate', "click");
        pcommon_page.__setCalender(endDate);
        fcommon_obj.__executeScript(pcommon_publish._labelStartTime, '_labelStartTime', "click");

        fcommon_obj.__isDropDownItemSelected_byGetText(pcommon_publish._lstTaxonomies, '_lstTaxonomies', 'Select Taxonomy');
        fcommon_obj.__selectByText('_lstTaxonomies', pcommon_publish._lstTaxonomies, 'Emerging Market Equity');


        // expect(pcommon_publish._txtFeaturedImage.getText()).toBe('Featured Image');

        // fcommon_obj.__executeScript(pcommon_publish._txtFeaturedImage, '_txtFeaturedImage', "click");
        // fcommon_obj.__executeScript(pcommon_publish._txtRegions, '_txtRegions', "click");
        // fcommon_obj.__executeScript(pcommon_publish._txtAudience, '_txtAudience', "click");

        // expect(pcommon_publish._zoneFeaturedImage.getText()).toBe('Drag and drop to upload a file');
        // pcommon_publish._zoneFeaturedImage.getText().then(function(txt){
        //    expect(txt).toBe('Drag and drop to upload a file') ;
        // });


        // fcommon_obj.__click('_zoneFeaturedImage_clickable', pcommon_publish._zoneFeaturedImage_clickable);

        // fcommon_obj.__executeScript(pcommon_publish._txtRegions, '_txtRegions', "click");
        // fcommon_obj.__isCheckBoxChecked(pcommon_publish._chkRegion_AllRegions, '_chkRegion_AllRegions', false);
        // fcommon_obj.__executeScript(pcommon_publish._txtRegion_AllRegions, '_txtRegion_AllRegions', "click");
        // fcommon_obj.__isCheckBoxChecked(pcommon_publish._chkRegion_AllRegions, '_chkRegion_AllRegions', true);

        // fcommon_obj.__setText('_txtEventContent', pcommon_publish._txtEventContent, 'test', false, false);

        // browser.sleep(10000);
        // fcommon_obj.__executeScript(pcommon_publish._zoneFeaturedImage_delete, '_zoneFeaturedImage_delete', "click");
        // expect(pcommon_publish._zoneFeaturedImage.getText()).toBe('Drag and drop to upload a file');




    });

    it('Open File', function () {
        // pcommon_publish.__OpenFile(td.Upload_FeaturedImage);

    });


    it('sleep', function () {


        browser.sleep(5000);
        fcommon_obj.__log('a***test');

    });


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

    it('User goes to tab Events', function () {
        pcommon_page.__selectMenu('Events');
    });



    it('User searches / verify visiblity of the item just Approved: ' + td_EventDetails.EventName, function () {
        pcommon_page.__searchAndVerifyExist(td_EventDetails.EventName);
    });


});


xdescribe('Completed - Delete Articles & Events ', function () {


    it('test', function () {

        pstrapi_page.__login(td.Strapi_URL, td.Strapi_Username, td.Strapi_Password);

        pstrapi_page.__DeleteData('Articles', '000_Test');
        pstrapi_page.__DeleteData('Events', '000_Test');

    });


    it('sleep', function () {


        browser.sleep(3000);
        fcommon_obj.__log('a***test');

    });


});





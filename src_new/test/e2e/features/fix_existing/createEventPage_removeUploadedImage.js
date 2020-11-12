/**
 * Created by webber-ling on 7/29/2020.
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
let common_moderate = require('../../page-objects/common_moderate');
let pcommon_moderate = new common_moderate();
let userArticleList_page = require('../../page-objects/userArticleList');
let puserArticleList_page = new userArticleList_page();
let contentList = require('../../page-objects/contentList');
let pcontentList = new contentList();







let td_EventDetails = {
    // "User": browser.params.login.login_globAdmin,
    "User": browser.params.login.login_compAdmin,
    // "User": browser.params.login.login_compAuthor,

    "EventName":     fcommon_test.__GenerateRandomString('0_AutoEvent_'),
    // "EventName":    '0_AutoEvent_' + futil_timer.__returnYYYYMMDDHMS(),
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
    "SuccessMsg": 'Your event has been saved.'
};


beforeAll(function () {
    fcommon_obj.__log('------------ before all');

});
afterAll(function () {
    fcommon_obj.__log('------------ after all');
});

// fcommon_test.__GivenUserSubmitAnEvent(td_EventDetails, false);
//
// describe('Verify that Company Admin is able to remove uploaded image on Draft Event Page', function () {
//
//
//     it('WHEN User login as: ' + td_EventDetails.User, function () {
//         fcommon_test.__GivenTheUserHasLoginSRC(td_EventDetails.User);
//     });
//
//     it('AND User goes to Posts menu under Person settings', function () {
//         pcommon_page.__gotoPersonIcon_Menu('Posts');
//     });
//
//     it('AND User selects event from Select Content Type dropdown', function () {
//         puserArticleList_page.__selectedContentType('event');
//     });
//
//     it('THEN The expected posts displays on the page: ' + td_EventDetails.EventName, function () {
//         puserArticleList_page.__verifyPostsExist(td_EventDetails.EventName);
//     });
//
//     it('WHEN User clicks on the Posts: ' + td_EventDetails.EventName, function () {
//         puserArticleList_page.__selectPosts(td_EventDetails.EventName);
//     });
//
//     it('THEN User Publish Your Event Screen displays', function () {
//         expect(pcommon_publish._txtHeader.getText()).toBe('Publish Your Event');
//     });
//
//     it('WHEN User expands the Featured Image', function () {
//         fcommon_obj.__executeScript(pcommon_publish._txtFeaturedImage, '_txtFeaturedImage', "click");
//         browser.sleep(browser.params.userSleep.short);
//     });
//
//     it('THEN Remove Image button is displayed and enabled', function () {
//
//         expect(pcommon_publish._zoneFeaturedImage_delete.isDisplayed()).toBe(true);
//         expect(pcommon_publish._zoneFeaturedImage_delete.isEnabled()).toBe(true);
//     });
//
//     it('WHEN User clicks on Remove Image icon', function () {
//         fcommon_obj.__executeScript(pcommon_publish._zoneFeaturedImage_delete, '_txtFeaturedImage', "click");
//         browser.sleep(browser.params.userSleep.short);
//     });
//
//     it('THEN the Image is removed', function () {
//         expect(pcommon_publish._zoneFeaturedImage_uploadedImg.isPresent()).toBe(false);
//     });
//
//     it('AND User save draft of the Event: ' + td_EventDetails.EventName, function () {
//
//         fcommon_obj.__executeScript(pcommon_publish._btnSaveDraft, '_btnSaveDraft', "click");
//         fcommon_obj.__wait4ElementVisible(pcommon_publish._txtToastOutletMsg, '_txtToastOutletMsg');
//         expect(pcommon_publish._txtToastOutletMsg.getText()).toBe(td_EventDetails.SuccessMsg);
//
//         fcommon_obj.__executeScript(pcommon_publish._btnToastOutletMsg_close, '_btnToastOutletMsg_close', "click");
//
//     });
//
//     it('WHEN User login as: ' + td_EventDetails.User, function () {
//         fcommon_test.__GivenTheUserHasLoginSRC(td_EventDetails.User);
//     });
//
//     it('AND User goes to Posts menu under Person settings', function () {
//         pcommon_page.__gotoPersonIcon_Menu('Posts');
//     });
//
//     it('AND User selects event from Select Content Type dropdown', function () {
//         puserArticleList_page.__selectedContentType('event');
//     });
//
//     it('THEN The expected posts displays on the page: ' + td_EventDetails.EventName, function () {
//         puserArticleList_page.__verifyPostsExist(td_EventDetails.EventName);
//     });
//
//     it('WHEN User clicks on the Posts: ' + td_EventDetails.EventName, function () {
//         puserArticleList_page.__selectPosts(td_EventDetails.EventName);
//     });
//
//     it('THEN User Publish Your Event Screen displays', function () {
//         expect(pcommon_publish._txtHeader.getText()).toBe('Publish Your Event');
//     });
//
//     it('WHEN User expands the Featured Image', function () {
//         fcommon_obj.__executeScript(pcommon_publish._txtFeaturedImage, '_txtFeaturedImage', "click");
//         browser.sleep(browser.params.userSleep.short);
//     });
//
//     it('THEN the Image is removed', function () {
//         expect(pcommon_publish._zoneFeaturedImage_uploadedImg.isPresent()).toBe(false);
//     });
//
//     it('THEN Remove Image button is not displayed', function () {
//         expect(pcommon_publish._zoneFeaturedImage_delete.isPresent()).toBe(false);
//     });
//
//
//
// });
//
// describe('Verify that Company Admin is able to upload image on Draft Event Page', function () {
//
//
//     it('WHEN User login as: ' + td_EventDetails.User, function () {
//         fcommon_test.__GivenTheUserHasLoginSRC(td_EventDetails.User);
//     });
//
//     it('AND User goes to Posts menu under Person settings', function () {
//         pcommon_page.__gotoPersonIcon_Menu('Posts');
//     });
//
//     it('AND User selects event from Select Content Type dropdown', function () {
//         puserArticleList_page.__selectedContentType('event');
//     });
//
//     it('THEN The expected posts displays on the page: ' + td_EventDetails.EventName, function () {
//         puserArticleList_page.__verifyPostsExist(td_EventDetails.EventName);
//     });
//
//     it('WHEN User clicks on the Posts: ' + td_EventDetails.EventName, function () {
//         puserArticleList_page.__selectPosts(td_EventDetails.EventName);
//     });
//
//     it('THEN User Publish Your Event Screen displays', function () {
//         expect(pcommon_publish._txtHeader.getText()).toBe('Publish Your Event');
//     });
//
//     it('WHEN User expands the Featured Image', function () {
//         fcommon_obj.__executeScript(pcommon_publish._txtFeaturedImage, '_txtFeaturedImage', "click");
//         browser.sleep(browser.params.userSleep.short);
//     });
//
//     it('THEN There is no Image uploaded', function () {
//         expect(pcommon_publish._zoneFeaturedImage_uploadedImg.isPresent()).toBe(false);
//     });
//
//     it('AND Remove Image button is not displayed', function () {
//         expect(pcommon_publish._zoneFeaturedImage_delete.isPresent()).toBe(false);
//         fcommon_obj.__click('_zoneFeaturedImage_clickable', pcommon_publish._zoneFeaturedImage_clickable);
//     });
//
//     it('WHEN User uploads Featured Image: ' + td_EventDetails.Upload_FeaturedImage, function () {
//         pcommon_publish.__OpenFile(td_EventDetails.Upload_FeaturedImage);
//
//     });
//
//     it('THEN the Uploaded Image is displayed', function () {
//         fcommon_obj.__wait4ElementVisible(pcommon_publish._zoneFeaturedImage_uploadedImg, '_zoneFeaturedImage_uploadedImg');
//         expect(pcommon_publish._zoneFeaturedImage_uploadedImg.isDisplayed()).toBe(true);
//     });
//
//     it('AND Remove Image button is displayed', function () {
//         expect(pcommon_publish._zoneFeaturedImage_delete.isDisplayed()).toBe(true);
//     });
//
//     it('AND User save draft of the Event: ' + td_EventDetails.EventName, function () {
//
//         fcommon_obj.__executeScript(pcommon_publish._btnSaveDraft, '_btnSaveDraft', "click");
//         fcommon_obj.__wait4ElementVisible(pcommon_publish._txtToastOutletMsg, '_txtToastOutletMsg');
//         expect(pcommon_publish._txtToastOutletMsg.getText()).toBe(td_EventDetails.SuccessMsg);
//
//         fcommon_obj.__executeScript(pcommon_publish._btnToastOutletMsg_close, '_btnToastOutletMsg_close', "click");
//
//     });
//
//     it('WHEN User login as: ' + td_EventDetails.User, function () {
//         fcommon_test.__GivenTheUserHasLoginSRC(td_EventDetails.User);
//     });
//
//     it('AND User goes to Posts menu under Person settings', function () {
//         pcommon_page.__gotoPersonIcon_Menu('Posts');
//     });
//
//     it('AND User selects event from Select Content Type dropdown', function () {
//         puserArticleList_page.__selectedContentType('event');
//     });
//
//     it('THEN The expected posts displays on the page: ' + td_EventDetails.EventName, function () {
//         puserArticleList_page.__verifyPostsExist(td_EventDetails.EventName);
//     });
//
//     it('WHEN User clicks on the Posts: ' + td_EventDetails.EventName, function () {
//         puserArticleList_page.__selectPosts(td_EventDetails.EventName);
//     });
//
//     it('THEN User Publish Your Event Screen displays', function () {
//         expect(pcommon_publish._txtHeader.getText()).toBe('Publish Your Event');
//     });
//
//     it('WHEN User expands the Featured Image', function () {
//         fcommon_obj.__executeScript(pcommon_publish._txtFeaturedImage, '_txtFeaturedImage', "click");
//         browser.sleep(browser.params.userSleep.short);
//     });
//
//     it('THEN the Uploaded Image is displayed', function () {
//         expect(pcommon_publish._zoneFeaturedImage_uploadedImg.isDisplayed()).toBe(true);
//     });
//
//     it('AND Remove Image button is displayed and eanabled', function () {
//         expect(pcommon_publish._zoneFeaturedImage_delete.isDisplayed()).toBe(true);
//         expect(pcommon_publish._zoneFeaturedImage_delete.isEnabled()).toBe(true);
//     });
//
//
// });




let td_EventDetails_published = {
    "User": browser.params.login.login_globAdmin,
    // "User": browser.params.login.login_compAdmin,
    // "User": browser.params.login.login_compAuthor,

    // "EventName":    '0_AutoEvent_20200730_212629',
    "EventName":     fcommon_test.__GenerateRandomString('0_AutoEvent_'),
    // "EventName":    '0_AutoEvent_' + futil_timer.__returnYYYYMMDDHMS(),
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

fcommon_test.__GivenUserSubmitAnEvent(td_EventDetails_published);

// describe('Verify Featured Image of Moderated Event in Admin', function () {
//
//
//     it('WHEN User login as: ' + td_EventDetails_published.User, function () {
//         fcommon_test.__GivenTheUserHasLoginSRC(td_EventDetails_published.User);
//     });
//
//     it('User goes to Setting -> : Moderate Content', function () {
//         pcommon_page.__gotoSetting('Moderate Content');
//     });
//
//     it('User searches the item to be Approved: ' + td_EventDetails_published.EventName, function () {
//         pcontentList.__doSearch('Waiting for approval', 'event', td_EventDetails_published.EventName, true);
//     });
//
//     it('THEN Moderate Event Screen displays', function () {
//         fcommon_obj.__wait4ElementVisible(pcommon_moderate._txtHeader, 'pcommon_moderate._txtTitle');
//         expect(pcommon_moderate._txtHeader.getText()).toBe('Moderate event');
//         expect(pcommon_publish._txtTitle.getAttribute('value')).toBe(td_EventDetails_published.EventName);
//     });
//
//     it('THEN the Uploaded Image is displayed', function () {
//         expect(pcommon_moderate._zoneFeaturedImage_uploadedImg.isDisplayed()).toBe(true);
//     });
//
//     it('AND Remove Image button is displayed and eanabled', function () {
//         expect(pcommon_moderate._zoneFeaturedImage_delete.isDisplayed()).toBe(true);
//         expect(pcommon_moderate._zoneFeaturedImage_delete.isEnabled()).toBe(true);
//     });
//
//
//
// });
//
// describe('Verify Remove Featured Image of Moderated Event in Admin', function () {
//
//
//     it('GIVEN User : ' + td_EventDetails_published.User + ' is on Moderate Event screen', function () {
//         fcommon_test.__passTestAsNotATest('following previous scenario');
//     });
//
//     it('WHEN User clicks on Remove Image button', function () {
//         fcommon_obj.__executeScript(pcommon_moderate._zoneFeaturedImage_delete, '_zoneFeaturedImage_delete', "click");
//         browser.sleep(browser.params.userSleep.short);
//     });
//
//
//     it('THEN the Uploaded Image is deleted', function () {
//         expect(pcommon_moderate._zoneFeaturedImage_uploadedImg.isPresent()).toBe(false);
//     });
//
//     it('AND Remove Image button is not displayed', function () {
//         expect(pcommon_moderate._zoneFeaturedImage_delete.isPresent()).toBe(false);
//     });
//
//     it('AND User clicks on Save', function () {
//         fcommon_obj.__executeScript(pcommon_moderate._btnSave, '_btnSave', "click");
//         fcommon_obj.__wait4ElementVisible(pcommon_publish._txtToastOutletMsg, '_txtToastOutletMsg');
//     });
//
//     it('User goes to Setting -> : Moderate Content', function () {
//         pcommon_page.__gotoSetting('Moderate Content');
//     });
//
//     it('User searches the item to be Approved: ' + td_EventDetails_published.EventName, function () {
//         pcontentList.__doSearch('Waiting for approval', 'event', td_EventDetails_published.EventName, true);
//     });
//
//     it('THEN Moderate Event Screen displays', function () {
//         fcommon_obj.__wait4ElementVisible(pcommon_moderate._txtHeader, 'pcommon_moderate._txtTitle');
//         expect(pcommon_moderate._txtHeader.getText()).toBe('Moderate event');
//         expect(pcommon_publish._txtTitle.getAttribute('value')).toBe(td_EventDetails_published.EventName);
//     });
//
//     it('THEN the Uploaded Image is deleted', function () {
//         expect(pcommon_moderate._zoneFeaturedImage_uploadedImg.isPresent()).toBe(false);
//     });
//
//     it('AND Remove Image button is not displayed', function () {
//         expect(pcommon_moderate._zoneFeaturedImage_delete.isPresent()).toBe(false);
//     });
//
//
// });
//
// describe('Verify Upload Featured Image of Moderated Event in Admin', function () {
//
//
//     it('GIVEN User : ' + td_EventDetails_published.User + ' is on Moderate Event screen', function () {
//         fcommon_test.__passTestAsNotATest('following previous scenario');
//     });
//
//     it('AND Remove Image button is not displayed', function () {
//         expect(pcommon_moderate._zoneFeaturedImage_delete.isPresent()).toBe(false);
//         fcommon_obj.__click('_zoneFeaturedImage_clickable', pcommon_publish._zoneFeaturedImage_clickable);
//     });
//
//     it('WHEN User uploads Featured Image: ' + td_EventDetails_published.Upload_FeaturedImage, function () {
//         pcommon_publish.__OpenFile(td_EventDetails_published.Upload_FeaturedImage);
//         // browser.sleep(browser.params.userSleep.short);
//     });
//
//     it('THEN the Uploaded Image is displayed', function () {
//         fcommon_obj.__wait4ElementVisible(pcommon_moderate._zoneFeaturedImage_uploadedImg, '_zoneFeaturedImage_uploadedImg');
//         expect(pcommon_moderate._zoneFeaturedImage_uploadedImg.isDisplayed()).toBe(true);
//     });
//
//     it('AND Remove Image button is displayed', function () {
//         fcommon_obj.__wait4ElementVisible(pcommon_moderate._zoneFeaturedImage_delete, '_zoneFeaturedImage_delete');
//         expect(pcommon_moderate._zoneFeaturedImage_delete.isDisplayed()).toBe(true);
//     });
//
//
//     it('AND User clicks on Save', function () {
//         fcommon_obj.__executeScript(pcommon_moderate._btnSave, '_btnSave', "click");
//         fcommon_obj.__wait4ElementVisible(pcommon_publish._txtToastOutletMsg, '_txtToastOutletMsg');
//     });
//
//     it('User goes to Setting -> : Moderate Content', function () {
//         pcommon_page.__gotoSetting('Moderate Content');
//     });
//
//     it('User searches the item to be Approved: ' + td_EventDetails_published.EventName, function () {
//         pcontentList.__doSearch('Waiting for approval', 'event', td_EventDetails_published.EventName, true);
//     });
//
//     it('THEN Moderate Event Screen displays', function () {
//         fcommon_obj.__wait4ElementVisible(pcommon_moderate._txtHeader, 'pcommon_moderate._txtTitle');
//         expect(pcommon_moderate._txtHeader.getText()).toBe('Moderate event');
//         expect(pcommon_publish._txtTitle.getAttribute('value')).toBe(td_EventDetails_published.EventName);
//     });
//
//     it('THEN the Uploaded Image is displayed', function () {
//         expect(pcommon_moderate._zoneFeaturedImage_uploadedImg.isDisplayed()).toBe(true);
//     });
//
//     it('AND Remove Image button is displayed', function () {
//         fcommon_obj.__wait4ElementVisible(pcommon_moderate._zoneFeaturedImage_delete, '_zoneFeaturedImage_delete');
//         expect(pcommon_moderate._zoneFeaturedImage_delete.isDisplayed()).toBe(true);
//     });
//
//
// });

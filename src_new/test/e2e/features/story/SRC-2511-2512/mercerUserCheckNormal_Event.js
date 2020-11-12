/**
 * Created by lin-li on 8/14/2020.
 */

"use strict";

let fs = require('fs');
let ec = protractor.ExpectedConditions;
const dateformat = require('dateformat');
const path = require('path');
let util_windows = require('../../../common/utilities/util_windows');
let futil_windows = new util_windows();
let util_timer = require('../../../common/utilities/util_timer');
let futil_timer = new util_timer();
let util_xlsx = require('../../../common/utilities/util_xlsx');
let futil_xlsx = new util_xlsx();
let common_obj = require('../../../common/common_obj');
let fcommon_obj = new common_obj();
let common_page = require('../../../page-objects/common_page');
let pcommon_page = new common_page();
let common_test = require('../../common_test/common_test');
let fcommon_test = new common_test();

let strapi_page = require('../../../page-objects/strapi');
let pstrapi_page = new strapi_page();
let login_page = require('../../../page-objects/login');
let plogin_page = new login_page();
let onboarding_page = require('../../../page-objects/onboarding');
let ponboarding_page = new onboarding_page();
let dashboard_page = require('../../../page-objects/dashboard');
let pdashboard_page = new dashboard_page();
let research_page = require('../../../page-objects/research');
let presearch_page = new research_page();
let news_page = require('../../../page-objects/news');
let pnews_page = new news_page();
let news_details_page = require('../../../page-objects/news_details');
let pnews_details_page = new news_details_page();
let event_details_page = require('../../../page-objects/event_details');
let pevent_details_page = new event_details_page();

let common_publish = require('../../../page-objects/common_publish');
let pcommon_publish = new common_publish();
let common_moderate = require('../../../page-objects/common_moderate');
let pcommon_moderate = new common_moderate();
let userArticleList_page = require('../../../page-objects/userArticleList');
let puserArticleList_page = new userArticleList_page();
let contentList = require('../../../page-objects/contentList');
let pcontentList = new contentList();

// beforeAll(function () {
//     fcommon_obj.__log('------------ before all');

// });
// afterAll(function () {
//     fcommon_obj.__log('------------ after all');
// });


let td_user = {
    "userEmail": browser.params.login.login_Mercer_userEmail,
    "userID": browser.params.login.login_Mercer_userID,
    "userPassword": browser.params.login.login_Mercer_userPassword,
}

let td_uploadFile = {

    "Excel": path.resolve(browser.params.uploadFile.excel),
    "PPT": path.resolve(browser.params.uploadFile.ppt),
    "PDF": path.resolve(browser.params.uploadFile.pdf),
    "Word": path.resolve(browser.params.uploadFile.word),
    "CSV": path.resolve(browser.params.uploadFile.csv),

    "Excel_Name": browser.params.uploadFile.excel_name,
    "PPT_Name": browser.params.uploadFile.ppt_name,
    "PDF_Name": browser.params.uploadFile.pdf_name,
    "Word_Name": browser.params.uploadFile.word_name,
    "CSV_Name": browser.params.uploadFile.csv_name,

}

let Upload_Attachemnts = '../data/in/\"\"' + td_uploadFile.Word_Name + '\"\" \"\"' + td_uploadFile.PDF_Name + '\"\" \"\"' + td_uploadFile.PPT_Name + '\"\" \"\"' + td_uploadFile.Excel_Name + '\"\" \"\"' + td_uploadFile.CSV_Name + '\"\"'


let td_article = {
    "research": 'Research/WhitePaper',
    "news": 'News/Blog',
}

let td_posts = {
    "research": 'research post',
    "news": 'news post',
    "event": 'event',
}

let td_moderate_status = {
    "ApprovalPending": 'Waiting for approval',
}

let td_content = {

    "Company_new": 'CompAuto',
    "ArticleType": 'Event',
    "PostsType": td_posts.event,

    "InternalOnly": false,

    "Title": '2512_AutoEvent_intNormal_' + futil_timer.__returnYYYYMMDDHMS(),
    "ExecutiveSummary": 'This is ExecutiveSummary: ' + futil_timer.__returnYYYYMMDDHMS(),
    "URL": 'https://colleagueconnect.mmc.com/en-us/Pages/HomePage.aspx',
    "Content": 'This is Event Content: ' + futil_timer.__returnYYYYMMDDHMS(),

    "StartDate": new Date(),
    "StartTime": '11:00 PM',
    "EndDate": new Date(),
    "EndTime": '11:00 PM',

    "Company": 'Mercer',
    "Type": 'Training',
    "Location": 'Shanghai, Chin',
    "sLocation": 'Shanghai, China',
    "Taxonomy": 'Broad Equity',
    "Tag": 'Technology',
    "NumOfMins": '8',
    "VideoLink": 'https://www.youtube.com/watch?v=haSX6qLGA3w',
    "Region": pcommon_publish._chkRegion_AllRegions, // hard coded in scripts
    // "Audience": 'Asset Manager', // hard coded in scripts
    "Author": 'webber.ling@mercer.com',

    // "Upload_FeaturedImage": path.resolve(browser.params.uploadImage.jpg),
    // "Upload_Attachemnts": '../data/in/\"\"Test_PDF.pdf\"\" \"\"Test_Word.docx\"\" \"\"Test_Excel.xls\"\" \"\"Test_PPT.pptx\"\""',
    // "Upload_Attachemnts": td_uploadFile.PDF,
    // "Upload_Attachemnts_Name": td_uploadFile.PDF_Name,

    "Event_Submit_SuccessMsg": 'Thank you for your event submission. Please note that all submissions are sent to moderation for admin approval. You will be notified when your submission is approved.',

    "InternalOnly_Warning": 'Internal Use Only: This document is intended for internal use only and may not be distributed externally.',
};

let popularArticle_content = {

    "title": 'Event_intNormal_notRemove_2512',

}

let txtInternalOnlyTag = 'Internal-Only'

// it('WHEN: Mercer User login as: ' + td_user.userEmail, function () {
//     fcommon_test.__GivenMercerUserLoginSRC(td_user.userEmail, td_user.userID, td_user.userPassword)
// })

describe('Verify Mercer Admin check normal ' + td_content.ArticleType, function () {

    describe('Verify Mercer Admin check normal ' + td_content.ArticleType + ' on ' + td_content.ArticleType + ' page', function () {

        it('WHEN: I see the normal ' + td_content.ArticleType + ' in ' + td_content.ArticleType + ' page: ' + td_content.Title, function () {
            fcommon_test.__SubmitAndApprovedAnArticle(td_content)
            pcommon_page.__selectMenu(td_content.ArticleType)
            pcommon_page.__searchAndVerifyExist(td_content.Title, true, false)
        })

        it('THEN: I see the normal ' + td_content.ArticleType + ' card without a tag "Internal-Only"', function () {
            fcommon_test.__checkElement_isDisplayed(pcommon_page._tagInternalOnly_inArticleCard(td_content.Title), false)
        })

        it('AND: I see the normal ' + td_content.ArticleType + ' card without a blue background color', function () {
            fcommon_test.__checkNormalArticle_backGroundColor(pcommon_page._cardArticle(td_content.Title))
        })

    })

    describe('Verify Mercer Admin check popular normal ' + td_content.ArticleType + ' on ' + td_content.ArticleType + ' page', function () {

        it('AND: I see the popular internal only ' + td_content.ArticleType + ' card is displayed: ' + popularArticle_content.title, function () {
            fcommon_test.__checkElement_isDisplayed(pcommon_page._cardPopularArticle(popularArticle_content.title), true)
        })

        it('AND: I see the popular internal only ' + td_content.ArticleType + ' card with a blue background color', function () {
            fcommon_test.__checkNormalPopularArticle_backGroundColor(pcommon_page._cardPopularArticle(popularArticle_content.title))
        })

    })

    describe('Verify Mercer Admin check normal ' + td_content.ArticleType + ' on ' + td_content.ArticleType + ' details page', function () {

        it('WHEN: I see normal ' + td_content.ArticleType + ' card opened', function () {
            fcommon_test.__clickArticleTitle(td_content.Title)
        })

        it('THEN: I see the alert card not display', function () {
            fcommon_test.__checkElement_isDisplayed(pcommon_page._cardInternalOnlyWarning, false)
        })

        it('AND: I see the normal ' + td_content.ArticleType + ' has not a tag ' + txtInternalOnlyTag, function () {
            fcommon_test.__checkElement_isDisplayed(pevent_details_page._tag_detailsPage(txtInternalOnlyTag), false)
        })

    })

})
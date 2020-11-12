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
    "compAuthor": browser.params.login.login_compAuthor,
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
    "event": 'Event'
}

let td_posts = {
    "research": 'research post',
    "news": 'news post',
    "event": 'event'
}


let td_content = {

    "ArticleType": 'Event',
    "PostsType": td_posts.event,

    "Title": '2513_AutoEvent_External_' + futil_timer.__returnYYYYMMDDHMS(),
    "ExecutiveSummary": 'This is ExecutiveSummary: ' + futil_timer.__returnYYYYMMDDHMS(),
    "URL": 'https://colleagueconnect.mmc.com/en-us/Pages/HomePage.aspx',
    "Content": 'This is Event Content: ' + futil_timer.__returnYYYYMMDDHMS(),

    "StartDate": new Date(),
    "StartTime": '11:00 PM',
    "EndDate": new Date(),
    "EndTime": '11:00 PM',

    "Company": 'CompAuto',
    "Type": 'Training',
    "Location": 'Shanghai, Chin',
    "sLocation": 'Shanghai, China',
    "Taxonomy": 'Broad Equity',
    "Tag": 'Technology',
    "NumOfMins": '8',
    "VideoLink": 'https://www.youtube.com/watch?v=haSX6qLGA3w',
    "Region": pcommon_publish._chkRegion_AllRegions, // hard coded in scripts
    "Audience": pcommon_publish._chkAudience_AssetManager, // hard coded in scripts
    "Author": 'webber.ling@mercer.com',

    // "Upload_FeaturedImage": path.resolve(browser.params.uploadImage.jpg),
    // "Upload_Attachemnts": '../data/in/\"\"Test_PDF.pdf\"\" \"\"Test_Word.docx\"\" \"\"Test_Excel.xls\"\" \"\"Test_PPT.pptx\"\""',

    "Event_Save_SuccessMsg": 'Your event has been saved.'
};


describe('Verify External User check Internal Only - publish Event page', function () {

    it('WHEN: External User login as: ' + td_user.compAuthor, function () {
        fcommon_test.__GivenTheUserHasLoginSRC(td_user.compAuthor)
    })

    it('AND: I see the publish Event page opened', function () {
        pcommon_publish.__Publish(td_article.event);
    })

    it('THEN: I see the Internal only toggle not display', function () {
        fcommon_test.__checkElement_isDisplayed(pcommon_publish._toggleInternalOnly, false)
    })

    it('AND: I see the Company field is disabled', function () {
        fcommon_test.__checkElement_isEnabled(pcommon_publish._txtCompany, false)
    })

    it('AND: I see the Company is ' + td_content.Company, function () {
        fcommon_test.__checkElement_textValue(pcommon_publish._txtCompany, td_content.Company)
    })

    it('AND: I see all the Audience are enabled', function () {
        fcommon_obj.__executeScript(pcommon_publish._txtAudience, '_txtAudience', "click");
        fcommon_test.__checkElement_isEnabled(pcommon_publish._chkAudience_AssetManager, true)
        fcommon_test.__checkElement_isEnabled(pcommon_publish._chkAudience_AssetOwner, true)
        fcommon_test.__checkElement_isEnabled(pcommon_publish._chkAudience_MercerConsultant, true)
        fcommon_test.__checkElement_isEnabled(pcommon_publish._chkAudience_ExternalConsultant, true)
        fcommon_test.__checkElement_isEnabled(pcommon_publish._chkAudience_IndustryVendor, true)
    })

    it('AND: I see all the Audience are not selected', function () {
        fcommon_test.__checkElement_isSelected(pcommon_publish._chkAudience_AssetManager, false)
        fcommon_test.__checkElement_isSelected(pcommon_publish._chkAudience_AssetOwner, false)
        fcommon_test.__checkElement_isSelected(pcommon_publish._chkAudience_MercerConsultant, false)
        fcommon_test.__checkElement_isSelected(pcommon_publish._chkAudience_ExternalConsultant, false)
        fcommon_test.__checkElement_isSelected(pcommon_publish._chkAudience_IndustryVendor, false)
    })

    it('AND: I see the other fields are empty', function () {
        fcommon_test.__checkElement_textValue(pcommon_publish._txtTitle, '')
        fcommon_test.__checkElement_textValue(pcommon_publish._txtEventExcerpt, '')
        fcommon_test.__checkElement_textValue(pcommon_publish._txtURLLink, '')
        fcommon_test.__checkElement_getText(pcommon_publish._txtEventContent, '')
        fcommon_test.__checkElement_getText(pcommon_publish._txtStartDate, 'MM/DD/YYYY')
        fcommon_test.__checkElement_getText(pcommon_publish._txtEndDate, 'MM/DD/YYYY')
        fcommon_test.__checkElement_getText(pcommon_publish._txtStartTime, '')
        fcommon_test.__checkElement_getText(pcommon_publish._txtEndTime, '')
        fcommon_test.__checkElement_textValue(pcommon_publish._lstEventType, '')
        fcommon_test.__checkElement_getText(pcommon_publish._txtLocation, '')

        fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_AllRegions, true)
        fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_Canada, true)
        fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_Asia, true)
        fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_EMEA, true)
        fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_AustraliaNZ, true)
        fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_Japan, true)
        fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_UK, true)
        fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_US, true)

        fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_AllRegions, false)
        fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_Canada, false)
        fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_Asia, false)
        fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_EMEA, false)
        fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_AustraliaNZ, false)
        fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_Japan, false)
        fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_UK, false)
        fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_US, false)

        pcommon_publish.__CancelWithoutChange()
    })

})

describe('Verify External User check Internal Only - draft Event page', function () {

    it('WHEN: I see a draft Event opened: ' + td_content.Title, function () {
        fcommon_test.__UserSaveAnArticleOnPublishPage(td_content)
        fcommon_test.__OpenPostsArticle(td_content)
    })

    it('THEN: I see the Internal only toggle not display', function () {
        fcommon_test.__checkElement_isDisplayed(pcommon_publish._toggleInternalOnly, false)
    })

    it('AND: I see the Company field is disabled', function () {
        fcommon_test.__checkElement_isEnabled(pcommon_publish._txtCompany, false)
    })

    it('AND: I see the Company is ' + td_content.Company, function () {
        fcommon_test.__checkElement_textValue(pcommon_publish._txtCompany, td_content.Company)
    })

})


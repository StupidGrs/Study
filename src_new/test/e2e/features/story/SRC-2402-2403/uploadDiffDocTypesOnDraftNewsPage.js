/**
 * Created by lin-li on 8/12/2020.
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

beforeAll(function () {
    fcommon_obj.__log('------------ before all');

});
afterAll(function () {
    fcommon_obj.__log('------------ after all');
});


let td_user = {
    "compAuthor": browser.params.login.login_compAuthor,
    "globalAdmin": browser.params.login.login_globAdmin,
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
}


let td_content = {

    "Title": '0_AutoNews_Draft_' + futil_timer.__returnYYYYMMDDHMS(),
    "ExecutiveSummary": 'This is ExecutiveSummary: ' + futil_timer.__returnYYYYMMDDHMS(),
    "URL": 'https://colleagueconnect.mmc.com/en-us/Pages/HomePage.aspx',
    "Content": 'This is News Content: ' + futil_timer.__returnYYYYMMDDHMS(),

    // "Company": 'CompAuto',
    "Type": 'House View',
    "Location": 'Shanghai, Chin',
    "Taxonomy": 'Broad Equity',

    "Save_SuccessMsg": 'Your news has been saved.',
    "Submit_SuccessMsg": 'Thank you for your news article submission. Please note that all submissions are sent to moderation for admin approval. You will be notified when your submission is approved.',
    
};

describe('Verify SRC publisher check file upload with different document types on Posts - News draft page', function () {

    it('WHEN User login as: ' + td_user.compAuthor, function () {
        fcommon_test.__GivenTheUserHasLoginSRC(td_user.compAuthor)
    })

    it('AND I create a News draft - ' + td_content.Title, function () {
        fcommon_test.__UserSaveAnArticleOnPublishPageWithMandatoryFields(td_content, false)
    })

    it('AND I see Posts - News draft opened', function () {
        pcommon_page.__gotoPersonIcon_Menu('Posts');
        puserArticleList_page.__selectedContentType(td_posts.news);
        puserArticleList_page.__verifyPostsExist(td_content.Title);
        puserArticleList_page.__selectPosts(td_content.Title);
    })

    it('AND I see a file upload dropzone', function () {
        fcommon_test.__checkElement_isDisplayed(pcommon_publish._zoneUploadAttachment_clickable, true)
        fcommon_test.__checkElement_getText(pcommon_publish._zoneUploadAttachment_block_name, "Upload Attachments")
    })

    it('AND I click Uploads Attachemts dropzone', function () {
        fcommon_obj.__click('_zoneUploadAttachment_clickable', pcommon_publish._zoneUploadAttachment_clickable);
    })

    it('AND I upload ' + td_uploadFile.PDF_Name + ', ' + td_uploadFile.PPT_Name + ', ' + td_uploadFile.Excel_Name + ' to dropzone', function () {
        pcommon_publish.__OpenFile(Upload_Attachemnts)
    })

    it('AND I See ' + td_uploadFile.Word_Name + ', ' + td_uploadFile.PDF_Name + ', ' + td_uploadFile.PPT_Name + ', ' + td_uploadFile.Excel_Name + ', ' + td_uploadFile.CSV_Name + ' uploaded successfully', function () {
        pcommon_publish.__wait4UploadAttachment(td_uploadFile.PDF_Name)
        pcommon_publish.__wait4UploadAttachment(td_uploadFile.PPT_Name)
        pcommon_publish.__wait4UploadAttachment(td_uploadFile.Excel_Name)
        pcommon_publish.__wait4UploadAttachment(td_uploadFile.Word_Name)
        pcommon_publish.__wait4UploadAttachment(td_uploadFile.CSV_Name)
    })

    it('AND I remove ' + td_uploadFile.Word_Name + ', ' + td_uploadFile.PDF_Name + ', ' + td_uploadFile.PPT_Name + ', ' + td_uploadFile.Excel_Name + ', ' + td_uploadFile.CSV_Name + ' successfully', function () {
        pcommon_publish.__zoneUploadAttachment_block_footer_fileRemove(td_uploadFile.PDF_Name)
        pcommon_publish.__zoneUploadAttachment_block_footer_fileRemove(td_uploadFile.PPT_Name)
        pcommon_publish.__zoneUploadAttachment_block_footer_fileRemove(td_uploadFile.Excel_Name)
        pcommon_publish.__zoneUploadAttachment_block_footer_fileRemove(td_uploadFile.Word_Name)
        pcommon_publish.__zoneUploadAttachment_block_footer_fileRemove(td_uploadFile.CSV_Name)
    })

})
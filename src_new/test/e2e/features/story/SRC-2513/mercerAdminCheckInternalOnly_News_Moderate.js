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

let td_moderate_status = {
    "ApprovalPending": 'Waiting for approval',
}

let td_content_moderate = {

    "Company_new": 'CompAuto',
    "ArticleType": 'News',
    "PostsType": td_posts.news,

    "InternalOnly": false,

    "Title": '2513_AutoNews_moderate_' + futil_timer.__returnYYYYMMDDHMS(),
    "ExecutiveSummary": 'This is ExecutiveSummary: ' + futil_timer.__returnYYYYMMDDHMS(),
    "URL": 'https://colleagueconnect.mmc.com/en-us/Pages/HomePage.aspx',
    "Content": 'This is News Content: ' + futil_timer.__returnYYYYMMDDHMS(),

    "CurrentDate": new Date(),

    "Company": 'Mercer',
    "Type": 'House View',
    "Location": 'Shanghai, China',
    "Taxonomy": 'Broad Equity',
    "Tag": 'Technology',
    "NumOfMins": '8',
    "VideoLink": 'https://www.youtube.com/watch?v=haSX6qLGA3w',
    "Region": pcommon_publish._chkRegion_AllRegions, // hard coded in scripts
    // "Audience": 'Asset Manager', // hard coded in scripts
    "Author": 'webber.ling@mercer.com',

    // "Upload_FeaturedImage": path.resolve(browser.params.uploadImage.jpg),
    // "Upload_Attachemnts": '../data/in/\"\"Test_PDF.pdf\"\" \"\"Test_Word.docx\"\" \"\"Test_Excel.xls\"\" \"\"Test_PPT.pptx\"\""',
    "Upload_Attachemnts": td_uploadFile.PDF,
    "Upload_Attachemnts_Name": td_uploadFile.PDF_Name,

    "News_Submit_SuccessMsg": 'Thank you for your news article submission. Please note that all submissions are sent to moderation for admin approval. You will be notified when your submission is approved.',

    "Moderate_Status": td_moderate_status.ApprovalPending,
};


// it('BACKGROUND: Mercer User login as: ' + td_user.userEmail, function () {
//     fcommon_test.__GivenMercerUserLoginSRC(td_user.userEmail, td_user.userID, td_user.userPassword)
// })



describe('Verify Mercer Admin check Internal Only - moderate News page', function () {

    it('WHEN: I see the moderate News page opened: ' + td_content_moderate.Title, function () {
        fcommon_test.__UserSubmitAnArticleOnPublishPage(td_content_moderate)
        fcommon_test.__OpenModerateArticle(td_content_moderate)
        // fcommon_test.__UserSubmitAnArticleOnPublishPageWithMandatoryFields(td_content_moderate, false)
        // pcommon_page.__gotoSetting('Moderate Content')
        // pcontentList.__doSearch('Waiting for approval', td_posts.news, td_content_moderate.Title, true)
    })


    it('THEN: I see the Internal only toggle display', function () {
        fcommon_test.__checkElement_isDisplayed(pcommon_moderate._toggleInternalOnly)
    })

    it('AND: I see the Internal only toggle is "Content is Mercer-only/Private"', function () {
        expect(pcommon_moderate._toggleInternalOnly.getText()).toEqual('Content is Mercer-only/Private')
    })

    it('AND: I see the Internal only toggle is default to false', function () {
        fcommon_test.__checkElement_isSelected(pcommon_moderate._toggleInternalOnly_setting, false)
    })

    it('AND: I see the Company field is enabled', function () {
        fcommon_test.__checkElement_isEnabled(pcommon_moderate._txtCompany, true)
    })

    it('AND: I see the Company is ' + td_content_moderate.Company, function () {
        fcommon_test.__checkElement_textValue(pcommon_moderate._txtCompany, td_content_moderate.Company)
    })

    // it('AND: I see all the Audience are enabled', function () {
    //     fcommon_test.__checkElement_isEnabled(pcommon_moderate._chkAudience_AssetManager, true)
    //     fcommon_test.__checkElement_isEnabled(pcommon_moderate._chkAudience_AssetOwner, true)
    //     fcommon_test.__checkElement_isEnabled(pcommon_moderate._chkAudience_MercerConsultant, true)
    //     fcommon_test.__checkElement_isEnabled(pcommon_moderate._chkAudience_ExternalConsultant, true)
    //     fcommon_test.__checkElement_isEnabled(pcommon_moderate._chkAudience_IndustryVendor, true)
    // })

    // it('AND: I see all the Audience are not selected', function () {
    //     fcommon_test.__checkElement_isSelected(pcommon_moderate._chkAudience_AssetManager, false)
    //     fcommon_test.__checkElement_isSelected(pcommon_moderate._chkAudience_AssetOwner, false)
    //     fcommon_test.__checkElement_isSelected(pcommon_moderate._chkAudience_MercerConsultant, false)
    //     fcommon_test.__checkElement_isSelected(pcommon_moderate._chkAudience_ExternalConsultant, false)
    //     fcommon_test.__checkElement_isSelected(pcommon_moderate._chkAudience_IndustryVendor, false)
    // })



    it('WHEN: I set the Toggle to true', function () {
        pcommon_moderate.__setInternalOnlyToggle(true)
    })

    it('THEN: I see the Company field is disabled', function () {
        fcommon_test.__checkElement_isEnabled(pcommon_moderate._txtCompany, false)
    })

    it('AND: I see the Company is ' + td_content_moderate.Company, function () {
        fcommon_test.__checkElement_textValue(pcommon_moderate._txtCompany, td_content_moderate.Company)
    })

    it('AND: I see the "Internal-Only" tag display', function () {
        expect(pcommon_moderate._tagInternalOnly.isDisplayed()).toBe(true)
    })

    // it('AND: I see all the Audience are disabled', function () {
    //     fcommon_test.__checkElement_isEnabled(pcommon_moderate._chkAudience_AssetManager, false)
    //     fcommon_test.__checkElement_isEnabled(pcommon_moderate._chkAudience_AssetOwner, false)
    //     fcommon_test.__checkElement_isEnabled(pcommon_moderate._chkAudience_MercerConsultant, false)
    //     fcommon_test.__checkElement_isEnabled(pcommon_moderate._chkAudience_ExternalConsultant, false)
    //     fcommon_test.__checkElement_isEnabled(pcommon_moderate._chkAudience_IndustryVendor, false)
    // })

    // it('AND: I see the "Mercer Consultant" are selected', function () {
    //     fcommon_test.__checkElement_isSelected(pcommon_moderate._chkAudience_MercerConsultant, true)
    // })

    // it('AND: I see the other Audience are not selected', function () {
    //     fcommon_test.__checkElement_isSelected(pcommon_moderate._chkAudience_AssetManager, false)
    //     fcommon_test.__checkElement_isSelected(pcommon_moderate._chkAudience_AssetOwner, false)
    //     fcommon_test.__checkElement_isSelected(pcommon_moderate._chkAudience_ExternalConsultant, false)
    //     fcommon_test.__checkElement_isSelected(pcommon_moderate._chkAudience_IndustryVendor, false)
    // })



    it('WHEN: I set the Toggle to false', function () {
        pcommon_publish.__setInternalOnlyToggle(false)
    })

    it('THEN: I see the Company field is enabled', function () {
        fcommon_test.__checkElement_isEnabled(pcommon_moderate._txtCompany, true)
    })

    it('AND: I see the Company is ' + td_content_moderate.Company, function () {
        fcommon_test.__checkElement_textValue(pcommon_moderate._txtCompany, td_content_moderate.Company)
    })

    it('AND: I see the "Internal-Only" tag disappear', function () {
        fcommon_test.__checkElement_isDisplayed(pcommon_moderate._tagInternalOnly, false)

        pcommon_moderate.__Cancel(true)
    })

    // it('AND: I see all the Audience are enabled', function () {
    //     fcommon_test.__checkElement_isEnabled(pcommon_moderate._chkAudience_AssetManager, true)
    //     fcommon_test.__checkElement_isEnabled(pcommon_moderate._chkAudience_AssetOwner, true)
    //     fcommon_test.__checkElement_isEnabled(pcommon_moderate._chkAudience_MercerConsultant, true)
    //     fcommon_test.__checkElement_isEnabled(pcommon_moderate._chkAudience_ExternalConsultant, true)
    //     fcommon_test.__checkElement_isEnabled(pcommon_moderate._chkAudience_IndustryVendor, true)
    // })

    // it('AND: I see all the Audience are not selected', function () {
    //     fcommon_test.__checkElement_isSelected(pcommon_moderate._chkAudience_AssetManager, false)
    //     fcommon_test.__checkElement_isSelected(pcommon_moderate._chkAudience_AssetOwner, false)
    //     fcommon_test.__checkElement_isSelected(pcommon_moderate._chkAudience_MercerConsultant, false)
    //     fcommon_test.__checkElement_isSelected(pcommon_moderate._chkAudience_ExternalConsultant, false)
    //     fcommon_test.__checkElement_isSelected(pcommon_moderate._chkAudience_IndustryVendor, false)

    //     pcommon_moderate.__Cancel(true)
    // })

})

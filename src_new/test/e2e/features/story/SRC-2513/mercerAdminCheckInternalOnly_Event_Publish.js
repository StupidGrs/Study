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
    "event": 'Event'
}

let td_posts = {
    "research": 'research post',
    "news": 'news post',
    "event": 'event'
}


let td_content = {

    "Company_new": 'CompAuto',
    "ArticleType": 'Event',

    "Title": '2513_AutoEvent_InternalOnly_' + futil_timer.__returnYYYYMMDDHMS(),
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
    "Audience": 'Asset Manager', // hard coded in scripts
    "Author": 'webber.ling@mercer.com',

    "Upload_FeaturedImage": path.resolve(browser.params.uploadImage.jpg),
    "Upload_Attachemnts": '../data/in/\"\"Test_PDF.pdf\"\" \"\"Test_Word.docx\"\" \"\"Test_Excel.xls\"\" \"\"Test_PPT.pptx\"\""',

    "SuccessMsg": 'Your event has been saved.',

    "Event_Submit_SuccessMsg": 'Thank you for your event submission. Please note that all submissions are sent to moderation for admin approval. You will be notified when your submission is approved.',
};




// it('BACKGROUND: Mercer User login as: ' + td_user.userEmail, function () {
//     fcommon_test.__GivenMercerUserLoginSRC(td_user.userEmail, td_user.userID, td_user.userPassword)
// })

describe('Verify Mercer Admin check Internal Only - publish Event page', function () {

    describe('Verify Mercer Admin check Internal Only - publish Event page - default page', function () {

        it('WHEN: I see the publish Event page opened', function () {
            pcommon_publish.__Publish(td_article.event);
        })

        it('THEN: I see the Internal only toggle display', function () {
            fcommon_test.__checkElement_isDisplayed(pcommon_publish._toggleInternalOnly)
        })

        it('AND: I see the Internal only toggle is "Content is Mercer-only/Private"', function () {
            expect(pcommon_publish._toggleInternalOnly.getText()).toEqual('Content is Mercer-only/Private')
        })

        it('AND: I see the Internal only toggle is default to false', function () {
            fcommon_test.__checkElement_isSelected(pcommon_publish._toggleInternalOnly_setting, false)
        })

        it('AND: I see the Company field is enabled', function () {
            fcommon_test.__checkElement_isEnabled(pcommon_publish._txtCompany, true)
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
            fcommon_test.__checkElement_isDisplayed(pcommon_publish._zoneFeaturedImage_delete, false)

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
        })

    })

    describe('Verify Mercer Admin check Internal Only - publish Event page - set Internal Only', function () {

        it('WHEN: I set the Toggle to true', function () {
            pcommon_publish.__setInternalOnlyToggle(true)
        })

        it('THEN: I see the Company field is disabled', function () {
            fcommon_test.__checkElement_isEnabled(pcommon_publish._txtCompany, false)
        })

        it('AND: I see the Company is ' + td_content.Company, function () {
            fcommon_test.__checkElement_textValue(pcommon_publish._txtCompany, td_content.Company)
        })

        it('AND: I see the "Internal-Only" tag display', function () {
            fcommon_test.__checkElement_isDisplayed(pcommon_publish._tagInternalOnly)
        })

        it('AND: I see all the Audience are disabled', function () {
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkAudience_AssetManager, false)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkAudience_AssetOwner, false)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkAudience_MercerConsultant, false)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkAudience_ExternalConsultant, false)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkAudience_IndustryVendor, false)
        })

        it('AND: I see the "Mercer Consultant" are selected', function () {
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkAudience_MercerConsultant, true)
        })

        it('AND: I see the other Audience are not selected', function () {
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkAudience_AssetManager, false)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkAudience_AssetOwner, false)
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
            fcommon_test.__checkElement_textValue(pcommon_publish._txtLocation, '')
            fcommon_test.__checkElement_isDisplayed(pcommon_publish._zoneFeaturedImage_delete, false)

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
        })

    })

    describe('Verify Mercer Admin check Internal Only - publish Event page - set back to no Internal Only', function () {

        it('WHEN: I set the Toggle to false', function () {
            pcommon_publish.__setInternalOnlyToggle(false)
        })

        it('THEN: I see the Company field is enabled', function () {
            fcommon_test.__checkElement_isEnabled(pcommon_publish._txtCompany, true)
        })

        it('AND: I see the Company is ' + td_content.Company, function () {
            fcommon_test.__checkElement_textValue(pcommon_publish._txtCompany, td_content.Company)
        })

        it('AND: I see the "Internal-Only" tag disappear', function () {
            fcommon_test.__checkElement_isDisplayed(pcommon_publish._tagInternalOnly, false)
        })

        it('AND: I see all the Audience are enabled', function () {
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
            fcommon_test.__checkElement_textValue(pcommon_publish._txtLocation, '')
            fcommon_test.__checkElement_isDisplayed(pcommon_publish._zoneFeaturedImage_delete, false)

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
        })

    })

    describe('Verify Mercer Admin check Internal Only - publish Event page - input some setting and set Internal Only', function () {

        it('WHEN: I change Company to ' + td_content.Company_new, function () {
            pcommon_publish.__setCompany(td_content.Company_new)
        })

        it('AND: I add Tag ' + td_content.Tag, function () {
            pcommon_publish.__setTag(td_content.Tag)
        })

        it('AND: I set all the Audience selected', function () {
            pcommon_publish.__setAudience(pcommon_publish._chkAudience_AssetManager, true)
            pcommon_publish.__setAudience(pcommon_publish._chkAudience_AssetOwner, true)
            pcommon_publish.__setAudience(pcommon_publish._chkAudience_MercerConsultant, true)
            pcommon_publish.__setAudience(pcommon_publish._chkAudience_ExternalConsultant, true)
            pcommon_publish.__setAudience(pcommon_publish._chkAudience_IndustryVendor, true)
        })

        it('AND: I set Audience - "Mercer Consultant" not selected', function () {
            pcommon_publish.__setAudience(pcommon_publish._chkAudience_MercerConsultant, false)
        })

        it('AND: I set other fields', function () {
            pcommon_publish.__setTitle(td_content.Title)
            pcommon_publish.__setExecutiveSummary(td_content.ExecutiveSummary)
            pcommon_publish.__setContentLink(td_content.URL)
            pcommon_publish.__setEventContent(td_content.Content)
            pcommon_publish.__setStartDate(td_content.StartDate)
            pcommon_publish.__setStartTime(td_content.StartTime)
            pcommon_publish.__setEndDate(td_content.EndDate)
            pcommon_publish.__setEndTime(td_content.EndTime)
            pcommon_publish.__setEventType(td_content.Type)
            pcommon_publish.__setLocation(td_content.Location)
            pcommon_publish.__setTaxonomies(td_content.Taxonomy)
            pcommon_publish.__insertFeaturedImage(td_content.Upload_FeaturedImage)
            pcommon_publish.__setRegions(td_content.Region, true)
        })

        it('AND: I set the Toggle to true', function () {
            pcommon_publish.__setInternalOnlyToggle(true)
        })

        it('THEN: I see the Company field is disabled', function () {
            fcommon_test.__checkElement_isEnabled(pcommon_publish._txtCompany, false)
        })

        it('AND: I see the Company is ' + td_content.Company, function () {
            fcommon_test.__checkElement_textValue(pcommon_publish._txtCompany, td_content.Company)
        })

        it('AND: I see the "Internal-Only" tag display', function () {
            expect(pcommon_publish._tagInternalOnly.isPresent()).toBe(true)
        })

        it('AND: I see all the Audience are disabled', function () {
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkAudience_AssetManager, false)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkAudience_AssetOwner, false)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkAudience_MercerConsultant, false)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkAudience_ExternalConsultant, false)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkAudience_IndustryVendor, false)
        })

        it('AND: I see the "Mercer Consultant" are selected', function () {
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkAudience_MercerConsultant, true)
        })

        it('AND: I see the other Audience are not selected', function () {
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkAudience_AssetManager, false)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkAudience_AssetOwner, false)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkAudience_ExternalConsultant, false)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkAudience_IndustryVendor, false)
        })

        it('AND: I see the other fields not affected', function () {
            fcommon_test.__checkElement_textValue(pcommon_publish._txtTitle, td_content.Title)
            fcommon_test.__checkElement_textValue(pcommon_publish._txtEventExcerpt, td_content.ExecutiveSummary)
            fcommon_test.__checkElement_textValue(pcommon_publish._txtURLLink, td_content.URL)
            fcommon_test.__checkElement_getText(pcommon_publish._txtEventContent, td_content.Content)
            fcommon_test.__checkElement_getText(pcommon_publish._txtStartDate, dateformat(td_content.StartDate, 'mm/dd/yyyy'))
            fcommon_test.__checkElement_textValue(pcommon_publish._txtStartTime, td_content.StartTime)
            fcommon_test.__checkElement_getText(pcommon_publish._txtEndDate, dateformat(td_content.EndDate, 'mm/dd/yyyy'))
            fcommon_test.__checkElement_textValue(pcommon_publish._txtEndTime, td_content.EndTime)
            fcommon_test.__checkElement_containValue(pcommon_publish._lstEventType, td_content.Type)
            fcommon_test.__checkElement_containValue(pcommon_publish._txtLocation, td_content.Location)
            fcommon_test.__checkElement_isDisplayed(pcommon_publish._zoneFeaturedImage_delete, true)

            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_AllRegions, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_Canada, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_Asia, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_EMEA, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_AustraliaNZ, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_Japan, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_UK, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_US, true)

            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_AllRegions, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_Canada, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_Asia, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_EMEA, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_AustraliaNZ, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_Japan, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_UK, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_US, true)

        })

    })

    describe('Verify Mercer Admin check Internal Only - publish Event page - set back to no Internal Only', function () {

        it('WHEN: I set the Toggle to false', function () {
            pcommon_publish.__setInternalOnlyToggle(false)
        })

        it('THEN: I see the Company field is enabled', function () {
            fcommon_test.__checkElement_isEnabled(pcommon_publish._txtCompany, true)
        })

        it('AND: I see the Company is ' + td_content.Company, function () {
            fcommon_test.__checkElement_textValue(pcommon_publish._txtCompany, td_content.Company)
        })

        it('AND: I see the "Internal-Only" tag disappear', function () {
            fcommon_test.__checkElement_isDisplayed(pcommon_publish._tagInternalOnly, false)
        })

        it('AND: I see all the Audience are enabled', function () {
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

        it('AND: I see the other fields not affected', function () {
            fcommon_test.__checkElement_textValue(pcommon_publish._txtTitle, td_content.Title)
            fcommon_test.__checkElement_textValue(pcommon_publish._txtEventExcerpt, td_content.ExecutiveSummary)
            fcommon_test.__checkElement_textValue(pcommon_publish._txtURLLink, td_content.URL)
            fcommon_test.__checkElement_getText(pcommon_publish._txtEventContent, td_content.Content)
            fcommon_test.__checkElement_getText(pcommon_publish._txtStartDate, dateformat(td_content.StartDate, 'mm/dd/yyyy'))
            fcommon_test.__checkElement_textValue(pcommon_publish._txtStartTime, td_content.StartTime)
            fcommon_test.__checkElement_getText(pcommon_publish._txtEndDate, dateformat(td_content.EndDate, 'mm/dd/yyyy'))
            fcommon_test.__checkElement_textValue(pcommon_publish._txtEndTime, td_content.EndTime)
            fcommon_test.__checkElement_containValue(pcommon_publish._lstEventType, td_content.Type)
            fcommon_test.__checkElement_containValue(pcommon_publish._txtLocation, td_content.Location)
            fcommon_test.__checkElement_isDisplayed(pcommon_publish._zoneFeaturedImage_delete, true)

            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_AllRegions, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_Canada, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_Asia, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_EMEA, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_AustraliaNZ, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_Japan, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_UK, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_US, true)

            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_AllRegions, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_Canada, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_Asia, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_EMEA, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_AustraliaNZ, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_Japan, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_UK, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_US, true)
        })

    })

    describe('Verify Mercer Admin check Internal Only - publish Event page - set Internal Only then Submit & Add Another Article', function () {

        it('WHEN: I set the Toggle to true', function () {
            pcommon_publish.__setInternalOnlyToggle(true)
        })

        it('THEN: I see the Company field is disabled', function () {
            fcommon_test.__checkElement_isEnabled(pcommon_publish._txtCompany, false)
        })

        it('AND: I see the Company is ' + td_content.Company, function () {
            fcommon_test.__checkElement_textValue(pcommon_publish._txtCompany, td_content.Company)
        })

        it('AND: I see the "Internal-Only" tag display', function () {
            expect(pcommon_publish._tagInternalOnly.isPresent()).toBe(true)
        })

        it('AND: I see all the Audience are disabled', function () {
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkAudience_AssetManager, false)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkAudience_AssetOwner, false)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkAudience_MercerConsultant, false)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkAudience_ExternalConsultant, false)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkAudience_IndustryVendor, false)
        })

        it('AND: I see the "Mercer Consultant" are selected', function () {
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkAudience_MercerConsultant, true)
        })

        it('AND: I see the other Audience are not selected', function () {
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkAudience_AssetManager, false)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkAudience_AssetOwner, false)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkAudience_ExternalConsultant, false)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkAudience_IndustryVendor, false)
        })

        it('AND: I see the other fields not affected', function () {
            fcommon_test.__checkElement_textValue(pcommon_publish._txtTitle, td_content.Title)
            fcommon_test.__checkElement_textValue(pcommon_publish._txtEventExcerpt, td_content.ExecutiveSummary)
            fcommon_test.__checkElement_textValue(pcommon_publish._txtURLLink, td_content.URL)
            fcommon_test.__checkElement_getText(pcommon_publish._txtEventContent, td_content.Content)
            fcommon_test.__checkElement_getText(pcommon_publish._txtStartDate, dateformat(td_content.StartDate, 'mm/dd/yyyy'))
            fcommon_test.__checkElement_textValue(pcommon_publish._txtStartTime, td_content.StartTime)
            fcommon_test.__checkElement_getText(pcommon_publish._txtEndDate, dateformat(td_content.EndDate, 'mm/dd/yyyy'))
            fcommon_test.__checkElement_textValue(pcommon_publish._txtEndTime, td_content.EndTime)
            fcommon_test.__checkElement_containValue(pcommon_publish._lstEventType, td_content.Type)
            fcommon_test.__checkElement_containValue(pcommon_publish._txtLocation, td_content.Location)
            fcommon_test.__checkElement_isDisplayed(pcommon_publish._zoneFeaturedImage_delete, true)

            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_AllRegions, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_Canada, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_Asia, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_EMEA, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_AustraliaNZ, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_Japan, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_UK, true)
            fcommon_test.__checkElement_isEnabled(pcommon_publish._chkRegion_US, true)

            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_AllRegions, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_Canada, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_Asia, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_EMEA, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_AustraliaNZ, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_Japan, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_UK, true)
            fcommon_test.__checkElement_isSelected(pcommon_publish._chkRegion_US, true)
        })

        it('WHEN: I Submit & Add Another', function () {
            fcommon_test.__SubmitAndAddAnotherArticle(td_content)
        })

        it('THEN: I see the Internal only toggle display', function () {
            fcommon_test.__checkElement_isDisplayed(pcommon_publish._toggleInternalOnly)
        })

        it('AND: I see the Internal only toggle is "Content is Mercer-only/Private"', function () {
            expect(pcommon_publish._toggleInternalOnly.getText()).toEqual('Content is Mercer-only/Private')
        })

        it('AND: I see the Internal only toggle is default to false', function () {
            fcommon_test.__checkElement_isSelected(pcommon_publish._toggleInternalOnly_setting, false)
        })

        it('AND: I see the Company field is enabled', function () {
            fcommon_test.__checkElement_isEnabled(pcommon_publish._txtCompany, true)
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
            fcommon_test.__checkElement_isDisplayed(pcommon_publish._zoneFeaturedImage_delete, false)

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

            pcommon_publish.__Cancel(false)
        })

    })

})


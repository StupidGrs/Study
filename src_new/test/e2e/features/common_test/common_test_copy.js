/**
 * Created by webber-ling on 7/10/2020.
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
let userArticleList_page = require('../../page-objects/userArticleList');
let puserArticleList_page = new userArticleList_page();
let contentList = require('../../page-objects/contentList');
let pcontentList = new contentList();


const common_test = function () {

    this.__failStubTest = function (text = 'write test') {
        // this test is designed always to fail - will be used to ensure all test stubs default to failure
        // this is only 1 line of code but it ensures all stub tests fail in the same way
        expect('1').toEqual(text);
    };

    this.__passTestAsNotATest = function (text = 'not a test so always passes') {
        // use this when tests can be passed as the phrase has already been effectively passed earlier in the script
        // this is only 1 line of code but it ensures all such tests pass in the same way

        expect(text).toEqual(text);
    };

    this.__checkElement_isDisplayed = (obj, bDisplayedTrue_NotDisplayedFalse = true) => {
        if (bDisplayedTrue_NotDisplayedFalse) {
            expect(obj.isDisplayed()).toBe(true)
        }
        else
            expect(obj.isPresent()).toBe(false)
    }

    this.__checkElement_isEnabled = (obj, bEnabledTrue_DisabledFalse) => {
        expect(obj.isEnabled()).toBe(bEnabledTrue_DisabledFalse)
    }

    this.__checkElement_isSelected = (obj, bSelectedTrue_NotSelectedFalse) => {
        expect(obj.isSelected()).toBe(bSelectedTrue_NotSelectedFalse)
    }

    this.__checkElement_textValue = (obj, text) => {
        expect(obj.getAttribute('value')).toEqual(text)
    }

    this.__checkElement_containValue = (obj, text) => {
        expect(obj.getAttribute('value')).toContain(text)
    }

    this.__checkElement_getText = (obj, text) => {
        expect(obj.getText()).toEqual(text)
    }

    this.__checkElement_containGetText = (obj, text) => {
        expect(obj.getText()).toContain(text)
    }

    this.__GivenMercerUserLoginSRC = (userEmail, userID, userPassword) => {

        plogin_page.__login_mercerUser(browser.params.url.url_test, browser.params.login.login_Mercer_userEmail, browser.params.login.login_Mercer_userID, browser.params.login.login_Mercer_userPassword)

        browser.getCurrentUrl().then(function (url) {

            fcommon_obj.__wait4ElementVisible(pdashboard_page._txtTrendingNewsAndBlogs, '_txtTrendingNewsAndBlogs');

            fcommon_obj.__log(url);

        });
    }


    let __GivenTheUserHasLoginSRC = function (userAccount) {


        browser.get(browser.params.url.url_test + '/v1/api/msso/dev/login/' + userAccount);

        browser.getCurrentUrl().then(function (url) {

            fcommon_obj.__wait4ElementVisible(pdashboard_page._txtTrendingNewsAndBlogs, '_txtTrendingNewsAndBlogs');

            fcommon_obj.__log(url);
            // expect(browser.params.url.url_test + '/dashboard').toBe(url);
        });


    };
    /***
     * fcommon_test.__GivenTheUserHasLoginSRC(browser.params.login.login_globAdmin);
     *
     * @param userAccount
     * @private
     */
    this.__GivenTheUserHasLoginSRC = function (userAccount) {

        __GivenTheUserHasLoginSRC(userAccount);

    };


    let __GenerateRandomString = function (sPrefix = '') {

        return sPrefix + futil_timer.__returnYYYYMMDDHMS() + '_' + (Math.random() * Math.pow(36, 10) << 0).toString(36);

    };
    /***
     * fcommon_test.__GenerateRandomString('TestAuto_')
     * @param sPrefix
     * @returns {string}
     * @private
     */
    this.__GenerateRandomString = function (sPrefix = '') {

        return __GenerateRandomString(sPrefix);

    };


    let __GivenUserSubmitDraftAnEvent = function (td, bSubmitTrue_SaveDraftFalse = true, i) {


        describe('GIVEN: ' + td.User + ' submit / draft an Event with all fields filled: ' + td.EventName + i, function () {

            it('User login as: ' + td.User, function () {
                __GivenTheUserHasLoginSRC(td.User);
            });

            it('User goes to Publish -> Event and fill all fields', function () {

                pcommon_publish.__Publish('Event');

                fcommon_obj.__setText('_txtEventName', pcommon_publish._txtEventName, td.EventName + i);
                fcommon_obj.__setText('_txtEventExcerpt', pcommon_publish._txtEventExcerpt, td.EventExcerpt);
                fcommon_obj.__setText('_txtURLLink', pcommon_publish._txtURLLink, td.URL);
                fcommon_obj.__setText('_txtEventContent', pcommon_publish._txtEventContent, td.EventContent, false, false);

                if (td.User === browser.params.login.login_globAdmin) {
                    fcommon_obj.__executeScript(pcommon_publish._btnCompany_delete, '_btnCompany_delete', "click");
                    fcommon_obj.__click('_txtCompany', pcommon_publish._txtCompany);
                    fcommon_obj.__setText('_txtCompany', pcommon_publish._txtCompany, td.Company, false, false);
                    let objCompany = element(by.cssContainingText('.mos-c-autocomplete__list__item', td.Company));
                    fcommon_obj.__click(td.Company, objCompany);
                }


                fcommon_obj.__selectByText('_lstEventType', pcommon_publish._lstEventType, td.EventType);

                fcommon_obj.__click('_txtLocation', pcommon_publish._txtLocation);
                fcommon_obj.__setText('_txtLocation', pcommon_publish._txtLocation, td.Location, false, false);
                let objLocation = element(by.cssContainingText('.mos-c-autocomplete__list__item', td.Location));
                fcommon_obj.__click(td.Location, objLocation);


                let currentDate = new Date();
                let startDate = dateformat(currentDate, 'd-mmm-yyyy');
                fcommon_obj.__executeScript(pcommon_publish._txtStartDate, 'startdate', "click");
                pcommon_page.__setCalender(startDate);
                fcommon_obj.__executeScript(pcommon_publish._labelStartTime, '_labelStartTime', "click");
                fcommon_obj.__setText('_txtStartTime', pcommon_publish._txtStartTime, '11:00 PM');

                let endDate = dateformat(currentDate.setDate(currentDate.getDate() + 1), 'd-mmm-yyyy');
                fcommon_obj.__executeScript(pcommon_publish._txtEndDate, 'endDate', "click");
                pcommon_page.__setCalender(endDate);
                fcommon_obj.__executeScript(pcommon_publish._labelStartTime, '_labelStartTime', "click");
                fcommon_obj.__setText('_txtEndTime', pcommon_publish._txtEndTime, '10:00 PM');

                fcommon_obj.__selectByText('_lstTaxonomies', pcommon_publish._lstTaxonomies, td.Taxonomy);

                ////// fcommon_obj.__click('_txtTags', pcommon_publish._txtTags);
                fcommon_obj.__executeScript(pcommon_publish._txtTags, '_txtTags', "click");
                fcommon_obj.__setText('_txtTags', pcommon_publish._txtTags, td.Tag, false, false);
                let objTag = element(by.cssContainingText('.mos-c-autocomplete__list__item', td.Tag));
                ////// fcommon_obj.__click(td.Tag, objTag);
                fcommon_obj.__executeScript(objTag, td.Tag, "click");


                fcommon_obj.__executeScript(pcommon_publish._txtRegions, '_txtRegions', "click");
                fcommon_obj.__executeScript(pcommon_publish._chkRegion_Asia, '_chkRegion_Asia', "click");
                fcommon_obj.__isCheckBoxChecked(pcommon_publish._chkRegion_Asia, '_chkRegion_Asia', true);

                fcommon_obj.__executeScript(pcommon_publish._txtAudience, '_txtAudience', "click");
                fcommon_obj.__executeScript(pcommon_publish._chkAudience_AssetManager, '_chkAudience_AssetManager', "click");
                fcommon_obj.__isCheckBoxChecked(pcommon_publish._chkAudience_AssetManager, '_chkAudience_AssetManager', true);

                fcommon_obj.__executeScript(pcommon_publish._txtFeaturedImage, '_txtFeaturedImage', "click");
                browser.getCapabilities().then(function(txt){
                    if(txt.get('browserName')!=='MicrosoftEdge'){
                        fcommon_obj.__click('_zoneFeaturedImage_clickable_Research', pcommon_publish._zoneFeaturedImage_clickable_Research, 2, 2);
                        browser.sleep(browser.params.userSleep.short);
                    }

                });

            });

            xit('User uploads Featured Image: ' + td.Upload_FeaturedImage, function () {
                browser.getCapabilities().then(function(txt){

                    if(txt.get('browserName')!=='MicrosoftEdge'){
                        pcommon_publish.__OpenFile(td.Upload_FeaturedImage, txt.get('browserName'));
                        fcommon_obj.__wait4ElementVisible(pcommon_publish._zoneFeaturedImage_delete, '_zoneFeaturedImage_delete');
                    }


                });
            });

            if (bSubmitTrue_SaveDraftFalse)
                it('User Submit the Event: ' + td.EventName, function () {

                    // fcommon_obj.__click('_btnSubmit', pcommon_publish._btnSubmit);
                    fcommon_obj.__executeScript(pcommon_publish._btnSubmit, '_btnSubmit', "click");
                    fcommon_obj.__wait4ElementVisible(pcommon_publish._txtToastOutletMsg, '_txtToastOutletMsg');
                    expect(pcommon_publish._txtToastOutletMsg.getText()).toBe(td.SuccessMsg);
                    // fcommon_obj.__click('_btnToastOutletMsg_close', pcommon_publish._btnToastOutletMsg_close);
                    fcommon_obj.__executeScript(pcommon_publish._btnToastOutletMsg_close, '_btnToastOutletMsg_close', "click");
                    browser.getCurrentUrl().then(function () {
                        fcommon_obj.__log('Submitted Event: ' + td.EventName);
                    });
                });
            else
                it('User save draft of the Event: ' + td.EventName, function () {

                    // fcommon_obj.__click('_btnSubmit', pcommon_publish._btnSubmit);
                    fcommon_obj.__executeScript(pcommon_publish._btnSaveDraft, '_btnSaveDraft', "click");
                    fcommon_obj.__wait4ElementVisible(pcommon_publish._txtToastOutletMsg, '_txtToastOutletMsg');
                    expect(pcommon_publish._txtToastOutletMsg.getText()).toBe(td.SuccessMsg);
                    // fcommon_obj.__click('_btnToastOutletMsg_close', pcommon_publish._btnToastOutletMsg_close);
                    fcommon_obj.__executeScript(pcommon_publish._btnToastOutletMsg_close, '_btnToastOutletMsg_close', "click");
                    browser.getCurrentUrl().then(function () {
                        fcommon_obj.__log('Saved Draft of Event: ' + td.EventName);
                    });
                });

        });


    };


    this.__GivenUserSubmitAnEvent = function (td, bSubmitTrue_SaveDraftFalse = true, i) {

        __GivenUserSubmitDraftAnEvent(td, bSubmitTrue_SaveDraftFalse, i);


    };


    let __GivenUserSubmitDraftAnArtical = function (td, bResearchTrue_NewsFalse = true, bSubmitTrue_SaveDraftFalse = true, i) {


        describe('GIVEN: ' + td.User + ' publishespublishes an artical with all fields filled: ' + td.Title + i, function () {

            it('User login as: ' + td.User, function () {
                __GivenTheUserHasLoginSRC(td.User);
            });

            it('User goes to Publish -> Research/WhitePaper and fill all fields', function () {

                if (bResearchTrue_NewsFalse)
                    pcommon_publish.__Publish('Research/WhitePaper');
                else
                    pcommon_publish.__Publish('News/Blog');

                fcommon_obj.__setText('_txtTitle', pcommon_publish._txtTitle, td.Title + i);
                fcommon_obj.__setText('_txtExecutiveSummary', pcommon_publish._txtExecutiveSummary, td.ExecutiveSummary);
                fcommon_obj.__setText('_txtURLLink', pcommon_publish._txtURLLink, td.URL);
                fcommon_obj.__setText('Content', pcommon_publish._txtEventContent, td.Content, false, false);


                let currentDate = new Date();
                let startDate = dateformat(currentDate, 'd-mmm-yyyy');
                fcommon_obj.__executeScript(pcommon_publish._txtDate, '_txtDate', "click");
                pcommon_page.__setCalender(startDate);
                fcommon_obj.__executeScript(pcommon_publish._labelTitle, '_labelTitle', "click");

                if (bResearchTrue_NewsFalse)
                    fcommon_obj.__selectByText('_lstResearchType', pcommon_publish._lstResearchType, td.Type);


                if (td.User === browser.params.login.login_globAdmin) {
                    fcommon_obj.__executeScript(pcommon_publish._btnCompany_delete, '_btnCompany_delete', "click");
                    fcommon_obj.__click('_txtCompany', pcommon_publish._txtCompany);
                    fcommon_obj.__setText('_txtCompany', pcommon_publish._txtCompany, td.Company, false, false);
                    let objCompany = element(by.cssContainingText('.mos-c-autocomplete__list__item', td.Company));
                    fcommon_obj.__click(td.Company, objCompany);
                }


                fcommon_obj.__selectByText('_lstTaxonomies', pcommon_publish._lstTaxonomies, td.Taxonomy);


                fcommon_obj.__executeScript(pcommon_publish._txtTags, '_txtTags', "click");
                fcommon_obj.__setText('_txtTags', pcommon_publish._txtTags, td.Tag, false, false);
                let objTag = element(by.cssContainingText('.mos-c-autocomplete__list__item', td.Tag));
                fcommon_obj.__executeScript(objTag, td.Tag, "click");

                fcommon_obj.__executeScript(pcommon_publish._txtReadTime, '_txtReadTime', "click");
                fcommon_obj.__setText('_txtNumOfMins', pcommon_publish._txtNumOfMins, td.NumOfMins, );

                fcommon_obj.__executeScript(pcommon_publish._txtVideoLink, '_txtVideoLink', "click");
                fcommon_obj.__setText('_txtVideoEmbed', pcommon_publish._txtVideoEmbed, td.VideoLink, );


                fcommon_obj.__executeScript(pcommon_publish._txtRegions, '_txtRegions', "click");
                fcommon_obj.__executeScript(pcommon_publish._chkRegion_Asia, '_chkRegion_Asia', "click");
                fcommon_obj.__isCheckBoxChecked(pcommon_publish._chkRegion_Asia, '_chkRegion_Asia', true);

                fcommon_obj.__executeScript(pcommon_publish._txtAudience, '_txtAudience', "click");
                fcommon_obj.__executeScript(pcommon_publish._chkAudience_AssetManager, '_chkAudience_AssetManager', "click");
                fcommon_obj.__isCheckBoxChecked(pcommon_publish._chkAudience_AssetManager, '_chkAudience_AssetManager', true);

                fcommon_obj.__executeScript(pcommon_publish._txtAuthors, '_txtAuthors', "click");
                fcommon_obj.__setText('_txtAuthor', pcommon_publish._txtAuthor, td.Author, );

                // fcommon_obj.__executeScript(pcommon_publish._txtFeaturedImage, '_txtFeaturedImage', "click");
                // // fcommon_obj.__executeScript(pcommon_publish._zoneFeaturedImage_clickable_Research, '_zoneFeaturedImage_clickable_Research', "click");
                //
                // browser.getCapabilities().then(function(txt){
                //     if(txt.get('browserName')!=='MicrosoftEdge'){
                //         fcommon_obj.__click('_zoneFeaturedImage_clickable_Research', pcommon_publish._zoneFeaturedImage_clickable_Research, 2, 2);
                //         browser.sleep(browser.params.userSleep.short);
                //     }
                //
                // });


            });

            xit('User uploads Featured Image: ' + td.Upload_FeaturedImage, function () {

                browser.getCapabilities().then(function(txt){

                    if(txt.get('browserName')!=='MicrosoftEdge'){
                        pcommon_publish.__OpenFile(td.Upload_FeaturedImage, txt.get('browserName'));
                        fcommon_obj.__wait4ElementVisible(pcommon_publish._zoneFeaturedImage_delete, '_zoneFeaturedImage_delete');
                    }


                });


            });

            xit('User clicks Uploads Attachemts dropzone', function () {
                browser.getCapabilities().then(function(txt){
                    if(txt.get('browserName')!=='MicrosoftEdge'){
                        fcommon_obj.__click('_zoneUploadAttachment_clickable', pcommon_publish._zoneUploadAttachment_clickable, 2, 2);
                        browser.sleep(browser.params.userSleep.short);
                    }


                });

            });

            xit('User uploads Attachemts: ', function () {

                browser.getCapabilities().then(function(txt){
                    if(txt.get('browserName')!=='MicrosoftEdge'){
                        pcommon_publish.__OpenFile(td.Upload_Attachemnts, txt.get('browserName'));
                        fcommon_obj.__wait4ElementVisible(element(by.cssContainingText('span', 'Test_PDF.pdf')), 'Test_PDF.pdf');
                        fcommon_obj.__wait4ElementVisible(element(by.cssContainingText('span', 'Test_Word.docx')), 'Test_Word.docx');
                        fcommon_obj.__wait4ElementVisible(element(by.cssContainingText('span', 'Test_Excel.xls')), 'Test_Excel.xls');
                        fcommon_obj.__wait4ElementVisible(element(by.cssContainingText('span', 'Test_PPT.pptx')), 'Test_PPT.pptx');
                    }


                });


            });


            if (bSubmitTrue_SaveDraftFalse)
                it('User Submit the Artical: ' + td.Title, function () {

                    fcommon_obj.__executeScript(pcommon_publish._btnSubmit, '_btnSubmit', "click");
                    fcommon_obj.__wait4ElementVisible(pcommon_publish._txtToastOutletMsg, '_txtToastOutletMsg');
                    // expect(pcommon_publish._txtToastOutletMsg.getText()).toBe(td.SuccessMsg);

                    let text = pcommon_publish._txtToastOutletMsg.getText().then(function (e) {
                        return e.replace(/\s+/g, ' ')
                    });
                    expect(text).toBe(td.SuccessMsg);
                    fcommon_obj.__executeScript(pcommon_publish._btnToastOutletMsg_close, '_btnToastOutletMsg_close', "click");
                    browser.getCurrentUrl().then(function () {
                        fcommon_obj.__log('Submitted artical: ' + td.Title);
                    });


                });
            else
                it('User save draft of the Artical: ' + td.Title, function () {

                    // fcommon_obj.__click('_btnSubmit', pcommon_publish._btnSubmit);
                    fcommon_obj.__executeScript(pcommon_publish._btnSaveDraft, '_btnSaveDraft', "click");
                    fcommon_obj.__wait4ElementVisible(pcommon_publish._txtToastOutletMsg, '_txtToastOutletMsg');
                    expect(pcommon_publish._txtToastOutletMsg.getText()).toBe(td.SuccessMsg);
                    // fcommon_obj.__click('_btnToastOutletMsg_close', pcommon_publish._btnToastOutletMsg_close);
                    fcommon_obj.__executeScript(pcommon_publish._btnToastOutletMsg_close, '_btnToastOutletMsg_close', "click");
                    browser.getCurrentUrl().then(function () {
                        fcommon_obj.__log('Saved Draft of artical: ' + td.Title);
                    });
                });




        });


    };


    this.__GivenUserSubmitAnArtical = function (td, bResearchTrue_NewsFalse = true, bSubmitTrue_SaveDraftFalse = true, i) {

        __GivenUserSubmitDraftAnArtical(td, bResearchTrue_NewsFalse, bSubmitTrue_SaveDraftFalse, i);


    };



    this.__UserSaveAnArticleOnPublishPageWithMandatoryFields = (td, bResearchTrue_NewsFalse = true) => {

        if (bResearchTrue_NewsFalse)
            pcommon_publish.__Publish('Research/WhitePaper');
        else
            pcommon_publish.__Publish('News/Blog');

        fcommon_obj.__setText('_txtTitle', pcommon_publish._txtTitle, td.Title);
        expect(pcommon_publish._txtTitle.getAttribute('value')).toEqual(td.Title)

        fcommon_obj.__setText('_txtExecutiveSummary', pcommon_publish._txtExecutiveSummary, td.ExecutiveSummary);
        expect(pcommon_publish._txtEventExcerpt.getAttribute('value')).toEqual(td.ExecutiveSummary)

        fcommon_obj.__setText('_txtURLLink', pcommon_publish._txtURLLink, td.URL);
        expect(pcommon_publish._txtURLLink.getAttribute('value')).toEqual(td.URL)

        // fcommon_obj.__setText('Content', pcommon_publish._txtEventContent, td.Content, false, false);

        const cCurrentDate = dateformat(td.CurrentDate, 'd-mmm-yyyy');
        const sCurrentDate = dateformat(td.CurrentDate, 'mm/dd/yyyy');
        fcommon_obj.__executeScript(pcommon_publish._txtDate, '_txtDate', "click");
        pcommon_page.__setCalender(cCurrentDate);
        fcommon_obj.__executeScript(pcommon_publish._labelTitle, '_labelTitle', "click");
        expect(pcommon_publish._txtDate.getText()).toEqual(sCurrentDate)


        if (bResearchTrue_NewsFalse) {
            fcommon_obj.__selectByText('_lstResearchType', pcommon_publish._lstResearchType, td.Type);
            expect(pcommon_publish._lstResearchType.getAttribute('value')).toContain(td.Type)
        }

        fcommon_obj.__selectByText('_lstTaxonomies', pcommon_publish._lstTaxonomies, td.Taxonomy);
        expect(element(by.cssContainingText('.mos-c-chip.mos-c-chip--md.mos-t-chip--secondary-alt', td.Taxonomy)).isDisplayed()).toBe(true)


        // if (pcommon_publish._txtTags != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtTags, '_txtTags', "click");
        //     fcommon_obj.__setText('_txtTags', pcommon_publish._txtTags, td.Tag, false, false);
        //     let objTag = element(by.cssContainingText('.mos-c-autocomplete__list__item', td.Tag));
        //     fcommon_obj.__executeScript(objTag, td.Tag, "click");
        // }

        // if (pcommon_publish._txtReadTime != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtReadTime, '_txtReadTime', "click");
        //     fcommon_obj.__setText('_txtNumOfMins', pcommon_publish._txtNumOfMins, td.NumOfMins, );
        // }

        // if (pcommon_publish._txtVideoLink != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtVideoLink, '_txtVideoLink', "click");
        //     fcommon_obj.__setText('_txtVideoEmbed', pcommon_publish._txtVideoEmbed, td.VideoLink, );
        // }

        // if (pcommon_publish._txtVideoLink != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtAuthors, '_txtAuthors', "click");
        //     fcommon_obj.__setText('_txtAuthor', pcommon_publish._txtAuthor, td.Author, );
        // }

        // if (pcommon_publish._txtFeaturedImage != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtFeaturedImage, '_txtFeaturedImage', "click");
        //     fcommon_obj.__click('_zoneFeaturedImage_clickable_Research', pcommon_publish._zoneFeaturedImage_clickable_Research);
        // }


        fcommon_obj.__executeScript(pcommon_publish._btnSaveDraft, '_btnSaveDraft', "click");
        fcommon_obj.__wait4ElementVisible(pcommon_publish._txtToastOutletMsg, '_txtToastOutletMsg');


        let text = pcommon_publish._txtToastOutletMsg.getText().then(function (e) {
            return e.replace(/\s+/g, ' ')
        });
        expect(text).toBe(td.Save_SuccessMsg);
        fcommon_obj.__executeScript(pcommon_publish._btnToastOutletMsg_close, '_btnToastOutletMsg_close', "click");
    }

    this.__UserSubmitAnArticleOnPublishPageWithMandatoryFields = (td, bResearchTrue_NewsFalse = true) => {

        if (bResearchTrue_NewsFalse)
            pcommon_publish.__Publish('Research/WhitePaper');
        else
            pcommon_publish.__Publish('News/Blog');

        fcommon_obj.__setText('_txtTitle', pcommon_publish._txtTitle, td.Title);
        fcommon_obj.__setText('_txtExecutiveSummary', pcommon_publish._txtExecutiveSummary, td.ExecutiveSummary);
        fcommon_obj.__setText('_txtURLLink', pcommon_publish._txtURLLink, td.URL);
        // fcommon_obj.__setText('Content', pcommon_publish._txtEventContent, td.Content, false, false);

        let currentDate = new Date();
        let startDate = dateformat(currentDate, 'd-mmm-yyyy');
        fcommon_obj.__executeScript(pcommon_publish._txtDate, '_txtDate', "click");
        pcommon_page.__setCalender(startDate);
        fcommon_obj.__executeScript(pcommon_publish._labelTitle, '_labelTitle', "click");

        if (bResearchTrue_NewsFalse)
            fcommon_obj.__selectByText('_lstResearchType', pcommon_publish._lstResearchType, td.Type);

        fcommon_obj.__selectByText('_lstTaxonomies', pcommon_publish._lstTaxonomies, td.Taxonomy);

        fcommon_obj.__executeScript(pcommon_publish._btnSubmit, '_btnSubmit', "click");
        fcommon_obj.__wait4ElementVisible(pcommon_publish._txtToastOutletMsg, '_txtToastOutletMsg');


        let text = pcommon_publish._txtToastOutletMsg.getText().then(function (e) {
            return e.replace(/\s+/g, ' ')
        });
        expect(text).toBe(td.Submit_SuccessMsg);
        fcommon_obj.__executeScript(pcommon_publish._btnToastOutletMsg_close, '_btnToastOutletMsg_close', "click");
    }

    this.__UserSaveEventOnPublishPageWithMandatoryFields = (td) => {

        pcommon_publish.__Publish('Event');

        fcommon_obj.__setText('_txtTitle', pcommon_publish._txtTitle, td.Title);
        expect(pcommon_publish._txtTitle.getAttribute('value')).toEqual(td.Title)

        fcommon_obj.__setText('_txtExecutiveSummary', pcommon_publish._txtExecutiveSummary, td.ExecutiveSummary);
        expect(pcommon_publish._txtEventExcerpt.getAttribute('value')).toEqual(td.ExecutiveSummary)

        fcommon_obj.__setText('_txtURLLink', pcommon_publish._txtURLLink, td.URL);
        expect(pcommon_publish._txtURLLink.getAttribute('value')).toEqual(td.URL)

        fcommon_obj.__setText('_txtEventContent', pcommon_publish._txtEventContent, td.Content, false, false);
        expect(pcommon_publish._txtEventContent.getText()).toEqual(td.Content)


        fcommon_obj.__selectByText('_lstEventType', pcommon_publish._lstEventType, td.Type);
        expect(pcommon_publish._lstEventType.getAttribute('value')).toContain(td.Type)

        fcommon_obj.__click('_txtLocation', pcommon_publish._txtLocation);
        fcommon_obj.__setText('_txtLocation', pcommon_publish._txtLocation, td.Location, false, false);
        browser.sleep(browser.params.userSleep.long)
        let objLocation = element(by.cssContainingText('.mos-c-autocomplete__list__item', td.Location));
        fcommon_obj.__click(td.Location, objLocation);
        expect(pcommon_publish._txtLocation.getAttribute('value')).toContain(td.Location)


        const cStartDate = dateformat(td.StartDate, 'd-mmm-yyyy');
        const sStartDate = dateformat(td.StartDate, 'mm/dd/yyyy');
        fcommon_obj.__executeScript(pcommon_publish._txtStartDate, '_txtStartDate', "click");
        pcommon_page.__setCalender(cStartDate);
        fcommon_obj.__executeScript(pcommon_publish._labelStartTime, '_labelStartTime', "click");
        expect(pcommon_publish._txtStartDate.getText()).toEqual(sStartDate)

        fcommon_obj.__setText('_txtStartTime', pcommon_publish._txtStartTime, td.StartTime);
        expect(pcommon_publish._txtStartTime.getAttribute('value')).toEqual(td.StartTime)

        const cEndDate = dateformat(td.EndDate.setDate(td.EndDate.getDate() + 1), 'd-mmm-yyyy');
        const sEndDate = dateformat(td.EndDate, 'mm/dd/yyyy');
        fcommon_obj.__executeScript(pcommon_publish._txtEndDate, '_txtEndDate', "click");
        pcommon_page.__setCalender(cEndDate);
        fcommon_obj.__executeScript(pcommon_publish._labelStartTime, '_labelEndTime', "click");
        expect(pcommon_publish._txtEndDate.getText()).toEqual(sEndDate)

        fcommon_obj.__setText('_txtEndTime', pcommon_publish._txtEndTime, td.EndTime);
        expect(pcommon_publish._txtEndTime.getAttribute('value')).toEqual(td.EndTime)

        fcommon_obj.__selectByText('_lstTaxonomies', pcommon_publish._lstTaxonomies, td.Taxonomy);
        expect(element(by.cssContainingText('.mos-c-chip.mos-c-chip--md.mos-t-chip--secondary-alt', td.Taxonomy)).isDisplayed()).toBe(true)


        // if (pcommon_publish._txtTags != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtTags, '_txtTags', "click");
        //     fcommon_obj.__setText('_txtTags', pcommon_publish._txtTags, td.Tag, false, false);
        //     let objTag = element(by.cssContainingText('.mos-c-autocomplete__list__item', td.Tag));
        //     fcommon_obj.__executeScript(objTag, td.Tag, "click");
        // }

        // if (pcommon_publish._txtReadTime != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtReadTime, '_txtReadTime', "click");
        //     fcommon_obj.__setText('_txtNumOfMins', pcommon_publish._txtNumOfMins, td.NumOfMins, );
        // }

        // if (pcommon_publish._txtVideoLink != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtVideoLink, '_txtVideoLink', "click");
        //     fcommon_obj.__setText('_txtVideoEmbed', pcommon_publish._txtVideoEmbed, td.VideoLink, );
        // }

        // if (pcommon_publish._txtVideoLink != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtAuthors, '_txtAuthors', "click");
        //     fcommon_obj.__setText('_txtAuthor', pcommon_publish._txtAuthor, td.Author, );
        // }

        // if (pcommon_publish._txtFeaturedImage != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtFeaturedImage, '_txtFeaturedImage', "click");
        //     fcommon_obj.__click('_zoneFeaturedImage_clickable_Research', pcommon_publish._zoneFeaturedImage_clickable_Research);
        // }


        fcommon_obj.__executeScript(pcommon_publish._btnSaveDraft, '_btnSaveDraft', "click");
        fcommon_obj.__wait4ElementVisible(pcommon_publish._txtToastOutletMsg, '_txtToastOutletMsg');


        let text = pcommon_publish._txtToastOutletMsg.getText().then(function (e) {
            return e.replace(/\s+/g, ' ')
        });
        expect(text).toBe(td.Save_SuccessMsg);
        fcommon_obj.__executeScript(pcommon_publish._btnToastOutletMsg_close, '_btnToastOutletMsg_close', "click");
    }

    this.__UserSubmitEventOnPublishPageWithMandatoryFields = (td) => {

        pcommon_publish.__Publish('Event');

        fcommon_obj.__setText('_txtTitle', pcommon_publish._txtTitle, td.Title);
        expect(pcommon_publish._txtTitle.getAttribute('value')).toEqual(td.Title)

        fcommon_obj.__setText('_txtExecutiveSummary', pcommon_publish._txtExecutiveSummary, td.ExecutiveSummary);
        expect(pcommon_publish._txtEventExcerpt.getAttribute('value')).toEqual(td.ExecutiveSummary)

        fcommon_obj.__setText('_txtURLLink', pcommon_publish._txtURLLink, td.URL);
        expect(pcommon_publish._txtURLLink.getAttribute('value')).toEqual(td.URL)

        fcommon_obj.__setText('_txtEventContent', pcommon_publish._txtEventContent, td.Content, false, false);
        expect(pcommon_publish._txtEventContent.getText()).toEqual(td.Content)


        fcommon_obj.__selectByText('_lstEventType', pcommon_publish._lstEventType, td.Type);
        expect(pcommon_publish._lstEventType.getAttribute('value')).toContain(td.Type)

        fcommon_obj.__click('_txtLocation', pcommon_publish._txtLocation);
        fcommon_obj.__setText('_txtLocation', pcommon_publish._txtLocation, td.Location, false, false);
        browser.sleep(browser.params.userSleep.long)
        let objLocation = element(by.cssContainingText('.mos-c-autocomplete__list__item', td.Location));
        fcommon_obj.__click(td.Location, objLocation);
        expect(pcommon_publish._txtLocation.getAttribute('value')).toContain(td.Location)


        const cStartDate = dateformat(td.StartDate, 'd-mmm-yyyy');
        const sStartDate = dateformat(td.StartDate, 'mm/dd/yyyy');
        fcommon_obj.__executeScript(pcommon_publish._txtStartDate, '_txtStartDate', "click");
        pcommon_page.__setCalender(cStartDate);
        fcommon_obj.__executeScript(pcommon_publish._labelStartTime, '_labelStartTime', "click");
        expect(pcommon_publish._txtStartDate.getText()).toEqual(sStartDate)

        fcommon_obj.__setText('_txtStartTime', pcommon_publish._txtStartTime, td.StartTime);
        expect(pcommon_publish._txtStartTime.getAttribute('value')).toEqual(td.StartTime)

        const cEndDate = dateformat(td.EndDate.setDate(td.EndDate.getDate() + 1), 'd-mmm-yyyy');
        const sEndDate = dateformat(td.EndDate, 'mm/dd/yyyy');
        fcommon_obj.__executeScript(pcommon_publish._txtEndDate, '_txtEndDate', "click");
        pcommon_page.__setCalender(cEndDate);
        fcommon_obj.__executeScript(pcommon_publish._labelStartTime, '_labelEndTime', "click");
        expect(pcommon_publish._txtEndDate.getText()).toEqual(sEndDate)

        fcommon_obj.__setText('_txtEndTime', pcommon_publish._txtEndTime, td.EndTime);
        expect(pcommon_publish._txtEndTime.getAttribute('value')).toEqual(td.EndTime)

        fcommon_obj.__selectByText('_lstTaxonomies', pcommon_publish._lstTaxonomies, td.Taxonomy);
        expect(element(by.cssContainingText('.mos-c-chip.mos-c-chip--md.mos-t-chip--secondary-alt', td.Taxonomy)).isDisplayed()).toBe(true)


        // if (pcommon_publish._txtTags != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtTags, '_txtTags', "click");
        //     fcommon_obj.__setText('_txtTags', pcommon_publish._txtTags, td.Tag, false, false);
        //     let objTag = element(by.cssContainingText('.mos-c-autocomplete__list__item', td.Tag));
        //     fcommon_obj.__executeScript(objTag, td.Tag, "click");
        // }

        // if (pcommon_publish._txtReadTime != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtReadTime, '_txtReadTime', "click");
        //     fcommon_obj.__setText('_txtNumOfMins', pcommon_publish._txtNumOfMins, td.NumOfMins, );
        // }

        // if (pcommon_publish._txtVideoLink != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtVideoLink, '_txtVideoLink', "click");
        //     fcommon_obj.__setText('_txtVideoEmbed', pcommon_publish._txtVideoEmbed, td.VideoLink, );
        // }

        // if (pcommon_publish._txtVideoLink != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtAuthors, '_txtAuthors', "click");
        //     fcommon_obj.__setText('_txtAuthor', pcommon_publish._txtAuthor, td.Author, );
        // }

        // if (pcommon_publish._txtFeaturedImage != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtFeaturedImage, '_txtFeaturedImage', "click");
        //     fcommon_obj.__click('_zoneFeaturedImage_clickable_Research', pcommon_publish._zoneFeaturedImage_clickable_Research);
        // }


        fcommon_obj.__executeScript(pcommon_publish._btnSubmit, '_btnSubmit', "click");
        fcommon_obj.__wait4ElementVisible(pcommon_publish._txtToastOutletMsg, '_txtToastOutletMsg');


        let text = pcommon_publish._txtToastOutletMsg.getText().then(function (e) {
            return e.replace(/\s+/g, ' ')
        });
        expect(text).toBe(td.Submit_SuccessMsg);
        fcommon_obj.__executeScript(pcommon_publish._btnToastOutletMsg_close, '_btnToastOutletMsg_close', "click");
    }

    this.__MercerUserSaveAnInternalOnlyArticleOnPublishPageWithMandatoryFields = (td, bResearchTrue_NewsFalse = true) => {

        if (bResearchTrue_NewsFalse)
            pcommon_publish.__Publish('Research/WhitePaper');
        else
            pcommon_publish.__Publish('News/Blog');

        // pcommon_publish._toggleInternalOnly.getText().then((t)=>fcommon_obj.__log(t))
        fcommon_obj.__executeScript(pcommon_publish._toggleInternalOnly_bar, '_toggleInternalOnly', "click");
        browser.sleep(browser.params.userSleep.short)
        fcommon_obj.__setText('_txtTitle', pcommon_publish._txtTitle, td.Title);
        fcommon_obj.__setText('_txtExecutiveSummary', pcommon_publish._txtExecutiveSummary, td.ExecutiveSummary);
        fcommon_obj.__setText('_txtURLLink', pcommon_publish._txtURLLink, td.URL);
        // fcommon_obj.__setText('Content', pcommon_publish._txtEventContent, td.Content, false, false);

        let currentDate = new Date();
        let startDate = dateformat(currentDate, 'd-mmm-yyyy');
        fcommon_obj.__executeScript(pcommon_publish._txtDate, '_txtDate', "click");
        pcommon_page.__setCalender(startDate);
        fcommon_obj.__executeScript(pcommon_publish._labelTitle, '_labelTitle', "click");

        if (bResearchTrue_NewsFalse)
            fcommon_obj.__selectByText('_lstResearchType', pcommon_publish._lstResearchType, td.Type);

        fcommon_obj.__selectByText('_lstTaxonomies', pcommon_publish._lstTaxonomies, td.Taxonomy);

        fcommon_obj.__executeScript(pcommon_publish._btnSaveDraft, '_btnSaveDraft', "click");
        fcommon_obj.__wait4ElementVisible(pcommon_publish._txtToastOutletMsg, '_txtToastOutletMsg');


        let text = pcommon_publish._txtToastOutletMsg.getText().then(function (e) {
            return e.replace(/\s+/g, ' ')
        });
        expect(text).toBe(td.Save_SuccessMsg);
        fcommon_obj.__executeScript(pcommon_publish._btnToastOutletMsg_close, '_btnToastOutletMsg_close', "click");

    }

    this.__MercerUserSubmitAnInternalOnlyArticleOnPublishPageWithMandatoryFields = (td, bResearchTrue_NewsFalse = true) => {

        if (bResearchTrue_NewsFalse)
            pcommon_publish.__Publish('Research/WhitePaper');
        else
            pcommon_publish.__Publish('News/Blog');

        fcommon_obj.__executeScript(pcommon_publish._toggleInternalOnly, '_toggleInternalOnly', "click");

        fcommon_obj.__setText('_txtTitle', pcommon_publish._txtTitle, td.Title);
        fcommon_obj.__setText('_txtExecutiveSummary', pcommon_publish._txtExecutiveSummary, td.ExecutiveSummary);
        fcommon_obj.__setText('_txtURLLink', pcommon_publish._txtURLLink, td.URL);
        // fcommon_obj.__setText('Content', pcommon_publish._txtEventContent, td.Content, false, false);

        let currentDate = new Date();
        let startDate = dateformat(currentDate, 'd-mmm-yyyy');
        fcommon_obj.__executeScript(pcommon_publish._txtDate, '_txtDate', "click");
        pcommon_page.__setCalender(startDate);
        fcommon_obj.__executeScript(pcommon_publish._labelTitle, '_labelTitle', "click");

        if (bResearchTrue_NewsFalse)
            fcommon_obj.__selectByText('_lstResearchType', pcommon_publish._lstResearchType, td.Type);

        fcommon_obj.__selectByText('_lstTaxonomies', pcommon_publish._lstTaxonomies, td.Taxonomy);

        fcommon_obj.__executeScript(pcommon_publish._btnSubmit, '_btnSubmit', "click");
        fcommon_obj.__wait4ElementVisible(pcommon_publish._txtToastOutletMsg, '_txtToastOutletMsg');


        let text = pcommon_publish._txtToastOutletMsg.getText().then(function (e) {
            return e.replace(/\s+/g, ' ')
        });
        expect(text).toBe(td.SubmitSuccessMsg);
        fcommon_obj.__executeScript(pcommon_publish._btnToastOutletMsg_close, '_btnToastOutletMsg_close', "click");

    }

    this.__MercerUserSaveInternalOnlyEventOnPublishPageWithMandatoryFields = (td) => {

        pcommon_publish.__Publish('Event');

        fcommon_obj.__executeScript(pcommon_publish._toggleInternalOnly_bar, '_toggleInternalOnly', "click");
        expect(pcommon_publish._toggleInternalOnly_setting.isSelected()).toBe(true)
        browser.sleep(browser.params.userSleep.short)

        fcommon_obj.__setText('_txtTitle', pcommon_publish._txtTitle, td.Title);
        expect(pcommon_publish._txtTitle.getAttribute('value')).toEqual(td.Title)

        fcommon_obj.__setText('_txtExecutiveSummary', pcommon_publish._txtExecutiveSummary, td.ExecutiveSummary);
        expect(pcommon_publish._txtEventExcerpt.getAttribute('value')).toEqual(td.ExecutiveSummary)

        fcommon_obj.__setText('_txtURLLink', pcommon_publish._txtURLLink, td.URL);
        expect(pcommon_publish._txtURLLink.getAttribute('value')).toEqual(td.URL)

        fcommon_obj.__setText('_txtEventContent', pcommon_publish._txtEventContent, td.Content, false, false);
        expect(pcommon_publish._txtEventContent.getText()).toEqual(td.Content)


        fcommon_obj.__selectByText('_lstEventType', pcommon_publish._lstEventType, td.Type);
        expect(pcommon_publish._lstEventType.getAttribute('value')).toContain(td.Type)

        fcommon_obj.__click('_txtLocation', pcommon_publish._txtLocation);
        fcommon_obj.__setText('_txtLocation', pcommon_publish._txtLocation, td.Location, false, false);
        browser.sleep(browser.params.userSleep.long)
        let objLocation = element(by.cssContainingText('.mos-c-autocomplete__list__item', td.Location));
        fcommon_obj.__click(td.Location, objLocation);
        expect(pcommon_publish._txtLocation.getAttribute('value')).toContain(td.Location)


        const cStartDate = dateformat(td.StartDate, 'd-mmm-yyyy');
        const sStartDate = dateformat(td.StartDate, 'mm/dd/yyyy');
        fcommon_obj.__executeScript(pcommon_publish._txtStartDate, '_txtStartDate', "click");
        pcommon_page.__setCalender(cStartDate);
        fcommon_obj.__executeScript(pcommon_publish._labelStartTime, '_labelStartTime', "click");
        expect(pcommon_publish._txtStartDate.getText()).toEqual(sStartDate)

        fcommon_obj.__setText('_txtStartTime', pcommon_publish._txtStartTime, td.StartTime);
        expect(pcommon_publish._txtStartTime.getAttribute('value')).toEqual(td.StartTime)

        const cEndDate = dateformat(td.EndDate.setDate(td.EndDate.getDate() + 1), 'd-mmm-yyyy');
        const sEndDate = dateformat(td.EndDate, 'mm/dd/yyyy');
        fcommon_obj.__executeScript(pcommon_publish._txtEndDate, '_txtEndDate', "click");
        pcommon_page.__setCalender(cEndDate);
        fcommon_obj.__executeScript(pcommon_publish._labelStartTime, '_labelEndTime', "click");
        expect(pcommon_publish._txtEndDate.getText()).toEqual(sEndDate)

        fcommon_obj.__setText('_txtEndTime', pcommon_publish._txtEndTime, td.EndTime);
        expect(pcommon_publish._txtEndTime.getAttribute('value')).toEqual(td.EndTime)

        fcommon_obj.__selectByText('_lstTaxonomies', pcommon_publish._lstTaxonomies, td.Taxonomy);
        expect(element(by.cssContainingText('.mos-c-chip.mos-c-chip--md.mos-t-chip--secondary-alt', td.Taxonomy)).isDisplayed()).toBe(true)


        // if (pcommon_publish._txtTags != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtTags, '_txtTags', "click");
        //     fcommon_obj.__setText('_txtTags', pcommon_publish._txtTags, td.Tag, false, false);
        //     let objTag = element(by.cssContainingText('.mos-c-autocomplete__list__item', td.Tag));
        //     fcommon_obj.__executeScript(objTag, td.Tag, "click");
        // }

        // if (pcommon_publish._txtReadTime != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtReadTime, '_txtReadTime', "click");
        //     fcommon_obj.__setText('_txtNumOfMins', pcommon_publish._txtNumOfMins, td.NumOfMins, );
        // }

        // if (pcommon_publish._txtVideoLink != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtVideoLink, '_txtVideoLink', "click");
        //     fcommon_obj.__setText('_txtVideoEmbed', pcommon_publish._txtVideoEmbed, td.VideoLink, );
        // }

        // if (pcommon_publish._txtVideoLink != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtAuthors, '_txtAuthors', "click");
        //     fcommon_obj.__setText('_txtAuthor', pcommon_publish._txtAuthor, td.Author, );
        // }

        // if (pcommon_publish._txtFeaturedImage != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtFeaturedImage, '_txtFeaturedImage', "click");
        //     fcommon_obj.__click('_zoneFeaturedImage_clickable_Research', pcommon_publish._zoneFeaturedImage_clickable_Research);
        // }


        fcommon_obj.__executeScript(pcommon_publish._btnSaveDraft, '_btnSaveDraft', "click");
        fcommon_obj.__wait4ElementVisible(pcommon_publish._txtToastOutletMsg, '_txtToastOutletMsg');


        let text = pcommon_publish._txtToastOutletMsg.getText().then(function (e) {
            return e.replace(/\s+/g, ' ')
        });
        expect(text).toBe(td.Save_SuccessMsg);
        fcommon_obj.__executeScript(pcommon_publish._btnToastOutletMsg_close, '_btnToastOutletMsg_close', "click");
    }

    this.__MercerUserSubmitInternalOnlyEventOnPublishPageWithMandatoryFields = (td) => {

        pcommon_publish.__Publish('Event');

        fcommon_obj.__executeScript(pcommon_publish._toggleInternalOnly_bar, '_toggleInternalOnly', "click");
        expect(pcommon_publish._toggleInternalOnly_setting.isSelected()).toBe(true)
        browser.sleep(browser.params.userSleep.short)

        fcommon_obj.__setText('_txtTitle', pcommon_publish._txtTitle, td.Title);
        expect(pcommon_publish._txtTitle.getAttribute('value')).toEqual(td.Title)

        fcommon_obj.__setText('_txtExecutiveSummary', pcommon_publish._txtExecutiveSummary, td.ExecutiveSummary);
        expect(pcommon_publish._txtEventExcerpt.getAttribute('value')).toEqual(td.ExecutiveSummary)

        fcommon_obj.__setText('_txtURLLink', pcommon_publish._txtURLLink, td.URL);
        expect(pcommon_publishthis._txtURLLink.getAttribute('value')).toEqual(td.URL)

        fcommon_obj.__setText('_txtEventContent', pcommon_publish._txtEventContent, td.Content, false, false);
        expect(pcommon_publish._txtEventContent.getText()).toEqual(td.Content)


        fcommon_obj.__selectByText('_lstEventType', pcommon_publish._lstEventType, td.Type);
        expect(pcommon_publish._lstEventType.getAttribute('value')).toContain(td.Type)

        fcommon_obj.__click('_txtLocation', pcommon_publish._txtLocation);
        fcommon_obj.__setText('_txtLocation', pcommon_publish._txtLocation, td.Location, false, false);
        browser.sleep(browser.params.userSleep.long)
        let objLocation = element(by.cssContainingText('.mos-c-autocomplete__list__item', td.Location));
        fcommon_obj.__click(td.Location, objLocation);
        expect(pcommon_publish._txtLocation.getAttribute('value')).toContain(td.Location)


        const cStartDate = dateformat(td.StartDate, 'd-mmm-yyyy');
        const sStartDate = dateformat(td.StartDate, 'mm/dd/yyyy');
        fcommon_obj.__executeScript(pcommon_publish._txtStartDate, '_txtStartDate', "click");
        pcommon_page.__setCalender(cStartDate);
        fcommon_obj.__executeScript(pcommon_publish._labelStartTime, '_labelStartTime', "click");
        expect(pcommon_publish._txtStartDate.getText()).toEqual(sStartDate)

        fcommon_obj.__setText('_txtStartTime', pcommon_publish._txtStartTime, td.StartTime);
        expect(pcommon_publish._txtStartTime.getAttribute('value')).toEqual(td.StartTime)

        const cEndDate = dateformat(td.EndDate.setDate(td.EndDate.getDate() + 1), 'd-mmm-yyyy');
        const sEndDate = dateformat(td.EndDate, 'mm/dd/yyyy');
        fcommon_obj.__executeScript(pcommon_publish._txtEndDate, '_txtEndDate', "click");
        pcommon_page.__setCalender(cEndDate);
        fcommon_obj.__executeScript(pcommon_publish._labelStartTime, '_labelEndTime', "click");
        expect(pcommon_publish._txtEndDate.getText()).toEqual(sEndDate)

        fcommon_obj.__setText('_txtEndTime', pcommon_publish._txtEndTime, td.EndTime);
        expect(pcommon_publish._txtEndTime.getAttribute('value')).toEqual(td.EndTime)

        fcommon_obj.__selectByText('_lstTaxonomies', pcommon_publish._lstTaxonomies, td.Taxonomy);
        expect(element(by.cssContainingText('.mos-c-chip.mos-c-chip--md.mos-t-chip--secondary-alt', td.Taxonomy)).isDisplayed()).toBe(true)


        // if (pcommon_publish._txtTags != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtTags, '_txtTags', "click");
        //     fcommon_obj.__setText('_txtTags', pcommon_publish._txtTags, td.Tag, false, false);
        //     let objTag = element(by.cssContainingText('.mos-c-autocomplete__list__item', td.Tag));
        //     fcommon_obj.__executeScript(objTag, td.Tag, "click");
        // }

        // if (pcommon_publish._txtReadTime != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtReadTime, '_txtReadTime', "click");
        //     fcommon_obj.__setText('_txtNumOfMins', pcommon_publish._txtNumOfMins, td.NumOfMins, );
        // }

        // if (pcommon_publish._txtVideoLink != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtVideoLink, '_txtVideoLink', "click");
        //     fcommon_obj.__setText('_txtVideoEmbed', pcommon_publish._txtVideoEmbed, td.VideoLink, );
        // }

        // if (pcommon_publish._txtVideoLink != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtAuthors, '_txtAuthors', "click");
        //     fcommon_obj.__setText('_txtAuthor', pcommon_publish._txtAuthor, td.Author, );
        // }

        // if (pcommon_publish._txtFeaturedImage != '') {
        //     fcommon_obj.__executeScript(pcommon_publish._txtFeaturedImage, '_txtFeaturedImage', "click");
        //     fcommon_obj.__click('_zoneFeaturedImage_clickable_Research', pcommon_publish._zoneFeaturedImage_clickable_Research);
        // }


        fcommon_obj.__executeScript(pcommon_publish._btnSaveDraft, '_btnSaveDraft', "click");
        fcommon_obj.__wait4ElementVisible(pcommon_publish._txtToastOutletMsg, '_txtToastOutletMsg');


        let text = pcommon_publish._txtToastOutletMsg.getText().then(function (e) {
            return e.replace(/\s+/g, ' ')
        });
        expect(text).toBe(td.Submit_SuccessMsg);
        fcommon_obj.__executeScript(pcommon_publish._btnToastOutletMsg_close, '_btnToastOutletMsg_close', "click");
    }



    this.__OpenPublishArticlePage = (sArticleType) => {
        switch (sArticleType) {
            case 'Research':
                pcommon_publish.__Publish('Research/WhitePaper');
                break
            case 'News':
                pcommon_publish.__Publish('News/Blog');
                break
            case 'Event':
                pcommon_publish.__Publish('Event');
                break
            default:
                fcommon_obj.__log("Please input an ArticleType in td: 'Research', 'News', 'Event'")
                return
        }
    }

    this.__SubmitPublishArticle = (td) => {
        switch (td.ArticleType) {
            case 'Research':
                pcommon_publish.__Submit(td.Research_Submit_SuccessMsg);
                break
            case 'News':
                pcommon_publish.__Submit(td.News_Submit_SuccessMsg);
                break
            case 'Event':
                pcommon_publish.__Submit(td.Event_Submit_SuccessMsg);
                break
        }
    }

    this.__SavePublishArticle = (td) => {
        switch (td.ArticleType) {
            case 'Research':
                pcommon_publish.__SaveDraft(td.Research_Save_SuccessMsg);
                break
            case 'News':
                pcommon_publish.__SaveDraft(td.News_Save_SuccessMsg);
                break
            case 'Event':
                pcommon_publish.__SaveDraft(td.Event_Save_SuccessMsg);
                break
        }
    }
    this.__OpenPostsArticle = (td) => {
        pcommon_page.__gotoPersonIcon_Menu('Posts');
        puserArticleList_page.__selectedContentType(td.PostsType);
        puserArticleList_page.__verifyPostsExist(td.Title);
        puserArticleList_page.__selectPosts(td.Title);
    }

    this.__OpenModerateArticle = (td) => {
        pcommon_page.__gotoSetting('Moderate Content')
        pcontentList.__doSearch(td.Moderate_Status, td.PostsType, td.Title, true)
    }
    this.__ApproveArticle = (td) => {
        pcommon_page.__gotoSetting('Moderate Content')
        pcontentList.__doSearch('Waiting for approval', td.PostsType, td.Title, false)
        pcontentList.__doApproveReject(td.Title, true)
    }

    this.__ArticlePublish = (td) => {

        //set internal only
        if (td.InternalOnly != null && td.InternalOnly != '')
            pcommon_publish.__setInternalOnlyToggle(td.InternalOnly)

        //set title
        pcommon_publish.__setTitle(td.Title)
        //set executive summary
        pcommon_publish.__setExecutiveSummary(td.ExecutiveSummary)
        //set link to content
        pcommon_publish.__setContentLink(td.URL)
        //set Content
        pcommon_publish.__setContent(td.Content)

        //set date
        if (td.ArticleType != 'Event') {
            //set date
            pcommon_publish.__setDate(td.CurrentDate)
        }
        else {
            //set start date
            pcommon_publish.__setStartDate(td.StartDate)
            //set start time
            pcommon_publish.__setStartTime(td.StartTime)
            //set end date
            pcommon_publish.__setEndDate(td.EndDate)
            //set end time
            pcommon_publish.__setEndTime(td.EndTime)
        }

        //set research type
        if (td.ArticleType === 'Research')
            pcommon_publish.__setResearchType(td.Type)

        //set event type
        //set location
        if (td.ArticleType === 'Event') {
            //set event type
            pcommon_publish.__setEventType(td.Type)
            //set location
            pcommon_publish.__setLocation(td.Location)
        }

        //set Taxonomies
        pcommon_publish.__setTaxonomies(td.Taxonomy)

        //set attachments
        if (td.Upload_Attachemnts != null && td.Upload_Attachemnts != '' && td.ArticleType != 'Event') {
            pcommon_publish.__insertAttachment(td.Upload_Attachemnts, td.Upload_Attachemnts_Name)
        }

        //set tag
        if (td.Tag != null && td.Tag != '') {
            pcommon_publish.__setTag(td.Tag)
        }

        //set read time
        if (td.NumOfMins != null && td.NumOfMins != '' && td.ArticleType != 'Event') {
            pcommon_publish.__setReadTime(td.NumOfMins)
        }

        //set Video Link
        if (td.VideoLink != null && td.VideoLink != '' && td.ArticleType != 'Event') {
            pcommon_publish.__setVideoLink(td.VideoLink)
        }

        //set featured image
        if (td.Upload_FeaturedImage != null && td.Upload_FeaturedImage != '') {
            pcommon_publish.__insertFeaturedImage(td.Upload_FeaturedImage)
        }

        //set region
        if (td.Region != null && td.Region != '') {
            pcommon_publish.__setRegions(td.Region, true)
        }

        //set Audience
        if (td.Audience != null && td.Audience != '') {
            pcommon_publish.__setAudience(td.Audience)
        }

        //set Author
        if (td.Author != null && td.Author != '' && td.ArticleType != 'Event') {
            pcommon_publish.__setAuthors(td.Author)
        }

    }

    this.__SubmitAndApprovedAnArticle = (td) => {

        this.__OpenPublishArticlePage(td.ArticleType)

        this.__ArticlePublish(td)

        this.__SubmitPublishArticle(td)

        this.__ApproveArticle(td)

    }

    this.__UserSaveAnArticleOnPublishPage = (td) => {

        this.__OpenPublishArticlePage(td.ArticleType)

        this.__ArticlePublish(td)

        this.__SavePublishArticle(td)

    }

    this.__UserSubmitAnArticleOnPublishPage = (td) => {

        this.__OpenPublishArticlePage(td.ArticleType)

        this.__ArticlePublish(td)

        this.__SubmitPublishArticle(td)

    }
};
module.exports = common_test;




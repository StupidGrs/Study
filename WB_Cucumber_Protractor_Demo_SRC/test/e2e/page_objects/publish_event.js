/**
 * Created by webber-ling on 30/09/2020.
 */



"use strict";
const chai = require('chai');
const chaiAsPromised = require('chai-as-promised');
chai.use(chaiAsPromised);
const expect = chai.expect;
const dateformat = require('dateformat');
const path = require('path');


const common_obj = require('../common/common_obj');
const fcommon_obj = new common_obj();
const util_windows = require('../common/utilities/util_windows');
const futil_windows = new util_windows();

// const common_page = require('./common_page');
// const pcommon_page = new common_page();


const publish_event = function () {

    /////////////////////////               page elements            ////////////////////////////////////

    this._txtWelcome = element.all(by.cssContainingText('p', 'Use this form to publish your event.')).first();
    this._txtEventName = element(by.css('[id="titleField"]'));
    this._txtEventExcerpt = element(by.css('[id="excerptField"]'));
    this._txtURLLink = element(by.css('[id="contentUrlField"]'));
    this._txtEventContent = element(by.css('[data-placeholder="Insert text here ..."]'));


    this._txtCompany = element(by.css('[placeholder="Select Company"][id^="mos-autocomplete-"]'));
    this._btnCompany_delete = element(by.css('[class="mos-c-autocomplete__input-close mos-c-autocomplete__input-close--icon ng-star-inserted"]'));
    this._lstEventType = element(by.css('[id="eventType"]'));
    this._txtLocation = element(by.css('[placeholder="Begin Typing"][id^="mos-autocomplete-"]'));


    this._txtStartDate = element(by.css('[id="publish-content-form-event-post-info_start_date"]')).element(by.css('span[class$="ng-star-inserted"]'));
    this._txtEndDate = element(by.css('[id="publish-content-form-event-post-info_end_date"]')).element(by.css('span[class$="ng-star-inserted"]'));
    this._txtStartTime = element(by.css('[id="startTime"]'));
    this._txtEndTime = element(by.css('[id="endTime"]'));
    this._labelStartTime = element(by.css('[for="startTime"]'));

    this._lstTaxonomies = element(by.css('[id="taxonomyField"]'));
    this._txtTags = element(by.css('[placeholder="Search Tags"][id^="mos-autocomplete-"]'));

    this._txtFeaturedImage = element(by.cssContainingText('mercer-accordion-static', 'Featured Image'));
    let _zoneFeaturedImage_block = element(by.css('[class^="src-c-publish-content-form-featured-image"]'));
    this._zoneFeaturedImage_clickable_Research = _zoneFeaturedImage_block.element(by.css('[class="mos-c-file-dropzone"]'));
    this._zoneFeaturedImage_delete = element(by.css('[id="publish-research-form_312295388"]'));


    this._txtFeaturedImage = element(by.cssContainingText('mercer-accordion-static', 'Featured Image'));
    this._txtRegions = element(by.cssContainingText('mercer-accordion-static', 'Regions'));
    this._txtAudience = element(by.cssContainingText('mercer-accordion-static', 'Audience'));

    this._chkRegion_AllRegions = element(by.css('[id="regionField-all"]'));
    this._chkRegion_Asia = element(by.css('[id="regionField-0"]'));

    /////////////////////////               page functions            ////////////////////////////////////


    this.__IsOnPage = async function(){
        return fcommon_obj.__isElementDisplayed(this._txtWelcome, '_txtWelcome');
    };

    this.__SetBasicInfo = async function (sName='', sExcerpt='', sURL='', sContent='') {

        await fcommon_obj.__setText('_txtEventName', this._txtEventName, sName);
        await fcommon_obj.__setText('_txtEventExcerpt', this._txtEventExcerpt, sExcerpt);
        await fcommon_obj.__setText('_txtURLLink', this._txtURLLink, sURL);
        // await fcommon_obj.__setText('_txtEventContent', this._txtEventContent, sContent);
        await fcommon_obj.__setText('_txtEventContent', this._txtEventContent, sContent, true, false);

    };

    this.__SetCompanyEventTypeLocation = async function (sCompany='', sEventType='', sLocation='') {


        if(sCompany!==''){
            await fcommon_obj.__executeScript(this._btnCompany_delete, '_btnCompany_delete', "click");
            await fcommon_obj.__click('_txtCompany', this._txtCompany);
            await fcommon_obj.__setText('_txtCompany', this._txtCompany, sCompany, false, false);
            let objCompany = element.all(by.cssContainingText('.mos-c-autocomplete__list__item', sCompany)).first();
            await fcommon_obj.__click(sCompany, objCompany);
        }

        if(sEventType!==''){
          await fcommon_obj.__selectByText('_lstEventType', this._lstEventType, sEventType);
        }

        if(sLocation!==''){
            await fcommon_obj.__click('_txtLocation', this._txtLocation);
            await fcommon_obj.__setText('_txtLocation', this._txtLocation, sLocation, false, false);
            await fcommon_obj.__click('_txtLocation', this._txtLocation);
            let objLocation = element(by.cssContainingText('.mos-c-autocomplete__list__item', sLocation));
            await fcommon_obj.__click(sLocation, objLocation);
        }

    };

    this.__SetDateTime = async function (sDate='', sTime='', bStartTrue_EndFalse=true) {


        if(bStartTrue_EndFalse){

            let startDate = dateformat(sDate, 'd-mmm-yyyy');
            await fcommon_obj.__executeScript(this._txtStartDate, 'startdate', "click");
            await __setCalender(startDate);
            await fcommon_obj.__executeScript(this._labelStartTime, '_labelStartTime', "click");
            await fcommon_obj.__setText('_txtStartTime', this._txtStartTime, sTime);
        }
        else{

            let endDate = dateformat(sDate, 'd-mmm-yyyy');
            await fcommon_obj.__executeScript(this._txtEndDate, 'endDate', "click");
            await __setCalender(endDate);
            await fcommon_obj.__executeScript(this._labelStartTime, '_labelStartTime', "click");
            await fcommon_obj.__setText('_txtEndTime', this._txtEndTime, sTime,);
        }



    };

    this.__SetTaxonomyTags = async function (sTaxonomy='', sTags='') {



        if(sTaxonomy!==''){
            await fcommon_obj.__selectByText('_lstTaxonomies', this._lstTaxonomies, sTaxonomy);
        }
        if(sTags!==''){

            await fcommon_obj.__executeScript(this._txtTags, '_txtTags', "click");
            await fcommon_obj.__setText('_txtTags', this._txtTags, sTags, false, false);
            let objTag = element(by.cssContainingText('.mos-c-autocomplete__list__item', sTags));
            await fcommon_obj.__executeScript(objTag, sTags, "click");

        }


    };

    this.__UploadImage = async function (sFileName) {

        await fcommon_obj.__executeScript(this._txtFeaturedImage, '_txtFeaturedImage', "click");
        await fcommon_obj.__click('_zoneFeaturedImage_clickable_Research', this._zoneFeaturedImage_clickable_Research, 2, 2);
        await __OpenFile(sFileName);

        await fcommon_obj.__wait4ElementVisible(this._zoneFeaturedImage_delete, '_zoneFeaturedImage_delete');
    };

    this.__SelectRegion = async function (sRegion) {

        await fcommon_obj.__executeScript(this._txtRegions, '_txtRegions', "click");
        await fcommon_obj.__executeScript(this._chkRegion_Asia, '_chkRegion_Asia', "click");
        await fcommon_obj.__isCheckBoxChecked(this._chkRegion_Asia, '_chkRegion_Asia', true);

    };


    const __setCalender = async function (dmmmyyyy, description = 'Calenda') {

        let currentDay = element(by.tagName('table'));

        await browser.getCapabilities().then(function(txt){
            // console.log(txt.get('browserName'));
            if(txt.get('browserName')==='internet explorer')
                currentDay = element(by.tagName('table'));
            if(txt.get('browserName')==='chrome')
                currentDay = element(by.tagName('mercer-calendar'));

        });

        let exp_day = dmmmyyyy.split('-')[0];

        let obj;

        if (Number(exp_day) <= 15)
            obj = currentDay.all(by.css('td')).filter(function (elem, index) {
                return elem.getText().then(function (text) {
                    ///////// console.log('index:' + index);
                    //////// console.log(text);
                    return text === exp_day;
                });
            }).first();



        if (Number(exp_day) > 15)
            obj = currentDay.all(by.css('td')).filter(function (elem, index) {
                return elem.getText().then(function (text) {

                    return text === exp_day;
                });
            }).last();

        await fcommon_obj.__executeScript(obj.element(by.css('[class="mos-c-calendar__day"]')), exp_day, "click");

    };

    const __OpenFile = async function (filename, browserName = 'chrome') {

        let absolutePath_file, absolutePath_exe, actCmd;

        absolutePath_file = path.resolve(__dirname, filename);



        if(browserName==='chrome')
            absolutePath_exe = path.resolve(__dirname, '../common/utilities/OpenDataFile.exe');
        if(browserName==='internet explorer')
            absolutePath_exe = path.resolve(__dirname, '../common/utilities/OpenDataFile_IE.exe');
        if(browserName==='firefox')
            absolutePath_exe = path.resolve(__dirname, '../common/utilities/OpenDataFile_ff.exe');


        actCmd = '"' + absolutePath_exe + '"' + ' ' + '"' + absolutePath_file + '"';
        await futil_windows.__runCmd(actCmd);
    };

};
module.exports = publish_event;





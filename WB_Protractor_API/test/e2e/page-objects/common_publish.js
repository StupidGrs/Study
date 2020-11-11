/**
 * Created by webber-ling on 7/10/2020.
 */


"use strict";
const ec = protractor.ExpectedConditions;
const path = require('path');
const dateformat = require('dateformat');
const common_obj = require('../common/common_obj');
const fcommon_obj = new common_obj();
const util_windows = require('../common/utilities/util_windows');
const futil_windows = new util_windows();
const common_page = require('./common_page');
const pcommon_page = new common_page();


const common_publish = function () {

    /////////////////////////               page elements            ////////////////////////////////////

    this._txtHeader = element(by.css('h2[id^="publish-content-form_"]'));

    this._btnPublish = element(by.css('[id="header_855538167"]'));

    this._iconPublish_Event = element(by.css('[alt="Event"]'));
    this._iconPublish_NewsBlog = element(by.css('[alt="News/Blog"]'));
    this._iconPublish_ResearchWhitePaper = element(by.css('[alt="Research/WhitePaper"]'));

    this._btnCancel = element(by.css('[id="cancelPublish"]'));
    this._btnSaveDraft = element(by.css('[id="publish-content-form-action-buttons_save-draft_41165451"]'));
    this._btnSubmit = element(by.css('[id="publish-content-form-action-buttons_300860620"]'));
    this._btnSubmitAndAddAnother = element(by.css('[id="publishAndSubmitAnother"]'));

    this._txtToastOutletMsg = element(by.css('[id="toast-outlet-dismissable_message"]'));
    this._btnToastOutletMsg_close = element(by.css('[class^="ng-tns-c3-"][icon="close"]'));

    this._btnClosePublishCancel = element(by.css('[id=id="exit-modal_cancel"]'));
    this._btnClosePublishContinue = element(by.css('[id^="exit-modal_continue"]'));

    ////////////////////////////////     Event     ///////////////////////////
    this._txtEventName = element(by.css('[id="titleField"]'));
    this._txtEventExcerpt = element(by.css('[id="excerptField"]'));
    this._txtURLLink = element(by.css('[id="contentUrlField"]'));
    this._txtEventContent = element(by.css('[data-placeholder="Insert text here ..."]'));

    this._txtCompany = element(by.css('[placeholder="Select Company"][id^="mos-autocomplete-"]'));
    // this._txtCompany = element(by.css('[id="mos-autocomplete-2"]'));
    this._btnCompany_delete = element(by.css('[class="mos-c-autocomplete__input-close mos-c-autocomplete__input-close--icon ng-star-inserted"]'));


    this._lstEventType = element(by.css('[id="eventType"]'));
    // this._txtLocation = element(by.css('[id="mos-autocomplete-3"]'));
    // this._txtLocation = element(by.css('.mos-c-autocomplete__input.ng-pristine.ng-invalid'))
    this._txtLocation = element(by.css('[placeholder="Begin Typing"][id^="mos-autocomplete-"]'));

    this._toggleInternalOnly = element(by.css('mercer-slide-toggle[formcontrolname="internal_use_only"]'))//.element(by.css('[id^="publish-content-form-article-post-info"]'));
    this._toggleInternalOnly_bar = this._toggleInternalOnly.element(by.css('[class="mos-c-slide-toggle__bar"]'));
    this._toggleInternalOnly_setting = this._toggleInternalOnly.element(by.css('[class="mos-c-slide-toggle__input"]'))

    this._txtStartDate = element(by.css('[id="publish-content-form-event-post-info_start_date"]')).element(by.css('span[class$="ng-star-inserted"]'));
    this._txtEndDate = element(by.css('[id="publish-content-form-event-post-info_end_date"]')).element(by.css('span[class$="ng-star-inserted"]'));
    this._txtStartTime = element(by.css('[id="startTime"]'));
    this._txtEndTime = element(by.css('[id="endTime"]'));
    this._labelStartTime = element(by.css('[for="startTime"]'));


    this._lstTaxonomies = element(by.css('[id="taxonomyField"]'));
    this._txtTags = element(by.css('[placeholder="Search Tags"][id^="mos-autocomplete-"]'));

    this._tagInternalOnly = element(by.css('[id=tag-chip-autocomplete_chip-title_internal-only]')).element(by.cssContainingText('.mos-c-chip.mos-c-chip--md.mos-t-chip--secondary-alt', 'Internal-Only'))
    // this._tagInternalOnly = element(by.css('[id=tag-chip-autocomplete_chip-title_internal-only]'))

    this._txtFeaturedImage = element(by.cssContainingText('mercer-accordion-static', 'Featured Image'));
    this._txtRegions = element(by.cssContainingText('mercer-accordion-static', 'Regions'));
    this._txtAudience = element(by.cssContainingText('mercer-accordion-static', 'Audience'));

    this._accordionAudience = element(by.cssContainingText('.mos-c-accordion.mos-c-accordion--border', 'Audience'));
    this._accordionReadTime = element(by.cssContainingText('.mos-c-accordion.mos-c-accordion--border', 'Read time'));
    this._accordionFeaturedImage = element(by.cssContainingText('.mos-c-accordion.mos-c-accordion--border', 'Featured Image'));
    this._accordionVideoLink = element(by.cssContainingText('.mos-c-accordion.mos-c-accordion--border', 'Video Link'));
    this._accordionRegions = element(by.cssContainingText('.mos-c-accordion.mos-c-accordion--border', 'Regions'));
    this._accordionAuthors = element(by.cssContainingText('.mos-c-accordion.mos-c-accordion--border', 'Authors'));
    this._accordionCollapsed = 'collapsed'
    this._accordionExpanded = 'expanded'

    this._zoneFeaturedImage = element(by.css('[class*=dropzone__upload-message]'));  // from old scripts
    this._zoneFeaturedImage_clickable = element(by.css('[class="mos-c-file-dropzone"]'));
    this._zoneFeaturedImage_delete = element(by.css('[id="publish-research-form_312295388"]'));


    this._chkRegion_AllRegions = element(by.css('[id="regionField-all"]'));
    this._chkRegion_Asia = element(by.css('[id="regionField-0"]'));
    this._chkRegion_AustraliaNZ = element(by.css('[id="regionField-1"]'));
    this._chkRegion_Canada = element(by.css('[id="regionField-2"]'));
    this._chkRegion_EMEA = element(by.css('[id="regionField-3"]'));
    this._chkRegion_Japan = element(by.css('[id="regionField-4"]'));
    this._chkRegion_UK = element(by.css('[id="regionField-5"]'));
    this._chkRegion_US = element(by.css('[id="regionField-6"]'));


    this._txtRegion_AllRegions = element(by.css('[for="regionField-all"]'));
    this._txtRegion_Asia = element(by.css('[for="regionField-0"]'));
    this._txtRegion_AustraliaNZ = element(by.css('[for="regionField-1"]'));
    this._txtRegion_Canada = element(by.css('[for="regionField-2"]'));
    this._txtRegion_EMEA = element(by.css('[for="regionField-3"]'));
    this._txtRegion_Japan = element(by.css('[for="regionField-4"]'));
    this._txtRegion_UK = element(by.css('[for="regionField-5"]'));
    this._txtRegion_US = element(by.css('[for="regionField-6"]'));


    this._chkAudience_AssetManager = element(by.css('[id="roleField-0"]'));
    this._chkAudience_AssetOwner = element(by.css('[id="roleField-1"]'));
    this._chkAudience_MercerConsultant = element(by.css('[id="roleField-2"]'));
    this._chkAudience_ExternalConsultant = element(by.css('[id="roleField-3"]'));
    this._chkAudience_IndustryVendor = element(by.css('[id="roleField-4"]'));

    this._txtAudience_AssetManager = element(by.css('[for="roleField-0"]'));
    this._txtAudience_AssetOwner = element(by.css('[for="roleField-1"]'));
    this._txtAudience_MercerConsultant = element(by.css('[for="roleField-2"]'));
    this._txtAudience_ExternalConsultant = element(by.css('[for="roleField-3"]'));
    this._txtAudience_IndustryVendor = element(by.css('[for="roleField-4"]'));


    ////////////////////////////////     Research & News     ///////////////////////////

    this._labelTitle = element(by.css('[id="publish-content-form-content-block_275549381"]'));
    this._txtTitle = element(by.css('[id="titleField"]'));
    this._txtExecutiveSummary = this._txtEventExcerpt;
    this._txtDate = element(by.css('[class="mos-c-datepicker__input-date"]'));
    this._lstResearchType = element(by.css('[id="researchType"]'));

    this._txtReadTime = element(by.cssContainingText('mercer-accordion-static', 'Read time'));
    this._txtNumOfMins = element(by.css('[id="read_time"]'));

    this._txtVideoLink = element(by.cssContainingText('mercer-accordion-static', 'Video Link'));
    this._txtVideoEmbed = element(by.css('[id="videoLinkField"]'));


    this._txtAuthors = element(by.cssContainingText('mercer-accordion-static', 'Authors'));
    this._txtAuthor = element(by.css('[id="authorField"]'));

    let _zoneFeaturedImage_block = element(by.css('[class^="src-c-publish-content-form-featured-image"]'))
    // this._zoneFeaturedImage_clickable_Research = element.all(by.css('[class="mos-c-file-dropzone"]')).last();
    this._zoneFeaturedImage_clickable_Research = _zoneFeaturedImage_block.element(by.css('[class="mos-c-file-dropzone"]'))
    this._zoneFeaturedImage_input = _zoneFeaturedImage_block.element(by.css('input[type="file"]'));
    this._zoneFeaturedImage_uploadedImg = element(by.css('[id="publish-research-form_949791479"]'));
    this._zoneFeaturedImage_delete = element(by.css('[id="publish-research-form_312295388"]'));


    // this._zoneUploadAttachment_clickable = element.all(by.css('[class="mos-c-file-dropzone"]')).first();
    this._zoneUploadAttachment_block = element(by.css('[class="small-12 columns"][id^="publish-content-form-content-block"]'))
    this._zoneUploadAttachment_block_name = this._zoneUploadAttachment_block.element(by.css('[class="src-c-publish-content-form__label"]'))
    this._zoneUploadAttachment_clickable = this._zoneUploadAttachment_block.element(by.css('[class="mos-c-file-dropzone"]'))
    // this._txtResetDropzoneAttachments  = element(by.cssContainingText('a', 'Reset Dropzone Attachments'));
    // this._zoneUploadAttachment_delete = element(by.css('[id="publish-research-form_312295388"]'));
    this._zoneUploadAttachment_block_input = this._zoneUploadAttachment_block.element(by.css('input[type="file"]'))
    this._zoneUploadAttachment_block_footer_file = (filename) => {
        return element(by.cssContainingText('mercer-chip', filename))
    }

    this._btnZoneUploadAttachment_block_footer_fileRemove = (filename) => this._zoneUploadAttachment_block_footer_file(filename).element(by.css('[icon="close"]'))
    this._lstZoneUploadAttachment_block_footer_file = element(by.css('[id="publish-content-form-content-block_413142645"]'))

    ////////////////////////////////     Research & News functions    ///////////////////////////

    this.__wait4UploadAttachment = (filename) => {
        fcommon_obj.__wait4ElementVisible(element(by.cssContainingText('span', filename)), filename);
    }

    this.__zoneUploadAttachment_block_footer_fileRemove = (filename) => {
        fcommon_obj.__executeScript(this._btnZoneUploadAttachment_block_footer_fileRemove(filename), '_btnZoneUploadAttachment_block_footer_fileRemove', "click");
        fcommon_obj.__isElementNotPresent(this._zoneUploadAttachment_block_footer_file(filename), filename + 'not removed')
    }


    /////////////////////////               page functions            ////////////////////////////////////


    /***
     * pcommon_publish.__Publish('Event');
     * pcommon_publish.__Publish('News/Blog');
     * pcommon_publish.__Publish('Research/WhitePaper');
     * @param sType
     * @private
     */
    this.__Publish = function (sType) {
        fcommon_obj.__executeScript(this._btnPublish, '_btnPublish', "click");


        if (sType === 'Event') {
            fcommon_obj.__executeScript(this._iconPublish_Event, '_iconPublish_Event', "click");
            expect(this._txtHeader.getText()).toBe('Publish Your Event');
            browser.sleep(browser.params.actionDelay.step_delay)
        }

        if (sType === 'News/Blog') {
            fcommon_obj.__executeScript(this._iconPublish_NewsBlog, '_iconPublish_NewsBlog', "click");
            expect(this._txtHeader.getText()).toBe('Publish Your News');
            browser.sleep(browser.params.actionDelay.step_delay)
        }

        if (sType === 'Research/WhitePaper') {
            fcommon_obj.__executeScript(this._iconPublish_ResearchWhitePaper, '_iconPublish_ResearchWhitePaper', "click");
            expect(this._txtHeader.getText()).toBe('Publish Your Research');
            browser.sleep(browser.params.actionDelay.step_delay)
        }



        // fcommon_obj.__click('_iconPublish_Event', this._iconPublish_Event);

        // fcommon_obj.__wait4ElementVisible(element.all(by.css('[name=Username]')).first(), 'Login-Username');

    };


    this.__OpenFile = function (filename, browserName = 'chrome') {

        let absolutePath_file, absolutePath_exe, actCmd;

        absolutePath_file = path.resolve(__dirname, filename);



            if(browserName==='chrome')
                absolutePath_exe = path.resolve(__dirname, '../common/utilities/OpenDataFile.exe');
            if(browserName==='internet explorer')
                absolutePath_exe = path.resolve(__dirname, '../common/utilities/OpenDataFile_IE.exe');
            if(browserName==='firefox')
                absolutePath_exe = path.resolve(__dirname, '../common/utilities/OpenDataFile_ff.exe');


        actCmd = '"' + absolutePath_exe + '"' + ' ' + '"' + absolutePath_file + '"';
        futil_windows.__runCmd(actCmd);
    };

    this.__Cancel = (bChangeTrue_NoChangeFalse = true) => {
        fcommon_obj.__executeScript(this._btnCancel, '_btnCancel', "click");
        if (bChangeTrue_NoChangeFalse)
            fcommon_obj.__executeScript(this._btnClosePublishContinue, '_btnClosePublishContinue', "click");
    }

    this.__CancelWithChange = () => {
        fcommon_obj.__executeScript(this._btnCancel, '_btnCancel', "click");
        fcommon_obj.__executeScript(this._btnClosePublishContinue, '_btnClosePublishContinue', "click");
    }

    this.__CancelWithoutChange = () => {
        fcommon_obj.__executeScript(this._btnCancel, '_btnCancel', "click");
    }

    this.__SaveDraft = (SuccessMsg) => {
        fcommon_obj.__executeScript(this._btnSaveDraft, '_btnSaveDraft', "click");
        fcommon_obj.__wait4ElementVisible(this._txtToastOutletMsg, '_txtToastOutletMsg');

        let text = this._txtToastOutletMsg.getText().then(function (e) {
            return e.replace(/\s+/g, ' ')
        });
        expect(text).toBe(SuccessMsg);
        fcommon_obj.__executeScript(this._btnToastOutletMsg_close, '_btnToastOutletMsg_close', "click");
    }

    this.__Submit = (SuccessMsg) => {
        fcommon_obj.__executeScript(this._btnSubmit, '_btnSubmit', "click");
        fcommon_obj.__wait4ElementVisible(this._txtToastOutletMsg, '_txtToastOutletMsg');

        let text = this._txtToastOutletMsg.getText().then(function (e) {
            return e.replace(/\s+/g, ' ')
        });
        expect(text).toBe(SuccessMsg);
        fcommon_obj.__executeScript(this._btnToastOutletMsg_close, '_btnToastOutletMsg_close', "click");
        browser.sleep(browser.params.userSleep.medium)
    }

    this.__SubmitAndAddAnother = (SuccessMsg) => {
        fcommon_obj.__executeScript(this._btnSubmitAndAddAnother, '_btnSubmitAndAddAnother', "click");
        fcommon_obj.__wait4ElementVisible(this._txtToastOutletMsg, '_txtToastOutletMsg');

        let text = this._txtToastOutletMsg.getText().then(function (e) {
            return e.replace(/\s+/g, ' ')
        });
        expect(text).toBe(SuccessMsg);
        fcommon_obj.__executeScript(this._btnToastOutletMsg_close, '_btnToastOutletMsg_close', "click");
        browser.sleep(browser.params.userSleep.medium)
    }

    this.__setTitle = (sTitle) => {
        fcommon_obj.__setText('_txtTitle', this._txtTitle, sTitle);
        expect(this._txtTitle.getAttribute('value')).toEqual(sTitle)
    }

    this.__setExecutiveSummary = (sExecutiveSummary) => {
        fcommon_obj.__setText('_txtEventExcerpt', this._txtEventExcerpt, sExecutiveSummary);
        expect(this._txtEventExcerpt.getAttribute('value')).toEqual(sExecutiveSummary)
    }

    this.__setContentLink = (sURLLink) => {
        fcommon_obj.__setText('_txtURLLink', this._txtURLLink, sURLLink);
        expect(this._txtURLLink.getAttribute('value')).toEqual(sURLLink)
    }

    this.__setEventContent = (sEventContent) => {
        fcommon_obj.__setText('_txtEventContent', this._txtEventContent, sEventContent, false, false);
        expect(this._txtEventContent.getText()).toEqual(sEventContent)
    }

    this.__setFullPostContent = (sFullPostContent) => {
        fcommon_obj.__setText('_FullPostContent', this._txtEventContent, sFullPostContent, false, false);
        expect(this._txtEventContent.getText()).toEqual(sFullPostContent)
    }

    this.__setContent = (sContent) => {
        fcommon_obj.__setText('_txtContent', this._txtEventContent, sContent, false, false);
        expect(this._txtEventContent.getText()).toEqual(sContent)
    }

    this.__setInternalOnlyToggle = (bSetTrue_NotSetFalse = true) => {
        this._toggleInternalOnly_setting.isSelected().then((setting) => {
            if (setting) {
                if (bSetTrue_NotSetFalse) {
                    expect(this._toggleInternalOnly_setting.isSelected()).toBe(bSetTrue_NotSetFalse)
                    return
                }
                else {
                    fcommon_obj.__executeScript(this._toggleInternalOnly_bar, '_toggleInternalOnly_bar', "click")
                    expect(this._toggleInternalOnly_setting.isSelected()).toBe(bSetTrue_NotSetFalse)
                    return
                }
            }
            else {
                if (bSetTrue_NotSetFalse) {
                    fcommon_obj.__executeScript(this._toggleInternalOnly_bar, '_toggleInternalOnly_bar', "click")
                    expect(this._toggleInternalOnly_setting.isSelected()).toBe(bSetTrue_NotSetFalse)
                    return
                }
                else {
                    expect(this._toggleInternalOnly_setting.isSelected()).toBe(bSetTrue_NotSetFalse)
                    return
                }
            }
        })
    }

    this.__setDate = (dCurrentDate) => {
        // let dCurrentDate = new Date();
        const cDate = dateformat(dCurrentDate, 'd-mmm-yyyy');
        const sDate = dateformat(dCurrentDate, 'mm/dd/yyyy')
        fcommon_obj.__executeScript(this._txtDate, '_txtDate', "click");
        pcommon_page.__setCalender(cDate);
        fcommon_obj.__executeScript(this._labelTitle, '_labelTitle', "click");
        expect(this._txtDate.getText()).toEqual(sDate)
    }

    this.__setStartDate = (dStartDate) => {
        // let currentDate = new Date();

        const cStartDate = dateformat(dStartDate, 'd-mmm-yyyy');
        const sStartDate = dateformat(dStartDate, 'mm/dd/yyyy')
        fcommon_obj.__executeScript(this._txtStartDate, '_txtStartDate', "click");
        pcommon_page.__setCalender(cStartDate);
        fcommon_obj.__executeScript(this._labelStartTime, '_labelStartTime', "click");
        expect(this._txtStartDate.getText()).toEqual(sStartDate)
    }

    this.__setEndDate = (dEndDate) => {
        // let currentDate = new Date();

        const cEndDate = dateformat(dEndDate.setDate(dEndDate.getDate() + 1), 'd-mmm-yyyy');
        const sEndDate = dateformat(dEndDate, 'mm/dd/yyyy')
        fcommon_obj.__executeScript(this._txtEndDate, '_txtEndDate', "click");
        pcommon_page.__setCalender(cEndDate);
        fcommon_obj.__executeScript(this._labelStartTime, '_labelEndTime', "click");
        expect(this._txtEndDate.getText()).toEqual(sEndDate)
    }

    this.__setStartTime = (sTime) => {
        fcommon_obj.__setText('_txtStartTime', this._txtStartTime, sTime);
        expect(this._txtStartTime.getAttribute('value')).toEqual(sTime)
    }

    this.__setEndTime = (sTime) => {
        fcommon_obj.__setText('_txtEndTime', this._txtEndTime, sTime);
        expect(this._txtEndTime.getAttribute('value')).toEqual(sTime)
    }

    this.__setResearchType = (sResearchType) => {
        fcommon_obj.__selectByText('_lstResearchType', this._lstResearchType, sResearchType);
        expect(this._lstResearchType.getAttribute('value')).toContain(sResearchType)
    }

    this.__setEventType = (sEventType) => {
        fcommon_obj.__selectByText('_lstEventType', this._lstEventType, sEventType);
        expect(this._lstEventType.getAttribute('value')).toContain(sEventType)
    }

    this.__setLocation = (sLocation) => {
        fcommon_obj.__click('_txtLocation', this._txtLocation);
        fcommon_obj.__setText('_txtLocation', this._txtLocation, sLocation, false, false);
        browser.sleep(browser.params.userSleep.medium)
        let objLocation = element(by.cssContainingText('.mos-c-autocomplete__list__item', sLocation));
        fcommon_obj.__click(sLocation, objLocation);
        expect(this._txtLocation.getAttribute('value')).toContain(sLocation)
    }

    this.__setCompany = (sCompany) => {
        fcommon_obj.__executeScript(this._btnCompany_delete, '_btnCompany_delete', "click");
        fcommon_obj.__click('_txtCompany', this._txtCompany);
        fcommon_obj.__setText('_txtCompany', this._txtCompany, sCompany, false, false);
        let objCompany = element(by.cssContainingText('.mos-c-autocomplete__list__item', sCompany));
        fcommon_obj.__click(sCompany, objCompany);
        expect(this._txtCompany.getAttribute('value')).toEqual(sCompany)
    }

    this.__setTaxonomies = (sTaxonomies) => {
        fcommon_obj.__selectByText('_lstTaxonomies', this._lstTaxonomies, sTaxonomies);
        expect(element(by.css('[id="taxonomy-form"]')).element(by.cssContainingText('.mos-c-chip.mos-c-chip--md.mos-t-chip--secondary-alt', sTaxonomies)).isDisplayed()).toBe(true)
    }

    this.__setTag = (sTag) => {
        fcommon_obj.__executeScript(this._txtTags, '_txtTags', "click");
        fcommon_obj.__setText('_txtTags', this._txtTags, sTag, false, false);
        let objTag = element(by.cssContainingText('.mos-c-autocomplete__list__item', sTag));
        fcommon_obj.__executeScript(objTag, sTag, "click");
        expect(element(by.css('[id="tag-chip-autocomplete"]')).element(by.cssContainingText('.mos-c-chip.mos-c-chip--md.mos-t-chip--secondary-alt', sTag)).isDisplayed()).toBe(true)
    }

    this.__setReadTime = (sReadTime) => {
        this._accordionReadTime.getAttribute('class').then((cls) => {
            if (cls.indexOf(this._accordionExpanded) != -1) {
                fcommon_obj.__setText('_txtNumOfMins', this._txtNumOfMins, sReadTime);
                expect(this._txtNumOfMins.getAttribute('value')).toEqual(sReadTime)
            }
            else {
                fcommon_obj.__executeScript(this._txtReadTime, '_txtReadTime', "click");
                fcommon_obj.__setText('_txtNumOfMins', this._txtNumOfMins, sReadTime);
                expect(this._txtNumOfMins.getAttribute('value')).toEqual(sReadTime)
            }
        })
    }

    this.__setVideoLink = (sVideoLink) => {
        this._accordionVideoLink.getAttribute('class').then((cls) => {
            if (cls.indexOf(this._accordionExpanded) != -1) {
                fcommon_obj.__setText('_txtVideoEmbed', this._txtVideoEmbed, sVideoLink, );
                expect(this._txtVideoEmbed.getAttribute('value')).toEqual(sVideoLink)
            }
            else {
                fcommon_obj.__executeScript(this._txtVideoLink, '_txtVideoLink', "click");
                fcommon_obj.__setText('_txtVideoEmbed', this._txtVideoEmbed, sVideoLink, );
                expect(this._txtVideoEmbed.getAttribute('value')).toEqual(sVideoLink)
            }
        })
    }

    this.__setCheckBox = (obj, bSetTrue_NotSetFalse = true) => {
        obj.isSelected().then((setting) => {
            if (setting) {
                if (bSetTrue_NotSetFalse) {
                    expect(obj.isSelected()).toBe(bSetTrue_NotSetFalse)
                    return
                }
                else {
                    fcommon_obj.__executeScript(obj, obj, "click")
                    expect(obj.isSelected()).toBe(bSetTrue_NotSetFalse)
                    return
                }
            }
            else {
                if (bSetTrue_NotSetFalse) {
                    fcommon_obj.__executeScript(obj, obj, "click")
                    expect(obj.isSelected()).toBe(bSetTrue_NotSetFalse)
                    return
                }
                else {
                    expect(obj.isSelected()).toBe(bSetTrue_NotSetFalse)
                    return
                }
            }
        })
    }

    this.__setRegions = (obj, bSetTrue_NotSetFalse = true) => {
        this._accordionRegions.getAttribute('class').then((cls) => {
            if (cls.indexOf(this._accordionExpanded) != -1)
                this.__setCheckBox(obj, bSetTrue_NotSetFalse)
            else {
                fcommon_obj.__executeScript(this._accordionRegions, '_accordionRegions', "click");
                this.__setCheckBox(obj, bSetTrue_NotSetFalse)
            }
        })
    }

    this.__setAudience = (obj, bSetTrue_NotSetFalse = true) => {
        this._accordionAudience.getAttribute('class').then((cls) => {
            if (cls.indexOf(this._accordionExpanded) != -1)
                this.__setCheckBox(obj, bSetTrue_NotSetFalse)
            else {
                fcommon_obj.__executeScript(this._txtAudience, '_txtAudience', "click");
                this.__setCheckBox(obj, bSetTrue_NotSetFalse)
            }
        })
    }

    this.__setAuthors = (sAuthor) => {
        this._accordionAuthors.getAttribute('class').then((cls) => {
            if (cls.indexOf(this._accordionExpanded) != -1)
                fcommon_obj.__setText('_txtAuthor', this._txtAuthor, sAuthor, );
            else {
                fcommon_obj.__executeScript(this._txtAuthors, '_txtAuthors', "click");
                fcommon_obj.__setText('_txtAuthor', this._txtAuthor, sAuthor, );
            }
        })
    }

    this.__insertAttachment = (sFilePath, sFileName) => {
        fcommon_obj.__ElementPresent('_zoneUploadAttachment_block_input', this._zoneUploadAttachment_block_input)
        this._zoneUploadAttachment_block_input.sendKeys(sFilePath).then(function (err) {
            if (err) fcommon_obj.__log(err)
        })
        this.__wait4UploadAttachment(sFileName)
        expect(element(by.cssContainingText('span', sFileName)).isDisplayed()).toBe(true)
        browser.sleep(browser.params.actionDelay.step_delay)
    }

    this.__insertFeaturedImage = (sImage) => {
        this._accordionFeaturedImage.getAttribute('class').then((cls) => {
            if (cls.indexOf(this._accordionExpanded) != -1) {
                fcommon_obj.__ElementPresent('_zoneUploadAttachment_block_input', this._zoneFeaturedImage_input)
                this._zoneFeaturedImage_input.sendKeys(sImage).then(function (err) {
                    if (err) fcommon_obj.__log(err)
                })
                fcommon_obj.__wait4ElementVisible(this._zoneFeaturedImage_delete, '_zoneFeaturedImage_delete')
            }
            else {
                fcommon_obj.__executeScript(this._txtFeaturedImage, '_txtFeaturedImage', "click");
                fcommon_obj.__ElementPresent('_zoneUploadAttachment_block_input', this._zoneFeaturedImage_input)
                this._zoneFeaturedImage_input.sendKeys(sImage).then(function (err) {
                    if (err) fcommon_obj.__log(err)
                })
                fcommon_obj.__wait4ElementVisible(this._zoneFeaturedImage_delete, '_zoneFeaturedImage_delete')
            }
        })
    }

};
module.exports = common_publish;



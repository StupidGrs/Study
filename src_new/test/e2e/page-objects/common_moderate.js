/**
 * Created by webber-ling on 7/30/2020.
 */


"use strict";
const ec = protractor.ExpectedConditions;
const path = require('path');
const dateformat = require('dateformat');
const common_obj = require('../common/common_obj');
const fcommon_obj = new common_obj();
const util_windows = require('../common/utilities/util_windows');
const futil_windows = new util_windows();



const common_moderate = function () {

    /////////////////////////               page elements            ////////////////////////////////////


    this._txtHeader = element(by.css('[id="content-moderation-form_439097539"]'));


    this._txtCompany = element(by.css('[placeholder="Begin typing company name"]'));

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

    this._zoneFeaturedImage_uploadedImg = element(by.css('[id="content-moderation-form_963172886"]'));
    this._zoneFeaturedImage_delete = element(by.css('[id="content-moderation-form_218098969"]'));

    // let _zoneUploadAttachment_block = element(by.cssContainingText('dev', 'Attachments'))
    this._zoneUploadAttachment_block_name = element(by.css('label[for="attachmentsField"]'))
    this._zoneUploadAttachment_clickable = element(by.css('mercer-file-dropzone[id="attachmentsField"]'))

    this._zoneUploadAttachment_block_footer_file = (filename) => {
        return element(by.cssContainingText('mercer-chip', filename))
    }

    this._btnZoneUploadAttachment_block_footer_fileRemove = (filename) => this._zoneUploadAttachment_block_footer_file(filename).element(by.css('[icon="close"]'))


    this._toggleInternalOnly = element(by.css('mercer-slide-toggle[formcontrolname="internal_use_only"]'))//.element(by.css('[id^="publish-content-form-article-post-info"]'));
    this._toggleInternalOnly_bar = this._toggleInternalOnly.element(by.css('[class="mos-c-slide-toggle__bar"]'));
    this._toggleInternalOnly_setting = this._toggleInternalOnly.element(by.css('[class="mos-c-slide-toggle__input"]'))

    this._txtTags = element(by.css('[placeholder="Search Tags"][id^="mos-autocomplete-"]'));

    this._tagInternalOnly = element(by.css('[id=tag-chip-autocomplete_chip-title_internal-only]')).element(by.cssContainingText('.mos-c-chip.mos-c-chip--md.mos-t-chip--secondary-alt', 'Internal-Only'))
    // this._tagInternalOnly = element(by.css('[id=tag-chip-autocomplete_chip-title_internal-only]'))


    this._btnSave = element(by.cssContainingText('button', 'Save'));

    this._btnCancel = element(by.cssContainingText('button', 'Cancel'));


    this._btnCancelAllChanges = element(by.css('[class="mos-c-modal__footer"]')).element(by.cssContainingText('button', 'Cancel all changes'));
    this._btnBackToEditing = element(by.css('[class="mos-c-modal__footer"]')).element(by.cssContainingText('button', 'Back to editing'));


    ////////////////////////////////     Research & News functions    ///////////////////////////

    this.__wait4UploadAttachment = (filename) => {
        fcommon_obj.__wait4ElementVisible(this._zoneUploadAttachment_block_footer_file(filename), filename);
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
        }

        if (sType === 'News/Blog') {
            fcommon_obj.__executeScript(this._iconPublish_NewsBlog, '_iconPublish_NewsBlog', "click");
            expect(this._txtHeader.getText()).toBe('Publish Your News');
        }

        if (sType === 'Research/WhitePaper') {
            fcommon_obj.__executeScript(this._iconPublish_ResearchWhitePaper, '_iconPublish_ResearchWhitePaper', "click");
            expect(this._txtHeader.getText()).toBe('Publish Your Research');
        }



        // fcommon_obj.__click('_iconPublish_Event', this._iconPublish_Event);

        // fcommon_obj.__wait4ElementVisible(element.all(by.css('[name=Username]')).first(), 'Login-Username');

    };


    this.__OpenFile = function (filename) {

        let absolutePath_file, absolutePath_exe, actCmd;

        absolutePath_file = path.resolve(__dirname, filename);
        absolutePath_exe = path.resolve(__dirname, '../common/utilities/OpenDataFile.exe');
        actCmd = '"' + absolutePath_exe + '"' + ' ' + '"' + absolutePath_file + '"';
        futil_windows.__runCmd(actCmd);
    };

    this.__Cancel = (bChangeTrue_NoChangeFalse = true) => {
        fcommon_obj.__executeScript(this._btnCancel, '_btnCancel', "click");
        if (bChangeTrue_NoChangeFalse)
            fcommon_obj.__executeScript(this._btnCancelAllChanges, '_btnCancelAllChanges', "click");
    }

    this.__CancelAllChange = () => {
        fcommon_obj.__executeScript(this._btnCancel, '_btnCancel', "click");
        fcommon_obj.__executeScript(this._btnCancelAllChanges, '_btnCancelAllChanges', "click");
    }

    this.__CancelWithChange = () => {
        fcommon_obj.__executeScript(this._btnCancel, '_btnCancel', "click");
        fcommon_obj.__executeScript(this._btnCancelAllChanges, '_btnCancelAllChanges', "click");
    }

    this.__CancelWithoutChange = () => {
        fcommon_obj.__executeScript(this._btnCancel, '_btnCancel', "click");
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

};
module.exports = common_moderate;



/**
 * Created by webber-ling on 7/22/2020.
 */


"use strict";

const common_obj = require('../common/common_obj');
const fcommon_obj = new common_obj();
const common_page = require('./common_page');
const pcommon_page = new common_page();


const contentList_page = function () {

    /////////////////////////               page elements            ////////////////////////////////////

    this._lstSelectStatus = element(by.css('[id=select-status]'));
    this._lstSelectType = element(by.css('[id=select-type]'));
    this._txtSearchContent = element(by.css('[id=search-input]'));
    this._labelSearchContent = element(by.css('[for=searchInput]'));

    this._txtModalContent = element(by.css('[id="textareaItemResizable"]'));
    this._btnModalCancel = element(by.css('[id="reject-modal_head_cancel"]'));
    this._btnModalReject = element(by.css('[id="reject-modal_head_reject"]'));

    /////////////////////////               page functions            ////////////////////////////////////


    /***
     * pcontentList.__doSearch('Waiting for approval', 'research post', 'auto');
     * pcontentList.__doSearch('Waiting for approval', 'blog/news post', td_News.Title);
     * pcontentList.__doSearch('Waiting for approval', 'event', td_EventDetails.EventName);
     *
     * @param sStatus
     * @param sType
     * @param sSearchContent
     * @private
     */
    this.__doSearch = function (sStatus, sType, sSearchContent = "", bSelect = false) {

        fcommon_obj.__selectByText('_lstSelectStatus', this._lstSelectStatus, sStatus);
        fcommon_obj.__selectByText('_lstSelectType', this._lstSelectType, sType);
        fcommon_obj.__setText('_txtSearchContent', this._txtSearchContent, sSearchContent);
        // fcommon_obj.__click('_labelSearchContent', this._labelSearchContent);

        fcommon_obj.__wait4ElementVisible(element(by.cssContainingText('mercer-table-td', sSearchContent)), sSearchContent);

        if (bSelect) {
            let tbl = element(by.tagName('tbody'));
            let objToClick = tbl.all(by.cssContainingText('mercer-table-td', sSearchContent)).first();
            fcommon_obj.__executeScript(objToClick, sSearchContent, "click");
        }

        browser.sleep(browser.params.userSleep.short)
    };

    this.__doApproveReject = function (sContent, bApproveTrue_RejectFalse = true, sRejectReason = '') {

        // let tbl = element(by.tagName('tbody'));
        let tbl = element(by.css('tbody[class="ng-star-inserted"]'));
        fcommon_obj.__ElementPresent('content list table', tbl)
        let row = tbl.all(by.cssContainingText('mercer-table-td', sContent)).first().element(by.xpath('..')).element(by.xpath('..'));
        fcommon_obj.__ElementPresent('content list table - row: ' + sContent, row)

        if (bApproveTrue_RejectFalse)
            fcommon_obj.__executeScript(row.element(by.cssContainingText('button', 'Approve')), 'Approve', "click");
        else {
            fcommon_obj.__executeScript(row.element(by.cssContainingText('button', 'Reject')), 'Reject', "click");
            fcommon_obj.__setText('_txtModalContent', this._txtModalContent, sRejectReason)
            fcommon_obj.__executeScript(this._btnModalReject, '_btnModalReject', "click")
        }
    };



};
module.exports = contentList_page;



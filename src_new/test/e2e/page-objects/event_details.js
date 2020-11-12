/**
 * Created by webber-ling on 6/22/2020.
 */


"use strict";

const common_obj = require('../common/common_obj');
const fcommon_obj = new common_obj();
const common_page = require('./common_page');
const pcommon_page = new common_page();


const event_details_page = function () {

    /////////////////////////               page elements            ////////////////////////////////////
    
    this._tag_headerTag = pcommon_page._card_header.element(by.css('[id=article-type-chip'))

    this._btn_headerGoing = element(by.css('[id=event-page-header_351164239]'))
    this._btn_headerTicketsInfo = element(by.css('[id=event-page-header_294831899]'))
    
    let _leftBlock = element(by.css('[id="social-part-left_751981794"]'))
    this._btn_leftBlock_going = _leftBlock.element(by.css('[id=event-going-button_317877342]'))
    this._btn_leftBlock_goingCount = _leftBlock.element(by.css('[id=event-going-button_872087467]'))

    this._tag_detailsPage = (tagName) => {
        return element.all(by.css('[class="mos-c-chip mos-c-chip--md mos-t-chip--secondary-alt src-c-event-page-content__tag"]')).filter((elem,index) => {
            return elem.getText().then((txt) => {
                return txt == tagName
            })
        }).first()
    }

    /////////////////////////               page functions            ////////////////////////////////////


    this.__PopVerify = function (_txtWelcome = "", _chkTermsAndConditions = "", _btnLetsGetStarted = "") {


        // fcommon_obj.__executeScript(this._btnLogin, "_btnLogin", "click");
        // fcommon_obj.__setText('_txtEmailAddress', this._txtEmailAddress, email, true);
        // fcommon_obj.__executeScript(this._btnSubmit, "_btnSubmit", "click");
    };

    this.__clickVisitExternalLink_btn = () => {
        fcommon_obj.__executeScript(this._btnVisitExternalLink, "_btnVisitExternalLink", "click");
    }

    this.__clickVisitExternalLink_closeNewTab


};
module.exports = event_details_page;



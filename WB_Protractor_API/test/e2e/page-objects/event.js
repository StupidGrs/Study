/**
 * Created by webber-ling on 6/22/2020.
 */


"use strict";

const common_obj = require('../common/common_obj');
const fcommon_obj = new common_obj();
const common_page = require('./common_page');
const pcommon_page = new common_page();


const event_page = function () {

    /////////////////////////               page elements            ////////////////////////////////////



    // this._cardNews = (sTitle) => {
    //     return element.all(by.css('[class^="src-c-content-list-card mos-u-spacer--padding-top-bottom-md mos-u-border--bottom-sm mos-u-color-border--accent2"]')).filter((elem, index) => {
    //         return elem.element(by.cssContainingText('a', sTitle));
    //     }).first()
    // }

    // this._tagInternalOnly = (sTitle) => {
    //     return _cardNews(sTitle).element(by.css('[id="internal-content-chip"]'))
    // }

    this._txtCompanyName_inArticleCard = (sTitle) => pcommon_page._cardArticle(sTitle).element(by.css('[class="src-c-content-list-card-event-info-block"]')).all(by.css('div[class="ng-star-inserted"]')).first().element(by.css('[class="mos-u-spacer--padding-left-sm"]'))

    this._iconAttend_inArticleCard = (sTitle) => pcommon_page._cardArticle(sTitle).element(by.css('[class="src-c-mercer-show-attendees__icon"]'))
    this._txtAttendCount_inArticleCard = (sTitle) => pcommon_page._cardArticle(sTitle).element(by.css('[class="src-c-mercer-show-attendees__count mos-u-spacer--padding-left-xsm mos-u-font-weight--medium"]'))
    


    /////////////////////////               page functions            ////////////////////////////////////


    this.__PopVerify = function (_txtWelcome = "", _chkTermsAndConditions = "", _btnLetsGetStarted = "") {


        // fcommon_obj.__executeScript(this._btnLogin, "_btnLogin", "click");
        // fcommon_obj.__setText('_txtEmailAddress', this._txtEmailAddress, email, true);
        // fcommon_obj.__executeScript(this._btnSubmit, "_btnSubmit", "click");
    };

    // this.__clickNewsTitle = (sTitle) => {
    //     fcommon_obj.__executeScript(element(by.cssContainingText('a', sTitle)), sTitle, "click");
    //     fcommon_obj.__wait4ElementVisible()
    // }



};
module.exports = event_page;



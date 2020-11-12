/**
 * Created by webber-ling on 6/22/2020.
 */


"use strict";

const common_obj = require('../common/common_obj');
const fcommon_obj = new common_obj();
const common_page = require('./common_page');
const pcommon_page = new common_page();


const news_details_page = function () {

    /////////////////////////               page elements            ////////////////////////////////////

    // this._txtResearch = element.all(by.cssContainingText('h1', 'Research')).first();

    this._cardHeader = element(by.css('[id=article-header_330418031]'))
    this._txtHeaderTitle = this._cardHeader.element(by.css('[class="src-c-article-header__title mos-u-spacer--margin-none mos-u-color-text--white"]'))

    // this._cardInternalOnlyWarning = element(by.css('[class="mos-c-card mos-t-card--secondary mos-c-card--no-border mos-c-card--alert-active"]'))
    // this._txtInternalOnlyWarning = element(by.css('[class="mos-u-medium-text-size--sm mos-u-spacer--margin-bottom-none"]'))

    this._btnVisitExternalLink = element(by.css('[id=link_552350283]'))

    this._tag_detailsPage = (tagName) => {
        return element(by.cssContainingText('[class="src-c-mercer-article-footer__tag mos-u-color-text--primary"]', tagName))
    }

    this._lnkAttachment = element(by.css('[id^=item-attachment-view_title_]'))

    /////////////////////////               page functions            ////////////////////////////////////


    this.__PopVerify = function (_txtWelcome = "", _chkTermsAndConditions = "", _btnLetsGetStarted = "") {


        // fcommon_obj.__executeScript(this._btnLogin, "_btnLogin", "click");
        // fcommon_obj.__setText('_txtEmailAddress', this._txtEmailAddress, email, true);
        // fcommon_obj.__executeScript(this._btnSubmit, "_btnSubmit", "click");
    };

    this.__clickVisitExternalLink_btn = () => {
        fcommon_obj.__executeScript(this._btnVisitExternalLink, "_btnVisitExternalLink", "click");
    }

    // this.__clickVisitExternalLink_closeNewTab


};
module.exports = news_details_page;



/**
 * Created by webber-ling on 6/22/2020.
 */


"use strict";

const common_obj = require('../common/common_obj');
const fcommon_obj = new common_obj();
const common_page = require('./common_page');
const pcommon_page = new common_page();


const research_details_page = function () {

    /////////////////////////               page elements            ////////////////////////////////////

    this._txtResearch = element.all(by.cssContainingText('h1', 'Research')).first();

    // this._cardHeader = element(by.css('[id=article-header_330418031]'))
    // this._txtHeaderTitle = this._cardHeader.element(by.css('[class="src-c-article-header__title mos-u-spacer--margin-none mos-u-color-text--white"]'))
    // this._txtHeader_ExecutiveSummary = this._cardHeader.element(by.css('[class="src-c-article-header__excerpt mos-u-spacer--margin-none mos-u-color-text--white"]'))
    // this._txtHeader_companyName = this._cardHeader.element(by.css('[class="src-c-article-card-info__company-name src-u--cursor-pointer mos-u-spacer--margin-right-xxsm ng-star-inserted"]'))
    // this._txtHeader_ReadTime = this._cardHeader.element(by.css('[class="src-c-article-card-info__readtime ng-star-inserted"]'))
    // this._iconHeader_View = this._cardHeader.element(by.css('[class="src-c-mercer-show-views__icon"]'))
    // this._txtHeader_View = this._cardHeader.element(by.css('[class="src-c-mercer-show-views__count mos-u-spacer--padding-left-xsm mos-u-font-weight--medium"]'))

    this._tag_headerTag = pcommon_page._card_header.element(by.css('[id=article-type-chip'))
    this._tag_headerInternalOnlyTag = pcommon_page._card_header.element(by.css('[id=internal-content-chip'))

    this._btnVisitExternalLink = element(by.css('[id=link_552350283]'))

    this._tag_detailsPage = (tagName) => {
        return element.all(by.css('[id^="article-footer_tag_"]')).filter((elem,index) => {
            return elem.getText().then((txt) => {
                return txt == tagName
            })
        }).first()
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

    this.__clickVisitExternalLink_closeNewTab


};
module.exports = research_details_page;



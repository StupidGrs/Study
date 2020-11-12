/**
 * Created by webber-ling on 6/22/2020.
 */


"use strict";

const common_obj = require('../common/common_obj');
const fcommon_obj = new common_obj();
const common_page = require('./common_page');
const pcommon_page = new common_page();


const research_page = function () {

    /////////////////////////               page elements            ////////////////////////////////////

    this._txtResearch = element.all(by.cssContainingText('h1', 'Research')).first();

    this._tag_inArticleCard = (sTitle) => pcommon_page._cardArticle(sTitle).element(by.css('[id="article-type-chip"]'))

    /////////////////////////               page functions            ////////////////////////////////////


    this.__PopVerify = function (_txtWelcome="", _chkTermsAndConditions="", _btnLetsGetStarted="") {


        // fcommon_obj.__executeScript(this._btnLogin, "_btnLogin", "click");
        // fcommon_obj.__setText('_txtEmailAddress', this._txtEmailAddress, email, true);
        // fcommon_obj.__executeScript(this._btnSubmit, "_btnSubmit", "click");
    };


};
module.exports = research_page;



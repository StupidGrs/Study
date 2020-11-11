/**
 * Created by lin-li3 on 8/18/2020.
 */


"use strict";

const common_obj = require('../common/common_obj');
const fcommon_obj = new common_obj();
const common_page = require('./common_page');
const pcommon_page = new common_page();


const news_page = function () {

    /////////////////////////               bell elements            ////////////////////////////////////

    let _headerBell = element(by.css('mercer-icon[id^="header-notifications"]'))
    // this._txtNews = element.all(by.cssContainingText('h1', 'News')).first();
    this._btnBell = _headerBell.element(by.css('svg[class="mos-c-icon mos-c-icon--xlg mos-t-icon--default ng-star-inserted"]'))
    this._iconRedDot = _headerBell.element(by.css('svg[][class="ng-star-inserted mos-c-icon mos-c-icon--md mos-t-icon--alert mos-c-icon--badge"]'))



    /////////////////////////               page functions            ////////////////////////////////////


    this.__PopVerify = function (_txtWelcome="", _chkTermsAndConditions="", _btnLetsGetStarted="") {


        // fcommon_obj.__executeScript(this._btnLogin, "_btnLogin", "click");
        // fcommon_obj.__setText('_txtEmailAddress', this._txtEmailAddress, email, true);
        // fcommon_obj.__executeScript(this._btnSubmit, "_btnSubmit", "click");
    };


};
module.exports = news_page;


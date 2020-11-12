/**
 * Created by webber-ling on 6/18/2020.
 */


"use strict";

const common_obj = require('../common/common_obj');
const fcommon_obj = new common_obj();
const common_page = require('./common_page');
const pcommon_page = new common_page();


const dashboard_page = function () {

    /////////////////////////               page elements            ////////////////////////////////////

    this._txtTrendingNewsAndBlogs = element.all(by.cssContainingText('h2', 'Trending News & Blogs')).first();
    this._chkTermsAndConditions = element(by.css('label[for=termsAndConditions]'));
    this._btnLetsGetStarted = element.all(by.cssContainingText('button', 'LET\'S GET STARTED!')).first();





    /////////////////////////               page functions            ////////////////////////////////////





};
module.exports = dashboard_page;



/**
 * Created by lin-li on 8/10/2020.
 */

"use strict";

let fs = require('fs');
let ec = protractor.ExpectedConditions;
const dateformat = require('dateformat');
const path = require('path');
let util_windows = require('../../../common/utilities/util_windows');
let futil_windows = new util_windows();
let util_timer = require('../../../common/utilities/util_timer');
let futil_timer = new util_timer();
let util_xlsx = require('../../../common/utilities/util_xlsx');
let futil_xlsx = new util_xlsx();
let common_obj = require('../../../common/common_obj');
let fcommon_obj = new common_obj();
let common_page = require('../../../page-objects/common_page');
let pcommon_page = new common_page();
let common_test = require('../../common_test/common_test');
let fcommon_test = new common_test();


let login_page = require('../../../page-objects/login');
let plogin_page = new login_page();


let url = browser.params.url.dev
let emailAddress = 'testEmailPwd.lin.li3@gisqa.mercer.com'


beforeAll(function () {
    fcommon_obj.__log('------------ before all');

});
afterAll(function () {
    fcommon_obj.__log('------------ after all');
});


describe('Verify the element on Log In page', function () {

    it('WHEN the User click forgot password on Log In page', function () {
        plogin_page.__login_forgotPassword(url, emailAddress)
    });

    it('THEN I see reset password page opened', function () {
        expect(browser.getCurrentUrl()).toEqual(url + "/msso/forgot-password")
    });

    it('AND I input the email address to reset password', function () {
        plogin_page.__login_resetPassword(emailAddress)
    });

});
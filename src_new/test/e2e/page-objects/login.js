/**
 * Created by webber-ling on 6/18/2020.
 */



"use strict";

const common_obj = require('../common/common_obj');
const fcommon_obj = new common_obj();
const common_page = require('./common_page');
const pcommon_page = new common_page();


const login_page = function () {

    /////////////////////////               page elements            ////////////////////////////////////

    this._btnLogin = element.all(by.cssContainingText('button', 'Log In')).first();
    this._txtEmailAddress = element.all(by.css('[name=Username]')).first();
    this._btnSubmit = element.all(by.cssContainingText('button', 'Submit')).first();

    this._txtOKTA_EmployeeID = element(by.css('[id=okta-signin-username]'));
    this._txtOKTA_NetworkPassword = element(by.css('[id=okta-signin-password]'));
    this._btnOKTA_SignIn = element(by.css('[id=okta-signin-submit]'));


    /////////////////////////               page functions            ////////////////////////////////////


    this.__login = function (url, email, psw) {

        if (url !== '') {
            browser.get(url);
            fcommon_obj.__executeScript(this._btnLogin, "_btnLogin", "click");
        }

        //browser.sleep(browser.params.userSleep.medium);
        // fcommon_obj.__click('_btnLogin', this._btnLogin, 3, 3);
        // fcommon_obj.__setText('_txtEmailAddress', this._txtEmailAddress, email, true);
        // fcommon_obj.__click('Next', this._btnSubmit, 3, 3);


        fcommon_obj.__setText('_txtEmailAddress', this._txtEmailAddress, email, true);
        fcommon_obj.__executeScript(this._btnSubmit, "_btnSubmit", "click");
    };

    this.__login_okta = function (id, psw) {


        fcommon_obj.__setText('_txtOKTA_EmployeeID', this._txtOKTA_EmployeeID, id, true);
        fcommon_obj.__setText('_txtOKTA_NetworkPassword', this._txtOKTA_NetworkPassword, psw, true);
        fcommon_obj.__click('Next', this._btnOKTA_SignIn);


    };

    this.__login_mercerUser = (url, email, id, psw) => {

        browser.get(url);
        
        fcommon_obj.__executeScript(this._btnLogin, "_btnLogin", "click");
        fcommon_obj.__setText('_txtEmailAddress', this._txtEmailAddress, email, true);
        fcommon_obj.__executeScript(this._btnSubmit, "_btnSubmit", "click");

        fcommon_obj.__setText('_txtOKTA_EmployeeID', this._txtOKTA_EmployeeID, id, true);
        fcommon_obj.__setText('_txtOKTA_NetworkPassword', this._txtOKTA_NetworkPassword, psw, true);
        fcommon_obj.__click('Next', this._btnOKTA_SignIn);

    }


    /////////////////////////               verify SRC website page            ////////////////////////////////////


    let _src_website_el = {
        "FAQ_HeaderLink": element(by.css('a[class="mos-u-spacer--margin-right-xlg mos-u-font-weight--medium"][href="/info/faq"]')),
        "ContactUs_HeaderLink": element(by.css('a[class="mos-u-spacer--margin-right-xlg mos-u-font-weight--medium"][href="mailto:srcsupport@mercer.com"]')),
        "LogIn_HeaderButton": element(by.css('button[class="src-c-landing-page-header__button-login mos-u-font-weight--medium mos-c-button--md mos-t-button--secondary mos-c-button mos-c-button--outline"]')),
        "ContactUs_HeaderButton": element(by.css('button[class="src-c-landing-page-header__button-contact mos-u-text-size--md mos-c-button--md mos-c-button"]')),
        "LogIn_HeaderLink": element(by.css('a[class="mos-u-spacer--margin-right-lg mos-u-text-size--md"]')),
        "ContactUs_FeatureButton": element(by.css('button[class="src-c-landing-page-features__button-contact mos-u-text-size--md mos-c-button--md mos-c-button"]')),
        "ContactUs_BenefitButton": element(by.css('button[class="src-c-landing-page-benefits__button-contact mos-u-text-size--md mos-c-button--md mos-c-button"]')),
        "ContactUs_ReviewButton": element(by.css('button[class="src-c-landing-page-reviews__button-contact mos-u-font-weight--bold mos-c-button--md mos-c-button"]')),
        "FAQ_FooterLink": element(by.css('[id=footer_faq_link]')),
        "TermsOfUse_FooterLink": element(by.css('[id=footer_terms_link]')),
        "PrivacyPolicy_FooterLink": element(by.css('[id=footer_privacy_link]')),
        "CookiesPolicy_FooterLink": element(by.css('[id=footer_cookies_link]')),
        "ContactUs_FooterLink": element(by.css('[id=footer_contact-us_link]')),
    }

    this.__src_website_page_verify = () => {
        fcommon_obj.__isElementDisplayed(_src_website_el.FAQ_HeaderLink, "FAQ_HeaderLink")
        expect(_src_website_el.FAQ_HeaderLink.getText()).toEqual("FAQ")
        fcommon_obj.__isElementDisplayed(_src_website_el.ContactUs_HeaderLink, "ContactUs_HeaderLink")
        expect(_src_website_el.ContactUs_HeaderLink.getText()).toEqual("Contact Us")
        fcommon_obj.__isElementDisplayed(_src_website_el.LogIn_HeaderButton, "LogIn_HeaderButton")
        expect(_src_website_el.LogIn_HeaderButton.getText()).toEqual("Log In")
        fcommon_obj.__isElementDisplayed(_src_website_el.ContactUs_HeaderButton, "ContactUs_HeaderButton")
        expect(_src_website_el.ContactUs_HeaderButton.getText()).toEqual("Contact Us")
        fcommon_obj.__isElementDisplayed(_src_website_el.LogIn_HeaderLink, "LogIn_HeaderLink")
        expect(_src_website_el.LogIn_HeaderLink.getText()).toEqual("Already a member? Click here")
        fcommon_obj.__isElementDisplayed(_src_website_el.ContactUs_FeatureButton, "ContactUs_FeatureButton")
        expect(_src_website_el.ContactUs_FeatureButton.getText()).toEqual("Contact Us")
        fcommon_obj.__isElementDisplayed(_src_website_el.ContactUs_BenefitButton, "ContactUs_BenefitButton")
        expect(_src_website_el.ContactUs_BenefitButton.getText()).toEqual("Contact Us")
        fcommon_obj.__isElementDisplayed(_src_website_el.ContactUs_ReviewButton, "ContactUs_ReviewButton")
        expect(_src_website_el.ContactUs_ReviewButton.getText()).toEqual("Contact Us")
        fcommon_obj.__isElementDisplayed(_src_website_el.FAQ_FooterLink, "FAQ_FooterLink")
        expect(_src_website_el.FAQ_FooterLink.getText()).toEqual("FAQ")
        fcommon_obj.__isElementDisplayed(_src_website_el.TermsOfUse_FooterLink, "TermsOfUse_FooterLink")
        expect(_src_website_el.TermsOfUse_FooterLink.getText()).toEqual("Terms of Use")
        fcommon_obj.__isElementDisplayed(_src_website_el.PrivacyPolicy_FooterLink, "Privacy_FooterLink")
        expect(_src_website_el.PrivacyPolicy_FooterLink.getText()).toEqual("Privacy Policy")
        fcommon_obj.__isElementDisplayed(_src_website_el.CookiesPolicy_FooterLink, "Cookies_FooterLink")
        expect(_src_website_el.CookiesPolicy_FooterLink.getText()).toEqual("Cookies Policy")
        fcommon_obj.__isElementDisplayed(_src_website_el.ContactUs_FooterLink, "ContactUs_FooterLink")
        expect(_src_website_el.ContactUs_FooterLink.getText()).toEqual("Contact Us")
    }


    /////////////////////////            external user log in            ////////////////////////////////////

    this._txtPassword = element(by.css('input[id=Password]'))
    this._btnPwdLogin = element(by.css('button[id=mssoLoginBtn]'))

    this.__login_ext = (url, email, psw) => {
        browser.get(url)
        fcommon_obj.__executeScript(this._btnLogin, "_btnLogin", "click");
        fcommon_obj.__setText('_txtEmailAddress', this._txtEmailAddress, email, true)
        fcommon_obj.__executeScript(this._btnSubmit, "_btnSubmit", "click");
        fcommon_obj.__setText('_txtPassword', this._txtPassword, psw, true)
        fcommon_obj.__executeScript(this._btnPwdLogin, "_btnPwdLogin", "click");
    }


    this._linkForgotPassword = element(by.css('div[class="columns small-12"]')).element(by.tagName('a'))
    this._txtResetPassword_EmailAddress = element(by.css('[id=emailItem]'));
    this._btnContinue = element(by.css('button[class="mos-c-button--md mos-c-button--expanded-large-down mos-c-button"]'));
    this._txtMessage = element(by.css('span[class="ng-star-inserted"]'))

    this.__login_forgotPassword = (url, email) => {
        browser.get(url)
        fcommon_obj.__executeScript(this._btnLogin, "_btnLogin", "click");
        fcommon_obj.__setText('_txtEmailAddress', this._txtEmailAddress, email, true)
        fcommon_obj.__executeScript(this._btnSubmit, "_btnSubmit", "click");
        fcommon_obj.__isElementDisplayed(this._linkForgotPassword, "_linkForgotPassword")
        expect(this._linkForgotPassword.getText()).toEqual("Forgot password")
        fcommon_obj.__executeScript(this._linkForgotPassword, "_linkForgotPassword", "click");
    }

    this.__login_resetPassword = (email) => {
        fcommon_obj.__setText('_txtResetPassword_EmailAddress', this._txtResetPassword_EmailAddress, email, true)
        fcommon_obj.__executeScript(this._btnContinue, "_btnContinue", "click")
        expect(this._txtMessage.getText()).toEqual("We just sent you an email to reset your password.")
    }



    /////////////////////////               toast message            ////////////////////////////////////

    this._toast_message = element(by.css('[id=toast-outlet_message]'));



};
module.exports = login_page;


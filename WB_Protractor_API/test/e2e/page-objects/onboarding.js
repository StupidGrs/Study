/**
 * Created by webber-ling on 6/18/2020.
 */


"use strict";

const common_obj = require('../common/common_obj');
const fcommon_obj = new common_obj();
const common_page = require('./common_page');
const pcommon_page = new common_page();


const onboarding_page = function () {

    /////////////////////////               page elements            ////////////////////////////////////

    this._txtWelcome = element.all(by.cssContainingText('h2', 'Welcome to The Strategic Research Community')).first();
    this._chkTermsAndConditions = element(by.css('label[for=termsAndConditions]'));
    this._btnLetsGetStarted = element.all(by.cssContainingText('button', 'LET\'S GET STARTED!')).first();



    this._txtLetsKnowYouBetter = element.all(by.cssContainingText('h2', 'Let\'s Get To Know You Better')).first();
    this._btnNext = element.all(by.cssContainingText('button', 'Next')).first();
    this._txtLetsPersonalizeYourExperience = element.all(by.cssContainingText('h2', 'Let\'s Personalize Your Experience')).first();
    this._btnFinishUp = element.all(by.cssContainingText('button', 'Finish up')).first();


    /////////////////////////               page functions            ////////////////////////////////////


    this.__PopVerify = function (_txtWelcome="", _chkTermsAndConditions="", _btnLetsGetStarted="") {


        // fcommon_obj.__executeScript(this._btnLogin, "_btnLogin", "click");
        // fcommon_obj.__setText('_txtEmailAddress', this._txtEmailAddress, email, true);
        // fcommon_obj.__executeScript(this._btnSubmit, "_btnSubmit", "click");
    };


};
module.exports = onboarding_page;



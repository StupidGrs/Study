/**
 * Created by webber-ling on 6/18/2020.
 */




"use strict";

const dateformat = require('dateformat');
const common_obj = require('../common/common_obj');
const fcommon_obj = new common_obj();
const common_page = require('./common_page');
const pcommon_page = new common_page();


const strapi_page = function () {

    /////////////////////////               page elements            ////////////////////////////////////


    this._txtUsername = element(by.css('[id=identifier]'));
    this._txtPassword = element(by.css('[id=password]'));
    this._chkRememberMe = element(by.css('[id=rememberMe]'));
    this._btnLogin = element.all(by.cssContainingText('button', 'Log in')).first();


    this._txtSearch = element(by.css('[type=text]'));

    this._listPersonProfiles_PersonStatus = element(by.css('[id=person_status]'));

    this._txtPersonProfiles_FullName = element(by.css('[id=full_name]'));
    this._btnPersonProfiles_Save = element.all(by.cssContainingText('button', 'Save')).first();

    this._btnUserAgreements_AddNewUseragreement = element.all(by.cssContainingText('button', 'Add New Useragreement')).first();
    this._txtUserAgreements_Content = element.all(by.tagName('textarea')).first();
    this._btnUserAgreements_RDTOpen = element(by.css('[class=rdt]')).element(by.tagName('input'));

    this._btnRightIcon = element(by.css('[class="fa fa-angle-right"]'));
    this._btnLeftIcon = element(by.css('[class="fa fa-angle-left"]'));

    this._btnConfirm = element.all(by.cssContainingText('button', 'Confirm')).first();
    this._btnDelete = element.all(by.cssContainingText('button', 'Delete')).first();


    /////////////////////////               page functions            ////////////////////////////////////


    // this.__login = function (url, email, psw) {
    //
    //     browser.get(url);
    //     //browser.sleep(browser.params.userSleep.medium);
    //     // fcommon_obj.__click('_btnLogin', this._btnLogin, 3, 3);
    //     // fcommon_obj.__setText('_txtEmailAddress', this._txtEmailAddress, email, true);
    //     // fcommon_obj.__click('Next', this._btnSubmit, 3, 3);
    //
    //     fcommon_obj.__executeScript(this._btnLogin, "_btnLogin", "click");
    //     fcommon_obj.__setText('_txtEmailAddress', this._txtEmailAddress, email, true);
    //     fcommon_obj.__executeScript(this._btnSubmit, "_btnSubmit", "click");
    // };

    this.__login = function (url, username, psw, rememberMe = false) {

        browser.get(url);

        fcommon_obj.__setText('_txtUsername', this._txtUsername, username, true);
        fcommon_obj.__setText('_txtPassword', this._txtPassword, psw, true);
        fcommon_obj.__checkOnOff(this._chkRememberMe, "_chkRememberMe", false);

        fcommon_obj.__click('_btnLogin', this._btnLogin);


    };

    let __leftNavigate = function (contentType) {

        let el = element.all(by.cssContainingText('span', contentType)).first();
        fcommon_obj.__click('contentType', el);
        browser.sleep(browser.params.userSleep.short);
        fcommon_obj.__click('contentType', el);
        browser.sleep(browser.params.userSleep.short);
    };

    this.__leftNavigate = function (contentType) {

        __leftNavigate(contentType);
    };

    let __setCalenderStrapi = function (dmmmyyyy, description = 'Calenda') {

        const currentDay = element(by.css('[class="rdtPicker"]'));


        let exp_day = dmmmyyyy.split('-')[0];


        if (Number(exp_day) < 15)
            fcommon_obj.__click('Day', currentDay.all(by.cssContainingText('td', exp_day)).first());
        if (Number(exp_day) > 20)
            fcommon_obj.__click('Day', currentDay.all(by.cssContainingText('td', exp_day)).last());



        //browser.sleep(browser.params.userSleep.short);

    };


    this.__PersonProfiles_pickupPerson = function (name) {

        __leftNavigate('Personprofiles');

        let table = element.all(by.tagName('table')).first();
        fcommon_obj.__setText('_txtSearch', this._txtSearch, name, true);
        fcommon_obj.__click(name, table.element(by.cssContainingText('td', name)));
        browser.sleep(browser.params.userSleep.short);



        this._txtPersonProfiles_FullName.getAttribute('value').then(function (txt) {
            if (txt === name)
                fcommon_obj.__log('function: __PersonProfiles_pickupPerson successfully selected user: ' + name);
            else {
                fcommon_obj.__log('function: __PersonProfiles_pickupPerson failed to select user: ' + name + " it picked up: " + txt + " instead!");
                throw new Error('function <__PersonProfiles_pickupPerson > failed to select user: ' + name + " it picked up: " + txt + " instead!");
            }
        });


    };

    this.__PersonProfiles_deletePerson = function (name) {

        // let table = element.all(by.tagName('table')).first();
        // fcommon_obj.__setText('_txtSearch', this._txtSearch, name, true);
        // fcommon_obj.__click(name, table.element(by.cssContainingText('td', name)));
        // browser.sleep(browser.params.userSleep.short);
        //
        //
        //
        // this._txtPersonProfiles_FullName.getAttribute('value').then(function(txt){
        //     if(txt===name){
        //         fcommon_obj.__log('function: __PersonProfiles_pickupPerson successfully selected user: ' + name);
        //         fcommon_obj.__executeScript(element.all(by.cssContainingText('button', 'Delete')).first(), "_btnDelete", "click");
        //         browser.sleep(browser.params.userSleep.short);
        //     }
        //     else{
        //         fcommon_obj.__log('function: __PersonProfiles_pickupPerson failed to select user: ' + name + " it picked up: " + txt + " instead!");
        //         throw new Error('function <__PersonProfiles_pickupPerson > failed to select user: ' + name + " it picked up: " + txt + " instead!");
        //     }
        // });


    };

    this.__PersonProfiles_changeStatus = function (status) {
        fcommon_obj.__selectByText('contentType', this._listPersonProfiles_PersonStatus, status, false);
        /////fcommon_obj.__click('_btnPersonProfiles_Save', this._btnPersonProfiles_Save);
        fcommon_obj.__executeScript(this._btnPersonProfiles_Save, "_btnPersonProfiles_Save", "click");
        browser.sleep(browser.params.userSleep.medium);
    };

    this.__PersonProfiles_clearAgreements = function () {

        let lstAgreements = element(by.css('[id=sortableListOfagreements]'));
        lstAgreements.all(by.tagName('li')).then(function (all) {
            fcommon_obj.__log(all.length);

            for (let i = all.length - 1; i >= 0; i--) {
                /////fcommon_obj.__click('Remove icon at index: ' + i, all[i].element(by.tagName('img')));
                fcommon_obj.__executeScript(all[i].element(by.tagName('img')), 'Remove icon at index: ' + i, "click");
            }


            // for(let i=0;i<all.length;i++){
            //     all[i].getText().then(function(txt){
            //         fcommon_obj.__log(txt);
            //     });
            // }


        });

        fcommon_obj.__executeScript(this._btnPersonProfiles_Save, "_btnPersonProfiles_Save", "click");
        browser.sleep(browser.params.userSleep.medium);

        expect(lstAgreements.all(by.tagName('li')).length).toBe(undefined);


    };

    this.__UserAgreements_Delete = function (content) {


        __leftNavigate('Useragreements');

        // this._btnRightIcon.isEnabled().then(function(txt){
        //     fcommon_obj.__log('enabled before click: ' + txt);
        // });

        fcommon_obj.__click('_btnRightIcon', this._btnRightIcon);
        fcommon_obj.__click('_btnRightIcon', this._btnRightIcon);
        fcommon_obj.__click('_btnRightIcon', this._btnRightIcon);


        let table = element.all(by.tagName('table')).first();

        table.element(by.cssContainingText('td', content)).isPresent().then(function (txt) {
            fcommon_obj.__log('content exist: ' + txt);
            if (txt === true) {
                let row = element(by.tagName('table')).element(by.cssContainingText('td', content)).element(by.xpath('..'));
                row.getText().then(function (txt) {
                    fcommon_obj.__log(txt);
                });
                let deleteIcon = row.all(by.css('[class="fa fa-trash"]')).first();
                fcommon_obj.__executeScript(deleteIcon, "deleteIcon", "click");
                browser.sleep(browser.params.userSleep.short);
                fcommon_obj.__executeScript(element.all(by.cssContainingText('button', 'Confirm')).first(), "_btnConfirm", "click");

            }
        });


        __leftNavigate('Useragreements');

        table.element(by.cssContainingText('td', content)).isPresent().then(function (txt) {
            fcommon_obj.__log('content exist: ' + txt);
            if (txt === true) {
                let row = element(by.tagName('table')).element(by.cssContainingText('td', content)).element(by.xpath('..'));
                row.getText().then(function (txt) {
                    fcommon_obj.__log(txt);
                });
                let deleteIcon = row.all(by.css('[class="fa fa-trash"]')).first();
                fcommon_obj.__executeScript(deleteIcon, "deleteIcon", "click");
                browser.sleep(browser.params.userSleep.short);
                fcommon_obj.__executeScript(element.all(by.cssContainingText('button', 'Confirm')).first(), "_btnConfirm", "click");

            }
        });


        // fcommon_obj.__executeScript(this._btnPersonProfiles_Save, "_btnPersonProfiles_Save", "click");
        //
        //
        //
        // fcommon_obj.__click(content, table.element(by.cssContainingText('td', content)));
        // browser.sleep(browser.params.userSleep.short);
        //
        // fcommon_obj.__executeScript(this._btnPersonProfiles_Save, "_btnPersonProfiles_Save", "click");
        // browser.sleep(browser.params.userSleep.medium);

    };

    this.__UserAgreements_Add = function (date, content) {

        __leftNavigate('Useragreements');

        fcommon_obj.__executeScript(this._btnUserAgreements_AddNewUseragreement, "_btnUserAgreements_AddNewUseragreement", "click");
        fcommon_obj.__executeScript(this._btnUserAgreements_RDTOpen, "_btnUserAgreements_RDTOpen", "click");
        __setCalenderStrapi(date);
        fcommon_obj.__setText('_txtUserAgreements_Content', this._txtUserAgreements_Content, content);
        fcommon_obj.__executeScript(this._btnPersonProfiles_Save, "_btnPersonProfiles_Save", "click");
        browser.sleep(browser.params.userSleep.medium);

    };

    /***
     * pstrapi_page.__DeleteData('Articles', '0_Auto');
     * pstrapi_page.__DeleteData('Events', '0_Auto');
     * 
     * @param sType
     * @param sContainText
     * @param iNum
     * @private
     */
    this.__DeleteData = function (sType, sContainText, iNum = 10, iPages = 5) {

        __leftNavigate(sType);

        let objNavi = element(by.css('[class="plugin-content-managernavUl__node_modules-strapi-helper-plugin-lib-src-components-GlobalPagination-styles__1nDXh"]'));
        let objLast = objNavi.all(by.tagName('li')).last();
        fcommon_obj.__click('Last Page', objLast);

        let table = element.all(by.tagName('table')).first();

        for (let iPg = 0; iPg < iPages; iPg++) {
            for (let i = 0; i < iNum; i++) {
                table.element(by.cssContainingText('td', sContainText)).isPresent().then(function (txt) {
                    fcommon_obj.__log('sContainText exist: ' + txt);
                    if (txt === true) {
                        let row = element(by.tagName('table')).element(by.cssContainingText('td', sContainText)).element(by.xpath('..'));
                        row.getText().then(function (txt) {
                            fcommon_obj.__log(txt);
                        });
                        let deleteIcon = row.all(by.css('[class="fa fa-trash"]')).first();
                        fcommon_obj.__executeScript(deleteIcon, "deleteIcon", "click");
                        fcommon_obj.__executeScript(element.all(by.cssContainingText('button', 'Confirm')).first(), "_btnConfirm", "click");
                        browser.sleep(browser.params.userSleep.short);
                    }
                });

            }
            fcommon_obj.__click('_btnLeftIcon', this._btnLeftIcon);
        }


    };


    //not finish
    // this.__DeleteCurrentData = (td) => {
    //     this.__login(td.url, td.username, td.psw)
    //     __leftNavigate(td.sType);

    //     let objNavi = element(by.css('[class="plugin-content-managernavUl__node_modules-strapi-helper-plugin-lib-src-components-GlobalPagination-styles__1nDXh"]'));
    //     let objLast = objNavi.all(by.tagName('li')).last();
    //     fcommon_obj.__click('Last Page', objLast);
    // }




};
module.exports = strapi_page;



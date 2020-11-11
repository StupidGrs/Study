/**
 * Created by webber-ling on 7/14/2017.
 */


"use strict";
const ec = protractor.ExpectedConditions;
const dateformat = require('dateformat');
const common_obj = require('../common/common_obj');
const fcommon_obj = new common_obj();
const util_windows = require('../common/utilities/util_windows');
const futil_windows = new util_windows();
const path = require('path');


const common_page = function () {

    /////////////////////////               page elements            ////////////////////////////////////

    this._btnPersonIcon = element(by.css('[id^="person-avatar_person"]'));
    this._listPersonIcon = element(by.css('[class="mos-c-dropdown__list"]'));
    this._btnAccept = element.all(by.cssContainingText('button', 'Accept')).first();

    this._btnSettingsIcon = element(by.css('[icon=settings]'));


    this._txtFilter = element(by.css('[id*=mos-autocomplete-]'));

    this._cardArticle = (sTitle) => {
        return element.all(by.css('[class^="src-c-content-list-card mos-u-spacer--padding-top-bottom-md mos-u-border--bottom-sm mos-u-color-border--accent2"]')).filter((elem, index) => {
            return elem.element(by.css('[class="src-c-content-list-card__title src-u--cursor-pointer mos-u-font-weight--bold mos-u-text-size--lg"]>a[href]')).getText().then((txt) => {
                return txt == sTitle
            })
        }).first()
    }

    this._tagInternalOnly_inArticleCard = (sTitle) => {
        return this._cardArticle(sTitle).element(by.css('[id="internal-content-chip"]'))
    }

    this._txtTitle_inArticleCard = (sTitle) => this._cardArticle(sTitle).element(by.css('[class="src-c-content-list-card__title src-u--cursor-pointer mos-u-font-weight--bold mos-u-text-size--lg"]>a[href]'))
    this._txtExecutiveSummary_inArticleCard = (sTitle) => this._cardArticle(sTitle).element(by.css('[class="mos-u-spacer--padding-top-bottom-sm mos-u-color-text--tertiary"]'))
    this._imageCompany_inArticleCard = (sTitle) => this._cardArticle(sTitle).element(by.css('[id="company-logo_image"]'))
    this._txtCompanyName_inArticleCard = (sTitle) => this._cardArticle(sTitle).element(by.css('[class="src-c-article-card-info__company-name src-u--cursor-pointer mos-u-spacer--margin-right-xxsm ng-star-inserted"]'))
    this._txtReadTime_inArticleCard = (sTitle) => this._cardArticle(sTitle).element(by.css('[class="src-c-article-card-info__readtime ng-star-inserted"]'))
    this._iconView_inArticleCard = (sTitle) => this._cardArticle(sTitle).element(by.css('[class="src-c-mercer-show-views__icon"]'))
    this._txtViewCount_inArticleCard = (sTitle) => this._cardArticle(sTitle).element(by.css('[class="src-c-mercer-show-views__count mos-u-spacer--padding-left-xsm mos-u-font-weight--medium"]'))

    this._iconStar1_inArticleCard = (sTitle) => this._cardArticle(sTitle).element(by.css('[id="show-ratings_star_0"]'))
    this._iconStar2_inArticleCard = (sTitle) => this._cardArticle(sTitle).element(by.css('[id="show-ratings_star_1"]'))
    this._iconStar3_inArticleCard = (sTitle) => this._cardArticle(sTitle).element(by.css('[id="show-ratings_star_2"]'))
    this._iconStar4_inArticleCard = (sTitle) => this._cardArticle(sTitle).element(by.css('[id="show-ratings_star_3"]'))
    this._iconStar5_inArticleCard = (sTitle) => this._cardArticle(sTitle).element(by.css('[id="show-ratings_star_4"]'))

    this._txtRating_inArticleCard = (sTitle) => this._cardArticle(sTitle).element(by.css('[class="src-c-mercer-show-ratings__rate-count mos-u-spacer--padding-left-xsm mos-u-font-weight--medium mos-u-color-text--accent2-alt"]'))

    this._btnBookmark_inArticleCard = (sTitle) => this._cardArticle(sTitle).element(by.css('[id="bookmark-button_link"]'))

    this._cardInternalOnlyWarning = element(by.css('[class="mos-c-card mos-t-card--secondary mos-c-card--no-border mos-c-card--alert-active"]'))
    this._txtInternalOnlyWarning = element(by.css('[class="mos-u-medium-text-size--sm mos-u-spacer--margin-bottom-none"]'))

    this._txtContent = element(by.css('[class="src-c-article-content__content ng-star-inserted"]'))
    this._txtDisclaimer = element(by.css('[class="src-c-article-disclaimer row align-center expanded mos-u-spacer--margin-top-xlg ng-star-inserted"]')).element(by.css('[class="column"]'))

    this._lnkVisitExternal = element(by.css('[class="src-c-mercer-link__button mos-c-button--md mos-c-button mos-c-button--outline ng-star-inserted"]'))

    this._lnlVideo = element(by.css('[label="Video"] iframe'))

    this._tag_detailsPage = (tagName) => {
        return element.all(by.css('[id^="article-footer_tag_"]')).filter((elem, index) => {
            return elem.getText().then((txt) => {
                return txt == tagName
            })
        }).first()
    }

    this._lnkAttachment = element(by.css('[id^=item-attachment-view_title_]'))

    this._popularArticle = element(by.css('[id="countable-item-list"]'))

    this._cardPopularArticle = (sTitle) => {
        return this._popularArticle.all(by.css('[class^="src-c-countable-item-list__item-content mos-u-spacer--padding-top-lg mos-u-spacer--padding-left-xlg"]')).filter((elem, index) => {
            return elem.element(by.css('[class="src-c-countable-item-list__item-title mos-u-font-weight--bold mos-u-spacer--margin-bottom-xsm src-u--cursor-pointer"]')).getText().then((txt => {
                return txt == sTitle
            }))
        }).first()
    }

    this._txtCompanyName_inPopularArticleCard = (sTitle) => this._cardPopularArticle(sTitle).element(by.css('[class="src-c-article-card-info__company-name src-u--cursor-pointer mos-u-spacer--margin-right-xxsm ng-star-inserted"]'))
    this._txtReadTime_inPopularArticleCard = (sTitle) => this._cardPopularArticle(sTitle).element(by.css('[class="src-c-article-card-info__readtime ng-star-inserted"]'))


    this._card_header = element(by.css('[id^=article-header][class="src-c-article-header"]'))
    this._tag_headerInternalOnly = this._card_header.element(by.css('[id="internal-content-chip"]'))
    this._txt_headerTitle = this._card_header.element(by.css('[class="src-c-article-header__title mos-u-spacer--margin-none mos-u-color-text--white"]'))
    this._txt_headerExecutiveSummary = this._card_header.element(by.css('[class="src-c-article-header__excerpt mos-u-spacer--margin-none mos-u-color-text--white"]'))
    this._txt_headerCompanyName = this._card_header.element(by.css('[class="src-c-article-card-info__company-name src-u--cursor-pointer mos-u-spacer--margin-right-xxsm ng-star-inserted"]'))
    this._txt_headerReadTime = this._card_header.element(by.css('[class="src-c-article-card-info__readtime ng-star-inserted"]'))
    this._icon_headerView = this._card_header.element(by.css('[class="src-c-mercer-show-views__icon"]'))
    this._txt_HeaderView = this._card_header.element(by.css('[class="src-c-mercer-show-views__count mos-u-spacer--padding-left-xsm mos-u-font-weight--medium"]'))

    this._icon_headerStar1 = this._card_header.element(by.css('[id="show-ratings_star_0"]'))
    this._icon_headerStar2 = this._card_header.element(by.css('[id="show-ratings_star_1"]'))
    this._icon_headerStar3 = this._card_header.element(by.css('[id="show-ratings_star_2"]'))
    this._icon_headerStar4 = this._card_header.element(by.css('[id="show-ratings_star_3"]'))
    this._icon_headerStar5 = this._card_header.element(by.css('[id="show-ratings_star_4"]'))

    this._txt_headerRating = this._card_header.element(by.css('[class="src-c-mercer-show-ratings__rate-count mos-u-spacer--padding-left-xsm mos-u-font-weight--medium mos-u-color-text--white"]'))

    this._btn_headerBack = this._card_header.element(by.css('[class="src-c-article-header__back-button"]'))

    this._txt_leftBlock_companyName = element(by.css('[class="src-c-mercer-social-part-left__company-name mos-u-font-weight--bold"]'))
    this._txt_leftBlock_followers = element(by.css('[class="src-c-mercer-social-part-left__followers mos-u-text-size--sm"]'))
    this._btn_leftBlock_followCompany = element(by.css('[class="row mos-u-spacer--padding-top-xsm"]')).element(by.css('[id="follow-button_root"]'))
    this._leftBlock_rating = element(by.css('[id="article-social-part-left_ratings"]'))
    this._icon_leftBlock_ratingStar = this._leftBlock_rating.element(by.css('[id="set-ratings_ratings"]'))
    this._txt_leftBlock_rateThis = this._leftBlock_rating.element(by.css('[id="set-ratings_rate-this"]'))
    this._icon_leftBlock_bookmark = element(by.css('[id=article-social-part-left_bookmark] [role="img"]'))



    /////////////////////////               page functions            ////////////////////////////////////


    this.__logout = function () {
        ////fcommon_obj.__click('_btnPersonIcon', this._btnPersonIcon);
        ////fcommon_obj.__click('_listPersonIcon', this._listPersonIcon.element(by.cssContainingText('div', 'Logout')));
        fcommon_obj.__executeScript(this._btnPersonIcon, "_btnPersonIcon", "click");
        fcommon_obj.__executeScript(this._listPersonIcon.element(by.cssContainingText('div', 'Logout')), "Logout", "click");
        fcommon_obj.__wait4ElementVisible(element.all(by.css('[name=Username]')).first(), 'Login-Username');

    };

    /***
     * 
     * @param sMenu
     * @private
     */
    this.__gotoPersonIcon_Menu = function (sMenu) {

        fcommon_obj.__executeScript(this._btnPersonIcon, "_btnPersonIcon", "click");

        fcommon_obj.__executeScript(this._listPersonIcon.all(by.cssContainingText('div', sMenu)).first(), sMenu, "click");


    };


    /***
     * pcommon_page.__selectMenu('Research');
     * pcommon_page.__selectMenu('News');
     * pcommon_page.__selectMenu('Events');
     *
     * @param sMenu
     * @private
     */
    this.__selectMenu = function (sMenu) {

        // if(sMenu==='Events')
        if (sMenu.indexOf('Event') != -1)
            fcommon_obj.__executeScript(element(by.cssContainingText('h5', sMenu)), sMenu, "click");
        else
            fcommon_obj.__click(sMenu, element(by.cssContainingText('h5', sMenu)));

    };

    /***
     * pcommon_page.__gotoSetting('Moderate Content');
     *
     * @param sMenu
     * @private
     */
    this.__gotoSetting = function (sMenu) {

        let objToCheck;

        switch (sMenu) {
            case 'Moderate Content':
                objToCheck = element(by.cssContainingText('h1', 'Content list'));
                break;
            case 'Reject':

                break;
            case 'Transfer':

                break;
            default:
                throw new Error('Incorrect input Menu name [' + sMenu + ']');
        }


        fcommon_obj.__executeScript(this._btnSettingsIcon, '_btnSettingsIcon', "click");

        let ojbMenu = element(by.css('[alt="' + sMenu + '"]'));

        fcommon_obj.__executeScript(ojbMenu, sMenu, "click");

        fcommon_obj.__wait4ElementVisible(objToCheck, 'Check object on screen: ' + sMenu);

    };


    this.__setCalender = function (dmmmyyyy, description = 'Calenda') {

        let currentDay = element(by.css('.mos-c-datepicker__calendar'))

        browser.getCapabilities().then(function (txt) {
            // console.log(txt.get('browserName'));
            if (txt.get('browserName') === 'internet explorer')
                currentDay = element(by.tagName('table'));
            if (txt.get('browserName') === 'chrome') {
                // currentDay = element(by.tagName('mercer-calendar'));
                element(by.css('.mos-c-datepicker__calendar'))
            }
        });

        let exp_day = dmmmyyyy.split('-')[0];

        // let obj;

        // if (Number(exp_day) <= 15)
        //     // obj = currentDay.all(by.css('td')).filter(function (elem, index) {
        //     obj = currentDay.all(by.tagName('td')).filter(function (elem, index) {
        //         return elem.getText().then(function (text) {
        //             ///////// console.log('index:' + index);
        //             //////// console.log(text);
        //             return text === exp_day;
        //         });
        //     }).first();



        // if (Number(exp_day) > 15)
        //     // obj = currentDay.all(by.css('td')).filter(function (elem, index) {
        //     obj = currentDay.all(by.tagName('td')).filter(function (elem, index) {
        //         return elem.getText().then(function (text) {
        //             //// console.log('index:' + index);
        //             //// console.log(text);
        //             return text === exp_day;
        //         });
        //     }).last();

        let obj = currentDay.all(by.css('a.mos-c-calendar__day')).filter(function (elem, index) {
            return elem.getText().then(function (text) {
                // console.log('exp_day:' + exp_day);
                // console.log(text);
                return text == exp_day;
            });
        }).first()

        // fcommon_obj.__click(exp_day, obj.element(by.css('[class="mos-c-calendar__day"]')));

        // fcommon_obj.__executeScript(obj.element(by.css('[class="mos-c-calendar__day"]')), exp_day, "click");
        fcommon_obj.__executeScript(obj, exp_day, "click");
        
        // if(Number(exp_day)<15)
        //   fcommon_obj.__click('Day', currentDay.all(by.cssContainingText('td', exp_day)).first());
        // if(Number(exp_day)>20)
        //   fcommon_obj.__click('Day', currentDay.all(by.cssContainingText('td', exp_day)).last());
        // $$('tr td').filter(function(elem, index) {
        //   return elem.getText().then(function(text) {
        //     return text === exp_day;
        //   });
        // }).last().click();

        //browser.sleep(browser.params.userSleep.short);

    };


    this.__searchAndVerifyExist = function (sConent, bExist = true, bSelect = false) {

        fcommon_obj.__setText('_txtFilter', this._txtFilter, sConent + protractor.Key.ENTER, true, false);

        let objToCheck = element(by.cssContainingText('a', sConent));

        if (bExist) {
            fcommon_obj.__wait4ElementVisible(objToCheck, 'Check object visible: ' + sConent);
            // fcommon_obj.__ElementScrollIntoView(this._cardArticle(sConent))
        }
        else
            fcommon_obj.__wait4ElementInvisible(objToCheck, 'Check object invisible: ' + sConent);

        if (bSelect)
            fcommon_obj.__executeScript(objToCheck, sConent, "click");
    };


    ////////////////////////////  below is MPRE common page functions -  for reference only    /////////////////////////////


    this._Save = element.all(by.cssContainingText('button', 'Save')).first();
    this._Logout = element(by.cssContainingText('a', 'Logout'));


    this._UploadStatus = element.all(by.cssContainingText('.ui-dialog-title', 'Upload Status')).first();
    this._InsurerPremiumsMismatched = element.all(by.cssContainingText('div', 'Insurer Premiums Mismatched')).first();


    let __Wait4Loading = function (el, bCheckLoading = true, index = 0) {

        let iLoadingAppear = 0;
        let iLoadingDisappear = 0;

        // for(let i=1;i<=iteration;i++){

        // browser.sleep(1000);

        // let loader =  element.all(by.cssContainingText('div', 'Loading...')).get(0);
        // let loader = element.all(by.css('[class="content-loading-spinner"]')).get(0);


        // element.all(by.css('[class="content-loading-spinner"]')).then(function(all){
        //     fcommon_obj.__log(all.length);
        //     for(let i=0;i<all.length;i++){
        //         all[i].isDisplayed().then(function(visible){
        //             fcommon_obj.__log(i + ': ' + visible);
        //         });
        //     }
        // });

        let loader = element.all(by.css('[class="content-loading-spinner"]')).get(index);

        if (bCheckLoading) {
            browser.wait(ec.visibilityOf(loader), 300000).then(function () {
                console.log('..... Loading Start.....: ' + ++iLoadingAppear);
            });

            browser.wait(ec.invisibilityOf(loader), 300000).then(function () {
                console.log('..... Loading Complete.....: ' + ++iLoadingDisappear);
            });
        }

        // browser.wait(ec.elementToBeClickable(this._BottomMenu_PrivacyPolicy), 50000, 'page not ready');
        if (el != null)
            browser.wait(ec.elementToBeClickable(el), 300000, 'page not ready'); ////browser.wait(ec.visibilityOf(el), 300000, 'page not ready');


        browser.sleep(3000);
        // }


    };

    this.__wait4Loading = function (el, bCheckLoading = true, index = 0) {

        __Wait4Loading(el, bCheckLoading, index);

    };

    this.__wait4Loading_Dialog = function (el, bCheckLoading = true, index = 0) {

        let iLoadingAppear = 0;
        let iLoadingDisappear = 0;

        element.all(by.css('[class="ng-modal-dialog-loading"]')).then(function (all) {
            fcommon_obj.__log(all.length);
            for (let i = 0; i < all.length; i++) {
                all[i].isDisplayed().then(function (visible) {
                    fcommon_obj.__log(i + ': ' + visible);
                });
            }
        });

        let loader = element.all(by.css('[class="ng-modal-dialog-loading"]')).get(index);

        if (bCheckLoading) {
            browser.wait(ec.visibilityOf(loader), 300000).then(function () {
                console.log('..... Loading Start.....: ' + ++iLoadingAppear);
            });

            browser.wait(ec.invisibilityOf(loader), 900000).then(function () {
                console.log('..... Loading Complete.....: ' + ++iLoadingDisappear);
            });
        }

        // browser.wait(ec.elementToBeClickable(this._BottomMenu_PrivacyPolicy), 50000, 'page not ready');
        if (el != null)
            browser.wait(ec.elementToBeClickable(el), 1000000, 'page not ready');

        browser.sleep(3000);
        // }


    };

    this.__wait4PageReady = function (pagename, element, iTimeout) {

        fcommon_obj.__isElementPresent(element, pagename, iTimeout);
        fcommon_obj.__isElementDisplayed(element, pagename, iTimeout);
        fcommon_obj.__isElementEnabled(element, pagename);

    };

    this.__wait4ObjectInvisible = function (el) {

        browser.wait(ec.invisibilityOf(el), 300000).then(function () {
        });

    };


    this.__activateBrowser = function (bEdge = true) {
        let absolutePath_exe, actCmd;
        if (bEdge)
            absolutePath_exe = path.resolve(__dirname, '../../common/utilities/ActivateBrowse.exe');

        // actCmd = '"' + absolutePath_exe + '"' + ' ' + browser.params.pageTitle;

        actCmd = '"' + absolutePath_exe + '"';
        futil_windows.__runCmd(actCmd);
    };



    this.__clickButton = function (position, bEdge = true) {

        let absolutePath_exe, actCmd;
        absolutePath_exe = path.resolve(__dirname, '../../common/utilities/ClickBrowse_btn_GivenName.exe');
        // actCmd = '"' + absolutePath_exe + '"';
        if (bEdge)
            actCmd = '"' + absolutePath_exe + '"' + ' ' + browser.params.pageTitle + ' ' + position;
        futil_windows.__runCmd(actCmd);

    };

    this.__doSaveAs = function (filename) {

        let absolutePath_file, absolutePath_exe, actCmd;

        absolutePath_file = path.resolve(__dirname, filename);
        absolutePath_exe = path.resolve(__dirname, '../../common/utilities/SaveDataFile.exe');
        actCmd = '"' + absolutePath_exe + '"' + ' ' + '"' + absolutePath_file + '"';
        futil_windows.__runCmd(actCmd);
    };

    this.__WaitFileDownloadCompleted = function (filename) {

        let absolutePath_file, absolutePath_exe, actCmd;

        absolutePath_file = path.resolve(__dirname, filename);
        absolutePath_exe = path.resolve(__dirname, '../../common/utilities/WaitDownloadCompleted.exe');
        actCmd = '"' + absolutePath_exe + '"' + ' ' + '"' + absolutePath_file + '"';
        futil_windows.__runCmd(actCmd);
    };


    let __Click_UIA = function (sObj = '', sInstance = '0') {

        let absolutePath_exe, absolutePath_exe_index, actCmd;


        // switch (sObj) {
        //
        //     case 'OK':
        //         absolutePath_exe = path.resolve(__dirname, '../../common/utilities/UIA/UIA_ClickO_K_Edge.exe');
        //         break;
        //     case 'Upload':
        //         absolutePath_exe = path.resolve(__dirname, '../../common/utilities/UIA/UIA_ClickU_pload_Edge.exe');
        //         break;
        //     case 'Browse':
        //         absolutePath_exe = path.resolve(__dirname, '../../common/utilities/UIA/UIA_ClickB_rowse_Edge.exe');
        //         break;
        //     case 'SaveAs':
        //         absolutePath_exe = path.resolve(__dirname, '../../common/utilities/UIA/UIA_ClickS_aveAs_Edge.exe');
        //         break;
        //     default:
        //         throw new Error('Incorrect input menu name [' + sObj + ']');
        // }

        absolutePath_exe = path.resolve(__dirname, '../../common/utilities/UIA/UIA_Click_Edge.exe');
        absolutePath_exe_index = path.resolve(__dirname, '../../common/utilities/UIA/UIA_Click_Edge_Index.exe');
        if (sInstance === '0')
            actCmd = '"' + absolutePath_exe + '"' + ' ' + sObj;
        else
            actCmd = '"' + absolutePath_exe_index + '"' + ' ' + sObj + ' ' + sInstance;

        futil_windows.__runCmd(actCmd);

    };

    this.__click_UIA = function (sObj = '', sInstance = '0') {
        __Click_UIA(sObj, sInstance);
    };

    /***
     * pcommon_page.__selectTab('Set up Plan Scenario');
     * pcommon_page.__selectTab('Select Metrics and Triggers');
     * pcommon_page.__selectTab('Select Insurers');
     */
    this.__selectTab = function (tabName) {


        let tab;

        // switch (tabName) {
        //     case 'Set up Plan Scenario':
        //         tab = element.all(by.cssContainingText('a', 'Set up Plan Scenario')).first();
        //         break;
        //     case 'Select Metrics and Triggers':
        //         tab = element.all(by.cssContainingText('a', 'Select Metrics and Triggers')).first();
        //         break;
        //     case 'Select Insurers':
        //         tab = element.all(by.cssContainingText('a', 'Select Insurers')).first();
        //         break;
        //     case 'Client Files':
        //         tab = element.all(by.cssContainingText('a', 'Client Files')).first();
        //         break;
        //     case 'Insurer Files':
        //         tab = element.all(by.cssContainingText('a', 'Insurer Files')).first();
        //         break;
        //     default:
        //         throw new Error('Incorrect input tab name [' + tabName + ']');
        //         break;
        // }

        tab = element.all(by.cssContainingText('.ui-tabs-anchor', tabName)).first();

        fcommon_obj.__click(tabName, tab);
        __Wait4Loading(tab, false);

    };


    /***
     * pcommon_page.__ClickIcon('Add Document');
     * pcommon_page.__ClickIcon('Delete Selected');
     * pcommon_page.__ClickIcon('Download Selected');
     */
    this.__ClickIcon = function (iconName) {

        let icon;

        switch (iconName) {
            case 'Add Document':
                break;
            case 'Delete Selected':
                break;
            case 'Download Selected':
                break;
            case 'Download All':
                break;
            case 'Send Link':
                break;
            default:
                throw new Error('Incorrect input tab name [' + tabName + ']');
                break;
        }

        let iVisible = 0;
        element.all(by.css('[title="' + iconName + '"]')).then(function (all) {
            fcommon_obj.__log('Icon: ' + iconName + ' total instance: ' + all.length);
            for (let i = 0; i < all.length; i++) {
                all[i].isDisplayed().then(function (visible) {
                    iVisible = i;
                    fcommon_obj.__log(iVisible + ': ' + visible);
                    if (visible) {
                        // fcommon_obj.__ElementScrollIntoView(element.all(by.css('[title="' + iconName + '"]')).get(iVisible));
                        fcommon_obj.__click(iconName, element.all(by.css('[title="' + iconName + '"]')).get(iVisible));
                    }

                });
            }
        });
    };

    this.__openDataFile = function (filename) {

        let absolutePath_file, absolutePath_exe, actCmd;
        absolutePath_file = path.resolve(__dirname, filename);
        absolutePath_exe = path.resolve(__dirname, '../../common/utilities/OpenDataFile.exe');
        actCmd = '"' + absolutePath_exe + '"' + ' ' + '"' + absolutePath_file + '"';
        futil_windows.__runCmd(actCmd);
    };

    this.ClickButtonToClosePopup = function (myElement, sDescription, buttonName) {

        let popDialog = myElement.$('div[ng-style="dialogStyle"]').$('div[class="ng-modal-dialog-buttonpane"]');

        popDialog.isPresent().then(function (elementPresent) {
            if (elementPresent) {
                // popDialog.$('button[ng-click="onSuccess(true) ? closeModal() : null"]').click().then (function ()
                popDialog.element(by.cssContainingText('button', buttonName)).click().then(function () {
                    fcommon_obj.__log('Step---Pop dialog ' + sDescription + ' shown, click ' + buttonName + ' button ');
                    browser.sleep(3000);
                });
            }
            else {
                fcommon_obj.__log('Step---Pop dialog ' + sDescription + ' Not shown');
            }

        })
    }


};
module.exports = common_page;

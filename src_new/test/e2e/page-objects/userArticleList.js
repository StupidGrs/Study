/**
 * Created by webber-ling on 7/22/2020.
 */


"use strict";

const common_obj = require('../common/common_obj');
const fcommon_obj = new common_obj();
const common_page = require('./common_page');
const pcommon_page = new common_page();


const userArticleList_page = function () {

    /////////////////////////               page elements            ////////////////////////////////////

    this._lstSelectedContentType = element(by.css('[id=selectedContentType]'));



    /////////////////////////               page functions            ////////////////////////////////////


    /***
     * puserArticleList_page.__selectedContentType('event');
     *
     * @param sStatus
     * @param sType
     * @param sSearchContent
     * @private
     */
    this.__selectedContentType = function (sType) {

        fcommon_obj.__selectByText('_lstSelectedContentType', this._lstSelectedContentType, sType);


    };


    /***
     * puserArticleList_page.__verifyPostsExist(td_EventDetails.EventName);
     *
     * @param sConent
     * @param bExist
     * @private
     */
    this.__verifyPostsExist = function(sConent, bExist = true){


        let objToCheck = element(by.cssContainingText('a', sConent));

        if(bExist)
            fcommon_obj.__wait4ElementVisible(objToCheck, 'Check object visible: ' + sConent);
        else
            fcommon_obj.__wait4ElementInvisible(objToCheck, 'Check object invisible: ' + sConent);

    };


    /***
     * puserArticleList_page.__selectPosts(td_EventDetails.EventName);
     *
     * @param sConent
     * @private
     */
    this.__selectPosts = function(sConent){

        let objToClick = element(by.cssContainingText('a', sConent));

        // fcommon_obj.__click(sConent, objToClick);
        fcommon_obj.__executeScript(objToClick, sConent, "click");

        browser.sleep(browser.params.userSleep.short)

    };

};
module.exports = userArticleList_page;



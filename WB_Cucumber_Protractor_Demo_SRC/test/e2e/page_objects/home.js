/**
 * Created by webber-ling on 9/28/2020.
 */


"use strict";
const chai = require('chai');
const chaiAsPromised = require('chai-as-promised');
chai.use(chaiAsPromised);
const expect = chai.expect;

const common_obj = require('../common/common_obj');
const fcommon_obj = new common_obj();
// const common_page = require('./common_page');
// const pcommon_page = new common_page();


const home_page = function () {

    /////////////////////////               page elements            ////////////////////////////////////

    this._txtWelcome = element.all(by.cssContainingText('h2', 'Trending News & Blogs')).first();
    this._tabEvent = element.all(by.cssContainingText('h5', 'Events')).first();
    this._tabNews = element.all(by.cssContainingText('h5', 'News')).first();
    this._tabResearch = element.all(by.cssContainingText('h5', 'Research')).first();

    this._btnPublish = element(by.css('[id="header_855538167"]'));

    this._iconPublish_Event = element(by.css('[alt="Event"]'));
    this._iconPublish_NewsBlog = element(by.css('[alt="News/Blog"]'));
    this._iconPublish_ResearchWhitePaper = element(by.css('[alt="Research/WhitePaper"]'));
    this._txtPublish_Header = element(by.css('h2[id^="publish-content-form_"]'));


    /////////////////////////               page functions            ////////////////////////////////////


    /***
     * pcommon_publish.__Publish('Event');
     * pcommon_publish.__Publish('News/Blog');
     * pcommon_publish.__Publish('Research/WhitePaper');
     * @param sType
     * @private
     */
    this.__Publish = async function (sType) {

        switch (sType) {
            case 'Event':
                break;
            case 'Research/WhitePaper':
                break;
            case 'News/Blog':
                break;
            default:
                throw new Error('Incorrect input type name [' + sType + ']');
        }

        await fcommon_obj.__executeScript(this._btnPublish, '_btnPublish', "click");


        if (sType === 'Event') {
            await fcommon_obj.__executeScript(this._iconPublish_Event, '_iconPublish_Event', "click");
            return expect(await this._txtPublish_Header.getText(), '_txtPublish_Header').to.equal('Publish Your Event');
        }

        if (sType === 'News/Blog') {
            await fcommon_obj.__executeScript(this._iconPublish_NewsBlog, '_iconPublish_NewsBlog', "click");
            return expect(await this._txtPublish_Header.getText(), '_txtPublish_Header').to.equal('Publish Your News');
        }

        if (sType === 'Research/WhitePaper') {
            await fcommon_obj.__executeScript(this._iconPublish_ResearchWhitePaper, '_iconPublish_ResearchWhitePaper', "click");
            return expect(await this._txtPublish_Header.getText(), '_txtPublish_Header').to.equal('Publish Your Research');
        }



        // fcommon_obj.__click('_iconPublish_Event', this._iconPublish_Event);

        // fcommon_obj.__wait4ElementVisible(element.all(by.css('[name=Username]')).first(), 'Login-Username');

    };



};
module.exports = home_page;

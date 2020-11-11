/**
 * Created by webber-ling on 28/09/2020.
 */

const chai = require('chai');
const chaiAsPromised = require('chai-as-promised');
chai.use(chaiAsPromised);
const expect = chai.expect;
var { Given, Then, When, And } = require("cucumber");
const { setDefaultTimeout } = require('cucumber');
setDefaultTimeout(browser.params.timeouts.page_timeout);
const dateformat = require('dateformat');

const common_obj = require('../common/common_obj');
const fcommon_obj = new common_obj();
// const common_page = require('./common_page');
// const pcommon_page = new common_page();
const home_page = require('../page_objects/home');
const phome_page = new home_page();
const events_page = require('../page_objects/events');
const pevents_page = new events_page();
const news_page = require('../page_objects/news');
const pnews_page = new news_page();
const research_page = require('../page_objects/research');
const presearch_page = new research_page();
const publish_event = require('../page_objects/publish_event');
const ppublish_event = new publish_event();


Given('User logs in as {string}', async (user) => {

    fcommon_obj.__log(user);
    browser.get(browser.params.url_test + '/v1/api/msso/dev/login/' + user);
    return fcommon_obj.__isElementDisplayedContainingText(phome_page._txtWelcome, 'Trending News & Blogs', '_txtWelcome');

});

When('User clicks tab {string}', async (tab) => {

    switch (tab) {
        case 'Events':
            return fcommon_obj.__click('phome_page._tabEvent', phome_page._tabEvent);
            break;
        case 'Research':
            return fcommon_obj.__click('phome_page._tabResearch', phome_page._tabResearch);
            break;
        case 'News':
            return fcommon_obj.__click('phome_page._tabNews', phome_page._tabNews);
            break;
        default:
            throw new Error('Incorrect input tab name [' + tab + ']');

    }


});

Then('{string} page displays with header {string}', async (tab, header) => {


    switch (tab) {
        case 'Events':
            return fcommon_obj.__isElementDisplayedContainingText(pevents_page._txtWelcome, header, '_txtWelcome');
            break;
        case 'Research':
            return fcommon_obj.__isElementDisplayedContainingText(presearch_page._txtWelcome, header, '_txtWelcome');
            break;
        case 'News':
            return fcommon_obj.__isElementDisplayedContainingText(pnews_page._txtWelcome, header, '_txtWelcome');
            break;
        default:
            throw new Error('Incorrect input tab name [' + tab + ']');
    }


});

When('User clicks publish -> {string}', async (type) => {

    switch (type) {
        case 'Event':
            break;
        case 'Research/WhitePaper':
            break;
        case 'News/Blog':
            break;
        default:
            throw new Error('Incorrect input type name [' + type + ']');
    }
    return phome_page.__Publish(type);

});

When('User fills in the basic info {string}, {string}, {string}, {string}', async (name, excerpt, url, content) => {

    await ppublish_event.__IsOnPage();
    return ppublish_event.__SetBasicInfo(name, excerpt, url, content);
});

When('User fills in the Company, EventType, Location info {string}, {string}, {string}', async (company, eventType, location) => {

    return ppublish_event.__SetCompanyEventTypeLocation(company, eventType, location);
});

When('User fills in Start Date and Start Time {string}, {string}', async (date, time) => {

    let currentDate = new Date();
    return ppublish_event.__SetDateTime(currentDate, time, true);

});

When('User fills in End Date and End Time {string}, {string}', async (date, time) => {

    let currentDate = new Date();
    let endDate = dateformat(currentDate.setDate(currentDate.getDate() + 1), 'd-mmm-yyyy');
    return ppublish_event.__SetDateTime(endDate, time, false);

});

When('User fills in Taxonomy and Tags {string}, {string}', async (taxonomy, tag) => {

    return ppublish_event.__SetTaxonomyTags(taxonomy, tag);

});

When('User uploads featured image {string}', async (image) => {

    return ppublish_event.__UploadImage(image);

});

When('User selects regions {string}', async (region) => {

    return ppublish_event.__SelectRegion(region);

});


When('User sleeps {int} seconds', async (seconds) => {


    await browser.sleep(seconds * 1000);
    return;


});


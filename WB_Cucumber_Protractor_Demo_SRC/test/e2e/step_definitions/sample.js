const chai = require('chai');
const chaiAsPromised = require('chai-as-promised');
chai.use(chaiAsPromised);
const expect = chai.expect;
var { Given, Then, When } = require("cucumber");
const { setDefaultTimeout } = require('cucumber');
setDefaultTimeout(300 * 1000);



// Given('User logs in as {string}', async (user) => {
//     console.log(user);
//     const email = 'test';
//     // URL to skip login page
//
//     const loginURL = browser.params.url_test;
//     console.log(loginURL);
//
//     await browser.get(loginURL);
//
//
//     //check header logo is displayed
//     // await browser.sleep(5 * 1000);
//     // const elem = await element(by.css(headerLogo));
//     // const isLogoVisible = await elementHelper.isElementVisible(elem);
//     // return expect(browser.getCurrentUrl(), url).to.equal(true);
//     return expect(1, 'assert').to.equal(2);
// });






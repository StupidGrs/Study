/**
 * Here will be application specific action step methods.
 *
 * Next ngpd-merceros-testautomation-ta can be helpful, add them to project if needed:
 * fileHelper -> contains methods to work with files.
 * stringHelper -> contains methods to work with string.
 * endpointHelper -> contains methods to work with GET & POST requests.
 */
require('../support/parameter-types');
const { When } = require('cucumber');
const { elementHelper } = require('ngpd-merceros-testautomation-ta');
const loginPage = require('../../data/page-selectors/login-page');
const path = require('path');
const { setDefaultTimeout } = require('cucumber');
const BROWSER = process.env.BROWSER_NAME || 'chrome';
const api_request = require('./utils/api_requests');
const utils = require('./utils/utils');
const headerLogo = require('./../../data/page-selectors/header').logo;
const chai = require('chai');
const chaiAsPromised = require('chai-as-promised');
chai.use(chaiAsPromised);
const expect = chai.expect;
const baseUrl_BE = require('../../data/api/dbDataAccess').baseUrl_BE;



//  const timeOut24h = 24 * 60 * 60000;
//  setDefaultTimeout(timeOut24h);
setDefaultTimeout(300 * 1000);

/**
 * Execute login for specified user on specified URL.
 * User and url information is taken from user-data.js
 *
 * @example
 * User logs in as "ADMIN" on "PROJECT_NAME"
 *
 * Remove after reading: this method is presented as template
 * of usage ngpd-merceros-testautomation-ta and user-data.js.
 * Method should be changed with project needs.
 *
 * @param user should be named as in user-data.js
 * @param url should be named as in user-data.js
 */
When('User logs in as {user} on {landing-url}', async (user, url) => {
    console.log("test");
  const email = user.email;
  // URL to skip login page
  const loginURL = `${baseUrl_BE}/msso/dev/login/${email}`;
  await browser.get(loginURL);

  console.log(loginURL);
  //check header logo is displayed
  await browser.sleep(5 * 1000);
  const elem = await element(by.css(headerLogo));
  const isLogoVisible = await elementHelper.isElementVisible(elem);
  return expect(isLogoVisible, `Login failed - logo is not visible`).to.equal(true);
});

When('User makes upload of file {text} using {detail} {css}', async (fileName, __, cssLocator) => {
  const fileToUpload = '../../features/test-data/file-templates/' + fileName;
  const absolutePath = path.resolve(__dirname, fileToUpload);
  const form = await elementHelper.getElementByCss(cssLocator);
  if (BROWSER === 'MicrosoftEdge') {
    await browser.executeScript(`arguments[0].removeAttribute('hidden')`, await form.getWebElement());
  };
  return form.sendKeys(absolutePath);
});

When('User navigates to {text} URL with title {text}', async (resource, resourceTitle) => {
  const resourceUrl = await api_request.getResourceUrlByTitle(resource, resourceTitle);
  console.log('------------------  resourceUrl: ' + resourceUrl);

  return browser.get(resourceUrl);
});

When('User waits for {detail} {css} initital text {text} change', async (_, cssLocator, initialText) => {
  const endTime = Date.now() + browser.params.timeout;
  let elementText;
  do {
    elementText = await utils.getElementText(cssLocator);
  } while ((Date.now() <= endTime) && (elementText === initialText));

  if ((Date.now() > endTime)) {
    throw new Error(`"${_}" text did not change. Wait timed out after ${browser.params.timeout}ms.`);
  };

  return;
});

When('User scrolls page to top', async () => {
  const modalCss = 'div.mos-c-modal__content__container';
  const bodyCss = 'body';

  const isModalOnView = await element(by.css('div.mos-c-modal__content__container')).isPresent();
  const elemToScrollCss = isModalOnView ? modalCss : bodyCss;
  const elemToScroll = await element(by.css(elemToScrollCss)).getWebElement();
  
  return browser.executeScript('arguments[0].scrollIntoView(true)', elemToScroll);
});

/**
 * Press CTRL key and click item with text
 * @example:
 * User holds CTRL key and selects Region "moderateResearchPage|regionsFieldOptionsList" with text "US"
 */
When('User holds CTRL key and selects {detail} {css} with text {text}', async function (_, cssLocator, text) {
  const elem = await elementHelper.getElementByCssContainingText(cssLocator, text);
  return browser.actions()
    .mouseMove(elem)
    .keyDown(protractor.Key.CONTROL)
    .click()
    .keyUp(protractor.Key.CONTROL)
    .perform();
});

/**
 * Click element by CSS with text by executing script.
 *
 * @example:
 * User clicks Search button "#searchButton" with text "search" using script
 *
 * @param _ - element description
 * @param cssLocator
 * @param text
 */
When('User clicks {detail} {css} with text {text} using script', async (_, css, text) => {
  const elem = await elementHelper.getElementByCssContainingText(css, text);
  return browser.executeScript('arguments[0].click()', await elem.getWebElement());
});
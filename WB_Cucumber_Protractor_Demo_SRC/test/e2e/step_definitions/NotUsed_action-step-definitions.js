const {Given, When} = require('cucumber');
const helper = require('../../helps/element-helper.js');
const stringHelper = require('../../helps/string-helper.js');
const path = require('path');
const actionHelper = require('../../helps/action-helper');


//
// /**
//  * Print additional details into test log.
//  *
//  * @example:
//  * User prints comment "Click on Submit button"
//  *
//  * @param comment - string to be printed in log
//  */
// Given('User prints comment {text}', function (comment) {
//     return console.log(comment);
// });
//
// /**
//  * If set to false, Protractor will not wait for Angular $http and $timeout
//  * tasks to complete before interacting with the browser.
//  *
//  * @example:
//  * User waits for angular "true"
//  * User waits for angular "false"
//  *
//  * @param waitForAngular
//  */
// When('User waits for angular {text}', function (waitForAngular) {
//     return browser.waitForAngularEnabled(waitForAngular === 'true');
// });
//
// /**
//  * Click element by CSS.
//  *
//  * @example:
//  * User clicks Search button "#searchButton"
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// When('User clicks {detail} {css}', async function (_, cssLocator) {
//     const elem = await helper.getElementByCss(cssLocator);
//     return helper.clickOnElement(elem);
// });
//
// /**
//  * Click element by CSS by executing script.
//  *
//  * @example:
//  * User clicks Search button "#searchButton" by executing script
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// When('User clicks {detail} {css} by executing script', async (_, css) => {
//     const elem = await helper.getElementByCss(css);
//     return browser.executeScript('arguments[0].click()', await elem.getWebElement());
// });
//
// /**
//  * Click element by CSS with text by executing script.
//  *
//  * @example:
//  * User clicks Search button "#searchButton" with text "search" by executing script
//  *
//  * @param _ - element description
//  * @param cssLocator
//  * @param text
//  */
// When('User clicks {detail} {css} with text {string} by executing script', async (_, css, text) => {
//     const elem = await helper.getElementByCssContainingText(css, text);
//     return browser.executeScript('arguments[0].click()', await elem.getWebElement());
// });
//
// /**
//  * Click element by CSS which contain a certain string.
//  *
//  * @example:
//  * User clicks link ".chapter" with text "Chapter 5"
//  *
//  * @param _ - element description
//  * @param cssLocator
//  * @param text
//  */
// When('User clicks {detail} {css} with text {text}', async function (_, cssLocator, text) {
//     const elem = await helper.getElementByCssContainingText(cssLocator, text);
//     return helper.clickOnElement(elem);
// });
//
// /**
//  * Click element by CSS with text equal to string.
//  *
//  * @example:
//  * User clicks link ".chapter" with text equal to "Chapter 5"
//  *
//  * @param _ - element description
//  * @param cssLocator
//  * @param text
//  */
// When('User clicks {detail} {css} with text equal to {text}', async function (_, cssLocator, textToFind) {
//     const collection = await $$(cssLocator).asElementFinders_();
//
//     for (let element of collection) {
//         const text = await element.getText();
//         if (text.toLowerCase() === textToFind.toLowerCase()) {
//             return helper.clickOnElement(element);
//         }
//     }
//
//     throw new Error(`No such element by locator: ${cssLocator} and text ${textToFind}`);
// });
//
// /**
//  * Click browser back button.
//  *
//  * @example:
//  * User clicks browser back button
//  */
// When('User clicks browser back button', function () {
//     return browser.navigate().back();
// });
//
// /**
//  * Double click element by CSS.
//  *
//  * @example:
//  * User clicks browser back button
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// When('User double clicks {detail} {css}', async function (_, cssLocator) {
//     return (await helper.getElementByCss(cssLocator)).doubleClick();
// });
//
// /**
//  * Click child element by CSS which contain a certain string
//  * within parent element by CSS which contain a certain string.
//  *
//  * @example:
//  * User clicks button "button" with text "Begin" on field ".card" with text "Test 1"
//  *
//  * @param _ - child element description
//  * @param childCssLocator
//  * @param childText
//  * @param __ - parent element description
//  * @param parentCssLocator
//  * @param parentText
//  */
// When('User clicks {detail} {css} with text {text} on {detail} {css} with text {text}', async function (_, childCssLocator, childText, __, parentCssLocator, parentText) {
//     const collection = await $$(parentCssLocator).asElementFinders_();
//     const regexp = stringHelper.getExactStringRegexp(parentText);
//     let childElement;
//
//     for (let item of collection) {
//         if ((await item.getText()).match(regexp)) {
//             // parent found
//             childElement = item.element(by.cssContainingText(childCssLocator, childText));
//             break;
//         }
//     }
//
//     return helper.clickOnElement(childElement);
// });
//
// /**
//  * Click child element by CSS within parent element by CSS which contain a certain string.
//  *
//  * @example:
//  * User clicks close icon ".close" on Company chip "#CompanyChipContainer" with text "Belarus"
//  *
//  * @param _ - child element description
//  * @param childCssLocator
//  * @param __ - parent element description
//  * @param parentCssLocator
//  * @param parentText
//  */
// When('User clicks {detail} {css} on {detail} {css} with text {text}', async function (_, childCssLocator, __, parentCssLocator, parentText) {
//     const parent = await helper.getElementByCssContainingText(parentCssLocator, parentText);
//     const child = parent.element(by.css(childCssLocator));
//     return helper.clickOnElement(child);
// });
//
// /**
//  * Click child element by CSS locator within parent element by CSS.
//  *
//  * @example:
//  * User clicks plus button "button#plus" on company row ".row .company"
//  *
//  * @param _ - child element description
//  * @param childCssLocator
//  * @param __ - parent element description
//  * @param parentCssLocator
//  */
// When('User clicks {detail} {css} on {detail} {css}', async function (_, childCssLocator, __, parentCssLocator) {
//     const parent = await helper.getElementByCss(parentCssLocator);
//     const child = parent.element(by.css(childCssLocator));
//     return helper.clickOnElement(child);
// });
//
// /**
//  * Click child element by CSS locator within parent element by CSS which contains some icon.
//  *
//  * @example:
//  * User clicks plus button "button#plus" on company row ".row .company" with icon "#icon-add"
//  *
//  * @param _ - child element description
//  * @param childCssLocator
//  * @param __ - parent element description
//  * @param parentCssLocator
//  * @param iconLocator
//  */
// When('User clicks {detail} {css} on {detail} {css} with icon {css}', async (_, childCssLocator, __, parentCssLocator, cssLocator) => {
//     const parent = await helper.getElementByCss(parentCssLocator);
//     const isPresent = await parent.element(by.css(cssLocator)).isPresent();
//     if (isPresent) {
//         const child = parent.element(by.css(childCssLocator));
//         return await helper.clickOnElement(child);
//     }
// });
//
//
// /**
//  * Click child element by CSS locator within parent element by CSS after some element with text
//  *
//  * @example:
//  * User clicks on Kickoff Date cell "renewalsPage|kickOffDateCell" on row "renewalsPage|renewalsRow" after Renewal list row "renewalsPage|rowByRenewalStatus" with text "Future"
//  *
//  * @param _ - child element description
//  * @param childCssLocator
//  * @param __ - parent element description
//  * @param parentCssLocator
//  * @param nextElement
//  * @param text
//  */
// When('User clicks {detail} {css} on {detail} {css} after {detail} {css} with text {text}', async (_, childCssLocator, __, nextElement, ___, parentCssLocator, text,) => {
//     const parentElement = await helper.getNextElementAfterParentWithText(parentCssLocator, text, nextElement);
//     const childElement = parentElement.element(by.css(childCssLocator));
//     return await helper.clickOnElement(childElement);
// });
//
// /**
//  * Select from dropdown - firstly click dropdown by CSS to expand, then select item by CSS.
//  *
//  * @example:
//  * User selects Engineer item "#engineerItem" from Job dropdown "#dropdownContainer"
//  *
//  * @param _ - item element description
//  * @param itemCssLocator - should be unique child css locator
//  * using this in the dropdownCssLocator + itemCssLocator duet.
//  * @param __ - dropdown element description
//  * @param dropdownCssLocator - should contain dropdown container css
//  * that is the parent for itemCssLocator.
//  * If dropdown element stores in <input> tag, this tag will apply automatically.
//  * No needs to provide it as part of dropdownCssLocator.
//  */
// When('User selects {detail} {css} from {detail} {css}', async function (_, itemCssLocator, __, dropdownCssLocator) {
//     const parentElement = await helper.getElementByCss(dropdownCssLocator);
//     const inputChildElement = parentElement.element(by.css('input'));
//     if (await helper.isElementNotVisible(inputChildElement, 1000)) {
//         await helper.clickOnElement(parentElement);
//     } else {
//         await helper.clickOnElement(inputChildElement);
//     }
//     return parentElement.element(by.css(itemCssLocator)).click();
// });
//
// /**
//  * Select from dropdown - firstly click dropdown by CSS to expand,
//  * then select item by CSS which contain a certain string.
//  *
//  * @example:
//  * User selects item "li" with text "Engineer" from Job dropdown "#dropdownContainer"
//  *
//  * @param itemCssLocator - should be not-unique child css locator as tag name for list elements.
//  * @param itemText - should be unique text that give unique combination for itemCssLocator + itemText duet.
//  * @param _ - dropdown element description
//  * @param dropdownCssLocator - should contain dropdown container css
//  * that is the parent for itemCssLocator.
//  * If dropdown element stores in <input> tag, this tag will apply automatically.
//  * No needs to provide it as part of dropdownCssLocator.
//  */
// When('User selects item {css} with text {text} from {detail} {css}', async function (itemCssLocator, itemText, _, dropdownCssLocator) {
//     const parentElement = await helper.getElementByCss(dropdownCssLocator);
//     const inputChildElement = parentElement.element(by.css('input'));
//     if (await helper.isElementNotVisible(inputChildElement, 1000)) {
//         await helper.clickOnElement(parentElement);
//     } else {
//         await helper.clickOnElement(inputChildElement);
//     }
//     return parentElement.element(by.cssContainingText(itemCssLocator, itemText)).click();
// });
//
// /**
//  * Select checkbox or radio button element by CSS.
//  *
//  * @example:
//  * User selects No radio button "#no-button"
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// When('User selects {detail} {css}', async function (_, cssLocator) {
//     const elem = await helper.getElementByCss(cssLocator);
//     return helper.clickOnElement(elem);
// });
//
//
// /**
//  * Select checkbox or radio button element by CSS which contain a certain string.
//  *
//  * @example:
//  * User selects No radio button "#radio-button" with text "No"
//  *
//  * @param _ - element description
//  * @param cssLocator
//  * @param text
//  */
// When('User selects {detail} {css} with text {text}', async function (_, cssLocator, text) {
//     const elem = await helper.getElementByCssContainingText(cssLocator, text);
//     return helper.clickOnElement(elem);
// });
//
// /**
//  * Unselect already selected checkbox element by CSS.
//  *
//  * @example:
//  * User unselects 2018 checkbox "#checboxId"
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// When('User unselects {detail} {css}', async function (_, cssLocator) {
//     const elem = await helper.getElementByCss(cssLocator);
//     return helper.clickOnElement(elem);
// });
//
// /**
//  * Enter text in text field by CSS.
//  * NOTE: Because of issues in components in FF , we have to send text by chars
//  * @example:
//  * User enters "test" in Search field "#search-field"
//  *
//  * @param text
//  * @param __ - element description
//  * @param cssLocator
//  */
// When('User enters {text} in {detail} {css}', async function (text, _, cssLocator) {
//     // FF has an issue with sending keys. This workaround helps to completely send all text into field.
//     const isFerfox = await browser.getCapabilities().then(caps => {
//         return caps.get('browserName').toLowerCase() === 'firefox';
//     });
//
//     let elem = await helper.getElementByCss(cssLocator);
//     if (isFerfox) {
//         for (let i = 0; i < text.length; i++) {
//             await elem.sendKeys(text.charAt(i));
//         }
//     } else {
//         await elem.sendKeys(text);
//     }
//     // need two seconds for completing animation
//     return browser.sleep(2000);
// });
//
//
// /**
//  * Enter random value in text field by CSS.
//  *
//  * @example:
//  * User enters random value in Search field "#search-field"
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// When('User enters random value in {detail} {css}', async function (_, cssLocator) {
//     const text = stringHelper.getRandomString(10);
//     const elem = await helper.getElementByCss(cssLocator);
//
//     // TODO: issue with FF ??
//     return elem.sendKeys(text);
// });
//
// /**
//  * Clear text from text field by CSS.
//  *
//  * @example:
//  * User clear text from Search field "#search-field"
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// When('User clears text from {detail} {css}', function (_, cssLocator) {
//     // webdriver clear() doesn't update angular forms: https://github.com/angular/protractor/issues/301
//     return helper.clearTextFromElement(cssLocator);
// });
//
// /**
//  * Move mouse over element by CSS.
//  *
//  * @example:
//  * User moves mouse over Input field "#input-field"
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// When('User moves mouse over {detail} {css}', async function (_, cssLocator) {
//     const elem = await helper.getElementByCss(cssLocator);
//     return browser.actions().mouseMove(elem).perform();
// });
//
// /**
//  * Move mouse over element by CSS with text.
//  *
//  * @example:
//  * User moves mouse over Input field "mercer-icon title" with text "poll"
//  *
//  * @param _ - element description
//  * @param cssLocator
//  * @param text
//  */
// When('User moves mouse over {detail} {css} with text {text}', async function (_, cssLocator, text) {
//     const elem = await helper.getElementByCssContainingText(cssLocator, text);
//     return browser.actions().mouseMove(elem).perform();
// });
//
// /**
//  * Refresh browser page.
//  *
//  * @example:
//  * User refreshes page
//  */
// When('User refreshes page', function () {
//     return browser.navigate().refresh();
// });
//
// /**
//  * Open new browser tab.
//  *
//  * @example:
//  * User opens new browser tab
//  */
// When('User opens new browser tab', function () {
//     return browser.executeScript('window.open()').then(function () {
//         return browser.getAllWindowHandles().then(function (handles) {
//             let secondWindow = handles[1];
//             return browser.switchTo().window(secondWindow);
//         });
//     });
// });
//
// /**
//  * Wait needed amount of seconds.
//  *
//  * @example:
//  * User waits 5 seconds
//  */
// When('User waits {int} second(s)', {timeout: 35 * 60 * 1000}, function (seconds) {
//     return browser.sleep(seconds * 1000);
// });
//
// /**
//  * Navigate to appropriate browser tab.
//  *
//  * @example:
//  * User goes to 2 browser tab
//  */
// When('User goes to {int} browser tab', function (tab) {
//     return browser.getAllWindowHandles().then((handles) => {
//         return browser.switchTo().window(handles[tab - 1]);
//     })
// });
//
// /**
//  * Restart browser.
//  *
//  * @example:
//  * User restarts browser
//  */
// When('User restarts browser', function () {
//     return browser.restart();
// });
//
// /**
//  * Navigate to appropriate url.
//  *
//  * @example:
//  * User navigates to "http://oursite.com"
//  * User navigates to "PROJECT_NAME"
//  */
// Given('User navigates to {landing-url}', function (url) {
//     return browser.getCurrentUrl().then(currentUrl => {
//         // maybe we are already there?
//         if (currentUrl !== url) {
//             return browser.driver.get(url);
//         }
//     })
// });
//
// /**
//  * Navigate to appropriate url with specific path.
//  *
//  * @example:
//  * User navigates to "http://oursite.com" with second index page "/page2.index"
//  * User nanigates to "PROJECT_NAME" with second index page "/page2.index"
//  */
// When('User navigates to {landing-url} with {detail} {text}', function (url, _, path) {
//     return browser.driver.get(url + path);
// });
//
// /**
//  * Press Enter key.
//  * NOTE: This method doesn't work correct in FF. To press enter in FF use 'User presses Enter key in {detail} {css}'
//  * @example:
//  * User presses Enter key
//  */
// When('User presses Enter key', function () {
//     return browser.actions().sendKeys(protractor.Key.ENTER).perform();
// });
//
// /**
//  * Press Enter key in the element.
//  *
//  * @example:
//  * User presses Enter key in the field "loginPage|passwordInput"
//  */
// When('User presses Enter key in {detail} {css}', async function (_, css) {
//     return (await helper.getElementByCss(css)).sendKeys(protractor.Key.ENTER);
// });
//
// /**
//  * Upload a file using upload form found by css selector.
//  * @param fileName - name of file to be uploaded.
//  * Should be placed only in /features/test-data/ folder of your current project
//  * @param cssLocator upload form css selector
//  *
//  * @example:
//  * When User uploads file "someFileToUpload.xlsx" using form "cssSelectorForm"
//  */
// When('User uploads {detail} {text} using {detail} {css}', async function (_, fileName, __, cssLocator) {
//     const fileToUpload = '../../../features/test-data/' + fileName,
//         absolutePath = path.resolve(__dirname, fileToUpload);
//     console.log(absolutePath);
//     const form = await helper.getElementByCss(cssLocator);
//     return browser.actions().mouseMove(form).perform().then(function () {
//         return form.clear().then(function () {
//             return form.sendKeys(absolutePath);
//         });
//     });
// });
//
// /**
//  * Click on item in collection
//  *
//  * @param itemNumber number of element in collection that should be clicked - started from 1
//  * @param cssLocator upload form css selector
//  * @example:
//  * When User clicks 2 item in "cssSelector" collection
//  */
// When('User clicks {int} item in {css} collection', async (itemNumber, cssLocator) => {
//     const collection = await $$(cssLocator).asElementFinders_();
//     return helper.clickOnElement(collection[itemNumber - 1]);
// });
//
// /**
//  *  Click on item in collection by css with text
//  *
//  * @param itemNumber number of element in collection that should be clicked - started from 1
//  * @param cssLocator upload form css selector
//  * @param text
//  * @example:
//  * When User clicks 2 item in "cssSelector" collection with text "collection name"
//  */
// When('User clicks {int} item in {css} collection with text {text}', async (itemNumber, cssLocator, text) => {
//     const collection = await element.all(by.cssContainingText(cssLocator, text)).asElementFinders_();
//     return helper.clickOnElement(collection[itemNumber - 1]);
// });
//
// /**
//  *  Click on element until it visible
//  *
//  * @param locator css selector for element to click
//  * @example:
//  * When User clicks Pagination Next Icon "cssSelector" until it visible
//  */
// When('User clicks on {detail} {css} until it visible', (_, locator) => {
//     return actionHelper.clickButtonUntilNotDisplayed(locator);
// });
//
// /**
//  *  Click on element until another element with given text will become visible
//  *
//  * @param clickOnElementLocator css selector for element to click
//  * @param elementWithTextLocator css selector for element with text
//  * @param text element text
//  * @example:
//  * When User clicks on Pagination Next Icon "cssSelector" until Table Of Users Items List "cssSelector" with text "abv@aa.aa" will become visible
//  */
// When('User clicks on {detail} {css} until {detail} {css} with text {text} will become visible', (_, clickOnElementLocator, __, elementWithTextLocator, text) => {
//     return actionHelper.clickButtonUntilNotDisplayed(clickOnElementLocator, elementWithTextLocator, text);
// });
//
// /**
//  * @param text text to enter into the field
//  * @param cssLocator css selector for element
//  * @example:
//  * And User enters "Automation Research Content" in Research Content field "publishResearchPage|researchContentField" by executing script
//  */
// When('User enters {text} in {detail} {css} by executing script', async function (text, _, cssLocator) {
//     const elem = await helper.getElementByCss(cssLocator);
//
//     return browser.executeScript(`arguments[0].textContent = '${text}'`, await elem.getWebElement());
// });
//
//



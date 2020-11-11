const chai = require('chai');
const chaiAsPromised = require('chai-as-promised');
const chaiString = require('chai-string');
chai.use(chaiAsPromised);
chai.use(chaiString);
const expect = chai.expect;
const stringHelper = require('../../helps/string-helper.js');
const endpointHelper = require('../../helps/endpoint-helper.js');
const { Then } = require('cucumber');
const helper = require('../../helps/element-helper.js');
const until = protractor.ExpectedConditions;
const path = require('path');
const fileSep = path.sep;// returns '\\' on windows, '/' on *nix
const fileHelper = require('../../helps/file-helper');
const moment = require('moment');
const localizationHelper = require('../../helps/localization-helper');
const sleepTimout = 3000;


//
// /**
//  * Verify that element attribute is present
//  *
//  * @example
//  * Attribute "class" of Search button "#searchButton"  is present
//  *
//  * @param attribute
//  * @param _ - element description
//  * @param cssLocator
//  */
// Then('Attribute {string} of {detail} {css} is present', async (attribute, _, cssLocator) => {
//   const elm = await (await helper.getElementByCss(cssLocator)).getWebElement();
//   return browser.executeScript('var items = {}; \
//          for (index = 0; index < arguments[0].attributes.length; ++index) { \
//              items[arguments[0].attributes[index].name] = arguments[0].attributes[index].value \
//          }; \
//          return items;', elm).then(function (attrs) {
//     return expect(attribute in attrs ? true : false).to.equal(true);
//   });
// });
//
// /**
//  * Verify that element attribute is equal to value.
//  *
//  * @example
//  * Attribute "class" of Search button "#searchButton" is equal to "container"
//  *
//  * @param attribute
//  * @param _ - element description
//  * @param cssLocator
//  * @param value
//  */
// Then('Attribute {text} of {detail} {css} is equal to {text}', async (attribute, _, cssLocator, value) => {
//   return typeof value === 'string' ?
//     expect((await helper.getElementByCss(cssLocator)).getAttribute(attribute)).to.eventually.equal(value) :
//     expect((await helper.getElementByCss(cssLocator)).getAttribute(attribute)).to.eventually.match(value);
// });
//
// /**
//  * Verify that element attribute is not equal to value.
//  *
//  * @example
//  * Attribute "class" of Search button "#searchButton" is not equal to "container"
//  *
//  * @param attribute
//  * @param _ - element description
//  * @param cssLocator
//  * @param value
//  */
// Then('Attribute {text} of {detail} {css} is not equal to {text}', async (attribute, _, cssLocator, value) => {
//   return typeof value === 'string' ?
//     expect((await helper.getElementByCss(cssLocator)).getAttribute(attribute)).to.eventually.not.equal(value) :
//     expect((await helper.getElementByCss(cssLocator)).getAttribute(attribute)).to.eventually.not.match(value);
// });
//
// /**
//  * Verify that element attribute contains value.
//  *
//  * @example
//  * Attribute "class" of Search button "#searchButton" contains "container"
//  *
//  * @param attribute
//  * @param _ - element description
//  * @param cssLocator
//  * @param value
//  */
// Then('Attribute {text} of {detail} {css} contains {text}', async (attribute, _, cssLocator, value) => {
//   return expect((await helper.getElementByCss(cssLocator)).getAttribute(attribute)).to.eventually.contains(value);
// });
//
// /**
//  * Verify that attribute of element with text contains value.
//  *
//  * @example
//  * Attribute "class" of Search button "button" with text "Search" contains "container"
//  *
//  * @param attribute
//  * @param _ - element description
//  * @param cssLocator
//  * @param text - element text
//  * @param value
//  */
// Then('Attribute {text} of {detail} {css} with text {text} contains {text}', async (attribute, _, cssLocator, text, value) => {
//   return expect((await helper.getElementByCssContainingText(cssLocator, text)).getAttribute(attribute)).to.eventually.contains(value);
// });
//
// /**
//  * Verify that attribute of child element within parent element with text contains value.
//  *
//  * @example
//  * Attribute "class" of Edit button "button" on row ".row" with text "Admin" contains "disabled-link"
//  *
//  * @param attribute
//  * @param _ - child element description
//  * @param childCssLocator
//  * @param __ - parent element description
//  * @param parentCssLocator
//  * @param text - parent element text
//  * @param value
//  */
// Then('Attribute {text} of {detail} {css} on {detail} {css} with text {text} contains {text}', async (attribute, _, childCssLocator, __, parentCssLocator, text, value) => {
//   const webElement = (await helper.getElementByCssContainingText(parentCssLocator, text)).element(by.css(childCssLocator));
//   return expect(webElement.getAttribute(attribute)).to.eventually.contains(value);
// });
//
// /**
//  * Verify that attribute of child element within parent element after some element with text contains value.
//  *
//  * @example
//  * Attribute "class" of Kickoff Date cell "renewalsPage|kickOffDateCell" on row "renewalsPage|renewalsRow" after Renewal list row "renewalsPage|rowByRenewalStatus" with text "Completed" contains "--success"
//  *
//  * @param attribute
//  * @param _ - child element description
//  * @param childCssLocator
//  * @param __ - next element description
//  * @param nextElement
//  * @param ___ - parent element description
//  * @param parentCssLocator
//  * @param text - parent element text
//  * @param value
//  */
// Then('Attribute {text} of {detail} {css} on {detail} {css} after {detail} {css} with text {text} contains {text}', async (attribute, _, childCssLocator, __, nextElement, ___, parentCssLocator, text, value) => {
//   const parentElement = await helper.getNextElementAfterParentWithText(parentCssLocator, text, nextElement);
//   const childElement = parentElement.element(by.css(childCssLocator));
//   return expect(await childElement.getAttribute(attribute)).to.contains(value);
// });
//
// /**
//  * Verify that attribute of some element with icon contains value.
//  *
//  * @example
//  * Attribute "class" of Edit button "button" with icon "#editIcon" contains "disabled"
//  *
//  * @param attribute
//  * @param __ - child element description
//  * @param parentCssLocator
//  * @param cssLocator
//  * @param value
//  */
// Then('Attribute {text} of {detail} {css} with icon {css} contains {text}', async (attribute, __, parentCssLocator, cssLocator, value) => {
//   const parent = await helper.getElementByCss(parentCssLocator);
//   const isPresent = await parent.element(by.css(cssLocator)).isPresent();
//   if (isPresent) {
//     return expect(await parent.getAttribute(attribute)).to.contains(value);
//   }
// });
//
// /**
//  * Verify that attribute of some element with icon contains value.
//  *
//  * @example
//  * Attribute "class" of Edit button "button" on row "#row" with icon "#editIcon" contains "disabled"
//  *
//  * @param attribute
//  * @param _ - child element description
//  * @param childCssLocator
//  * @param __ - parent element description
//  * @param parentCssLocator
//  * @param iconCss
//  * @param value
//  */
// Then('Attribute {text} of {detail} {css} on {detail} {css} with icon {css} contains {text}', async (attribute, _, childCssLocator, __, parentCssLocator, iconCss, value) => {
//   const parent = await helper.getElementByCss(parentCssLocator);
//   const isPresent = await parent.element(by.css(iconCss)).isPresent();
//   if (isPresent) {
//     const webElement = await parent.element(by.css(childCssLocator));
//     return expect(await webElement.getAttribute(attribute)).to.contains(value);
//   }
// });
//
// /**
//  * Verify that attribute of child element within parent element with text does not contain value.
//  *
//  * @example
//  * Attribute "class" of Edit button "button" on row ".row" with text "Admin" contains "disabled-link"
//  *
//  * @param attribute
//  * @param _ - child element description
//  * @param childCssLocator
//  * @param __ - parent element description
//  * @param parentCssLocator
//  * @param text - parent element text
//  * @param value
//  */
// Then('Attribute {text} of {detail} {css} on {detail} {css} with text {text} does not contain {text}', async (attribute, _, childCssLocator, __, parentCssLocator, text, value) => {
//   const webElement = (await helper.getElementByCssContainingText(parentCssLocator, text)).element(by.css(childCssLocator));
//   return expect(await webElement.getAttribute(attribute)).to.not.contains(value);
// });
//
// /**
//  * Verify that attribute of child element within parent element after some element with text does not contain value.
//  *
//  * @example
//  * Attribute "class" of Kickoff Date cell "renewalsPage|kickOffDateCell" on row "renewalsPage|renewalsRow" after Renewal list row "renewalsPage|rowByRenewalStatus" with text "Completed" does not contain "--success"
//  *
//  * @param attribute
//  * @param _ - child element description
//  * @param childCssLocator
//  * @param __ - next element description
//  * @param nextElement
//  * @param ___ - parent element description
//  * @param parentCssLocator
//  * @param text - parent element text
//  * @param value
//  */
// Then('Attribute {text} of {detail} {css} on {detail} {css} after {detail} {css} with text {text} does not contain {text}', async (attribute, _, childCssLocator, __, nextElement, ___, parentCssLocator, text, value) => {
//   const parentElement = await helper.getNextElementAfterParentWithText(parentCssLocator, text, nextElement);
//   const childElement = parentElement.element(by.css(childCssLocator));
//   return expect(await childElement.getAttribute(attribute)).to.not.contains(value);
// });
//
// /**
//  * Verify that attribute of some element with icon does not contain value.
//  *
//  * @example
//  * Attribute "class" of Edit button "button" with icon "#editIcon" does not contain "disabled"
//  *
//  * @param attribute
//  * @param __ - child element description
//  * @param parentCssLocator
//  * @param cssLocator
//  * @param value
//  */
// Then('Attribute {text} of {detail} {css} with icon {css} does not contain {text}', async (attribute, __, parentCssLocator, cssLocator, value) => {
//   const parent = await helper.getElementByCss(parentCssLocator);
//   const isPresent = await parent.element(by.css(cssLocator)).isPresent();
//   if (isPresent) {
//     return expect(await parent.getAttribute(attribute)).to.not.contains(value);
//   }
// });
//
// /**
//  * Verify that attribute of some element with icon does not contain value.
//  *
//  * @example
//  * Attribute "class" of Edit button "button" on row "#row" with icon "#editIcon" does not contain "disabled"
//  *
//  * @param attribute
//  * @param _ - child element description
//  * @param childCssLocator
//  * @param __ - parent element description
//  * @param parentCssLocator
//  * @param iconCss
//  * @param value
//  */
// Then('Attribute {text} of {detail} {css} on {detail} {css} with icon {css} does not contain {text}', async (attribute, _, childCssLocator, __, parentCssLocator, iconCss, value) => {
//   const parent = await helper.getElementByCss(parentCssLocator);
//   const isPresent = await parent.element(by.css(iconCss)).isPresent();
//   if (isPresent) {
//     const webElement = await parent.element(by.css(childCssLocator));
//     return expect(await webElement.getAttribute(attribute)).to.not.contains(value);
//   }
// });
//
// /**
//  * Verify that element attribute does not contain value.
//  *
//  * @example
//  * Attribute "class" of Search button "#searchButton" does not contain "container"
//  *
//  * @param attribute
//  * @param _ - element description
//  * @param cssLocator
//  * @param value
//  */
// Then('Attribute {text} of {detail} {css} does not contain {text}', async (attribute, _, cssLocator, value) => {
//   return expect((await helper.getElementByCss(cssLocator)).getAttribute(attribute)).to.eventually.not.contains(value);
// });
//
// /**
//  * Verify that attribute of element with text does not contain value.
//  *
//  * @example
//  * Attribute "class" of Search button "button" with text "Search" does not contain "container"
//  *
//  * @param attribute
//  * @param _ - element description
//  * @param cssLocator
//  * @param text - element text
//  * @param value
//  */
// Then('Attribute {text} of {detail} {css} with text {text} does not contain {text}', async (attribute, _, cssLocator, text, value) => {
//   return expect((await helper.getElementByCssContainingText(cssLocator, text)).getAttribute(attribute)).to.eventually.not.contains(value);
// });
//
// /**
//  * Verify that element text is equal to value.
//  *
//  * @example
//  * Search input "#search" text is equal to "protractor"
//  *
//  * @param _ - element description
//  * @param cssLocator
//  * @param value
//  */
//
// Then('{detail} {css} text is equal to {text}', async (_, cssLocator, value) => {
//   const elem = await helper.getElementByCss(cssLocator);
//   let elementText;
//
//   if ((await elem.getTagName()) === 'select') {
//     const optionIndex = await elem.getAttribute('value');
//     const optionElement = elem.element(by.css('option[value="' + optionIndex + '"]'));
//     elementText = await optionElement.getText();
//   } else {
//     elementText = await elem.getText();
//   }
//
//     console.log("#####elementText.trim()" + "--" + elementText.trim());
//     console.log("######value.trim()" + "--" + value.trim());
//
//     // expect(elementText.trim()).to.equalIgnoreCase(value.trim());
//     // expect("1 Featured Tokens Remaining").to.contain("1 Featured Tokens Remaining");
//     // expect("1 Featured Tokens Remaining").to.contain("1 Featured Tokens Remaining");
//
//
//
//   typeof value === 'string' ?
//     expect(elementText.trim()).to.equalIgnoreCase(value.trim()) :
//     expect(elementText.trim()).to.match(value.trim());
//
//
// });
//
// /**
//  * Verify that INPUT webElement text is equal to value.
//  *
//  * @example
//  * Flat Coverage Amount "#inputId" input text is equal to "65"
//  *
//  * @param _ - element description
//  * @param cssLocator
//  * @param value
//  */
// Then('{detail} {css} input text is equal to {text}', async (_, cssLocator, value) => {
//   return typeof value === 'string' ?
//     expect((await helper.getElementByCss(cssLocator)).getAttribute('value')).to.eventually.equal(value) :
//     expect((await helper.getElementByCss(cssLocator)).getAttribute('value')).to.eventually.match(value);
// });
//
// /**
//  * Verify that child element text within parent element is equal to value.
//  *
//  * @example
//  * Label "[data-id=progress-circle-upload]" text is equal to "0" on File Upload button "[data-id=goto-upload]"
//  *
//  * @param _ - child element description
//  * @param itemCssLocator - child locator
//  * @param value
//  * @param _ - parent element description
//  * @param parentCssLocator
//  */
// Then('{detail} {css} text is equal to {text} on {detail} {css}', async (_, itemCssLocator, value, __, parentCssLocator) => {
//   const webElement = (await helper.getElementByCss(parentCssLocator)).element(by.css(itemCssLocator));
//   return typeof value === 'string' ?
//     expect(webElement.getText()).to.eventually.equal(value) :
//     expect(webElement.getText()).to.eventually.match(value);
// });
//
//
// /**
//  * Verify that child element text within parent element is equal to value.
//  *
//  * @example
//  * Card "mercer-card" count is equal to 3
//  *
//  * @param _ - element description
//  * @param elementCssSelector - element locator
//  * @param value
//  */
// Then('{detail} {css} count is equal to {int}', function (_, elementCssSelector, expectedValue) {
//   return expect(helper.getElementsCount(elementCssSelector)).to.eventually.equal(expectedValue);
// });
//
// /** $
//  * Verify that count of elements is equal to value in total count element .
//  *
//  * @example
//  * Count of Policy cells "renewalsPage|forCountOfPolicyCells" count is equal to number "renewalsPage|numberCell"
//  *
//  * @param _ - child element description
//  * @param elementCssLocator
//  * @param _ - parent element description
//  * @param expectedCountCss
//  */
// Then('{detail} {css} count is equal to {detail} {css}', async (_, elementCssSelector, __, expectedCountCss) => {
//   const countOfElements = await helper.getElementByCss(expectedCountCss);
//   let text = await countOfElements.getText();
//   text = text.replace(',', '.');
//   text = text.replace(/[^0-9.]/g, '');
//   text = parseFloat(text);
//   let count = await helper.getElementsCount(elementCssSelector);
//   return expect(count).to.equal(text);
// });
//
// /**
//  * Verifying that count of some element is less or greater than some venue
//  *
//  * @example
//  * Client cards "homePage|mercerClientCard" count is "greater" than 1
//  *
//  * @param _ - element description
//  * @param elementCssSelector - element locator
//  * @param lessOrGreater - text that should be "less" or "greater"
//  * @param expectedValue
//  */
//
// Then('{detail} {css} count is {string} than {int}', function (_, cssLocator, lessOrGreater, expectedValue) {
//   const COMPARATOR = ['less', 'greater'];
//   const comparator = lessOrGreater.toLowerCase();
//
//   if (!COMPARATOR.includes(comparator)) {
//     throw new Error(`Wrong comparator - '${lessOrGreater}' was given. Use: ${COMPARATOR.join(' or ')}`);
//   }
//
//   if (comparator === 'less') {
//     return expect(helper.getElementsCount(cssLocator)).to.eventually.lessThan(expectedValue);
//   } else {
//     return expect(helper.getElementsCount(cssLocator)).to.eventually.greaterThan(expectedValue);
//   }
// });
//
// /**
//  * Verify that child element text within parent element with text is equal to value.
//  *
//  * @example
//  * Label "[data-id=progress-circle-upload]" text is equal to "0" on File Upload section "[data-id=goto-upload]" with text "Company (US)"
//  *
//  * @param _ - child element description
//  * @param itemCssLocator - child locator
//  * @param value
//  * @param _ - parent element description
//  * @param parentCssLocator
//  * @param text - parent text
//  */
//
// Then('{detail} {css} text is equal to {text} on {detail} {css} with text {text}', async (_, itemCssLocator, value, __, parentCssLocator, text) => {
//   const webElement = (await helper.getElementByCssContainingText(parentCssLocator, text)).element(by.css(itemCssLocator));
//   return typeof value === 'string' ?
//     expect(webElement.getText()).to.eventually.equal(value) :
//     expect(webElement.getText()).to.eventually.match(value);
// });
//
// /**
//  * Verify that element text is not equal to value.
//  *
//  * @example
//  * Search input "#search" text is not equal to "protractor"
//  *
//  * @param _ - element description
//  * @param cssLocator
//  * @param value
//  */
// Then('{detail} {css} text is not equal to {text}', async (_, cssLocator, value) => {
//   return typeof value === 'string' ?
//     expect((await helper.getElementByCss(cssLocator)).getText()).to.not.eventually.equal(value) :
//     expect((await helper.getElementByCss(cssLocator)).getText()).to.not.eventually.match(value);
// });
//
// /**
//  * Verify that element text contains value.
//  *
//  * @example
//  * Search input "#search" text contains "protractor"
//  *
//  * @param _ - element description
//  * @param cssLocator
//  * @param value
//  */
// Then('{detail} {css} contains {text} text', async (_, cssLocator, value) => {
//   return expect((await helper.getElementByCss(cssLocator)).getText()).to.eventually.contains(value);
// });
//
// /**
//  * Verify that child element text within parent element with text is equal to value.
//  *
//  * @example
//  * Number of active services "clientPage|servicesCount" contains "11 selected" text on group "clientPage|serviceGroupMenuItem" with text "Implementation and Governance Strategy"
//  *
//  * @param _ - child element description
//  * @param itemCssLocator - child locator
//  * @param value
//  * @param _ - parent element description
//  * @param parentCssLocator
//  * @param text - parent text
//  */
// Then('{detail} {css} contains {text} text on {detail} {css} with text {text}', async (_, itemCssLocator, value, __, parentCssLocator, text) => {
//   const webElement = (await helper.getElementByCssContainingText(parentCssLocator, text)).element(by.css(itemCssLocator));
//   return expect(await webElement.getText()).to.contains(value);
// });
//
// /**
//  * Verify that INPUT webElement text contains value.
//  *
//  * @example
//  * Flat Coverage Amount "#inputId" input text contains "65"
//  *
//  * @param _ - element description
//  * @param cssLocator
//  * @param value
//  */
// Then('{detail} {css} input contains {text} text', async (_, cssLocator, value) => {
//   return expect((await helper.getElementByCss(cssLocator)).getAttribute('value')).to.eventually.contains(value);
// });
//
// /**
//  * Verify that element text does not contain value.
//  *
//  * @example
//  * Search input "#search" text does not contain "protractor"
//  *
//  * @param _ - element description
//  * @param cssLocator
//  * @param value
//  */
// Then('{detail} {css} does not contain {text} text', async (_, cssLocator, value) => {
//   return expect((await helper.getElementByCss(cssLocator)).getText()).to.not.eventually.contains(value);
// });
//
// /**
//  * Verify that checkbox or radio button element is selected.
//  *
//  * @example
//  * Agreed Terms and Conditions checkbox "[data-id=agree-with-terms-checkbox]" is selected
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// Then('{detail} {css} is selected', async (_, cssLocator) => {
//   const element = await helper.getElementByCss(cssLocator);
//   return expect(helper.isElementSelected(element)).to.eventually.equal(true);
// });
//
// /**
//  * Verify that child element (checkbox or radio button) within parent element with text is selected.
//  *
//  * @example
//  * Yes checkbox "#yes-checkbox" on result row ".row" with text "automation_1" is selected
//  *
//  * @param _ - child element description
//  * @param cssLocator - child locator
//  * @param __ - parent element description
//  * @param parentCssSelector
//  * @param text - parent text
//  */
// Then('{detail} {css} on {detail} {css} with text {text} is selected', async (_, cssLocator, __, parentCssSelector, text) => {
//   const parent = await helper.getElementByCssContainingText(parentCssSelector, text);
//   const element = parent.element(by.css(cssLocator));
//   return expect(helper.isElementSelected(element)).to.eventually.equal(true);
// });
//
// /**
//  * Verify that checkbox or radio button element is not selected.
//  *
//  * @example
//  * Agreed Terms and Conditions checkbox "[data-id=agree-with-terms-checkbox]" is not selected
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// Then('{detail} {css} is not selected', async (_, cssLocator) => {
//   // don't wait too long! (maybe temporary)
//   const TIMEOUT = 1000;
//   const element = await helper.getElementByCss(cssLocator);
//   return expect(helper.isElementSelected(element, TIMEOUT)).to.eventually.equal(false);
// });
//
// /**
//  * Verify that child element (checkbox or radio button) within parent element with text is not selected.
//  *
//  * @example
//  * Yes checkbox "#yes-checkbox" on result row ".row" with text "automation_1" is not selected
//  *
//  * @param _ - child element description
//  * @param cssLocator - child locator
//  * @param __ - parent element description
//  * @param parentCssSelector
//  * @param text - parent text
//  */
// Then('{detail} {css} on {detail} {css} with text {text} is not selected', async (_, cssLocator, __, parentCssSelector, text) => {
//   const parent = await helper.getElementByCssContainingText(parentCssSelector, text);
//   const element = parent.element(by.css(cssLocator));
//   return expect(helper.isElementSelected(element)).to.eventually.equal(false);
// });
//
// /**
//  * Verify that element is not only presented in DOM, but also has height and width.
//  *
//  * @example
//  * Company Dropdown "#multi-selector-wrapper" is displayed
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// Then('{detail} {css} is displayed', function (_, cssLocator) {
//   const elem = element(by.css(cssLocator));
//   return expect(helper.isElementVisible(elem)).to.eventually.equal(true);
// });
//
// /**
//  * Verify that element with text is not only presented in DOM, but also has height and width.
//  *
//  * @example
//  * Status step ".breadcrumb" with text "Status" is displayed
//  *
//  * @param _ - element description
//  * @param cssLocator
//  * @param text
//  */
// Then('{detail} {css} with text {text} is displayed', function (_, cssLocator, text) {
//   const elem = element(by.cssContainingText(cssLocator, text));
//   return expect(helper.isElementVisible(elem)).to.eventually.equal(true);
// });
//
// /**
//  * Verify that child element within parent element with text is not only presented in DOM,
//  * but also has height and width.
//  *
//  * @example
//  * Continue button "button#id" on Company row ".row" is displayed
//  *
//  * @param _ - child element description
//  * @param itemCssLocator - child element locator
//  * @param __ - parent element description
//  * @param cssLocator - parent element locator
//  */
// Then('{detail} {css} on {detail} {css} is displayed', async (_, itemCssLocator, __, cssLocator) => {
//   const parent = await helper.getElementByCss(cssLocator);
//   const elem = parent.element(by.css(itemCssLocator));
//   return expect(await helper.isElementVisible(elem)).to.equal(true);
// });
//
// /**
//  * Verify that child element within parent element with text is not only presented in DOM,
//  * but also has height and width.
//  *
//  * @example
//  * Continue button "button#id" on Company row ".row" with text "Company (US)" is displayed
//  *
//  * @param _ - child element description
//  * @param itemCssLocator - child element locator
//  * @param __ - parent element description
//  * @param cssLocator - parent element locator
//  * @param text - parent element text
//  */
// Then('{detail} {css} on {detail} {css} with text {text} is displayed', async (_, itemCssLocator, __, cssLocator, text) => {
//   const parent = await helper.getElementByCssContainingText(cssLocator, text);
//   const elem = parent.element(by.css(itemCssLocator));
//   return expect(helper.isElementVisible(elem)).to.eventually.equal(true);
// });
//
// /**
//  * Verify that child element with text within parent element with text is not only presented in DOM,
//  * but also has height and width.
//  *
//  * @example
//  * Button "button" with text "Continue" on Company row ".row" with text "Company (US)" is displayed
//  *
//  * @param _ - child element description
//  * @param itemCssLocator - child element locator
//  * @param itemText - child element text
//  * @param __ - parent element description
//  * @param elementCssLocator - parent element locator
//  * @param elementText - parent element text
//  */
// Then('{detail} {css} with text {text} on {detail} {css} with text {text} is displayed', async (_, itemCssLocator, itemText, __, elementCssLocator, elementText) => {
//   const parent = await helper.getElementByCssContainingText(elementCssLocator, elementText);
//   const child = parent.element(by.cssContainingText(itemCssLocator, itemText));
//   return expect(helper.isElementVisible(child)).to.eventually.equal(true);
// });
//
// /**
//  * Verify that element is not displayed.
//  * Do not wait until element invisibility is rendered.
//  * Just immediately check (during 1 second) that element is not displayed.
//  *
//  * @example
//  * Company Dropdown "#multi-selector-wrapper" is not displayed
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// Then('{detail} {css} is not displayed', function (_, cssLocator) {
//   const elem = element(by.css(cssLocator));
//   return expect(helper.isElementNotVisible(elem, 1000)).to.eventually.equal(true);
// });
//
// /**
//  * Verify that element with text is not displayed.
//  * Do not wait until element invisibility is rendered.
//  * Just immediately check (during 1 second) that element is not displayed.
//  *
//  * @example
//  * Status step ".breadcrumb" with text "Status" is not displayed
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// Then('{detail} {css} with text {text} is not displayed', function (_, cssLocator, text) {
//   const elem = element(by.cssContainingText(cssLocator, text));
//   return expect(helper.isElementNotVisible(elem, 1000)).to.eventually.equal(true);
// });
//
// /**
//  * Verify that element is disabled.
//  * Verify by attribute disabled -> will pass, if element has attribute 'disabled' or 'disabled=true'.
//  *
//  * @example
//  * Upload your file button "#upload-button" is disabled
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// Then('{detail} {css} is disabled', async (_, cssLocator) => {
//   const elem = await helper.getElementByCss(cssLocator);
//   return expect(elem.isEnabled()).to.eventually.equal(false);
// });
//
// /**
//  * Verify that element with text is disabled.
//  * Verify by attribute disabled -> will pass, if element has attribute 'disabled' or 'disabled=true'.
//  *
//  * @example
//  * Upload your file button "button" with text "Upload" is disabled
//  *
//  * @param _ - element description
//  * @param cssLocator
//  * @param text
//  */
// Then('{detail} {css} with text {text} is disabled', async (_, cssLocator, text) => {
//   const elem = await helper.getElementByCssContainingText(cssLocator, text);
//   return expect(elem.isEnabled()).to.eventually.equal(false);
// });
//
// /**
//  * Verify that child element within parent element is disabled.
//  * Verify by attribute disabled -> will pass, if element has attribute 'disabled' or 'disabled=true'.
//  *
//  * @example
//  * Upload your file button ".upload-button" on row "#id" is disabled
//  *
//  * @param _ - child element description
//  * @param itemCssLocator - child element locator
//  * @param __ - parent element description
//  * @param cssLocator - parent element locator
//  */
// Then('{detail} {css} on {detail} {css} is disabled', async (_, itemCssLocator, __, cssLocator) => {
//   const parent = await helper.getElementByCss(cssLocator);
//   const child = parent.element(by.css(itemCssLocator));
//   return expect(child.isEnabled()).to.eventually.equal(false);
// });
//
// /**
//  * Verify that child element within parent element with text is disabled.
//  * Verify by attribute disabled -> will pass, if element has attribute 'disabled' or 'disabled=true'.
//  *
//  * @example
//  * Upload your file button ".upload-button" on row ".row" with text "automation-1" is disabled
//  *
//  * @param _ - child element description
//  * @param itemCssLocator - child element locator
//  * @param __ - parent element description
//  * @param elementCssLocator - parent element locator
//  * @param elementText - parent element text
//  */
// Then('{detail} {css} on {detail} {css} with text {text} is disabled', async (_, itemCssLocator, __, elementCssLocator, elementText) => {
//   const collection = await $$(elementCssLocator).asElementFinders_();
//   const regexp = stringHelper.getExactStringRegexp(elementText);
//   let parentElement;
//
//   for (let element of collection) {
//     const text = await element.getText();
//     if (text.match(regexp)) {
//       parentElement = element;
//       break;
//     }
//   }
//   const childElement = parentElement.$(itemCssLocator);
//
//   await browser.wait(until.presenceOf(childElement), browser.params.timeout, 'Wait for element appears');
//   return expect(childElement.isEnabled()).to.eventually.equal(false);
// });
//
// /**
//  * Verify that element is enabled.
//  * Verify by attribute disabled -> will pass, if element does not have attribute 'disabled' or 'disabled=false.
//  *
//  * @example
//  * Upload your file button "#upload-button" is enabled
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// Then('{detail} {css} is enabled', async (_, cssLocator) => {
//   const elem = await helper.getElementByCss(cssLocator);
//   return expect(elem.isEnabled()).to.eventually.equal(true);
// });
//
// /**
//  * Verify that element with text is enabled.
//  * Verify by attribute disabled -> will pass, if element does not have attribute 'disabled' or 'disabled=false.
//  *
//  * @example
//  * Upload your file button ".button" with text "Upload" is enabled
//  *
//  * @param _ - element description
//  * @param cssLocator
//  * @param text
//  */
// Then('{detail} {css} with text {text} is enabled', async (_, cssLocator, text) => {
//   const elem = await helper.getElementByCssContainingText(cssLocator, text);
//   return expect(elem.isEnabled()).to.eventually.equal(true);
// });
//
// /**
//  * Verify that child element within parent element with text is enabled.
//  * Verify by attribute disabled -> will pass, if element does not have attribute 'disabled' or 'disabled=false.
//  *
//  * @example
//  * Upload your file button ".upload-button" on row ".row" with text "automation-1" is enabled
//  *
//  * @param _ - child element description
//  * @param itemCssLocator - child element locator
//  * @param __ - parent element description
//  * @param elementCssLocator - parent element locator
//  * @param elementText - parent element text
//  */
// Then('{detail} {css} on {detail} {css} with text {text} is enabled', async (_, itemCssLocator, __, elementCssLocator, elementText) => {
//   const parent = await helper.getElementByCssContainingText(elementCssLocator, elementText);
//   const child = parent.element(by.css(itemCssLocator));
//   return expect(child.isEnabled()).to.eventually.equal(true);
// });
//
// /**
//  * Verify that page title is equal to value.
//  *
//  * @example
//  * Page title is equal to "Welcome!"
//  *
//  * @param value
//  */
// Then('Page title is equal to {text}', function (value) {
//   return typeof value === 'string' ?
//     expect(browser.getTitle()).to.eventually.equal(value) :
//     expect(browser.getTitle()).to.eventually.match(value);
// });
//
// /**
//  * Verify that page URL is equal to value.
//  *
//  * @example
//  * Page URL is equal to "www.home.com"
//  * Possible using PO - Page URL is equal to "PROJECT_HOME_PAGE"
//  *
//  * @param value
//  */
// Then('Page URL is equal to {landing-url}', function (value) {
//   let expectedConditions = protractor.ExpectedConditions;
//   return browser.wait(expectedConditions.urlIs(value), browser.params.timeout).then(() => {
//   }, (error => {
//       return browser.getCurrentUrl().then(url => {
//         throw new Error(`Expected url: ${value} is not loaded; Current url: ${url}`);
//       })
//     }));
// });
//
// /**
//  * Verify that page URL contains value.
//  *
//  * @example
//  * Page URL contains "www.home.com"
//  * Possible using PO - Page URL contains "PROJECT_HOME_PAGE"
//  *
//  * @param value
//  */
// Then('Page URL contains {landing-url}', function (value) {
//   let expectedConditions = protractor.ExpectedConditions;
//   return browser.wait(expectedConditions.urlContains(value), browser.params.timeout).then(() => {
//   }, (error => {
//       return browser.getCurrentUrl().then(url => {
//         throw new Error(`Current url: ${url} doesn't contain expected url: ${value}`);
//       })
//     }));
// });
//
// /**
//  * Verify that page URL contains defined as PO URL with expected path.
//  *
//  * @example
//  * Page URL contains "PROJECT_HOME" with path "/clients"
//  *
//  * @param value
//  */
// Then('Page URL contains {landing-url} with path {text}', function (url, path) {
//   const fullURL = url + path;
//   let expectedConditions = protractor.ExpectedConditions;
//   return browser.wait(expectedConditions.urlContains(fullURL), browser.params.timeout).then(() => {
//   }, (error => {
//       return browser.getCurrentUrl().then(url => {
//         throw new Error(`Current url: ${url} doesn't contain expected url: ${fullURL}`);
//       })
//     }));
// });
//
// /**
//  * Verify that page URL is equal to defined as PO URL with expected path.
//  *
//  * @example
//  * Page URL contains "PROJECT_HOME" with path "/clients"
//  *
//  * @param value
//  */
// Then('Page URL is equal to {landing-url} with path {text}', function (url, path) {
//   const fullURL = url + path;
//   let expectedConditions = protractor.ExpectedConditions;
//   return browser.wait(expectedConditions.urlIs(fullURL), browser.params.timeout).then(() => {
//   }, (error => {
//       return browser.getCurrentUrl().then(url => {
//         throw new Error(`Expected url: ${fullURL} is not loaded; Current url: ${url}`);
//       })
//     }));
// });
//
//
// /**
//  * Compare table content with expected.
//  * Mostly used for long tables, where we need to scroll right/left to see content.
//  *
//  * @example
//  * Users table "#table" with cell element "span" data match values:
//  * | First Name | Last Name | Phone number |
//  * | Ivan       | Sivov     | 876755677    |
//  * | Kate       | Petrov    | 339859389    |
//  *
//  * @param _- table description
//  * @param tableCssLocator
//  * @param cellCssLocator
//  * @param expectedTable
//  *
//  */
// Then('{detail} table {css} with cell element {css} data match values:', async (_, tableCssLocator, cellCssLocator, expectedTable) => {
//   let expected = expectedTable.hashes();
//   if (browser.params.need_localization) {
//     expected = expected.map(item => {
//       const updatedObject = {};
//       const keys = Object.keys(item);
//       const translatedKeys = keys.map(oneMoreItem => {
//         if (oneMoreItem) { // could be empty values
//           return localizationHelper.checkLocalization(oneMoreItem);
//         }
//         return oneMoreItem;
//       });
//       translatedKeys.forEach((translatedKey, index) => {
//         updatedObject[translatedKey] = localizationHelper.checkLocalization(item[keys[index]]);
//       });
//       return updatedObject;
//     });
//   }
//   const table = await helper.getElementByCss(tableCssLocator);
//   const actual = await helper.getTableContentAsJSON(table, cellCssLocator);
//   return expect(actual).to.deep.equal(expected);
// });
//
// /**
//  * Compare table content with expected.
//  *
//  * @example
//  * Users table "#table" data match values:
//  * | First Name | Last Name | Phone number |
//  * | Ivan       | Sivov     | 876755677    |
//  * | Kate       | Petrov    | 339859389    |
//  *
//  * @param _- table description
//  * @param tableCssLocator
//  * @param expectedTable
//  *
//  */
// Then('{detail} table {css} data match values:', async (_, cssLocator, expectedTable) => {
//   let expected = expectedTable.hashes();
//   if (browser.params.need_localization) {
//     expected = expected.map(item => {
//       const updatedObject = {};
//       const keys = Object.keys(item);
//       const translatedKeys = keys.map(oneMoreItem => {
//         if (oneMoreItem) { // could be empty values
//           return localizationHelper.checkLocalization(oneMoreItem);
//         }
//         return oneMoreItem;
//       });
//       translatedKeys.forEach((translatedKey, index) => {
//         updatedObject[translatedKey] = localizationHelper.checkLocalization(item[keys[index]]);
//       });
//       return updatedObject;
//     });
//   }
//   const table = await helper.getElementByCss(cssLocator);
//   const seconds = browser.params.AwsSleepTimout ?
//     browser.params.AwsSleepTimout : browser.params.LocalSleepTumeout ?
//       browser.params.LocalSleepTumeout : sleepTimout;
//   await browser.sleep(seconds);
//   const actual = await helper.getTableContentAsJSON(table);
//   return expect(actual).to.deep.equal(expected);
// });
//
// /**
//  * Verify if horizontal scroll is existed for element.
//  *
//  * @example
//  * Horizontal scroll for Question group form ".dimension-table" is existed
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// Then('Horizontal scroll for {detail} {css} is existed', async (_, cssLocator) => {
//   const elem = await helper.getElementByCss(cssLocator);
//   return expect(helper.isHorizontalScrollExisted(elem)).to.eventually.equal(true);
// });
//
// /**
//  * Verify if horizontal scroll is not existed for element.
//  *
//  * @example
//  * Horizontal scroll for Question group form ".dimension-table" is not existed
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// Then('Horizontal scroll for {detail} {css} is not existed', async (_, cssLocator) => {
//   const elem = await helper.getElementByCss(cssLocator);
//   return expect(helper.isHorizontalScrollNotExisted(elem)).to.eventually.equal(true);
// });
//
// /**
//  * Wait for element visibility within appropriate number of seconds.
//  *
//  * @example
//  * User waits for Success popup ".content-close" visibility within 30 seconds
//  *
//  * @param _ - element description
//  * @param cssLocator
//  * @param sec
//  */
// Then('User waits for {detail} {css} visibility within {int} second(s)', { timeout: 35 * 60 * 1000 }, function (_, cssLocator, sec) {
//   const elem = element(by.css(cssLocator));
//   return helper.waitElementVisibility(elem, sec);
// });
//
// /**
//  * Wait for element with text visibility within appropriate number of seconds.
//  *
//  * @example
//  * User waits for popup ".content-close" with text "Successful" visibility within 30 seconds
//  *
//  * @param _ - element description
//  * @param cssLocator
//  * @param sec
//  */
// Then('User waits for {detail} {css} with text {text} visibility within {int} second(s)', { timeout: 35 * 60 * 1000 }, function (_, cssLocator, text, sec) {
//   const elem = element(by.cssContainingText(cssLocator, text));
//   return helper.waitElementVisibility(elem, sec);
// });
//
// /**
//  * Wait for element invisibility within appropriate number of seconds.
//  *
//  * @example
//  * User waits for Success popup ".content-close" invisibility within 5 seconds
//  *
//  * @param _ - element description
//  * @param cssLocator
//  * @param sec
//  */
// Then('User waits for {detail} {css} invisibility within {int} second(s)', { timeout: 35 * 60 * 1000 }, function (_, cssLocator, sec) {
//   const elem = element(by.css(cssLocator));
//   return helper.waitElementInvisibility(elem, sec);
// });
//
// /**
//  * Wait for element with text invisibility within appropriate number of seconds.
//  *
//  * @example
//  * User waits for popup ".content-close" with text "Successful" invisibility within 5 seconds
//  *
//  * @param _ - element description
//  * @param cssLocator
//  * @param sec
//  */
// Then('User waits for {detail} {css} with text {text} invisibility within {int} second(s)', { timeout: 35 * 60 * 1000 }, function (_, cssLocator, text, sec) {
//   const elem = element(by.cssContainingText(cssLocator, text));
//   return helper.waitElementInvisibility(elem, sec);
// });
//
// Then('User verify response from {landing-url} with {detail} {text} contains {text}', async (host, _, path, text) => {
//   let responseText = await endpointHelper.getResponseText('GET', host + path);
//   return expect(responseText).to.contains(text);
// });
//
// /**
//  * Compare actual element texts with expected.
//  * Is used for dropdown list.
//  *
//  * @example
//  * Plan Type dropdown list "#container li" contains values:
//  *  |                      |
//  *  | Flat Coverage Amount |
//  *  | Multiple of Pay      |
//  *
//  * @param _ - elements/list description
//  * @param cssLocator - locators for elements
//  * @param expected - table with expected values
//  */
// Then('{detail} list {css} contains values:', async (_, cssLocators, expected) => {
//   expected = expected.raw();
//
//   const actual = await helper.getElementTexts(cssLocators);
//   return expect(actual).to.deep.equal(expected);
// });
//
// /**
//  * Verify if file with appropriate name is exist is BaseDir/test directory.
//  *
//  * @example
//  * Downloaded file name is equal to "automation_1528760342739 - 2019.pdf"
//  *
//  * @param name - file name with extension.
//  */
// Then('Downloaded file with name {text} exists', function (name) {
//   const filePath = browser.params.basePath + fileSep + name;// generate file path
//   return expect(fileHelper.isFileExist(filePath)).to.eventually.equal(true);
// });
//
// /**
//  * Verify that hash of downloaded file is equal to expected hash.
//  *
//  * @example
//  * 1. Navigate to https://md5file.com/calculator
//  * 2. Upload a file that you want to use as template
//  * 3. Copy calculated value for hash type SHA-1 and paste it into {hash}
//  * User verify downloaded file "file-upload.xlsx" hash is equal to "HASH:ca73c829598b923f8e58fefe3cda2271c8b206cb"
//  *
//  * @param fileName - downloaded file name
//  * @param hash
//  */
// Then('User verify downloaded file {text} hash is equal to {hash}', function (fileName, hash) {
//   const filePath = browser.params.basePath + fileSep + fileName;// generate file path
//   return expect(fileHelper.getFileHash(filePath)).to.eventually.equal(hash);
// });
//
//
// /**
//  * Verify that hash of downloaded file is equal to hash of some template file.
//  * Put expected file "file-upload.xlsx" template into features/test-data/file-templates/.
//  *
//  * @example
//  * User verify downloaded file "file-upload.xlsx" hash is equal to template file "file-upload.xlsx" hash
//  *
//  * @param fileName - downloaded file name
//  * @param templateFileName
//  *
//  */
// Then('User verify downloaded file {text} hash is equal to template file {text} hash', function (fileName, templateFileName) {
//   const filePath = browser.params.basePath + fileSep + fileName;// generate file path
//   const fileTemplatePath = path.resolve(__dirname, '../../../features/test-data/file-templates/' + templateFileName);
//   return fileHelper.getFileHash(fileTemplatePath).then((hash) => {
//     return expect(fileHelper.getFileHash(filePath)).to.eventually.equal(hash);
//   });
// });
//
// /**
//  * Verifying that array is sorted alphabetically or numerically in ascending or descending order case insensitive.
//  *
//  * @example
//  * List "homePage|expectedRevenueList" is sorted numerically in "descending" order
//  *
//  * @param _ - elements/list description
//  * @param locator - valid locator for collection of elements
//  * @param alphabeticallyOrNumerically - text that should be "alphabetically" (a-z) or "numerically" (0-9)
//  * @param ascendingOrDescending - text that should be "ascending" (from A to Z) or "descending" (from Z to A)
//  */
// Then('{detail} {css} is sorted {text} in {text} order', (_, locator, alphabeticallyOrNumerically, ascendingOrDescending) => {
//   const ORDERS = ['ascending', 'descending'];
//   const FORMATS = ['alphabetically', 'numerically', 'by date'];
//   const order = ascendingOrDescending.toLowerCase();
//   const format = alphabeticallyOrNumerically.toLowerCase();
//
//   if (!ORDERS.includes(order)) {
//     throw new Error(`Wrong order - '${ascendingOrDescending}' was given. Use: ${ORDERS.join(' or ')}`);
//   }
//
//   if (!FORMATS.includes(format)) {
//     throw new Error(`Wrong format - '${alphabeticallyOrNumerically}' was given. Use: ${FORMATS.join(' or ')}`);
//   }
//
//   return helper.getElementTexts(locator).then(array => {
//     let actualArray = array.slice();
//
//     if (actualArray.length === 0) {
//       throw new Error(`Values are not found for css locator: '${locator}'. Sorting verification failed`)
//     }
//
//     stringHelper.arraySorting(array, format, order);
//     return expect(JSON.stringify(actualArray), `${actualArray} is not sorted ${format} in ${order} order`).to.deep.equal(JSON.stringify(array));
//   });
// });
//
// /**
//  * Verifying that array is sorted alphabetically or numerically in ascending or descending order case sensitive.
//  *
//  * @example
//  * List "homePage|expectedRevenueList" is sorted numerically in "descending" order
//  *
//  * @param _ - elements/list description
//  * @param locator - valid locator for collection of elements
//  * @param alphabeticallyOrNumerically - text that should be "alphabetically" (a-z) or "numerically" (0-9)
//  * @param ascendingOrDescending - text that should be "ascending" (from A to Z) or "descending" (from Z to A)
//  */
// Then('{detail} {css} is sorted {text} in {text} order case sensitive', (_, locator, alphabeticallyOrNumerically, ascendingOrDescending) => {
//   const ORDERS = ['ascending', 'descending'];
//   const FORMATS = ['alphabetically', 'numerically', 'by date'];
//   const order = ascendingOrDescending.toLowerCase();
//   const format = alphabeticallyOrNumerically.toLowerCase();
//
//   if (!ORDERS.includes(order)) {
//     throw new Error(`Wrong order - '${ascendingOrDescending}' was given. Use: ${ORDERS.join(' or ')}`);
//   }
//
//   if (!FORMATS.includes(format)) {
//     throw new Error(`Wrong format - '${alphabeticallyOrNumerically}' was given. Use: ${FORMATS.join(' or ')}`);
//   }
//
//   return helper.getElementTexts(locator).then(array => {
//     let actualArray = array.slice();
//
//     if (actualArray.length === 0) {
//       throw new Error(`Values are not found for css locator: '${locator}'. Sorting verification failed`);
//     }
//
//     const caseSensitive = true;
//     stringHelper.arraySorting(array, format, order, caseSensitive);
//     return expect(JSON.stringify(actualArray), `${actualArray} is not sorted ${format} in ${order} order`).to.deep.equal(JSON.stringify(array));
//   });
// });
//
// /**
//  * Verify that element text is empty.
//  *
//  * @example
//  * Client Name Input "clientPage|clientName" is empty
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// Then('{detail} {css} is empty', function (_, cssLocator) {
//   return expect(helper.isElementHasText(cssLocator), `Element ${cssLocator} is not empty`).to.eventually.be.false;
// });
//
// /**
//  * Verify that element text is not empty.
//  *
//  * @example
//  * Client Name Input "clientPage|clientName" is not empty
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// Then('{detail} {css} is not empty', function (_, cssLocator) {
//   return expect(helper.isElementHasText(cssLocator), `Element ${cssLocator} is empty`).to.eventually.be.true;
// });
//
// /**
//  * Verify that each element from the list contains specified by css element.
//  *
//  * @example
//  * User verifies each table row "dspAdministrationClient|clientTableContentRow" contains dropdown selection option "dspAdministrationClient|clientSettingsIconList"
//  *
//  * @param _ elements/list description
//  * @param parentCss - elements/list css selector
//  * @param __ - item element description
//  * @param itemCss - expected item element css selector
//  */
//
// Then('User verifies each {detail} {css} contains {detail} {css}', async (_, parentCss, __, itemCss) => {
//   const collection = await element.all(by.css(parentCss)).asElementFinders_();
//
//   for (let i = 0; i < collection.length; i++) {
//     const parent = collection[i];
//     const child = parent.element(by.css(itemCss));
//     expect(await helper.isElementVisible(child), `${i + 1} element ${itemCss} is not displayed`).to.equal(true);
//   }
// });
//
// /**
//  * Verify that each element from the list contains specified by css element with expected text.
//  *
//  * @example
//  * User verifies each Client table row "dspAdministrationClient|clientTableContentRow" contains label "dspAdministrationClient|label" with test "Active"
//  *
//  * @param _ elements/list description
//  * @param parentCss - elements/list css selector
//  * @param __ - item element description
//  * @param itemCss - expected item element css selector
//  * @param itemText - expected item element text
//  */
//
// Then('User verifies each {detail} {css} contains {detail} {css} with text {text}', async (_, parentCss, __, itemCss, itemText) => {
//   const collection = await element.all(by.css(parentCss)).asElementFinders_();
//
//   for (let i = 0; i < collection.length; i++) {
//     const parent = collection[i];
//     const child = parent.element(by.cssContainingText(itemCss, itemText));
//     expect(await helper.isElementVisible(child), `${i + 1} element ${itemCss} with text ${itemText} is not displayed`).to.equal(true);
//   }
// });
//
// /**
//  * Verify that each element from the list is not selected.
//  *
//  * @example
//  * And User verifies each checkbox "managerQuickUpdatePage|predefinedTemplate|marketingContacts|filterCheckBoxInput" item is not selected
//  *
//  * @param __ - item element description
//  * @param itemCss - expected item element css selector
//  */
//
// Then('User verifies each {detail} {css} item is not selected', async (__, itemCss) => {
//   const collection = await element.all(by.css(itemCss)).asElementFinders_();
//
//   for (let i = 0; i < collection.length; i++) {
//     expect(await helper.isElementSelected(collection[i], 500), `${i + 1} element ${itemCss} is selected`).to.equal(false);
//   }
// });
//
// /**
//  * Verify that each element from the list is selected.
//  *
//  * @example
//  * And User verifies each checkbox "managerQuickUpdatePage|predefinedTemplate|marketingContacts|filterCheckBoxInput" item is selected
//  *
//  * @param __ - item element description
//  * @param itemCss - expected item element css selector
//  */
//
// Then('User verifies each {detail} {css} item is selected', async (__, itemCss) => {
//   const collection = await element.all(by.css(itemCss)).asElementFinders_();
//
//   for (let i = 0; i < collection.length; i++) {
//     expect(await helper.isElementSelected(collection[i], 500), `${i + 1} element ${itemCss} is not selected`).to.equal(true);
//   }
// });
//
// /**
//  * Verify that some date element text after ":" has a specified format
//  *
//  * @example
//  * Start Date "policySinglePage|dateFormat1" has a format "DD MMM YYYY"
//  *
//  * @param _ elements description
//  * @param css - elements css selector
//  * @param format
//  */
// Then('{detail} {css} has a format {text}', async (_, css, format) => {
//   let elementDate = await (await helper.getElementByCss(css)).getText();
//   elementDate = elementDate.split(': ').pop();
//   return expect(moment(elementDate, format, true).isValid()).to.equal(true);
// });
//
// /**
//  * Verify that some element integer value is greater or less than some other value
//  *
//  * @example
//  * Client cards value "homePage|mercerClientCard"  is "greater" than 1
//  *
//  * @param _ elements description
//  * @param locator - elements css selector
//  * @param greaterOrLess
//  * @param number
//  */
// Then('{detail} {css} is {text} than {int}', async (_, locator, greaterOrLess, number) => {
//   const COMPARATOR = ['greater', 'less'];
//   const comp = greaterOrLess.toLowerCase();
//
//   if (!COMPARATOR.includes(comp)) {
//     throw new Error(`Wrong comparator - '${greaterOrLess}' was given. Use: ${COMPARATOR.join(' or ')}`);
//   }
//
//   const elem = await helper.getElementByCss(locator);
//
//   let text = await elem.getText();
//   text = text.replace(',', '.');
//   text = text.replace(/[^0-9.]/g, '');
//   text = parseFloat(text);
//   if (comp === 'greater') {
//     expect(text).to.be.greaterThan(number);
//   } else {
//     expect(text).to.be.lessThan(number);
//   }
// });
//
// /**
//  * Verify that sum of some elements is equal to some other element value
//  *
//  * @example
//  * Sum of elements "policySinglePage|annualTableItemValue" are equal to Annual total value "policySinglePage|annualTotalValue"
//  *
//  * @param _ elements description
//  * @param childLocator - elements css selector
//  * @param __ element description
//  * @param parentLocator
//  */
// Then('Sum of {detail} {css} are equal to {detail} {css}', async (_, childLocator, __, parentLocator) => {
//   const totalElement = await helper.getElementByCss(parentLocator);
//   let sum = 0;
//   const collection = await element.all(by.css(childLocator)).asElementFinders_();
//   for (let i = 0; i < collection.length; i++) {
//     let text = await collection[i].getText();
//     if (text !== '') {
//       text = text.replace(',', '.');
//       text = text.replace(/[^0-9.]/g, '');
//       text = parseFloat(text);
//       sum = sum + text;
//     }
//   }
//   let totalValue = await totalElement.getText();
//   totalValue = totalValue.replace(',', '.');
//   totalValue = totalValue.replace(/[^0-9.]/g, '');
//   totalValue = parseFloat(totalValue);
//   return expect(totalValue).to.equal(sum);
// });
//
// /**
//  * Verify that sum of some elements is equal to some other element value
//  *
//  * @example
//  * Sum of elements "policySinglePage|annualTableItemValue" are equal to Annual total value "policySinglePage|annualTotalValue" on row "row" with text "text"
//  *
//  * @param _ elements description
//  * @param childLocator - elements css selector
//  * @param __ element description
//  * @param parentLocator
//  * @param ___
//  * @param css
//  * @param text
//  */
// Then('Sum of {detail} {css} are equal to {detail} {css} on {detail} {css} with text {text}', async (_, childLocator, __, parentLocator, ___, css, text) => {
//   const totalElement = (await helper.getElementByCssContainingText(css, text)).element(by.css(parentLocator));
//   let sum = 0;
//   const collection = await element.all(by.css(childLocator)).asElementFinders_();
//   for (let i = 0; i < collection.length; i++) {
//     let text = await collection[i].getText();
//     if (text !== '') {
//       text = text.replace(',', '.');
//       text = text.replace(/[^0-9.]/g, '');
//       text = parseFloat(text);
//       sum = sum + text;
//     }
//   }
//   let totalValue = await totalElement.getText();
//   totalValue = totalValue.replace(',', '.');
//   totalValue = totalValue.replace(/[^0-9.]/g, '');
//   totalValue = parseFloat(totalValue);
//   return expect(totalValue).to.equal(sum);
// });
//
//
// Then('{detail} table {css} with cell element {css} data contains values:', async (_, tableCssLocator, cellCssLocator, expectedTable) => {
//   const expected = expectedTable.hashes();
//   const table = await helper.getElementByCss(tableCssLocator);
//   const seconds = browser.params.AwsSleepTimout ?
//     browser.params.AwsSleepTimout : browser.params.LocalSleepTumeout ?
//       browser.params.LocalSleepTumeout : sleepTimout;
//   await browser.sleep(seconds);
//   const actual = await helper.getTableContentAsJSON(table, cellCssLocator);
//
//   return expect(actual).to.include.deep.members(expected);
// });
//
//
// Then('{detail} table {css} data contains values:', async (_, cssLocator, expectedTable) => {
//   const expected = expectedTable.hashes();
//   const table = await helper.getElementByCss(cssLocator);
//   const seconds = browser.params.AwsSleepTimout ?
//     browser.params.AwsSleepTimout : browser.params.LocalSleepTumeout ?
//       browser.params.LocalSleepTumeout : sleepTimout;
//   await browser.sleep(seconds);
//   const actual = await helper.getTableContentAsJSON(table);
//
//   return expect(actual).to.include.deep.members(expected);
// });
//
// Then('{detail} table {css} data does not contain values:', async (_, cssLocator, expectedTable) => {
//   const expected = expectedTable.hashes();
//   const table = await helper.getElementByCss(cssLocator);
//   const seconds = browser.params.AwsSleepTimout ?
//     browser.params.AwsSleepTimout : browser.params.LocalSleepTumeout ?
//       browser.params.LocalSleepTumeout : sleepTimout;
//   await browser.sleep(seconds);
//   const actual = await helper.getTableContentAsJSON(table);
//
//   return expect(actual).to.not.include.deep.members(expected);
// });
//
// Then('{detail} table {css} with cell element {css} data does not contain values:', async (_, tableCssLocator, cellCssLocator, expectedTable) => {
//   const expected = expectedTable.hashes();
//   const table = await helper.getElementByCss(tableCssLocator);
//   const seconds = browser.params.AwsSleepTimout ?
//     browser.params.AwsSleepTimout : browser.params.LocalSleepTumeout ?
//       browser.params.LocalSleepTumeout : sleepTimout;
//   await browser.sleep(seconds);
//   const actual = await helper.getTableContentAsJSON(table, cellCssLocator);
//
//   return expect(actual).to.not.include.deep.members(expected);
// });
//
// /**
//  * Verify that each element is disabled.
//  * Verify by attribute disabled -> will pass, if element has an attribute 'disabled' or 'disabled=true'.
//  *
//  * @example
//  * 'User verifies each dropdown option "#option" is disabled'
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// Then('User verifies each {detail} {css} is disabled', async (_, cssLocator) => {
//   const elements = await $$(cssLocator).asElementFinders_();
//   for (let i = 0; i < elements.length; i++) {
//     expect(elements[i].isEnabled(), `${i + 1} element ${cssLocator} is not disabled`).to.eventually.equal(false);
//   }
// });
//
// /**
//  * Verify that each element is enabled.
//  * Verify by attribute disabled -> will pass, if element doesn't have an attribute 'disabled' or 'disabled=true'.
//  *
//  * @example
//  * 'User verifies each dropdown option "#option" is enabled'
//  *
//  * @param _ - element description
//  * @param cssLocator
//  */
// Then('User verifies each {detail} {css} is enabled', async (_, cssLocator) => {
//   const elements = await $$(cssLocator).asElementFinders_();
//   for (let i = 0; i < elements.length; i++) {
//     expect(elements[i].isEnabled(), `${i + 1} element ${cssLocator} is disabled`).to.eventually.equal(true);
//   }
//
// });
//
// Then('User verifies each {detail} {css} is mailTo link', async (_, itemCss) => {
//   const mailToRegExp = new RegExp('mailto:[a-zA-Z0-9.!#$%&\'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$');
//
//   const elementsArray = await $$(itemCss).asElementFinders_();
//   for (let i = 0; i < elementsArray.length; i++) {
//     const hrefValue = await elementsArray[i].getAttribute('href');
//
//     expect(hrefValue, `${i + 1} element ${itemCss} does not match mailto link`).to.match(mailToRegExp);
//   }
//
// });
//
//
// /**
//  * Verify that pagination is working correctly by moving forward and backward through a given table.
//  *
//  * @example
//  * Then User paginates through "UNIQUE:163_noOfUsers" rows of data, with page size 10, in table rows "usersPage|userTableRows", by clicking "usersPage|nextPageButton" for next and "usersPage|previousPageButton" for previous
//  *
//  * @param noOfRowsString the number of rows as a string.
//  * @param pageSize the size of each page.
//  * @param cssLocatorTableRows a css selector for the table rows, used to verify the number of expected rows in each page.
//  * @param cssLocatorNext a css selector for the component to click for "Next"
//  * @param cssLocatorPrevious a css selector for the component to click for "Previous"
//  */
//
// Then('User paginates through {text} rows of data, with page size {int}, in table rows {css}, by clicking {css} for next and {css} for previous', async (noOfRowsString, pageSize, cssLocatorTableRows, cssLocatorNext, cssLocatorPrevious) => {
//
//   const noOfRows = parseInt(noOfRowsString);
//
//   const noOfPages = noOfRows % pageSize === 0 ? noOfRows / pageSize : Math.floor(noOfRows / pageSize) + 1;
//   const noOfRowsInLastPage = noOfPages === 1 ? noOfRows : noOfRows - ((noOfPages - 1) * pageSize);
//
//   for (let i = 1; i <= noOfPages; i++) {
//     const tableRows = await helper.getElementByCss(cssLocatorTableRows);
//     await helper.waitElementVisibility(tableRows);
//
//     const noOfRowsInThisPage = await helper.getElementsCount(cssLocatorTableRows);
//     if (i === noOfPages) {
//       expect(noOfRowsInThisPage, 'Unexpected number of rows in last page of data.').to.eq(noOfRowsInLastPage);
//     }
//     else {
//       expect(noOfRowsInThisPage, `Unexpected number of rows in page ${i} of data`).to.eq(pageSize);
//       await (await helper.getElementByCss(cssLocatorNext)).click();
//     }
//   }
//
//   for (let j = noOfPages; j > 0; j--) {
//     const tableRows = await helper.getElementByCss(cssLocatorTableRows);
//     await helper.waitElementVisibility(tableRows);
//
//     const noOfRowsInThisPage = await helper.getElementsCount(cssLocatorTableRows);
//     if (j === noOfPages) {
//       expect(noOfRowsInThisPage, 'Unexpected number of rows in last page of data.').to.eq(noOfRowsInLastPage);
//     }
//     else {
//       expect(noOfRowsInThisPage, 'Unexpected number of rows in first page of data.').to.eq(pageSize);
//     }
//
//     if (j > 1) {
//       await (await helper.getElementByCss(cssLocatorPrevious)).click();
//     }
//   }
// });
//
// /**
//  * Verify that each element in given collection is present, clickable, visible, invisible, selected, gone, enabled or disabled
//  *
//  * @example
//  * User verifies each element in Add Icons List "HomePage|AddIconsList" is "enabled"
//  *
//  * @param _ element description
//  * @param locator a css selector for collection of the elements.
//  * @param validation validation value
//  */
// Then('User verifies each element in {detail} {css} is {text}', async (_, locator, validation) => {
//   const SHOULD_BE = ['present', 'clickable', 'visible', 'invisible', 'selected', 'gone', 'enabled', 'disabled'];
//   const validationText = validation.toLowerCase();
//
//   if (!SHOULD_BE.includes(validationText)) {
//     throw new Error(`Wrong validation - '${validation}' was given. Use: ${SHOULD_BE.join(' or ')}`);
//   }
//   const collectionOfElements = await $$(locator).asElementFinders_();
//
//   return Promise.all(collectionOfElements.map(el => browser.wait(helper.ECHelper(el, validation), browser.params.timeout, `Not all items in ${_} are ${validation}`)));
// });
//
// /**
//  * Verify that each element in given collection is NOT present, clickable, visible, invisible, selected, gone, enabled or disabled
//  *
//  * @example
//  * User verifies each element in Add Icons List "HomePage|AddIconsList" is not "enabled"
//  *
//  * @param _ element description
//  * @param locator a css selector for collection of the elements.
//  * @param validation validation value
//  */
// Then('User verifies each element in {detail} {css} is not {text}', async (_, locator, validation) => {
//   const SHOULD_BE = ['present', 'clickable', 'visible', 'invisible', 'selected', 'gone', 'enabled', 'disabled'];
//   const validationText = validation.toLowerCase();
//
//   if (!SHOULD_BE.includes(validationText)) {
//     throw new Error(`Wrong validation - '${validation}' was given. Use: ${SHOULD_BE.join(' or ')}`);
//   }
//   const collectionOfElements = await $$(locator).asElementFinders_();
//
//   return Promise.all(collectionOfElements.map(el => browser.wait(helper.ECHelper(el, validation, false), browser.params.timeout, `Not all items in ${_} are not ${validation}`)));
// });
//
// /**
//  * Verify that default selected option in drop-down is equal to given text (no need to check attribute 'value')
//  *
//  * @example
//  * User verifies default selected option in Country Dropdown "HomePage|CountryDropdown" dropdown is equal to "Spain"
//  *
//  * @param _ element description
//  * @param elementCssSelector a css selector for drop-down element
//  * @param validationText validation text value
//  */
// Then('User verifies default selected option in {detail} {css} dropdown is equal to {text}', async (_, elementCssSelector, validationText) => {
//   const elementDropdown = await helper.getElementByCss(elementCssSelector);
//   const defaultSelectedOption = await browser.executeScript('return arguments[0].selectedOptions[0].text;', elementDropdown);
//   return expect(defaultSelectedOption).to.equal(validationText);
// });
//
// /**
//  * Verify that dropdown list contains specific values (can be more values than specified)
//  *
//  * @example
//  * Date dropdown option list "#options" includes values:
//  * |Jun 2019|
//  * |Mar 2019|
//  * |Dec 201
//  * |Sep 201
//  *
//  * @param _ - dropdown description
//  * @param - cssLocators
//  * @param expectedDropdownOptions - expected dropdown options list
//  */
// Then('{detail} list {css} includes values:', async (_, cssLocators, expectedDropdownOptions) => {
//   const expected = expectedDropdownOptions.raw();
//   const actual = await helper.getElementTexts(cssLocators);
//   return expect(actual).to.deep.include.members(expected);
// });
//
// /**
//  * Verify element date with given format
//  *
//  * @example
//  * "Page|Section|Element" date with format "DD-MMM-YYYY" is "=" "Current Date" date with format "DD-MMM-YYYY"
//  * @example
//  * "Page|Section|Element" date with format "DD-MMM-YYYY" is ">=" "10-Jun-2018" date with format "DD-MMM-YYYY"
//  *
//  * @param _ - element description
//  * @param firstDate - css locator to the element with date
//  * @param firstFormatKey - String with date format
//  * @param verificationOption - one of the given option: <, <=, =, >, >=
//  * @param secondDate - String value with expected date (can be set as "Current Date" and it will take todays day)
//  * @param secondFormatKey - String value with expected format
//  */
// Then('{detail} {css} date with format {text} is {text} {text} date with format {text}', async (_, firstDate, firstFormatKey, verificationOption, secondDate, secondFormatKey) => {
//   const elementDate = await helper.getElementByCss(firstDate);
//   const inputOrText = await elementDate.getTagName();
//   let elementText;
//
//   // inputs don't have text, only value
//   if (inputOrText === 'input' || inputOrText === 'select') {
//     elementText = await elementDate.getAttribute('value');
//   } else {
//     elementText = await elementDate.getText();
//   }
//   elementText = moment(moment(elementText).format(firstFormatKey));
//
//   let date;
//   const currentDate = moment().format(secondFormatKey);
//
//   if (secondDate === 'Current Date') {
//     date = currentDate;
//   } else {
//     date = moment(secondDate).format(secondFormatKey);
//   }
//
//   let success;
//   switch (verificationOption) {
//   case '<':
//     success = elementText.isBefore(date);
//     break;
//   case '<=':
//     success = elementText.isBefore(date) || elementText.isSame(date);
//     break;
//   case '=':
//     success = elementText.isSame(date);
//     break;
//   case '>':
//     success = elementText.isAfter(date);
//     break;
//   case '>=':
//     success = elementText.isAfter(date) || elementText.isSame();
//     break;
//   default:
//     success = false;
//     console.log('ERROR. ' + verificationOption + ' is not supported as a verification option.');
//     break;
//   }
//
//   return expect(success, `${elementText} is not ${verificationOption} ${date}`).to.be.true;
// });



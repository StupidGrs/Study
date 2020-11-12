/**
 * Here will be application specific verification step methods
 */
require('../support/parameter-types');
const chai = require('chai');
const chaiAsPromised = require('chai-as-promised');
chai.use(chaiAsPromised);
const expect = chai.expect;
// TODO discuss do we really need to have next 3 unused variable here
// const expect = chai.expect;
// const path = require('path');
// const loginPage = require('../../data/page-selectors/login-page');
const { fileHelper, elementHelper } = require('ngpd-merceros-testautomation-ta');
const { setDefaultTimeout } = require('cucumber');
const { Then } = require('cucumber');
const moment = require("moment");
const utils = require('./utils/utils');
const dateUtils = require('../../utils/date-util');
const path = require('path');
const fileSep = path.sep;// returns '\\' on windows, '/' on *nix
const api_requests = require("../step-definitions/utils/api_requests");

// const timeOut24h = 24 * 60 * 60000;
// setDefaultTimeout(timeOut24h);
setDefaultTimeout(300 * 1000);

/**
 * Verify that some localized text is matched to expected value using REGEXP
 * Expected value is stored in "data/text-data.js" file with LOCALIZATION identification
 * Global parameter LOCALIZATION is specified in "common_config.js" file
 * Used for library tests
 *
 * @example
 * Toast "homePage|toastContainer" text is matched "LoginPage|loginErrorEmpty"
 *
 * @param element/data description
 * @param cssLocator
 * @param value - expected value using REGEXP
 */
Then('{detail} {css} text is matched {localized-text}', function (_, cssLocator, value) {
  return elementHelper.getElementByCss(cssLocator).getText().then((text) => {
    return expect(text).to.match(value);
  });
});

/**
 * Verify that some localized text is equal to expected value
 * Expected value is stored in "data/text-data.js" file with LOCALIZATION identification
 * Global parameter LOCALIZATION is specified in "common_config.js" file
 * Used for library tests
 *
 * @example
 * Toast "homePage|toastContainer" text is the same as "LoginPage|loginErrorEmptyNotREGEXP"
 *
 * @param element/data description
 * @param cssLocator
 * @param value - expected value
 */
Then('{detail} {css} text is the same as {localized-text}', function (_, cssLocator, value) {
  return elementHelper.getElementByCss(cssLocator).getText().then((text) => {
    return expect(text).to.equalIgnoreCase(value)
  });
});

Then('{detail} {css} text is equal to {text} with break line', async (_, cssLocator, value) => {
  const elem = await elementHelper.getElementByCss(cssLocator);
  let elementText;

  if ((await elem.getTagName()) === 'select') {
    const optionIndex = await elem.getAttribute('value');
    const optionElement = elem.element(by.css('option[value="' + optionIndex + '"]'));
    elementText = await optionElement.getText();
  } else {
    elementText = await elem.getText();
  }

  const formattedText = elementText.replace(/(\r\n|\n|\r)/gm, ' ');

  typeof value === 'string' ?
      expect(formattedText).to.equalIgnoreCase(value) :
      expect(formattedText).to.match(value.trim());
});


/**
 * @example
 * "homePage|date" date is equal to "Current Date" date with format "DD-MMM-YYYY"
 * 
 * @param cssLocator - cssLocator of the element with date
 * @param secondDate  - expected date 
 * @param dateFormat - date format
 */
Then('{css} date is equal to {text} date with format {text}', async (cssLocator, secondDate, dateFormat) => {
  const elementText = await utils.getElementText(cssLocator);
  const currentDate = moment().format(dateFormat);
  const date = secondDate === "Current Date" ? currentDate : moment(new Date(secondDate)).format(dateFormat);

  return expect(elementText).to.equal(date);
});

/**
 * @example
 * "homePage|date" date is equal to "Current Date" date 
 * 
 * compare dates ignoring format
 * 
 * @param cssLocator - cssLocator of the element with date
 * @param secondDate  - expected date 
 * 
 */
Then('{css} date is equal to {text} date', async (cssLocator, secondDate) => {
  let elementText = await utils.getElementText(cssLocator);
  elementText = moment(elementText).format('MM/DD/YYYY');
  const currentDate = moment().format('MM/DD/YYYY');
  const date = secondDate === "Current Date" ? currentDate : moment(new Date(secondDate));
  const success = moment(elementText).isSame(date);

  return expect(success, `${elementText} is not the same as ${date}`).to.be.true;
});


/**
 * @example
 * Post Status "userPostsPage|articleStatusesList" contains "Current Date" date in format "MMM D, YYYY"
 * 
 * @param cssLocator - cssLocator of the element with date
 * @param date  - expected date 
 * @param format - date format
 * 
 */
Then('{detail} {css} contains {text} date in format {text}', async (_, cssLocator, expectedDate, dateFormat) => {
  const elementText = await utils.getElementText(cssLocator);
  const currentDate = moment().format(dateFormat);
  const date = expectedDate === "Current Date" ? currentDate : moment(new Date(expectedDate)).format(dateFormat);

  return expect(elementText).to.contains(date);
});

/**
 * @example
 * Event Date in the Header details "eventDetailsPage|dateTimeHeader" contains Start Date "05/20/2020" and Time "4:10 AM" and End Date "05/20/2021" and Time "4:10 PM" in short format with GMT offset
 * 
 * @param cssLocator - cssLocator of the element with date
 * @param eventStartDate  - event Start Date
 * @param eventStartTime - event Start Time
 * @param eventEndDate  - event End Date
 * @param eventEndTime  - event End Time
 * 
 */
Then('{detail} {css} contains Start Date {text} and Time {text} and End Date {text} and Time {text} in short format with GMT offset', async (_, cssLocator, eventStartDate, eventStartTime, eventEndDate, eventEndTime) => {
  //extract date without time from Dates
  const startDate = dateUtils.extractDate(eventStartDate);
  const endDate = dateUtils.extractDate(eventEndDate);

  //get full event start date time and end date time
  const startDateTime = eventStartTime ? moment(startDate + ' ' + eventStartTime) : moment(startDate);
  const endDateTime = eventEndTime ? moment(endDate + ' ' + eventEndTime) : moment(endDate);

  //check if eventStartDate and eventEndDate are the same day
  const isSameDay = startDateTime.isSame(endDateTime, 'day');
  const isSameMonth = startDateTime.isSame(endDateTime, 'month');
  const isSameYear = startDateTime.isSame(endDateTime, 'year');

  const dateOffset = ' GMT' + (moment().format('Z')).toString();
    // const dateOffset = ' GMT-06:00'; /// WB updated 2020-07-30
  const startTimeWithOffset = startDateTime.format('h:mma').toString() + dateOffset;

  let result;
  if (!isSameYear) {
    //different years
    //Dec 20th 2019-Jan 22nd, 2020 / 1:00pm GMT+03:00
    const startDateFormat = startDateTime.format('MMM Do YYYY');
    const endDateFormat = endDateTime.format('MMM Do, YYYY');
    result = `${startDateFormat}-${endDateFormat} / ${startTimeWithOffset}`;
  } else {
    if (!isSameMonth) {
      //same year, different month
      //Nov 15th-Dec 26th, 2019 / 1:00pm GMT+03:00
      const startDateFormat = startDateTime.format('MMM Do');
      const endDateFormat = endDateTime.format('MMM Do, YYYY');
      result = `${startDateFormat}-${endDateFormat} / ${startTimeWithOffset}`;
    } else {
      if (!isSameDay) {
        //same year, same month, different days
        //Dec 15-31st, 2019 / 11:00am GMT+03:00
        const startDateFormat = startDateTime.format('MMM D');
        const endDateFormat = endDateTime.format('Do, YYYY');
        result = `${startDateFormat}-${endDateFormat} / ${startTimeWithOffset}`;
      } else {
        //same year, same month, same day
        //Sep 26th 2019 / 3:00am GMT+03:00
        const startDateFormat = startDateTime.format('MMM Do YYYY');
        result = `${startDateFormat} / ${startTimeWithOffset}`;
      };
    };
  };

  const elementText = await utils.getElementText(cssLocator);

  return expect(elementText).to.contains(result);
});
// Egle:2020-09-10 Add new script with GMT +2 time zone

Then('{detail} {css} contains Start Date {text} and Time {text} and End Date {text} and Time {text} in short format with GMT +02:00', async (_, cssLocator, eventStartDate, eventStartTime, eventEndDate, eventEndTime) => {
  //extract date without time from Dates
  const startDate = dateUtils.extractDate(eventStartDate);
  const endDate = dateUtils.extractDate(eventEndDate);

  //get full event start date time and end date time
  const startDateTime = eventStartTime ? moment(startDate + ' ' + eventStartTime) : moment(startDate);
  const endDateTime = eventEndTime ? moment(endDate + ' ' + eventEndTime) : moment(endDate);

  //check if eventStartDate and eventEndDate are the same day
  const isSameDay = startDateTime.isSame(endDateTime, 'day');
  const isSameMonth = startDateTime.isSame(endDateTime, 'month');
  const isSameYear = startDateTime.isSame(endDateTime, 'year');

  const dateOffset = ' GMT+02:00'
  const startTimeWithOffset = startDateTime.format('h:mma').toString() + dateOffset;

  let result;
  if (!isSameYear) {
    //different years
    //Dec 20th 2019-Jan 22nd, 2020 / 1:00pm GMT+03:00
    const startDateFormat = startDateTime.format('MMM Do YYYY');
    const endDateFormat = endDateTime.format('MMM Do, YYYY');
    result = `${startDateFormat}-${endDateFormat} / ${startTimeWithOffset}`;
  } else {
    if (!isSameMonth) {
      //same year, different month
      //Nov 15th-Dec 26th, 2019 / 1:00pm GMT+03:00
      const startDateFormat = startDateTime.format('MMM Do');
      const endDateFormat = endDateTime.format('MMM Do, YYYY');
      result = `${startDateFormat}-${endDateFormat} / ${startTimeWithOffset}`;
    } else {
      if (!isSameDay) {
        //same year, same month, different days
        //Dec 15-31st, 2019 / 11:00am GMT+03:00
        const startDateFormat = startDateTime.format('MMM D');
        const endDateFormat = endDateTime.format('Do, YYYY');
        result = `${startDateFormat}-${endDateFormat} / ${startTimeWithOffset}`;
      } else {
        //same year, same month, same day
        //Sep 26th 2019 / 3:00am GMT+03:00
        const startDateFormat = startDateTime.format('MMM Do YYYY');
        result = `${startDateFormat} / ${startTimeWithOffset}`;
      };
    };
  };

  const elementText = await utils.getElementText(cssLocator);

  return expect(elementText).to.contains(result);
});




/**
 * @example
 * Time "eventDetailsPage|timeBottom" contains "4:10am – 4:10pm" text with GMT offset
 * 
 * @param cssLocator - cssLocator of the element with date
 * @param text  - text
 * 
 */
Then('{detail} {css} contains {text} text with GMT offset', async (_, cssLocator, text) => {
  const gmtOffset = ' GMT' + (moment().format('Z')).toString();
  const result = text + gmtOffset;
  const elementText = await utils.getElementText(cssLocator);

  return expect(elementText).to.contains(result);
});


/**
 * @example
 * Video Error "researchDetailsPage|videoError" is not displayed in iframe "researchDetailsPage|videoIframe" 
 * 
 * @param elemCssLocator - cssLocator of the element inside of iframe
 * @param iframeCssLocator  - cssLocator of the iframe
 * 
 */
Then('{detail} {css} is not displayed in iframe {css}', async (_, elemCssLocator, iframeCssLocator) => {

  const iframeElement = await (await elementHelper.getElementByCss(iframeCssLocator)).getWebElement();
  let isElementNotVisible;
  await browser.switchTo().frame(iframeElement);
  try {
    const elem = element(by.css(elemCssLocator));
    isElementNotVisible = await elementHelper.isElementNotVisible(elem, 1000);
  } catch (e) {
    await browser.switchTo().defaultContent();
    throw new Error(e);
  };
  await browser.switchTo().defaultContent();

  return expect(isElementNotVisible).to.equal(true);
});

/**
 * @example
 * Video Error "researchDetailsPage|videoError" is displayed in iframe "researchDetailsPage|videoIframe" 
 * 
 * @param elemCssLocator - cssLocator of the element inside of iframe
 * @param iframeCssLocator  - cssLocator of the iframe
 * 
 */
Then('{detail} {css} is displayed in iframe {css}', async (_, elemCssLocator, iframeCssLocator) => {

  const iframeElement = await (await elementHelper.getElementByCss(iframeCssLocator)).getWebElement();
  await browser.switchTo().frame(iframeElement);
  let isElementVisible;
  try {
    const elem = element(by.css(elemCssLocator));
    isElementVisible = await elementHelper.isElementVisible(elem, 1000);
  } catch (e) {
    await browser.switchTo().defaultContent();
    throw new Error(e);
  };
  await browser.switchTo().defaultContent();

  return expect(isElementVisible).to.equal(true);
});



/**
 * @example
 * Followers "researchDetailsPage|leftBlockCompanyFollowers" value "$followers" is increased by 1
 * 
 * @param elemCssLocator - cssLocator of the element 
 * @param originalValue - original value of the element
 * @param number - number
 * 
 */
Then('{detail} {css} value {text} is increased by {int}', async (_, elemCssLocator, originalValue, number) => {
  //TODO: check why cannot use getElementText from ta framework
  let text = await utils.getElementText(elemCssLocator);
  text = text.replace(',', '.');
  text = text.replace(/[^0-9.]/g, '');
  text = parseFloat(text);

  originalValue = originalValue.replace(',', '.');
  originalValue = originalValue.replace(/[^0-9.]/g, '');
  originalValue = parseFloat(originalValue);

  const total = originalValue + number;

  return expect(text).to.equal(total);
});

/**
 * @example
 * Followers "researchDetailsPage|leftBlockCompanyFollowers" value "$followers" is decreased by 1
 * 
 * @param elemCssLocator - cssLocator of the element 
 * @param originalValue - original value of the element
 * @param number - number
 * 
 */
Then('{detail} {css} value {text} is decreased by {int}', async (_, elemCssLocator, originalValue, number) => {

  let text = await utils.getElementText(elemCssLocator);
  text = text.replace(',', '.');
  text = text.replace(/[^0-9.]/g, '');
  text = parseFloat(text);

  originalValue = originalValue.replace(',', '.');
  originalValue = originalValue.replace(/[^0-9.]/g, '');
  originalValue = parseFloat(originalValue);

  const total = originalValue - number;

  return expect(text).to.equal(total);
});

/**
 * Verify that hash of downloaded file is equal to hash of some template file.
 * Put expected file "file-upload.xlsx" template into features/test-data/file-templates/.
 *
 * @example
 * User verify downloaded file "file-upload.xlsx" hash is equal to template file "file-upload.xlsx" hash
 *
 * @param fileName - downloaded file name
 * @param templateFileName
 *
 */
Then('User verifies downloaded file {text} hash is equal to template file {text} hash', async (fileName, templateFileName) => {
  const filePath = browser.params.basePath + fileSep + fileName;// generate file path
  const fileTemplatePath = path.resolve(__dirname, '../../features/test-data/file-templates/' + templateFileName);
  const templateFileHash = await fileHelper.getFileHash(fileTemplatePath);
  const fileHash = await fileHelper.getFileHash(filePath);
  return expect(fileHash).to.equal(templateFileHash);
});

Then('User {user} performs Company search by Full Company Name and checks the first {int} result(s) - test {text} companies', { timeout: 60 * 60 * 1000 }, async function (user, nResults, nRuns) {
  const notFound = await api_requests.searchCompanyTest(user, 'fullName', nResults, nRuns);
  return expect(notFound, notFound).to.be.empty;
});

Then('User {user} performs Company search by First {int} word(s) from Company Name and checks first {int} result(s) - test {text} companies', { timeout: 60 * 60 * 1000 }, async function (user, nWords, nResults, nRuns) {
  const notFound = await api_requests.searchCompanyTest(user, nWords, nResults, nRuns);
  return expect(notFound, notFound).to.be.empty;
});

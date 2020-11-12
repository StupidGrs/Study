const Memory = require("./memory/Memory");
const { Then, When } = require('cucumber');
const utils = require("./utils/utils");
const { elementHelper } = require('ngpd-merceros-testautomation-ta');
const stringUtils = require("./../../utils/string-util");
const moment = require("moment");
const api_requests = require('../step-definitions/utils/api_requests');

When(`User remembers value of {text} attribute of {css} as {text}`, async (attrName, locator, key) => {
    const attr = await (await elementHelper.getElementByCss(locator)).getAttribute(attrName);
    return Memory.setValue(key, attr);
});

When(`User remembers text of {css} as {text}`, async (locator, key) => {
    const text = await (await elementHelper.getElementByCss(locator)).getText();
    return Memory.setValue(key, text);
});

When(`User remembers {text} item's attribute {text} in {css} collection as {text}`, async (itemNumber, attrName, locator, key) => {
    const elements = utils.getListOfElementsByCss(locator);
    await browser.wait(protractor.ExpectedConditions.visibilityOf(elements.get(parseInt(itemNumber) - 1)), browser.params.timeout, 'Wait for element appears');
    const attr = await (await elements.get(parseInt(itemNumber) - 1)).getAttribute(attrName);
    return Memory.setValue(key, attr);
});

When(`User remembers {text} item's text in {css} collection as {text}`, async (itemNumber, locator, key) => {
    const elements = utils.getListOfElementsByCss(locator);
    await browser.wait(protractor.ExpectedConditions.visibilityOf(elements.get(parseInt(itemNumber) - 1)), browser.params.timeout, 'Wait for element appears');
    const elementText = await elements.get(parseInt(itemNumber) - 1).getText();
    return Memory.setValue(key, elementText);
});

When('User remembers length of {css} collection as {text}', async (locator, key) => {
    await browser.wait(protractor.ExpectedConditions.visibilityOf(await elementHelper.getElementByCss(locator)), browser.params.timeout, 'Wait for element appears');
    const length = await elementHelper.getElementsCount(locator);
    return Memory.setValue(key, length);
});

When('User remembers text {text} with added unique Id as {text}', async (text, key) => {
    text = '000_' + text;
    const textWithUniqueId = stringUtils.getTextWithUniqueGuid(text);
    console.log('wb: text - ' + text);
    console.log('wb: textWithUniqueId - ' + textWithUniqueId);
    return Memory.setValue(key, textWithUniqueId);
});

When('User remembers current date in format {text} as {text}', async (format, key) => {
    const currentDate = moment().format(format);
    return Memory.setValue(key, currentDate);
});

When('User remembers date {text} in format {text} as {text}', async (date, format, key) => {
    const res = moment(date).format(format);
    return Memory.setValue(key, res);
});

When('User remembers Start Date of Event with title {text} as {text}', async (eventTitle, key) => {
    const startDate = await api_requests.getEventStartDateByTitle(eventTitle);
    return Memory.setValue(key, startDate);
});

When('User remembers End Date of Event with title {text} as {text}', async (eventTitle, key) => {
    const endDate = await api_requests.getEventEndDateByTitle(eventTitle);
    return Memory.setValue(key, endDate);
});

When('User remembers Start Date of Event with title {text} in format {text} as {text}', async (eventTitle, dateFormat, key) => {
    const startDate = await api_requests.getEventStartDateByTitle(eventTitle);
    const startDateFormatted = moment(startDate).format(dateFormat);

    return Memory.setValue(key, startDateFormatted);
});

When('User remembers End Date of Event with title {text} in format {text} as {text}', async (eventTitle, dateFormat, key) => {
    const endDate = await api_requests.getEventEndDateByTitle(eventTitle);
    const endDateFormatted = moment(endDate).format(dateFormat);

    return Memory.setValue(key, endDateFormatted);
});

When(`User remembers File Name from {text} attribute of {css} as {text}`, async (attrName, locator, key) => {
    const url = await (await elementHelper.getElementByCss(locator)).getAttribute(attrName);
    const filename = url.split('/').pop();
    return Memory.setValue(key, filename);
});

/**
 * @example
 * User remembers current date "minus" "1 Year, 2 Months, 3 Days, 2 Hours, 1 Minutes, 10 Seconds" as "publishDate"
 * 
 * @param op operation: "minus" or "plus"
 * @param dateValues values to decrease/increase current date
 * @param key remember key
 * 
 */
When(`User remembers current date {text} {text} as {text}`, async (op, dateValues, key) => {
    const dateObj = dateValues.toLowerCase().split(',').reduce((obj, item) => {
        const value = item.trim().split(' ')[0];
        if (item.includes('year')) obj['years'] = value;
        if (item.includes('month')) obj['months'] = value;
        else if (item.includes('day')) obj['days'] = value;
        else if (item.includes('hour')) obj['hours'] = value;
        else if (item.includes('minute')) obj['minutes'] = value;
        else if (item.includes('second')) obj['seconds'] = value;
        return obj;
    }, {});
    let resultDate = moment();
    switch (op) {
        case 'minus':
            for (const prop in dateObj) {
                resultDate.subtract(dateObj[prop], prop);
            };
            break;
        case 'plus':
            for (const prop in dateObj) {
                resultDate.add(dateObj[prop], prop);
            };
            break;
        default:
            throw new Error(`"${minusOrPlus}" is not supported. Supported options: "minus" or "plus"`);
    };
    resultDate = resultDate.toISOString();

    return Memory.setValue(key, resultDate);
});
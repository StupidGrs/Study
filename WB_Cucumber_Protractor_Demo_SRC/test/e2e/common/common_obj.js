/**
 * Created by webber-ling on 6/2/2017.
 */
"use strict";

const ec = protractor.ExpectedConditions;
const util_windows = require('../common/utilities/util_windows');
const futil_windows = new util_windows();
const path = require('path');

const chai = require('chai');
const chaiAsPromised = require('chai-as-promised');
chai.use(chaiAsPromised);
const expect = chai.expect;


const common_obj = function () {





    const __log = function (description) {
        console.log('------ custom log:   ' + description);
    };

    this.__log = function (description) {
        __log(description);
    };

    const __ElementPresent = async function (description, element, timeout = browser.params.timeouts.obj_timeout) {
        return browser.driver.wait(ec.presenceOf(element), timeout, 'Element <' + description + '> does NOT Present in <' + timeout + '> seconds').then(function(){
            __log('__ElementPresent: ' + description);
        });
    };

    this.__ElementPresent = async function (description, element, timeout = browser.params.timeouts.obj_timeout){
        await __ElementPresent(description, element, timeout);
    };

    const __ElementVisible = async function (description, element, timeout = browser.params.timeouts.obj_timeout) {
        return browser.driver.wait(ec.visibilityOf(element), timeout, 'Element <' + description + '> does NOT visible in <' + timeout + '> seconds');
    };

    const __ElementClickable = async function (description, element, timeout = browser.params.timeouts.obj_timeout) {
        return browser.driver.wait(ec.elementToBeClickable(element), timeout, 'Element <' + description + '> does NOT clickable in <' + timeout + '> seconds');
    };

    const __ElementScrollIntoView = async function (element) {
        return browser.executeScript('arguments[0].scrollIntoView();', await element.getWebElement());
    };

    this.__ElementScrollIntoView = async function (element) {
        await __ElementScrollIntoView(element);
    };

    this.__isElementDisplayedContainingText = async function (el, text, description = 'qa is lazy', exactMatch = true, useAttribute = false) {

        await browser.sleep(browser.params.actionDelay.step_delay);

        await __ElementVisible(description, el);


        if(exactMatch){
            if(useAttribute)
                return expect(await el.getAttribute('value'), description).to.equal(text);
            else
                return expect(await el.getText(), description).to.equal(text);
        }
        else{
            if(useAttribute)
                return expect(await el.getAttribute('value'), description).to.contains(text);
            else
                return expect(await el.getText(), description).to.contains(text);
        }


    };

    this.__isElementDisplayed = async function (el, description = 'qa is lazy', timeout = browser.params.userSleep.medium) {

        await __ElementVisible(description, el, timeout);
        return expect(await el.isDisplayed()).to.equal(true);

    };

    this.__wait4ElementVisible = async function (el, description = 'qa is lazy', iTimeOut = browser.params.timeouts.obj_timeout) {

        return browser.wait(ec.visibilityOf(el), iTimeOut).then(function () {
            __log('..... wait for object visible.....: ' + description);
        });

    };


    this.__wait4ElementInvisible = async function (el, description = 'qa is lazy', iTimeOut = browser.params.timeouts.obj_timeout) {

        return browser.wait(ec.invisibilityOf(el), iTimeOut).then(function () {
            __log('..... wait for object invisible.....: ' + description);
        });

    };

    this.__wait4ElementInvisible = async function (el, description = 'qa is lazy', iTimeOut = browser.params.timeouts.obj_timeout) {

        return browser.wait(ec.invisibilityOf(el), iTimeOut).then(function () {
            __log('..... wait for object invisible.....: ' + description);
        });

    };




    this.__click = async function (description, element, xPos = 1, yPos = 1, bScrollIntoView = true) {


        await browser.sleep(browser.params.actionDelay.step_delay);

        await __ElementPresent(description, element);
        if (bScrollIntoView)
            await __ElementScrollIntoView(element);
        await __ElementClickable(description, element);


        if (xPos === 1) {
            return element.click().then(function (err) {
                if (err) {
                    __log('fail: click on element <' + description + '>');
                    __log(err);
                }
                else {
                    __log('success: click on element <' + description + '>');

                }
            });
        }
        else {
            return browser.actions().mouseMove(await element.getWebElement(), {x: xPos, y: yPos}).click().perform().then(function () {
                __log('success: click on element <' + description + '> on X: ' + xPos + ', Y: ' + yPos);
            });
        }


    };

    this.__executeScript = async function (el, description = 'qa is lazy', sType = 'qa is lazy', sValue = '') {

        // await browser.sleep(15000);
        await browser.sleep(browser.params.actionDelay.step_delay);

        await __ElementPresent(description, el);
        // await __ElementVisible(description, el);
        // await __ElementScrollIntoView(el);
        switch (sType) {
            case 'click':
                return browser.executeScript('arguments[0].click();', el.getWebElement()).then(function (txt) {
                    __log('Execute Script: ' + sType + ' on object: ' + description);
                });
                break;
            case 'setText':
                return browser.executeScript(await el.getWebElement() + '.value=' + sValue).then(function (txt) {
                    __log('Execute Script: ' + sType + ' on object: ' + description + ' with value: ' + sValue);
                });

                break;
            default:
                throw new Error('Incorrect input Type name [' + sType + ']');
        }

    };


    const __deleteText = async function (description, element, bVerify = true) {

        await browser.sleep(browser.params.actionDelay.step_delay);

        await element.clear();

        __log('success: delete text from element <' + description + '>');

        if(bVerify){
            return expect(await element.getAttribute('value')).to.equal('');
        }



        //element.sendKeys(protractor.Key.BACK_SPACE);


    };

    this.__deleteText = async function (description, element, bVerify = true) {

        await __ElementPresent(description, element);
        await __ElementScrollIntoView(element);
        await __ElementClickable(description, element);

        await __deleteText(description, element, bVerify);

    };

    /**
     * Function:    __setText => set text to element
     * Parm_1:      web element to set test into
     * Parm_2:      the text value
     * Parm_3:      optional, delete exsiting value or not, default is false
     * Created by webber-ling on 6/2/2017.
     *
     */
    this.__setText = async function (description, element, value, bDeleteExisting = true, bVerify = true, bScrollIntoView = true) {

        await browser.sleep(browser.params.actionDelay.step_delay);

        if (value.toString().length !== 0) {

            await __ElementPresent(description, element);
            if (bScrollIntoView)
                await __ElementScrollIntoView(element);
            await __ElementClickable(description, element);


            if (value.toString() === '#del#') {
                await __deleteText(description, element, bVerify);
            }
            else {
                if (bDeleteExisting) {
                    await __deleteText(description, element, bVerify);
                }
                await element.sendKeys(value);

                __log('success: set text: <' + value + '> to element <' + description + '>');
                if (bVerify)
                    return expect(await element.getAttribute('value')).to.equal(value);

            }

        }



    };

    /**
     * Function:    __selectByText => select dropdown item by name
     * Parm_1:      description of the dropdown element
     * Parm_2:      dropdown element
     * Parm_3:      dropdown name to be selected
     * Created by webber-ling on 7/20/2017.
     *
     * sample:
     *  fcommon_obj.__selectByText("Select Application dropdown", pcommon_page._SelectApplication, '~Testing - Webber 1');
     */
    this.__selectByText = async function (description, element, text, byOption=true) {

        if (text !== '') {
            await __ElementPresent(description, element);
            await __ElementScrollIntoView(element);
            await __ElementClickable(description, element);

            if(byOption)
                await this.__click(text, element.element(by.cssContainingText('option', text)));
            else
                await this.__click(text, element.element(by.css('[value=' + text +']')));
        }
    };

    this.__isCheckBoxChecked = async function (el, description = 'qa is lazy', check_uncheck = true) {


        await el.isSelected().then(function (checked) {
            return expect('Checkbox: ' + description + ' Status: ' + checked).to.equal('Checkbox: ' + description + ' Status: ' + check_uncheck);
        });

    };



    //////////////////////////////////////// below is Protractor-Jasmine functions/////////////////////////////////////////////









    this.__deleteText_byKey = function (description, element, bVerify = true, iNum = 30) {

        element.sendKeys(protractor.Key.END);

        for (let i = 0; i < iNum; i++)
            element.sendKeys(protractor.Key.BACK_SPACE);

        if (bVerify)
            expect(element.getAttribute('value')).toEqual('');

        browser.sleep(browser.params.actionDelay.step_delay);
    };






    this.__rightClick = function (description, element) {

        __ElementPresent(description, element);
        this.__ElementScrollIntoView(element);
        __ElementClickable(description, element);

        browser.actions().mouseMove(element).click(protractor.Button.RIGHT).perform().then(function () {
            __log('success: right click on element <' + description + '>');
        });

        browser.sleep(browser.params.actionDelay.step_delay);

    };


    /**
     * Function:    __selectByValue => select dropdown item by value
     * Parm_1:      description of the dropdown element
     * Parm_2:      dropdown element
     * Parm_3:      dropdown item value
     * Created by webber-ling on 7/20/2017.
     */
    this.__selectByValue = function (description, element, value) {

        __ElementPresent(description, element);
        this.__ElementScrollIntoView(element);
        __ElementClickable(description, element);

        this.__click(description + ':' + value, element.element(by.css('[value="' + value + '"]')));

    };



    this.__selectByIndex = function (description, element, index) {

        if (index !== '') {
            __ElementPresent(description, element);
            this.__ElementScrollIntoView(element);
            __ElementClickable(description, element);

            this.__click(description + ':' + index, element.all(by.tagName('option')).get(index));
        }
    };

    this.__clickButton_AutoIT = function (position) {

        let absolutePath_exe, actCmd;
        absolutePath_exe = path.resolve(__dirname, '../common/utilities/ClickBrowse_btn.exe');
        // actCmd = '"' + absolutePath_exe + '"';

        actCmd = '"' + absolutePath_exe + '"' + ' ' + position;
        futil_windows.__runCmd(actCmd);

    };

    this.__clickButton_Common = function (name, indexNum = 0, xPos = 1, yPos = 1) {

        element.all(by.cssContainingText('button', name)).then(function (all) {
            __log('Button: ' + name + ' total instance: ' + all.length);
            for (let i = 0; i < all.length; i++) {
                all[i].isDisplayed().then(function (visible) {
                    __log(name + ': ' + i + ' visible: ' + visible);
                });
            }
        });

        /////// indexNum means the index number of visible instance, not the nuber of all instance
        this.__click(name, element.all(by.cssContainingText('button', name)).filter(function (elem, index) {
            return elem.isDisplayed().then(function (visible) {
                // __log(name + ': ' + index + ' visible: ' + visible);
                return visible === true;
            });
        }).get(indexNum), xPos, yPos);

        // let iVisible = 0;
        // element.all(by.cssContainingText('button', name)).then(function (all) {
        //   fcommon_obj.__log('Button: ' + name + ' total instance: ' + all.length);
        //   for (let i = 0; i < all.length; i++) {
        //     all[i].isDisplayed().then(function (visible) {
        //       iVisible = i;
        //       fcommon_obj.__log(iVisible + ': ' + visible);
        //       if (visible)
        //         fcommon_obj.__click(name, element.all(by.cssContainingText('button', name)).get(iVisible));
        //     });
        //   }
        // });
    };



    this.__isElementPresent = function (el, description = 'qa is lazy', timeout = browser.params.userSleep.medium) {
        __ElementPresent(description, el, timeout);
        expect(el.isPresent()).toBe(true);
    };

    this.__isElementNotPresent = function (el, description = 'qa is lazy') {
        expect(el.isPresent()).toBe(false);
    };

    this.__isElementNotDisplayed = function (el, description = 'qa is lazy') {

        // __ElementVisible(description, el);
        expect(el.isDisplayed()).toBe(false);

    };

    this.__isElementEnabled = function (el, description = 'qa is lazy', timeout = browser.params.userSleep.medium) {
        this.__ElementScrollIntoView(el);
        __ElementClickable(description, el, timeout);
        expect(el.isEnabled()).toBe(true);

    };

    this.__isElementDisabled = function (el, description = 'qa is lazy', timeout = browser.params.userSleep.medium) {
        this.__ElementScrollIntoView(el);
        __ElementVisible(description, el, timeout);
        // expect(el.getAttribute('disabled')).toEqual('true');
        expect(el.isEnabled()).toBe(false);

    };






    this.__checkOnOff = function (el, description = 'qa is lazy', check_uncheck = true) {

        el.isSelected().then(function (checked) {

            if (checked) {
                if (check_uncheck)
                    __log('Checkbox: ' + description + ' already checked on!');
                else {
                    el.click().then(function (err) {
                        if (err) {
                            __log('fail: click on element <' + description + '>');
                            __log(err);
                        }
                        else {
                            __log('success: click on element <' + description + '>');

                        }
                    });
                }
            }
            else {
                if (!check_uncheck)
                    __log('Checkbox: ' + description + ' already checked off!');
                else {
                    el.click().then(function (err) {
                        if (err) {
                            __log('fail: click on element <' + description + '>');
                            __log(err);
                        }
                        else {
                            __log('success: click on element <' + description + '>');

                        }
                    });
                }
            }
        });
        browser.sleep(browser.params.actionDelay.step_delay);
        el.isSelected().then(function (checked) {
            expect('Checkbox: ' + description + ' Status: ' + checked).toBe('Checkbox: ' + description + ' Status: ' + check_uncheck);
        });
        browser.sleep(browser.params.actionDelay.step_delay * 10);
    };

    this.__isDropDownItemSelected_byGetAttribute = function (el, description = 'qa is lazy', expected) {
        el.getAttribute('value').then(function (txt) {
            expect('Dropdown: ' + description + ' Status: ' + txt).toBe('Dropdown: ' + description + ' Status: ' + expected);
        });
    };

    this.__isDropDownItemSelected_byGetText = function (el, description = 'qa is lazy', expected) {
        el.element(by.css('option:checked')).getText().then(function (txt) {
            expect('Dropdown: ' + description + ' Status: ' + txt).toBe('Dropdown: ' + description + ' Status: ' + expected);
        });
    };


};
module.exports = common_obj;

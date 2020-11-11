/**
 * Created by webber-ling on 6/2/2017.
 */
"use strict";

const ec = protractor.ExpectedConditions;
const util_windows = require('../common/utilities/util_windows');
const futil_windows = new util_windows();
const path = require('path');


const common_obj = function () {

    const __log = function (description) {
        console.log(description);
    };

    this.__log = function (description) {
        __log(description);
    };

    const __ElementPresent = function (description, element, timeout = browser.params.timeouts.obj_timeout) {
        browser.driver.wait(ec.presenceOf(element), timeout, 'Element <' + description + '> does NOT Present in <' + timeout + '> seconds');
    };

    this.__ElementPresent = (description, element, timeout = browser.params.timeouts.obj_timeout) => __ElementPresent(description, element, timeout)

    const __ElementVisible = function (description, element, timeout = browser.params.timeouts.obj_timeout) {
        browser.driver.wait(ec.visibilityOf(element), timeout, 'Element <' + description + '> does NOT visible in <' + timeout + '> seconds');
    };

    const __ElementClickable = function (description, element, timeout = browser.params.timeouts.obj_timeout) {
        browser.driver.wait(ec.elementToBeClickable(element), timeout, 'Element <' + description + '> does NOT clickable in <' + timeout + '> seconds');
    };

    this.__ElementScrollIntoView = function (element) {
        browser.executeScript('arguments[0].scrollIntoView();', element);
    };

    const __deleteText = function (description, element, bVerify = true) {

        element.clear().then(function (err) {
            if (err) {
                __log('fail: delete text from element <' + description + '>');
                __log(err);
            }
            else {
                __log('success: delete text from element <' + description + '>');
                if (bVerify)
                    expect(element.getAttribute('value')).toEqual('');
            }
        });

        //element.sendKeys(protractor.Key.BACK_SPACE);
        browser.sleep(browser.params.actionDelay.step_delay);

    };

    this.__deleteText = function (description, element, bVerify = true) {

        __ElementPresent(description, element);
        this.__ElementScrollIntoView(element);
        __ElementClickable(description, element);

        __deleteText(description, element, bVerify);

    };

    this.__deleteText_byKey = function (description, element, bVerify = true, iNum = 30) {

        element.sendKeys(protractor.Key.END);

        for (let i = 0; i < iNum; i++)
            element.sendKeys(protractor.Key.BACK_SPACE);

        if (bVerify)
            expect(element.getAttribute('value')).toEqual('');

        browser.sleep(browser.params.actionDelay.step_delay);
    };


    /**
     * Function:    __setText => set text to element
     * Parm_1:      web element to set test into
     * Parm_2:      the text value
     * Parm_3:      optional, delete exsiting value or not, default is false
     * Created by webber-ling on 6/2/2017.
     *
     */
    this.__setText = function (description, element, value, bDeleteExisting = true, bVerify = true, bScrollIntoView = true) {


        if (value.toString().length !== 0) {

            __ElementPresent(description, element);
            if (bScrollIntoView)
                this.__ElementScrollIntoView(element);
            __ElementClickable(description, element);


            if (value.toString() === '#del#') {
                __deleteText(description, element, bVerify);
            }
            else {
                if (bDeleteExisting) {
                    __deleteText(description, element, bVerify);
                }
                element.sendKeys(value).then(function (err) {
                    if (err) {
                        __log('fail: set text: <' + value + '> to element <' + description + '>');
                        __log(err);
                    }
                    else {
                        __log('success: set text: <' + value + '> to element <' + description + '>');
                        if (bVerify)
                            expect(element.getAttribute('value')).toEqual(value);
                    }
                });
            }

        }

        browser.sleep(browser.params.actionDelay.step_delay);

    };

    this.__click = function (description, element, xPos = 1, yPos = 1, bScrollIntoView = true) {


        __ElementPresent(description, element);
        if (bScrollIntoView)
            this.__ElementScrollIntoView(element);
        __ElementClickable(description, element);


        if (xPos === 1) {
            element.click().then(function (err) {
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
            browser.actions().mouseMove(element, {x: xPos, y: yPos}).click().perform().then(function () {
                __log('success: click on element <' + description + '> on X: ' + xPos + ', Y: ' + yPos);
            });
        }

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
    this.__selectByText = function (description, element, text, byOption=true) {

        if (text !== '') {
            __ElementPresent(description, element);
            this.__ElementScrollIntoView(element);
            __ElementClickable(description, element);

            if(byOption)
                this.__click(text, element.element(by.cssContainingText('option', text)));
            else
                this.__click(text, element.element(by.css('[value=' + text +']')));
        }
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

    this.__isElementDisplayedContainingText = function (el, text, description = 'qa is lazy', exactMatch = true, useAttribute = false) {

        __ElementVisible(description, el);
        expect(el.isDisplayed()).toBe(true);

        // if (exactMatch)
        //     expect(el.getText()).toMatch(text);
        // else
        //     expect(el.getText()).toContain(text);

        if (exactMatch) {
            if (useAttribute)
                expect(el.getAttribute('value')).toMatch(text);
            else
                expect(el.getText()).toMatch(text);
        }
        else {
            if (useAttribute)
                expect(el.getAttribute('value')).toContain(text);
            else
                expect(el.getText()).toContain(text);
        }
    };

    this.__isElementDisplayed = function (el, description = 'qa is lazy', timeout = browser.params.userSleep.medium) {

        __ElementVisible(description, el, timeout);
        expect(el.isDisplayed()).toBe(true);

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


    this.__wait4ElementInvisible = function (el, description = 'qa is lazy', iTimeOut = browser.params.timeouts.obj_timeout) {

        browser.wait(ec.invisibilityOf(el), iTimeOut).then(function () {
            console.log('..... wait for object invisible.....: ' + description);
        });

    };

    this.__wait4ElementVisible = function (el, description = 'qa is lazy', iTimeOut = browser.params.timeouts.obj_timeout) {

        browser.wait(ec.visibilityOf(el), iTimeOut).then(function () {
            console.log('..... wait for object visible.....: ' + description);
        });

    };

    this.__isCheckBoxChecked = function (el, description = 'qa is lazy', check_uncheck = true) {

        el.isSelected().then(function (checked) {
            expect('Checkbox: ' + description + ' Status: ' + checked).toBe('Checkbox: ' + description + ' Status: ' + check_uncheck);
        });

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

    this.__executeScript = function (el, description = 'qa is lazy', sType = 'qa is lazy', sValue = '') {


        __ElementPresent(description, el);
        // __ElementVisible(description, el);

        switch (sType) {
            case 'click':
                this.__ElementScrollIntoView(el);
                browser.executeScript('arguments[0].click();', el).then(function (txt) {
                    __log('Execute Script: ' + sType + 'on object: ' + description);
                });
                break;
            case 'setText':
                browser.executeScript(el + '.value=' + sValue).then(function (txt) {
                    __log('Execute Script: ' + sType + 'on object: ' + description + ' with value: ' + sValue);
                });
                break;
            default:
                throw new Error('Incorrect input Type name [' + sType + ']');
        }

        browser.sleep(browser.params.actionDelay.step_delay);
    }
};
module.exports = common_obj;

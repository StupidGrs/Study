const stringHelper = require('./string-helper.js');
const EC = protractor.ExpectedConditions;

const thisModule = {

  /**
     * Find element by CSS and wait for it presence within appropriate timeout.
     *
     * @param ms - waiting time in milliseconds
     * @param value
     * @returns {promise.Promise<any>}
     */
  getElementByCss: async function (value, ms = browser.params.timeout) {
    const elem = element(by.css(value));
    await browser.wait(protractor.ExpectedConditions.presenceOf(elem), ms, 'Wait for element appears');
    return elem;
  },

  /**
     * Find element by CSS and text and wait for it presence within appropriate timeout.
     *
     * @param ms - waiting time in milliseconds
     * @param css
     * @param text - string or RegExp() if using 'REGEXP:' construction
     * @returns {promise.Promise<any>}
     */
  getElementByCssContainingText: async function (css, text, ms = browser.params.timeout) {
    const elem = element(by.cssContainingText(css, text));
    await browser.wait(protractor.ExpectedConditions.presenceOf(elem), ms, 'Wait for element appears');
    return elem;
  },

  /**
     * Find element using indicated method By and wait for it presence within appropriate timeout.
     *
     * @param ms - waiting time in milliseconds
     * @param by
     *
     * @returns {promise.Promise<any>}
     */
  getElementBy: async function (by, ms = browser.params.timeout) {
    const elem = element(by);
    await browser.wait(protractor.ExpectedConditions.presenceOf(elem), ms, 'Wait for element appears');
    return elem;
  },

  /**
     * Verify that element is not only presented in DOM, but also has height and width.
     *
     * @param elem
     * @param ms - waiting time in milliseconds.
     * ms = browser.params.timeout by default, if it is not defined.
     * @returns {promise.Promise<boolean>}
     */
  isElementVisible: function (elem, ms = browser.params.timeout) {
    return browser.wait(protractor.ExpectedConditions.visibilityOf(elem), ms).then(() => true, () => false);
  },

  /**
     * Verify that element is not presented in DOM and has not height and width.
     *
     * @param elem
     * @param ms - waiting time in milliseconds.
     * ms = browser.params.timeout by default, if it is not defined.
     * @returns {promise.Promise<boolean>}
     */
  isElementNotVisible: function (elem, ms = browser.params.timeout) {
    return browser.wait(protractor.ExpectedConditions.invisibilityOf(elem), ms).then(() => true, () => false);
  },

  /**
     * Verify that element is selected.
     *
     * @param elem
     * @param ms - waiting time in milliseconds.
     * ms = browser.params.timeout by default, if it is not defined.
     * @returns {promise.Promise<boolean>}
     */
  isElementSelected: function (elem, ms = browser.params.timeout) {
    return browser.wait(protractor.ExpectedConditions.elementToBeSelected(elem), ms).then(() => true, () => false);
  },

  /**
     * Wait for element visibility within appropriate amount of seconds.
     *
     * @param elem
     * @param sec
     * @returns {promise.Promise<boolean|error>}
     */
  waitElementVisibility: function (elem, sec) {
    return thisModule.isElementVisible(elem, sec * 1000).then(function (isVisible) {
      if (!isVisible) {
        throw new Error(`Element did not appeared in ${sec} seconds`);
      }
    });
  },

  /**
   * Wait for element invisibility within appropriate amount of seconds.
   *
   * @param elem
   * @param sec
   * @returns {promise.Promise<boolean|error>}
   */
  waitElementInvisibility: function (elem, sec) {
    return thisModule.isElementNotVisible(elem, sec * 1000).then(function (isNotVisible) {
      if (!isNotVisible) {
        throw new Error(`Element did not disappeared in ${sec} second(s)`);
      }
    });
  },

  /**
     * Verify if horizontal scroll is existed for element.
     *
     * @param elem
     * @returns {boolean}
     */
  isHorizontalScrollExisted: function (elem) {
    return isHorizontalScroll(elem);
  },

  /**
     * Verify if horizontal scroll is not existed for element.
     *
     * @param elem
     * @returns {boolean}
     */
  isHorizontalScrollNotExisted: function (elem) {
    return isHorizontalScroll(elem).then((isScroll) => !isScroll);
  },

  /**
     * Click on element.
     *
     * If failed to click - try to scroll to element and click again.
     * If failed to click again - try to scroll to page top and click again.
     * If it is not element visibility issue - will fail with Element is not clickable error
     * @param elem
     * @returns {PromiseLike<T> | Promise<T>}
     */
  clickOnElement: function (elem) {
    if (browser.params.deviceType !== 'mobile') {
      let retryWithScrollToTop = function (error) {
        return scrollToTop()
          .then(() => elem.click());
      };
      let retryWithScrollToElementByLocation = function (error) {
        return scrollToElementByLocation(elem)
          .then(() => elem.click())
          .then(() => { }, retryWithScrollToTop);
      };

      return browser.wait(protractor.ExpectedConditions.elementToBeClickable(elem), browser.params.timeout, `${elem.locator()} is not clickable after ${browser.params.timeout} ms of wait`)
        .then(() => elem.click().then(() => { }, retryWithScrollToElementByLocation));
    } else {
      return browser.wait(protractor.ExpectedConditions.elementToBeClickable(elem), browser.params.timeout, `${elem.locator()} is not clickable after ${browser.params.timeout} ms of wait`).then(() => {
        return browser.executeScript('arguments[0].click();', elem);
      }).catch(exeption => {
        throw new Error(`Not able to click on ${elem.locator()} element`);
      });
    }
  },

  /**
     * Click on element if it exists.
     *
     * wait for Angular.
     * Verify if element is present on page.
     * If element is present - click.
     *
     * @param cssLocator
     * @param ms time to wait in ms
     * @returns {promise.Promise<any>}
     */
  clickIfExist: async function (cssLocator, ms = 3000) {
    const elem = $(cssLocator);

    try {
      await browser.wait(protractor.ExpectedConditions.visibilityOf(elem), ms);
      await thisModule.clickOnElement(elem);
    } catch (e) {
      // ignore error that element is not clickable at the point, other element would receive the click.
    }

    return;
  },

  /**
     * Click on element with text if it exists.
     *
     * wait for Angular.
     * Verify if element is present on page.
     * If element is present - click.
     *
     * @param cssLocator
     * @param text
     * @param ms time to wait in miliseconds
     * @returns {promise.Promise<any>}
     */
  clickOnElementWithTextIfExist: async function (cssLocator, text, ms = 3000) {
    const elem = element(by.cssContainingText(cssLocator, text));

    try {
      await browser.wait(protractor.ExpectedConditions.visibilityOf(elem), ms);
      await thisModule.clickOnElement(elem);
    } catch (e) {
      // ignore error that element is not clickable at the point, other element would receive the click.
    }

    return;
  },

  /**
     * Collect table content as JSON.
     *
     * @param table - element
     * @param cellCss - exact tag locator where cell text is stored.
     * Used for long tables where need to scroll right to see content.
     * getText() will take '' for invisible column content.
     * Using getAttribute('innerText') helps to get cell text for invisible columns without scrolling.
     * But we need exact tag locator where cell text is stored.
     */
  getTableContentAsJSON: async (table, cellCss) => {
    const headers = [];
    const actual = [];
    const visible = await thisModule.isElementVisible(table);
    if (visible) {
      const collection = await table.all(by.css('th')).asElementFinders_();

      for (let i = 0; i < collection.length; i++) {
        await collection[i].element(by.css('span')).getAttribute('innerText').then(attr => {
          headers[i] = attr.trim();
        }, error => {
          headers[i] = '';
        });
      }

      const newCollection = await table.all(by.css('tbody tr')).asElementFinders_();
      for (let i = 0; i < newCollection.length; i++) {
        const rowAsJson = {};
        const row = await newCollection[i].all(by.css('td')).asElementFinders_();
        for (let y = 0; y < row.length; y++) {
          try {
            let cellText = cellCss ? await row[y].element(by.css(cellCss)).getAttribute('innerText') : await row[y].getText();
            rowAsJson[headers[y]] = cellText.trim();
          } catch (e) {
            rowAsJson[headers[y]] = '';
          }
        }
        actual.push(rowAsJson);
      }
      return actual;
    } else {
      throw new Error('Table is not visible');
    }
  },

  /**
     * Collect element texts as [['text1'],['text2'],['text3']] array.
     * Mostly for using with cucumber table.row()
     * @param locator
     * @return {Promise<Array<String>>}
     */
  getElementTexts: async function (locator) {
    const result = [];
    const collection = await $$(locator).asElementFinders_();

    for (let element of collection) {
      const newItem = Array.of(await element.getText());
      // create two-dimensional array
      result.push(newItem);
    }

    return result;
  },

  /**
     * return Elements count by css
     * @param locator
     * @return {Promise<Integer>}
     */
  getElementsCount: async function (locator) {
    const collection = await $$(locator).asElementFinders_();
    return collection.length;
  },

  /** Scrolling according to direction
     *
     * @param direction - may have 2 values top|bottom
     * @returns {promise.Promise<any>}
     */
  scrollTo: function (direction = 'bottom') {
    if (direction === 'bottom') {
      return scrollToBottom();
    }

    return scrollToTop();
  },

  /** verify if element has any text
     *
     * @param cssLocator - css selector
     * @returns {promise.Promise<boolean>}
     */
  isElementHasText: async function (cssLocator) {
    const elem = await thisModule.getElementByCss(cssLocator);
    return elem.getTagName().then(tagName => {
      // inputs don't have text, only value
      if (tagName === 'input' || tagName === 'select') {
        return elem.getAttribute('value');
      }

      return elem.getText();
    }).then(value => {
      // Regexp /^(?!\s*$).+/ - means a Non-blank/non-whitespace string
      // !! - convert value to boolean
      return !!value.match(/^(?!\s*$).+/);
    });
  },

  /** clear text from element
     *
     * @param cssLocator - css selector
     * @returns {promise.Promise<void>}
     */
  clearTextFromElement: async function (cssLocator) {
    // webdriver clear() doesn't update angular forms: https://github.com/angular/protractor/issues/301
    const element = await thisModule.getElementByCss(cssLocator);
    const ctrlA = protractor.Key.chord(protractor.Key.CONTROL, 'a');
    await element.sendKeys(ctrlA);

    return element.sendKeys(protractor.Key.BACK_SPACE);
  },

  getNextElementAfterParentWithText: async (parentElementCss, parentText, nextElementCss) => {
    return (await thisModule.getElementByCssContainingText(parentElementCss, parentText)).element(by.xpath('following-sibling::' + nextElementCss));
  },

  getNextElementAfterParent: async (parentElementCss, nextElementCss) => {
    return (await thisModule.getElementByCss(parentElementCss)).element(by.xpath('following-sibling::' + nextElementCss));
  },

  /**
   * one helper for almost all Expected Conditions
   * @param element - element that will be expected
   * @param {String} validation - String value with type of validation
   * @param {boolean} positiveValue - boolean flag that is telling ECHelper that it should return positive of negative value (by default is equal to true)
   */
  ECHelper: (element, validation, positiveValue = true) => {
    switch (validation) {
      case 'present': return positiveValue === false ? EC.not(EC.presenceOf(element)) : EC.presenceOf(element);
      case 'clickable': return positiveValue === false ? EC.not(EC.elementToBeClickable(element)) : EC.elementToBeClickable(element);
      case 'visible': return positiveValue === false ? EC.not(EC.visibilityOf(element)) : EC.visibilityOf(element);
      case 'invisible': return positiveValue === false ? EC.not(EC.invisibilityOf(element)) : EC.invisibilityOf(element);
      case 'selected': return positiveValue === false ? EC.not(EC.elementToBeSelected(element)) : EC.elementToBeSelected(element);
      case 'gone': return positiveValue === false ? EC.not(EC.stalenessOf(element)) : EC.stalenessOf(element); // not in DOM
      case 'enabled': return EC.elementToBeClickable(element);
      case 'disabled': return EC.not(EC.elementToBeClickable(element));
      default: throw new Error('Wrong expected condition provided');
    }
  }
};

/**
 * Scroll to element by it's location.
 *
 * @param elem
 * @returns {promise.Promise<any>}
 */
function scrollToElementByLocation(elem) {
  return elem.getLocation().then(function (location) {
    return browser.executeScript('window.scrollTo(0,' + (location.y) + ')');
  });
}

/**
 * Scroll to top of the page.
 *
 * @returns {promise.Promise<any>}
 */
function scrollToTop() {
  return browser.executeScript('window.scrollTo(0, 0)');
}

/**
 * Scroll to the bottom of the page.
 *
 * @returns {promise.Promise<any>}
 */
function scrollToBottom() {
  return browser.executeScript('window.scrollTo(0, 100000)');
}

/**
 * Check if element scrollWidth more than element clientWidth.
 * The scrollWidth property returns the entire width of an element in pixels.
 * The clientWidth property returns the viewable width of an element in pixels.
 *
 * @param elem
 * @returns {promise.Promise<T>|promise.Promise<any>}
 */
function isHorizontalScroll(elem) {
  return browser.executeScript(function (el) {
    return el.scrollWidth > el.clientWidth;
  }, elem);
}

module.exports = thisModule;
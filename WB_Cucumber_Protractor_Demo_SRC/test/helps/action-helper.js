const EC = protractor.ExpectedConditions;
const elementHelper = require('./element-helper');

/**
  * Click on element until it visible or until element with given text will become visible
  *
  * @param locator
  * @param elementWithTextLocator
  * @param text
  * @param waitForSeconds
  * @return {PromiseLike<T>|Promise<T>}
  */
 const clickButtonUntilNotDisplayed = (locator, elementWithTextLocator, text, waitForSeconds = 2000) => {
  const elementToClick = element(by.css(locator));

  if (elementWithTextLocator) {
      const elementWithText = element(by.cssContainingText(elementWithTextLocator, text));
      return browser.wait(EC.visibilityOf(elementWithText), waitForSeconds).catch((err) => {
          return elementHelper.clickOnElement(elementToClick).then(() => {
              return clickButtonUntilNotDisplayed(locator, elementWithTextLocator, text);
          }).catch((err) => {
              console.log(`No more elements with ${locator} css selector.`);
          });
      });
  } else {
      return browser.wait(EC.visibilityOf(elementToClick), waitForSeconds).then((visibleOrNot) => {
          return elementHelper.clickOnElement(elementToClick);
      }).then(() => {
          return clickButtonUntilNotDisplayed(locator);
      }).catch((err) => {
          console.log(`No more elements with ${locator} css selector.`);
      });
  }
};

module.exports = {
  /**
   * Retry to execute an action a specified number of times.
   *
   * @param action
   * @param numOfTries
   * @return {PromiseLike<T>|Promise<T>}
   */
  retryIfNeeded: function (action, numOfTries) {
    let times = 0;
    let retry = function (error) {
      if (times < numOfTries) {
        times++;
        console.log(`Retrying action, that have failed with ${error.name} ${error.message}`);
        return action().then(null, retry);
      } else {
        throw new Error(`Still failing after ${numOfTries} times of retry due to ${error.name} ${error.message}`);
      }
    };
    return action().then(null, retry);
  },
  clickButtonUntilNotDisplayed
};
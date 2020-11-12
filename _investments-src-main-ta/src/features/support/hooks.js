/**
 * Multiple Before hooks are executed in the order that they were defined.
 * Multiple After hooks are executed in the reverse order that they were defined.
 */
const fs = require('fs');
const path = require('path');
const { Before, After, Status } = require('cucumber');
const { endpointHelper, fileHelper } = require('ngpd-merceros-testautomation-ta');
const remote = require('selenium-webdriver/remote');
const baseUrl_BE = require('../../data/api/dbDataAccess').baseUrl_BE;
const logsUtils = require('../../utils/logs-util');

/** Switch off wait for angular before each test.
 * Since browser restarts between tests, this step could not be moved to onPrepare().
 * onPrepare() runs once for session.
 */
Before(function () {
  return browser.waitForAngularEnabled(false);
});


Before(function () {
  return browser.setFileDetector(new remote.FileDetector());
});

// hook to enable file download in headless mode for chrome browser
Before(function () {
  /* eslint-disable-next-line */
  return browser.getCapabilities().then(caps => {
    return browser.getProcessedConfig().then(config => {
      if (caps.get('browserName') === 'chrome') {
        return browser.getSession().then(function (session) {
          const params = {
            cmd: 'Page.setDownloadBehavior',
            params: { behavior: 'allow', downloadPath: browser.params.basePath }
          };
          /* eslint-disable-next-line */
          return endpointHelper.sendRequest('POST', `${config.seleniumAddress}/session/${session.id_}/chromium/send_command`, JSON.stringify(params));
        });
      }
    });
  });
});


// https://github.com/cucumber/cucumber-js/blob/master/docs/support_files/attachments.md
/* eslint-disable-next-line */
After(function (testCase) {
  const world = this;
  if (testCase.result.status === Status.FAILED) {
    // return browser.executeScript(function () {
    //     return {
    //       width: document.body.clientWidth,
    //       height: document.body.clientHeight
    //     };
    //   }).then(function (result) {
    //     return browser.driver.manage().window().setSize(result.width, result.height).then(function () {
    return browser.takeScreenshot().then(function (screenShot) {
      // screenShot is a base-64 encoded PNG
      return world.attach(screenShot, 'image/png');
    });
    //   });
    // });
  };
});

//hook to attach log messages to a report in the Cucumber plugin without encoding problems
After(function (testCase) {
  const world = this;
  return browser.getCapabilities().then(caps => {
    if (caps.get('browserName') === 'chrome') {
      if (testCase.result.status === Status.FAILED) {
        return logsUtils.writeConsoleLogs(world, testCase);
      };
    };
  });
});

//hook to attach network log messages to a report in the Cucumber plugin without encoding problems
After(function (testCase) {
  const world = this;
  return browser.getCapabilities().then(caps => {
    if (caps.get('browserName') === 'chrome') {
      if (testCase.result.status === Status.FAILED) {
          return logsUtils.writeNetworkLogs(world, testCase);
      };
    };
  });
});

// Clean base directory if it exists and not empty
After(function () {
  return fileHelper.removeDirectory(browser.params.basePath);
});

//disable hook, because it breaks IE in sauceLabs
// Clean Cookies
// After(async () => {
//   await browser.manage().deleteAllCookies();

//   return;
// });
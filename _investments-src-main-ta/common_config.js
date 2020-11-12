/* eslint-disable no-console */
const os = require('os');                   // this is the standard Node.js operating system API
const fs = require('fs');                   // this is the standard Node.js filesystem API
const fsExtra = require('fs-extra');        // like fs but adds more functionality
const path = require('path');               // this is the standard Node.js filepath API
const yargs = require("yargs").argv;

const TEST_FOLDER_NAME = 'test' + path.sep + new Date().getTime();
const downloadDir = `${os.homedir() + path.sep + TEST_FOLDER_NAME}`;

/*
  without setting the following deleteReportsFolderOnEachTestRun = true the report generated for reports run locally
  can be a potentially confusing mix of old and new results

  if the project preference is - to quote Anton Klimkovich (Exadel) - "to run\debug tests one by one and after all
  [are run we] can send a report that all is done" and to control the deletions in the reports folder manually then
  please set the deleteReportsFolderOnEachTestRun = false (note that if set to true there would be a need to "rerun
  all tests again [if only some fail] to generate a [full] report")
 */
const reportsFolder = path.join(process.cwd(), 'reports');
const deleteReportsFolderOnEachTestRun = true;      // false will mean report folder must be managed manually

const failedScreenshots_tempFileName = path.join(process.cwd(), 'failedScreenshots.txt');
const failedScreenshots_json = 'failedScreenshots.json';
const DELIMITER = '===DELIMITER===';
const SCREENSHOTS_DIRNAME = 'screenshots'; // relative to feature dir
const SHARD_TEST_FILES = (process.env.MAX_INSTANCES || yargs.instances) || false;
const MAX_INSTANCES = process.env.MAX_INSTANCES ? process.env.MAX_INSTANCES : (yargs.instances || 1);

const environment = process.env.TEST_ENV ? process.env.TEST_ENV : (yargs.TEST_ENV || 'LOCAL');

let deviceType;
let osPlatformName;

switch (os.platform()) {
  case 'win32':
    osPlatformName = 'windows';
    deviceType = 'Mercer PC';
    break;
  case 'linux':
    osPlatformName = 'linux';
    deviceType = 'Linux PC';
    break;
  default:
    // assumption
    osPlatformName = 'osx';
    deviceType = 'Mac';
};

exports.chromeCapabilities = {
  browserName: 'chrome',
  loggingPrefs: {
    performance: 'ALL',
    browser: 'ALL'
  },
  chromeOptions: {
    args: ['disable-infobars', 'disable-gpu',
      //'start-maximized',
      'window-size=1920,2500',
      'test-type=browser', 'disable-notifications',
      'incognito',
      'disable-application-cache',
      'disable-dev-shm-usage',
      'no-sandbox',
      // 'headless',
      'disable-browser-side-navigation',
    ],
    perfLoggingPrefs: {
      'enableNetwork': true
    },
    w3c: false,
    useAutomationExtension: false,
    // Set download path and avoid prompting for download even though
    // this is already the default on Chrome but for completeness
    prefs: {
      'plugins.always_open_pdf_externally': true,
      download: {
        prompt_for_download: false,
        default_directory: downloadDir,
        directory_upgrade: true,
        // Disable Chrome's annoying password manager
        'profile.password_manager_enabled': false,
        credentials_enable_service: false,
        password_manager_enabled: false
      }
    }
  },
  // set metadata for Cucumber HTML report
  metadata: {
    device: deviceType,
    platform: {
      name: osPlatformName,
      version: os.release()
    }
  },
  // allows different specs to run in parallel.
  // If this is set to be true, specs will be sharded by file
  // (i.e. all files to be run by this set of capabilities will run in parallel).
  // Default is false.
  shardTestFiles: SHARD_TEST_FILES,

  // Maximum number of browser instances that can run in parallel for this
  // set of capabilities. This is only needed if shardTestFiles is true.
  // Default is 1.
  maxInstances: MAX_INSTANCES,
};

exports.firefoxCapabilities = {
  "acceptInsecureCerts": true,
  browserName: 'firefox',
  'moz:webdriverClick': false,
  'moz:firefoxOptions': {
    'args': ['-safe-mode', '-private'],
    'prefs': {
      'browser.download.folderList': 2,
      'browser.download.dir': downloadDir,
      'browser.download.useDownloadDir': true,
      'browser.download.manager.showWhenStarting': false,
      'browser.helperApps.neverAsk.saveToDisk': 'application/pdf, application/postscript, ' +
        'application/msword, application/wordperfect, application/rtf, ' +
        'application/vnd.ms-excel, application/vnd.ms-powerpoint, text/html, ' +
        'text/plain, application/x-troff, application/x-troff-man, application/x-dvi, ' +
        'application/mathematica, application/octet-stream'
    },
    'log': { 'level': 'error' }
  },
  // set metadata for Cucumber HTML report
  metadata: {
    device: deviceType,
    platform: {
      name: osPlatformName,
      version: os.release()
    }
  },
  // allows different specs to run in parallel.
  // If this is set to be true, specs will be sharded by file
  // (i.e. all files to be run by this set of capabilities will run in parallel).
  // Default is false.
  shardTestFiles: SHARD_TEST_FILES,

  // Maximum number of browser instances that can run in parallel for this
  // set of capabilities. This is only needed if shardTestFiles is true.
  // Default is 1.
  maxInstances: MAX_INSTANCES,
};

exports.ieCapabilities = {
  'browserName': 'internet explorer',
  "se:ieOptions": {
    "ignoreProtectedModeSettings": true,
    "ie.ensureCleanSession": true,
    "ie.browserCommandLineSwitches": "-private",
    "ie.forceCreateProcessApi": true,
    'ignoreZoomSetting': true,
    "ie.forceCreateProcessApi": true,
    "nativeEvents": false,
    "requireWindowFocus": true
  },
  "unhandledPromptBehavior": "accept",
  shardTestFiles: SHARD_TEST_FILES,
  maxInstances: MAX_INSTANCES,
  // set metadata for Cucumber HTML report
  metadata: {
    device: deviceType,
    platform: {
      name: osPlatformName,
      version: os.release()
    }
  },
};

exports.edgeCapabilities = {
  browserName: 'MicrosoftEdge',
  platform: 'Windows 10',
  version: 'latest',
  log: { level: 'error' },
  "EdgeOptions": {
    'ms:inPrivate': true,
  },
  shardTestFiles: SHARD_TEST_FILES,
  maxInstances: MAX_INSTANCES,
  // set metadata for Cucumber HTML report
  metadata: {
    device: deviceType,
    platform: {
      name: osPlatformName,
      version: os.release()
    }
  },
};

//const chromeDriverPath = process.platform === 'win32' ? 'node_modules/protractor/node_modules/webdriver-manager/selenium/chromedriver_74.0.3729.6.exe' : '/data/app/thirdparty-bin/chromedriver'

exports.common_config = {


  // directConnect: true,
  // chromeDriver: chromeDriverPath,
  seleniumAddress: 'http://127.0.0.1:4444/wd/hub',
  getPageTimeout: 60000, // 60 sec
  // allScriptsTimeout: 60000, // 60 seconds
  ignoreUncaughtExceptions: true, // This allows cucumber to handle the exception and record it appropriately.
  framework: 'custom',
  // path relative to the current config file
  frameworkPath: require.resolve('protractor-cucumber-framework'),
  restartBrowserBetweenTests: true,
  baseURL: '',
  beforeLaunch() {
    //cleanup.cleanUpTestData();

    if (deleteReportsFolderOnEachTestRun) {
      /*
        create the reports folder (deleting and re-creating the entire report folder if it already exists)
 
        note the protractor-multiple-cucumber-html-reporter-plugin NPM package used to create Cucumber HTML reports
        for local runs cannot delete all of the existing report data even if the removeOriginalJsonReportFile and
        removeExistingJsonReportFile options are set to true if the number of specs run is less than the previous
        executions
 
        reference: https://github.com/wswebcreation/protractor-multiple-cucumber-html-reporter-plugin/issues/13
       */
      if (fs.existsSync(reportsFolder)) {
        fsExtra.removeSync(reportsFolder);
      }

      fs.mkdirSync(reportsFolder);
    } else if (!fs.existsSync(reportsFolder)) {
      // create folder for reports if it doesn't exist
      fs.mkdirSync(reportsFolder);
    }

    // remove failed screenshots info on start
    if (fs.existsSync(failedScreenshots_tempFileName)) {
      fs.unlinkSync(failedScreenshots_tempFileName);
    }
  },

  afterLaunch() {
    // convert txt to json
    if (fs.existsSync(failedScreenshots_tempFileName)) {
      const filesToReplace = fs
        .readFileSync(failedScreenshots_tempFileName, 'utf8')
        .split(DELIMITER)
        .filter(el => el)
        .map(el => JSON.parse(el))
        .reduce((jsonObject, screenshot) => {
          jsonObject.screenshots.push(screenshot);

          return jsonObject;
        }, { screenshots: [] });

      fs.writeFileSync(failedScreenshots_json, JSON.stringify(filesToReplace, null, 2));
      fs.unlinkSync(failedScreenshots_tempFileName);
    }
  },

  onPrepare() {

          console.log('------------ webber: onPrepare ');

    // enable soft asserts
    const testCaseRunner = require('cucumber/lib/runtime/test_case_runner');
    const status = require('./node_modules/cucumber/lib/status').default;

    testCaseRunner.default.prototype.isSkippingSteps = function isSkippingSteps() {
      if (this.result.status === status.FAILED) {
        return !this.result.exception.softAssert;
      }

      return this.result.status !== status.PASSED;
    };

    // variable for creating and working with unique string values during one session
    // fs.readFile('storage.json', (err, data) => {
    //   if (err) {
    //     global.uniqueMap = {};
    //     return;
    //   }
    //   global.uniqueMap = JSON.parse(data);
    // });

    // Disable animations so e2e tests run more quickly
    const disableNgAnimate = function () {
      angular.module('disableNgAnimate', []).run(['$animate', function ($animate) {
        $animate.enabled(false);
      }]);
    };

    browser.addMockModule('disableNgAnimate', disableNgAnimate);
  },

  // Don't use pretty format when run tests in parallel.
  cucumberOpts: {
    require: [
      'src/features/step-definitions/*.js',
      '../node_modules/ngpd-merceros-testautomation-ta/step-definitions/*.js',
      '../node_modules/ngpd-merceros-testautomation-ta/support/hooks.js',
      'src/features/support/hooks.js'
    ],
    keepAlive: false,
    format: [
      'json:reports/results.json',
      'progress'
    ],
    strict: true,
      tags: [`${yargs.tag || "not @ignore"}`],
  },

  onComplete() {
    //return cleanup.cleanUpTestData().then((result) => {
    // fs.writeFile('storage.json', JSON.stringify(uniqueMap), 'utf8', (err) => {
    //   if (err) throw err;
    //   console.log('The storage.json file has been saved!');
    // });
    //});

    // browser.quit();

      console.log('------------ webber: onComplete ');
  },

  params: {
    timeout: 10000,
    env: environment,
    // Used for library tests and for localization
    language: process.env.LOCALIZATION || 'EN',
    basePath: downloadDir,
    fileDownloadGlobalWait: 300000, // 5 min
    DELIMITER,
    SCREENSHOTS_DIRNAME,
    failedScreenshots_tempFileName,
    failedScreenshots_json
    // definedParameterTypes: require('./features/support/parameter-types.js')
  },
  plugins: [{
    'package': 'protractor-multiple-cucumber-html-reporter-plugin',
    options: {
      // set options for Cucumber HTML report - please refer to:
      // https://www.npmjs.com/package/protractor-multiple-cucumber-html-reporter-plugin#options
      pageTitle: 'Test Automation Report',
      reportName: 'Test Automation Report',
      automaticallyGenerateReport: true,
      removeExistingJsonReportFile: false,   // please note reports folder is deleted anyway before each test run
      removeOriginalJsonReportFile: false,
      openReportInBrowser: true,
      displayDuration: true,
      durationInMS: false
    }
  }]
};

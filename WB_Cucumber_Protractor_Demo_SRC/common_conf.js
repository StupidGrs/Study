
const os = require('os');                   // this is the standard Node.js operating system API
const fs = require('fs');                   // this is the standard Node.js filesystem API
const fsExtra = require('fs-extra');        // like fs but adds more functionality
const path = require('path');               // this is the standard Node.js filepath API
const yargs = require("yargs").argv;


const TEST_FOLDER_NAME = 'test' + path.sep + new Date().getTime();
const downloadDir = `${os.homedir() + path.sep + TEST_FOLDER_NAME}`;

const reportsFolder = path.join(process.cwd(), 'reports');
const deleteReportsFolderOnEachTestRun = true;      // false will mean report folder must be managed manually

const failedScreenshots_tempFileName = path.join(process.cwd(), 'failedScreenshots.txt');
const failedScreenshots_json = 'failedScreenshots.json';
const DELIMITER = '===DELIMITER===';
const SCREENSHOTS_DIRNAME = 'screenshots'; // relative to feature dir
const SHARD_TEST_FILES = false;
const MAX_INSTANCES = 1;

const environment = process.env.TEST_ENV ? process.env.TEST_ENV : (yargs.TEST_ENV || 'DEV');


let deviceType;
let osPlatformName;

switch (os.platform()) {
    case 'win32':
        osPlatformName = 'windows';
        deviceType = 'My Testing PC';
        break;
    case 'linux':
        osPlatformName = 'linux';
        deviceType = 'Linux PC';
        break;
    default:
        // assumption
        osPlatformName = 'osx';
        deviceType = 'Mac';
}

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


exports.chromeCapabilities = {

    browserName: 'chrome',

    chromeOptions: {
        args: ['--disable-extensions',
            '--start-maximized',
            // "--incognito",
            'disable-infobars',
            'disable-gpu',
            'start-maximized',
            'window-size=1920,2500',
            'test-type=browser', 'disable-notifications',
            'incognito',
            'disable-application-cache',
            'disable-dev-shm-usage',
            'no-sandbox',
            // 'headless',
            'disable-browser-side-navigation',
        ],
        // perfLoggingPrefs: {
        //     'enableNetwork': true
        // },
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
        },
        useAutomationExtension: false,
        w3c: false,
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

exports.common_conf = {




    getPageTimeout: 60000,
    allScriptsTimeout: 500000,
    framework: 'custom',
    // path relative to the current config file
    frameworkPath: require.resolve('protractor-cucumber-framework'),



    baseURL: 'http://localhost:8080/',

    params: {
        // timeout: 10000,
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

    beforeLaunch() {
        //cleanup.cleanUpTestData();

        console.log('------------ webber: beforeLaunch ');
        console.log('*** downloadDir ****' + downloadDir);

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

    cucumberOpts: {
        require: ['./test/e2e/step_definitions/*.js',
            './test/support/hooks.js'],

        tags: false,
        format: [
            'json:reports/results.json',
            'progress'
        ],
        strict: true,
        profile: false,
        'no-source': true
    },

    plugins: [{
        'package': require.resolve('protractor-multiple-cucumber-html-reporter-plugin'),
        options: {
            // set options for Cucumber HTML report - please refer to:
            // https://www.npmjs.com/package/protractor-multiple-cucumber-html-reporter-plugin#options

            // automaticallyGenerateReport: true,
            // removeExistingJsonReportFile: true,

            pageTitle: 'Test Automation Report',
            reportName: 'Test Automation Report',
            automaticallyGenerateReport: true,
            // removeExistingJsonReportFile: false,   // please note reports folder is deleted anyway before each test run
            // removeOriginalJsonReportFile: false,
            openReportInBrowser: true,
            displayDuration: true,
            durationInMS: false
        }
    }],

};

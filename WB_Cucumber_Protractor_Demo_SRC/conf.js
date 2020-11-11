/**
 * Created by webber-ling on 28/09/2020.
 */


const { common_conf, chromeCapabilities, ieCapabilities, firefoxCapabilities, edgeCapabilities } = require('./common_conf');
const yargs = require("yargs").argv;
const BROWSER = process.env.BROWSER_NAME ? process.env.BROWSER_NAME : (yargs.BROWSER_NAME || 'chrome');
const environment = process.env.TEST_ENV ? process.env.TEST_ENV : (yargs.TEST_ENV || 'DEV');

let capability;
//const timeOut24h = 24 * 60 * 60000;

// const BROWSER = 'chrome';
switch (BROWSER) {
    case "chrome":
        capability = { ...chromeCapabilities };
        //capability['max-duration'] = timeOut24h;
        //capability['command-timeout'] = timeOut24h;
        break;
    case "internet explorer":
        capability = { ...ieCapabilities };
        break;
    case "firefox":
        capability = { ...firefoxCapabilities };
        break;
    case "MicrosoftEdge":
        capability = { ...edgeCapabilities };
        break;
    default:
        capability = { ...chromeCapabilities };
        break;
}

let url_under_test;
switch (environment) {
    case "DEV":
        url_under_test = 'https://src.us-east-1.dev.awsapp.mercer.com';
        break;
    case "STAGE":
        url_under_test = 'https://src.us-east-1.stage.awsapp.mercer.com';
        break;
    default:
        url_under_test = 'https://src.us-east-1.dev.awsapp.mercer.com';
        break;
}


exports.config = Object.assign({}, common_conf, {
    capabilities: Object.assign(capability),

    params: {

        url_test: url_under_test,

        env: {
            hostname: 'https://src.us-east-1.stage.awsapp.mercer.com' // Whatever the address of your app is
        },


        timeouts: {
            page_timeout: 60000,
            obj_timeout: 10000,
            job_timeout: 10000,
        },
        actionDelay: {
            step_delay: 100,
        },
        userSleep: {
            short: 1000,
            medium: 5000,
            long10: 10000,
            long20: 20000,
            long30: 30000,
        },




    },


    ///// 2020-09-28 WB: need to enable seleniumAddress and start webdriver manually if run scripts: npm run ***
    /////                if run by protractor conf.js, can comment seleniumAddress to let it automatically launch chrome
    seleniumAddress: 'http://127.0.0.1:4444/wd/hub',

    localSeleniumStandaloneOpts: {
        // jvmArgs : ["-Dwebdriver.ie.driver=./driver/IEDriverServer_32.exe"] // e.g: "node_modules/protractor/node_modules/webdriver-manager/selenium/IEDriverServer_x64_X.XX.X.exe"
        // jvmArgs: ["-Dwebdriver.edge.driver=./driver/MicrosoftWebDriver_win1809.exe"],
        // jvmArgs: ["-Dwebdriver.chrome.driver=./driver/chromedriver.exe"],
        // jvmArgs: ["-Dwebdriver.chrome.driver=./driver/chromedriver_77.0.3865.40.exe"],
    },

    // Spec patterns are relative to this directory.
    specs: [
        './test/e2e/features/NavigationTest.feature',
        './test/e2e/features/Publish.feature',
    ],
    suites: {

        navi: [
            './test/e2e/features/NavigationTest.feature',
        ],
        publish: [
            './test/e2e/features/Publish.feature',
        ],

    },

    // using spread operator to copy tags in cucumberOptions

    // cucumberOpts: { ...common_conf.cucumberOpts, tags: [`${yargs.tag || '@smoke and not @ignore'}`]} // WB: config for smoke test
    // cucumberOpts: { ...common_conf.cucumberOpts}

});
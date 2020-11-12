/**
 * Created by webber-ling on 5/18/2017.
 */
"use strict";

const DescribeFailureReporter = require('protractor-stop-describe-on-failure');
const screenshots = require('protractor-take-screenshots-on-demand');
const glob = require("glob");
const fs = require("fs");
const path = require('path');
const HtmlScreenshotReporter = require('protractor-jasmine2-html-reporter');
const reporter = new HtmlScreenshotReporter({
    // cleanDestination: true,
    // showSummary: true,
    // showConfiguration: true,
    // reportTitle: "SRC Test Automation - Protractor/Jamine Reports",
    // dest: path.resolve(__dirname, '../../reports'),
    // filename: 'Automation_Report.html',
    // ignoreSkippedSpecs: false,
    // reportOnlyFailedSpecs: false,
    // captureOnlyFailedSpecs: true,

    fileName: 'SRC_Automation_Reports',
    consolidate: false,
    consolidateAll: false,

    takeScreenshots: true,
    takeScreenshotsOnlyOnFailures: true,
    fixedScreenshotName: true,
    cleanDestination: true,


});


exports.config = {
    params: {

        url: {
            dev: 'https://src.us-east-1.dev.awsapp.mercer.com',
            aws_dev: 'https://src.us-east-1.dev.awsapp.mercer.com',
            stage: 'https://src.us-east-1.stage.awsapp.mercer.com',
            aws_stage: 'https://src.us-east-1.stage.awsapp.mercer.com',

            url_test: 'https://src.us-east-1.dev.awsapp.mercer.com',
            // url_test: 'https://src.us-east-1.stage.awsapp.mercer.com',
        },

        url_strapi: {
            dev: 'https://strapi.src.us-east-1.dev.int.mercer.com/admin',
            dev_username: 'MercerAdmin',
            dev_password: 'Welcome1!',

            stage: 'https://strapi.src.us-east-1.stage.int.mercer.com/admin',
            stage_username: 'MercerAdmin',
            stage_password: 'Welcome1!',


            // url_test: 'https://strapi.src.us-east-1.dev.int.mercer.com/admin',
            url_test: 'https://strapi.src.us-east-1.stage.int.mercer.com/admin',
            username: 'MercerAdmin',
            password: 'Welcome1!',

        },

        login: {
            login_email_test: 'webber.ling@mercer.com',
            login_globAdmin: 'glob.admin@src.mercer.com',
            login_compAdmin: 'comp.admin@src.mercer.com',
            login_compAuthor: 'comp.author@src.mercer.com',
            login_Mercer_userEmail: 'lin.li3@mercer.com',
            login_Mercer_userID: '878301',
            login_Mercer_userPassword: 'Shanghai33',
        },

        uploadFile: {
            excel: './data/in/Test_Excel_xlsx.xlsx',
            excel_name: 'Test_Excel_xlsx.xlsx',
            ppt: './data/in/Test_PPT_ppt.ppt',
            ppt_name: 'Test_PPT_ppt.ppt',
            pdf: './data/in/Test_PDF.pdf',
            pdf_name: 'Test_PDF.pdf',
            word: './data/in/Test_Word.docx',
            word_name: 'Test_Word.docx',
            csv: './data/in/Test_CSV.csv',
            csv_name: 'Test_CSV.csv',
        },

        uploadImage: {
            jpg: './data/in/Test_Image.jpg',
        },

        timeouts: {
            page_timeout: 300000,
            obj_timeout: 60000,
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


    /*
     to run a suite use --suite [suite name]
     e.g. protractor conf_html2.js --suite=demo
     without suite defined all specs except those in the [exclude] section will be run
     e.g. protractor conf_html2.js
     */

    specs: ['./features/*spec.js'],
    suites: {
        fixing: [
            // './features/regression/login_onboarding.feature.js',
            './features/fix_existing/createEventPage_removeUploadedImage.js',
        ],

        testData: [
            './features/regression/testData.js',

        ],
        debug: [
            './features/regression/debug.js',
            // './features/regression/lotsOfArticles_DraftMissing.js',
        ],
        samples: [
            './features/regression/samples.js',

        ],

        common: [
            // './features/regression/Common/checkSRCWebsitePage.js',
            // './features/regression/Common/forgotPassword.js',
            // './features/regression/Common/wrongEmailOrPassword.js',
        ],

        story_2402_2403: [
            './features/story/SRC-2402-2403/uploadDiffDocTypesOnDiffResearchPage.js',
            './features/story/SRC-2402-2403/uploadDiffDocTypesOnDiffNewsPage.js',

            './features/story/SRC-2402-2403/uploadDiffDocTypesOnPublishResearchPage.js',
            './features/story/SRC-2402-2403/uploadDiffDocTypesOnPublishNewsPage.js',
            './features/story/SRC-2402-2403/uploadDiffDocTypesOnDraftResearchPage.js',
            './features/story/SRC-2402-2403/uploadDiffDocTypesOnDraftNewsPage.js',
            './features/story/SRC-2402-2403/uploadDiffDocTypesOnRejectedResearchPage.js',
            './features/story/SRC-2402-2403/uploadDiffDocTypesOnRejectedNewsPage.js',
        ],

        story_2513: [
            './features/story/SRC-2513/mercerAdminCheckInternalOnly_Login.js',

            './features/story/SRC-2513/mercerAdminCheckInternalOnly_Event_Publish.js',
            './features/story/SRC-2513/mercerAdminCheckInternalOnly_Event_Draft.js',
            './features/story/SRC-2513/mercerAdminCheckInternalOnly_Event_Moderate.js',
            './features/story/SRC-2513/mercerAdminCheckInternalOnly_News_Publish.js',
            './features/story/SRC-2513/mercerAdminCheckInternalOnly_News_Draft.js',
            './features/story/SRC-2513/mercerAdminCheckInternalOnly_News_Moderate.js',
            './features/story/SRC-2513/mercerAdminCheckInternalOnly_Research_Publish.js',
            './features/story/SRC-2513/mercerAdminCheckInternalOnly_Research_Draft.js',
            './features/story/SRC-2513/mercerAdminCheckInternalOnly_Research_Moderate.js',
            './features/story/SRC-2513/externalUserCheckInternalOnly_Event.js',
            './features/story/SRC-2513/externalUserCheckInternalOnly_News.js',
            './features/story/SRC-2513/externalUserCheckInternalOnly_Research.js',
        ],

        story_788: [
            './features/story/SRC-788/checkVotingReminder_Research.js',
        ],
        
        
    },


    localSeleniumStandaloneOpts: {
        // jvmArgs : ["-Dwebdriver.ie.driver=../../driver/IEDriverServer_32.exe"] // e.g: "node_modules/protractor/node_modules/webdriver-manager/selenium/IEDriverServer_x64_X.XX.X.exe"
       jvmArgs: ["-Dwebdriver.edge.driver=../../driver/MicrosoftWebDriver_win1809.exe"],
    },


    /* time out guide:    https://github.com/angular/protractor/blob/master/docs/timeouts.md*/
    getPageTimeout: 100000, //Timed out waiting for page to load, and alternatively browser.get(address, timeout_in_millis)
    allScriptsTimeout: 1000000, // Timed out waiting for asynchronous Angular tasks


    framework: 'jasmine2',
    // restartBrowserBetweenTests: true,
    //////// directConnect: true,

    // seleniumAddress: 'http://localhost:4444/wd/hub',        /// this is for local run
    // seleniumAddress: 'http://localhost:4445/wd/hub', 
    // sauceUser:  'webber_ling',                           /// this is for saucelab run
    // sauceKey:   '1b1c51e8-b0a3-409b-8434-7b606c3e3430',

    jasmineNodeOpts: {
        showColors: true,
        isVerbose: true,
        includeStackTrace: true,
        defaultTimeoutInterval: 900000, //To change for all specs
                                        //To change for one individual spec, pass a third parameter to  it :  it(description, testFn, timeout_in_millis)
        //realtimeFailure: true,
        print: function () {
        }
    },

    // seleniumArgs: ['-Dwebdriver.ie.driver=node_modules/protractor/selenium/IEDriverServer.exe'],
    // 'browserName': 'internet explorer',


    capabilities: {

        // browserName: 'MicrosoftEdge',
        // browserName: 'internet explorer',
        // 'ignoreProtectedModeSettings':true,'ignoreZoomSetting':true,'nativeEvents':false,
        // browserName: 'firefox',
        browserName: 'chrome',
        chromeOptions: {
            args: ['--disable-extensions', '--start-maximized', "--incognito"],
            useAutomationExtension: false,
            w3c: false
        },
        // platform:   'ANY', //
        // version:    '11', // ie only
        acceptSslCerts: true,
        shardTestFiles: false,
        implicit: 30000
    },


    beforeLaunch: function () {
        // return new Promise(function (resolve) {
        //     reporter.beforeLaunch(resolve);
        // });

    },
    onPrepare: function () {
        browser.ignoreSynchronization = true;
        browser.driver.manage().window().maximize();

        jasmine.getEnv().addReporter(
            new HtmlScreenshotReporter({
                savePath: '../../reports'
            })
        );

        /////////////////////////////////////   below codes are for customized screenshots /////////////////////////
        //joiner between browser name and file name
        screenshots.browserNameJoiner = '_'; //this is the default
        //folder of screenshots
        screenshots.screenShotDirectory = './screenshots';
        // delete any existing screenshots
        glob("./screenshots/*.*", function (err, files) {
            if (err)
                throw err;

            // Delete files
            files.forEach(function (item) {
                fs.unlink(item, function (err) {
                    if (err)
                        throw err;
                });
            });
        });
        //creates folder of screenshots
//        screenshots.createDirectory();
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////   below codes are for clean data>>out /////////////////////////

        // delete any existing output data
        // glob("./data/out/*.*", function (err, files) {
        //     if (err)
        //         throw err;
        //
        //     // Delete files
        //     files.forEach(function (item) {
        //         fs.unlink(item, function (err) {
        //             if (err)
        //                 throw err;
        //
        //         });
        //     });
        // });
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // skip current Describe if has error and keep execute other Describes   --- 2020-06-20 WB
        jasmine.getEnv().addReporter(DescribeFailureReporter(jasmine.getEnv()));

        ///////////////////////  stop whole tests after first fail //////////////////////////////////////////////
        // var specs = [];
        // var orgSpecFilter = jasmine.getEnv().specFilter;
        // jasmine.getEnv().specFilter = function (spec) {
        //     specs.push(spec);
        //     return orgSpecFilter(spec);
        // };
        // jasmine.getEnv().addReporter(new function () {
        //     this.specDone = function (result) {
        //         if (result.failedExpectations.length > 0) {
        //             specs.forEach(function (spec) {
        //                 spec.disable()
        //             });
        //         }
        //     };
        // });


    },

    afterLaunch: function (exitCode) {

        return new Promise(function (resolve) {
            reporter.afterLaunch(resolve.bind(this, exitCode));
        });

    },

};



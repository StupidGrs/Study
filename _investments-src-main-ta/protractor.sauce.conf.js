const { common_config, chromeCapabilities, ieCapabilities, firefoxCapabilities, edgeCapabilities } = require('./common_config');
const yargs = require("yargs").argv;

const BROWSER = process.env.BROWSER_NAME ? process.env.BROWSER_NAME : (yargs.BROWSER_NAME || 'chrome');
const BROWSER_VERSION = process.env.BROWSER_VERSION || 'latest';
const PLATFORM = process.env.PLATFORM || 'windows 10';
const JOB_NAME = process.env.JOB_NAME || 'Regression Tests';
const SAUCE_USERNAME = process.env.SAUCE_USERNAME || 'exadelmercerte';
const SAUCE_ACCESS_KEY = process.env.SAUCE_ACCESS_KEY || 'b423526a-48f8-4146-a4a4-f689099f9d66';
const SELENIUM_VERSION = process.env.SELENIUM_VERSION || '3.141.59';
const DEVICE = process.env.DEVICE || 'PC';
const SCREEN_RESOLUTION = process.env.SCREEN_RESOLUTION || "1920x1080";

const TUNNEL_IDENTIFIER = 'MercerTunnel1';
const EU_TUNNEL_IDENTIFIER = 'MercerEU_Tunnel';
const PARENT_TUNNEL = 'erik-horrell';
const SHARD_TEST_FILES = (process.env.MAX_INSTANCES || yargs.instances) || false;
const MAX_INSTANCES = process.env.MAX_INSTANCES ? process.env.MAX_INSTANCES : (yargs.instances || 1);

exports.config = Object.assign({}, common_config, {
  seleniumAddress: null,
  sauceUser: SAUCE_USERNAME,
  sauceKey: SAUCE_ACCESS_KEY,
  capabilities: _processSauceConfig(),
  //sauceSeleniumAddress: 'ondemand.eu-central-1.saucelabs.com/wd/hub',
  specs: ['./src/features/regression/**/*.feature'],
  cucumberOpts: { ...common_config.cucumberOpts, tags: [`${yargs.tag || '@regression and not @ignore'}`]},
});

// -- internal -- //
function _processSauceConfig() {
  const conf = {
    browserName: BROWSER,
    //'time-zone': 'London',
    platform: PLATFORM,
    version: BROWSER_VERSION,
    seleniumVersion: SELENIUM_VERSION,
    // tunnelIdentifier: TUNNEL_IDENTIFIER,
    // parentTunnel: PARENT_TUNNEL,
    name: JOB_NAME,
    videoUploadOnPass: false,
    recordScreenshots: false,
    shardTestFiles: SHARD_TEST_FILES,
    maxInstances: MAX_INSTANCES,
    screenResolution: SCREEN_RESOLUTION,
    // extendedDebugging: true,
    // capturePerformance: true,
    recordVideo: false,

    // protractor-multiple-cucumber-html-reporter-plugin options
    metadata: {
      browser: {
        name: BROWSER,
        version: BROWSER_VERSION
      },
      device: DEVICE,
      platform: {
        name: PLATFORM.replace(/\d*/g, '').trim(),
        version: PLATFORM.replace(/\D*/g, '').trim()
      }
    }
  };

  switch (conf.browserName) {
    case 'firefox': {
      conf['moz:firefoxOptions'] = firefoxCapabilities['moz:firefoxOptions'];
      break;
    }
    case 'chrome': {
      conf.chromeOptions = chromeCapabilities.chromeOptions;
      break;
    }
    case 'internet explorer': {
      conf["se:ieOptions"] = ieCapabilities["se:ieOptions"];
      break;
    }
    case 'MicrosoftEdge': {
      conf.EdgeOptions = edgeCapabilities.EdgeOptions;
      break;
    }
    case 'Safari': {
      console.warn('Safari not fully supported');
      break;
    }
    default: {
      console.log(`Browser: ${conf.browserName}, TEST_ENV: ${process.env.TEST_ENV ? process.env.TEST_ENV : (yargs.TEST_ENV || 'LOCAL')}`);
      throw new Error('Can\'t find matching browser capabilities. Please check config');
    }
  }

  return conf;
}

// EXAMPLES:
// {
//   browserName: "chrome",
//   platform: "Windows 7",
//   version: "latest-2",
//   seleniumVersion: '3.12.0'
// },
// {
//   browserName: "firefox",
//   platform: "Windows 7",
//   version: "latest-1",
//   seleniumVersion: '3.12.0'
// },
// {
//   browserName: "internet explorer",
//   platform: "Windows 7",
//   version: "latest",
//   seleniumVersion: '3.12.0'
// },
// {
//   browserName: "MicrosoftEdge",
//   platform: "Windows 10",
//   version: "17.17134",
//   seleniumVersion: '3.12.0'
// },
// {
//   browserName: "safari",
//   platform: "macOS 10.12",
//   version: "10.1",
//   seleniumVersion: '3.12.0'
// },

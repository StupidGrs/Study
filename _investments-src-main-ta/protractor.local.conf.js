const yargs = require("yargs").argv;

const { common_config, chromeCapabilities, ieCapabilities, firefoxCapabilities, edgeCapabilities } = require('./common_config');

const BROWSER = process.env.BROWSER_NAME ? process.env.BROWSER_NAME : (yargs.BROWSER_NAME || 'MicrosoftEdge');

let capability;

switch (BROWSER) {
  case "chrome":
    capability = { ...chromeCapabilities };
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
};

exports.config = Object.assign({}, common_config, {
  capabilities: {
    ...capability
  },
  // Used for library tests
  //specs: ['src/features/regression/*/*.feature']
  specs: ['./src/features/**/*.feature']
  ,
  // cucumberOpts: Object.assign({}, common_config.cucumberOpts, {tags: 'not @Ignore'}),
  plugins: [{
    package: 'protractor-multiple-cucumber-html-reporter-plugin',
    options: {
      // read the options part https://www.npmjs.com/package/protractor-multiple-cucumber-html-reporter-plugin#options
      automaticallyGenerateReport: true,
      removeExistingJsonReportFile: true,
      openReportInBrowser: false,
      removeOriginalJsonReportFile: false,
      displayDuration: true,
      durationInMS: false
    }
  }]

});

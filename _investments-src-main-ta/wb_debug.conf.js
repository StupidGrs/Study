const { common_config, chromeCapabilities, ieCapabilities, firefoxCapabilities, edgeCapabilities } = require('./common_config');
const yargs = require("yargs").argv;

const BROWSER = process.env.BROWSER_NAME ? process.env.BROWSER_NAME : (yargs.BROWSER_NAME || 'MicrosoftEdge');

let capability;
//const timeOut24h = 24 * 60 * 60000;

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
};

exports.config = Object.assign({}, common_config, {
  capabilities: Object.assign(capability),
  specs: [

    // './src/features/e2e/researchE2E.feature',
    './src/features/regression/News/*.feature', // WB: config for smoke test

    // './src_new/test/e2e/features/regression/debug.js',
  ],

  // using spread operator to copy tags in cucumberOptions

  // cucumberOpts: { ...common_config.cucumberOpts, tags: [`${yargs.tag || '@smoke and not @ignore'}`]} // WB: config for smoke test

});

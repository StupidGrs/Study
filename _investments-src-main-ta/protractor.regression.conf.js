const { common_config, chromeCapabilities, ieCapabilities, firefoxCapabilities, edgeCapabilities } = require('./common_config');
const yargs = require("yargs").argv;

const BROWSER = process.env.BROWSER_NAME ? process.env.BROWSER_NAME : (yargs.BROWSER_NAME || 'chrome');
const environment = process.env.TEST_ENV ? process.env.TEST_ENV : (yargs.TEST_ENV || 'LOCAL');
let capability;
const proxy = {
  proxy: {
    proxyType: 'MANUAL',
    httpProxy: '10.2.30.39:8080',
    sslProxy: '10.2.30.39:8080'
  }
}
switch (BROWSER) {
  case "chrome":
    capability = { ...chromeCapabilities };
    capability = (environment.includes('AWS')) ? Object.assign({}, capability, proxy) : capability;
    break;
  case "internet explorer":
    capability = { ...ieCapabilities };
    break;
  case "firefox":
    capability = { ...firefoxCapabilities };
    capability = (environment.includes('AWS')) ? Object.assign({}, capability, proxy) : capability;
    break;
  case "MicrosoftEdge":
    capability = { ...edgeCapabilities };
    break;
  default:
    capability = { ...chromeCapabilities };
    break;
}

exports.config = Object.assign({}, common_config, {
  capabilities: Object.assign(capability),
  specs:  ['./src/features/regression/**/*.feature'],
  // using spread operator to copy tags in cucumberOptions
  cucumberOpts: { ...common_config.cucumberOpts, tags: [`${yargs.tag || '@regression and not @ignore'}`] }
});
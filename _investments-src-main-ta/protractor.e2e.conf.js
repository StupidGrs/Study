const { common_config, chromeCapabilities, ieCapabilities, firefoxCapabilities, edgeCapabilities } = require('./common_config');
const yargs = require("yargs").argv;

const BROWSER = process.env.BROWSER_NAME ? process.env.BROWSER_NAME : (yargs.BROWSER_NAME || 'chrome');

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
  capabilities: Object.assign(capability, {
    // proxy is used only for AWS test run
    proxy: {
      proxyType: 'MANUAL',
      httpProxy: '10.2.30.39:8080',
      sslProxy: '10.2.30.39:8080'
    }
  }),
  specs: ['./src/features/e2e/*.feature'],
  restartBrowserBetweenTests: false,
  // using spread operator to copy tags in cucumberOptions
  cucumberOpts: { ...common_config.cucumberOpts, tags: [`${yargs.tag || '@e2e and not @ignore'}`]},
});
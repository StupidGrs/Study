const {common_config, chromeCapabilities} = require('./common_config');

exports.config = Object.assign({}, common_config, {
  capabilities: Object.assign(chromeCapabilities, {
    // proxy is used only for AWS test run
    proxy: {
      proxyType: 'MANUAL',
      httpProxy: '10.2.30.39:8080',
      sslProxy: '10.2.30.39:8080'
    },
    maxInstances: 15,
  }),
  specs: ['./src/features/*/*/*.feature'],
  // remove 'protractor-multiple-cucumber-html-reporter-plugin' for CI
  // in favor of cucumber jenkins plugin - https://wiki.jenkins.io/display/JENKINS/Cucumber+Reports+Plugin
  plugins: []
});

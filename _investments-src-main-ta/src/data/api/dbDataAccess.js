const yargs = require("yargs").argv;

const ENV = process.env.TEST_ENV ? process.env.TEST_ENV : (yargs.TEST_ENV || 'STAGE');

const baseUrl = {
  LOCAL: {
    BE: 'https://localdev-columbus.mercer.com:3000',
    STRAPI: 'http://localhost:1337'
  },
  DEV: {
    BE: 'https://src.us-east-1.dev.awsapp.mercer.com/v1/api',
    STRAPI: 'https://strapi.src.us-east-1.dev.awsadmin.mercer.com'
  },
  AWS_DEV: {
    BE: 'https://src.us-east-1.dev.awsapp.mercer.com/v1/api',
    STRAPI: 'https://strapi.src.us-east-1.dev.awsadmin.mercer.com'
  },
  STAGE: {
    BE: 'https://src.us-east-1.stage.awsapp.mercer.com/v1/api',
    STRAPI: 'https://strapi.src.us-east-1.stage.awsadmin.mercer.com'
  },
  AWS_STAGE: {
    BE: 'https://src.us-east-1.stage.awsapp.mercer.com/v1/api',
    STRAPI: 'https://strapi.src.us-east-1.stage.awsadmin.mercer.com'
  },
  AWS: "…"
};

module.exports = {
  baseUrl_BE: baseUrl[ENV].BE,
  baseUrl_STRAPI: baseUrl[ENV].STRAPI
};
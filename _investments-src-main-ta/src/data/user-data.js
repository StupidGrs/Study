/**
 * This file is represented urls and users information.
 * PROJECT_NAME should be changed with appropriate project name.
 * PROJECT_NAME constructions can be as much as needed.
 *
 * urls are used in {landing-url} custom parameter type.
 * users are used in {user} custom parameter type.
 * Used for library tests
 *
 * @example
 * User navigates to "PAGE_NAME"
 * User login
 */


module.exports = {
  urls: {
    ENV: {
      LOCAL: 'http://localdev-columbus.mercer.com:4200',
      DEV: 'https://src.us-east-1.dev.awsapp.mercer.com',
      AWS_DEV: 'https://src.us-east-1.dev.awsapp.mercer.com',
      STAGE: 'https://src.us-east-1.stage.awsapp.mercer.com',
      AWS_STAGE: 'https://src.us-east-1.stage.awsapp.mercer.com',
    },
    LOGIN_PAGE: '/login',
    HOME_PAGE: '/dashboard',
    NEWS_PAGE: '/news',
    RESEARCH_PAGE: '/research',
    EVENTS_PAGE: '/events',
    DIRECTORIES_PAGE: '/directories',
    PUBLISH_RESEARCH_PAGE: '/publish/research',
    USER_ARTICLE_LIST_PAGE: '/user-article-list',
    CONTENT_LIST_PAGE: '/admin/content-list',
    ADMIN_COMPANY_IMPORT: '/admin/company-import',
    ADMIN_RESEARCH_IMPORT: '/admin/research-import',
    ADMIN_RSS_CONFIGS: '/admin/rss-configs',
  },
  users: {
    COMPANY_ADMIN: {
      email: 'comp.admin@src.mercer.com',
      login: 'COMPANY_ADMIN',
      password: 'Password1'
    },
    GLOBAL_ADMIN: {
      email: 'glob.admin@src.mercer.com',
      login: 'GLOBAL_ADMIN',
      password: 'Password1'
    },
    COMPANY_USER: {
      email: 'comp.user@src.mercer.com',
      login: 'COMPANY_USER',
      password: 'Password1'
    },
    COMPANY_AUTHOR: {
      email: 'comp.author@src.mercer.com',
      login: 'COMPANY_AUTHOR',
      password: 'Password1'
    },
    GLOBAL_USER: {
      email: 'glob.admin.second@src.mercer.com?useMsso=false',
      login: 'GLOBAL_USER',
      password: 'Password1'
    }
  }
};

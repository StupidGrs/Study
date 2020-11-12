/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */
const peopleCompaniesListComponent = require('../people-company-list-component');

module.exports = {
  employeesTab: '#company-people-card_931237687 .mos-c-tabs--label:nth-child(1)',
  followersTab: '#company-people-card_931237687 .mos-c-tabs--label:nth-child(2)',
  ...peopleCompaniesListComponent,
};

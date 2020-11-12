/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */
const recentlyPublishedComponent = require('./components/companyProfile/company-profile-recently-published-component');
const employeesFollowersPopUpComponent = require('./components/companyProfile/employees-Followers-PopUp-component');

module.exports = {
    companyName: '#company-page-header_416479247',
    mainTabsList: '#company-page-tabs_707149504 > div > div > div a',
    employeesTab: '#company-people-card_931237687 .mos-c-tabs--label:nth-child(1)',
    followersTab: '#company-people-card_931237687 .mos-c-tabs--label:nth-child(2)',
    viewAllButton: '.src-c-company-people-card__button-bar button',
    ...recentlyPublishedComponent,
    ...employeesFollowersPopUpComponent
};

/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */
const peopleCompaniesListComponent = require('./components/people-company-list-component');

module.exports = {
    companyLink: '#profile-header_402880671',
    recentActivitySection: '#recent-activity_857171356',
    recentActivityRowItemsList: '[id^=recent-activity_item]',
    activityTypesList: 'div.src-c-recent-activity__activity-type',
    activityResourceTitlesList: 'div.src-c-recent-activity__title',
    activityTimeList: 'div.src-c-recent-activity__time',
    activityIconsList: 'div.src-c-recent-activity__activity-type-icon',
    followingTab: `#following_150718831`,
    followingTabIcon: `#following_83083590`,
    followingTabText: `#following_430266797`,
    followersTab: `#following_434296628`,
    followersTabIcon: `#following_512627320`,
    followersTabText: `#following_387441956`,
    peopleTab: `#following_590305374`,
    peopleTabCount: `#following_599204203`,
    peopleTabText: `#following_397144543`,
    companiesTab: `#following_904747661`,
    companiesTabCount: `#following_381688716`,
    companiesTabText: `#following_497507804`,
    ...peopleCompaniesListComponent

};

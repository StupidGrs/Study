const profileMenuComponent = require('./components/profile-menu-component');
const settingsMenuComponent = require('./components/settings-menu-component');

module.exports = {
  publishButton: '#header_855538167',
  settingsButton: '#settings_211540600',
  notificationButton: '[id="header-notifications_23878109"] [id="header-notifications_35883687"]',
  notificationComponent: 'div.mos-c-dropdown--open > ul > li:nth-child(1) > div',
  notificationHeader: 'div.mos-c-dropdown--open > ul > li:nth-child(1) [id="header-notifications_67550403"]',
  markAllAsRead: 'div.mos-c-dropdown--open > ul > li:nth-child(1) [id="header-notifications_39888126"]',
  noNewNotification: '#header-notifications_50938390',
  firstNotificationMessage: 'ul > li:nth-child(2) > div > div > div:nth-child(1) > div',
  secondNotificationMessage: 'ul > li:nth-child(2) > div > div > div:nth-child(2) > div',
  thirdNotificationMessage: 'ul > li:nth-child(2) > div > div > div:nth-child(3) > div',
  fourthNotificationMessage: 'ul > li:nth-child(2) > div > div > div:nth-child(4) > div',
  fifthNotificationMessage: 'ul > li:nth-child(2) > div > div > div:nth-child(5) > div',
  firstNotificationCompanyLog: 'li:nth-child(2)> div:nth-child(1) [id="company-logo_abbreviation"]',
  firstNotificationCompanyName: '#notification-item_698459783',
  firstNotificationText: '#notification-item_566327543',
  seeAllButton: '#header-notifications_61176872',
  firstNotificationCheckIcon: '#notification-item_554837835',
  firstNotification: '#notification-item_32394835',
  userLogo: '[id="header_685283248"] > div',
  ...settingsMenuComponent,
  settingsItemsList: '.mos-c-dropdown__list li a > div',
  profileButton: '#header_685283248',
  ...profileMenuComponent,
  logo: 'a.src-c-header__logo',
    // logo: '#header_661848070',//2020-06-30 WB updated
};
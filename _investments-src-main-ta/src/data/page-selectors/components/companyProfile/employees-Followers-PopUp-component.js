const modalContent = 'mercer-modal-content';

module.exports = {
  headerTitle: '.modal-header>div>[id^="company-people-card-modal"]',
  headerInfo1: '.src-c-company-people-card-modal__info-block > div:nth-child(1)',
  headerInfo2: '.src-c-company-people-card-modal__info-block > div:nth-child(2)',
  closeButton: '.mos-c-modal__close',
  followButtonsList: `${modalContent} button`,
  avatarsList: `${modalContent} mercer-person-avatar`,
  peopleNamesList: `${modalContent} h3`,
  titlesAndCompaniesList: `${modalContent} .src-c-person-list__subtitle span`
};
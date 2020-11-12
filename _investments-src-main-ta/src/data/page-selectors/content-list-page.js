/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */
const rejectPopup = require('./popups/rejectReason');
const bulkActionsBlock = '.mos-u-display--inline-block';
const table = 'table';
const tableHeader = `${table} .mos-u-table__header-container`;
const tableBody = `${table} tbody`;
const tableRowsList = `${tableBody} tr`;


module.exports = {
  pageHeader: 'mercer-hero h1',
  articleStatusDropdown: '#select-status',
  articleStatusDropdownOptionsList: '#select-status option',
  articleTypeDropdown: '#select-type',
  articleTypeDropdownOptionsList: '#select-type option',
  searchContentField: '#search-input',
  searchContentFieldLabel: '[for="searchInput"]',
  bulkActionsLabel: `#content-list_459628859`,
  bulkApproveButton: `#content-list_174738729`,
  bulkRejectButton: `#content-list_710595560`,
  bulkUnapproveButton: `#content-list_743580`,
  table: `${table}`,
  tableHeader: `${tableHeader}`,
  tableHeaderColumnsList: `${tableHeader} mos-c-table__header--label`,
  tableHeaderColumnsSortingIconsList: `${tableHeader} .mos-c-table__header--sorting-icon mercer-icon`,
  tableHeaderSelectAllCheckboxLabel: `${tableHeader} label[for="mosCheckboxAll"]`,
  tableHeaderSelectAllCheckboxInput: `${tableHeader} #mosCheckboxAll`,
  tableBody: `${tableBody}`,
  tableRowsList: `${tableRowsList}`,
  tableRowCheckboxInputsList: `${tableRowsList} input[id*=checkboxRow]`,
  tableRowCheckboxLabelsList: `${tableRowsList} label[for*=checkboxRow]`,
  tableRowApproveButtonsList: `[id^="content-list__approve__"]`,

  tableRowRejectButtonsList: `[id^="content-list__reject__"]`,
  contentTypeList: `[id^="content-list__ct__"]`,
  sourceList: `[column="ingestion_source"]`,
  titleList: `[id^="content-list__title__"]`,
  dateList: `[id^="content-list__date__"]`,
  companyList: `[id^="content-list__name__"]`,
  feedNameList: `[column="sourceFeed"]`,
  unapproveButtonsList: `[id^="content-list__unapprove__"]`,
  viewButtonsList: `[id^="content-list__view"]`,
  ...rejectPopup,
};

/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */
const filterSection = '#filters_root';
const filterHeaderSection = `${filterSection} .src-c-filters__header`;
const filterInputsSection = `#filters_form`;
const filterCategoriesSection = `${filterInputsSection} > div:nth-child(1)`;
const filterDateRangeSection = `#filters_281427150`;
const filterCompaniesSection = `${filterInputsSection} > div:nth-child(3)`;
const filterRegionsSection = `${filterInputsSection} > div:nth-child(4)`;

module.exports = {
  //filter section
  filterIcon: `${filterHeaderSection} mercer-icon[icon="filter_list"]`,
  filterHeaderLabel: `${filterHeaderSection} h3`,
  filterClearAllLink: `${filterHeaderSection} a`,
  filterSettingsIcon: `${filterHeaderSection} [icon="settings"] mercer-icon`,

  //Categories
  filterCategoriesHeaderLabel: `${filterCategoriesSection} h4`,
  filterCategoriesSelectedLabel: `${filterCategoriesSection} span`,
  filterCategoriesRevertToDefaultLink: `${filterCategoriesSection} a`,
  filterCategoriesCheckBoxesInputsList:`${filterCategoriesSection} input`,
  filterCategoriesCheckBoxesLabelsList:`${filterCategoriesSection} label`,

  //Date Rage
  filterDateRangeHeaderLabel: `${filterDateRangeSection} h4`,
  filterDateRangeRevertToDefaultLink: `${filterDateRangeSection} a`,
  filterDateRangeFromValue: `${filterDateRangeSection} .row:nth-child(2) div:nth-child(1)`,
  filterDateRangeToValue: `${filterDateRangeSection} .row:nth-child(2) div:nth-child(2)`,
  filterDateRangeSlider: `${filterDateRangeSection} .mos-c-slider`,
  filterDateRangeSliderFromBullet: `${filterDateRangeSection} .mos-c-slider__scrubber--lower`,
  filterDateRangeSliderToBullet: `${filterDateRangeSection} .mos-c-slider__scrubber--upper`,

  //Companies
  filterCompaniesHeaderlabel: `${filterCompaniesSection} h4`,
  filterCompaniesSelectedLabel: `${filterCompaniesSection} span`,
  filterCompaniesRevertToDefaultLink: `${filterCompaniesSection} a`,
  filterCompaniesSearchInput: `${filterCompaniesSection} .search-input-block input`,
  filterCompaniesSearchIcon: `${filterCompaniesSection} .search-input-block mercer-icon`,
  filterCompaniesCheckBoxesInputsList: `${filterCompaniesSection} .scr-scrollable-filter-box input`,
  filterCompaniesCheckBoxesLabelsList: `${filterCompaniesSection} .scr-scrollable-filter-box label`,

  //Regions
  filterRegionsHeaderLabel: `${filterRegionsSection} h4`,
  filterRegionsSelectedLabel: `${filterRegionsSection} span`,
  filterRegionsRevertToDefaultLink: `${filterRegionsSection} a`,
  filterRegionsCheckBoxesInputsList:`${filterRegionsSection} input`,
  filterRegionsCheckBoxesLabelsList:`${filterRegionsSection} label`,

  //sort and search section
  sortByDropdownFieldLabel: `label[for="sortSelect"]`,
  sortByDropdownField: `select#sortSelect`,
  sortByDropdownFieldOptionsList: `select#sortSelect option`,

  searchArticleAutocompleteField: `#search-autocomplete_field input`,
  searchArticleAutocompleteFieldItemsList: `.mos-c-autocomplete__list a`, 
  searchArticleIcon: `#search-autocomplete_934836367`,
  searchArticleClearInputIcon: `.search-part mercer-icon:nth-child(2)`,

};
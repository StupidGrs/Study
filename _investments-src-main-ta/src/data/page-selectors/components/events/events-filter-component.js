/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */

//todo: selectors are identical to ones on Research tab. To create a common component
module.exports = {
    searchEventsField: `#search-autocomplete_field input`,
    clearSearchFieldButton: `mercer-autocomplete button`,

    //sort and search section
    sortByDropdownFieldLabel: `label[for="sortSelect"]`,
    sortByDropdownField: `select#sortSelect`,
    sortByDropdownFieldOptionsList: `select#sortSelect option`
};
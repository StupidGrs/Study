/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */

module.exports = {
  modalHeader: '#publish-content-form_56855288',
  modalHeaderTitle: `#event-form-modal_960296810`,
  modalContent: `.src-c-publish-content-form-header__description`,
  // closeIcon: 'mercer-icon[icon="close"]',
    closeIcon: '#publish-content-form_406816460',
  companyField: '#companies-autocomplete_autocomplete input',
  companyFieldLabel: '[for="company"]',
  // eventTypeField: '#eventTypeField',
    eventTypeField: '[id="eventType"]', //2020-06-24 WB updated
  // eventTypeFieldLabel: '[for="eventTypeField"]',
    eventTypeFieldLabel: '[for="eventType"]',//2020-06-30 WB updated
  eventTypeFieldLabelSpan: '[for="eventType"] span',
  eventTypeFieldOption: '#eventType option',
  //eventNameField: '#eventNameField',
    eventNameField: '[id="titleField"]',//2020-06-24 WB updated
  eventNameFieldLabel: '[for="titleField"]',
  eventNameFieldLabelSpan: '[for="titleField"] span',
  locationField: '[id="mos-autocomplete-3"]',
  locationFieldLabel: '[id*="publish-content-form-event-post-info_"]',
  locationFieldLabelSpan: '[id*="publish-content-form-event-post-info_"] span',
  locationAutocompleteList: '.mos-c-autocomplete__container--absolute',
  // locationAutocompleteItem: '.mos-c-autocomplete__list__item li',
    locationAutocompleteItem: '.mos-c-autocomplete__list__item > .ng-star-inserted',
  locationInput: '#mos-autocomplete-4',
  locationSelectList: 'div.mos-c-autocomplete__list__container > ul > li > a > div',
  regionField: '#regionField',
  // regionFieldDropdown: '#mos-multi-select-default',
    regionFieldDropdown: '#publish-content-form-accordion-wrapper_287255107',//2020-07-1 WB updated


  regionFieldSpan: '#mos-multi-select-default span',
  regionFieldLabel: '[id="publish-content-form-accordion-wrapper_287255107"]',
  regionOptionRow: '#regionField mercer-option',
  // regionOptionCheckboxLabel: '#regionField mercer-option label',
    regionOptionCheckboxLabel: '.region-form__label',//2020-06-29 WB updated
    regionOptionCheckboxLabel_UK: '.column:nth-child(5) .region-form__label',//2020-06-29 WB updated
    regionOptionCheckbox_US: '.column:nth-child(8) .region-form__label',//2020-07-01 WB added
  regionOptionCheckboxInput: '#regionField mercer-option input',
  startDateField: `#publish-content-form-event-post-info_start_date .mos-c-datepicker__input-date > .ng-star-inserted`,


  startDateFieldLabel: `#publish-content-form-event-post-info_26968538`,
  // datepickerStartDate: '#event-form-modal_start_date mercer-icon',
    datepickerStartDate: '#publish-content-form-event-post-info_start_date mercer-icon',//2020-06-24 WB updated

  endDateField: `#publish-content-form-event-post-info_end_date .mos-c-datepicker__input-date > .ng-star-inserted`,
  endDateFieldLabel: `#publish-content-form-event-post-info_92791781`,
  //datepickerEndDate: '#event-form-modal_end_date mercer-icon',
    datepickerEndDate: '#publish-content-form-event-post-info_end_date mercer-icon',//2020-06-29 WB updated
  calendarArrowLeftButton: '[icon="keyboard_arrow_left"] mercer-icon',
  calendarArrowRightButton: '[icon="keyboard_arrow_right"] mercer-icon',
  calendarDayIcon: '.mos-c-calendar__day',
  startTimeField: '#startTime',
  startTimeFieldLabel: '[for="startTime"]',
  startTimeFieldLabelSpan: '[for="startTime"] span',
  endTimeField: '#endTime',
  endTimeFieldLabel: '[for="endTime"]',
  endTimeFieldLabelSpan: '[for="endTime"] span',
  timezoneWarningMessage: '[class*="timezone-warning"]',
  // urlLinkField: '#urlLinkField',
    urlLinkField: '[id="contentUrlField"]',//2020-06-29 WB updated
  // urlLinkFieldLabel: '[for="urlLinkField"]',
    urlLinkFieldLabel: '[for="contentUrlField"]',//2020-06-29 WB updated
  taxonomyField: '#taxonomyField',
  taxonomyFieldLabel: '[for="taxonomies"]',
  taxonomyFieldLabelSpan: '[for="taxonomies"] span',
  taxonomyFieldOption: '#taxonomyField option',
  taxonomyFieldDisabledOptionsList: '#taxonomies select option[disabled]',
  taxonomiesSelectedOptionsList: '[id^=taxonomy-form_chip]',
  taxonomiesRemoveIconsList: '[id^=taxonomy-form_chip] mercer-icon',
  tagsField: 'input[placeholder="Search Tags"]',
  tagsFieldLabel: '[for="tagField"]',
  tagsAutoCompleteList: '.mos-c-autocomplete__list__container',
  tagsAutoCompleteItem: '.mos-c-autocomplete__list a',
  tagChipItem: '[id^="tag-chip-autocomplete_chip-title"]',
  tagChipItemRemoveIcon: '[id^="tag-chip-autocomplete_chip-title"] mercer-icon',
  excerptField: '#excerptField',
  excerptFieldLabel: '[for="excerptField"]',
  excerptFieldLabelSpan: '[for="excerptField"] span',
  excerptCharCounter: '.mos-u-float-right',
  contentField: '.ql-editor',
  contentFieldToolbar: '.ql-toolbar',
  contentFieldLabel: '[for="contentField"]',
  contentFieldLabelSpan: '[for="contentField"] span',
  // fileDropZone: 'mercer-file-dropzone',//2020-07-3 WB updated
    fileDropZone: '.mos-c-file-dropzone',
  // removeImageButton: `#event-form-modal_38526444`,
    removeImageButton: `#mos-icon-cancel`,//2020-06-30 WB updated
  attachmentFieldInput: '#attachmentField input',
  attachmentFieldLabel: '#event-form-modal_336373128',
  uploadedFileTitle: `#attachmentField span`,
  attachmentFieldMessage: '[class*=dropzone__upload-message]',
  attachmentFieldIcon: '#attachmentField mercer-icon',
  // modalFooterButtons: 'mercer-modal-footer button',
    SubmitAndAddAnother: '[id="publishAndSubmitAnother"]', // WB: above modalFooterButtons is replaced by SubmitAndAddAnother and Submit
    Submit: '[id="publishSubmitLowerLeft"]',
  cancelButton: `#cancelPublish`,
  // saveDraftButton: `#event-form-modal_saveDraft_562521651`,
    saveDraftButton: `[id*="publish-content-form-action-buttons_save-draft_"]`,//2020-06-30 WB updated
  saveDraftButtonIcon: `#publish-content-form-action-buttons_735287367`,
  submitButton: '[id="publishSubmitLowerLeft"]',
  submitAndPostNewButton: '[id="publishAndSubmitAnother"]',
    attachedImageDropdown: '#publish-content-form-accordion-wrapper_287255107',//2020-07-1 WB updated
  attachedImageLabel: `#event-form-modal_909322494 mercer-chip span`,
  attachedImageRemoveIcon: `#publish-research-form_312295388 > mercer-icon`,
  resubmitButton: `#publish-content-form-action-buttons_866420623`, //
};
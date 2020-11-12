/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */
const taxonomiesDropdownField = '#taxonomyField';
const isFeaturedToogleDiv = '#content-moderation-form_133406456';
const datePicker = '#content-moderation-form_255877751';

module.exports = {
  pageHeader: '#content-moderation-form_439097539',
  articleStatus: '#content-moderation-form_624288445',
  titleField: `#titleField`,
  titleFieldLabel: `#content-moderation-form_670234683`,
  contentUrlField: `#contentUrlField`,
  contentUrlFieldLabel: `#content-moderation-form_790708964`,
  urlLabelField: `#contentUrlLabelField`,
  urlLabelFieldLabel: `#content-moderation-form_148462269`,
  excerptField: `#excerptField`,
  excerptFieldInput: `#excerptField .ql-editor`,
  excerptFieldLabel: `#content-moderation-form_769798803`,
  contentField: `#contentField`,
  contentFieldInput: `#contentField .ql-editor`,
  contentFieldLabel: `#content-moderation-form_193481423`,

  isFeaturedLabel: `${isFeaturedToogleDiv} div.mos-c-slide-toggle span`,
  isFeaturedSlider: `${isFeaturedToogleDiv} div.mos-c-slide-toggle__bar`,
  isFeaturedSliderCheckboxInput: `${isFeaturedToogleDiv} .mos-c-slide-toggle input`,

  readTimeField: `#readTimeField`,
  readTimeFieldLabel: `#content-moderation-form_956394368`,
  calculateTimeButton: `#content-moderation-form_514127163`,

  disclaimerField: `#content-moderation-form_106547662`,
  disclaimerFieldInput: `#content-moderation-form_106547662 .ql-editor`,
  disclaimerFieldLabel: `#content-moderation-form_373339090`,

  articleDocTypeField: `#articleTypeField`,
  articleDocTypeFieldLabel: `#content-moderation-form_127101342`,

  dateFieldLabel: `${datePicker} span`,
  dateFieldInput: `${datePicker} .mos-c-datepicker__key-in`,
  dateFieldInputValue: `${datePicker} .mos-c-datepicker__input`,
  datePickerIcon: `${datePicker} mercer-icon`,

  companyAutocompleteField: `#companies-autocomplete_autocomplete input`,
  companyAutocompleteFieldLabel: `#content-moderation-form_570005973`,
  companyAutocompleteItemsList: `#companies-autocomplete_autocomplete a`,

  regionsField: `#regionsField`,
  regionsFieldOptionsList: `#regionsField option`,
  regionsSelectedOptionsList: `#regionsField option:checked`,
  regionsFieldLabel: `#content-moderation-form_715363281`,

  targetAudienceOptionsList: `#content-moderation-form_972176674 li`,
  targetAudienceCheckBoxInputsList: '[id^=roleField]',
  targetAudienceCheckBoxLabelsList: '[for^=roleField]',
  targetAudienceLabel: `mercer-target-audience-form legend`,

  taxonomiesDropdownFieldLabel: `[for="taxonomyField"]`,
  taxonomiesDropdownField: `${taxonomiesDropdownField}`,
  taxonomiesOptionsGroupsList: `${taxonomiesDropdownField} optgroup`,
  taxonomiesDisabledOptionsGroupsList: `${taxonomiesDropdownField} optgroup[disabled]`,
  taxonomiesOptionsList: `${taxonomiesDropdownField} option`,
  taxonomiesDisabledOptionsList: `${taxonomiesDropdownField} option[disabled]`,
  taxonomiesSelectedOptionsList: 'mercer-taxonomy-form mercer-chip div',
  taxonomiesRemoveIconsList: 'mercer-taxonomy-form mercer-chip div mercer-icon',

  tagsInputLabel: '#tag-chip-autocomplete label span',
  tagsField: '#tagField input',
  tagsAutoCompleteItem: '.mos-c-autocomplete__list a',
  tagsSelectedList: '[id^=tag-chip-autocomplete_chip] div',
  tagsRemoveIconsList: '[id^=tag-chip-autocomplete_chip] div mercer-icon',

  featuredImageDropzone: '#featuredImageField',
  featuredImageFieldInput: '#featuredImageField input',
  featuredImageLabel: '#content-moderation-form_669580451',
  featuredImageUploadedDiv: '#content-moderation-form_887046679 mercer-card > div',
  featuredImageUploaded: '#content-moderation-form_675982796',
  featureImageRemoveButton: '#content-moderation-form_173665049 button',

  attachmentsDropzone: '#attachmentsField',
  attachmentsFieldInput: '#attachmentsField input',
  attachmentsLabel: '#content-moderation-form_367834390',
  attachmetsItemsList: '[id^=content-moderation-form__attachmet] div',
  attachmetsRemoveIconsList: '[id^=content-moderation-form__attachmet] div mercer-icon',

  actionButtonsList: '.mos-u-spacer--padding-top-lg button',
  saveButton: `#content-moderation-form_834175926`,
  saveAndPreviewButton: `#content-moderation-form_514405115`,
  approveButton: `#content-moderation-form_735220781`,
  approveAndOpenNextButton: `#content-moderation-form_512144377`,
  rejectButton: `#content-moderation-form_497268836`,
  rejectAndOpenNextButton: `#content-moderation-form_505089104`,
  cancelButton: `#content-moderation-form_945841915`,

  eventLocationAutocompleteField: `#location-autocomplete input`,
  eventLocationAutocompleteFieldLabel: `label[for="eventLocationField"]`,
  eventLocationAutocompleteItemsList: `.mos-c-autocomplete__list a`,

  eventTypeLabel: `#content-moderation-form_368802088`,
  eventTypeDropdownField: `#eventTypeField`,
  eventTypeDropdownOptionsList: `#eventTypeField option`,
  eventStartDateLabel: `#startDate label:nth-child(2)`,
//  lin: fixed at 31/Aug/2020
//  eventStartDateInput: `#startDate [mercerinput]`,
  eventStartDateInput: `#startDate .mos-c-datepicker__input-date .ng-star-inserted`,
  eventStartDatePicker: `#startDate mercer-icon`,
  eventStartTimeLabel:`#content-moderation-form_479005869`,
  eventStartTimeInput:`#startTimeField`,
  eventEndDateLabel: `#content-moderation-form_775569490 label:nth-child(2)`,
//  lin: fixed at 31/Aug/2020
//  eventEndDateInput: `#content-moderation-form_775569490 [mercerinput]`,
  eventEndDateInput: `#content-moderation-form_775569490 .mos-c-datepicker__input-date .ng-star-inserted`,
  eventEndDatePicker: `#content-moderation-form_775569490 mercer-icon`,
  eventEndTimeLabel:`#content-moderation-form_371915982`,
  eventEndTimeInput:`#endTimeField`,

  eventFeaturedImageUploaded: `#content-moderation-form_151311369`,
  eventRemoveFeaturedImageButton: `#content-moderation-form_357127874`

}
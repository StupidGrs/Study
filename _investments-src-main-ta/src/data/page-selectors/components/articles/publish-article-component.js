/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */
// .ql-editor


// const leftSidebar = '#publish-research-form_314067241';
// const rightSidebar = '#publish-research-form_759123566';
// const header = '#publish-research-form_131377915';

const leftSidebar = '#publish-content-form_314067241'; // WB 20200703
const rightSidebar = '#publish-content-form_759123566'; // WB 20200703
const header = '#publish-content-form_131377915'; // WB 20200703


module.exports = {
    header: `${header}`,
    // headerTitle: '#publish-research-form_56855288',
    headerTitle: '#publish-content-form_56855288', // WB 20200703
    // headerMessage: '#publish-research-form_971651506',
    headerMessage: '#publish-content-form_971651506', //WB 20200703
    // headerDividerLine: '#publish-research-form_334047193 hr',
    headerDividerLine: '#publish-content-form_334047193 hr',// WB 20200703
    submitButton: '#publishSubmitLowerLeft',
    submitAndAddAnotherButton: '#publishAndSubmitAnother',
    cancelButton: '#cancelPublish',
    // closeButton: '#publish-research-form_406816460',
    closeButton: '#publish-content-form_406816460', //WB 20200703
    resubmitButton: '.mos-o-form-input-field > button',
    // saveDraftButton: '#publish-research-form_saveDraft_41165451',
    saveDraftButton: '#publish-content-form-action-buttons_save-draft_41165451', //WB 20200703
    // saveDraftButtonIcon: '#publish-research-form_735287367',
    saveDraftButtonIcon: '#publish-content-form-action-buttons_735287367', //WB 20200703
    previewButton: '#publish-research-form_preview_56165121',
    previewButtonIcon: '#publish-research-form_preview_56165121 > mercer-icon',

    headerInfoIcon: '#pendo-image-badge-2bcf202b',
    infoPopup: '#pendo-guide-container',
    infoPopupMessageText: '#pendo-code-ac691209 p',
    infoPopupHereLink: '#pendo-code-ac691209 p a',
    infoPopupCloseIcon: '#pendo-close-guide-c4b527b2',
    infoPopupOkButton: '#pendo-button-453fe165' ,

    titleField: '#titleField',
    titleFieldLabel: '[for="titleField"]',
    executiveSummaryField: '#excerptField',
    // executiveSummaryFieldLabel: '#publish-research-form_734721963',
    executiveSummaryFieldLabel: '#publish-content-form-content-block_734721963',//WB 20200703
    uploadPDFDropzone: `${leftSidebar} #attachmentField`,
    uploadPDFDropzoneMessage: `${leftSidebar} #attachmentField [class*=dropzone__upload-message]`,
    uploadPDFDropzoneIcon: `${leftSidebar} #attachmentField mercer-icon`,
    uploadPDFFieldInput: `${leftSidebar} #attachmentField input`,
    uploadPDFFieldLabel: `${leftSidebar} [for="attachmentField"]`,
    attachedPDFLabelsList: `[id^=publish-research-form_attachment_] mercer-chip span`,
    // attachedPDFRemoveIconsList: `[id^=publish-research-form_attachment_] mercer-chip mercer-icon` //Egle 20200902
    attachedPDFRemoveIconsList: `[id="publish-content-form-content-block_413142645"] mercer-chip mercer-icon`,
    // removeAttachmentsLink: '#publish-research-form_647111537', //WB 20200703
    removeAttachmentsLink: '#publish-content-form-content-block_647111537',
    linkToContent: '#contentUrlField',
    linkToContentLabel: '[for="contentUrlField"]',
    fullPostContent: 'div[quill-editor-element]',
    fullPostContentEditor: '#contentField .ql-editor',
    fullPostContentField: '#contentField p',
    fullPostContentFieldLabel: '[for="contentField"]',

    // dateLabel: '#publish-research-form_558266956',
    dateLabel: '#publish-content-form-article-post-info_558266956',//WB 20200703
    // dateFieldLabel: 'mercer-datepicker .mos-c-datepicker__input-date-label',
    dateFieldLabel: '#publish-content-form-article-post-info_496429311',//Lin 20200901
    dateFieldValue: 'mercer-datepicker .mos-c-datepicker__input-date span',
    datePickerIcon: 'mercer-datepicker mercer-icon',
    researchTypeDropdownField: '#researchType',
    researchTypeDropdownFieldLabel: '[for="researchType"]',
    researchTypeOptionsList: '#researchType option',
    mercerCompaniesAutocompleteField: '#companies-autocomplete_autocomplete input',
    mercerCompaniesAutocompleteFieldLabel: '[for="company"]',
    mercerCompaniesAutocompleteItem: '.mos-c-autocomplete__list a',
    taxonomiesDropdownFieldLabel: '[for="taxonomies"]',
    taxonomiesDropdownField: '#taxonomies select',
    taxonomiesOptionsGroupsList: '#taxonomies select optgroup',
    taxonomiesDisabledOptionsGroupsList: '#taxonomies select optgroup[disabled]',
    taxonomiesOptionsList: '#taxonomies select option',
    taxonomiesDisabledOptionsList: '#taxonomies select option[disabled]',
    taxonomiesSelectedOptionsList: 'mercer-taxonomy-form mercer-chip div',
    taxonomiesRemoveIconsList: 'mercer-taxonomy-form mercer-chip div mercer-icon',
    tagsFieldLabel: '[for="tagField"]',
    tagsField: '#tagField input',
    tagsAutoCompleteItem: '.mos-c-autocomplete__list a',
    tagsSelectedList: 'mercer-tag-chip-autocomplete mercer-chip div',
    tagsRemoveIconsList: 'mercer-tag-chip-autocomplete mercer-chip div mercer-icon',
    numberOfMinutesField: '#read_time',
    numberOfMinutesFieldLabel:'[for="readTimeField"]',
    // calculateButton: '#publish-research-form_111049253',
    calculateButton: '#publish-content-form-read-time_111049253',//WB 20200703
    featuredImageDropzone: `${rightSidebar} #attachmentField`,
    featuredImageDropzoneMessage: `${rightSidebar} #attachmentField [class*=dropzone__upload-message]`,
    featuredImageDropzoneIcon: `${rightSidebar} #attachmentField mercer-icon`,
    featuredImageFieldInput: `${rightSidebar} #attachmentField input`,
    uploadedFeaturedImage: `#publish-research-form_949791479`,
    removeUploadedFeaturedImageIcon: `#publish-research-form_312295388 > mercer-icon`,
    // removeUploadedFeaturedImageIcon: `#publish-content-form_312295388 mercer-icon`,//WB 20200703
    videoLinkField: '#videoLinkField',
    videoLinkFieldLabel: '[for="videoLinkField"]',
    // regionRowsList: '#publish-research-form_413012465 li',
    regionRowsList: '[id*=region-form]',
    regionCheckBoxInputsList: '[id*=regionField-]',
    regionCheckBoxLabelsList: '[for*=regionField-]',
    targetAudienceRowsList:  '[id^=target-audience-form_role_]',
    targetAudienceCheckBoxInputsList: '[id*=roleField-]',
    targetAudienceCheckBoxLabelsList: '[for*=roleField-]',
    authorField: '#authorField',
    authorFieldLabel: '[for="authorField"]',
    rightSidebarAccordionIcon: `${rightSidebar} mercer-accordion .mos-c-accordion__icon`,
    rightSidebarAccordionHeadersList: `${rightSidebar} mercer-accordion .mos-c-accordion__header`,
    rightSidebarAccordionHeadersTextsList: `${rightSidebar} mercer-accordion .mos-c-accordion__header .row`,
};
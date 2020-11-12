
const incompleteFormPopupContainer = 'mercer-submission-error-modal';

module.exports = {
    headerText: `${incompleteFormPopupContainer} h4`,
    bodyText: `${incompleteFormPopupContainer} .mos-c-modal__content`,
    bodyTextItem: `${incompleteFormPopupContainer} .mos-c-modal__content li`,
    okButton: `${incompleteFormPopupContainer} .mos-c-modal__footer button`,
    closeButton: `div[class=mos-c-modal-wrapper] div:not([class*=mos-c-modal__header]) > div > button.mos-c-modal__close`
};
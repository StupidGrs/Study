const Calendar = "div.mos-c-calendar";
const Footer = "div.mos-c-modal__footer";

module.exports = {
    "calendarBox": Calendar,
    "year": `${Calendar} .row:nth-child(1) select`,
    "yearsList": `${Calendar} .row:nth-child(1) select option`,
    "nextMonthButton": `${Calendar} .row:nth-child(1) button[icon='keyboard_arrow_right']`,
    "previousMonthButton": `${Calendar} .row:nth-child(1) button[icon='keyboard_arrow_left']`,
    "month": `${Calendar} .row:nth-child(2) select`,
    "monthsList": `${Calendar} .row:nth-child(2) select option`,
    "daysList": `${Calendar} table tbody td a`,
    "todaysDay": `${Calendar} table tbody td.mos-c-calendar--today`,
    "cancelButton": `${Footer} div div:nth-child(1)`,
    "continueButton": `${Footer} div div:nth-child(2)`
};
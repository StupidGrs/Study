const moment = require("moment");
/**
    * Return date in MM.DD.YYYY format for UK timezone
    * @returns {string} DateString
    */
const getCurrentDateWithDotSeparation = () => {
  const date = new Date();
  const options = { year: 'numeric', month: '2-digit', day: '2-digit', timeZone: 'Europe/London' };
  const currentDate = date.toLocaleDateString('en-UK', options);

  return currentDate.replace(/\//g, '.');
};

const getDateInZuluFormat = (date) => {
  return moment(date).utc().format('YYYY-MM-DDTHH:mm:ss.SSS[Z]');
};

const extractDate = (date) => {
  if (moment(date).isValid()) {
    date = moment(date).format('MM/DD/YYYY');
  } else {
    date = moment(date, 'DD/MM/YYYY').format('MM/DD/YYYY');
  };

  return date;
};

module.exports = {
  getCurrentDateWithDotSeparation,
  getDateInZuluFormat,
  extractDate
};
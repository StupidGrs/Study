const path = require('path');
const fs = require('fs');
const { elementHelper } = require('ngpd-merceros-testautomation-ta');
const XLSX = require('xlsx');

const getListOfElementsByCss = (value) => {
  const elem = element.all(by.css(value));
  return elem;
};

const textFromFileComporator = (text) => {
  if (typeof text !== "object" && text.indexOf('TEXT:') >= 0) {
    const filePath = text.split('TEXT:').pop();
    const mes = require(`${path.resolve(`src/data/texts/${filePath}`)}`);
    return mes.message;
  } else {
    return text;
  }
};

const getFileDetailsForUpload = (filename) => {
  const fileToUpload = './../../test-data/file-templates/' + filename;
  const absolutePath = path.resolve(__dirname, fileToUpload);
  const attachment = {
    value: fs.createReadStream(absolutePath),
    options: {
      'filename': filename
    }
  };

  return attachment;
};

const getElementText = async (cssLocator) => {
  const element = await elementHelper.getElementByCss(cssLocator);
  const inputOrText = await element.getTagName();
  let elementText;
  // inputs don't have text, only value
  if (inputOrText === 'input' || inputOrText === 'select') {
    elementText = await element.getAttribute('value');
  } else {
    elementText = await element.getText();
  };

  return elementText;
};

const shuffleArr = (arr) => {
  let tempArr = arr.slice();
  for (let i = tempArr.length - 1; i > 0; i--) {
    const j = Math.floor(Math.random() * (i + 1));
    [tempArr[i], tempArr[j]] = [tempArr[j], tempArr[i]];
  };
  return tempArr;
};

const saveJsonToXlsx = async (jsonData, headers, fname) => {
  const dir = path.join(process.cwd(), 'reports', 'xlsx');
  const filename = `${fname}_${Date.now()}.xlsx`;

  if (!fs.existsSync(dir)) {
    fs.mkdirSync(dir);
  };

  const wb = XLSX.utils.book_new();
  const ws = XLSX.utils.json_to_sheet(jsonData, { header: headers });
  XLSX.utils.book_append_sheet(wb, ws, "Company Search");
  const content = XLSX.write(wb, { type: 'buffer', bookType: 'xlsx', bookSST: true });
  try {
    fs.writeFileSync(path.join(dir, filename), content);
  } catch (err) {
    console.error(err);
  };

  return filename;
};

module.exports = {
  getListOfElementsByCss,
  textFromFileComporator,
  getFileDetailsForUpload,
  getElementText,
  shuffleArr,
  saveJsonToXlsx
}
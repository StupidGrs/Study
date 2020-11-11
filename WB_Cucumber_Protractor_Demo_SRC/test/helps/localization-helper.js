/**
 * Return translated text from storage.json by English translation from json.
 *
 * @param searchingValue array
 * @returns {string}
 */
const getLocalizationFromStorage = (searchingValue) => {
  searchingValue = searchingValue.trim();
  let result = null;
  if (JSON.stringify(global.localizationMap) === '{}') { // check if global.localizationMap contain data
    throw new Error('No any translations data in localizationMap.json file'); // check localization-storage.json file
  } else if (global.localizationMap.allLanguageItems) {
    const currentTranslationsArray = global.localizationMap.allLanguageItems;
    let flag = false; // boolean flag that will be set as 'true' when translation will be found 
    currentTranslationsArray.forEach(currentTranslation => {
      if (!flag) { // when variable flag is 'true' - we don't need to check that value in other files. 
        result = _translationSearcher(currentTranslation, searchingValue);
        if (result) {
          flag = true;
          return result.trim();
        }
      }
    });
    if (!result) {
      if (/\s\d+\s/.test(searchingValue) || /\(\d+\)/.test(searchingValue)) {
        return _translateConstructor(searchingValue, currentTranslationsArray);
      }
      return searchingValue;
    }
    return result;
  } else {
    throw new Error('No such LOCALIZATION available in storage');
  }
};

/**
 * Private function that will be used if translated value should be concatenated from the few values in the File
 * For example: Pagination ('1 of 10 from 350') - 'of' and 'from' are storaged in the file in different items
 * @param {String} searchingValue String that should be translated by concatenation from the few values in the File
 * @param {Array} currentTranslation Array with current translation items
 */
const _translateConstructor = (searchingValue, currentTranslationsArray) => {
  const arrayFromBrokenTestString = searchingValue.split(' ');
  const searchingStringWithoutNumbers = searchingValue.replace(/\(\d+\)/gi, '').trim();
  let partialFlag = false;
  let finalTranslatedValue = '';

  arrayFromBrokenTestString.forEach(item => {
    let translatedValue;
    let flag = false; // boolean flag that will be set as 'true' when translation will be found 
    currentTranslationsArray.forEach(currentTranslation => {
      if (!flag) { // when variable flag is 'true' - we don't need to check that value in other files.
        for (let curRow of currentTranslation) {
          let englishTranslationFromFile = curRow[1];
          if (curRow[1]) {
            const flag = englishTranslationFromFile.match(`^${item}$`);
            const oneMoreFlag = englishTranslationFromFile.match(`^${searchingStringWithoutNumbers}$`);

            if (oneMoreFlag) {
              finalTranslatedValue = curRow[2] ? searchingValue.replace(searchingStringWithoutNumbers, curRow[2]) : item;
              partialFlag = true;
              return;
            } else if (partialFlag) {
              return;
            } else if (flag) {
              translatedValue = curRow[2] ? curRow[2] : item;
              break;
            }
          }
        }
        if (translatedValue) {
          flag = true;
        }
      }
    });
    if (partialFlag) {
      return;
    }
    finalTranslatedValue += translatedValue ? ` ${translatedValue}` : ` ${item}`;
  });

  return finalTranslatedValue.trim();
};

/**
* Private function that are going throught given array of translations and 
* match updated given String value in English to the English value from the file
* @param {Array} arrayWithCurrentTranslations Array with all translations from the 1 current file
* @param {String} searchingValue String value from the test step
*/
const _translationSearcher = (arrayWithCurrentTranslations, searchingValue) => {
  let result;
  for (let curRow of arrayWithCurrentTranslations) {
    if (curRow[1]) {
      let englishTranslationFromFile = curRow[1];
      let updatedEnglishTranslationFromFile = englishTranslationFromFile
        .replace(/\./gi, '\\.')
        .replace(/\(/gi, '\\(')
        .replace(/\)/gi, '\\)')
        .replace(/\?/gi, '\\?')
        .replace(/\:/gi, '\\:')
        .replace(/\|/gi, '\\|')
        .replace(/\+/gi, '\\+')
        .replace(/\-/gi, '\\-')
        .replace(/\$/gi, '\\$')
        .replace(/<strong>/gi, '')
        .replace(/<\/strong>/gi, '')
        .replace(/<strong>/gi, '')
        .replace(/<\/ strong>/gi, '')
        .replace(/<div>/gi, '')
        .replace(/<\/div>/gi, '')
        .replace(/<div>/gi, '')
        .replace(/<\/ div>/gi, '')
        .replace(/<ul>/gi, '')
        .replace(/<\/ ul>/gi, '')
        .replace(/<\/ul>/gi, '')
        .replace(/<li>/gi, '')
        .replace(/<\/ li>/gi, '')
        .replace(/<\/li>/gi, '')
        .replace(/<h4>/gi, '')
        .replace(/<\/ h4>/gi, '')
        .replace(/<\/h4>/gi, '')
        .replace(/<p>/gi, '')
        .replace(/{{(\s\w+\s|\w+)}}/gi, '(.+)');

      const matchingArray = searchingValue.match(`^${updatedEnglishTranslationFromFile}$`);

      if (matchingArray) { // find the row where English translation will match giving REGEXP
        let localizationTextFromFile = curRow[2];
        if (!localizationTextFromFile) {
          result = searchingValue;
          return result;
        }
        if (localizationTextFromFile.includes('{{')) {
          result = _stringWithDynamicVariablesTranslator(localizationTextFromFile, englishTranslationFromFile, matchingArray);
        } else {
          result = curRow[2]; // get translated text fo current row
        }
        return result
          .replace(/<strong>/gi, '')
          .replace(/<\/strong>/gi, '')
          .replace(/<strong>/gi, '')
          .replace(/<\/ strong>/gi, '')
          .replace(/<div>/gi, '')
          .replace(/<\/div>/gi, '')
          .replace(/<div>/gi, '')
          .replace(/<\/ div>/gi, '')
          .replace(/<ul>/gi, '')
          .replace(/<\/ ul>/gi, '')
          .replace(/<\/ul>/gi, '')
          .replace(/<li>/gi, '')
          .replace(/<\/ li>/gi, '')
          .replace(/<\/li>/gi, '')
          .replace(/<h4>/gi, '')
          .replace(/<\/ h4>/gi, '')
          .replace(/<\/h4>/gi, '')
          .replace(/<p>/gi, '');
      }
    }
  }
};

/**
* Private function that is working on translation value that contains dynamic variables
* @param {String} localizationTextFromFile String with translated value from the file
* @param {String} englishTranslationFromFile String with English translation from the file
* @param {Array} matchingArray Array after matching searching English value with English value from the file
*/
const _stringWithDynamicVariablesTranslator = (localizationTextFromFile, englishTranslationFromFile, matchingArray) => {
  let result;
  let flag = 1;
  localizationTextFromFile = localizationTextFromFile
    .replace(/{ /gi, '{')
    .replace(/ }/gi, '}');
  englishTranslationFromFile = englishTranslationFromFile
    .replace(/{ /gi, '{')
    .replace(/ }/gi, '}');

  const arrayFromLocalizationText = localizationTextFromFile.split(/\s|{|}|\.\s|\.|\。|\。\s|:\s|-\s|：|,\s|\?\s|'\s|\(\s|\(|\)\s|\（\s|\（|\）\s|\）/);
  const arrayFromEnglishText = englishTranslationFromFile.split(/\s|\{\s|\s\}|\.\s|\.|\。|\。\s|:\s|-\s|：|,\s|\?\s|'\s|\(\s|\(|\)\s|\（\s|\（|\）\s|\）/);
  const objectWithDynamicVariables = {};
  let final = localizationTextFromFile;

  arrayFromEnglishText.forEach((item) => {
    if (item.includes('{{') && item.includes('}}')) {
      const key = item.replace(' ', '').replace(/{/gi, '').replace(/}/gi, '').replace(/\)/gi, '');
      objectWithDynamicVariables[key] = matchingArray[flag];
      flag += 1;
    }
  });

  arrayFromLocalizationText.forEach((item, index) => {
    if (arrayFromLocalizationText[index - 1] === '' && arrayFromLocalizationText[index + 1] === '' && item !== '') {
      const key = item.replace(' ', '');
      if (objectWithDynamicVariables[key]) {
        final = final.replace(item, objectWithDynamicVariables[key]);
      }
    }
  });
  result = final
    .replace(/{/gi, '')
    .replace(/}/gi, '')
    .replace(/<strong>/gi, '')
    .replace(/<\/strong>/gi, '')
    .replace(/<strong>/gi, '')
    .replace(/<\/ strong>/gi, '')
    .replace(/<div>/gi, '')
    .replace(/<\/div>/gi, '')
    .replace(/<div>/gi, '')
    .replace(/<\/ div>/gi, '')
    .replace(/<ul>/gi, '')
    .replace(/<\/ ul>/gi, '')
    .replace(/<\/ul>/gi, '')
    .replace(/<li>/gi, '')
    .replace(/<\/ li>/gi, '')
    .replace(/<\/li>/gi, '')
    .replace(/<h4>/gi, '')
    .replace(/<\/ h4>/gi, '')
    .replace(/<\/h4>/gi, '')
    .replace(/<p>/gi, '');

  return result;
};

/**
*  Return translated text for current language and current unique key value, which was already generated in global allLanguageItems parameter.
*  Parser for {text} input.
*  @example
* @param text
* @returns {string}
*/
const checkLocalization = (text) => {
  const localization = browser.params.localization; // set global localization from common_config file

  if (localization) {
    if (text.includes('REGEXP:')) {
      text = text.substring(7);
    }
    return getLocalizationFromStorage(text); // get localizated text from storage for localization
  }
  return text;
}

module.exports = {
  getLocalizationFromStorage,
  checkLocalization
};
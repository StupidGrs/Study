const fs = require('fs');
const path = require('path');
const { Then } = require('cucumber');
const chai = require('chai');
const chaiAsPromised = require('chai-as-promised');
chai.use(chaiAsPromised);
const expect = chai.expect;

const screenshotHelper = require('../../helps/screenshot-helper');
const elementHelper = require('../../helps/element-helper.js');

const DELIMITER = browser.params.DELIMITER || '===DELIMITER===';
const SCREENSHOTS_DIRNAME = browser.params.SCREENSHOTS_DIRNAME || 'screenshots';
const failedScreenshots_tempFileName = browser.params.failedScreenshots_tempFileName || path.join(process.cwd(), 'failedScreenshots.txt');

// screenshots should be stored in subfolder 'screenshots' of the same folder as .feature file
// |
// release0 |
//          |
//          screenshots |
//                      |
//                      platformName |
//                                   |
//                                   browserName |
//                                               |
//                                               216_cohortDetail.png
//          |
//          someName.feature

// EXAMPLE:
// Then User compares screenshot of Cohort detail "payGapsPage|actionPanel|cohortDetail" to "216_cohortDetail.png"

// Then('User compares screenshot of {detail} {css} to {string}', async function (_, cssSelector, fileName) {
//   const world = this;
//   const platformName = await screenshotHelper.getPlatformName();
//   const browserName = await screenshotHelper.getBrowserName();
//   const elem = await elementHelper.getElementByCss(cssSelector);
//   const actualImg = await screenshotHelper.takeElementScreenshot(elem);
//   const screenshotsDir = path.join(process.cwd(), this.testLocation, SCREENSHOTS_DIRNAME);
//   const screenshotsDir_platformName = path.join(screenshotsDir, platformName);
//   const screenshotsDir_browserName = path.join(screenshotsDir_platformName, browserName);
//   const expectedImgFilePath = path.join(screenshotsDir_browserName, fileName);
//
//   // create dir for screenshots if doesn't exist
//   if (!fs.existsSync(screenshotsDir)) fs.mkdirSync(screenshotsDir);
//   if (!fs.existsSync(screenshotsDir_platformName)) fs.mkdirSync(screenshotsDir_platformName);
//   if (!fs.existsSync(screenshotsDir_browserName)) fs.mkdirSync(screenshotsDir_browserName);
//
//   // if no expected screenshot - save new as expected
//   if (!fs.existsSync(expectedImgFilePath)) {
//     fs.writeFileSync(expectedImgFilePath, actualImg, 'base64');
//
//     const error = new Error(`No EXPECTED screenshot found. Saved new as expected: ${expectedImgFilePath}`);
//     error.softAssert = true;
//
//     world.attach(actualImg, 'image/png');
//
//     throw error;
//   }
//
//   const expectedImg = fs.readFileSync(expectedImgFilePath);
//   const diff = screenshotHelper.compareScreenshots(actualImg, expectedImg);
//
//   const actualImgFileName = path.basename(expectedImgFilePath, path.extname(expectedImgFilePath)); // trim extenshion from filename
//   const actualImgFilePath = path.join(screenshotsDir_browserName, `${actualImgFileName}__actualScreenshot.png`);
//   const diffImgFilePath = path.join(screenshotsDir_browserName, `${actualImgFileName}__diff.png`);
//
//   try {
//     expect(diff, 'screenshots don\'t match').to.be.false;
//     // remove actual and diff screenshots if test passed
//     if (fs.existsSync(actualImgFilePath)) fs.unlinkSync(actualImgFilePath);
//     if (fs.existsSync(diffImgFilePath)) fs.unlinkSync(diffImgFilePath);
//   } catch (assertionError) {
//     // save actual screenshot
//     fs.writeFileSync(actualImgFilePath, actualImg, 'base64');
//
//     // save diff screenshot
//     fs.writeFileSync(diffImgFilePath, diff);
//
//     // save results to file for easier update
//     // TODO: add button 'replace expected screenshot' to reporter
//     const imgDataToSave = {
//       name: fileName,
//       browser: browserName,
//       path: expectedImgFilePath
//     };
//
//     fs.appendFileSync(failedScreenshots_tempFileName, JSON.stringify(imgDataToSave, null, 2) + DELIMITER);
//
//     // attach screenshots to reporter
//     world.attach(expectedImg, 'image/png');
//     world.attach(actualImg, 'image/png');
//     world.attach(diff, 'image/png');
//
//     assertionError.softAssert = true;
//     throw assertionError;
//   }
// });

/**
 * Here will be application specific action step methods.
 *
 * Next ngpd-merceros-testautomation-ta can be helpful, add them to project if needed:
 * fileHelper -> contains methods to work with files.
 * stringHelper -> contains methods to work with string.
 * endpointHelper -> contains methods to work with GET & POST requests.
 */
require('../support/parameter-types');
const { When } = require('cucumber');
const { elementHelper } = require('ngpd-merceros-testautomation-ta');
const loginPage = require('../../data/page-selectors/login-page');
const mssoLoginPage = require('../../data/page-selectors/msso-login-page');
const path = require('path');
const { setDefaultTimeout } = require('cucumber');
const yargs = require("yargs").argv;
const BROWSER = process.env.BROWSER_NAME ? process.env.BROWSER_NAME : (yargs.BROWSER_NAME || 'chrome');
const newsPage = require('../../data/page-selectors/news-page');
const contentListPage = require('../../data/page-selectors/content-list-page');
const header = require('../../data/page-selectors/header');
const navigation = require('../../data/page-selectors/navigation');
const userData = require('../../data/user-data');
const chai = require('chai');
const expect = chai.expect;
const api_requests = require('../step-definitions/utils/api_requests');

let total_runs = 0;
let success_runs = 0;
let failed_runs = 0;

When('User {user} cyclepits with News Bug for {int} hours', async function (user, executionHours) {
  //await browser.waitForAngularEnabled(true);
  //local news title
  //const newsTitle = 'Why Economic Slowdown Continues';
  //const newsId = '5d162aafbff5fc001d151cab';
  //stage news title
  // const newsTitle = 'Does Weakness In Job Openings Foreshadow Recession?';
  // const newsId = '5d7a6cc53378e5001e4ed7d3';
  //new stage news
  const newsTitle = 'The pros and cons of currency hedging';
  const newsId = '5d68b64873ab5c001d627827';
  //user logs in
  const password = user.password;
  const email = user.email;
  const environment = browser.params.env;
  const loginUrl = userData.urls.ENV[environment] + userData.urls.LOGIN_PAGE;
  await browser.get(loginUrl);
  await (await elementHelper.getElementByCss(loginPage.emailInput)).sendKeys(email);
  const submit = await elementHelper.getElementByCss(loginPage.submitButton);
  await elementHelper.clickOnElement(submit);
  await (await elementHelper.getElementByCss(loginPage.passwordInput)).sendKeys(password);
  await elementHelper.clickOnElement(submit);

  const startTime = Date.now();
  const executionTimeInMs = executionHours * 60 * 60000;
  while ((Date.now() - startTime) < executionTimeInMs) {
    try {
      total_runs = total_runs + 1;
      console.log(new Date().toISOString() + ' Run #' + total_runs);
      await browser.navigate().refresh();
      //set news status = Waiting for approval using API requests
      await api_requests.setAuthorizationHeader(user);
      await api_requests.setApprovalStatus(user, 'blog/news post', newsId, 'pending');
      //click settings button
      const settingsBtn = await elementHelper.getElementByCss(header.settingsButton);
      await elementHelper.clickOnElement(settingsBtn);
      //click Moderate Content
      const moderateContentBtn = await elementHelper.getElementByCssContainingText(header.settingsItemsList, 'Moderate Content');
      await elementHelper.clickOnElement(moderateContentBtn);
      await browser.sleep(3000);
      //select Waiting for approval status filter
      const statusDropdown = await elementHelper.getElementByCss(contentListPage.articleStatusDropdown);
      await elementHelper.clickOnElement(statusDropdown);
      const waitingStatus = await elementHelper.getElementByCssContainingText(contentListPage.articleStatusDropdownOptionsList, 'Waiting for approval');
      await elementHelper.clickOnElement(waitingStatus);
      //enter news title in search field
      const contentListSearchField = await elementHelper.getElementByCss(contentListPage.searchContentField);
      await elementHelper.clearTextFromElement(contentListPage.searchContentField);
      await contentListSearchField.sendKeys(newsTitle);
      await browser.sleep(3000);
      //find row in the results that contains title
      const watingForApproveRow = await elementHelper.getElementByCssContainingText(contentListPage.tableRowsList, newsTitle);
      //click Approve button
      const approveBtn = watingForApproveRow.element(by.css(contentListPage.tableRowApproveButtonsList));
      await elementHelper.clickOnElement(approveBtn);
      ////////////////////comment this wait - so test will fail//////////
      await browser.sleep(5000);
      //open News page
      const navigationNewsBtn = await elementHelper.getElementByCssContainingText(navigation.horizontalNavigationMenuItemsList, 'News');
      await elementHelper.clickOnElement(navigationNewsBtn);
      await browser.sleep(3000);
      //select sort by Relevance
      const sortByDropdown = await elementHelper.getElementByCss(newsPage.sortByDropdownField);
      await elementHelper.clickOnElement(sortByDropdown);
      const relevanceOption = await elementHelper.getElementByCssContainingText(newsPage.sortByDropdownFieldOptionsList, 'Relevance');
      await elementHelper.clickOnElement(relevanceOption);
      //enter news title in search field on news page
      await elementHelper.clearTextFromElement(newsPage.searchArticleAutocompleteField);
      const newsSearchField = await elementHelper.getElementByCss(newsPage.searchArticleAutocompleteField);
      await newsSearchField.sendKeys(newsTitle);
      await (await elementHelper.getElementByCss(newsPage.searchArticleAutocompleteField)).sendKeys(protractor.Key.ENTER);
      await browser.sleep(3000);
      //check if approved news is found in the list
      const approvedNews = element(by.cssContainingText(newsPage.articleTitlesList, newsTitle));
      const isApprovedNewsFound = await browser.wait(protractor.ExpectedConditions.visibilityOf(approvedNews), browser.params.timeout).then(() => true, () => false);
      if (!isApprovedNewsFound) {
        throw new Error(`Approved News is NOT visible`);
      };
      //click settings button
      await elementHelper.clickOnElement(settingsBtn);
      //click Moderate Content
      await elementHelper.clickOnElement(moderateContentBtn);
      await browser.sleep(3000);
      //select Approved filter
      await elementHelper.clickOnElement(statusDropdown);
      const approvedOption = await elementHelper.getElementByCssContainingText(contentListPage.articleStatusDropdownOptionsList, 'Approved');
      await elementHelper.clickOnElement(approvedOption);
      //enter news titile in search field
      await elementHelper.clearTextFromElement(contentListPage.searchContentField);
      await contentListSearchField.sendKeys(newsTitle);
      await browser.sleep(3000);
      //find row in the results that contains title
      const approvedRow = await elementHelper.getElementByCssContainingText(contentListPage.tableRowsList, newsTitle);
      //click Unapprove
      const unapproveBtn = approvedRow.element(by.css(contentListPage.unapproveButtonsList));
      await elementHelper.clickOnElement(unapproveBtn);
      await browser.sleep(5000);
      //open News page
      await elementHelper.clickOnElement(navigationNewsBtn);
      await browser.sleep(3000);
      //select sort by Relevance
      await elementHelper.clickOnElement(sortByDropdown);
      await elementHelper.clickOnElement(relevanceOption);
      //enter news title in search field on news page
      await elementHelper.clearTextFromElement(newsPage.searchArticleAutocompleteField);
      await newsSearchField.sendKeys(newsTitle);
      await (await elementHelper.getElementByCss(newsPage.searchArticleAutocompleteField)).sendKeys(protractor.Key.ENTER);
      await browser.sleep(3000);
      //check if unapproved news is not found in the list
      const unapprovedNews = element(by.cssContainingText(newsPage.articleTitlesList, newsTitle));
      const isUnapprovedNewsFound = await browser.wait(protractor.ExpectedConditions.visibilityOf(unapprovedNews), browser.params.timeout).then(() => true, () => false);
      if (isUnapprovedNewsFound) {
        throw new Error(`Unapproved News is visible`);
      } else {
        success_runs = success_runs + 1;
        console.log(new Date().toISOString() + ' Run #' + total_runs + ' passed');
        console.log(new Date().toISOString() + ' Total passed runs:' + success_runs);
      };
    }
    catch (error) {
      failed_runs = failed_runs + 1;
      console.log(new Date().toISOString() + ' Test_Error: ', error);
      console.log(new Date().toISOString() + ' Run #' + total_runs + ' failed');
      console.log(new Date().toISOString() + ' Total failed runs:' + failed_runs);
    };
  };
}); 
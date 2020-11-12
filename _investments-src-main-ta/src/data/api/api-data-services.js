const countriesApi = require("./services/country-api-data");
const feature1_test_data = require("../../features/api/api-test-data/feature-api-test-data");
const articlesApi = require("./services/articles-api-data");
const loginApi = require("./services/login-api-data");
const eventsApi = require("./services/events-api-data");
const taxonomiesApi = require("./services/taxonomies-api-data");
const personalprofilesApi = require("./services/personalprofiles-api-data");
const moderationContentApi = require("./services/moderation-content-api-data");
const regionsApi = require("./services/regions-api-data");
const companiesApi = require("./services/companies-api-data");
const userRolesApi = require("./services/userroles-api-data");

module.exports = {
  services: {
    countries: countriesApi.getAllCountries,
    countryDelete: countriesApi.deleteCountry,

    addNewCountryFeature1: feature1_test_data.addNewCountriesSprint1Feature1,
    renameCountryFeature1: feature1_test_data.renameCountrySprint1Feature1,
    deleteCountryFeature1: feature1_test_data.deleteCountrySprint1Feature1,
    
    getArticles: articlesApi.getArticlesStrapi,
    getUserArticles: articlesApi.getUserArticles,
    updateArticles: articlesApi.updateArticle,
    deleteArticles: articlesApi.deleteArticleStrapi,
    getLeadStories: articlesApi.getLeadStories,
    createResearch: articlesApi.createResearch,
    deleteResearch: articlesApi.deleteArticleStrapi,
    createNews: articlesApi.createNews,
    deleteNews: articlesApi.deleteArticleStrapi,

    getEvents: eventsApi.getEventsStrapi,
    updateEvents: eventsApi.updateEvent,
    deleteEvents: eventsApi.deleteEventStrapi,
    createEvents: eventsApi.createEvent,

    getTaxonomies: taxonomiesApi.getTaxonomies,
    getRegions: regionsApi.getRegions,
    getCompanies: companiesApi.getCompanies,
    getCompanyContent: companiesApi.filterContent,

    getCurrentUserProfile: personalprofilesApi.getCurrentUserProfile,
    updateCurrentUserProfile: personalprofilesApi.updateCurrentUserProfile,
    followCompany: personalprofilesApi.followCompany,
    unfollowCompany: personalprofilesApi.unfollowCompany,
    rateArticle: personalprofilesApi.rateArticle,
    bookmarkArticle: personalprofilesApi.bookmarkArticle,
    getUsers: personalprofilesApi.getUsers,
    updateUser: personalprofilesApi.updateUser,

    login: loginApi.skipLogin,

    setContentStatus: moderationContentApi.setStatus,

    getResearchModerateFormData: moderationContentApi.getResearch,
    getNewsModerateFormData: moderationContentApi.getNews,
    getEventModerateFormData: moderationContentApi.getEvent,

    moderateResearch: moderationContentApi.updateResearch,
    moderateNews: moderationContentApi.updateNews,
    moderateEvent: moderationContentApi.updateEvent,

    markAsCompanyFeatured: articlesApi.markAsCompanyFeatured,
    unmarkAsCompanyFeatured: articlesApi.unmarkAsCompanyFeatured,

    getUserRoles: userRolesApi.getUserRoles

  }
};
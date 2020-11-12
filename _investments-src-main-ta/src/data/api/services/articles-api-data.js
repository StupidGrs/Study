const dbDataAccess = require('../dbDataAccess');
const researchArticleData = require('../requestTemplates/postResearch');
const newsArticleData = require('../requestTemplates/postNews');

module.exports = {

  getArticlesStrapi: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_STRAPI}, {
    method: "GET",
    path: '/articles',
  }),

  getUserArticles: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "GET",
    path: '/articles/currentUser',
  }),

  createResearch: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "POST",
    path: '/articles/form',
    formData: `content: ${JSON.stringify(researchArticleData)}`,
    articleData: researchArticleData
  }),

  updateArticle: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "PUT",
    path: '/articles/form',
  }),

  deleteArticleStrapi: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_STRAPI}, {
    method: "DELETE",
    path: '/articles/',
  }),

  createNews: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "POST",
    path: '/articles/form',
    formData: `content: ${JSON.stringify(newsArticleData)}`,
    articleData: newsArticleData
  }),

  markAsCompanyFeatured: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "PATCH",
    path: '/articles/mark-as-company-featured/'
  }),

  unmarkAsCompanyFeatured: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "PATCH",
    path: '/articles/unmark-as-company-featured/'
  }),

  getLeadStories: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "GET",
    path: '/articles/lead_stories'
  }),
};
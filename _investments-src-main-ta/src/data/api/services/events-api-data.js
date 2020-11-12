const dbDataAccess = require('../dbDataAccess');
const eventData = require('../requestTemplates/postEvent');

module.exports = {

  getEventsStrapi: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_STRAPI}, {
    method: "GET",
    path: '/events',
  }),

  createEvent: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "POST",
    path: '/events/create-event-form',
    formData: `content: ${JSON.stringify(eventData)}`,
    eventData: eventData
  }),

  updateEvent: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_BE}, {
    method: "PUT",
    path: '/events',
  }),

  deleteEventStrapi: Object.assign({}, {baseUrl: dbDataAccess.baseUrl_STRAPI}, {
    method: "DELETE",
    path: '/events/',
  }),

};
/**
 * This file is represent Page Objects usage.
 * Here should be CSS selectors related to application.
 * Any desired/appropriate nesting and structure can be used.
 * Used for library tests
 */
const starsBlock = 'div.src-c-set-ratings__stars-block';

module.exports = {
    starsBlock: `${starsBlock}`,
    starsList: `${starsBlock} [id^=set-ratings_rate]`,
    star1: `#set-ratings_rate-0`,
    star2: `#set-ratings_rate-1`,
    star3: `#set-ratings_rate-2`,
    star4: `#set-ratings_rate-3`,
    star5: `#set-ratings_rate-4`,
    starHint: `div.mos-c-tooltip`,
};
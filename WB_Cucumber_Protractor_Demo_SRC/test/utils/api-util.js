const expect = require('chai').expect;
const jsonPath = require('jsonpath');
// const apiData = require('../data/api/api-data-services');
/**
 * Used for taking necessary property from given Object
 *
 * @example
 * utils.objectParser(someObject, properties)
 *
 * @param object given object which should include parsing property
 * @param valueToParse object properties nesting by "."
 */
const objectParser = (object, valueToParse) => {
  let finalProperty;

  const properties = valueToParse.split(".");

  properties.forEach(property => {
    try {
      if (!finalProperty) {
        return finalProperty = typeof object[property] === "string" ? JSON.parse(object[property]) : object[property];
      }

      return finalProperty = finalProperty[property];

    } catch (e) {
      throw new Error(`There is no such properties: '${valueToParse}' in the '${object}'`);
    }
  });

  return finalProperty;
};

const getAllNodesFromJson = (object) => {
  return jsonPath.nodes(object, "$..*");
};

const replaceValueInProperty = (object, propertyPath, newValue) => {
  if (typeof propertyPath !== "string") {
    propertyPath = jsonPath.stringify(propertyPath);
  }
  jsonPath.apply(object, propertyPath, function () {
    return newValue;
  });

  return object;
};

/**
 * Verifying that string are equals or one string contains another
 *
 * @example
 * utils.objectParser(someObject, properties)
 *
 * @param givenText text that we will compare with "comparingText"
 * @param comparingText text for comparing with "givenText"
 * @param shouldBe String value that could be equal to "be equal to" or "contain" for comparing
 */
const stringComparator = (givenText, comparingText, shouldBe) => {
  switch (shouldBe) {
    case "equal to":
      return expect(givenText).to.equal(comparingText);
    case "contain":
      return expect(givenText.includes(comparingText)).to.be.true;
    default:
      throw new Error(`Wrong ${shouldBe} was given.`);
  }
};

/**
 * Construct query string
 * @param {Object} params
 * @return {string} - generated query string
 * @example
 * query([{
 *          query: "lastName",
 *          field: "Smith"
 * }]); //will return "?lastName=Smith"
 */
const query = (params) => {
  let resultString = "?";

  params.forEach(paramQuery => {
    resultString += paramQuery.name + "=" + paramQuery.value + "&";
  });

  return resultString.slice(0, -1)
};

const addParameter = (params, paramName, newValue) => {
  let newParams = params.slice();
  const newParam = {
    name: paramName,
    value: newValue
  };
  newParams.push(newParam);

  return newParams;
};

module.exports = {
  objectParser,
  stringComparator,
  query,
  addParameter,
  replaceValueInProperty,
  getAllNodesFromJson
};
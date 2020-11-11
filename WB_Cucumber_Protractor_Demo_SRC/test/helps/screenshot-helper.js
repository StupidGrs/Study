'use strict';

const PNG = require('pngjs').PNG;
const pixelmatch = require('pixelmatch');
const Duplex = require('stream').Duplex;

function compareScreenshots(img1, img2) {
  // convert images to PNG
  const img1_png = PNG.sync.read(img1);
  const img2_png = PNG.sync.read(img2);
  // set width and height for diff image
  const diff = new PNG({ width: img1_png.width, height: img1_png.height });

  // https://www.npmjs.com/package/pixelmatch
  const numDiffPixels = pixelmatch(img1_png.data, img2_png.data, diff.data, img1_png.width, img1_png.height, {
    threshold: 0.1
  });

  if (numDiffPixels === 0) {
    return false;
  } else {
    return PNG.sync.write(diff);
  }
}

async function takeElementScreenshot(elem) {
  await scrollIntoView(elem);
  const elementCoordinates = await getLocation(elem);
  const screenshot = await browser.takeScreenshot();
  const actualImg = await crop(screenshot, elementCoordinates);

  return actualImg;
}

async function getBrowserName() {
  const capabilities = await browser.getCapabilities();
  let browserName = capabilities.get('browserName');

  if (browserName === 'chrome') {
    await browser.executeScript('return navigator.userAgent').then(userAgent => {
      if (userAgent.includes('HeadlessChrome')) {
        browserName = 'HeadlessChrome';
      }
    });
  }

  return browserName;
}

async function getPlatformName() {
  const platformName = await browser.executeScript("return window.navigator.platform");

  return platformName;
}

async function scrollIntoView(element) {
  return browser.executeScript(function (el) {
    el.scrollIntoView();
  }, element);
}

async function getLocation(element) {
  // JS gives coordinates inside viewport
  const coordinates = await browser.executeScript(
    "const clientRect = arguments[0].getBoundingClientRect();"
    + "return {"
    + "right: clientRect.right,"
    + "bottom: clientRect.bottom,"
    + "top: clientRect.top,"
    + "height: clientRect.height,"
    + "width: clientRect.width,"
    + "left: clientRect.left }",
    element);

  // add viewport dimensions
  const viewport = await browser.executeScript(function () {
    return { width: window.innerWidth, height: window.innerHeight };
  });

  if(!coordinates.width || !coordinates.height) {
    throw new Error(`Element: ${element.locator()} - does not have width or height!`);
  }

  coordinates.viewport = viewport;

  return coordinates;
}

function crop(sourceImg, elementCoordinates) {
  const { left, top, width, height, viewport } = elementCoordinates;

  if(!width || !height) {
    throw new Error('Given element does not have width or height!');
  }

  return new Promise((resolve, reject) => {
    _bufferToStream(Buffer.from(sourceImg, 'base64'))
      .pipe(new PNG())
      .on('error', function (err) {
        reject(err);
      })
      .on('parsed', function () {
        const outImg = new PNG({ width, height });
        // https://www.npmjs.com/package/pngjs#pngbitbltdst-sx-sy-w-h-dx-dy
        this.bitblt(outImg, left, top, Math.min(width, viewport.width), Math.min(height, viewport.height), 0, 0);

        resolve(PNG.sync.write(outImg.pack()));
      });
  });
}

function _bufferToStream(buffer) {
  const stream = new Duplex();
  stream.push(buffer);
  stream.push(null);

  return stream;
}

module.exports = {
  crop,
  getLocation,
  scrollIntoView,
  takeElementScreenshot,
  getBrowserName,
  compareScreenshots,
  getPlatformName
};

# My project's README

Make sure you have the latest versions of the following installed:
	Node.js,
	Java Development Kit.
Protractor requires Node and the development kit is needed for the Selenium Server.


In order to run Protractor, you will need to start the Selenium Server.
Protractor includes a webdriver-manager tool that starts up your server.

### Install Dependencies

```
npm install
```

### Start WebDriver Manager (in 1 terminal window)

```
npm run start-webdriver
```


### Run Protractor tests (in another terminal window)

####-------Run Smoke test----------
npm run test-smoke

####-----------Feature Run-----------------------
#### Before run make sure you add feature to specs in protractor.local.conf.js
#### or add appropriate tag in feature file.
npm run test-local

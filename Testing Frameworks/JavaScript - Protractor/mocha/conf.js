
exports.config = {
  //Remote address
  seleniumAddress: 'https://MY_HOST.perfectomobile.com/nexperience/perfectomobile/wd/hub',

  //Capabilities to be passed to the webdriver instance.
  capabilities: {
    browserName: 'chrome',
    //user: 'MY_USER',
    //password: 'MY_PASS',
    securityToken: 'MY_TOKEN',
    platformName: 'Android'
  },

  //Framework to use
  framework: 'mocha',

  mochaOpts: {
    timeout: 120000, // default suite timeout for Mocha is 2000ms. Most Selenium tests take longer
    slow: 3000
  },

  // Spec patterns are relative to the current working directly when
  // protractor is called.
  specs: ['spec.js'],

}
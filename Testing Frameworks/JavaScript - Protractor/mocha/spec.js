const chai = require('chai');
var chaiAsPromised = require('chai-as-promised');
chai.use(chaiAsPromised);
var expect = chai.expect;

describe('Protractor Perfecto Demo', function () {

  it('should have a title', function () {

    browser.driver.get('https://www.google.com'); //Navigate to google.com

    //Locate the search box element and insert text
    //Click on search button
    browser.driver.findElement(by.name('q')).sendKeys('PerfectoCode GitHub');
    browser.driver.findElement(by.css('#tsbb > div')).click();

    //Click the first search result
    browser.driver.findElement(by.css("#rso > div:nth-of-type(1) > div._Z1m > div:nth-of-type(1) > a._Olt._bCp")).click();

    //Assert that title equals to the expected once
    expect(browser.driver.getTitle()).to.eventually.equal('GitHub - PerfectoCode/Samples: Product Samples');
  });

});

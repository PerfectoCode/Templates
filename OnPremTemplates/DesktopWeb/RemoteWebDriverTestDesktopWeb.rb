require 'selenium-webdriver'
require 'uri'

host = 'myHost.perfectomobile.com'
token = 'myToken'

capabilities = {
  #TODO: Set the Web Machine configuration, for example:
  #Read more about the available configurations at http://developers.perfectomobile.com/display/PD/Desktop+Web+Devices

  :platformName => 'Windows',
  :platformVersion => '10',
  :browserName => 'Firefox',
  :browserVersion => 'latest',
  #TODO: Name your script
  :scriptName => 'RemoteWebDriverTest',
  :securityToken => token
}

#TODO: Set your cloud host

url = "http://" + host + "/nexperience/perfectomobile/wd/hub/fast"

#Create WebDriver
puts "Creating Remote WebDriver"
driver = Selenium::WebDriver.for(:remote, :url => url, :desired_capabilities => capabilities)
#Define driver time out
driver.manage.timeouts.implicit_wait = 30

#TODO: Write your test here
puts "Starting Test"
driver.get "http://www.google.com"

# Close Driver
puts "Test ended, closing driver"
driver.close

# Quit Driver
puts "Done, terminating Remote WebDriver"
driver.quit

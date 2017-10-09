require 'selenium-webdriver'
require 'uri'

#TODO: Set the Web Machine configuration, for example:
capabilities = {
  :browserName => 'mobileOS',
  :platform => 'ANY',

  #TODO: Set your security token
  :securityToken => 'MY_TOKEN',
  #:user => 'MY_USER',
  #:password => 'MY_PASSWORD',

  #TODO: Set Device ID
  :deviceName => 'MY_DEVICE_ID',

  #TODO: Name your script
  :scriptName => 'RemoteWebDriverTest'
}

#TODO: Set your cloud host
host = 'MY_HOST.perfectomobile.com'
url = "http://" + host + "/nexperience/perfectomobile/wd/hub"

#Create WebDriver
puts "Starting test"
driver = Selenium::WebDriver.for(:remote, :url => url, :desired_capabilities => capabilities)

#TODO: Write your test here
driver.get "http://www.perfectomobile.com"

driver.close

#In case you want to down the report or the report attachments, do it here.
#puts "Downloading report"
#command = 'mobile:report:download';
#params = {}
#params['type'] = 'pdf'
#report = driver.execute_script(command, params)
#File.open('C:/Temp/Report_' + 'ruby' + '.pdf', 'wb') { |f| f << report.unpack("m")[0] }

driver.quit
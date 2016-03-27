require 'selenium-webdriver'
require 'uri'

capabilities = {
  #TODO: Set the Web Machine configuration, for example:
  :platformName => 'Windows',
  :platformVersion => '7',
  :browserName => 'Firefox',
  :browserVersion => '42',
  
  #TODO: Set your cloud host credentials
  :user => 'MY_USER',
  :password => 'MY_PASSWORD',
  
  #TODO: Name your script
  :scriptName => 'RemoteWebDriverTest'
}

#TODO: Set your cloud host
host = 'MY_HOST.perfectomobile.com'
url = "http://" + host + "/nexperience/perfectomobile/wd/hub"

#Create WebDriver
puts "Creating Remote WebDriver"
driver = Selenium::WebDriver.for(:remote, :url => url, :desired_capabilities => capabilities)
#Define driver time out
driver.manage.timeouts.implicit_wait = 30

#TODO: Write your test here
puts "Starting Test"
driver.get "http://www.perfectomobile.com"

# Close Driver
puts "Test ended, closing driver"
driver.close

#In case you want to down the report or the report attachments, do it here.
command = 'mobile:report:download';

# In case you want to down the report or the report attachments, do it here.
#puts "Downloading report"
#params = {}
#params['type'] = 'pdf'
#report = driver.execute_script(command, params)
#File.open('report_' + 'ruby' + '.pdf', 'wb') { |f| f << report.unpack("m")[0] }

# Quit Driver
puts "Done, terminating Remote WebDriver"
driver.quit
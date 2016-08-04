require 'selenium-webdriver'
require 'uri'
require 'test/unit'

#TestingBox class 
#Here you configure the pre and post test operations
class  PerfectoTestingBox < Test::Unit::TestCase

	@@tests_count = 0 #tests counter
	@driver = nil  

	#Test initializer
	def initialize(name = nil)
		@test_name = name
		@@tests_count += 1
		super(name) unless name.nil?
	end

	#runs before each test case
	#set up your device capabilities here
	def setup 
		puts 'setup: ' + @test_name 

		#device capabilities goes here:
		capabilities = {
			:platformName => 'Android',
			:model => 'Galaxy S6', #Optional 
			:platformVersion => '', #Optional 
			:browserName => 'mobileOS', #Optional 
			:browserVersion => '', #Optional for web
			:deviceName => '' #Optional
		}

		#your host url
		host = 'MY_HOST.perfectomobile.com'

		#Your perfecto lab username and password
		capabilities['user'] = 'MY_USER'
		capabilities['password'] = 'MY_PASS' 

		@driver = Selenium::WebDriver.for(:remote, :url => "http://" + host + "/nexperience/perfectomobile/wd/hub", :desired_capabilities =>capabilities) 
	end

	#runs after each test, cleaning up the webdriver and quit
	def teardown
		puts 'teardown: '+ @test_name

		@driver.close
		@driver.quit
	end

end
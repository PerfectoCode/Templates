require_relative 'test_setup.rb'
#Here you write your tests


class MyTests < PerfectoTestingBox

	# Test class, user driver as class memeber with '@'

	def test_page_title

		#get google url
		@driver.get 'https://google.com'

		#locate search bar and send value
		@driver.find_element(:name => 'q').send_keys('PerfectoCode GitHub')

	end
	
end
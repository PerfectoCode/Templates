require_relative 'test_setup.rb'
#Here you write your tests


class MyTests < PerfectoTestingBox

	# Test class, user driver as class memeber with '@'

	def test_page_title

		#get google url
		@driver.get 'https://google.com'

		#locate search bar and send value
		@driver.find_element(:name => 'q').send_keys('PerfectoCode GitHub')

		#click search button
		@driver.find_element(:id => 'tsbb').click

		#click the first search result
		@driver.find_element(:css => '#rso > div > div:nth-child(1) > div > div > div._OXf > h3 > a').click

		#validate page title
		assert_equal('GitHub - PerfectoCode/Samples: Product Samples' , @driver.title)

	end
	
end
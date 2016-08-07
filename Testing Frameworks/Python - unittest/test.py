import unittest
from testConf import PerfectoTestBox

class testBox(PerfectoTestBox):

    #use self.driver as your testing webdriver
    #configuration and capabilities for this test class can be found at testConf.py
    def test_validate_title(self):
        #Navigate to google
        self.driver.get('https://www.google.com')

        #Searching for the search bar and sending a string
        self.driver.find_element_by_name('q').send_keys('PerfectoCode GitHub')

        #Click on the search button
        self.driver.find_element_by_class_name('sbico').click()

        #Navigate to the first search result
        self.driver.find_element_by_css_selector('#rso > div > div:nth-child(1) > div > div > div._OXf > h3 > a').click()

        #Assert title contains the word Perfecto
        assert 'Perfecto' in self.driver.title

#Main ready, run via command line with : python test.py
if __name__ == '__main__':
    unittest.main()
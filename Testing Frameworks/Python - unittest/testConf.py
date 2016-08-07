from selenium import webdriver
import unittest

class PerfectoTestBox(unittest.TestCase):

    global user, password, host, capabilities
    #Set your Perfecto Lab user, pass and host
    user = "MY_USER"
    password = "MY_PASS"    
    host = "MY_HOST.perfectomobile.com"
    
    #Set your test device capabilities
    capabilities = {
        'platformName': 'Android',
        'platformVersion': '',
        'browserName': 'mobileOS',
        'model': ''
    }

    def setUp(self):
        global user, password, host, capabilities
        capabilities['user'] = user
        capabilities['password'] = password
        self.init_driver()

    def init_driver(self):
        global host
        self.driver = webdriver.Remote('https://' + host + "/nexperience/perfectomobile/wd/hub", capabilities)

    def tearDown(self):
        self.driver.close()
        self.driver.quit()

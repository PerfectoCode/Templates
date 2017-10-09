from selenium import webdriver
import unittest

class PerfectoTestBox(unittest.TestCase):

    global user, password, host, capabilities, token
    #Set your Perfecto Lab host and security token
    token = "MY_TOKEN"
    host = "MY_HOST.perfectomobile.com"

    #user = "MY_USER"
    #password = "MY_PASS"


    #Set your test device capabilities
    capabilities = {
        'platformName': 'Android',
        'platformVersion': '',
        'browserName': 'mobileOS',
        'model': ''
    }

    def setUp(self):
        global host, capabilities, token #, user, password
        capabilities['securityToken'] = token
        #capabilities['user'] = user
        #capabilities['password'] = password
        self.init_driver()

    def init_driver(self):
        global host
        self.driver = webdriver.Remote('https://' + host + "/nexperience/perfectomobile/wd/hub", capabilities)

    def tearDown(self):
        self.driver.close()
        self.driver.quit()

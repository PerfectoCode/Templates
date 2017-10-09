from selenium import webdriver

#TODO: Set your cloud host
host = 'myHost.perfectomobile.com'
token = 'myToken'

if __name__ == '__main__' :
    print 'Run started'
    
    #TODO: Set the Web Machine configuration, for example:
    #Read more about the available configurations at http://developers.perfectomobile.com/display/PD/Desktop+Web+Devices

    capabilities = {
        'platformName'      : 'Windows',
        'platformVersion'   : '8.1',
        'browserName'       : 'Chrome',
        'browserVersion'    : 'latest',
        #TODO: Set your cloud host credentials (we recommend using a Security Token instead username and password)
        'securityToken'     : token,
        #TODO: Name your script
        'scriptName'        : 'RemoteWebDriverTest'
    }

    #Create WebDriver
    print 'Creating Remote WebDriver'
    driver = webdriver.Remote('https://' + host + '/nexperience/perfectomobile/wd/hub/fast' , capabilities)
    #Define driver time out
    driver.implicitly_wait(30)

    try:
        #TODO: Write your test here
        print 'Starting Test'
        driver.get('http://www.google.com')
    
    except Exception as e:
        print e

    finally:
        try:
            # Close Driver
            print 'Test ended, closing driver'
            driver.close()
            
        except Exception as e:
            print e
        
        # Quit Driver
        print 'Done, terminating Remote WebDriver'
        driver.quit()
 
    print 'Run ended'

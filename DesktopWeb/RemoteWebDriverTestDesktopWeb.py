from selenium import webdriver
from PerfectoLabUtils import PerfectoLabUtils

if __name__ == '__main__' :
    print 'Run started'
    
    #TODO: Set the Web Machine configuration, for example:
    capabilities = {
            'platformName'      : 'Windows',
            'platformVersion'   : '8.1',
            'browserName'       : 'Chrome',
            'browserVersion'    : '48',
            
            #TODO: Set your cloud host credentials
            'user'              : 'MY_USER',
            'password'          : 'MY_PASSWORD',
            
            #TODO: Name your script
            'scriptName'        : 'RemoteWebDriverTest'
            }
    
    #TODO: Set your cloud host
    host = 'MY_HOST.perfectomobile.com'
    
    #Create WebDriver
    print 'Creating Remote WebDriver'
    driver = webdriver.Remote('https://' + host + '/nexperience/perfectomobile/wd/hub' , capabilities)
    #Define driver time out
    driver.implicitly_wait(30)

    try:
        #TODO: Write your test here
        print 'Starting Test'
        driver.get('http://www.perfectomobile.com')
    
    except Exception as e:
        print e

    finally:
        try:
            # Close Driver
            print 'Test ended, closing driver'
            driver.close()
            params = {}
            driver.execute_script("mobile:execution:close", params)
            
            #// In case you want to down the report or the report attachments, do it here. 
            # print 'Downloading report'
            #"""
            #file_name = 'Report'
            #format = 'pdf' #report format
            #PerfectoLabUtils.download_report(driver , format , file_name)
            #"""
        except Exception as e:
            print e
        
        # Quit Driver
        print 'Done, terminating Remote WebDriver'
        driver.quit()
 
    print 'Run ended'

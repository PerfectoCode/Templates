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
            'user'              : "MY_USER",
            'password'          : "MY_PASSWORD"
            }
    
    #TODO: Set your cloud host and credentials
    host = 'MY_HOST.perfectomobile.com'
    
    #Create webdriver
    driver = webdriver.Remote('https://' + host + '/nexperience/perfectomobile/wd/hub' , capabilities)
    #Define driver time out
    driver.implicitly_wait(30)

    try:
        #TODO: Write your test here
        driver.get('http://www.perfectomobile.com')
    
    except Exception as e:
        print e

    finally:
        try:
            driver.close()
            params = {}
            driver.execute_script("mobile:execution:close", params)
            #in case you want download the report you enable this script : 
            """
            file_name = 'Report'
            format = 'pdf' #report format
            PerfectoLabUtils.download_report(driver , format , file_name)
            """
        except Exception as e:
            print e
        
        driver.quit()
 
    print 'Run ended'
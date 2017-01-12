import time

from selenium.webdriver import ActionChains
from selenium.webdriver.remote.command import Command
from selenium.webdriver.remote.mobile import Mobile

from WindTunnelUtils import WindTunnelUtils
from PerfectoLabUtils import PerfectoLabUtils
from selenium import webdriver
from perfecto import *

# For programming samples and updated templates refer to the Perfecto GitHub at: https://github.com/PerfectoCode
class RemoteWebDriverTest:
    def __init__(self):
        pass

    @staticmethod
    def main():
        print('Run started')

        capabilities = {}
        capabilities['browserName'] = "mobileOS"
        capabilities['platform'] = "ANY"
        host = "myHost.perfectomobile.com"
        capabilities['user'] = "myUser"
        capabilities['password'] = "myPassword"

        # TODO: Change your device ID
        capabilities['deviceName'] = "12345"

        # Use the automationName capability to define the required framework - Appium (default) or PerfectoMobile.
        # capabilities['automationName'] = "PerfectoMobile"

        # Call this method if you want the script to share the devices with the recording plugin.
        PerfectoLabUtils.set_execution_id_capability(capabilities, host)

        # Adds a persona to your script (see https://community.perfectomobile.com/posts/1048047-available-personas)
        #capabilities[WindTunnelUtils.WIND_TUNNEL_PERSONA_CAPABILITY] = WindTunnelUtils.GEORGIA

        # Name your script
        # capabilities['scriptName'] = "RemoteWebDriverTest"

        driver = webdriver.Remote("https://" + host + "/nexperience/perfectomobile/wd/hub", capabilities)
        driver.implicitly_wait(15)

        perfecto_execution_context = PerfectoExecutionContext(driver, ['tag1'], Job('My Job', 45), Project('My Project', '1.0'))
        reporting_client = PerfectoReportiumClient(perfecto_execution_context)

        try:
            print('Driver created')
            reporting_client.test_start('My test name', TestContext('tag2', 'tag3'))

            # write your code here

            # reporting_client.test_step('step1') # this is a logical step for reporting
            # reporting_client.test_step('step2')

            reporting_client.test_stop(TestResultFactory.create_success())
        except Exception as e:
            reporting_client.test_stop(TestResultFactory.create_failure(str(e)))
            print(e)
        finally:
            try:
                # disconnect from the Remote server
                if driver is not None:
                    # Retrieve the URL of the Single Test Report, can be saved to your execution summary and used to download the report at a later point
                    report_url = reporting_client.report_url()

                    # For documentation on how to export reporting PDF, see https://github.com/perfectocode/samples/wiki/reporting
                    # report_pdf_url = driver.capabilities['reportPdfUrl']

                    driver.close()

                    # In case you want to download the report or the report attachments, do it here.
                    # PerfectoLabUtils.download_attachment(driver, 'video', '/test/video', 'flv')
                    # PerfectoLabUtils.download_attachment(driver, 'image', '/test/image', 'jpg')

            except Exception as e:
                print(e)

            driver.quit()

        print('Run ended')

    @staticmethod
    def switch_to_context(driver, context):
        driver.execute(Command.SWITCH_TO_CONTEXT, {"name": context})

    @staticmethod
    def get_current_context_handle(driver):
        mobile = Mobile(driver)
        return mobile.context

    @staticmethod
    def get_context_handles(driver):
        mobile = Mobile(driver)
        return mobile.contexts

if __name__ == "__main__":
    RemoteWebDriverTest().main()

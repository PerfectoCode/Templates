import time

from selenium.webdriver import ActionChains
from selenium.webdriver.remote.command import Command
from selenium.webdriver.remote.mobile import Mobile

from WindTunnelUtils import WindTunnelUtils
from PerfectoLabUtils import PerfectoLabUtils
from selenium import webdriver


class RemoteWebDriverTest:
    def __init__(self):
        pass

    @staticmethod
    def main():
        print('Run started')


        host = "myHost.perfectomobile.com"
        token = "myToken"

        capabilities = {}
        capabilities['browserName'] = "mobileOS"
        capabilities['platform'] = "ANY"
        capabilities['securityToken'] = token

        #capabilities['user'] = "myUser"
        #capabilities['password'] = "myPassword"

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

        try:
            print('Driver created')
            # write your code here

        except Exception as e:
            print(e)
        finally:
            try:
                # disconnect from the Remote server
                if driver is not None:

                    driver.close()

                    # In case you want to download the report or the report attachments, do it here.
                    # PerfectoLabUtils.download_report(driver, 'pdf', '/test/report')
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

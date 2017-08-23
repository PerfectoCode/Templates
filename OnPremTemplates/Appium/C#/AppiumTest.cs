using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.MultiTouch;
using System.Threading;
using System.Collections.ObjectModel;

namespace CSharp
{
    [TestClass]
    public class AppiumTest
    {
        private AndroidDriver<IWebElement> driver;
        //private IOSDriver<IWebElement> driver;

        [TestInitialize]
        public void PerfectoOpenConnection()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities(string.Empty, string.Empty, new Platform(PlatformType.Any));

            var host = "MY_HOST.perfectomobile.com";
            var token = "MY_TOKEN";
            capabilities.SetCapability("securityToken", token);

            //Old Credentials:
            //var user = "username";
            //var password = "password";
            //capabilities.SetCapability("user", user);
            //capabilities.SetCapability("password", password);

            //TODO: Provide your device ID
            capabilities.SetCapability("deviceName", "MY_DEVICE_ID");

            // Use this method if you want the script to share the devices with the Perfecto Lab plugin.
            capabilities.SetPerfectoLabExecutionId(host);

            // Use the automationName capability to defined the required framework - Appium (this is the default) or PerfectoMobile.
            //capabilities.SetCapability("automationName", "PerfectoMobile"); 


            // Application settings examples.
            // capabilities.SetCapability("app", "PRIVATE:applications/Errands.ipa");
            // For Android:
            //capabilities.SetCapability("appPackage", "com.google.android.keep");
            //capabilities.SetCapability("appActivity", ".activities.BrowseActivity");
            // For iOS:
            // capabilities.SetCapability("bundleId", "com.yoctoville.errands");


            // Add a persona to your script (see https://community.perfectomobile.com/posts/1048047-available-personas)
            //capabilities.SetCapability(WindTunnelUtils.WIND_TUNNEL_PERSONA_CAPABILITY, WindTunnelUtils.GEORGIA);

            // Name your script
            // capabilities.SetCapability("scriptName", "AppiumTest");

            var url = new Uri(string.Format("http://{0}/nexperience/perfectomobile/wd/hub", host));
            driver = new AndroidDriver<IWebElement>(url, capabilities);
            //driver = new IOSDriver<IWebElement>(url, capabilities);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
        }

        [TestCleanup]
        public void PerfectoCloseConnection()
        {
            // Retrieve the URL of the Single Test Report, can be saved to your execution summary and used to download the report at a later point
            string reportUrl = (string)(driver.Capabilities.GetCapability(WindTunnelUtils.SINGLE_TEST_REPORT_URL_CAPABILITY));

            driver.Close();

            // In case you want to download the report or the report attachments, do it here.
            //try
            //{
            //    driver.DownloadReport(DownloadReportTypes.pdf, "C:\\test\\report");
            //    driver.DownloadAttachment(DownloadAttachmentTypes.video, "C:\\test\\report\\video", "flv");
            //    driver.DownloadAttachment(DownloadAttachmentTypes.image, "C:\\test\\report\\images", "jpg");
            //}
            //catch (Exception ex)
            //{
            //    Trace.WriteLine(string.Format("Error getting test logs: {0}", ex.Message));
            //}

            driver.Quit();
        }

        [TestMethod]
        public void AppiumTestMethod()
        {
            //Write your test here
        }
    }
}

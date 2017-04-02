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
using Reportium.test;
using Reportium.test.Result;
using Reportium.client;
using Reportium.model;

namespace PerfectoLabAppiumTestProject
{
    /// <summary>
    /// This template is for users that use DigitalZoom Reporting (ReportiumClient).
    /// For any other use cases please see the basic template at https://github.com/PerfectoCode/Templates.
    /// For more programming samples and updated templates refer to the Perfecto Documentation at: http://developers.perfectomobile.com/
    /// </summary>
    [TestClass]
    public class AppiumTest
    {
        private AndroidDriver<IWebElement> driver;
        //private IOSDriver<IWebElement> driver;
        private ReportiumClient reportiumClient;

        [TestInitialize]
        public void PerfectoOpenConnection()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities(string.Empty, string.Empty, new Platform(PlatformType.Any));

            var host = "$Cloud$";
            capabilities.SetCapability("user", "$UserName$");
            
            //TODO: Provide your password
            capabilities.SetCapability("password", "[ENTER YOUR PASSWORD HERE]");

            //TODO: Provide your device ID
            capabilities.SetCapability("deviceName", "[ENTER YOUR DEVICE ID HERE]");

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

            var url = new Uri(string.Format("http$IsConnectUsingHttps$://{0}/nexperience/perfectomobile/wd/hub",host));
            driver = new AndroidDriver<IWebElement>(url, capabilities);
            //driver = new IOSDriver<IWebElement>(url, capabilities);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));

            // Reporting client. For more details, see http://developers.perfectomobile.com/display/PD/Reporting
            PerfectoExecutionContext perfectoExecutionContext = new PerfectoExecutionContext.PerfectoExecutionContextBuilder()
                    .withProject(new Project("My Project", "1.0"))
                    .withJob(new Job("My Job", 45))
                    .withContextTags(new[] { "tag1" })
                    .withWebDriver(driver)
                    .build();
            reportiumClient = PerfectoClientFactory.createPerfectoReportiumClient(perfectoExecutionContext);
        }

        [TestCleanup]
        public void PerfectoCloseConnection()
        {
            // Retrieve the URL of the Single Test Report, can be saved to your execution summary and used to download the report at a later point
            String reportURL = reportiumClient.getReportUrl();

            // For documentation on how to export reporting PDF, see https://github.com/perfectocode/samples/wiki/reporting
            // String reportPdfUrl = (String)(driver.Capabilities.GetCapability("reportPdfUrl"));

            driver.Close();

            // In case you want to download the report or the report attachments, do it here.
            //try
            //{
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
            try
            {
                reportiumClient.testStart("My test mame", new TestContextTags("tag2", "tag3"));

                // write your code here

                // reportiumClient.testStep("step1"); // this is a logical step for reporting
                // add commands...
                // reportiumClient.testStep("step2");
                // add commands...

                reportiumClient.testStop(TestResultFactory.createSuccess());
            }
            catch (Exception e)
            {
                reportiumClient.testStop(TestResultFactory.createFailure(e.Message, e));
            }
        }
    }
}

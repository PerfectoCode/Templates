using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Reportium.test;
using Reportium.test.Result;
using Reportium.client;
using Reportium.model;

namespace PerfectoLabSeleniumTestProject
{
    /// <summary>
    /// Summary description for RemoteWebDriverTest
    /// 
    /// For programming samples and updated templates refer to the Perfecto GitHub at: https://github.com/PerfectoCode
    /// </summary>
    [TestClass]
    public class RemoteWebDriverTest
    {
        private RemoteWebDriver driver;
        private ReportiumClient reportiumClient;

        [TestInitialize]
        public void PerfectoOpenConnection()
        {
            var browserName = "mobileOS";
            var host = "$Cloud$";

            DesiredCapabilities capabilities = new DesiredCapabilities(browserName, string.Empty, new Platform(PlatformType.Any));
            capabilities.SetCapability("user", "$UserName$");
            
            //TODO: Provide your password
            capabilities.SetCapability("password", "[ENTER YOUR PASSWORD HERE]");

            //TODO: Provide your device ID
            capabilities.SetCapability("deviceName", "[ENTER YOUR DEVICE ID HERE]");

            capabilities.SetPerfectoLabExecutionId(host);

            // Add a persona to your script (see https://community.perfectomobile.com/posts/1048047-available-personas)
            //capabilities.SetCapability(WindTunnelUtils.WIND_TUNNEL_PERSONA_CAPABILITY, WindTunnelUtils.GEORGIA);

            // Name your script
            // capabilities.SetCapability("scriptName", "RemoteWebDriverTest");

            var url = new Uri(string.Format("http$IsConnectUsingHttps$://{0}/nexperience/perfectomobile/wd/hub", host));
            driver = new RemoteWebDriver(url, capabilities);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));

            // Reporting client. For more details, see https://github.com/perfectocode/samples/wiki/reporting
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
        public void WebDriverTestMethod()
        {
            try
            {
                reportiumClient.testStart("My test mame", new TestContextTags("tag2", "tag3"));

                // write your code here

                // reportiumClient.testStep("step1"); // this is a logical step for reporting
                // reportiumClient.testStep("step2");

                reportiumClient.testStop(TestResultFactory.createSuccess());
            }
            catch (Exception e)
            {
                reportiumClient.testStop(TestResultFactory.createFailure(e.Message, e));
            }
        }
    }
}

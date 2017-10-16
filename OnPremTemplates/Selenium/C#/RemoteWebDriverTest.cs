using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;


namespace CSharp
{
    /// <summary>
    /// Summary description for MobileRemoteTest
    /// </summary>
    [TestClass]
    public class RemoteWebDriverTest
    {
        private RemoteWebDriverExtended driver;

        [TestInitialize]
        public void PerfectoOpenConnection()
        {
            var browserName = "mobileOS";

            //TODO: Provide your host and security token
            var host = "myHost.perfectomobile.com";
            var token = "myToken"

            DesiredCapabilities capabilities = new DesiredCapabilities(browserName, string.Empty, new Platform(PlatformType.Any));

            //Old Credentials (Not recommended)
            //capabilities.SetCapability("user", "MY_USER");
            //capabilities.SetCapability("password", "MY_PASSWORD");

            capabilities.SetCapability("securityToken", token);
            capabilities.SetPerfectoLabExecutionId(host);

            // Name your script
            // capabilities.SetCapability("scriptName", "RemoteWebDriverTest");

            var url = new Uri(string.Format("http://{0}/nexperience/perfectomobile/wd/hub", host));
            driver = new RemoteWebDriverExtended(new HttpAuthenticatedCommandExecutor(url), capabilities);
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
        public void WebDriverTestMethod()
        {
            //Write your test here
        }
    }
}

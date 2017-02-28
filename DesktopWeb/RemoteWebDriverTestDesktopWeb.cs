using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;


namespace PerfectoLabSeleniumTestGoogleHomePage
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
            // TODO: Set your cloud host and credentials
            DesiredCapabilities capabilities = new DesiredCapabilities();
            var host = "MY_HOST.perfectomobile.com";
            capabilities.SetCapability("user", "MY_USER");
            capabilities.SetCapability("password", "MY_PASSWORD");

            //TODO: Set the Web Machine configuration, - these capabilities may be copied from the Launch dialogue
            capabilities.SetCapability("platformName", "Windows");
            capabilities.SetCapability("platformVersion", "10");
            capabilities.SetCapability("browserName", "Chrome");
            // browserVersion may be a specific version number or "beta" or "latest" (always the latest version)
            capabilities.SetCapability("browserVersion", "latest");
            capabilities.SetCapability("resolution", "1366x768");
            // location - default may be configured by the site administrator
            capabilities.SetCapability("location", "US East");

            capabilities.SetPerfectoLabExecutionId(host);

            // TODO: Name your script
            //capabilities.SetCapability("scriptName", "RemoteWebDriverTest");

            var url = new Uri(string.Format("http://{0}/nexperience/perfectomobile/wd/hub", host));
            driver = new RemoteWebDriverExtended(new HttpAuthenticatedCommandExecutor(url), capabilities);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30));
        }

        [TestCleanup]
        public void PerfectoCloseConnection()
        {
            // Retrieve the URL of the Single Test Report, can be saved to your execution summary and used to download the report at a later point
            string reportUrl = (string)(driver.Capabilities.GetCapability(WindTunnelUtils.WIND_TUNNEL_REPORT_URL_CAPABILITY));
         
            driver.Close();

            // In case you want to download the report or the report attachments, do it here.
            //try
            //{
                //var parameters = new Dictionary<string, object>();
                //driver.ExecuteScript("mobile:execution:close", parameters);
                //driver.DownloadReport(DownloadReportTypes.pdf, "C:\\test\\report");
                //driver.DownloadAttachment(DownloadAttachmentTypes.video, "C:\\test\\report\\video", "flv");
                //driver.DownloadAttachment(DownloadAttachmentTypes.image, "C:\\test\\report\\images", "jpg");
            //}
            //catch (Exception ex)
            //{
            //    Trace.WriteLine(string.Format("Error getting test logs: {0}", ex.Message));
            //}

            driver.Quit();
        }

        [TestMethod]
        public void SearchGoogle()
        {
            // TODO: Write your test here
            driver.Navigate().GoToUrl("http://www.perfectomobile.com");

            // Take screenshot
            try
            {
                Screenshot screenshotFile = ((ITakesScreenshot)driver).GetScreenshot();
                // TODO: Set your screenshot target folder
                screenshotFile.SaveAsFile(@"C:\Screenshots\SeleniumTestingScreenshot.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}

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
            var token = "MY_TOKEN";

            //var user = "MY_USER";
            //var password = "MY_PASSWORD";
            //capabilities.SetCapability("user", user);
            //capabilities.SetCapability("password", password);

            capabilities.SetCapability("securityToken", token);

            //TODO: Set the Web Machine configuration, for example:
            capabilities.SetCapability("platformName", "Windows");
            capabilities.SetCapability("platformVersion", "8.1");
            capabilities.SetCapability("browserName", "Chrome");
            capabilities.SetCapability("browserVersion", "48");

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

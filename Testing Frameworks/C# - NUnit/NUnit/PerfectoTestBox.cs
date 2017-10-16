using System;
using NUnit.Framework;
using OpenQA.Selenium.Remote;

namespace ReportingTests.NUnit
{
    /// <summary>
    /// Test base class
    /// </summary>
    /// <remarks> 
    /// Create RemoteWebDriverExtended and Reportium client object.
    /// Configure here what happensed before and after each test and
    /// before and after all tests.
    /// </remarks>
    [TestFixture]
    class PerfectoTestBox
    {
        //Perfecto lab security token and host

        private const string PERFECTO_HOST = "myHost.perfectomobile.com";
        private const string PERFECTO_TOKEN = "myToken";

        //Old school credentials:
        //private const string PERFECTO_USER = "MY_USER";
        //private const string PERFECTO_PASS = "MY_PASS";

        internal static RemoteWebDriverExtended driver;

        /// <summary>
        /// Setup once what happens before all tests
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //DesiredCapabilities capabilities = new DesiredCapabilities(browserName, string.Empty, new Platform(PlatformType.Any));
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("securityToken", PERFECTO_TOKEN);

            //Old school credentials:
            //capabilities.SetCapability("user", PERFECTO_USER);
            //capabilities.SetCapability("password", PERFECTO_PASS);

            //Device capabilities
            capabilities.SetCapability("platformName", "Android");

            //Create RemoteWebDriver
            var url = new Uri(string.Format("http://{0}/nexperience/perfectomobile/wd/hub", PERFECTO_HOST));
            driver = new RemoteWebDriverExtended(new HttpAuthenticatedCommandExecutor(url), capabilities);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));

        }

        /// <summary>
        /// Class cleanup (after all tests)
        /// </summary>
        /// <remarks> 
        /// This method runs after all the tests in the class are finished.
        /// </remarks>
        [OneTimeTearDown]
        public static void tearDown()
        {
            driver.Close();
            driver.Quit();
        }

    }
}

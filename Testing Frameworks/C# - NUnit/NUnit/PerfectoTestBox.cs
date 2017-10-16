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

        private const string PERFECTO_HOST = "branchtest.perfectomobile.com";
        private const string PERFECTO_TOKEN = "eyJhbGciOiJSUzI1NiJ9.eyJqdGkiOiJhZTBlNThlNS1jZDc4LTQ2ZjYtYmUwMC04ZmY2Y2Y5NjlhMjQiLCJleHAiOjAsIm5iZiI6MCwiaWF0IjoxNTA3MDI4NTQ0LCJpc3MiOiJodHRwczovL2F1dGgucGVyZmVjdG9tb2JpbGUuY29tL2F1dGgvcmVhbG1zL2JyYW5jaHRlc3QtcGVyZmVjdG9tb2JpbGUtY29tIiwiYXVkIjoib2ZmbGluZS10b2tlbi1nZW5lcmF0b3IiLCJzdWIiOiJhYzc5ZTM4NC04YTA1LTQxMzMtYmNjYi01OWQ1NjYwNTgzNTciLCJ0eXAiOiJPZmZsaW5lIiwiYXpwIjoib2ZmbGluZS10b2tlbi1nZW5lcmF0b3IiLCJzZXNzaW9uX3N0YXRlIjoiMWUzZjNlYjAtZDYyYy00ZDUzLWI5MGYtZjRjNDY5OGRiNDEyIiwiY2xpZW50X3Nlc3Npb24iOiI5OWQ0OTA1OS05YTczLTQwYTMtYTQyNC0xZTRkNTNiNDU5Y2YiLCJyZWFsbV9hY2Nlc3MiOnsicm9sZXMiOlsib2ZmbGluZV9hY2Nlc3MiXX0sInJlc291cmNlX2FjY2VzcyI6eyJhY2NvdW50Ijp7InJvbGVzIjpbIm1hbmFnZS1hY2NvdW50Iiwidmlldy1wcm9maWxlIl19fX0.uhz974LQXQlTcKSWzPZHYH9lj5OJ9zv_JhbhFOKbwCSS49iVoYR2CgzFBGJOALwDoe8uQeqLmYRVSpRlumMPBl8MejZYAa55uH4hUyjBK8HKKhDNlStuRrvzsUGm_ngmmbkOGxAYx68T1EieOm9FVWJ7gqLHwvYTDsRidpjBxgkmbGAnRsAAt-fYUukMwdu2-T4ubcf5Ko5qryxbgCkDpkTlhstL15SVeLmVpsF0zVE3PGePWHOp4oEDWgiQYp1XTkQnHyUre3YqT6U-jHDbMl1WR9m_8IgI7wYjJUMGX54YJgsLZaqrIiymsStUJxlmAIT6nt7KIR_WqgRATcoMeA";

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

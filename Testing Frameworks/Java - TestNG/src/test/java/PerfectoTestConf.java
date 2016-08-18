import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.remote.RemoteWebDriver;
import org.testng.annotations.AfterTest;
import org.testng.annotations.BeforeTest;
import org.testng.annotations.Parameters;

import java.net.MalformedURLException;
import java.net.URL;
import java.util.concurrent.TimeUnit;

/**
 * Test configuration class.
 */
public class PerfectoTestConf {

    final String perfecto_user = "My_User";
    final String perfecto_pass = "My_Pass";
    final String perfecto_host = "My_Host.perfectomobile.com";

    RemoteWebDriver driver;

    /**
     * Before test method , running before each test at the test class.
     * Parameters passed through testng.xml file
     * @param platformName
     * @param platformVersion
     * @param browserName
     * @param browserVersion
     * @param screenResolution
     * @throws MalformedURLException
     */
    @BeforeTest
    @Parameters({"platformName","platformVersion","browserName","browserVersion","screenResolution"})
    public void setup(String platformName, String platformVersion, String browserName, String browserVersion, String screenResolution) throws MalformedURLException {

        DesiredCapabilities capabilities = new DesiredCapabilities();
        capabilities.setCapability("user" , perfecto_user);
        capabilities.setCapability("password" , perfecto_pass);

        capabilities.setCapability("platformName", platformName);
        capabilities.setCapability("platformVersion", platformVersion);
        capabilities.setCapability("browserName", browserName);
        capabilities.setCapability("browserVersion", browserVersion);
        capabilities.setCapability("screenResolution", screenResolution);

        driver = new RemoteWebDriver(new URL("https://" + perfecto_host + "/nexperience/perfectomobile/wd/hub") , capabilities);
        driver.manage().timeouts().implicitlyWait(20, TimeUnit.SECONDS);
        driver.manage().timeouts().pageLoadTimeout(20, TimeUnit.SECONDS);
    }

    /**
     * After test method.
     */
    @AfterTest
    public void tearDown(){
        driver.close();
        driver.quit();
    }

}

import java.io.*;
import java.net.*;
import java.util.*;
import java.util.concurrent.TimeUnit;
import org.openqa.selenium.remote.*;

public class RemoteWebDriverWebDemo {

    public static void main(String[] args) throws MalformedURLException, IOException {
        System.out.println("Run started");

        DesiredCapabilities capabilities = new DesiredCapabilities();
        String host = "myHost.perfectomobile.com";
        String token = "myToken";

        capabilities.setCapability("securityToken", token);

        // TODO: Set the Web Machine configuration, for example:
        capabilities.setCapability("platformName", "Windows");
        capabilities.setCapability("platformVersion", "8.1");
        capabilities.setCapability("browserName", "Firefox");
        capabilities.setCapability("browserVersion", "latest");

        // TODO: Name your script
        capabilities.setCapability("scriptName", "RemoteWebDriverTest");

        RemoteWebDriver driver = new RemoteWebDriver(new URL("https://" + host + "/nexperience/perfectomobile/wd/hub/fast"), capabilities);
        driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
        driver.manage().timeouts().pageLoadTimeout(30, TimeUnit.SECONDS);

        try {
            // TODO: write your code here
            driver.get("http://www.perfectomobile.com");

        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            try {
                driver.close();

            } catch (Exception e) {
                e.printStackTrace();
            }

            driver.quit();
        }
        System.out.println("Run ended");
    }
}

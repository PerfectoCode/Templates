import java.io.*;
import java.net.*;
import java.util.*;
import java.util.concurrent.TimeUnit;
import org.openqa.selenium.remote.*;

public class RemoteWebDriverWebDemo {

    public static void main(String[] args) throws MalformedURLException, IOException {
        System.out.println("Run started");

        DesiredCapabilities capabilities = new DesiredCapabilities();
        String host = "MY_HOST.perfectomobile.com";
        String token = "MY_TOKEN";
        //String user = "MY_USERNAME";
        //String password = "MY_PASSWORD;

        //old credentials:
        //String user = "MY_USERNAME";
        //String password = "MY_PASSWORD";
        //capabilities.setCapability("user", user);
        //capabilities.setCapability("password", password);

        capabilities.setCapability("securityToken", token);

	// TODO: Set the Web Machine configuration
	capabilities.setCapability("platformName", "Windows");
	capabilities.setCapability("platformVersion", "8.1");
	capabilities.setCapability("browserName", "Firefox");
	capabilities.setCapability("browserVersion", "40");
	
	// TODO: Name your script
        //capabilities.setCapability("scriptName", "RemoteWebDriverTest");

        RemoteWebDriver driver = new RemoteWebDriver(new URL("https://" + host + "/nexperience/perfectomobile/wd/hub"), capabilities);
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

                // In case you want to down the report or the report attachments, do it here.
		// Map<String, Object> params = new HashMap<>(); 
                // driver.executeScript("mobile:execution:close", params);
                // PerfectoLabUtils.downloadReport(driver, "pdf", "C:/test/report");
                // PerfectoLabUtils.downloadAttachment(driver, "video", "C:/test/report/video", "flv");
                // PerfectoLabUtils.downloadAttachment(driver, "image", "C:/test/report/images", "jpg");

            } catch (Exception e) {
                e.printStackTrace();
            }

            driver.quit();
        }

        System.out.println("Run ended");
    }
}

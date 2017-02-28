import java.io.*;
import java.net.*;
import java.util.*;
import java.util.concurrent.TimeUnit;
import org.openqa.selenium.remote.*;
import org.openqa.selenium.Cookie.Builder;

import com.perfecto.reportium.client.ReportiumClient;
import com.perfecto.reportium.client.ReportiumClientFactory;
import com.perfecto.reportium.model.Job;
import com.perfecto.reportium.model.PerfectoExecutionContext;
import com.perfecto.reportium.model.Project;
import com.perfecto.reportium.test.TestContext;
import com.perfecto.reportium.test.result.TestResult;
import com.perfecto.reportium.test.result.TestResultFactory;

public class RemoteWebDriverWebDemo {

    public static void main(String[] args) throws MalformedURLException, IOException {
        System.out.println("Run started");

        // TODO: Set your cloud host and credentials
        DesiredCapabilities capabilities = new DesiredCapabilities();
        String host = "MY_HOST.perfectomobile.com";
        capabilities.setCapability("user", "MY_USER");
        capabilities.setCapability("password", "MY_PASSWORD");

	// TODO: Set the Web Machine configuration - these capabilities may be copied from the Launch dialogue
	capabilities.setCapability("platformName", "Windows");
	capabilities.setCapability("platformVersion", "10");
	capabilities.setCapability("browserName", "Chrome");
	// browserVersion may be a specific version number or "beta" or "latest" (always the latest version)
	capabilities.setCapability("browserVersion", "latest");
	capabilities.setCapability("resolution", "1366x768");
	// location - default may be configured by the site administrator
	capabilities.setCapability("location", "US East");	
	// TODO: Name your script
        //capabilities.setCapability("scriptName", "RemoteWebDriverTest");

        RemoteWebDriver driver = new RemoteWebDriver(new URL("https://" + host + "/nexperience/perfectomobile/wd/hub"), capabilities);

        // Reporting client. For more details, see http://developers.perfectomobile.com/display/PD/Reporting
        PerfectoExecutionContext perfectoExecutionContext = new PerfectoExecutionContext.PerfectoExecutionContextBuilder()
                .withProject(new Project("My Project", "1.0"))
                .withJob(new Job("My Job", 45))
                .withContextTags("tag1")
                .withWebDriver(driver)
                .build();
        ReportiumClient reportiumClient = new ReportiumClientFactory().createPerfectoReportiumClient(perfectoExecutionContext);

	driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
        driver.manage().timeouts().pageLoadTimeout(30, TimeUnit.SECONDS);

        try {
	    // Notify Reporting that single test is starting
            reportiumClient.testStart("My test mame", new TestContext("tag2", "tag3"));
            // TODO: write your code here
        	driver.get("http://www.perfectomobile.com");

            // reportiumClient.testStep("step1"); // this is a logical step for reporting
            // reportiumClient.testStep("step2");

            reportiumClient.testStop(TestResultFactory.createSuccess());

        } catch (Exception e) {
            reportiumClient.testStop(TestResultFactory.createFailure(e.getMessage(), e));
            e.printStackTrace();
        } finally {
            try {
                // Retrieve the URL of the Single Test Report, can be saved to your execution summary and used to download the report at a later point
                String reportURL = reportiumClient.getReportUrl();

                // For documentation on how to export reporting PDF, see http://developers.perfectomobile.com/display/PD/PDF+Formatted+Reports
                // String reportPdfUrl = (String)(driver.getCapabilities().getCapability("reportPdfUrl"));

		driver.close();

                // In case you want to download the report attachments, do it here.
                // PerfectoLabUtils.downloadAttachment(driver, "video", "C:/test/report/video", "flv");
                // PerfectoLabUtils.downloadAttachment(driver, "image", "C:/test/report/images", "jpg");

            } catch (Exception e) {
                e.printStackTrace();
            }

            driver.quit();
        }

        System.out.println("Run ended");
    }

    private static void switchToContext(RemoteWebDriver driver, String context) {
        RemoteExecuteMethod executeMethod = new RemoteExecuteMethod(driver);
        Map<String,String> params = new HashMap<String,String>();
        params.put("name", context);
        executeMethod.execute(DriverCommand.SWITCH_TO_CONTEXT, params);
    }

    private static String getCurrentContextHandle(RemoteWebDriver driver) {
        RemoteExecuteMethod executeMethod = new RemoteExecuteMethod(driver);
        String context =  (String) executeMethod.execute(DriverCommand.GET_CURRENT_CONTEXT_HANDLE, null);
        return context;
    }

    private static List<String> getContextHandles(RemoteWebDriver driver) {
        RemoteExecuteMethod executeMethod = new RemoteExecuteMethod(driver);
        List<String> contexts =  (List<String>) executeMethod.execute(DriverCommand.GET_CONTEXT_HANDLES, null);
        return contexts;
    }
}

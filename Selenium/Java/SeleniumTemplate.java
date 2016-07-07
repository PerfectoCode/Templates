import java.awt.Desktop;
import java.net.MalformedURLException;
import java.net.URI;
import java.net.URL;

//Download latest selenium jars from:
//http://www.seleniumhq.org/download/
import org.openqa.selenium.By;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.remote.RemoteWebDriver;

//Downlaod latest reportium sdk from: 
// https://repository-perfectomobile.forge.cloudbees.com/public/com/perfecto/reporting-sdk/reportium-java/
import com.perfecto.reportium.client.ReportiumClient;
import com.perfecto.reportium.client.ReportiumClientFactory;
import com.perfecto.reportium.model.PerfectoExecutionContext;
import com.perfecto.reportium.model.Project;
import com.perfecto.reportium.test.TestContext;
import com.perfecto.reportium.test.result.TestResultFactory;

public class SeleniumTemplate {

	static RemoteWebDriver driver;
	static ReportiumClient reportiumClient;
	
	//TODO: Set your perfecto lab user, password and host name
	static String user = "My_User";
	static String pass = "My_Pass";
	static String host = "My_Host.perfectomobile.com";
	
	//TODO: Set your device desired capabilities
	public static RemoteWebDriver InitDevice() throws MalformedURLException{

		DesiredCapabilities capabilities = new DesiredCapabilities();
		capabilities.setCapability("user", user);
		capabilities.setCapability("password", pass);
		
		//TODO: Set your device capabilities 
		capabilities.setCapability("platformName", "Android");
		capabilities.setCapability("platformVersion", "5.0.1");
		capabilities.setCapability("model", "Nexus 5");
		//capabilities.setCapability("deviceName", "MyDeviceID");
		
		return new RemoteWebDriver(new URL("https://" + host + "/nexperience/perfectomobile/wd/hub") , capabilities);
	}
	
	//Complete the test in the main method
	public static void main(String[] args) throws MalformedURLException {
		
			RemoteWebDriver driver = InitDevice(); 
			ReportiumClient reportiumClient = getReportiumClient(driver);
			
		try{
			
			//START TEST
			//TODO: Set your test name and add tags
			reportiumClient.testStart("My First Selenium-Reportium Test", new TestContext());
			
			//TODO : Write your test
			
			//Test sample: search perfecto in google
			//TODO: Optional: set reportium step for each test step
			reportiumClient.testStep("My first step - search."); //Optional - Set a new test step. 
			driver.get("https://google.com");
			driver.findElement(By.name("q")).sendKeys("Perfecto!");;
			
			//STOP TEST
			reportiumClient.testStop(TestResultFactory.createSuccess());
			
		}catch(Throwable t){
			t.printStackTrace();
			reportiumClient.testStop(TestResultFactory.createFailure(t.getMessage(), t));
		}
		
		try{
			driver.quit();
			
			//Get your report URL
			String reportURL = reportiumClient.getReportUrl();
			System.out.println(reportURL); //Print URL to console
			
			if (Desktop.isDesktopSupported()) {
			    Desktop.getDesktop().browse(new URI(reportURL)); //Open report in default browser
			}
			
		}catch(Exception ex){
			ex.printStackTrace();
		}
		
	}
	
	//TODO: Set your reportium project name, version and a context tag
	public static ReportiumClient getReportiumClient(RemoteWebDriver driver){
		
		PerfectoExecutionContext perfectoExecutionContext = new PerfectoExecutionContext.PerfectoExecutionContextBuilder()
				.withProject(new Project("Sample Selenium-Reportium project" , "1.0")) //Optional
				.withContextTags("Regression" , "SampleTag1" , "SampleTag2") //Optional 
				.withWebDriver(driver)
				.build();
		
		return new ReportiumClientFactory().createPerfectoReportiumClient(perfectoExecutionContext);
	}
	
}

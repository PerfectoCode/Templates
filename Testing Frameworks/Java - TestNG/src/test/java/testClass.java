import org.openqa.selenium.By;
import org.testng.Assert;
import org.testng.annotations.Test;


public class testClass extends PerfectoTestConf {

    /**
     * Test method.
     * Write here your test using "driver" as your webdriver.
     */
    @Test
    public void test_method(){
        //Navigate to url
        driver.get("https://www.google.com");

        //Searching for the search bar and sends string
        driver.findElement(By.name("q")).sendKeys("PerfectoCode GitHub");
    }
}

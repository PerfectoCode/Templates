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

        //Searching for the search butt
        driver.findElement(By.className("sbico")).click();

        //Navigate to the first search result
        driver.findElement(By.cssSelector("#rso > div > div:nth-child(1) > div > div > div._OXf > h3 > a")).click();

        //Assert the title contains expected text
        Assert.assertTrue(driver.getTitle().contains("Perfecto"));
    }
}

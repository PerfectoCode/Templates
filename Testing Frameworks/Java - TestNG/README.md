## Java TestNG

This template using TestNG testing framework and Maven for dependencie managment for Java programming language. 

The template contains two files, the first: [PerfectoTestConf](src/test/java/PerfectoTestConf.java) which includes the configuration of the test.

In this file you will find `@BeforeTest` and `@AfterTest` methods which determines what happens before and after each test.

The second file: [testClass](src/test/java/testClass.java), at this file the tests are implemented.

That way you keep your code DRY (without repeats) and easy to read.

**Quick Start:**
- Import the project to Intellij or Eclipse as a Maven project. 
- Set your Perfecto lab user, password and host at [PerfectoTestConf](src/test/java/PerfectoTestConf.java):
```Java
    final String perfecto_user = "My_User";
    final String perfecto_pass = "My_Pass";
    final String perfecto_host = "My_Host.perfectomobile.com";
```
- At [testng.xml](testng.xml) file set your favorite device DesiredCapabilities: 
```xml
    <test name="Test Android">
        <parameter name="platformName" value="Android" />
        <parameter name="platformVersion" value="" />
        <parameter name="browserName" value="mobileOS" />
        <parameter name="browserVersion" value="" /> <!-- Optional for web machine -->
        <parameter name="screenResolution" value="" />
        <classes>
            <class name="testClass" />
        </classes>
    </test>
```  
- Write your test at [testClass](src/test//java/testClass.java) file and add more test methods with `@Test` annotation.

For the complete documentation of TestNG click [here](http://testng.org/doc/documentation-main.html).

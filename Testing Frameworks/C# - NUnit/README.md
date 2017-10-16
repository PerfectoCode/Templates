## NUnit

This project demonstrates using NUnit testing framework for C#.

The project seperated into two files the first file: [PerfectoTestBox.cs](PerfectoTestBox.cs) which determines the test configuration.
At this file you will find the following properties:<br/>
`[OneTimeSetUp]` - Run before all the tests in the class.<br/>
`[SetUp]` - Run before each test. <br/>
`[TearDown]` - Run after each test.<br/>
`[OneTimeTearDown]` - Run after all tests completed.

The second file [MyTestClass.cs](MyTestClass.cs) include the tests : <br/>
The first test navigates to google and searches for the PerfectoCode repository in GitHub.<br/>
Then clicks on the first search result and asserts that the Keyword *Perfecto* exists in the title of the page. 

**TODO:**
- Make sure you have installed Perfecto [plugin for Visual Studio](https://www.perfectomobile.com/integrations/continuous-quality-integrated-visual-studio).
- Download the project and import the .sln file to Visual Studio IDE.
- Set your Perfecto lab User, Password and Host in the [PerfectoTestBox.cs](PerfectoTestBox.cs) file under *TestFixture* annotation.
```Csharp
  const string PERFECTO_TOKEN = "myToken";
  const string PERFECTO_HOST = "MY_HOST.perfectomobile.com";
```
- Write your tests and add more tests methods with `[TestFixture]` annotation. 
- Run the tests as [NUnit tests](https://www.nuget.org/packages/NUnit/) with the [test explorer](https://msdn.microsoft.com/en-us/library/hh270865.aspx) in Visual Studio.

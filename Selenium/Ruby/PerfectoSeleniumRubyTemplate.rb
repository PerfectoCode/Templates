require 'test/unit'
require 'perfecto-reporting'
require 'selenium-webdriver'

# This template is for users that use DigitalZoom Reporting (ReportiumClient).
# For any other use cases please see the basic template at https://github.com/PerfectoCode/Templates.
# For more programming samples and updated templates refer to the Perfecto Documentation at: http://developers.perfectomobile.com/
class MyTest < Test::Unit::TestCase

  @@User = 'myUser'
  @@Pass = 'myPassword'
  @@Host = 'myHost.perfectomobile.com'

  attr_accessor :driver, :reportiumClient, :exception

  # Called before every test method runs. Can be used
  # to set up fixture information.
  def setup

    capabilities = {
      :platformName => 'Android',
      :model => '',
      :platformVersion => '',
      :browserName => 'mobileOS',
      :browserVersion => '',
      :deviceName => '',
      :user => @@User,
      :password => @@Pass
    }
    _url = 'http://' + @@Host + '/nexperience/perfectomobile/wd/hub'
    @driver = Selenium::WebDriver.for(:remote, :url => _url, :desired_capabilities => capabilities)

    @reportiumClient = create_reportium_client
  end

  # Reporting client. For more details, see http://developers.perfectomobile.com/display/PD/Reporting
  def create_reportium_client
    perfectoExecutionContext = PerfectoExecutionContext.new(
        PerfectoExecutionContext::PerfectoExecutionContextBuilder
            .withProject(Project.new('Reporting SDK Ruby', '1')) # Optional
            .withJob(Job.new('Ruby Job', 1)) # Optional
            .withContextTags('Tag1') # Optional
            .withWebDriver(@driver)
            .build)

    PerfectoReportiumClient.new(perfectoExecutionContext)
  end

  # Called after every test method runs. Can be used to tear
  # down fixture information.

  def teardown

    if self.passed?
      @reportiumClient.testStop(TestResultFactory.createSuccess)
    else
      @reportiumClient.testStop(TestResultFactory.createFailure(@exception.message, @exception))
    end

    @driver.quit

    # Retrieve the URL to the DigitalZoom Report (= Reportium Application) for an aggregated view over the execution
    reportURL = @reportiumClient.getReportUrl

    # Retrieve the URL to the Execution Summary PDF Report
    reportPdfUrl = @driver.capabilities['reportPdfUrl']

    # For detailed documentation on how to export the Execution Summary PDF Report, the Single Test report and other attachments such as
    # video, images, device logs, vitals and network files - see http://developers.perfectomobile.com/display/PD/Exporting+the+Reports

  end

  # Write your test here
  def test_mytest
    begin
      @reportiumClient.testStart(self.name, TestContext.new('Tag2', 'Tag3'))

      # Write your code here

      # @reportiumClient.testStep('step 1')
      # add commands ...
      # @reportiumClient.testStep('step 2')
      # add commands ...

    rescue Exception => exception
      @exception = exception
      raise exception
    end
  end

end
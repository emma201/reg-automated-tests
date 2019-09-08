# CQC Registrations service automated tests
Selenium WebDriver based automated tests for the Registrations digital service.

Technology-wise it is a Microsoft .NET Core project using:

- [.NET Core 2.1](https://dotnet.microsoft.com/download/dotnet-core/2.1)
- [xUnit.net](https://xunit.net/)
- [Fluent Assertions](https://fluentassertions.com/)
- [RestSharp](http://restsharp.org/)
- [Selenium WebDriver](https://www.seleniumhq.org/projects/webdriver/)


## Running tests on local machine

By default the tests run on Chrome browser. In order to run the tests locally, download the [ChromeDriver](https://chromedriver.chromium.org/) to a local path.

Create an environment variable containing that local path to the webdriver:

`ChromeWebDriver=C:\SeleniumWebDrivers\ChromeWebDriver`

Restore the nuget packages for the solution and execute the tests using the Test Explorer.


## Running tests on Azure DevOps

Configure the build variables to include variable for the URL of the service instance to be tested and the web browser to be used for running the tests.

For example:

`Browser = Windows Chrome`
`TestURL = https://service-test-instance.cqc.org.uk`


using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace REG.Automation.Factories
{
    public class DriverFactory : IDisposable
    {
        private readonly int timeout = 30;

        public DriverFactory()
        {
            if (Environment.GetEnvironmentVariable("Browser") == null)
            {
                Browser = "Windows Chrome";
                Environment.SetEnvironmentVariable("Browser", "Windows Chrome");
            }
            else
            {
                Browser = Environment.GetEnvironmentVariable("Browser");
            }

            if (Environment.GetEnvironmentVariable("TestURL") == null)
            {
                Url = "***REMOVED***";
                Environment.SetEnvironmentVariable("TestURL", Url);
            }
            else
            {
                Url = Environment.GetEnvironmentVariable("TestURL");
            }
        }

        public IWebDriver CreateDriver()
        {
            switch (Browser.ToUpperInvariant())
            {
                case "WINDOWS CHROME":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("no-sandbox");
                    chromeOptions.AddAdditionalCapability("useAutomationExtension", false);

                    var chromeDriver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"), chromeOptions);
                    chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
                    chromeDriver.Manage().Cookies.DeleteAllCookies();

                    // Set brwoser window to maximise for Desktop browsers only
                    chromeDriver.Manage().Window.Maximize();

                    return chromeDriver;

                case "IPHONE SAFARI":
                    var capability = new DesiredCapabilities();
                    capability.SetCapability("browserName", "iPhone");
                    capability.SetCapability("device", "iPhone XS");
                    capability.SetCapability("realMobile", "true");
                    capability.SetCapability("os_version", "12");
                    capability.SetCapability("browserstack.user", "***REMOVED***");
                    capability.SetCapability("browserstack.key", "***REMOVED***");
                    capability.SetCapability("name", "REG Smoke Test");

                    var remoteWebDriver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
                    remoteWebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
                    remoteWebDriver.Manage().Cookies.DeleteAllCookies();

                    return remoteWebDriver;

                default:
                    throw new ArgumentException($"{Browser} browser not yet implemented");
            }
        }

        public void Dispose()
        { }

        public string Browser { get; }
        public string Url { get; }
    }
}

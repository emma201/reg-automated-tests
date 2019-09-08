using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace REG.Automation.Pages.Organisation
{
    public class ServiceLocationPage : BasePage
    {
        private readonly IWebDriver driver;

        public ServiceLocationPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement Heading => driver.FindElement(By.XPath(".//h1[contains(.,'Where will the service be provided?')]"));
        public IWebElement OwnHomeOption => driver.FindElement(By.Id("question-1"));
        public IWebElement CarersHomeOption => driver.FindElement(By.Id("question-2"));
        public IWebElement AdaptedAccommodationOption => driver.FindElement(By.Id("question-3"));

    }
}

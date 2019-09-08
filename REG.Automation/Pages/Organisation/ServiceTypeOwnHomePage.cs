using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace REG.Automation.Pages.Organisation
{
    public class ServiceTypeOwnHomePage : BasePage
    {
        private readonly IWebDriver driver;

        public ServiceTypeOwnHomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void SelectAllAndContinue()
        {
            DomiciliaryCareOption.Click();
            SharedLivesSchemeOption.Click();
            SupportedLivingPackageOption.Click();
            Continue();
        }

        public IWebElement Heading => driver.FindElement(By.XPath(".//h1[contains(.,'How will the service be delivered to people in their home?')]"));
        public IWebElement DomiciliaryCareOption => driver.FindElement(By.Id("question-4"));
        public IWebElement SharedLivesSchemeOption => driver.FindElement(By.Id("question-5"));
        public IWebElement SupportedLivingPackageOption => driver.FindElement(By.Id("question-6"));

    }
}

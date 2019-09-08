using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace REG.Automation.Pages.Organisation
{
    public class ServiceTypeAdaptedAccommodationPage : BasePage
    {
        private readonly IWebDriver driver;

        public ServiceTypeAdaptedAccommodationPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void SelectAllAndContinue()
        {
            DomiciliaryCareOption.Click();
            SupportedLivingPackageOption.Click();
            PersonalCareOption.Click();
            Continue();
        }

        public IWebElement Heading => driver.FindElement(By.XPath(".//h1[contains(.,'How will the service be delivered to people in specially adapted accommodation?')]"));
        public IWebElement DomiciliaryCareOption => driver.FindElement(By.Id("question-7"));
        public IWebElement SupportedLivingPackageOption => driver.FindElement(By.Id("question-8"));
        public IWebElement PersonalCareOption => driver.FindElement(By.Id("question-9"));

    }
}

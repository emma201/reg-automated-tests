using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace REG.Automation.Pages
{
    public class TypeOfBusinessPage : BasePage
    {
        private readonly IWebDriver driver;

        public TypeOfBusinessPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement Heading => driver.FindElement(By.XPath(".//h1[contains(.,'What type of business are you?')]"));
        public IWebElement SoleTraderOption => driver.FindElement(By.Id("business-type-individual"));
        public IWebElement OrganisationOption => driver.FindElement(By.Id("business-type-organisation"));
        public IWebElement PartnershipOption => driver.FindElement(By.Id("business-type-partnership"));

    }
}

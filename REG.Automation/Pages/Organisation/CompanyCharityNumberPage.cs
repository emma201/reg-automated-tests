using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace REG.Automation.Pages.Organisation
{
    public class CompanyCharityNumberPage : BasePage
    {
        private readonly IWebDriver driver;

        public CompanyCharityNumberPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement Heading => driver.FindElement(By.XPath(".//h1[contains(.,'Organisation name')]"));
        public IWebElement CompanyNumber => driver.FindElement(By.Id("CompanyNumber"));
        public IWebElement CharityNumber => driver.FindElement(By.Id("CharityNumber"));

    }
}

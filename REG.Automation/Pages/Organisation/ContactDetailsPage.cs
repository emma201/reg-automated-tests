using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace REG.Automation.Pages.Organisation
{
    public class ContactDetailsPage : BasePage
    {
        private readonly IWebDriver driver;

        public ContactDetailsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement Heading => driver.FindElement(By.XPath(".//h1[contains(.,'Organisation name')]"));
        public IWebElement BusinessPhone => driver.FindElement(By.Id("BusinessPhone"));
        public IWebElement BusinessEmail => driver.FindElement(By.Id("BusinessEmail"));

    }
}

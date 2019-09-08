using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace REG.Automation.Pages.Organisation
{
    public class RegisteredAddressPage : BasePage
    {
        private readonly IWebDriver driver;

        public RegisteredAddressPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement Heading => driver.FindElement(By.XPath(".//h1[contains(.,'Organisation name')]"));
        public IWebElement Postcode => driver.FindElement(By.Id("Postcode"));
        public IWebElement SelectAddress => driver.FindElement(By.Id("SelectedAddressUprn"));

    }
}

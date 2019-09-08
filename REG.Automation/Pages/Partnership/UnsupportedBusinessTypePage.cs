using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace REG.Automation.Pages.Partnership
{
    public class UnsupportedBusinessTypePage : BasePage
    {
        private readonly IWebDriver driver;

        public UnsupportedBusinessTypePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement Heading => driver.FindElement(By.XPath(".//h1[contains(.,'Unsupported Business type')]"));

    }
}

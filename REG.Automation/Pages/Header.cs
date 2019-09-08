using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace REG.Automation.Pages
{
    public class Header : BasePage
    {
        private readonly IWebDriver driver;

        public Header(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement CQCLogo => driver.FindElement(By.CssSelector("[src*= '/images/cqc-logo.png']"));
        public IWebElement ServiceName => driver.FindElement(By.XPath(".//span[contains(.,'Register with CQC')]"));

    }
}

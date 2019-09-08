using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace REG.Automation.Pages
{
    public class HomePage : BasePage
    {
        private readonly IWebDriver driver;

        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void ApplyOnline()
        {
            ShowApplyToRegister.Click();
            ApplyOnlineLink.Click();
        }

        public IWebElement Heading => driver.FindElement(By.XPath(".//h1[contains(.,'6 steps to registering with CQC')]"));
        public IWebElement ShowApplyToRegister => driver.FindElement(By.Id("reg_step4_show"));
        public IWebElement ApplyOnlineLink => driver.FindElement(By.Id("reg_step4_apply_register_link"));

    }
}

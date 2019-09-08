using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace REG.Automation.Pages
{
    public class Footer : BasePage
    {
        private readonly IWebDriver driver;

        public Footer(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement PrivacyLink => driver.FindElement(By.Id("LinkToCQCPrivacyStatement"));
        public IWebElement CookiesLink => driver.FindElement(By.Id("LinkToCQCCookieStatement"));
        public IWebElement TAndCLink => driver.FindElement(By.Id("LinkToCQCTermsAndConditionsStatement"));
        public IWebElement Copyright => driver.FindElement(By.XPath(".//li[contains(.,'© Care Quality Commission 2019')]"));

    }
}

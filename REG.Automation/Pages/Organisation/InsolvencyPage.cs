using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace REG.Automation.Pages.Organisation
{
    public class InsolvencyPage : BasePage
    {
        private readonly IWebDriver driver;

        public InsolvencyPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement Heading => driver.FindElement(By.XPath(".//h1[contains(.,'Business Dependencies')]"));
        public IWebElement NoOption => driver.FindElement(By.Id("insolventNo"));

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace REG.Automation.Pages.Organisation
{
    public class TradingNamesPage : BasePage
    {
        private readonly IWebDriver driver;

        public TradingNamesPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement Heading => driver.FindElement(By.XPath(".//h1[contains(.,'Organisation name')]"));
        public IWebElement YesOption => driver.FindElement(By.Id("yes"));
        public IWebElement NoOption => driver.FindElement(By.Id("no"));
        public IWebElement TradingName => driver.FindElement(By.Id("trading-name-1"));

    }
}

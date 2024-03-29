﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace REG.Automation.Pages.SoleTrader
{
    public class TasklistPage : BasePage
    {
        private readonly IWebDriver driver;

        public TasklistPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void ChangeBusinessType()
        {
            ChangeBusinessTypeLink.Click();
        }

        public IWebElement Heading => driver.FindElement(By.XPath(".//h1[contains(.,'Register with CQC')]"));
        public IWebElement ChangeBusinessTypeLink => driver.FindElement(By.CssSelector("[href*= '/application/business-type']"));

    }
}

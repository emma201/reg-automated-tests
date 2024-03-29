﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace REG.Automation.Pages.Organisation
{
    public class RegistrationHistoryPage : BasePage
    {
        private readonly IWebDriver driver;

        public RegistrationHistoryPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement Heading => driver.FindElement(By.XPath(".//h1[contains(.,'Registration history')]"));
        public IWebElement NoOption => driver.FindElement(By.Id("opt_registered_before_no"));

    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace REG.Automation.Pages.Organisation
{
    public class CheckYourAnswersPage : BasePage
    {
        private readonly IWebDriver driver;

        public CheckYourAnswersPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement Heading => driver.FindElement(By.XPath(".//h1[contains(.,'Check your answers')]"));
        public IWebElement ChangeContactDetails => driver.FindElement(By.Id("change_contact_detail"));

    }
}

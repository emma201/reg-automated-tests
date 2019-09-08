using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace REG.Automation.Pages.Organisation
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
        public IWebElement NameAndContactDetailsLink => driver.FindElement(By.CssSelector("[href*= '/business/business-name']"));
        public IWebElement AboutYourOrganisationLink => driver.FindElement(By.CssSelector("[href*= '/business/registration-history']"));
        public IWebElement BusinessStructureLink => driver.FindElement(By.CssSelector("[href*= '/business/business-setup']"));
        public IWebElement CheckYourAnswersLink => driver.FindElement(By.CssSelector("[href*= '/business/organisation-summary']"));

    }
}

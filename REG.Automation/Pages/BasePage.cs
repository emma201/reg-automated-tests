using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace REG.Automation.Pages
{
    public abstract class BasePage : IRegAppPage
    {
        private readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(500);
        }

        public void Continue()
        {
            ContinueButton.Click();
        }

        public void BackToTasklist()
        {
            TasklistLink.Click();
        }

        public string Title => driver.Title;
        public IWebElement ContinueButton => driver.FindElement(By.Id("continue"));
        public IWebElement TasklistLink => driver.FindElement(By.Id("link_back_to_task_list"));

    }
}

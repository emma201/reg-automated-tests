using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace REG.Automation.Pages
{
    public class LoginPage : BasePage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void Login(string url)
        {
            GoToUrl(url);
            LoginId.SendKeys($"***REMOVED***");
            Password.SendKeys($"***REMOVED***");
            LoginButton.Click();
        }

        public IWebElement LoginId => driver.FindElement(By.Id("logonIdentifier"));
        public IWebElement Password => driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => driver.FindElement(By.XPath(".//button[text()='Sign in']"));

    }
}

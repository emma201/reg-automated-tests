using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using REG.Automation.Pages;

namespace REG.Automation.Extensions
{
    public static class CommonPageMethods
    {
        public static void SelectAndContinue(this IRegAppPage page, IWebElement element)
        {
            element.Click();
            page.ContinueButton.Click();
        }

        public static void SelectAndSubmit(this IRegAppPage page, IWebElement element)
        {
            element.Click();
            page.SubmitButton.Click();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace REG.Automation.Pages
{
    public interface IRegAppPage
    {
        IWebElement ContinueButton { get; }
        IWebElement SubmitButton { get; }
    }
}

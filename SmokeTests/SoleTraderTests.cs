using System;
using System.Collections.Generic;
using System.Threading;
using FluentAssertions;
using OpenQA.Selenium;
using Xunit;
using REG.Automation.Extensions;
using REG.Automation.Helpers;
using REG.Automation.Factories;
using REG.Automation.Pages;
using REG.Automation.Pages.SoleTrader;

namespace SmokeTests
{
    public class SoleTrader : IDisposable
    {
        DriverFactory d;
        IWebDriver driver;
        LoginPage loginPage;
        HomePage homePage;
        TypeOfBusinessPage typeofBusinessPage;
        UnsupportedBusinessTypePage unsupportedBusinessTypePage;         

        [Fact]
        // Selecting 'Sole Trader' as type of business displays it is unsupported
        public void Sole_trader_business_type_is_unsupported()
        {
            // act
            typeofBusinessPage.SelectAndContinue(typeofBusinessPage.SoleTraderOption);

            // assert
            unsupportedBusinessTypePage.Heading.Displayed.Should().BeTrue();
        }


        public SoleTrader()
        {
            // arrange
            d = new DriverFactory();
            driver = d.CreateDriver();
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            typeofBusinessPage = new TypeOfBusinessPage(driver);
            unsupportedBusinessTypePage = new UnsupportedBusinessTypePage(driver);

            HttpClientHelper.ClearUserData($"***REMOVED***");

            loginPage.Login(d.Url);
            homePage.ApplyOnline();
        }

        public void Dispose()
        {
            driver.Dispose();
            d.Dispose();
        }
    }
}

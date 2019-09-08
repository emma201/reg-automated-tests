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
using REG.Automation.Pages.Organisation;

namespace SmokeTests
{
    public class SoleTrader : IDisposable
    {
        DriverFactory d;
        IWebDriver driver;
        LoginPage loginPage;
        HomePage homePage;
        TypeOfBusinessPage typeOfBusinessPage;
        UnsupportedBusinessTypePage unsupportedBusinessTypePage;
        REG.Automation.Pages.SoleTrader.TaskListPage taskListPage;
        ServiceLocationPage serviceLocationPage;

        [Fact]
        // Selecting 'Sole Trader' as type of business displays it is unsupported
        public void Sole_trader_business_type_is_unsupported()
        {
            // act
            typeOfBusinessPage.SelectAndContinue(typeOfBusinessPage.SoleTraderOption);

            // assert
            unsupportedBusinessTypePage.Heading.Displayed.Should().BeTrue();
        }

        [Fact]
        // User can change business type from 'Sole Trader' to 'Organisation'
        public void Change_business_type_from_sole_trader_to_organisation()
        {
            // act
            typeOfBusinessPage.SelectAndContinue(typeOfBusinessPage.SoleTraderOption);

            typeOfBusinessPage.GoToUrl(d.Url);
            taskListPage.ChangeBusinessType();
            typeOfBusinessPage.SelectAndContinue(typeOfBusinessPage.OrganisationOption);

            // assert
            serviceLocationPage.Heading.Displayed.Should().BeTrue();
        }


        public SoleTrader()
        {
            // arrange
            d = new DriverFactory();
            driver = d.CreateDriver();
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            typeOfBusinessPage = new TypeOfBusinessPage(driver);
            unsupportedBusinessTypePage = new UnsupportedBusinessTypePage(driver);
            taskListPage = new REG.Automation.Pages.SoleTrader.TaskListPage(driver);
            serviceLocationPage = new ServiceLocationPage(driver);

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

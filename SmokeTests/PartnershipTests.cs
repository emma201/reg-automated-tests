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
using REG.Automation.Pages.Partnership;
using REG.Automation.Pages.Organisation;

namespace SmokeTests
{
    public class Partnership : IDisposable
    {
        DriverFactory d;
        IWebDriver driver;
        LoginPage loginPage;
        HomePage homePage;
        TypeOfBusinessPage typeOfBusinessPage;
        UnsupportedBusinessTypePage unsupportedBusinessTypePage;
        REG.Automation.Pages.Partnership.TasklistPage tasklistPage;
        ServiceLocationPage serviceLocationPage;

        [Fact]
        // Selecting 'Partnership' as type of business displays it is unsupported
        public void Partnership_business_type_is_unsupported()
        {
            // act
            typeOfBusinessPage.SelectAndContinue(typeOfBusinessPage.PartnershipOption);

            // assert
            unsupportedBusinessTypePage.Heading.Displayed.Should().BeTrue();
        }

        [Fact]
        // User can change business type from 'Partnership' to 'Organisation'
        public void Change_business_type_from_partnership_to_organisation()
        {
            // act
            typeOfBusinessPage.SelectAndContinue(typeOfBusinessPage.PartnershipOption);

            typeOfBusinessPage.GoToUrl(d.Url);
            tasklistPage.ChangeBusinessType();
            typeOfBusinessPage.SelectAndContinue(typeOfBusinessPage.OrganisationOption);

            // assert
            serviceLocationPage.Heading.Displayed.Should().BeTrue();
        }


        public Partnership()
        {
            // arrange
            d = new DriverFactory();
            driver = d.CreateDriver();
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            typeOfBusinessPage = new TypeOfBusinessPage(driver);
            unsupportedBusinessTypePage = new UnsupportedBusinessTypePage(driver);
            tasklistPage = new REG.Automation.Pages.Partnership.TasklistPage(driver);
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

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

namespace SmokeTests
{
    public class Launch : IDisposable
    {
        DriverFactory d;
        IWebDriver driver;
        LoginPage loginPage;
        HomePage homePage;
        BusinessTypePage businessTypePage;

        [Fact]
        // Start Page opens and various buttons and links are present
        public void Launch_app()
        {
            // act
            loginPage.GoToUrl(d.Url);

            // assert
            loginPage.Title.Should().Be("Care Quaility Commission - Create Account");
            loginPage.LoginButton.Displayed.Should().BeTrue();
        }

        [Fact]
        // User is able to login to the application
        public void Login_user()
        {
            // act
            loginPage.Login(d.Url);

            //assert
            homePage.Heading.Displayed.Should().BeTrue();
        }

        [Fact]
        // User is able to start online application
        public void Start_online_application()
        {
            // act
            loginPage.Login(d.Url);
            homePage.ApplyOnline();

            //assert
            businessTypePage.Heading.Displayed.Should().BeTrue();
        }

        public Launch()
        {
            // arrange
            d = new DriverFactory();
            driver = d.CreateDriver();
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            businessTypePage = new BusinessTypePage(driver);

            HttpClientHelper.ClearUserData($"***REMOVED***");
        }

        public void Dispose()
        {
            driver.Dispose();
            d.Dispose();
        }
    }
}

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
using REG.Automation.Pages.External;

namespace SmokeTests
{
    public class CommonElements : IDisposable
    {
        DriverFactory d;
        IWebDriver driver;
        LoginPage loginPage;
        HomePage homePage;
        TypeOfBusinessPage typeOfBusinessPage;
        Header header;
        Footer footer;
        PrivacyPage privacyPage;
        CookiesPage cookiesPage;
        TAndCPage tAndCpage;

        [Fact]
        public void Verify_CQC_logo()
        {
            // assert
            header.CQCLogo.Displayed.Should().BeTrue();
        }

        [Fact]
        public void Verify_Service_name()
        {
            // assert
            header.ServiceName.Displayed.Should().BeTrue();
        }

        [Fact]
        public void Verify_Privacy_link()
        {
            // act
            footer.PrivacyLink.Click();

            // assert
            privacyPage.Heading.Displayed.Should().BeTrue();
        }

        [Fact]
        public void Verify_Cookies_link()
        {
            // act
            footer.CookiesLink.Click();

            // assert
            cookiesPage.Heading.Displayed.Should().BeTrue();
        }

        [Fact]
        public void Verify_Terms_and_Conditions_link()
        {
            // act
            footer.TAndCLink.Click();

            // assert
            tAndCpage.Heading.Displayed.Should().BeTrue();
        }

        [Fact]
        public void Verify_Copyright()
        {
            // assert
            footer.Copyright.Displayed.Should().BeTrue();
        }

        public CommonElements()
        {
            // arrange
            d = new DriverFactory();
            driver = d.CreateDriver();
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            typeOfBusinessPage = new TypeOfBusinessPage(driver);
            header = new Header(driver);
            footer = new Footer(driver);
            privacyPage = new PrivacyPage(driver);
            cookiesPage = new CookiesPage(driver);
            tAndCpage = new TAndCPage(driver);

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

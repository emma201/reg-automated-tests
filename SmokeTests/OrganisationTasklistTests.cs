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
    public class OrganisationTasklist : IDisposable
    {
        DriverFactory d;
        IWebDriver driver;
        LoginPage loginPage;
        HomePage homePage;
        TypeOfBusinessPage typeOfBusinessPage;
        UnsupportedBusinessTypePage unsupportedBusinessTypePage;
        REG.Automation.Pages.Organisation.TasklistPage tasklistPage;
        ServiceLocationPage serviceLocationPage;
        ServiceTypeOwnHomePage serviceTypeOwnHomePage;
        ServiceTypeAdaptedAccommodationPage serviceTypeAdaptedAccommodationPage;
        ConfirmTaxonomyPage confirmTaxonomyPage;
        OrganisationNamePage organisationNamePage;
        RegistrationHistoryPage registrationHistoryPage;
        BusinessSetupPage businessSetupPage;
        CheckYourAnswersPage checkYourAnswersPage;

        [Fact]
        public void Change_business_type_from_organisation_to_sole_trader()
        {
            typeOfBusinessPage.GoToUrl(d.Url);
            tasklistPage.ChangeBusinessType();
            typeOfBusinessPage.SelectAndContinue(typeOfBusinessPage.SoleTraderOption);

            unsupportedBusinessTypePage.Heading.Displayed.Should().BeTrue();
        }

        [Fact]
        public void Open_Name_and_contact_details_from_tasklist()
        {
            tasklistPage.NameAndContactDetailsLink.Click();

            organisationNamePage.Heading.Displayed.Should().BeTrue();
        }

        [Fact]
        public void Open_About_your_organisation_from_tasklist()
        {
            tasklistPage.AboutYourOrganisationLink.Click();

            registrationHistoryPage.Heading.Displayed.Should().BeTrue();
        }

        [Fact]
        public void Open_Business_structure_from_tasklist()
        {
            tasklistPage.BusinessStructureLink.Click();

            businessSetupPage.Heading.Displayed.Should().BeTrue();
        }

        [Fact]
        public void Open_Check_your_answers_from_tasklist()
        {
            tasklistPage.CheckYourAnswersLink.Click();

            checkYourAnswersPage.Heading.Displayed.Should().BeTrue();
        }

        [Fact]
        public void User_can_navigate_back_to_tasklist_from_check_your_answers()
        {
            tasklistPage.CheckYourAnswersLink.Click();
            checkYourAnswersPage.BackToTasklist();

            tasklistPage.Heading.Displayed.Should().BeTrue();
        }


        public OrganisationTasklist()
        {
            // arrange
            d = new DriverFactory();
            driver = d.CreateDriver();
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            typeOfBusinessPage = new TypeOfBusinessPage(driver);
            unsupportedBusinessTypePage = new UnsupportedBusinessTypePage(driver);
            tasklistPage = new REG.Automation.Pages.Organisation.TasklistPage(driver);
            serviceLocationPage = new ServiceLocationPage(driver);
            serviceTypeOwnHomePage = new ServiceTypeOwnHomePage(driver);
            serviceTypeAdaptedAccommodationPage = new ServiceTypeAdaptedAccommodationPage(driver);
            confirmTaxonomyPage = new ConfirmTaxonomyPage(driver);
            organisationNamePage = new OrganisationNamePage(driver);
            registrationHistoryPage = new RegistrationHistoryPage(driver);
            businessSetupPage = new BusinessSetupPage(driver);
            checkYourAnswersPage = new CheckYourAnswersPage(driver);

            HttpClientHelper.ClearUserData($"***REMOVED***");

            loginPage.Login(d.Url);
            homePage.ApplyOnline();
            typeOfBusinessPage.SelectAndContinue(typeOfBusinessPage.OrganisationOption);

            serviceLocationPage.OwnHomeOption.Click();
            serviceLocationPage.CarersHomeOption.Click();
            serviceLocationPage.AdaptedAccommodationOption.Click();
            serviceLocationPage.Continue();

            serviceTypeOwnHomePage.DomiciliaryCareOption.Click();
            serviceTypeOwnHomePage.SharedLivesSchemeOption.Click();
            serviceTypeOwnHomePage.SupportedLivingPackageOption.Click();
            serviceTypeOwnHomePage.Continue();

            serviceTypeAdaptedAccommodationPage.DomiciliaryCareOption.Click();
            serviceTypeAdaptedAccommodationPage.SupportedLivingPackageOption.Click();
            serviceTypeAdaptedAccommodationPage.PersonalCareOption.Click();
            serviceTypeAdaptedAccommodationPage.Continue();

            confirmTaxonomyPage.Continue();
        }

        public void Dispose()
        {
            driver.Dispose();
            d.Dispose();
        }
    }
}

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
using REG.Automation.Pages.Organisation;

namespace SmokeTests
{
    public class OrganisationDetails : IDisposable
    {
        DriverFactory d;
        IWebDriver driver;
        LoginPage loginPage;
        HomePage homePage;
        TypeOfBusinessPage typeOfBusinessPage;
        TasklistPage tasklistPage;
        ServiceLocationPage serviceLocationPage;
        ServiceTypeOwnHomePage serviceTypeOwnHomePage;
        ServiceTypeAdaptedAccommodationPage serviceTypeAdaptedAccommodationPage;
        ConfirmTaxonomyPage confirmTaxonomyPage;
        OrganisationNamePage organisationNamePage;
        RegistrationHistoryPage registrationHistoryPage;
        BusinessSetupPage businessSetupPage;
        CheckYourAnswersPage checkYourAnswersPage;
        CompanyCharityNumberPage companyCharityNumberPage;
        TradingNamesPage tradingNamesPage;
        ContactDetailsPage contactDetailsPage;
        RegisteredAddressPage registeredAddressPage;
        BusinessDependenciesPage businessDependenciesPage;
        InsolvencyPage insolvencyPage;

        [Fact]
        public void Submit_complete_organisation_details()
        {
            checkYourAnswersPage.Heading.Displayed.Should().BeTrue();
            checkYourAnswersPage.BackToTasklist();

            tasklistPage.Heading.Displayed.Should().BeTrue();
        }

        [Fact]
        public void Change_details_from_check_your_answers_page()
        {
            checkYourAnswersPage.ChangeContactDetails.Click();
            contactDetailsPage.BusinessPhone.Clear();
            contactDetailsPage.BusinessPhone.SendKeys("0209876543210");
            contactDetailsPage.Submit();
            registeredAddressPage.Submit();
            registrationHistoryPage.Continue();
            businessDependenciesPage.Continue();
            insolvencyPage.Continue();
            businessSetupPage.Continue();

            checkYourAnswersPage.Heading.Displayed.Should().BeTrue();
            checkYourAnswersPage.BackToTasklist();

            tasklistPage.Heading.Displayed.Should().BeTrue();
        }


        public OrganisationDetails()
        {
            // arrange
            d = new DriverFactory();
            driver = d.CreateDriver();
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            typeOfBusinessPage = new TypeOfBusinessPage(driver);
            tasklistPage = new REG.Automation.Pages.Organisation.TasklistPage(driver);
            serviceLocationPage = new ServiceLocationPage(driver);
            serviceTypeOwnHomePage = new ServiceTypeOwnHomePage(driver);
            serviceTypeAdaptedAccommodationPage = new ServiceTypeAdaptedAccommodationPage(driver);
            confirmTaxonomyPage = new ConfirmTaxonomyPage(driver);
            organisationNamePage = new OrganisationNamePage(driver);
            registrationHistoryPage = new RegistrationHistoryPage(driver);
            businessSetupPage = new BusinessSetupPage(driver);
            checkYourAnswersPage = new CheckYourAnswersPage(driver);
            companyCharityNumberPage = new CompanyCharityNumberPage(driver);
            tradingNamesPage = new TradingNamesPage(driver);
            contactDetailsPage = new ContactDetailsPage(driver);
            registeredAddressPage = new RegisteredAddressPage(driver);
            businessDependenciesPage = new BusinessDependenciesPage(driver);
            insolvencyPage = new InsolvencyPage(driver);

            HttpClientHelper.ClearUserData($"***REMOVED***");

            loginPage.Login(d.Url);
            homePage.ApplyOnline();
            typeOfBusinessPage.SelectAndContinue(typeOfBusinessPage.OrganisationOption);

            serviceLocationPage.SelectAllAndContinue();
            serviceTypeOwnHomePage.SelectAllAndContinue();
            serviceTypeAdaptedAccommodationPage.SelectAllAndContinue();
            confirmTaxonomyPage.Continue();

            tasklistPage.NameAndContactDetailsLink.Click();

            organisationNamePage.OrganisationName.SendKeys("Test Organisation");
            organisationNamePage.Submit();
            companyCharityNumberPage.CompanyNumber.SendKeys("XY123456");
            companyCharityNumberPage.CharityNumber.SendKeys("123456A");
            companyCharityNumberPage.Submit();
            tradingNamesPage.SelectAndContinue(tradingNamesPage.NoOption);
            contactDetailsPage.BusinessPhone.SendKeys("020987654321");
            contactDetailsPage.BusinessEmail.SendKeys($"user@test.xyz");
            contactDetailsPage.Submit();
            registeredAddressPage.Postcode.SendKeys("SW1W 9SZ");
            registeredAddressPage.Submit();
            registeredAddressPage.SelectAddress.Click();
            driver.FindElement(By.XPath($"(.//option[text()='151 Buckingham Palace Road, London'])[1]")).Click();
            registeredAddressPage.Submit();
            registrationHistoryPage.SelectAndContinue(registrationHistoryPage.NoOption);
            businessDependenciesPage.SelectAndContinue(businessDependenciesPage.NoOption);
            insolvencyPage.SelectAndContinue(insolvencyPage.NoOption);
            businessSetupPage.SelectAndContinue(businessSetupPage.NoOption);
        }

        public void Dispose()
        {
            driver.Dispose();
            d.Dispose();
        }
    }
}

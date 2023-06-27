using System;
using Allure.Commons;
using Diploma_Zayats.Models;
using Diploma_Zayats.Pages;
using Diploma_Zayats.Utilities.Configuration;
using NUnit.Allure.Attributes;

namespace Diploma_Zayats.Tests.GUI
{
    public class LoginTest : BaseGuiTest
    {
        [Test, Order(1)]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureOwner("User")]
        [AllureSuite("GUI_Suite")]
        [AllureSubSuite("Login")]
        [AllureIssue("Issue - Login with valid credentials")]
        [AllureTms("Login - 1.1")]
        [AllureTag("Smoke")]
        [AllureLink("https://qa_anastasiya_zayats.testmonitor.com/")]
        [Description("Verifying that standart user with valid credentials can login")]
        public void SuccessfullLogin_StandartUser()
        {
            UserBuilder builder = new UserBuilder();

            User standartUser = builder
                .SetUserName(Configurator.Admin.Username)
                .SetPassword(Configurator.Admin.Password)
                .Build();

            var myProjectsPage = new LoginPage(Driver, true)
                .SuccessfulLogin(standartUser);

            //Assert
            Assert.That(myProjectsPage.CheckManageProjectButtonIsDisplayed, Is.True);
        }

        [Test, Order(2)]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureOwner("User with invalid credentials")]
        [AllureSuite("GUI_Suite")]
        [AllureSubSuite("Login")]
        [AllureIssue("Issue - Login with invalid credentials")]
        [AllureTms("Login - 1.2")]
        [AllureTag("Smoke")]
        [AllureLink("https://www.saucedemo.com/")]
        [Description("Verifying that standart user with invalid password can not login. Error is appeared")]
        public void IncorrectLogin_UserWithIncorrectPassword()
        {
            UserBuilder builder = new UserBuilder();

            User userWithInvalidPassword = builder
                .SetUserName(Configurator.UserWithInvalidPassword.Username)
                .SetPassword(Configurator.UserWithInvalidPassword.Password)
                .Build();

            var loginPage = new LoginPage(Driver, true)
                .IncorrectLogin(userWithInvalidPassword);

            var expectedError = "These credentials do not match our records.";

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(loginPage.ErrorMessageIsDisplayed, Is.True);
                Assert.That(loginPage.GetErrorMessage_WhenInvalidPassword, Is.EqualTo(expectedError));
            });
        }
    }
}


using System;
using Diploma_Zayats.Models;
using Diploma_Zayats.Tests.GUI;
using OpenQA.Selenium;

namespace Diploma_Zayats.Pages
{
    public class LoginPage : BasePage
    {
        private static string END_POINT = "";

        By UsernameInputBy = By.Id("email");
        By PasswordInputBy = By.Id("password");
        By LoginButtonBy = By.ClassName("button");
        By ErrorMessageElementBy = By.ClassName("message-body");

        public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }
        public LoginPage(IWebDriver driver) : base(driver, false)
        {
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseGuiTest.BaseUrl);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return Driver.FindElement(LoginButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public LoginPage SetUsername(string name)
        {
            Driver.FindElement(UsernameInputBy).SendKeys(name);

            return this;
        }

        public LoginPage SetUserPassword(string password)
        {
            Driver.FindElement(PasswordInputBy).SendKeys(password);

            return this;
        }

        public void ClickLoginButton()
        {
            Driver.FindElement(LoginButtonBy).Click();
        }

        public MyProjectsPage SuccessfulLogin(User user)
        {
            Login(user);

            return new MyProjectsPage(Driver, true);
        }

        public LoginPage IncorrectLogin(User user)
        {
            Login(user);

            return this;
        }

        private void Login(User user)
        {
            OpenPage();
            SetUsername(user.Username);
            SetUserPassword(user.Password);
            ClickLoginButton();
        }

        public bool ErrorMessageIsDisplayed()
        {
            return Driver.FindElement(ErrorMessageElementBy).Displayed;
        }

        public string GetErrorMessage_WhenInvalidPassword()
        {
            return Driver.FindElement(ErrorMessageElementBy).Text;
        }
    }
}


using System;
using Diploma_Zayats.Tests.GUI;
using OpenQA.Selenium;

namespace Diploma_Zayats.Pages
{
    public class MyProjectsPage : BasePage
    {
        private static string END_POINT = "my-projects";

        By ManageProjectButtonBy = By.ClassName("button");

        public MyProjectsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public MyProjectsPage(IWebDriver driver) : base(driver, false)
        {
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseGuiTest.BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return GetManageProjectButton().Displayed;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public SettingsProjectsPage ManageProject()
        {
            GetManageProjectButton().Click();

            return new SettingsProjectsPage(Driver, true);
        }

        public bool CheckManageProjectButtonIsDisplayed()
        {
            return GetManageProjectButton().Displayed;
        }

        private IWebElement GetManageProjectButton()
        {
            return Driver.FindElement(ManageProjectButtonBy);
        }
    }
}


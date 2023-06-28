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
                return Driver.FindElement(ManageProjectButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public SettingsProjectsPage ManageProject()
        {
            Driver.FindElement(ManageProjectButtonBy).Click();

            return new SettingsProjectsPage(Driver, true);
        }

        public bool CheckManageProjectButtonIsDisplayed()
        {
            return Driver.FindElement(ManageProjectButtonBy).Displayed;
        }
    }
}


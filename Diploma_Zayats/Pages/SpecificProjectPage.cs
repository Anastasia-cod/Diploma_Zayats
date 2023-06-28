using System;
using Diploma_Zayats.Tests.GUI;
using System.Net;
using OpenQA.Selenium;

namespace Diploma_Zayats.Pages
{
    public class SpecificProjectPage : BasePage
    {
        private static string END_POINT = "settings/projects/59";

        By SettingsButtonBy = By.XPath("(//button[@class='button is-white'])[2]");
        By ArchiveElementBy = By.XPath("(//a[@class='dropdown-item'])[3]");
        By ArchiveButtonBy = By.XPath("//button[@class='button is-danger']");

        public SpecificProjectPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public SpecificProjectPage(IWebDriver driver) : base(driver, true)
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
                return Driver.FindElement(SettingsButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public SpecificProjectPage ArchiveSpecificProject()
        {
            var settingsProjectsPage = new SettingsProjectsPage(Driver, true);

            settingsProjectsPage
                .GoToSpecificPage_ClickByProjectTitle()
                .ClickSettingsButton()
                .SelectActionInDropdownSettingsButton()
                .ClickArchiveButton();

            return this;
        }

        public SpecificProjectPage ClickSettingsButton()
        {
            Driver.FindElement(SettingsButtonBy).Click();

            return this;
        }

        public SpecificProjectPage SelectActionInDropdownSettingsButton()
        {
            Driver.FindElement(ArchiveElementBy).Click();

            return this;
        }

        public SpecificProjectPage ClickArchiveButton()
        {
            Driver.FindElement(ArchiveButtonBy).Click();

            return this;
        }
    }
    
}


using System;
using Diploma_Zayats.Tests.GUI;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Diploma_Zayats.Pages
{
    public class SpecificProjectPage : BasePage
    {
        private string END_POINT => $"settings/projects/{GetProjectIdFromUrl()}";

        By SettingsButtonBy = By.XPath("(//button[@class='button is-white'])[2]");
        By ArchiveElementBy = By.XPath("(//a[@class='dropdown-item'])[3]");
        By ArchiveButtonBy = By.XPath("//button[@class='button is-danger']");
        By CancelButtonBy = By.XPath("//div[@class='buttons is-right is-fullwidth']/button[@class='button is-white']");

        public SpecificProjectPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public SpecificProjectPage(IWebDriver driver) : base(driver, true)
        {
        }

        private string GetProjectIdFromUrl()
        {
            string url = Driver.Url;
            int lastSlashIndex = url.LastIndexOf('/');
            int projectIdLength = url.Length - lastSlashIndex - 1;
            string projectId = url.Substring(lastSlashIndex + 1, projectIdLength);

            return projectId;
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
                .GoToSpecificPage_ClickByLastAddedProjectTitle()
                .ClickSettingsButton()
                .SelectActionInDropdownSettingsButton()
                .ClickArchiveButton();

            return this;
        }

        public SpecificProjectPage CancelArchiveSpecificProject()
        {
            var settingsProjectsPage = new SettingsProjectsPage(Driver, true);

            settingsProjectsPage
                .GoToSpecificPage_ClickByFirstAddedProjectTitle()
                .ClickSettingsButton()
                .SelectActionInDropdownSettingsButton()
                .ClickCancelButton();

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

        public SpecificProjectPage ClickCancelButton()
        {
            Driver.FindElement(CancelButtonBy).Click();

            return this;
        }
    }    
}


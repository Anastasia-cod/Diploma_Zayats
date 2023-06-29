using System;
using Diploma_Zayats.Tests.GUI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Diploma_Zayats.Pages
{
    public class ArchivedProjectPage : BasePage
    {
        private static string END_POINT = "settings/archived/projects";

        By BackToProjectsButtonBy = By.XPath("//div[@class='level-item mr-4']");
        By ItemForDisplayedOnThePageElementBy = By.XPath("//span[@class='select']/select");
        By Page100ForDisplayedOnThePageElementBy = By.XPath("//option[@value='100']");
        By LastArchivedProjectElementBy = By.XPath("(//td[@data-label='Project']/div)[last()]");

        public ArchivedProjectPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public ArchivedProjectPage(IWebDriver driver) : base(driver, false)
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
                return Driver.FindElement(BackToProjectsButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string GetLastArchivedProjectTitle()
        {
            ItemForDisplayedOnThePageClick();
            Page100DisplayedOnThePageClick();

            return GetArchivedProjectTitle();
        }

        public string GetArchivedProjectTitle()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            try
            {
                return wait.Until(ExpectedConditions.ElementExists(LastArchivedProjectElementBy)).Text;
            }
            catch (NoSuchElementException)
            {
                throw new ApplicationException("Last archived project element not found");
            }
        }

        public void ItemForDisplayedOnThePageClick()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            try
            {
                var lastPageElement = wait.Until(ExpectedConditions.ElementExists(ItemForDisplayedOnThePageElementBy));
                lastPageElement.Click();
            }
            catch (NoSuchElementException)
            {
                throw new ApplicationException("Last page element not found");
            }
        }

        public ArchivedProjectPage Page100DisplayedOnThePageClick()
        {
            Driver.FindElement(Page100ForDisplayedOnThePageElementBy).Click();

            return this;
        }
    }
}


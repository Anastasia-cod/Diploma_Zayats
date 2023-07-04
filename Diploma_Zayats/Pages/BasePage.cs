using System;
using Diploma_Zayats.Core;
using Diploma_Zayats.Utilities.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Diploma_Zayats.Pages
{
    public abstract class BasePage
    {
        protected static int waitForPageLoadingTime = Configurator.AppSettings.WaitForPageLoadingTime;
        protected static int webdriverWaitTime = Configurator.AppSettings.WebDriverWaitTime;
        protected IWebDriver Driver;
        protected Waits Waits;

        public abstract void OpenPage();
        public abstract bool IsPageOpened();

        public BasePage(IWebDriver driver, bool openPageByUrl)
        {
            Driver = driver;
            Waits = new Waits(Driver, webdriverWaitTime);

            if (openPageByUrl)
            {
                OpenPage();
            }
        }
    }
}


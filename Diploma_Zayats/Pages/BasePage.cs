using System;
using Diploma_Zayats.Core;
using OpenQA.Selenium;

namespace Diploma_Zayats.Pages
{
	public abstract class BasePage
	{
        protected static int waitForPageLoadingTime = 60;
        protected IWebDriver Driver;
        protected WaitService WaitService;

        By ShoppingCartLinkBy = By.ClassName("support-widget-button");

        public abstract void OpenPage();
        public abstract bool IsPageOpened();

        public BasePage(IWebDriver driver, bool openPageByUrl)
        {
            Driver = driver;
            WaitService = new WaitService(Driver);

            if (openPageByUrl)
            {
                OpenPage();
            }
        }
    }
}


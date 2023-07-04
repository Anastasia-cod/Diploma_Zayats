using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Diploma_Zayats.Core
{
    public class Waits
    {
        private WebDriverWait wait;

        public Waits(IWebDriver driver, int waitTime)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
        }

        public IWebElement WaitUntilElementExists(By by)
        {
            return wait.Until(ExpectedConditions.ElementExists(by));
        }

        public IWebElement WaitUntilElementClickable(By by)
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public IWebElement WaitUntilElementVisible(By by)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public bool WaitUntilElementIsDisplayed(By by)
        {
            try
            {
                return wait.Until(ExpectedConditions.ElementIsVisible(by)).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
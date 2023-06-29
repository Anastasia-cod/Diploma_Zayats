﻿using System;
using Diploma_Zayats.Tests.GUI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Diploma_Zayats.Pages
{
    public class IssuesPageOfFirstAddedProject : BasePage
    {
        private string END_POINT = "my-fir/issues";

        By AddIssueButtonBy = By.XPath("//div[@class='control']/div/button[@class='button is-primary']");
        By DialogueWindowElementBy = By.XPath("//form/div[@class='modal-card']");
        By CategoryDropdownElementBy = By.XPath("(//button[@class='button is-fullwidth'])[1]");
        By NameInputBy = By.XPath("//input[@name='name']");
        By DescriptionInputBy = By.XPath("//p[@class='is-empty is-editor-empty']");
        By AddButtonBy = By.XPath("//button[@class='button is-success']");
        By CancelButtonBy = By.XPath("//div[@class='buttons is-right is-fullwidth']/button[@class='button is-white']");

        public IssuesPageOfFirstAddedProject(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public IssuesPageOfFirstAddedProject(IWebDriver driver) : base(driver, true)
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
                return Driver.FindElement(AddIssueButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CheckIsDialogWindowDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            try
            {
                return wait.Until(ExpectedConditions.ElementExists(DialogueWindowElementBy)).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IssuesPageOfFirstAddedProject ClickAddIssueButton()
        {
            Driver.FindElement(AddIssueButtonBy).Click();

            return this;
        }

        public bool CheckCategoryDropdownIsDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            try
            {
                return wait.Until(ExpectedConditions.ElementExists(CategoryDropdownElementBy)).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckNameInputIsDisplayed()
        {
            return Driver.FindElement(NameInputBy).Displayed;
        }

        public bool CheckDescriptionInputIsDisplayed()
        {
            return Driver.FindElement(DescriptionInputBy).Displayed;
        }

        public bool CheckAddButtonIsDisplayed()
        {
            return Driver.FindElement(AddButtonBy).Displayed;
        }

        public bool CheckCancelButtonIsDisplayed()
        {
            return Driver.FindElement(CancelButtonBy).Displayed;
        }

    }
}



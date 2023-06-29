using System;
using Diploma_Zayats.Models;
using Diploma_Zayats.Tests.GUI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Diploma_Zayats.Pages
{
    public class SettingsProjectsPage : BasePage
    {
        private static string END_POINT = "settings/projects";

        By SettingsProjectButtonBy = By.XPath("(//button[@class='button is-white'])[1]");
        By ProjectArchiveElementBy = By.XPath("//div[@class='has-link']/div/a");
        By CreateProjectButtonBy = By.XPath("//div[@class='modal-wizard']/button");
        By NameProjectInputBy = By.XPath("//div[@class='control is-clearfix']/input");
        By DescriptionProjectInputBy = By.XPath("//div[@class='control']/textarea");
        By CancelButtonBy = By.XPath("//div[@class='level-item']/button[@class='button is-white']");
        By FeaturesButtonBy = By.XPath("//div[@class='level-item']/button[@class='button is-primary']");
        By TemplateButtonBy = By.XPath("//div[@class='level-item']/button[@class='button is-primary']");
        By CreateButtonBy = By.XPath("//div[@class='level-item']/button[@class='button is-primary']");
        By LastAddedProjectElementBy = By.XPath("(//div[@class='media-content']/h3)[4]");
        By FirstAddedProjectElementBy = By.XPath("(//div[@class='media-content']/h3)[1]");
        By SuccessAlertElementBy = By.XPath("//div[@role='alert']");


        public SettingsProjectsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public SettingsProjectsPage(IWebDriver driver) : base(driver, false)
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
                return Driver.FindElement(CreateProjectButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool IsSuccessAlertDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            try
            {
                return wait.Until(ExpectedConditions.ElementExists(SuccessAlertElementBy)).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckCreateProjectButtonIsDisplayed()
        {
            return Driver.FindElement(CreateProjectButtonBy).Displayed;
        }

        public bool CheckThatPossibleClickFeatureButton()
        {
            ClickFeaturesButton();

            return Driver.FindElement(TemplateButtonBy).Displayed;
        }

        public SettingsProjectsPage CreateProject(Project project)
        {
            ClickCreateProjectButton();
            SetProjectName(project.Name);
            SetProjectDescription(project.Description);
            ClickFeaturesButton();
            ClickTemplateButton();
            ClickCreateButton();

            return this;
        }

        public SettingsProjectsPage ClickCreateProjectButton()
        {
            Driver.FindElement(CreateProjectButtonBy).Click();

            return this;
        }

        public SettingsProjectsPage SetProjectName(string name)
        {
            Driver.FindElement(NameProjectInputBy).SendKeys(name);

            return this;
        }

        public SettingsProjectsPage SetProjectDescription(string description)
        {
            Driver.FindElement(DescriptionProjectInputBy).SendKeys(description);

            return this;
        }

        public SettingsProjectsPage ClickFeaturesButton()
        {
            Driver.FindElement(FeaturesButtonBy).Click();

            return this;
        }

        public SettingsProjectsPage ClickTemplateButton()
        {
            Driver.FindElement(TemplateButtonBy).Click();

            return this;
        }

        public SettingsProjectsPage ClickCreateButton()
        {
            Driver.FindElement(CreateButtonBy).Click();

            return this;
        }

        public string GetFirstAddedProjectTitle()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            try
            {
                return wait.Until(ExpectedConditions.ElementExists(FirstAddedProjectElementBy)).Text;

            }
            catch (NoSuchElementException)
            {
                throw new ApplicationException("Last added project element not found");
            }
        }

        public string GetLastAddedProjectTitle()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            try
            {
                return wait.Until(ExpectedConditions.ElementExists(LastAddedProjectElementBy)).Text;

            }
            catch (NoSuchElementException)
            {
                throw new ApplicationException("Last added project element not found");
            }
        }

        public SpecificProjectPage GoToSpecificPage_ClickByLastAddedProjectTitle()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement element = wait.Until(ExpectedConditions.ElementExists(LastAddedProjectElementBy));
                element.Click();

                return new SpecificProjectPage(Driver, true);
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public SpecificProjectPage GoToSpecificPage_ClickByFirstAddedProjectTitle()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement element = wait.Until(ExpectedConditions.ElementExists(FirstAddedProjectElementBy));
                element.Click();

                return new SpecificProjectPage(Driver, true);
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public SettingsProjectsPage ClickSettingsProjectButton()
        {
            Driver.FindElement(SettingsProjectButtonBy).Click();

            return this;
        }

        public SettingsProjectsPage ClickProjectArchiveInDropdownSettingsButton()
        {
            Driver.FindElement(ProjectArchiveElementBy).Click();

            return this;
        }
    }
}



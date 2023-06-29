using System;
using Allure.Commons;
using Diploma_Zayats.Models;
using Diploma_Zayats.Pages;
using Diploma_Zayats.Utilities.Configuration;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using OpenQA.Selenium;

namespace Diploma_Zayats.Tests.GUI
{
    [TestFixture]
    public class ProjectTest : BaseGuiTest
    {
        private UserBuilder _userBuilder;
        private User _standartUser;

        [SetUp]
        public void Setup()
        {
            _userBuilder = new UserBuilder();

            _standartUser = _userBuilder
                .SetUserName(Configurator.Admin.Username)
                .SetPassword(Configurator.Admin.Password)
                .Build();

            new LoginPage(Driver)
                .SuccessfulLogin(_standartUser);
        }

        [TestCase("P")]
        [TestCase("New project that contains 99 characters for check that it's ok and the Features button will be clickable after filling")]
        [TestCase("New project that contains 100 characters for check that it's ok and the Features button will be clickable after filling")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureOwner("User")]
        [AllureSuite("GUI_Suite")]
        [AllureSubSuite("Project")]
        [AllureIssue("Issue - check limit values in Name field when creating new project")]
        [AllureTms("Project - P1")]
        [AllureTag("Smoke")]
        [AllureLink("https://qa_anastasiya_zayats.testmonitor.com/")]
        [Description("Verifying that field Name can contains [1-100] characters when creating new project")]
        public void P1_LimitValuesProjectNameInputTest(string projectName)
        {
            var settingsProjectsPage = new SettingsProjectsPage(Driver, true)
                .ClickCreateProjectButton()
                .SetProjectName(projectName);

            Assert.IsTrue(settingsProjectsPage.CheckThatPossibleClickFeatureButton());
        }

        [Test, Order(1)]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureOwner("User")]
        [AllureSuite("GUI_Suite")]
        [AllureSubSuite("Project")]
        [AllureIssue("Issue - create new project")]
        [AllureTms("Project - P2")]
        [AllureTag("Smoke")]
        [AllureLink("https://qa_anastasiya_zayats.testmonitor.com/")]
        [Description("Verifying that standart user with valid credentials can login")]
        public void P2_CreateNewProjectTest()
        {
            var projectName = "New Project GUI test 4";

            ProjectBuilder builder = new ProjectBuilder();

            Project newProject = builder
                .SetProjectName(projectName)
                .SetProjectDescriprion("Create new Project via GUI test - check that all is ok")
                .Build();

            var settingsProjectsPage = new SettingsProjectsPage(Driver, true)
                .CreateProject(newProject);

            Assert.Multiple(() =>
            {
                Assert.That(settingsProjectsPage.IsSuccessAlertDisplayed, Is.True);
                Assert.That(settingsProjectsPage.GetLastAddedProjectTitle, Is.EqualTo(projectName)); ;
            });            
        }

        [Test, Order(2)]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureOwner("User")]
        [AllureSuite("GUI_Suite")]
        [AllureSubSuite("Project")]
        [AllureIssue("Issue - archive the added project")]
        [AllureTms("Project - P3")]
        [AllureTag("Smoke")]
        [AllureLink("https://qa_anastasiya_zayats.testmonitor.com/")]
        [Description("Verifying that it's possible to archive the added project")]
        public void P3_ArchiveAddedProjectTest()
        {
            var lasdAddedTitle = new SettingsProjectsPage(Driver, true)
                .GetLastAddedProjectTitle();

            new SpecificProjectPage(Driver, true)
                .ArchiveSpecificProject();

            var archivedProjectTitle = new ArchivedProjectPage(Driver, true)
                .GetLastArchivedProjectTitle();

            Assert.That(archivedProjectTitle, Is.EqualTo(lasdAddedTitle));
        }

        [Test, Order(3)]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("GUI_Suite")]
        [AllureSubSuite("Project")]
        [AllureIssue("Issue - cancel archive a project")]
        [AllureTms("Project - P4")]
        [AllureTag("Smoke")]
        [AllureLink("https://qa_anastasiya_zayats.testmonitor.com/")]
        [Description("Verifying that it's possible to cancel archive a project, but the test Failed because firstAddedProjectTitle is not match the lastArchivedProjectTitle. Test for check that in case of test failed - the allure take a screenshot.")]
        public void P4_FailedTest_CancelArchiveAddedProjectTest()
        {
            var firstAddedTitle = new SettingsProjectsPage(Driver, true)
                .GetFirstAddedProjectTitle();

            new SpecificProjectPage(Driver, true)
                .CancelArchiveSpecificProject();

            var archivedProjectTitle = new ArchivedProjectPage(Driver, true)
                .GetLastArchivedProjectTitle();

            Assert.That(archivedProjectTitle, Is.EqualTo(firstAddedTitle));
        }
    }
}


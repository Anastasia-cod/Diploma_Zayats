using System;
using Allure.Commons;
using Diploma_Zayats.Models;
using Diploma_Zayats.Pages;
using Diploma_Zayats.Utilities.Configuration;
using NUnit.Allure.Attributes;

namespace Diploma_Zayats.Tests.GUI
{
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
            var projectName = "New Project GUI test 3";

            ProjectBuilder builder = new ProjectBuilder();

            Project newProject = builder
                .SetProjectName(projectName)
                .SetProjectDescriprion("Create new Project via GUI test - check that all is ok")
                .Build();

            var settingsProjectsPage = new SettingsProjectsPage(Driver)
                .CreateProject(newProject);

            Assert.That(settingsProjectsPage.GetLastAddedProjectTitle, Is.EqualTo(projectName));
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
            //var lasdAddedTitle = new SettingsProjectsPage(Driver, true)
            //    .GetLastAddedProjectTitle();

            //new SpecificProjectPage(Driver, true)
            //    .ArchiveSpecificProject();

            var archivedProjectTitle = new ArchivedProjectPage(Driver)
                .GetLastArchivedProjectTitle();

            //Assert.That(lasdAddedTitle, Is.EqualTo(archivedProjectTitle));
            Assert.That(archivedProjectTitle, Is.EqualTo("New Project GUI test 3"));

        }
    }
}


using System;
using Allure.Commons;
using Diploma_Zayats.Models;
using Diploma_Zayats.Pages;
using Diploma_Zayats.Utilities.Configuration;
using NUnit.Allure.Attributes;

namespace Diploma_Zayats.Tests.GUI
{
    [TestFixture]
    public class IssueTest : BaseGuiTest
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

        [Test, Order(1)]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureOwner("User")]
        [AllureSuite("GUI_Suite")]
        [AllureSubSuite("Issue")]
        [AllureIssue("Issue - dialogue window 'Add Issue'")]
        [AllureTms("Issue - I1")]
        [AllureTag("Smoke")]
        [AllureLink("https://qa_anastasiya_zayats.testmonitor.com/")]
        [Description("Verifying that when 'Add Issue' button is clicked - the dialogue window 'Add Issue' appears")]
        public void I1_DialogueWindowAddIssueTest()
        {
            var issuePage = new IssuesPageOfFirstAddedProject(Driver, true)
                .ClickAddIssueButton();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(issuePage.CheckIsDialogWindowDisplayed());
                Assert.IsTrue(issuePage.CheckCategoryDropdownIsDisplayed());
                Assert.IsTrue(issuePage.CheckNameInputIsDisplayed());
                Assert.IsTrue(issuePage.CheckDescriptionInputIsDisplayed());
                Assert.IsTrue(issuePage.CheckAddButtonIsDisplayed());
                Assert.IsTrue(issuePage.CheckCancelButtonIsDisplayed());
            });           
        }
    }
}


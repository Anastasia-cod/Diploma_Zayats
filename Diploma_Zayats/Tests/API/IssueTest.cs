using System;
using Allure.Commons;
using Diploma_Zayats.Models;
using Diploma_Zayats.Utilities.Helpers;
using NLog;
using NUnit.Allure.Attributes;

namespace Diploma_Zayats.Tests.API
{
    public class IssueTest : BaseApiTest
    {
        protected Issue expectedIssueForGet = TestDataHelper.GetIssueFromJsonFile("GetIssue.json");
        protected Issue expectedIssueForCreate = TestDataHelper.GetTestIssue("CreateIssue.json");

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        [Test, Order(1)]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureOwner("User")]
        [AllureSuite("API Suite")]
        [AllureSubSuite("Smoke test - Issue")]
        [AllureIssue("Issue - smoke test: get issue by issueID. GET HTTP-request")]
        [AllureTms("Issue - I1")]
        [AllureTag("Smoke")]
        [AllureLink("https://qa_anastasiya_zayats.testmonitor.com/")]
        [Description("Verifying that issue was retrieved successfully")]
        public void I1_GetIssueTest()
        {
            var actualIssue = _issueService.GetIssue(expectedIssueForGet.Id);

            _logger.Info("Actual Issue: " + actualIssue);
            _logger.Info("Expected Issue: " + expectedIssueForGet);

            Assert.Multiple(() =>
            {
                Assert.That(actualIssue.Id, Is.EqualTo(expectedIssueForGet.Id));
                Assert.That(actualIssue.ProjectId, Is.EqualTo(expectedIssueForGet.ProjectId));
                Assert.That(actualIssue.Name, Is.EqualTo(expectedIssueForGet.Name));
                Assert.That(actualIssue.Description, Is.EqualTo(expectedIssueForGet.Description));
                Assert.That(actualIssue.IssueStatusId, Is.EqualTo(expectedIssueForGet.IssueStatusId));
                Assert.That(actualIssue.IssuePriorrityId, Is.EqualTo(expectedIssueForGet.IssuePriorrityId));
                Assert.That(actualIssue.IssueCategoryId, Is.EqualTo(expectedIssueForGet.IssueCategoryId));

            });
        }

        [Test, Order(2)]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureOwner("User")]
        [AllureSuite("API Suite")]
        [AllureSubSuite("Smoke test - Issue")]
        [AllureIssue("Issue - smoke test: add issue in project by projectID. POST HTTP-request")]
        [AllureTms("Issue - I2")]
        [AllureTag("Smoke")]
        [AllureLink("https://qa_anastasiya_zayats.testmonitor.com/")]
        [Description("Verifying that issue was created successfully")]
        public void I2_AddIssueTest()
        {
            var actualIssue = _issueService.AddIssue(expectedIssueForCreate.ProjectId, expectedIssueForCreate.Name, expectedIssueForCreate.Description, expectedIssueForCreate.IssueStatusId, expectedIssueForCreate.IssuePriorrityId, expectedIssueForCreate.IssueCategoryId);
            _logger.Info("Actual Added Issue: " + actualIssue);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(201, (int)actualIssue.StatusCode);
                Assert.IsNotNull(actualIssue.Content);
            });
        }
    }
}


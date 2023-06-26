using System;
using Diploma_Zayats.Models;
using Diploma_Zayats.Utilities.Helpers;
using NLog;

namespace Diploma_Zayats.Tests.API
{
    public class IssueTest : BaseApiTest
    {
        protected Issue expectedIssueForGet = TestDataHelper.GetIssueFromJsonFile("GetIssue.json");
        protected Issue expectedIssueForCreate = TestDataHelper.GetTestIssue("CreateIssue.json");

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        [Test]
        public void AddIssueTest()
        {
            var actualIssue = _issueService.AddIssue(expectedIssueForCreate.ProjectId, expectedIssueForCreate.Name, expectedIssueForCreate.Description, expectedIssueForCreate.IssueStatusId, expectedIssueForCreate.IssuePriorrityId, expectedIssueForCreate.IssueCategoryId);
            _logger.Info("Actual Added Issue: " + actualIssue);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(201, (int)actualIssue.StatusCode);
                Assert.IsNotNull(actualIssue.Content);
            });
        }

        [Test]
        public void GetIssueTest()
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
    }
}


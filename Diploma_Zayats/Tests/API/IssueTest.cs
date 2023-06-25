using System;
using Diploma_Zayats.Models;
using Diploma_Zayats.Utilities.Helpers;
using NLog;
using RestSharp.Serializers;

namespace Diploma_Zayats.Tests.API
{
    public class IssueTest : BaseApiTest
    {
        protected Issue expectedIssueForGet = TestDataHelper.GetIssueFromJsonFile("TestData/GetIssue.json");

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        [Test]
        public void AddIssueTest()
        {
            int projectId = 1;
            string name = "Create new Issue via API check";
            string description = "New issue via API test";
            int issueStatusId = 2;
            int issuePriorityId = 3;
            int issueCategoryId = 2;

            var response = _issueService.AddIssue(projectId, name, description, issueStatusId, issuePriorityId, issueCategoryId);
            _logger.Info("Actual Issue: " + response);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(201, (int)response.StatusCode);
                Assert.IsNotNull(response.Content);

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


using System;
using Allure.Commons;
using Diploma_Zayats.Models;
using Diploma_Zayats.Services;
using Diploma_Zayats.Utilities.Helpers;
using NLog;
using NUnit.Allure.Attributes;

namespace Diploma_Zayats.Tests.API
{
    public class RequirementTest : BaseApiTest
    {
        protected Requirement expectedRequirementForGet = TestDataHelper.GetRequirementFromJsonFile("GetRequirement.json");

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        [Test]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureOwner("User")]
        [AllureSuite("API Suite")]
        [AllureSubSuite("Smoke test - Requirement")]
        [AllureIssue("Issue - smoke test: get requirement by requirementID. GET HTTP-request")]
        [AllureTms("Requirement - R1")]
        [AllureTag("Smoke")]
        [AllureLink("https://qa_anastasiya_zayats.testmonitor.com/")]
        [Description("Verifying that requirement was retrieved successfully")]
        public void R1_GetRequirementTest()
        {
            var actualRequirement = _requirementService.GetRequirement(expectedRequirementForGet.Id);

            _logger.Info("Actual Requirement: " + actualRequirement);
            _logger.Info("Expected Requirement: " + expectedRequirementForGet);

            Assert.Multiple(() =>
            {
                Assert.That(actualRequirement.Id, Is.EqualTo(expectedRequirementForGet.Id));
                Assert.That(actualRequirement.ProjectId, Is.EqualTo(expectedRequirementForGet.ProjectId));
                Assert.That(actualRequirement.Name, Is.EqualTo(expectedRequirementForGet.Name));
                Assert.That(actualRequirement.Description, Is.EqualTo(expectedRequirementForGet.Description));
                Assert.That(actualRequirement.RequirementTypeId, Is.EqualTo(expectedRequirementForGet.RequirementTypeId));
            });
        }
    }
}


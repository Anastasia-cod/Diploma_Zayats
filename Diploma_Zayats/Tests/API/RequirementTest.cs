using System;
using Diploma_Zayats.Models;
using Diploma_Zayats.Services;
using Diploma_Zayats.Utilities.Helpers;
using NLog;

namespace Diploma_Zayats.Tests.API
{
    public class RequirementTest : BaseApiTest
    {
        protected Requirement expectedRequirementForGet = TestDataHelper.GetRequirementFromJsonFile("GetRequirement.json");

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        [Test]
        public void GetRequirementTest()
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


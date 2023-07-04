using System;
using System.Net;
using Allure.Commons;
using Diploma_Zayats.Client;
using Diploma_Zayats.Models;
using Diploma_Zayats.Services;
using Diploma_Zayats.Utilities.Configuration;
using Diploma_Zayats.Utilities.Helpers;
using NLog;
using NUnit.Allure.Attributes;
using RestSharp;
using RestSharp.Authenticators;

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
        [AllureIssue("Issue - smoke test: get requirement by invalid requirementID. GET HTTP-request")]
        [AllureTms("Requirement - R1")]
        [AllureTag("Smoke")]
        [AllureLink("https://qa_anastasiya_zayats.testmonitor.com/")]
        [Description("Verifying that requirement with invalid requirementId wasn't retrieved successfully.")]
        public void R1_GetNotFoundRequirementByInvalidIdTest()
        {
            var actualRequirement = _requirementService.GetRequirement(expectedRequirementForGet.Id);

            _logger.Info("Actual Requirement: " + actualRequirement);
            _logger.Info("Expected Requirement: " + expectedRequirementForGet);

            Assert.IsNull(actualRequirement, "The actual requirement should be null for an invalid requirementId");
        }
    }   
}


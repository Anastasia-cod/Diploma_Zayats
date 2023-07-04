using Allure.Commons;
using Diploma_Zayats.Client;
using Diploma_Zayats.Services;
using NUnit.Allure.Core;
using NUnit.Framework.Interfaces;

namespace Diploma_Zayats.Tests.API;

[AllureNUnit]
public class BaseApiTest
{
    protected ApiClient _apiClient;
    protected ProjectService _projectService;
    protected IssueService _issueService;
    protected RequirementService _requirementService;

    [OneTimeSetUp]
    public void InitApiClient()
    {
        _apiClient = new ApiClient();
        _projectService = new ProjectService(_apiClient);
        _issueService = new IssueService(_apiClient);
        _requirementService = new RequirementService(_apiClient);
    }
}
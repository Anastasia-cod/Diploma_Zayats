using Diploma_Zayats.Client;
using Diploma_Zayats.Services;

namespace Diploma_Zayats.Tests.API;

public class BaseApiTest
{
    protected ApiClient _apiClient;
    protected ProjectService _projectService;
    protected IssueService _issueService;

    [OneTimeSetUp]
    public void InitApiClient()
    {
        _apiClient = new ApiClient();
        _projectService = new ProjectService(_apiClient);
        _issueService = new IssueService(_apiClient);
    }
}
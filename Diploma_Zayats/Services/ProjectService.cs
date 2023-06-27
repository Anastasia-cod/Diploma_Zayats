using System.Net;
using RestSharp;
using Diploma_Zayats.Client;
using Diploma_Zayats.Models;
using Newtonsoft.Json.Linq;
using Diploma_Zayats.Utilities.Configuration;

namespace Diploma_Zayats.Services;

public class ProjectService : BaseService
{
    public static readonly string GET_PPROJECT = "api/v1/projects/{projectId}";
    public static readonly string ARCHIVE_PPROJECT = "api/v1/project/{projectId}/archive";
    public static readonly string UNARCHIVE_PPROJECT = "api/v1/project/{projectId}/unarchive";

    public ProjectService(ApiClient apiClient) : base(apiClient)
    {
    }

    public Project GetProject(int projectId)
    {
        var request = new RestRequest(GET_PPROJECT)
            .AddUrlSegment("projectId", projectId);

        var response = _apiClient.Execute(request);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            var responseData = JObject.Parse(response.Content);
            return responseData["data"].ToObject<Project>();
        }

        return null;
    }

    public bool ArchiveProject(int projectId)
    {

        var request = new RestRequest(ARCHIVE_PPROJECT, Method.Post)
            .AddUrlSegment("projectId", projectId)
            .AddHeader("Content-Type", "application/json")
            .AddBody("");

        var response =  _apiClient.Execute(request);

        return response.IsSuccessful;
    }
}


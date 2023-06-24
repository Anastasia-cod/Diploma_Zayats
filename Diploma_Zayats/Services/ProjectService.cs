using System.Net;
using RestSharp;
using Diploma_Zayats.Client;
using Diploma_Zayats.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;


namespace Diploma_Zayats.Services;

public class ProjectService : BaseService
{
    public static readonly string GET_ALL_PPROJECT = "/projects";
    public static readonly string GET_PPROJECT = "api/v1/projects/{projectId}";
    public static readonly string ADD_PPROJECT = "api/v1/projects";
    
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
    
    public Project AddProject(Project project1)
    {
        var request = new RestRequest(ADD_PPROJECT, Method.Post)
            .AddHeader("Content-Type", "application/json")
            .AddBody(project1);

        return _apiClient.Execute<Project>(request);
        
        // var request = new RestRequest(ADD_PPROJECT, Method.Post)
        //     .AddHeader("Content-Type", "application/json")
        //     .AddJsonBody(project);
        //
        // var response = _apiClient.Execute(request);
        //
        // if (response.StatusCode == System.Net.HttpStatusCode.Created)
        // {
        //     var responseData = JsonConvert.DeserializeObject<Project>(response.Content);
        //     return responseData;
        // }
        // else
        // {
        //     Console.WriteLine(response.Content); // Print the response content for debugging
        // }
        //
        // return null;
    }

}
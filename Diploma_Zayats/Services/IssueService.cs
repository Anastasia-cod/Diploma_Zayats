using System;
using Diploma_Zayats.Client;
using Diploma_Zayats.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace Diploma_Zayats.Services
{
    public class IssueService : BaseService
    {
        public static readonly string ADD_ISSUE = "api/v1/issues";
        public static readonly string GET_ISSUE = "api/v1/issues/{issueId}";
        public static readonly string GET_TASK_FROM_ISSUE = "api/v1/issues/{issueId}/tasks/{taskId}";

        public IssueService(ApiClient apiClient) : base(apiClient)
        {
        }

        public Issue GetIssue(int issueId)
        {
            var request = new RestRequest(GET_ISSUE)
                .AddUrlSegment("issueId", issueId);

            var response = _apiClient.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseData = JObject.Parse(response.Content);
                return responseData["data"].ToObject<Issue>();
            }

            return null;
        }

        //public RestResponse AddIssue(Issue issue)
        //{
        //    var request = new RestRequest(ADD_ISSUE, Method.Post)
        //        .AddHeader("Content-Type", "application/json")
        //        .AddJsonBody(issue);

        //    return _apiClient.Execute(request);


        public RestResponse AddIssue(int projectId, string name, string description, int issueStatusId, int issuePriorityId, int issueCategoryId)
        {
            var request = new RestRequest(ADD_ISSUE, Method.Post);
            request.AddJsonBody(new
            {
                project_id = projectId,
                name,
                description,
                issue_status_id = issueStatusId,
                issue_priority_id = issuePriorityId,
                issue_category_id = issueCategoryId
            });

            return _apiClient.Execute(request);
        }
    }   
}


using System;
using System.Net;
using Diploma_Zayats.Client;
using Diploma_Zayats.Models;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Diploma_Zayats.Services
{
    public class RequirementService : BaseService
    {
        public static readonly string GET_REQUIREMENT = "api/v1/requirements/{requirementId}";

        public RequirementService(ApiClient apiClient) : base(apiClient)
        {
        }

        public Requirement GetRequirement(int requirementId)
        {
            var request = new RestRequest(GET_REQUIREMENT)
                .AddUrlSegment("requirementId", requirementId);

            var response = _apiClient.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseData = JObject.Parse(response.Content);
                return responseData["data"].ToObject<Requirement>();
            }

            return null;
        }
    }
}


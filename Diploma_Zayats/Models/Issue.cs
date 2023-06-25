using System;
using Newtonsoft.Json;

namespace Diploma_Zayats.Models
{
    public class Issue
    {        
        [JsonProperty("project_id")] public int ProjectId { get; set; }
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("issue_category_id")] public int IssueCategoryId { get; set; }
        [JsonProperty("issue_status_id")] public int IssueStatusId { get; set; }
        [JsonProperty("issue_priority_id")] public int IssuePriorrityId { get; set; }

        protected bool Equals(Issue other)
        {
            return Name == other.Name && ProjectId == other.ProjectId && Description == other.Description && IssueCategoryId == other.IssueCategoryId && IssueStatusId == other.IssueStatusId && IssuePriorrityId == other.IssuePriorrityId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, ProjectId, Description, IssueCategoryId, IssueStatusId, IssuePriorrityId);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            return Equals((Project)obj);
        }

        public override string ToString()
        {
            return $"\n {nameof(Id)}: {Id}\n {nameof(Name)}: {Name},\n {nameof(Description)}: {Description},\n {nameof(ProjectId)}: {ProjectId},\n {nameof(IssueCategoryId)}: {IssueCategoryId}, \n {nameof(IssueStatusId)}: {IssueStatusId}, \n {nameof(IssuePriorrityId)}: {IssuePriorrityId}";
        }
    }
}


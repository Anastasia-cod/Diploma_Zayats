using System;
using Newtonsoft.Json;

namespace Diploma_Zayats.Models
{
    public class Requirement
    { 
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("code")] public string Code { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("project_id")] public int ProjectId { get; set; }
        [JsonProperty("requirement_type_id")] public int RequirementTypeId { get; set; }

        protected bool Equals(Requirement other)
        {
            return Name == other.Name && Code == other.Code && ProjectId == other.ProjectId && Description == other.Description && RequirementTypeId == other.RequirementTypeId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Code, ProjectId, Description, RequirementTypeId);
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
            return $"\n {nameof(Id)}: {Id}\n {nameof(Name)}: {Name},\n {nameof(Code)}: {Code}, \n {nameof(Description)}: {Description},\n {nameof(ProjectId)}: {ProjectId},\n {nameof(RequirementTypeId)}: {RequirementTypeId}";
        }
    }
}


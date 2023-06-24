using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Diploma_Zayats.Models;

public class Project
{
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("symbol_id")] public int SymbolId { get; set; }
    [JsonProperty("id")] public int Id { get; set; }
    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("starts_at")] public DateTime StartsAt { get; set; }
    [JsonProperty("ends_at")] public DateTime EndsAt { get; set; }
    [JsonProperty("uses_applications")] public bool UsesApplications { get; set; }
    [JsonProperty("uses_requirements")] public bool UsesRequirements { get; set; }
    [JsonProperty("uses_risks")] public bool UsesRisks { get; set; }
    [JsonProperty("uses_issues")] public bool UsesIssues { get; set; }
    [JsonProperty("uses_messages")] public bool UsesMessages { get; set; }
    [JsonProperty("completed")] public bool Completed { get; set; }
    
    [JsonProperty("url")] public string Url { get; set; }
    protected bool Equals(Project other)
    {
        return Name == other.Name && Id == other.Id && Description == other.Description && StartsAt == other.StartsAt && EndsAt == other.EndsAt && UsesIssues == other.UsesIssues && UsesRequirements == other.UsesRequirements && Completed == other.Completed;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Id, Description, StartsAt, EndsAt, UsesIssues, UsesRequirements, Completed);
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
        return $"\n {nameof(Id)}: {Id}, \n {nameof(Name)}: {Name},\n {nameof(SymbolId)}: {SymbolId},\n {nameof(Description)}: {Description},\n {nameof(StartsAt)}: {StartsAt}, \n {nameof(EndsAt)}: {EndsAt},\n {nameof(UsesIssues)}: {UsesIssues},\n {nameof(UsesRequirements)}: {UsesRequirements},\n {nameof(Completed)}: {Completed}";
    }
}
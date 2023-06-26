using System.Reflection;
using System.Text.Json;
using Diploma_Zayats.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Diploma_Zayats.Utilities.Helpers;

public class TestDataHelper
{
    public static Project GetTestProject(string fileName)
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData"
                                    + Path.DirectorySeparatorChar + fileName);
        return JsonHelper.FromJson(json).ToObject<Project>();
    }

    public static Issue GetTestIssue(string fileName)
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData"
                                    + Path.DirectorySeparatorChar + fileName);
        return JsonConvert.DeserializeObject<Issue>(json);
    }

    public static Project GetProjectFromJsonFile(string fileName)
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData"
                                    + Path.DirectorySeparatorChar + fileName);
        JObject jsonObject = JObject.Parse(json);

        Project project = new Project
        {
            Id = (int)jsonObject["id"],
            Name = (string)jsonObject["name"],
            Description = (string)jsonObject["description"],
            SymbolId = (int)jsonObject["symbol_id"],
            StartsAt = jsonObject["starts_at"]?.ToObject<DateTime?>(),
            EndsAt = jsonObject["ends_at"]?.ToObject<DateTime?>(),
            UsesIssues = (bool)jsonObject["uses_issues"],
            UsesRequirements = (bool)jsonObject["uses_requirements"],
            Completed = (bool)jsonObject["completed"],
            DeletedAt = jsonObject["deleted_at"]?.ToObject<DateTime?>()

        };

        return project;
    }

    public static Issue GetIssueFromJsonFile(string fileName)
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData"
                                    + Path.DirectorySeparatorChar + fileName);
        JObject jsonObject = JObject.Parse(json);

        Issue issue = new Issue
        {
            Id = (int)jsonObject["id"],
            Name = (string)jsonObject["name"],
            Description = (string)jsonObject["description"],
            IssueCategoryId = (int)jsonObject["issue_category_id"],
            IssuePriorrityId = (int)jsonObject["issue_priority_id"],
            IssueStatusId = (int)jsonObject["issue_status_id"],
            ProjectId = (int)jsonObject["project_id"]
        };

        return issue;
    }

    public static Requirement GetRequirementFromJsonFile(string fileName)
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData"
                                    + Path.DirectorySeparatorChar + fileName);
        JObject jsonObject = JObject.Parse(json);

        Requirement requirement = new Requirement
        {
            Id = (int)jsonObject["id"],
            Code = (string)jsonObject["code"],
            Name = (string)jsonObject["name"],
            Description = (string)jsonObject["description"],
            RequirementTypeId = (int)jsonObject["requirement_type_id"],
            ProjectId = (int)jsonObject["project_id"]
        };

        return requirement;
    }
}
using System.Reflection;
using System.Text.Json;
using Diploma_Zayats.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Diploma_Zayats.Utilities.Helpers;

public class TestDataHelper
{
    public static Project GetTestProject(string FileName)
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData"
                                    + Path.DirectorySeparatorChar + FileName);
        return JsonHelper.FromJson(json).ToObject<Project>();
    }

    //public static Case GetTestCase(string fileName)
    //{
    //    var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    //    var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData"
    //                                + Path.DirectorySeparatorChar + fileName);

    //    return JsonHelper.FromJson(json).ToObject<Case>();
    //}

    //public static Project GetTestProject(string fileName)
    //{
    //    var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    //    var json = File.ReadAllText(Path.Combine(basePath, "TestData", fileName));

    //    return JsonSerializer.Deserialize<Project>(json);
    //}

    //public Issue DeserializeIssueData(string fileName)
    //{
    //    var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    //    var filePath = Path.Combine(basePath, "TestData", fileName);
    //    var json = File.ReadAllText(filePath);

    //    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    //    return JsonSerializer.Deserialize<Issue>(json, options);
    //}

    public static Project GetProjectFromJsonFile(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Could not find file: {filePath}");

        string json = File.ReadAllText(filePath);
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

    public static Issue GetIssueFromJsonFile(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Could not find file: {filePath}");

        string json = File.ReadAllText(filePath);
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
}
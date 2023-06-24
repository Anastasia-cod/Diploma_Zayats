using System.Reflection;
using Diploma_Zayats.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Diploma_Zayats.Utilities.Helpers;

public class TestDataHelper
{
    // public static Project GetTestProject(string FileName)
    // {
    //     var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    //     var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData" 
    //                                 + Path.DirectorySeparatorChar + FileName);
    //     return JsonHelper.FromJson(json).ToObject<Project>();
    // }

    //public static Case GetTestCase(string fileName)
    //{
    //    var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    //    var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData"
    //                                + Path.DirectorySeparatorChar + fileName);

    //    return JsonHelper.FromJson(json).ToObject<Case>();
    //}

    public static Project GetTestProject(string fileName)
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var json = File.ReadAllText(Path.Combine(basePath, "TestData", fileName));
    
        return JsonSerializer.Deserialize<Project>(json);
    }
    
    public static Project LoadProjectFromJsonFile(string filePath)
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
            StartsAt = (DateTime)jsonObject["starts_at"],
            EndsAt = (DateTime)jsonObject["ends_at"],
            UsesIssues = (bool)jsonObject["uses_issues"],
            UsesRequirements = (bool)jsonObject["uses_requirements"],
            Completed = (bool)jsonObject["completed"]
        };

        return project;
    }
}
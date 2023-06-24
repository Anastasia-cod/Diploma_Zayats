using Diploma_Zayats.Models;
using Diploma_Zayats.Utilities.Helpers;
using Newtonsoft.Json.Linq;
using RestSharp;
using NLog;

namespace Diploma_Zayats.Tests.API;

public class ProjectTest : BaseApiTest
{
    protected Project expectedProjectForCreate = TestDataHelper.GetTestProject("CreateProject.json");
    protected Project expectedProjectForGet = TestDataHelper.LoadProjectFromJsonFile("TestData/GetProject.json");

    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    [Test]
    public void AddProjectTest()
    {
        var actualProject = _projectService.AddProject(expectedProjectForCreate);
        
        _logger.Info("Actual Project: " + actualProject);
        //
        // Assert.Multiple(() =>
        // {
        //     Assert.That(actualProject.Name, Is.EqualTo(expectedProjectForCreate.Name));
        //     Assert.That(actualProject.SymbolId, Is.EqualTo(expectedProjectForCreate.SymbolId));
        //     Assert.That(actualProject.Description, Is.EqualTo(expectedProjectForCreate.Description));
        // });
    }

    [Test]
    public void GetProjectsTest()
    {
        var actualProject = _projectService.GetProject(expectedProjectForGet.Id);

        _logger.Info("Actual Project: " + actualProject);
        _logger.Info("Expected Project: " + expectedProjectForGet);

        Assert.Multiple(() =>
        {
            Assert.That(actualProject.Id, Is.EqualTo(expectedProjectForGet.Id));
            Assert.That(actualProject.Name, Is.EqualTo(expectedProjectForGet.Name));
            Assert.That(actualProject.Description, Is.EqualTo(expectedProjectForGet.Description));
            Assert.That(actualProject.SymbolId, Is.EqualTo(expectedProjectForGet.SymbolId));
            Assert.That(actualProject.StartsAt, Is.EqualTo(expectedProjectForGet.StartsAt));
            Assert.That(actualProject.EndsAt, Is.EqualTo(expectedProjectForGet.EndsAt));
            Assert.That(actualProject.UsesIssues, Is.EqualTo(expectedProjectForGet.UsesIssues));
            Assert.That(actualProject.UsesRequirements, Is.EqualTo(expectedProjectForGet.UsesRequirements));
            Assert.That(actualProject.Completed, Is.EqualTo(expectedProjectForGet.Completed));
        });
    }
}
    

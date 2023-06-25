using Diploma_Zayats.Models;
using Diploma_Zayats.Utilities.Helpers;
using Newtonsoft.Json.Linq;
using RestSharp;
using NLog;
using Diploma_Zayats.Services;

namespace Diploma_Zayats.Tests.API;

public class ProjectTest : BaseApiTest
{
    protected Project expectedProjectForCreate = TestDataHelper.GetTestProject("CreateProject.json");
    protected Project expectedProjectForGet = TestDataHelper.GetProjectFromJsonFile("TestData/GetProject.json");

    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    //Doesn't work
    //[Test]
    //public void AddProjectTest()
    //{
    //    var actualProject = _projectService.AddProject(expectedProjectForCreate.Name, expectedProjectForCreate.SymbolId);

    //    _logger.Info("Actual Project: " + actualProject);

    //    Assert.Multiple(() =>
    //    {
    //        Assert.That(actualProject.Name, Is.EqualTo(expectedProjectForCreate.Name));
    //        Assert.That(actualProject.SymbolId, Is.EqualTo(expectedProjectForCreate.SymbolId));
    //        Assert.That(actualProject.Description, Is.EqualTo(expectedProjectForCreate.Description));
    //    });
    //}

    [Test]
    public void GetProjectTest()
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
            Assert.That(actualProject.DeletedAt, Is.EqualTo(expectedProjectForGet.DeletedAt));
        });
    }

    [Test]
    public void ArchiveProjectTest()
    {
        var projectForGet = _projectService.GetProject(expectedProjectForGet.Id);

        var result = _projectService.ArchiveProject(projectForGet.Id);

        Assert.IsTrue(result);

        var archivedProject = _projectService.GetProject(expectedProjectForGet.Id);

        _logger.Info("Archived Project: " + archivedProject);

        Assert.Multiple(() =>
        {
            Assert.IsNotNull(archivedProject.DeletedAt);
            Assert.That(archivedProject.Id, Is.EqualTo(expectedProjectForGet.Id));
        });
        
    }
}

    

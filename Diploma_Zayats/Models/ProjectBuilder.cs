using System;
namespace Diploma_Zayats.Models
{
    public class ProjectBuilder
    {
        private Project project;

        public ProjectBuilder()
        {
            project = new Project();
        }

        public ProjectBuilder SetProjectName(string name)
        {
            project.Name = name;

            return this;
        }

        public ProjectBuilder SetProjectDescriprion(string description)
        {
            project.Description = description;

            return this;
        }

        public Project Build()
        {
            return project;
        }
    }
}


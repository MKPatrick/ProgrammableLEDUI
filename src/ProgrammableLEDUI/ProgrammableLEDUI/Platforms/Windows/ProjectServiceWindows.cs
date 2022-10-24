using Newtonsoft.Json;
using ProgrammableLEDUI.Models;
using ProgrammableLEDUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammableLEDUI.Platforms.Windows
{
    internal class ProjectServiceWindows : IProjectService
    {
        private  string PROJECTSPath = $"{System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\projects.json";
        private List<ProjectModel> _allProjects;

        public ProjectServiceWindows()
        {
            _allProjects = new();
            _allProjects = LoadAllProjects();
        }

        public void CreateNewProject(ProjectModel project)
        {
            _allProjects.Add(project);
            SaveAllProjects();
        }

        public void DeleteProjectByID(string ID)
        {
            throw new NotImplementedException();
        }

        public ProjectModel GetProjectByID(string ID)
        {
            return _allProjects.First(x => x.ID == ID);
        }

        public List<ProjectModel> GetProjects()
        {
            return _allProjects;
        }

        public void SaveProject(ProjectModel project)
        {
            SaveAllProjects();
        }


        private List<ProjectModel> LoadAllProjects()
        {
            if (!File.Exists(PROJECTSPath))
            {
                return new List<ProjectModel>();
            }
            var json = File.ReadAllText(PROJECTSPath);
            return JsonConvert.DeserializeObject<List<ProjectModel>>(json,
          new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
        }


        public void SaveAllProjects()
        {
            string json = JsonConvert.SerializeObject(_allProjects, Formatting.Indented,
     new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            File.WriteAllText(PROJECTSPath, json);
        }

    }
}
